create table TEmployees
(
  EmID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255) NOT NULL,
  PRIMARY KEY(EmID)
)