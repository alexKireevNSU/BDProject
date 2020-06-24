create table TTradePointsPayments
(
  TPPID int GENERATED ALWAYS AS IDENTITY,
  TPID int references TTradePoints(TPID) ON DELETE CASCADE,
  name varchar(255) NOT NULL,
  psum float(31) NOT NULL,
  pdate date NOT NULL,
  primary key(TPPID)
)