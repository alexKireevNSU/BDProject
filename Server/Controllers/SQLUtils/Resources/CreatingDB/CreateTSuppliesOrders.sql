create table TSuppliesOrders
(
  SuID int references TSupplies(SuID) ON DELETE CASCADE,
  OrderID int references TOrders(OrderID) ON DELETE CASCADE,
  PRIMARY KEY(SuID, OrderID)
)