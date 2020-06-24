create table TTypes
(
  TypeID int GENERATED ALWAYS AS IDENTITY,
  name varchar(255) NOT NULL,
  PRIMARY KEY(TypeID)
)