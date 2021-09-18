--sample database for focus logics project
--create database DB_LAB
create table paramadics
(
parID int Primary Key,
ParName varchar(25),
jobStatus varchar(25),
w_ID int
);

create table operator 
(
opID int Primary key,
opName varchar(25),
opContact integer,
opCenter int
);

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
wardSec varchar(20),
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
P_Address varchar(100),
Condition varchar (20),
Age int 
);

alter table operator
add constraint centFK foreign key (opCenter) references callcenter(centID) on delete set NULL on update cascade;

alter table paramadics
add constraint wardFK foreign key (W_ID) references ward(w_ID) on delete set NULL on update cascade;

insert into peopleExposed values('Ali',0322784596);
insert into peopleExposed values('Hamza',0322788426);
insert into peopleExposed values('Qayum',0322787159);
insert into peopleExposed values('Abid',0321739516);
insert into peopleExposed values('Salman',0322123695);
insert into peopleExposed values('Akram Masood',312749658);
insert into peopleExposed values('Yasir Hussain',312938271);


insert into AreaExposed values('Wapda Town','Lahore','Punjab');
insert into AreaExposed values('Model Town','Lahore','Punjab');
insert into AreaExposed values('Johar Town','Lahore','Punjab');
insert into AreaExposed values('New Town','Hyderabad','Sindh');
insert into AreaExposed values('Lyari','Karachi','Sindh');
insert into AreaExposed values('Hayatabad','Peshawar','KPK');
insert into AreaExposed values('Madina Town','Faisalabad','Punjab');
insert into AreaExposed values('Revenue Society','Faisalabad','Punjab');
insert into AreaExposed values('Asharafabad','Faisalabad','Punjab');
insert into AreaExposed values('Model Colony','Karachi','Sindh');


insert into ward values (11,100,0,'Lahore','Private','Iqbal','Quarantine');
insert into ward values (13,199,1,'Karachi','Private','Edhi','Quarantine');
insert into ward values (14,99,1,'Faisalabad','Private','Al-Hamra','Isolation');
insert into ward values (15,99,1,'Islamabad','Public','Benazir','Quarantine');
insert into ward values (16,200,0,'Multan','Private','Sufi','Isolation');
insert into ward values (17,100,0,'Gujrat','Public','General','Quarantine');
insert into ward values (18,98,2,'Faisalabad','Public','Allied','Isolation');
insert into ward values (19,100,0,'Hyderabad','Public','Defah','Quarantine');
insert into ward values (20,199,1,'Lahore','Public','Default Isolation','Isolation');
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
insert into operator values(107,'Ilyas',314952641,7)

insert into paramadics values (200,'Bilal','Doctor',11)
insert into paramadics values (201,'Haider','Doctor',11)
insert into paramadics values (202,'Hamza','Doctor',13)
insert into paramadics values (203,'Iqra','Nurse',14)
insert into paramadics values (204,'Sadia','Nurse',15)
insert into paramadics values (205,'Ayesha','Nurse',19)
insert into paramadics values (206,'Saleem','Doctor',11)

insert into Patient values(1001,'Abiha Mumtaz','1995-05-14','33100-8536147-9',333962547,'People Colony, Faisalabad, Pakistan','Mild',21);
insert into Patient values (1002,'Nasir Akram','1994-06-28','33102-8536183-6',312584136,'People Colony, Faisalabad, Pakistan','Normal',26);
insert into Patient values (1003,'Alishba Nadeem','1995-07-28','33100-9674126-9',321453298,'D type, Faisalabad, Pakistan','Normal',25);
insert into Patient values (1004,'Nida Yasir','1980-01-20','33100-8516473-3',321962178,'Model Colony, Karachi, Pakistan','Mild',40);
insert into Patient values (1005,'Abrar ul Haq','1980-09-20','33100-8514753-9',315913498,'D type, Faisalabad, Pakistan, Pakistan','Mild',40);


insert into patientAdmit values(1000,12,'2020-06-16','2020-06-16');
insert into patientAdmit values(1001,12,'2020-06-16',NULL);
insert into patientAdmit values(1002,12,'2020-06-16','2020-06-16');
insert into patientAdmit values(1003,12,'2020-06-16',NULL);
insert into patientAdmit values(1005,12,'2020-06-16',NULL);
insert into patientAdmit values(1002,12,'2020-06-16',NULL);
insert into patientAdmit values(1000,12,'2020-06-16',NULL);
insert into patientAdmit values(1004,12,'2020-06-16',NULL);

insert into P_Symptoms values(1000,1);
insert into P_Symptoms values(1000,2);
insert into P_Symptoms values(1000,5);
insert into P_Symptoms values(1000,6);
insert into P_Symptoms values(1001,3);
insert into P_Symptoms values(1001,4);
insert into P_Symptoms values(1002,3);
insert into P_Symptoms values(1003,2);
insert into P_Symptoms values(1003,5);
insert into P_Symptoms values(1005,2);
insert into P_Symptoms values(1005,3);
insert into P_Symptoms values(1002,6);
insert into P_Symptoms values(1004,3);
insert into P_Symptoms values(1004,6);

select * from Patient
select * from patientAdmit
select * from P_Symptoms
select * from symptoms
select * from ward;
select * from AreaExposed
select * from peopleExposed
select * from operator
select * from paramadics