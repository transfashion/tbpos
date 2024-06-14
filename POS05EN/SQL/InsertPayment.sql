declare @bon_id AS varchar(40)
declare @payment_line AS int
declare @payment_cardnumber AS varchar(40)
declare @payment_cardholder AS varchar(40)
declare @payment_mvalue AS decimal(18,0)
declare @payment_mcash AS decimal(18,0)
declare @payment_installment AS int
declare @pospayment_id AS varchar(10)
declare @pospayment_name AS varchar(30)
declare @pospayment_bank AS varchar(30)
declare @posedc_id AS varchar(10)
declare @posedc_name AS varchar(30)
declare @posedc_approval AS varchar(30)




BEGIN

	set	@bon_id = ?
	set	@payment_line = ?
	set	@payment_cardnumber = ?
	set	@payment_cardholder = ?
	set	@payment_mvalue = ?
	set	@payment_mcash = ?
	set	@payment_installment = ?
	set	@pospayment_id = ?
	set	@pospayment_name = ?
	set	@pospayment_bank = ?
	set	@posedc_id = ?
	set	@posedc_name = ?
	set	@posedc_approval = ?


	SET NOCOUNT ON

	INSERT INTO transaksi_hepospayment
	(
		bon_id,
		payment_line,
		payment_cardnumber,
		payment_cardholder,
		payment_mvalue,
		payment_mcash,
		payment_installment,
		pospayment_id,
		pospayment_name,
		pospayment_bank,
		posedc_id,
		posedc_name,
		posedc_approval
	) VALUES (
		@bon_id,
		@payment_line,
		@payment_cardnumber,
		@payment_cardholder,
		@payment_mvalue,
		@payment_mcash,
		@payment_installment,
		@pospayment_id,
		@pospayment_name,
		@pospayment_bank,
		@posedc_id,
		@posedc_name,
		@posedc_approval
	)

	SELECT * FROM transaksi_hepospayment
	WHERE
	bon_id = @bon_id AND payment_line=@payment_line


END
