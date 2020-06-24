create table TTradePointsSales
(
  SaleID int GENERATED ALWAYS AS IDENTITY,
  TRID int references TTradePoints(TPID) ON DELETE CASCADE,
  PrID int references TProducts(PrID) ON DELETE CASCADE,
  SuID int references TSuppliers(SuID),
  pCount int NOT NULL,
  price float(31) NOT NULL,
  saleDate DATE NOT NULL,
  PRIMARY KEY(SaleID)
)