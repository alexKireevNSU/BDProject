create table TRequestsOrders
(
  OrderId int references TOrders(OrderID) ON DELETE CASCADE,
  RequestID int references TTradePointsRequests(RequestID) ON DELETE CASCADE,
  PRIMARY KEY(OrderID, RequestID)
)