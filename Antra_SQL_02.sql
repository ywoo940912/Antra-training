-- 1.
SELECT COUNT(*) AS TotalProducts
FROM Production.Product;

-- 2.
SELECT COUNT(*) AS ProductsWithSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL;

-- 3.
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID;

-- 4. 
SELECT COUNT(*) AS ProductsWithoutSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

-- 5. 
SELECT SUM(Quantity) AS TotalQuantity
FROM Production.ProductInventory;

-- 6. 
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;

-- 7. 
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;

-- 8. 
SELECT AVG(Quantity) AS AverageQuantity
FROM Production.ProductInventory
WHERE LocationID = 10;

-- 9. 
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf;

-- 10. 
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf;

-- 11. 
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;

-- 12. 
SELECT cr.Name AS Country, sp.Name AS Province
FROM Person.CountryRegion cr
JOIN Person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode;

-- 13. 
SELECT cr.Name AS Country, sp.Name AS Province
FROM Person.CountryRegion cr
JOIN Person.StateProvince sp ON cr.CountryRegionCode = sp.CountryRegionCode
WHERE cr.Name IN ('Germany', 'Canada');

-- 14. 
SELECT DISTINCT p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE());

-- Down below codes use Northwind

-- 15. 
SELECT TOP 5 c.PostalCode, COUNT(od.Quantity) AS TotalSold
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.PostalCode
ORDER BY TotalSold DESC;

-- 16. 
SELECT TOP 5 c.PostalCode, COUNT(od.Quantity) AS TotalSold
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY c.PostalCode
ORDER BY TotalSold DESC;

-- 17. 
SELECT c.City, COUNT(c.CustomerID) AS TotalCustomers
FROM Customers c
GROUP BY c.City;

-- 18. 
SELECT c.City, COUNT(c.CustomerID) AS TotalCustomers
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 2;

-- 19. 
SELECT DISTINCT c.CompanyName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01';

-- 20. 
SELECT c.CompanyName, MAX(o.OrderDate) AS MostRecentOrder
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CompanyName;

-- 21. 
SELECT c.CompanyName, COUNT(od.ProductID) AS TotalProductsBought
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CompanyName;

-- 22. 
SELECT c.CustomerID, COUNT(od.ProductID) AS TotalProductsBought
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.ProductID) > 100;

-- 23. 
SELECT s.CompanyName AS SupplierCompany, sh.CompanyName AS ShippingCompany
FROM Suppliers s
CROSS JOIN Shippers sh;

-- 24. 
SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate;

-- 25. 
SELECT e1.FirstName + ' ' + e1.LastName AS Employee1, 
       e2.FirstName + ' ' + e2.LastName AS Employee2, 
       e1.Title
FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID;

-- 26. 
SELECT e1.FirstName + ' ' + e1.LastName AS Manager, COUNT(e2.EmployeeID) AS TotalEmployees
FROM Employees e1
JOIN Employees e2 ON e1.EmployeeID = e2.ReportsTo
GROUP BY e1.EmployeeID, e1.FirstName, e1.LastName
HAVING COUNT(e2.EmployeeID) > 2;

-- 27. 
SELECT City, 
       CompanyName AS Name, 
       ContactName, 
       'Customer' AS Type
FROM Customers
UNION
SELECT City, 
       CompanyName AS Name, 
       ContactName, 
       'Supplier' AS Type
FROM Suppliers;
