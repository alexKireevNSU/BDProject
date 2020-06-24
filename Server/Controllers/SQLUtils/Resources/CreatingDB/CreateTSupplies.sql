create table TSupplies
(
  SuID int GENERATED ALWAYS AS IDENTITY,
  supplyDate DATE NOT NULL,
  PRIMARY KEY(SuID)
)