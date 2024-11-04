  
  --exista si BoliIst si fisist(de la flrc)
  --tre sa creez o tabela cu nomenclatorul de boli COBO, CODB este codboala si CODBN , codul bolii date de medic
  if exists ( select * from sys.tables where name = N'Disease')
 DROP TABLE [Disease];
 CREATE TABLE [Disease] (
	 [Id] int identity(1,1) primary key clustered not null ,
	 [EmpNode] hierarchyid  NOT NULL,
	 EmpRecordChangeDate smalldatetime,
	CodeDisease integer, --cod boala => trebuie migrat si nomenclatorul de boli din fcod,--[CODB]                             Integer, 
	StartDateofMedicalHoliday smalldatetime, -- ziua cand se acorda concediu medical, --[ZI_INC]                           Integer, 
	NoDiseaseDayCalend integer,--[NR_ZI_C]                          Integer, 
	NoDiseaseDayWork integer,--[NR_ZI_L]                          Integer, 
	NoDiseaseDayWorkPaidByEmployer integer,--[NR_ZI_LU]                         Integer, 
	NoDiseaseDayWorkPaidByGovt integer,--[NR_ZI_LB]                         Integer, 
	NetSalaryOnTheLast12Months money,--[BAZA]                             Numeric(10,2), --claculata luata din istoric (flrc) se iau cele 12 luni salar si se aduna
	NetSalaryPerDayOnTheLast12Months money,--calculata : impart netul la cate zile lucratoare sunt in anterior 12 luni, care se baseaza pe zile_ANA si zile_anc								 --[BAZA_ZI]                          Numeric(8,2), 
	NoWorkDaysPerLast12Months integer, --[NR_ZILN] Integer, --may not need it pot sa le tin in params, luate din zile_ANA si ZILE_ANC pe baz careiase calculeaza NetSalaryPerDayOnTheLastTwelveMonths
	NoCalendDaysPerLast12Months integer, ----[NR_ZILC]  Integer,  may not need it, pot sa le tin in params, luate din zile_ANA si ZILE_ANC pe baz careiase calculeaza NetSalaryPerDayOnTheLastTwelveMonths
	StartDateOfTheDisease smalldatetime, -- --[DPR]                              DateTime, ,ziua exact cand incepe boala
	EndDateOfTheDisease smalldatetime, -- --[DIR]                              DateTime, ziua exact cand se termina boala
	DiseaseIsInitialOrContinued	bit, ----[TIP_C]                            Char(1), boala  este intiala sau continuRE
	MedCertificateCode char(2), ----[COD]                              Char(2), mpat la codul bolii CODB
	MedCertificateSerie char(10),--[SERIE]                            Char(10), 
	MedCertificateNo char(10),--[NUMAR]                            Char(10), 
	MedCertificateCodeContinue char(2), ----[CODI]                             Char(2), mpat la codul bolii CODB
	MedCertificateSerieContinued char(10),--[SERIEI]                            Char(10), 
	MedCertificateNumberContinued char(10),--[NUMARI]                            Char(10), 
	UrgencyCode char(3),--[COD_URG]                          Char(3), 
	ContagiousCode					char(2),--[COD_CONTAG]                       Char(2), 
	ChildCnp	numeric(13,0),--[CNP_COPIL]                        Numeric(13,0), 
	DoctorLicenseNumber char(10),--[ME_NR]                            Char(10), 
	DateMedicalCertificate smalldatetime,--[DATA_ACORD]                       DateTime, 
	LocationCode	integer, --1,2 sau 3, 1=medic fam, 2=spital, 3=? --unde a fost dat certificatul medical;--[LOC_PRES]                         Integer, 
	DiagnosticCode integer,-- e sris pe cert medical;--[COD_DIAG]                         Integer, 
	OtherPersonInCareCnp numeric(13,0),
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
	);--daca e un adult in ingrijire--[CNP_ADULT]                        Numeric(13,0));

--[L1]                               Numeric(10,4), --reprezint veniturile pe fiecare luna anteriorara  pe 12 luni din urma  
--[L2]                               Numeric(10,4), --sunt sin in in FLRC!!! si folosescla calclarea BAZA si BAZA_ZI
--[L3]                               Numeric(10,4), 
--[L4]                               Numeric(10,4), 
--[L5]                               Numeric(10,4), 
--[L6]                               Numeric(10,4), 
--[L7]                               Numeric(10,4), 
--[L8]                               Numeric(10,4), 
--[L9]                               Numeric(10,4), 
--[L10]                              Numeric(10,4), 
--[L11]                              Numeric(10,4), 
--[L12]                              Numeric(10,4), 
--[D1]                               Integer, --reprezinat o data de 6 caractere corecpunzatoare luna-an pt claculul BAZa si BAZA_ZI
--[D2]                               Integer, 
--[D3]                               Integer, 
--[D4]                               Integer, 
--[D5]                               Integer, 
--[D6]                               Integer, 
--[D7]                               Integer, 
--[D8]                               Integer, 
--[D9]                               Integer, 
--[D10]                              Integer, 
--[D11]                              Integer, 
--[D12]                              Integer, 
--[ZI_LC1]                           Integer, --ziele lunii din anul curent si anterior sunt din PARAM
--[ZI_LC2]                           Integer, 
--[ZI_LC3]                           Integer, 
--[ZI_LC4]                           Integer, 
--[ZI_LC5]                           Integer, 
--[ZI_LC6]                           Integer, 
--[ZI_LC7]                           Integer, 
--[ZI_LC8]                           Integer, 
--[ZI_LC9]                           Integer, 
--[ZI_LC10]                          Integer, 
--[ZI_LC11]                          Integer, 
--[ZI_LC12]                          Integer, 
--[ZI_LC_EF1]                        Integer, --zile efectiv lucrate ,sunt in FLRC,  se folorsc
--[ZI_LC_EF2]                        Integer, 
--[ZI_LC_EF3]                        Integer, 
--[ZI_LC_EF4]                        Integer, 
--[ZI_LC_EF5]                        Integer, 
--[ZI_LC_EF6]                        Integer, 
--[ZI_LC_EF7]                        Integer, 
--[ZI_LC_EF8]                        Integer, 
--[ZI_LC_EF9]                        Integer, 
--[ZI_LC_EF10]                       Integer, 
--[ZI_LC_EF11]                       Integer, 
--[ZI_LC_EF12]                       Integer, 
--[DII]                              DateTime, 
--STartDateOfTheIncrease smalldatetime, -- ziua exact cand incepe indexarea, --nu se mai foloseste
--[SEMN1]                            Char(1), --daca ja avut sau nu scutire, vedem la algoritm,
--[SEMN2]                            Char(1), 
--[SEMN3]                            Char(1), 
--[SEMN4]                            Char(1), 
--[SEMN5]                            Char(1), 
--[SEMN6]                            Char(1), 
--[SEMN7]                            Char(1), 
--[SEMN8]                            Char(1), 
--[SEMN9]                            Char(1), 
--[SEMN10]                           Char(1), 
--[SEMN11]                           Char(1), 
--[SEMN12]                           Char(1), 
--[PLAFON]                           Numeric(10,2), ?
--[DPREMA]                           Integer, ?
--[DPN]                              DateTime, ?
--[DIF_BU]                           Numeric(10,2), ?
--[DIF_BB]                           Numeric(10,2), ?
--[L13]                              Numeric(10,4), --poate suma celor 12 anterioare
--[D13]                              Integer, 
--[ZI_LC13]                          Integer, 
--[ZI_LC_EF13]                       Integer, 
--[SEMN13]                           Char(1), --poate nu se mai folosesc
--[CNP]                              Numeric(13,0), --e deja in EMployee