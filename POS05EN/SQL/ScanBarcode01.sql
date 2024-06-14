 -- ScanBarcode01
 -- Internal Barcode


 --DECLARE @id as varchar(13);
 --SET @id = 'TM11120161701'
 DECLARE @id as varchar(13);
 SET @id = ? 
 
 
 BEGIN


   SET NOCOUNT ON;


   DECLARE @_heinv_id as varchar(13);
   DECLARE @_sizecolcode as varchar(2);
   DECLARE @_sizecolcodecustom as varchar(2);
   DECLARE @_UnknownSize as varchar(5);
   DECLARE @_AddCustomRow as tinyint;
   DECLARE @_nowdate as varchar(10);
   DECLARE @_promo_id varchar(10);
   DECLARE @_promo_isfullpriceonly tinyint;


   SET @_heinv_id = substring(@id, 1, 11) + '00';
   SET @_sizecolcode = substring(@id, 12, 2);
   SET @_UnknownSize = 'X?'; 
   SET @_AddCustomRow = 0;
   SET @_nowdate = convert(varchar(10), getdate(), 120);
 

   
   -- PROMO
   select top 1 
     @_promo_id = promo_id, 
     @_promo_isfullpriceonly = isnull(promo_isfullpriceonly, 0)
   from master_promo 
   where 
   convert(varchar(10),promo_datestart,120)<=@_nowdate and convert(varchar(10),promo_dateend,120)>= @_nowdate;
   	

   SELECT 
   heinv_id,heinv_art,heinv_mat,heinv_col,heinv_name,heinv_descr,heinv_isdisabled,heinv_priceori,heinv_price01,heinv_pricedisc01,heinv_price02,heinv_pricedisc02,heinv_price03,heinv_pricedisc03,heinv_price04,heinv_pricedisc04,heinv_price05,heinv_pricedisc05,heinvgro_id,heinvctg_id,season_id,region_id,
   region_nameshort=(SELECT region_nameshort FROM master_region WHERE region_id=A.region_id),
   pricegross = heinv_price01,
   pricediscp = heinv_pricedisc01,
   pricenett =  heinv_price01 * ((100.00-heinv_pricedisc01)/100.00),
   priceissp = (case when (heinv_price01 < heinv_priceori) AND (heinv_pricedisc01 = 0) then 1 else 0 end), 
   activepromo_id = @_promo_id,
   promo_isfullpriceonly = @_promo_isfullpriceonly,
   promo_disc = CASE WHEN @_promo_id is null then 0 else 
			         CASE WHEN @_promo_isfullpriceonly=1 AND ((heinv_price01 * ((100.00-heinv_pricedisc01)/100.00)) < heinv_priceori) then 0 else
						  CASE WHEN (select count(*) from master_promoex where promo_id=@_promo_id and heinv_id=A.heinv_id) > 0 then
							   (SELECT disc FROM master_promoex where promo_id=@_promo_id and heinv_id=A.heinv_id)
						  ELSE
						       isnull((SELECT disc FROM master_promodetil 
							   where 
							   promo_id=@_promo_id and heinvctg_id = A.heinvctg_id
							   and
							   (season='ALL' or season like '%' + A.season_id + '%')), 0)
						  END
					 end
                end
   INTO #tempHEINVRaw
   FROM master_heinv A
   WHERE heinv_isdisabled=0 AND heinv_id = @_heinv_id



   SELECT A.heinv_id, C.* 
   INTO #tempHEINV
   FROM 
   ( #tempHEINVRaw A left join master_heinvctg B
     on A.heinvctg_id = B.heinvctg_id AND A.region_id = B.region_id
   ) left join master_heinvsizetag C
     on B.region_id=C.region_id AND B.heinvctg_sizetag = C.SIZETAG




   SELECT heinv_id, colname, sizeval
   INTO #tempHEINVSizeRaw
   FROM (select * from #tempHEINV) AS P1
        UNPIVOT
                 (sizeval for colname in(C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25)) AS P2
   


   SELECT id=substring(heinv_id, 1, 11)+substring(colname, 2, 2), heinv_id, colname, sizeval, sizecode=substring(colname, 2, 2), seq='10'
   INTO #tempHEINVSize
   FROM #tempHEINVSizeRaw
   WHERE sizeval<>''
   


   /*
   IF (SELECT COUNT(*) FROM #tempHEINVSize) = 0 
   BEGIN
     INSERT INTO #tempHEINVSize
     SELECT @id, @_heinv_id, 'C??', @_UnknownSize, '??', '90'
                    --                      COL    SIZE           CODE
   END
   ELSE
   BEGIN
    -- Cek Barcode
    IF (SELECT COUNT(*) FROM #tempHEINVSize WHERE sizecode=@_sizecolcode) = 0
    BEGIN


     IF (SELECT COUNT(*) FROM #tempHEINVSize) > 1 
      SET @_AddCustomRow = 1
     ELSE
      IF @_sizecolcode<>'00' SET @_AddCustomRow = 1;


     IF @_AddCustomRow>0
     BEGIN
      SET @_sizecolcodecustom = CASE WHEN @_sizecolcode='00' THEN '??' ELSE @_sizecolcode END;
      INSERT INTO #tempHEINVSize
      SELECT @id, @_heinv_id, 'C'+@_sizecolcodecustom, @_UnknownSize, @_sizecolcodecustom, '90'
     END


    END
   END
   */

   --select * from #tempHEINVSize


   SET NOCOUNT OFF;
   IF @_sizecolcode='00'
   BEGIN
    SELECT 
     iteminventory_id = A.id,
     iteminventory_idsc = A.heinv_id,
     iteminventory_barcode = @id,
     iteminventory_sizecode = A.sizecode,
     iteminventory_name = B.heinv_name,
     iteminventory_article = B.heinv_art,
     iteminventory_material = B.heinv_mat,
     iteminventory_color = B.heinv_col,
     iteminventory_size = A.sizeval,
	 iteminventory_priceori = heinv_priceori,
     iteminventory_sellpricedefault = pricegross,
     iteminventory_discountdefault = CASE WHEN B.priceissp=1 OR B.promo_disc<=pricediscp THEN pricediscp ELSE B.promo_disc END,
     iteminventory_pricenet = CASE WHEN B.priceissp=1 OR B.promo_disc<=pricediscp THEN pricenett ELSE pricegross * ((100.00-B.promo_disc)/100.00) END,
     iteminventory_isadddisc=0,
     iteminventorygroup_id = B.heinvgro_id,
     iteminventorysubgroup_id = B.heinvctg_id,
     region_id = B.region_id,
     region_nameshort = B.region_nameshort,
     colname,
     sizetag = isnull((SELECT SIZETAG FROM #tempHEINV WHERE heinv_id=A.heinv_id),''),     
	 pricingrule = (CASE WHEN B.priceissp=0 AND B.promo_disc > pricediscp THEN B.activepromo_id ELSE '01' END),
     [proc]='01',
	 B.priceissp,
	 B.activepromo_id,
	 B.promo_isfullpriceonly,
	 B.promo_disc
    FROM #tempHEINVSize A INNER JOIN #tempHEINVRaw B
      ON A.heinv_id = B.heinv_id
    ORDER BY A.seq
   END
   ELSE
   BEGIN
    SELECT 
     iteminventory_id = A.id,
     iteminventory_idsc = A.heinv_id,
     iteminventory_barcode = @id,
     iteminventory_sizecode = A.sizecode,
     iteminventory_name = B.heinv_name,
     iteminventory_article = B.heinv_art,
     iteminventory_material = B.heinv_mat,
     iteminventory_color = B.heinv_col,
     iteminventory_size = A.sizeval,
	 iteminventory_priceori = heinv_priceori,
     iteminventory_sellpricedefault = pricegross,
     iteminventory_discountdefault = CASE WHEN B.priceissp=1 OR B.promo_disc<=pricediscp THEN pricediscp ELSE B.promo_disc END,
     iteminventory_pricenet = CASE WHEN B.priceissp=1 OR B.promo_disc<=pricediscp THEN pricenett ELSE pricegross * ((100.00-B.promo_disc)/100.00) END,
     iteminventory_isadddisc=0,
     iteminventorygroup_id = B.heinvgro_id,
     iteminventorysubgroup_id = B.heinvctg_id,
     region_id = B.region_id,
     region_nameshort = B.region_nameshort,
     colname,
     sizetag = isnull((SELECT SIZETAG FROM #tempHEINV WHERE heinv_id=A.heinv_id),''),
     pricingrule = (CASE WHEN B.priceissp=0 AND B.promo_disc > pricediscp THEN B.activepromo_id ELSE '01' END),
     [proc]='01',
	 B.priceissp,
	 B.activepromo_id,
	 B.promo_isfullpriceonly,
	 B.promo_disc
    FROM #tempHEINVSize A INNER JOIN #tempHEINVRaw B
      ON A.heinv_id = B.heinv_id
    WHERE id=@id
    ORDER BY A.seq
   END


   SET NOCOUNT ON;
   DROP TABLE #tempHEINVRaw;
   DROP TABLE #tempHEINV;
   DROP TABLE #tempHEINVSizeRaw;
   DROP TABLE #tempHEINVSize;
 
  END


