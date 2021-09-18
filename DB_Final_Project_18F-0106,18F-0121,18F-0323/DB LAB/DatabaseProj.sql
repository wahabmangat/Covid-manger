
create table paramadics
(
parID int Primary Key,
ParName varchar(25),
jobStatus varchar(25),
w_ID int
);
alter table paramadics
add constraint wardFK foreign key (W_ID) references ward(w_ID) on delete set NULL on update cascade;

create table operator 
(
opID int Primary key,
opName varchar(25),
opContact integer,
opCenter int  --FOREIGN KEY
);
alter table operator
add constraint centFK foreign key (opCenter) references callcenter(centID) on delete set NULL on update cascade;

create table callCenter
(
centID int Primary Key,
emergNum integer,
centLoc varchar(25)
);

create table AreaExposed
(
location varchar(50),
city varchar(50),
region varchar(50)
);

create table peopleExposed
(
 name varchar(50),
 contactNo integer
);

create  table patientAdmit
(
p_ID int,
w_ID int,
dateAdmit date default NULL,
dateDischarge date default NULL
);

create table P_symptoms
(
P_ID int not null, 
S_ID int not null
);


create table symptoms 
(
 S_ID int primary key,
 s_name varchar(20)
);


create table ward
(
W_ID int primary key,
Beds int ,
noOfPatients int,
Loc varchar(40),
wardSec varchar(20),--private/public
W_Name varchar(20),
W_type varchar(20) 
);


create table Patient
(
Patient_ID int Primary key,
P_Name varchar(20),
P_DOB date, 
CNIC varchar(16),
Phone integer,
P_Address varchar(50),
Condition varchar (20), 
Age int 
);



insert into peopleExposed values('Ali',0322784596);
insert into peopleExposed values('Hamza',0322788426);
insert into peopleExposed values('Qayum',0322787159);
insert into peopleExposed values('Abid',0321739516);
insert into peopleExposed values('Salman',0322123695);


insert into AreaExposed values('Wapda Town','Lahore','Punjab');
insert into AreaExposed values('Model Town','Lahore','Punjab');
insert into AreaExposed values('Johar Town','Lahore','Punjab');
insert into AreaExposed values('New Town','Hyderabad','Sindh');
insert into AreaExposed values('Lyari','Karachi','Sindh');
insert into AreaExposed values('Hayatabad','Peshawar','KPK');



insert into ward values (11,100,0,'Lahore','Private','Iqbal','Quarantine');
insert into ward values (12,150,0,'Karachi','Public','Jinnah','Isolation');
insert into ward values (13,200,0,'Karachi','Private','Edhi','Quarantine');
insert into ward values (14,100,0,'Faisalabad','Private','Al-Hamra','Isolation');
insert into ward values (15,100,0,'Islamabad','Public','Benazir','Quarantine');
insert into ward values (16,150,0,'Multan','Private','Sufi','Isolation');
insert into ward values (17,100,0,'Gujrat','Public','General','Quarantine');
insert into ward values (18,100,0,'Faisalabad','Public','Allied','Isolation');
insert into ward values (19,100,0,'Hyderabad','Public','Defah','Quarantine');
insert into ward values (20,200,0,'Lahore','Public','Default Isolation','Isolation');
insert into ward values (21,200,0,'Lahore','Public','Default Quarantine','Quarantine');


insert into symptoms values(1,'High Fever');
insert into symptoms values(2,'Dry Cough');
insert into symptoms values(3,'Tiredness');
insert into symptoms values(4,'Sore Throat');
insert into symptoms values(5,'Diarrhoea');
insert into symptoms values(6,'Headache');


insert into callCenter values(1,0345984126,'Faisalabad');
insert into callCenter values(2,0321961578,'Lahore');
insert into callCenter values(3,0312324895,'Karachi');
insert into callCenter values(4,0333741265,'Multan');
insert into callCenter values(5,0320974563,'Islamabad');
insert into callCenter values(6,0315741936,'Hyderabad');
insert into callCenter values(7,0324963174,'Quetta');

insert into operator values(100,'Hamza',0314963254,1)
insert into operator values(101,'Ali',0315962879,2)
insert into operator values(102,'Hamdan',0321852574,3)
insert into operator values(103,'Burhan',0322963625,4)
insert into operator values(104,'Aleem',0323741425,5)
insert into operator values(105,'Saleem',0332126578,6)
insert into operator values(106,'Qayyum',0334984565,7)

insert into paramadics values (200,'Bilal','Doctor',11)
insert into paramadics values (201,'Haider','Doctor',12)
insert into paramadics values (202,'Hamza','Doctor',13)
insert into paramadics values (203,'Iqra','Nurse',14)
insert into paramadics values (204,'Sadia','Nurse',15)
insert into paramadics values (205,'Ayesha','Nurse',19)


select * from ward