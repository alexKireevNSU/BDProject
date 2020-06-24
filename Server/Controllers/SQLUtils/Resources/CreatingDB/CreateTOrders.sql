create table TOrders
(
  OrderID int GENERATED ALWAYS AS IDENTITY,
  orderDate DATE NOT NULL,
  PRIMARY KEY(OrderID)
)