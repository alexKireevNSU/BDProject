create table TTradePoints
(
  TPID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255) NOT NULL,
  TypeID int references TTypes(TypeID) ON DELETE CASCADE NOT NULL,
  PRIMARY KEY(TPID)
)