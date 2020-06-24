create table TOredersLists
(
  OrderID int references TOrders(OrderID) ON DELETE CASCADE,
  PrID int references TProducts(PrID) ON DELETE CASCADE,
  SuID int references TSuppliers(SuID),
  pCount int NOT NULL,
  PRIMARY KEY(OrderID, PrID, SuID)
)