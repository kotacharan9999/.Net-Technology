CREATE DATABASE InventoryDB;
GO

USE InventoryDB;
GO

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

INSERT INTO Products (ProductName, Quantity, Price)
VALUES
('Keyboard', 20, 750),
('Mouse', 35, 450),
('Monitor', 10, 8500);
GO