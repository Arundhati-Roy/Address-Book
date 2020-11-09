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
--addr varchar(250) NOT NULL,
--city varchar(250) NOT NULL,
--state varchar(250) NOT NULL,
phNo varchar(250) NOT NULL,
constraint FK_Contacts_ABname foreign key(ABname)
references AddressBookDictionary(name)
);

create table AddressBookDictionary(
name varchar(30) not null Primary key, 
type varchar(30) not null
);

select * from contacts
select * from AddressBookDictionary

Alter table contacts
add addr varchar(250) default('Home'),
city varchar(250) default('Home'),
state varchar(250) default('Home'),
email varchar(30) default('NA')
with values;

insert into AddressBookDictionary
values
('a','Friends'),
('b','Family'),
('c','Colleagues'),
('d','Family')

insert into Contacts
values('a','Aru','Roy','Pimpri','Pune','Mah',776578976,'dxfc@tfg.dh'),
('b','Neha','Roy','Worli','Mumbai','Mah',9857836878,'dchbhn@hjn.bhj'),
('a','Shreya','Roy','Colaba','Mumbai','Mah',8765778676,'ugb@hgb.guvhjb')
,('c','Bec','John','Kormangla','Bangalore','Karnataka',9897867565,'usz@bh.hbjk')

insert into Contacts(ABname,lName,fName,addr,city,state,phNo)
values('a','Priya','Roy','Pimpri','Pune','Mah',776578976)

select * from Contacts c,AddressBookDictionary a
where c.ABname=a.name

update AddressBookDictionary 
set type='Family' where name='a'
update AddressBookDictionary 
set type='Friends' where name='b'

delete from AddressBookDictionary
where name='c'

--***********************************
drop procedure spAddContact
create procedure spAddContact
@fname VARCHAR(20),
@lName varchar(20),
@phNo varchar(20),
@type varchar(20)

as
begin
set xact_abort on;
begin try
	begin transaction
	declare @ABName varchar(30)
	set @ABName=(select top(1)name from AddressBookDictionary where type=@type)
	insert into Contacts(ABname,fName,lName,phNo) values(@ABName,@fname,@lName,@phNo)
	select * from Contacts c,AddressBookDictionary a
	where c.ABname=a.name
	commit transaction
end try
begin catch
select ERROR_NUMBER() as errorNum, 
ERROR_MESSAGE() as ErrorMess;
if(XACT_STATE()=-1)
	begin
		print N'The transaction is in an uncommittable state.' + 'Rolling back transaction.'
		Rollback transaction ;
	end;
if(XACT_STATE()=1)
	begin
		print N'The transaction is committable state.' + 'Commiting transaction.'
		Commit transaction ;
	end;
end catch
end
go;

select name from AddressBookDictionary where type='Family'
select * from AddressBookDictionary
exec spAddContact @fname='Shreya',@lname='Roy',@phNo=786986397,@type='Family'