create table TEmployeesPositions
(
  EPID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255) NOT NULL,
  PRIMARY KEY(EPID)
)