create table TTradePointsRequests
(
  RequestID int GENERATED ALWAYS AS IDENTITY,
  TPID int references TTradePoints(TPID) ON DELETE CASCADE,
  PrID int references TProducts(PrID) ON DELETE CASCADE,
  pCount int NOT NULL,
  PRIMARY KEY(RequestID)
)