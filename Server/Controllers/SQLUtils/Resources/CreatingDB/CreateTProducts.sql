create table TProducts
(
  PrID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255),
  PRIMARY KEY(PrID)
)