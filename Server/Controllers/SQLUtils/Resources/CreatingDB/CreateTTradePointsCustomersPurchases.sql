create table TTradePointsCustomersPurchases
(
  CuID int references TTradePointsCustomers(CuID) ON DELETE CASCADE,
  SaleID int references TTradePointsSales(SaleID) ON DELETE CASCADE,
  PRIMARY KEY(CuID, SaleID)
)