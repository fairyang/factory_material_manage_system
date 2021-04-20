create database wareHouse
go
use wareHouse
go
go
create table waresinfo
(
  wares_id int not null identity(1,1) primary key,
  wares_name varchar(30) not null default'Ĭ��',
  wares_type varchar(30) not null default'Ĭ��',
  wares_tity int not null default'0',
  wares_ption varchar(10)not null default'Ĭ��',
 )
 select wares_id, wares_name, wares_type, wares_tity, wares_ption from waresinfo where wares_ption like '��';
 go
 select * from waresinfo
insert into waresinfo values('��','��',0,'{0}')
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('���ϴ�','����',3000,'��');
insert into waresinfo values('����','ľ��Ʒ',1000,'��');
insert into waresinfo values('����','ľ��Ʒ',1000,'��');
insert into waresinfo values('ʯ��','ȼ��',1000,'��');
insert into waresinfo values('����','����',2000,'��');
insert into waresinfo values('����','����',1000,'��');
insert into waresinfo values('����','����',1000,'��');
insert into waresinfo values('������','ʳ��',2000,'��');

go
 select * from waresinfo
 
 create table usersinfo(
  users_id int not null identity(01,1) primary key,
  usersinfo_zh varchar(30) not null,
  usersinfo_pwd varchar(18) not null default '123456',
  usersinfo_qx varchar(10) not null default 'Ա��',
  usersinfo_sex varchar(2) not null,
  usersinfo_name varchar(30) not null,
  usersinfo_add varchar(100) not null,
  usersinfo_tell varchar(11) not null check (len(usersinfo_tell)=11),
  usresinfo_date varchar(100) not null
  
)

insert into usersinfo values('admin','123','����Ա','��','�','����','14725836900','2018-06-10 21:04');
insert into usersinfo values('admin1','123',default,'��','����','����','10236547891','2018-06-10 21:04');
insert into usersinfo values('admin2','123',default,'��','������','����','12014587963','2018-06-10 21:04');
insert into usersinfo values('admin3','123',default,'��','����','����','19251840851','2018-06-10 21:04');

select * from usersinfo

go
create table inStorage
(
  inStorage_id int not null identity(000001,1) primary key,
  inStorage_date datetime not null,
  inStorage_company varchar(30) not null,
  inStorage_info varchar(30) not null
)
select * from inStorage

create table shiPment
(
  shiPment_id int foreign key references inStorage(inStorage_id),
  shiPment_date datetime not null,
  shiPment_info varchar(30) not null,
)
select * from shiPment
create table cangKu
(
  cangKu_id int not null identity(1,1) primary key,
  cangKu_type varchar(10) not null, 
  cangKu_num int not null
) 

insert into cangKu values('��','50000');
insert into cangKu values('��','50000');
insert into cangKu values('��','50000');
insert into cangKu values('��','50000');
select * from cangKu
delete from cangKu where cangKu_id =6
create table info(
  info_id int not null identity(1,1) primary key,
  info_name varchar(10) not null default '����',
  info_tell varchar(11) not null default '��',
  info_bz varchar(500) not null
)
select * from info