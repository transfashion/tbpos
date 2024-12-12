 declare @bon_id AS varchar(40)
 declare @bon_idext AS varchar(50) 
 declare @bon_event AS varchar(30) 
 declare @bon_date AS smalldatetime 
 declare @bon_createby AS varchar(30) 
 declare @bon_createdate AS smalldatetime 
 declare @bon_modifyby AS varchar(30) 
 declare @bon_modifydate AS smalldatetime 
 declare @bon_isvoid AS tinyint 
 declare @bon_voiddate AS smalldatetime 
 declare @bon_replacefromvoid AS varchar(40) 
 declare @bon_msubtotal AS decimal(18, 0) 
 declare @bon_msubtvoucher AS decimal(18, 0) 
 declare @bon_msubtdiscadd AS decimal(18, 0) 
 declare @bon_msubtredeem AS decimal(18, 0) 
 declare @bon_msubtracttotal AS decimal(18, 0) 
 declare @bon_msubtotaltobedisc AS decimal(18, 0) 
 declare @bon_mdiscpaympercent AS decimal(18, 0) 
 declare @bon_mdiscpayment AS decimal(18, 0) 
 declare @bon_mtotal AS decimal(18, 0) 
 declare @bon_mpayment AS decimal(18, 0) 
 declare @bon_mrefund AS decimal(18, 0) 
 declare @bon_msalegross AS decimal(18, 0) 
 declare @bon_msaletax AS decimal(18, 0) 
 declare @bon_msalenet AS decimal(18, 0) 
 declare @bon_itemqty AS int 
 declare @bon_rowitem AS int 
 declare @bon_rowpayment AS int 
 declare @bon_npwp AS varchar(50) 
 declare @bon_fakturpajak AS varchar(50) 
 declare @bon_adddisc_authusername AS varchar(50) 
 declare @bon_disctype AS varchar(30)
 declare @customer_id AS varchar(30) 
 declare @customer_name AS varchar(30) 
 declare @customer_telp AS varchar(30)
 declare @customer_npwp AS  varchar(30)
 declare @customer_ageid AS  varchar(30)
 declare @customer_agename AS  varchar(30)
 declare @customer_genderid AS  varchar(30)
 declare @customer_gendername AS  varchar(30)
 declare @customer_nationalityid AS  varchar(30)
 declare @customer_nationalityname AS  varchar(30)
 declare @customer_typename AS varchar(30)
 declare @customer_passport AS varchar(50)
 declare @customer_disc int
 declare @voucher01_id AS  varchar(30)
 declare @voucher01_name AS  varchar(30)
 declare @voucher01_codenum AS  varchar(30)
 declare @voucher01_method AS  varchar(30)
 declare @voucher01_type AS  varchar(30)
 declare @voucher01_discp AS  decimal(18, 0)
 declare @salesperson_id AS varchar(10) 
 declare @salesperson_name AS varchar(30) 
 declare @pospayment_id AS varchar(10) 
 declare @pospayment_name AS varchar(30) 
 declare @posedc_id AS varchar(10) 
 declare @posedc_name AS varchar(30) 
 declare @machine_id AS varchar(10)
 declare @region_id AS varchar(5)
 declare @branch_id AS varchar(7) 
 declare @syncode AS varchar(50) 
 declare @syndate AS smalldatetime 
 declare @rowid AS varchar(50)
 declare @site_id_from AS varchar(20)


BEGIN

	set @bon_id = ?
 	set @bon_idext = ?
 	set @bon_event = ?
 	set @bon_date = ?
 	set @bon_createby = ?
 	set @bon_createdate = ?
 	set @bon_modifyby = ?
 	set @bon_modifydate = ?
 	set @bon_isvoid = ?
 	set @bon_voiddate = ?
 	set @bon_replacefromvoid = ?
 	set @bon_msubtotal = ?
 	set @bon_msubtvoucher = ?
 	set @bon_msubtdiscadd = ?
 	set @bon_msubtredeem = ?
 	set @bon_msubtracttotal = ?
 	set @bon_msubtotaltobedisc  = ?
 	set @bon_mdiscpaympercent  = ?
 	set @bon_mdiscpayment  = ?
 	set @bon_mtotal  = ?
 	set @bon_mpayment = ?
 	set @bon_mrefund = ?
 	set @bon_msalegross = ?
 	set @bon_msaletax  = ?
 	set @bon_msalenet  = ?
 	set @bon_itemqty  = ?
 	set @bon_rowitem = ?
 	set @bon_rowpayment = ?
 	set @bon_npwp = ?
 	set @bon_fakturpajak = ?
 	set @bon_adddisc_authusername  = ?
 	set @bon_disctype  = ?
 	set @customer_id  = ?
 	set @customer_name = ?
 	set @customer_telp = ?
 	set @customer_npwp  = ?
 	set @customer_ageid = ?
 	set @customer_agename  = ?
 	set @customer_genderid = ?
 	set @customer_gendername = ?
 	set @customer_nationalityid = ?
 	set @customer_nationalityname = ?
 	set @customer_typename  = ?
 	set @customer_passport = ?
 	set @customer_disc = ?
 	set @voucher01_id = ?
 	set @voucher01_name = ?
 	set @voucher01_codenum  = ?
 	set @voucher01_method = ?
	set @voucher01_type = ?
 	set @voucher01_discp  = ?
 	set @salesperson_id  = ?
 	set @salesperson_name  = ?
 	set @pospayment_id = ?
 	set @pospayment_name = ?
 	set @posedc_id = ?
 	set @posedc_name  = ?
 	set @machine_id  = ?
 	set @region_id  = ?
 	set @branch_id  = ?
 	set @syncode  = ?
 	set @syndate  = ?
 	set @rowid = ?
 	set @site_id_from = ?

	SET NOCOUNT ON


	DECLARE @bon_idexttax as varchar(50);
	DECLARE @bon_branchtaxcode as varchar(30);


	EXEC dbo.poshe_TrnBon_InsertSequencer @region_id, @branch_id, @machine_id, @bon_id OUTPUT, @bon_branchtaxcode OUTPUT, 0
	EXEC dbo.poshe_TrnBon_InsertSequencerTax @region_id, @branch_id, @customer_nationalityid,  @bon_fakturpajak OUTPUT, @bon_idexttax OUTPUT, 0


 IF @bon_id IS NULL
 BEGIN
  RAISERROR ('[poshe_TrnBon_Insert]: bon_id is NULL, dbo.poshe_TrnBon_InsertSequencer tidak menghasilkan data', 16, 1);
  RETURN;
 END




 SET @bon_createdate = getdate();
 SET @bon_modifyby = NULL;
 SET @bon_modifydate = NULL;
 SET @bon_isvoid = 0;
 SET @bon_voiddate = NULL;
 SET @bon_replacefromvoid = NULL;
 SET @syncode = NULL; 
 SET @syndate = NULL;
 SET @rowid = newid();




 INSERT INTO transaksi_hepos (
     bon_id, 
     bon_idext, 
     bon_event, 
     bon_date, 
     bon_createby, 
     bon_createdate, 
     bon_modifyby, 
     bon_modifydate, 
     bon_isvoid, 
     bon_voiddate, 
     bon_replacefromvoid, 
     bon_msubtotal, 
     bon_msubtvoucher, 
     bon_msubtdiscadd, 
     bon_msubtredeem, 
     bon_msubtracttotal, 
     bon_msubtotaltobedisc, 
     bon_mdiscpaympercent, 
     bon_mdiscpayment, 
     bon_mtotal, 
     bon_mpayment, 
     bon_mrefund, 
     bon_msalegross, 
     bon_msaletax, 
     bon_msalenet, 
     bon_itemqty, 
     bon_rowitem, 
     bon_rowpayment, 
     bon_npwp, 
	 bon_fakturpajak,
	 bon_adddisc_authusername,
	 bon_disctype,
     customer_id, 
     customer_name, 
     customer_telp,
     customer_npwp,
     customer_ageid,
     customer_agename,
     customer_genderid,
     customer_gendername,
     customer_nationalityid,
     customer_nationalityname,
	 customer_typename,
	 customer_passport,
	 customer_disc,
     voucher01_id,
     voucher01_name,
     voucher01_codenum,
     voucher01_method,
     voucher01_type,
     voucher01_discp,
     salesperson_id, 
     salesperson_name, 
     pospayment_id, 
     pospayment_name, 
     posedc_id, 
     posedc_name, 
     machine_id, 
     region_id, 
     branch_id, 
     syncode, 
     syndate, 
     rowid,
     site_id_from
   ) VALUES (
     @bon_id, 
     @bon_idext, 
     @bon_event, 
     @bon_date, 
     @bon_createby, 
     @bon_createdate, 
     @bon_modifyby, 
     @bon_modifydate, 
     @bon_isvoid, 
     @bon_voiddate, 
     @bon_replacefromvoid, 
     @bon_msubtotal, 
     @bon_msubtvoucher, 
     @bon_msubtdiscadd, 
     @bon_msubtredeem, 
     @bon_msubtracttotal, 
     @bon_msubtotaltobedisc, 
     @bon_mdiscpaympercent, 
     @bon_mdiscpayment, 
     @bon_mtotal, 
     @bon_mpayment, 
     @bon_mrefund, 
     @bon_msalegross, 
     @bon_msaletax, 
     @bon_msalenet, 
     @bon_itemqty, 
     @bon_rowitem, 
     @bon_rowpayment, 
     @bon_npwp, 
	 @bon_fakturpajak,
	 @bon_adddisc_authusername,
	 @bon_disctype,
     @customer_id, 
     @customer_name, 
     @customer_telp,
     @customer_npwp,
     @customer_ageid,
     @customer_agename,
     @customer_genderid,
     @customer_gendername,
     @customer_nationalityid,
     @customer_nationalityname,
	 @customer_typename,
	 @customer_passport,
	 @customer_disc,
     @voucher01_id,
     @voucher01_name,
     @voucher01_codenum,
     @voucher01_method,
     @voucher01_type,
     @voucher01_discp,
     @salesperson_id, 
     @salesperson_name, 
     @pospayment_id, 
     @pospayment_name, 
     @posedc_id, 
     @posedc_name, 
     @machine_id, 
     @region_id, 
     @branch_id, 
     @syncode, 
     @syndate, 
     @rowid,
     @site_id_from
   );


  

	 SET NOCOUNT OFF;
	 SELECT * FROM transaksi_hepos
	 WHERE 
	 bon_id = @bon_id

END