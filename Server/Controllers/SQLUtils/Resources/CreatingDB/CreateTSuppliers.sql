create table TSuppliers
(
  SuID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255),
  PRIMARY KEY(SuID)
)