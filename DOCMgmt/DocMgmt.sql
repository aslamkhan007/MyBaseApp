Create table JCT_DMS_Master_Category 
(CompanyCode Varchar(10),EmpCode Varchar(8), TransNo BigInt Identity,
ParentCatg Varchar(40), Catg Char(2),ShortDesc Varchar(50), 
LongDesc Varchar(200), EffFrom Datetime, EffTo Datetime,Host_Ip Varchar(15), Status Char(1), Entry_Time Datetime)
  
select * from JCT_DMS_Master_Category
CompanyCode,EmpCode, Catg ,ShortDesc , LongDesc ,EffFrom, EffTo,Host_Ip, Status , Entry_Time,ParentCatg

COMPANY_CODE,EMP_CODE,DEPT_CODE,SHORTDESC,LONGDESC,EFF_FROM,EFF_TO,HOST_IP,STATUS,ENTRY_TIME,PARENTDEPT

drop table JCT_DMS_Trans_Upload
create table JCT_DMS_Trans_Upload
(CompanyCode Varchar(10),EmpCode Varchar(8), EnteredDt Datetime,TransNo bigint Identity, FileRefNo Varchar(50),
FileType Varchar(50), FileRefDate Datetime, FilePath Varchar(70), Department Varchar(30), Privacy varchar(20),
KeyInfo Varchar(500), PagesCnt int, AmtInv Numeric(11,2),AuthFlag Char(1), AuthBy Varchar(10), AuthDate Datetime,
AuthCode Varchar(),Status Char(1), DeletionDt Datetime,DeletedBy Varchar(8)) 

drop table JCT_DMS_Trans_Upload_Files
create table JCT_DMS_Trans_Upload_Files
(CompanyCode Varchar(10),EmpCode Varchar(8), TransNo BigInt, FileNo int,
FileName Varchar(30), Privacy varchar(20), Description Varchar(100), HODAuth Char(1), ITAuth Char(1),
Status Char(1),DeletionDt Datetime,DeletedBy Varchar(8)) 

select * from jct_epor_master_dept where status='a' order by longdesc
select right(filetype,len(filetype)-charindex('-->',filetype)-2) from JCT_DMS_Trans_Upload a inner join 
JCT_DMS_Trans_Upload_Files b on a.transno=b.transno and a.status='' and b.status='' 
inner join jct_empmast_base c on a.empcode=c.empcode and c.active='Y' 
where 
select * from JCT_DMS_Trans_Upload


select * from JCT_DMS_Trans_Upload_files


select * from jct_empmast_base where empname  like 'jasneet%'


select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files 
where status='' and (hodauth='' or hodauth='a') and (itauth='' or itauth='a') and transno=

select fileno, filename,description, '~/upd/' + filename as url from JCT_DMS_Trans_Upload_files where status='' 
and (hodauth='' or hodauth='a' or hodauth='r') and (itauth='' or itauth='a' or itauth='r') and transno=1


alter table JCT_DMS_Trans_Upload add 


truncate table JCT_DMS_Trans_Upload_files

delete from JCT_DMS_Trans_Upload_files where transno=0

Insert into JCT_DMS_Trans_Upload values ('','N-02632',getdate(),'hhjh',
right('Kaizen Mkt Images-->IMKRMK',len('Kaizen Mkt Images-->IMKRMK')-charindex('-->','Kaizen Mkt Images-->IMKRMK')-2),
'10/21/2009','','INFORMATION TECHNOLOGY','','ghghghghg',0,0,'',null,null)




select * from JCT_DMS_Master_Category

select filetype as catg,count(*) as cnt from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b--, JCT_DMS_Trans_Upload_Files c
where a.parentcatg+a.catg =b.filetype-- and b.transno=c.transno

select filetype as catg,count(*) as cnt from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b where a.parentcatg+a.catg =b.filetype
select filetype as catg,count(*) as cnt from JCT_DMS_Master_Category a,JCT_DMS_Trans_Upload b where a.parentcatg+a.catg =b.filetype group by filetype
select deptname from deptmast where company_code='jct00ltd' order by deptname


delete from JCT_DMS_Trans_Upload
delete from JCT_DMS_Trans_Upload_files

Insert into JCT_DMS_Trans_Upload values ('','',getdate(),'','','','','','','',,'','',null,null)

Insert into JCT_DMS_Trans_Upload values ('','',getdate(),'','','','','','','',,,'',null,null)

select * from jct_empmast_base where empname like '%rajesh%'

R-03481

select * from jct_empmast_base where empname like '%ranje%'

select * from production..role_user_mapping where uname='R-03481'

select * from production..user_module_menus_mapping where uname ='R-03481'


insert into production..user_module_menus_mapping
select 'R-03335',module,mnuname,action
 from production..user_module_menus_mapping where uname ='R-03481'

SELECT * FROM  JCT_DMS_Master_Type_Parameters

CREATE TABLE JCT_DMS_Master_Type_Parameters
(CompanyCode VARCHAR(10), UserCode VARCHAR(10), HostIP VARCHAR(15),TransNo INT IDENTITY, FileType VARCHAR(50),
Parameter Varchar(20), Description VARCHAR(70), ParamType  VARCHAR(30),
Mandatory CHAR(1), ProcName VARCHAR(60), Status CHAR(1), CreatedDt DATETIME, DeletionDt DATETIME,
DeletedBy VARCHAR(10))

INSERT INTO JCT_DMS_Master_Type_Parameters (
	CompanyCode,
	UserCode,
	HostIP,
	FileType,
	Parameter,
	Description,
	ParamType,
	Mandatory,
	ProcName,
	Status,
	CreatedDt,
	DeletionDt,
	DeletedBy
) VALUES ( 
	/* CompanyCode - VARCHAR(10) */ 'JCT00LTD',
	/* UserCode - VARCHAR(10) */ 'N-02632',
	/* HostIP - VARCHAR(15) */ '',
	/* FileType - VARCHAR(50) */ 'DCRE',
	/* Parameter - Varchar(20) */ 'Last Qualification',
	/* Description - VARCHAR(70) */ 'Last Qualification',
	/* ParamType - VARCHAR(30) */ 'DropDownList',
	/* Mandatory - CHAR(1) */ 'Y',
	/* ProcName - VARCHAR(60) */ ' ',
	/* Status - CHAR(1) */ '',
	/* CreatedDt - DATETIME */ '2009-10-23',NULL,
	/* DeletionDt - DATETIME  '2009-10-23 10:25:21.69',*/
	/* DeletedBy - VARCHAR(10) */ null ) 


SELECT RIGHT(LTRIM(RTRIM(b.page_name)),LEN(b.page_name)-2),C.action FROM 
production..modules_menu_master a,jctdev..JCT_Menu_Form_Mapping b,production..user_module_menus_mapping c 
WHERE a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND C.mnuname=A.mnuname  
AND a.action=c.action AND a.module=c.module AND a.module='docmgmt'AND c.uname='N-02632' AND 
RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='CatgMaster.aspx'   union    
select RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2),C.action from production..modules_menu_master a,
jctdev..JCT_Menu_Form_Mapping b,production..role_module_menus_mapping c,production..role_user_mapping d 
where a.action<>'load' AND b.module=a.module AND a.mnuname=b.mnuname AND a.action=c.action AND c.role=d.role 
AND C.mnuname=A.mnuname AND a.module=c.module AND a.module='docmgmt'AND  d.uname='N-02632' 
AND RIGHT(LTRIM(RTRIM(b.page_name)),len(b.page_name)-2)='CatgMaster.aspx'

SELECT * FROM production..role_module_menus_mapping WHERE module='docmgmt'
sp_objects jct_dms,v

alter View JCT_DMS_Location 
as
SELECT TOP 100 percent  Code, State + ' - ' + City AS Location  FROM JCTGEN..JCT_EPOR_STATE_MASTER ORDER BY State + ' - ' + City

CREATE VIEW JCT_DMS_Qualification
as
SELECT TOP 100 PERCENT Course_code,Short_Name FROM dbo.JCT_EPor_Course_Master WHERE status='a'
ORDER BY short_name

update  JCT_DMS_Master_Type_Parameters SET procname='JCT_DMS_Area_Div'
WHERE transno=4

SELECT * FROM JCT_DMS_Master_Category
SELECT * FROM JCT_DMS_Master_Type_Parameters
SELECT * FROM JCT_DMS_Trans_Upload
SELECT * FROM JCT_DMS_Trans_Upload_Files

SELECT * FROM JCT_DMS_Trans_Upload_Param

create TABLE JCT_DMS_Trans_Upload_Param (CompanyCode VARCHAR(10), EmpCode VARCHAR(10), TransNo INT,
ParamName VARCHAR(30), Value VARCHAR(50), DescriptionText VARCHAR(200),Status CHAR(1))

sp_objects jct_dms,u
