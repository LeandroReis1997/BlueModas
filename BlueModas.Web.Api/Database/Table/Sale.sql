

create table Sale
(
	SaleId UNIQUEIDENTIFIER DEFAULT NEWID(),
	ProductId UNIQUEIDENTIFIER DEFAULT null,
	NumberOrder int not null			   
)