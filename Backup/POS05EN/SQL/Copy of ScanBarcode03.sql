DECLARE @criteria as varchar(255)
SET @criteria = ?
--SET @criteria = 'heinv_art = ''50163865''';
--SET @criteria = 'heinv_art = ''111.389''';


BEGIN


   SET NOCOUNT ON;


   DECLARE @id as varchar(13);
   DECLARE @_heinv_id as varchar(13);
   DECLARE @_sizecolcode as varchar(2);
   DECLARE @_UnknownSize as varchar(5);
   DECLARE @SQL as varchar(3000);
   DECLARE @heinv_art as varchar(30);
   DECLARE @heinv_mat as varchar(30);
   DECLARE @heinv_col as varchar(30);


   SET @_UnknownSize = 'X?'; 
   

   CREATE TABLE #tempHEINVRaw (
    [heinv_id] [varchar](13) NOT NULL,
    [heinv_art] [varchar](30) NULL,
    [heinv_mat] [varchar](30) NULL,
    [heinv_col] [varchar](30) NULL,
    [heinv_name] [varchar](40) NULL,
    [heinv_descr] [varchar](50) NULL,
    [heinv_isdisabled] [tinyint] NOT NULL   DEFAULT ((0)),
    [heinv_priceori] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_price01] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_pricedisc01] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_price02] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_pricedisc02] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_price03] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_pricedisc03] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_price04] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_pricedisc04] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_price05] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_pricedisc05] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
    [heinv_createby] [varchar](30) NOT NULL,
    [heinv_createdate] [smalldatetime] NOT NULL   DEFAULT (getdate()),
    [heinv_modifyby] [varchar](30) NULL,
    [heinv_modifydate] [smalldatetime] NULL,
    [heinvgro_id] [varchar](10) NOT NULL,
    [heinvctg_id] [varchar](10) NOT NULL,
    [season_id] [varchar](10) NOT NULL   DEFAULT ((0)),
    [region_id] [varchar](5) NOT NULL   DEFAULT ((0)),
    [rowid] [varchar](50) NOT NULL   DEFAULT (newid()),
    [region_nameshort] [varchar](50) NOT NULL DEFAULT '',
	[pricegross] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
	[pricediscp] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
	[pricenett] [decimal](18, 0) NOT NULL   DEFAULT ((0)),
	[priceissp] [tinyint],
	[activepromo_id] [varchar] (10),
	[promo_isfullpriceonly] [tinyint],
	[promo_disc] [int]
   )


   -- PROMO
   


   SET @SQL = '
			   DECLARE @_nowdate as varchar(10);
			   DECLARE @_promo_id varchar(10);
			   DECLARE @_promo_isfullpriceonly tinyint;

			   SET @_nowdate = convert(varchar(10), getdate(), 120);

			   
			   select top 1 
				 @_promo_id = promo_id, 
				 @_promo_isfullpriceonly = isnull(promo_isfullpriceonly, 0)
			   from master_promo 
			   where 
			   convert(varchar(10),promo_datestart,120)<=@_nowdate and convert(varchar(10),promo_dateend,120)>= @_nowdate
			   
		   
               INSERT INTO #tempHEINVRaw 
               SELECT TOP 30
			   [heinv_id], [heinv_art], [heinv_mat], [heinv_col], [heinv_name], [heinv_descr], [heinv_isdisabled], [heinv_priceori], [heinv_price01], [heinv_pricedisc01], [heinv_price02], [heinv_pricedisc02], [heinv_price03], [heinv_pricedisc03], [heinv_price04], [heinv_pricedisc04], [heinv_price05], [heinv_pricedisc05], [heinv_createby], [heinv_createdate], [heinv_modifyby], [heinv_modifydate], [heinvgro_id], [heinvctg_id], [season_id], [region_id], [rowid], 	
			   region_nameshort=(SELECT region_nameshort FROM master_region WHERE region_id = A.region_id),
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
							   (season=''ALL'' or season like ''%'' + A.season_id + ''%'')), 0)
						  END
					 end
                end  		   		    			   
			   FROM master_heinv A WHERE heinv_isdisabled=0 AND ' + @criteria + '
			   ';
			   

   EXEC(@SQL)


   
   SELECT A.heinv_id, A.heinv_art, A.heinv_mat, A.heinv_col, C.* 
   INTO #tempHEINV
   FROM 
   ( #tempHEINVRaw A left join master_heinvctg B
     on A.heinvctg_id = B.heinvctg_id AND A.region_id = B.region_id
   ) left join master_heinvsizetag C
     on B.region_id=C.region_id AND B.heinvctg_sizetag = C.SIZETAG


   



   SELECT heinv_id, heinv_art, heinv_mat, heinv_col, colname, sizeval
   INTO #tempHEINVSizeRaw
   FROM (select * from #tempHEINV) AS P1
        UNPIVOT
                 (sizeval for colname in(C01, C02, C03, C04, C05, C06, C07, C08, C09, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25)) AS P2


   SELECT id=substring(heinv_id, 1, 11)+substring(colname, 2, 2), heinv_id, heinv_art, heinv_mat, heinv_col, colname, sizeval, sizecode=substring(colname, 2, 2), seq='10'
   INTO #tempHEINVSize
   FROM #tempHEINVSizeRaw
   WHERE sizeval<>''
   AND colname <= 'C25'

/*
   -- Memunculkan alternatif pilihan X?, agar user bisa isi size sendiri, syaratya apabila user mencari artikel secara explicit   
   IF  (SELECT COUNT(distinct heinv_art) FROM #tempHEINV)=1  -- Mencari artikel secara explisit, tanpa menggunakan like, atau menggunakan like, tapi cuma ketemu satu artikel
   BEGIN



    IF (SELECT COUNT(*) FROM #tempHEINVSize)=0 
    BEGIN

	 -- kalau disini biasanya karena category dan sizetag belum di copy ke database POS 

      SELECT TOP 1
      @id=heinv_id, 
      @_heinv_id=heinv_id,
      @heinv_art = heinv_art,
      @heinv_mat = heinv_mat,
      @heinv_col = heinv_col
      FROM
      #tempHEINV

      INSERT INTO #tempHEINVSize
      SELECT @id, @_heinv_id, @heinv_art, @heinv_mat, @heinv_col, 'C??', @_UnknownSize, '??', '90'
      --                                                          COL    SIZE           CODE
    END

   END     
*/


   SELECT 
   TOP 50
    iteminventory_id = A.id,
    iteminventory_idsc = A.heinv_id,
    iteminventory_barcode = '',
    iteminventory_sizecode = A.sizecode,
    iteminventory_name = B.heinv_name,
    iteminventory_article = B.heinv_art,
    iteminventory_material = B.heinv_mat,
    iteminventory_color = B.heinv_col,
    iteminventory_size = A.sizeval,
	iteminventory_priceori = heinv_priceori,
    iteminventory_sellpricedefault = pricegross,
	item_disc = pricediscp,
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
	[proc]='03',
	B.priceissp,
	B.activepromo_id,
	B.promo_isfullpriceonly,
	B.promo_disc
   FROM #tempHEINVSize A INNER JOIN #tempHEINVRaw B
     ON A.heinv_id = B.heinv_id
   ORDER BY B.heinv_mat, B.heinv_col, A.seq




   SET NOCOUNT ON;
   DROP TABLE #tempHEINVRaw;
   DROP TABLE #tempHEINV;
   DROP TABLE #tempHEINVSizeRaw;
   DROP TABLE #tempHEINVSize;




END

