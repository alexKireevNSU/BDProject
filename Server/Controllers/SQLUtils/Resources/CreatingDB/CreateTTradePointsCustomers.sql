create table TTradePointsCustomers
(
  CuID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255),
  description varchar(255),
  PRIMARY KEY(CuID)
)