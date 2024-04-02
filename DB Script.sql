--CREATE DATABASE jcDeskInventoryDB

CREATE TABLE Users (
	UserId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	UserFullName VARCHAR(60) NOT NULL, 
	UserName VARCHAR(20) NOT NULL,
	UserPassword VARCHAR(20) NOT NULL
);

CREATE TABLE ProductCategories (
	CategoryId INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50)
	);

CREATE TABLE Events (
	EventId INT PRIMARY KEY IDENTITY NOT NULL,
	UserId INT FOREIGN KEY 
		REFERENCES Users(UserId) NOT NULL,
	EventType VARCHAR(20) NOT NULL,
	EventDescription VARCHAR(500) NOT NULL,
	EventDateTime DATETIME NOT NULL
	);

CREATE TABLE Products (
	ProductId INT PRIMARY KEY IDENTITY(1001,1) NOT NULL,
	CategoryId INT FOREIGN KEY 
		REFERENCES ProductCategories(CategoryId) NOT NULL,
	ProductCode INT UNIQUE,
	ProductName VARCHAR(50) NOT NULL,
	ProductDescription VARCHAR(100) NULL,
	ProductCurrentQuantity INT DEFAULT 0
	);

GO

-- INITIAL DATA

INSERT INTO ProductCategories (CategoryName) VALUES ('Toner Cartridges');
INSERT INTO ProductCategories (CategoryName) VALUES ('Ink Cartridges');
INSERT INTO ProductCategories (CategoryName) VALUES ('Cables');
INSERT INTO ProductCategories (CategoryName) VALUES ('Batteries');
GO


--STORED PROCEDURES

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'GetAllProductCategories' AND type = 'P')
	DROP GetAllProductCategories
GO

CREATE PROC GetAllProductCategories AS
BEGIN
	SELECT * FROM ProductCategories
END
GO


IF EXISTS (SELECT name FROM sysobjects WHERE name = 'AddProduct' AND type = 'P')
	DROP AddProduct
GO
CREATE PROC AddProduct 
@CategoryId INT, 
@ProductCode INT, 
@ProductName VARCHAR(50), 
@ProductDescription VARCHAR(100), 
@ProductCurrentQuantity INT
AS
BEGIN
	INSERT INTO Products (CategoryId, ProductCode, ProductName, ProductDescription, ProductCurrentQuantity)
		VALUES (@CategoryId, @ProductCode, @ProductName, @ProductDescription, @ProductCurrentQuantity)
END
GO