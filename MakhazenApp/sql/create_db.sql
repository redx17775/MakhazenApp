-- create_db.sql
-- Creates 'DB' database and basic schema used by the app. Run locally using SSMS or sqlcmd.

IF DB_ID('DB') IS NULL
BEGIN
    CREATE DATABASE [DB];
END
GO

USE [DB];
GO

-- Category table used by app
IF OBJECT_ID('Category') IS NULL
BEGIN
    CREATE TABLE Category (
        CategoryID INT IDENTITY(1,1) PRIMARY KEY,
        CategoryName NVARCHAR(100) NOT NULL
    );
END
GO
-- Product table used by app (singular)
IF OBJECT_ID('Product') IS NULL
BEGIN
    CREATE TABLE Product (
        ProductID INT IDENTITY(1,1) PRIMARY KEY,
        ProductName NVARCHAR(200) NOT NULL,
        ItemCode NVARCHAR(50) NOT NULL,
        CategoryID INT NULL,
        Quantity INT NOT NULL DEFAULT 0,
        Price DECIMAL(18,2) NOT NULL DEFAULT 0,
        ImageURL NVARCHAR(500) NULL,
        Status NVARCHAR(50) NOT NULL DEFAULT 'InStock'
    );
    ALTER TABLE Product ADD CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID);
END

-- Users table
IF OBJECT_ID('Users') IS NULL
BEGIN
    CREATE TABLE Users (
        UserID INT IDENTITY(1,1) PRIMARY KEY,
        FirstName VARCHAR(50) NOT NULL,
        LastName VARCHAR(50) NOT NULL,
        Username VARCHAR(50) NOT NULL UNIQUE,
        Password VARCHAR(200) NOT NULL,
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END
GO

-- Stores table
IF OBJECT_ID('Store') IS NULL
BEGIN
    CREATE TABLE Store (
        StoreID INT IDENTITY(1,1) PRIMARY KEY,
        StoreName VARCHAR(100) NOT NULL,
        Location VARCHAR(200),
        Status VARCHAR(20) NOT NULL DEFAULT 'Active',
        CreatedAt DATETIME DEFAULT GETDATE()
    );
END
GO

-- Transaction table
IF OBJECT_ID('Transaction') IS NULL
BEGIN
    CREATE TABLE [Transaction] (
        TransactionID INT IDENTITY(1,1) PRIMARY KEY,
        TransactionDate DATETIME DEFAULT GETDATE(),
        TransactionType VARCHAR(20) NOT NULL,
        Quantity INT NOT NULL,
        ProductID INT NOT NULL
    );
END
GO
GO

-- Insert basic sample data
IF NOT EXISTS (SELECT 1 FROM Categories)
    INSERT INTO Categories (Name) VALUES ('Uncategorized');

IF NOT EXISTS (SELECT 1 FROM Products)
    INSERT INTO Products (Name, Code, Category, Stock, Price) VALUES ('Sample', 'SMP001', 'Uncategorized', 10, 9.99);
GO
