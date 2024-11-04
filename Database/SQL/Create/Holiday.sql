 
  if exists ( select * from sys.tables where name = N'Holiday')
 DROP TABLE [Holiday];
 CREATE TABLE [Holiday] (
  [Id] int identity(1,1) primary key clustered not null,
 [EmpNode] [hierarchyid]  NOT NULL,
 EmpRecordChangeDate smalldatetime,
	VacationStartDate smalldatetime,--luna inceput concdiu --[LN]                               Integer, 
	VacationStartDay integer, -- ziau de incput a conceiului,tabela contine o line pt fiecre luna de concediu, sau pt aceeasi luna pot fi 
	--2 record daca isi ia N zi la inceput si M zile la sfarsit; deci de cate ori isi ia concediu cate on linie in tabela
	NumberofVacationDays		Integer,--[ZCO]                              Integer, 
	CalculationBase		money, --[BAZ]                              Numeric(10,2), --idiotic base , should be 0
	IncreaseCode		char(8),--[CSPOR]                            Char(8), 
	IncreaseValue		money, --increase value, calculated --[VSPOR]                            Numeric(10,2), 
	VacationValueGross				money,--[VALCOB]                           Numeric(10,2), 
	CalculatedTax		money, --impozitul pe concediu,--[IMPZ]                             Numeric(10,2), 
	CalculatedContributionToRetirement money,--[CTR7]                             Numeric(10,2), 
	CalculatedContributionToHealth money,--[CTR3]                             Numeric(10,2), 
	CalculatedContributionToUnemployment money,--[CTR1]                             Numeric(10,2), 
	--[CTR6]                             Numeric(10,2), --?
	Retains numeric(10,2),--retineri,--[SRET]                             Numeric(10,2), 
	FinalNetValueVacationMoney numeric(10,2),----[VALCON]                           Numeric(10,2), calculated net value after decreasing all the taxes and contributions
	CalculationDate	             smalldatetime, --[LNP]                              Integer, 
	--[RM]                               Numeric(7,3), regim de munca; se ia din params RNO8  si se inmultit cu 8
	[CurrentYearMonthlyWorkHours] numeric(7,3), -- regim de munca; se ia din params ZILE_ANC_CurrentYearMonthlyWorkDays si se inmultit cu 8;
	--daca e pe anul viitor se asuma sau se dialogheaza, deci pe februarie dex sunt 20 zile deci zile_ANC*8.
	ReCalculatedVacationValueNet	     money,----[VALCOBR]                          Numeric(10,2),value of net holiday money reclculated
	DateWhenVacationIsIntroduced  smalldatetime,----[ZINT]                             Integer, ziua-data when the vacation is introduced in the system
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
	--[ZC]                               Integer, ?
	--[SCOMP]                            Numeric(10,2), ? sume compensate
	--[SCOMPR]                           Numeric(10,2), ? sume compensate recalculate
	--[SP]                               Integer, ? sporuri
	--[ANC]                              Integer, -anul curent este in Params table, n-am nevoie pt ca am CalculationDate
	--[BAZAC]                            Numeric(10,2), ? posibil nefolosita
	--[VALCOBRP]                         Numeric(10,2), ? necompletat
	--[PR_PV]                            Numeric(6,2), ? percent ?
	--[SALT]                             Numeric(10,2), ?
	--[IMPZV]                            Numeric(10,2), ?
	--[DEDCUV]                           Numeric(10,2), --deducere cuvenita
	--[ZIL]                              Integer, ?
	--[ANCA]                             Integer, -anul in care calculeaza concediul, n-am nevoie pt ca am CalculationDate
	--[CEDS]                             Char(1) ?
);
