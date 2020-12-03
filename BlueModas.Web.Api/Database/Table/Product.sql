

create table Product
(
	ProductId UNIQUEIDENTIFIER DEFAULT NEWID(),
	ProductName varchar(50) not null,
	Price decimal(10,2) not null,
	Quantity int,
	Image varchar(200)
)