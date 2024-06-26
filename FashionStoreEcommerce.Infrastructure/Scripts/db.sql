CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL
);

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    Nit INT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);


CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(MAX) NOT NULL,
    ImageUrl VARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Stock DECIMAL(18, 2) NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE OrderItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    PaymentDate DATETIME NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);