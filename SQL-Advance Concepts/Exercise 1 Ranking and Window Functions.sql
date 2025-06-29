//
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Customers VALUES
(1, 'Alice', 'East'),
(2, 'Bob', 'West'),
(3, 'Charlie', 'East'),
(4, 'Diana', 'North');

INSERT INTO Products VALUES
(101, 'Laptop', 'Electronics', 1000.00),
(102, 'Smartphone', 'Electronics', 800.00),
(103, 'Tablet', 'Electronics', 800.00),
(104, 'Chair', 'Furniture', 150.00),
(105, 'Desk', 'Furniture', 200.00),
(106, 'Sofa', 'Furniture', 500.00);

INSERT INTO Orders VALUES
(201, 1, '2025-01-05'),
(202, 2, '2025-01-10'),
(203, 1, '2025-01-15'),
(204, 3, '2025-01-20'),
(205, 1, '2025-01-25'),
(206, 1, '2025-01-28');

INSERT INTO OrderDetails VALUES
(301, 201, 101, 1),
(302, 202, 104, 2),
(303, 203, 102, 1),
(304, 204, 105, 1),
(305, 205, 103, 1),
(306, 206, 106, 1);

//Exercise 1: Ranking in MySQL

SELECT
    Category,
    ProductName,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankPos,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank
FROM Products;

