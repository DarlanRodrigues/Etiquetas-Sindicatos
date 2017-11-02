create database EtiquetasDB
use EtiquetasDB;

create table ESTADOS(
estadoId int identity(1,1) primary key,
estadoNome varchar(255) not null
)

create table REGIOES(
regiaoId int identity(1,1) primary key,
regiaoNome varchar(255) not null,
estadoId int foreign key references ESTADOS(estadoId)
)

create table CIDADES(
cidadeId int identity(1,1) primary key,
cidadeNome varchar(255) not null,
regiaoId int foreign key references REGIOES(regiaoId)
)


CREATE TABLE SINDICATOS(
sindicatoId int identity(1,1) primary key,
sindicatoNome varchar(255) not null,
sindicatoRua varchar(255) not null,
sindicatoCep int not null,
sindicatoNumero varchar(255),
sindicatoBairro varchar(255),
cidadeId int foreign key references CIDADES(cidadeId)
)
