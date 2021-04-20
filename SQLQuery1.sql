create database wareHouse
go
use wareHouse
go
go
create table waresinfo
(
  wares_id int not null identity(1,1) primary key,
  wares_name varchar(30) not null default'默认',
  wares_type varchar(30) not null default'默认',
  wares_tity int not null default'0',
  wares_ption varchar(10)not null default'默认',
 )
 select wares_id, wares_name, wares_type, wares_tity, wares_ption from waresinfo where wares_ption like '甲';
 go
 select * from waresinfo
insert into waresinfo values('无','无',0,'{0}')
insert into waresinfo values('塑料袋','塑料',3000,'甲');
insert into waresinfo values('塑料袋','塑料',3000,'甲');
insert into waresinfo values('塑料袋','塑料',3000,'甲');
insert into waresinfo values('塑料袋','塑料',3000,'甲');
insert into waresinfo values('塑料袋','塑料',3000,'甲');
insert into waresinfo values('塑料袋','塑料',3000,'乙');
insert into waresinfo values('塑料袋','塑料',3000,'乙');
insert into waresinfo values('桌子','木制品',1000,'丙');
insert into waresinfo values('凳子','木制品',1000,'丙');
insert into waresinfo values('石油','燃料',1000,'丙');
insert into waresinfo values('篮球','球类',2000,'丁');
insert into waresinfo values('排球','球类',1000,'丁');
insert into waresinfo values('足球','球类',1000,'丁');
insert into waresinfo values('方便面','食物',2000,'甲');

go
 select * from waresinfo
 
 create table usersinfo(
  users_id int not null identity(01,1) primary key,
  usersinfo_zh varchar(30) not null,
  usersinfo_pwd varchar(18) not null default '123456',
  usersinfo_qx varchar(10) not null default '员工',
  usersinfo_sex varchar(2) not null,
  usersinfo_name varchar(30) not null,
  usersinfo_add varchar(100) not null,
  usersinfo_tell varchar(11) not null check (len(usersinfo_tell)=11),
  usresinfo_date varchar(100) not null
  
)

insert into usersinfo values('admin','123','管理员','男','李凡','商洛','14725836900','2018-06-10 21:04');
insert into usersinfo values('admin1','123',default,'男','张三','商洛','10236547891','2018-06-10 21:04');
insert into usersinfo values('admin2','123',default,'男','郭鹏飞','商洛','12014587963','2018-06-10 21:04');
insert into usersinfo values('admin3','123',default,'男','郭恒','商洛','19251840851','2018-06-10 21:04');

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

insert into cangKu values('甲','50000');
insert into cangKu values('乙','50000');
insert into cangKu values('丙','50000');
insert into cangKu values('丁','50000');
select * from cangKu
delete from cangKu where cangKu_id =6
create table info(
  info_id int not null identity(1,1) primary key,
  info_name varchar(10) not null default '匿名',
  info_tell varchar(11) not null default '无',
  info_bz varchar(500) not null
)
select * from info