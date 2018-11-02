IF OBJECT_ID(N'Categories', N'U') IS NULL
BEGIN
	CREATE TABLE Categories
	(
		Id INT IDENTITY(1,1) NOT NULL
	  , Name NVARCHAR(250) NOT NULL
	  , CONSTRAINT Categories_PK PRIMARY KEY(Id)
	)

	INSERT INTO Categories(Name) VALUES(N'CategoryA'),(N'CategoryB'),(N'CategoryC'),(N'CategoryD'),(N'CategoryE')
END

IF OBJECT_ID(N'Products', N'U') IS NULL
BEGIN
	CREATE TABLE Products
	(
		Id INT IDENTITY(1,1) NOT NULL
	  , Name NVARCHAR(250) NOT NULL
	  , CONSTRAINT Products_PK PRIMARY KEY(Id)
	)

	INSERT INTO Products(Name) VALUES (N'Product1'),(N'Product2'),(N'Product3'),(N'Product4'),(N'Product5')
END

IF OBJECT_ID(N'CategoriesProducts', N'U') IS NULL
BEGIN
	CREATE TABLE CategoriesProducts
	(
		Category_Id INT NOT NULL
		, Product_Id INT NOT NULL
		, CONSTRAINT Category_FK FOREIGN KEY(Category_Id) REFERENCES Categories(Id)
		, CONSTRAINT Product_FK FOREIGN KEY(Product_Id) REFERENCES Products(Id)
		, CONSTRAINT CategoryProduct_UNQ UNIQUE(Category_Id, Product_Id)
	)

	INSERT INTO CategoriesProducts(Category_Id, Product_Id) VALUES (1,1), (1,2), (2,1), (3,3), (4,5)
END

  /************/
 /*  Запрос  */
/************/

SELECT P.Name as ProductName, C.Name as CategoryName
FROM Products as P
	 LEFT OUTER JOIN CategoriesProducts as CP ON CP.Product_Id = P.Id
	 LEFT OUTER JOIN Categories as C ON C.Id = CP.Category_Id