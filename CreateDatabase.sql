CREATE DATABASE RealEstatePropertiesDB;

USE RealEstatePropertiesDB;

CREATE TABLE [Owner] (
	IdOwner INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50),
	[Address] VARCHAR(50),
	Photo VARCHAR(100),
	Birthday DATE
);

CREATE TABLE Property (
	IdProperty INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50),
	[Address] VARCHAR(50),
	Price DECIMAL(19,4),
	CodeInternal VARCHAR(100),
	[Year] INT,
	IdOwner INT,
	CONSTRAINT fk_Owner FOREIGN KEY (IdOwner) REFERENCES [Owner] (IdOwner),
);

CREATE TABLE PropertyImage (
	IdPropertyImage INT PRIMARY KEY IDENTITY(1,1),
	[File] VARCHAR(100),
	[Enable] BIT,
	IdProperty INT,
	CONSTRAINT fk_Property_PropertyImage FOREIGN KEY (IdProperty) REFERENCES Property (IdProperty),
);

CREATE TABLE PropertyTrace (
	IdPropertyTrace INT PRIMARY KEY IDENTITY(1,1),
	DataSale DATE,
	[Name] VARCHAR(100),
	[Value] DECIMAL(19,4),
	[Tax] DECIMAL(19,4),
	IdProperty INT,
	CONSTRAINT fk_Property_PropertyTrace FOREIGN KEY (IdProperty) REFERENCES Property (IdProperty),
);