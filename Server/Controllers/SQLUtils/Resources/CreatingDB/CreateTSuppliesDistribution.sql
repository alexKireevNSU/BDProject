create table TSuppliesDistribution
(
  SDID int GENERATED ALWAYS AS IDENTITY,
  SuppliesID int references TSupplies(SuID) ON DELETE CASCADE,
  PrID int references TProducts(PrID) ON DELETE CASCADE,
  TPID int references TTradePoints(TPID) ON DELETE CASCADE,
  SuppliersID int references TSuppliers(SuID),
  pCount int NOT NULL,
  price float(31) NOT NULL,
  CONSTRAINT CSuppliesDistributionUnique UNIQUE (SuppliesID, PrID, SuppliersID, TPID),
  PRIMARY KEY(SDID)
)