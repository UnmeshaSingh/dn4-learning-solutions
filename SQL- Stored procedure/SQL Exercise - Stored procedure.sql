//SCHEMA
-- Create Tables
CREATE TABLE Departments (
 DepartmentID INT PRIMARY KEY,
 DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
 EmployeeID INT PRIMARY KEY,
 FirstName VARCHAR(50),
 LastName VARCHAR(50),
 DepartmentID INT,
 Salary DECIMAL(10,2),
 JoinDate DATE,
 FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

-- Insert Data
INSERT INTO Departments VALUES
(1, 'HR'), (2, 'Finance'), (3, 'IT'), (4, 'Marketing');

INSERT INTO Employees VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

//QUERY
-- Exercise 1 & 4: Simulate "sp_GetEmployeesByDepartment" for DepartmentID = 3
SELECT EmployeeID, FirstName, LastName, Salary, JoinDate
FROM Employees
WHERE DepartmentID = 3;

-- Exercise 5: Simulate "sp_GetEmployeeCountByDepartment" for DepartmentID = 2
SELECT COUNT(*) AS TotalEmployees
FROM Employees
WHERE DepartmentID = 2;
