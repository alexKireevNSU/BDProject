create table TEmployeesList
(
  TradePointID int references TTradePoints(TPID) ON DELETE CASCADE,
  EmployeeID int references TEmployees(EmID) ON DELETE CASCADE,
  PositionID int references TEmployeesPositions(EPID) ON DELETE CASCADE NOT NULL,
  PRIMARY KEY(TradePointID, EmployeeID)
)