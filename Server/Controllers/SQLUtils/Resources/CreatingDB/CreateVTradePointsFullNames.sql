CREATE OR REPLACE VIEW VTradePointsFullNames AS
WITH 
ObjRelWithNames(id, pid, name) AS
(
SELECT tp.TPID as "id", objRel.ParentID as "pid", tp.name as "name"
FROM TTradePoints tp
LEFT JOIN TObjectsRelations objRel ON tp.TPID = objRel.ID
),
stepbystep(id, pid, name, sid) AS
(
  SELECT id, pid, name, id
  FROM ObjRelWithNames
  UNION ALL
  SELECT objRel.id, objRel.pid, objRel.name || ' / ' || s.name, s.sid
  FROM ObjRelWithNames objRel
      INNER JOIN stepbystep s
      ON s.pid = objRel.id
)
SELECT tp."ID", tp."Name", s.name, tp."Type ID", tp."Type Name", tp."Size", tp."Number Of Counters", tp."Is Barren" FROM VTradePoints tp INNER JOIN stepbystep s ON s.sid = tp."ID"
WHERE s.pid is null