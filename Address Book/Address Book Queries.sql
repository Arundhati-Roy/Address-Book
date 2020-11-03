/*UC1*/
create database AddressBookDB

/*UC2*/
create table AddressBook(
id int NOT NULL identity(1,1) PRIMARY KEY,
fName varchar(30) NOT NULL,
lName varchar(30) NOT NULL,
addr varchar(250) NOT NULL,
city varchar(250) NOT NULL,
state varchar(250) NOT NULL,
phNo varchar(250) NOT NULL,
email varchar(250) NOT NULL,
);
select * from AddressBook

/*UC3*/
insert into AddressBook(fName,lName,addr,city,state,phNo,email)
values('Aru','Roy','Pimpri','Pune','Mah',776578976,'dxfc@tfg.dh'),
('Neha','Roy','Worli','Mumbai','Mah',9857836878,'dchbhn@hjn.bhj'),
('Shreya','Roy','Colaba','Mumbai','Mah',8765778676,'ugb@hgb.guvhjb'),
('Bec','John','Kormangla','Bangalore','Karnataka',9897867565,'usz@bh.hbjk')
select * from AddressBook

/*UC4*/
UPDATE AddressBook set lName='ROY'
where fName='Aru'
select * from AddressBook

/*UC5*/
delete from AddressBook
where fName='Aru' and id=1
select * from AddressBook

/*UC6*/
select * from AddressBook
where state='Mah'

/*UC7*/
select count(*) from AddressBook
where state='Mah'

/*UC8*/
select * from AddressBook
where state='Mah'
order by fName

/*UC9*/
alter table AddressBook
add name varchar(30), type varchar(30)
select * from AddressBook

/*UC10*/
select count(*) from AddressBook
where type='Family'

/*UC11*/
insert into AddressBook(fName,lName,addr,city,state,phNo,email,name,type)
values('Arundhati','Roy','Pimpri','Pune','Mah',776578976,'dxfc@tfg.dh','a','Family'),
('Neharika','Roy','Worli','Mumbai','Mah',9857836878,'dchbhn@hjn.bhj','a','Friend'),
('Shreyasi','Roy','Colaba','Mumbai','Mah',8765778676,'ugb@hgb.guvhjb','b','Family'),
('Becty','John','Kormangla','Bangalore','Karnataka',9897867565,'usz@bh.hbjk','b','Friend')
select * from AddressBook

UPDATE AddressBook set type='Family',name='b'
where fName='Aru'
select * from AddressBook

/*UC12*/
drop table Contacts
drop table AddressBookDictionary

create table Contacts(
id int NOT NULL identity(1,1) PRIMARY KEY,
ABname varchar(30) not null, 
fName varchar(30) NOT NULL,
lName varchar(30) NOT NULL,
addr varchar(250) NOT NULL,
city varchar(250) NOT NULL,
state varchar(250) NOT NULL,
phNo varchar(250) NOT NULL,
email varchar(250) NOT NULL,
constraint FK_Contacts_ABname foreign key(ABname)
references AddressBookDictionary(name)
);

create table AddressBookDictionary(
name varchar(30) not null Primary key, 
type varchar(30) not null
);

select * from contacts
select * from AddressBookDictionary

insert into Contacts
values('a','Aru','Roy','Pimpri','Pune','Mah',776578976,'dxfc@tfg.dh'),
('b','Neha','Roy','Worli','Mumbai','Mah',9857836878,'dchbhn@hjn.bhj'),
('a','Shreya','Roy','Colaba','Mumbai','Mah',8765778676,'ugb@hgb.guvhjb'),
('c','Bec','John','Kormangla','Bangalore','Karnataka',9897867565,'usz@bh.hbjk')

insert into AddressBookDictionary
values('a','Friends'),
('b','Family'),
('c','Colleagues')

select * from Contacts c,AddressBookDictionary a
where c.ABname=a.name