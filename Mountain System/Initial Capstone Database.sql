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
	CustomerPhone	nvarchar(20)
);

INSERT INTO Capstone.dbo.Customers VALUES(1, 'Cactus Comidas para llevar', 'Patricio', 'Simpson', 'Cerrito 333', 'Buenos Aires', 'IN', '67000', 'USA', 'West', '(604) 555-4729');
INSERT INTO Capstone.dbo.Customers VALUES(2, 'Centro comercial Moctezuma', 'Francisco', 'Chang', 'Sierras de Granada 9993', 'Haldo', 'OR', '28023', 'USA', 'West', '(171) 555-1212');
INSERT INTO Capstone.dbo.Customers VALUES(3, 'Chop-suey Chinese', 'Yang', 'Wang', 'Hauptstr. 29', 'Bern', 'MA', '13008', 'USA', 'West', '(123) 135-5555');
INSERT INTO Capstone.dbo.Customers VALUES(4, 'ComOrcio Mineiro', 'Pedro', 'Afonso', 'Av. dos Lusa≠adas', 'Sao Paulo', 'ME', '69842', 'USA', 'West', '(543) 555-3392');

CREATE TABLE Capstone.dbo.Orders (
	OrderID	int NOT NULL PRIMARY KEY,
	CustomerID	int NOT NULL,
	EmployeeID	int,
	OrderDate	datetime,
	ShipperID	int,
	ShippedDate	datetime,
	DeliveredDate	datetime,
	OrderContactFirstName	nvarchar(25),
	OrderContactLastName	nvarchar(25),
	OrderAddress	nvarchar(40),
	OrderCity	nvarchar(40),
	OrderState	nvarchar(2),
	OrderZip	nvarchar(10),
	OrderCountry	nvarchar(40),
	OrderRegion	nvarchar(40),
	OrderPhone	nvarchar(20)
);

INSERT INTO Capstone.dbo.Orders VALUES(11, 1, 5556, '20230102', 21, '', '', 'Aria', 'Cruz', 'Sierras de Granada 9993', 'Nantes', 'MO', '80805', 'USA', 'West', '(212) 283-2951');
INSERT INTO Capstone.dbo.Orders VALUES(12, 2, 5557, '20221005', NULL, '', '', 'Diego', 'Roel', 'Hauptstr. 29', 'Torino', 'IN', '44000', 'USA', 'West', '(251) 555-0091');
INSERT INTO Capstone.dbo.Orders VALUES(13, 2, 5558, '20220815', 23, '20220817', '20220825', 'Martine', 'Ranc', 'Av. dos Lus√≠adas, 23', 'Lisboa', 'OR', '10100', 'USA', 'West', '(548) 555-1340');
INSERT INTO Capstone.dbo.Orders VALUES(14, 4, 5559, '20220620', 23, '20220623', '20220701', 'Maria', 'Larsson', 'Berkeley Gardens 12  Brewery', 'Barcelona', 'WA', '16752', 'USA', 'West', '(503) 555-6874');

CREATE TABLE Capstone.dbo.OrderDetail (
	OrderID	int,
	ProductID	int,
	UnitPrice	money,
	Quantity	int
);

INSERT INTO Capstone.dbo.OrderDetail VALUES(11, 501, 34.45, 2);
INSERT INTO Capstone.dbo.OrderDetail VALUES(12, 502, 12.62, 1);
INSERT INTO Capstone.dbo.OrderDetail VALUES(13, 505, 1.66, 3);
INSERT INTO Capstone.dbo.OrderDetail VALUES(14, 507, 21.32, 1);
INSERT INTO Capstone.dbo.OrderDetail VALUES(14, 508, 33.78, 5);

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
	UnitsInStock	int
);

INSERT INTO Capstone.dbo.Products VALUES(501, 'Razor', 844, 222, 34.45, 256);
INSERT INTO Capstone.dbo.Products VALUES(502, 'Hairbrush', 845, 222, 12.62, 654);
INSERT INTO Capstone.dbo.Products VALUES(505, 'Screen Door', 854, 254, 1.66, 254);
INSERT INTO Capstone.dbo.Products VALUES(507, 'Pumpkin', 875, 217, 21.32, 123);
INSERT INTO Capstone.dbo.Products VALUES(508, 'Cookie', 812, 217, 33.78, 237);

CREATE TABLE Capstone.dbo.Categories (
	CategoryID	int	NOT NULL PRIMARY KEY,
	CategoryName	nvarchar(40),
	CategoryDescription	nvarchar(100)
);

INSERT INTO Capstone.dbo.Categories VALUES(222, 'Grooming', 'Personal Health Products');
INSERT INTO Capstone.dbo.Categories VALUES(254, 'House', 'Items for the Household');
INSERT INTO Capstone.dbo.Categories VALUES(217, 'Edibles', 'Tasty eats');

CREATE TABLE Capstone.dbo.Suppliers (
	SupplierID	int	NOT NULL PRIMARY KEY,
	SupplierCompanyName	nvarchar(50),
	SupplierContactFirstName	nvarchar(25),
	SupplierContactLastName	nvarchar(25),
	SupplierAddress	nvarchar(40),
	SupplierCity	nvarchar(40),
	SupplierState	nvarchar(2),
	SupplierZip	nvarchar(10),
	SupplierCountry	nvarchar(40),
	SupplierRegion	nvarchar(40),
	SupplierPhone	nvarchar(20)
);

INSERT INTO Capstone.dbo.Suppliers VALUES(844, 'Exotic Liquids', 'Charlotte', 'Cooper', '49 Gilbert St.', 'Toledo', 'OH', '68544', 'USA', 'West', '(312) 555-2222');
INSERT INTO Capstone.dbo.Suppliers VALUES(845, 'New Orleans Cajun Delights', 'Shelley', 'Burke', 'P.O. Box 78934', 'Chicago', 'IL', '13765', 'USA', 'West', '(343) 555-4822');
INSERT INTO Capstone.dbo.Suppliers VALUES(854, 'Grandma Kellys Homestead', 'Regina', 'Murphy', '707 Oxford Rd.', 'Riverside', 'CA', '75162', 'USA', 'West', '(643) 555-5735');
INSERT INTO Capstone.dbo.Suppliers VALUES(875, 'Tokyo Traders', 'Yoshi', 'Nagase', '9-8 Sekimai Musashino-shi', 'Bakersville', 'CA', '76192', 'USA', 'West', '(213) 555-5011');
INSERT INTO Capstone.dbo.Suppliers VALUES(812, 'Cooperativa de Quesos', 'Antonio', 'Saavedra', 'Calle del Rosal 4', 'Austin', 'TX', '89543', 'USA', 'West', '(545) 623-8193');

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

ALTER TABLE Capstone.dbo.OrderDetail
	ADD CONSTRAINT FK_ORDERDETAIL_ORDERS
	FOREIGN KEY (OrderID)
	REFERENCES Capstone.dbo.Orders (OrderID);

ALTER TABLE Capstone.dbo.OrderDetail
	ADD CONSTRAINT FK_ORDERDETAIL_PRODUCTS
	FOREIGN KEY (ProductID)
	REFERENCES Capstone.dbo.Products (ProductID);

ALTER TABLE Capstone.dbo.Products
	ADD CONSTRAINT FK_PRODUCTS_SUPPLIERS
	FOREIGN KEY (SupplierID)
	REFERENCES Capstone.dbo.Suppliers (SupplierID);
	
ALTER TABLE Capstone.dbo.Products
	ADD CONSTRAINT FK_PRODUCTS_CATEGORIES
	FOREIGN KEY (CategoryID)
	REFERENCES Capstone.dbo.Categories (CategoryID);
