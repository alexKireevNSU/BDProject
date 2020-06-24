create table TTradePointsProps
(
  TPID int primary key references TTradePoints(TPID) ON DELETE CASCADE,
  tradePointSize int,
  numberOfCounters int
)