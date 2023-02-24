DROP DATABASE IF EXISTS Capstone;
CREATE DATABASE Capstone;
GO

CREATE TABLE Capstone.dbo.Customers (
    CustomerID int NOT NULL PRIMARY KEY,
	CustomerCompanyName	nvarchar(50),
	CustomerFirstName	nvarchar(25),
	CustomerLastName	nvarchar(25),
	CustomerAddress	nvarchar(40),
	CustomerCity	nvarchar(40),
	CustomerState	nvarchar(2),
	CustomerZip	nvarchar(10),
	CustomerCountry	nvarchar(40),
	CustomerRegion	nvarchar(40),
	CustomerPhone	nvarchar(20),
	CustomerEmail	nvarchar(20)
);

INSERT INTO Capstone.dbo.Customers VALUES(1, 'Cactus Comidas para llevar', 'Patricio', 'Simpson', 'Cerrito 333', 'Buenos Aires', 'IN', '67000', 'USA', 'West', '(604) 555-4729', 'llevar@yahoo.com');
INSERT INTO Capstone.dbo.Customers VALUES(2, 'Centro comercial Moctezuma', 'Francisco', 'Chang', 'Sierras de Granada 9993', 'Haldo', 'OR', '28023', 'USA', 'West', '(171) 555-1212', 'moctezuma@gmail.com');
INSERT INTO Capstone.dbo.Customers VALUES(3, 'Chop-suey Chinese', 'Yang', 'Wang', 'Hauptstr. 29', 'Bern', 'MA', '13008', 'USA', 'West', '(123) 135-5555', 'yang2222@yahoo.com');
INSERT INTO Capstone.dbo.Customers VALUES(4, 'ComOrcio Mineiro', 'Pedro', 'Afonso', 'Av. dos Lusa�adas', 'Sao Paulo', 'ME', '69842', 'USA', 'West', '(543) 555-3392', 'afonso4444@gmail.com');

CREATE TABLE Capstone.dbo.Orders (
	OrderID	int NOT NULL PRIMARY KEY,
	CustomerID	int NOT NULL,
	EmployeeID	int,
	OrderDate	datetime,
	ProductID	int,
	Quantity	int,
	ShipperID	int,
	ShippedDate	datetime,
	DeliveredDate	datetime,
	OrderComplete INT NOT NULL DEFAULT 0
);

INSERT INTO Capstone.dbo.Orders VALUES(11, 1, 5556, '20230102', 501, 5, 21, '', '',0);
INSERT INTO Capstone.dbo.Orders VALUES(12, 2, 5557, '20221005', 502, 21, NULL, '', '',0);
INSERT INTO Capstone.dbo.Orders VALUES(13, 2, 5558, '20220815', 505, 15, 23, '20220817', '20220825',1);
INSERT INTO Capstone.dbo.Orders VALUES(14, 4, 5559, '20220620', 507, 18, 23, '20220623', '20220701',1);

CREATE TABLE Capstone.dbo.Employees (
	EmployeeID	int	NOT NULL PRIMARY KEY,
	LastName	nvarchar(25),
	FirstName	nvarchar(25),	
	Role	nvarchar(40),
	Phone	nvarchar(20)
);

INSERT INTO Capstone.dbo.Employees VALUES(5556, 'Crate', 'Tom', 'Customer Fulfillment', '(231) 875-9622');
INSERT INTO Capstone.dbo.Employees VALUES(5557, 'Smith', 'Mike', 'Sales', '(463) 487-3154');
INSERT INTO Capstone.dbo.Employees VALUES(5558, 'Hogan', 'Richard', 'Customer Fulfillment', '(731) 864-4371');
INSERT INTO Capstone.dbo.Employees VALUES(5559, 'Blakes', 'Harry', 'Sales', '(468) 976-2467');

CREATE TABLE Capstone.dbo.Shippers (
	ShipperID	int	NOT NULL PRIMARY KEY,	
	ShipperCompanyName	nvarchar(40),
	ShipperPhone	nvarchar(20)
);

INSERT INTO Capstone.dbo.Shippers VALUES(21, 'UPS', '(317) 457-3233');
INSERT INTO Capstone.dbo.Shippers VALUES(22, 'DHL', '(416) 853-6833');
INSERT INTO Capstone.dbo.Shippers VALUES(23, 'FedEx', '(945) 892-9476');

CREATE TABLE Capstone.dbo.Products (
	ProductID	int	NOT NULL PRIMARY KEY,
	ProductName	nvarchar(40),
	SupplierID	int,
	CategoryID	int,
	UnitPrice	money,
	UnitsInStock	int,
	MaxDesiredStock int,
	ReorderThreshold int
);

INSERT INTO Capstone.dbo.Products VALUES(501, 'Razor', 844, 222, 34.45, 256, 500, 100);
INSERT INTO Capstone.dbo.Products VALUES(502, 'Hairbrush', 845, 222, 12.62, 654, 1000, 200);
INSERT INTO Capstone.dbo.Products VALUES(505, 'Screen Door', 854, 254, 1.66, 254, 500, 100);
INSERT INTO Capstone.dbo.Products VALUES(507, 'Pumpkin', 875, 217, 21.32, 123, 500, 100);
INSERT INTO Capstone.dbo.Products VALUES(508, 'Cookie', 812, 217, 33.78, 237, 500, 100);

CREATE TABLE Capstone.dbo.Suppliers (
	SupplierID	int	NOT NULL PRIMARY KEY,
	SupplierCompanyName	nvarchar(50),
);

INSERT INTO Capstone.dbo.Suppliers VALUES(844, 'Exotic Liquids');
INSERT INTO Capstone.dbo.Suppliers VALUES(845, 'New Orleans Cajun Delights');
INSERT INTO Capstone.dbo.Suppliers VALUES(854, 'Grandma Kellys Homestead');
INSERT INTO Capstone.dbo.Suppliers VALUES(875, 'Tokyo Traders');
INSERT INTO Capstone.dbo.Suppliers VALUES(812, 'Cooperativa de Quesos');

ALTER TABLE Capstone.dbo.Orders
	ADD CONSTRAINT FK_ORDERS_CUSTOMERS
	FOREIGN KEY (CustomerID)
	REFERENCES Capstone.dbo.Customers (CustomerID);

ALTER TABLE Capstone.dbo.Orders
	ADD CONSTRAINT FK_ORDERS_SHIPPERS
	FOREIGN KEY (ShipperID)
	REFERENCES Capstone.dbo.Shippers (ShipperID);

ALTER TABLE Capstone.dbo.Orders
	ADD CONSTRAINT FK_ORDERS_EMPLOYEES
	FOREIGN KEY (EmployeeID)
	REFERENCES Capstone.dbo.Employees (EmployeeID);
	
ALTER TABLE Capstone.dbo.Orders
	ADD CONSTRAINT FK_ORDERS_PRODUCTS
	FOREIGN KEY (ProductID)
	REFERENCES Capstone.dbo.Products (ProductID);

ALTER TABLE Capstone.dbo.Products
	ADD CONSTRAINT FK_PRODUCTS_SUPPLIERS
	FOREIGN KEY (SupplierID)
	REFERENCES Capstone.dbo.Suppliers (SupplierID);
	
CREATE TABLE Capstone.dbo.MainSplashVars (
	SplashIndex		int,
	Employee_ID	int,
	CustomerID	int
);

INSERT INTO Capstone.dbo.MainSplashVars VALUES(1, 5556, 1);