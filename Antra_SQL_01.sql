-- 1.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product;

-- 2.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE ListPrice > 0;

-- 3.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NULL;

-- 4.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL;

-- 5.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0;

-- 6.
SELECT Name + ' ' + Color AS Product_Details
FROM Production.Product
WHERE Color IS NOT NULL;

-- 7.
SELECT 'NAME: ' + Name + '  --  COLOR: ' + Color AS Product_Details
FROM Production.Product
WHERE Name IN ('LL Crankarm', 'ML Crankarm', 'HL Crankarm', 'Chainring Bolts', 'Chainring Nut', 'Chainring');

-- 8.
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500;

-- 9.
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color IN ('Black', 'Blue');

-- 10.
SELECT ProductID, Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%'
ORDER BY Name;

-- 11.
SELECT Name, ListPrice
FROM Production.Product
ORDER BY Name;

-- 12.
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'A%' OR Name LIKE 'S%'
ORDER BY Name;

-- 13.
SELECT Name
FROM Production.Product
WHERE Name LIKE 'SPO%' AND Name NOT LIKE 'SPOK%'
ORDER BY Name;

-- 14.
SELECT DISTINCT Color
FROM Production.Product
ORDER BY Color DESC;
