CREATE OR REPLACE VIEW VEmployees AS
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
),
FullNames as
(
SELECT sid, name FROM stepbystep
WHERE pid is null
)
SELECT e.EmID as "Employee ID",
       e.name as "Employee Name",
       ep.EPID as "Position ID",
       ep.name as "Position",
       tp.TPID as "Trade Point ID",
       fn.name as "Trade Point",
       t.TypeID as "Trade Point Type ID",
       t.name "Trade Point Type" 
FROM TEmployees e 
    LEFT JOIN TEmployeesList el ON e.EmID = el.EmployeeID
    LEFT JOIN TEmployeesPositions ep ON el.PositionID = ep.EPID
    LEFT JOIN TTradePoints tp ON el.TradePointID = tp.TPID
    LEFT JOIN TTypes t ON t.TypeID = tp.TypeID
    LEFT JOIN FullNames fn ON sid = tp.TPID
