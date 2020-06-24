create table TObjectsRelations
(
  ObjRelID int GENERATED ALWAYS AS IDENTITY,
  ParentID int references TTradePoints(TPID) ON DELETE CASCADE,
  ID int references TTradePoints(TPID) ON DELETE CASCADE,
  PRIMARY KEY(ObjRelID)
)