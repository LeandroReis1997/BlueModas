﻿

ALTER TABLE Sale
ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId);