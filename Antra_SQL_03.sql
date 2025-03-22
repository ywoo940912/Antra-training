-- 1.
SELECT DISTINCT c.City
FROM Customers c
JOIN Employees e ON c.City = e.City;

-- 2a.
SELECT DISTINCT City 
FROM Customers 
WHERE City NOT IN (SELECT DISTINCT City FROM Employees);

-- 2b.
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL;

-- 3.
SELECT p.ProductName, SUM(od.Quantity) AS TotalOrderedQuantity
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName
ORDER BY TotalOrderedQuantity DESC;

-- 4.
SELECT c.City, SUM(od.Quantity) AS TotalProductsOrdered
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY TotalProductsOrdered DESC;

-- 5.
SELECT City, COUNT(CustomerID) AS NumberOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2;

-- 6.
SELECT c.City
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2;

-- 7.
SELECT DISTINCT c.CompanyName, c.City AS CustomerCity, o.ShipCity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity;

-- 8.
WITH ProductPopularity AS (
    SELECT od.ProductID, SUM(od.Quantity) AS TotalSold
    FROM [Order Details] od
    GROUP BY od.ProductID
),
TopCities AS (
    SELECT od.ProductID, c.City, SUM(od.Quantity) AS CityTotal
    FROM [Order Details] od
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    GROUP BY od.ProductID, c.City
)
SELECT TOP 5 p.ProductName, AVG(od.UnitPrice) AS AvgPrice, tc.City AS TopOrderingCity
FROM ProductPopularity pp
JOIN Products p ON pp.ProductID = p.ProductID
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN TopCities tc ON p.ProductID = tc.ProductID
ORDER BY pp.TotalSold DESC;

-- 9a.
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (SELECT DISTINCT o.ShipCity FROM Orders o);

-- 9b.
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL;

-- 10.
WITH TopEmployeeSales AS (
    SELECT TOP 1 e.City, COUNT(o.OrderID) AS TotalOrders
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
    ORDER BY TotalOrders DESC
),
TopProductSales AS (
    SELECT TOP 1 c.City, SUM(od.Quantity) AS TotalQuantity
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY c.City
    ORDER BY TotalQuantity DESC
)
SELECT te.City
FROM TopEmployeeSales te
JOIN TopProductSales tp ON te.City = tp.City;

-- 11. In this case, we remove the duplicates record of Orders
WITH CTE AS (
    SELECT *, 
           ROW_NUMBER() OVER (PARTITION BY CustomerID, OrderDate, ShipCity ORDER BY OrderID) AS RowNum
    FROM Orders
)
DELETE FROM Orders WHERE OrderID IN (SELECT OrderID FROM CTE WHERE RowNum > 1);

