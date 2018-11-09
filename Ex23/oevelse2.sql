DROP TABLE IF EXISTS LINE_ITEM
DROP TABLE IF EXISTS INVOICE
DROP TABLE IF EXISTS PRODUCT



CREATE TABLE INVOICE
(
	InvoiceNumber		int				primary key
	,InvoiceDate		datetime		NOT NULL
	,SubTotal			float			NOT NULL
	,TaxPct				float			NOT NULL
	,Total				float			NOT NULL
);

CREATE TABLE PRODUCT
(
	ProductNumber		int				primary key
	,ProductType		varchar(50)		NOT NULL
	,ProductDescription	varchar(100)	NOT NULL
	,UnitPrice			float			NOT NULL
);

CREATE TABLE LINE_ITEM
(
	InvoiceNumber		int				NOT NULL
	,LineNumber			int				NOT NULL
	,ProductNumber		int				NOT NULL
	,Quantity			int				NOT NULL
	,Unitprice			float			NOT NULL
	,Total				float			NOT NULL

	,primary key (InvoiceNumber, LineNumber)

	,CONSTRAINT FK_INVOICE FOREIGN KEY (InvoiceNumber)
		REFERENCES INVOICE (InvoiceNumber)
		ON DELETE CASCADE
		ON UPDATE CASCADE

	,CONSTRAINT FK_PRODUCT FOREIGN KEY (ProductNumber)
		REFERENCES PRODUCT (ProductNumber)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);