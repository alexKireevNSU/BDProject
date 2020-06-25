CREATE or Replace VIEW VTradePoints AS
SELECT tp.TPID as "ID",
       tp.name as "Name",
       tp.TypeID as "Type ID",
       t.name as "Type Name",
       tp.tradePointSize as "Size",
       tp.numberOfCounters as "Number Of Counters",
       t.isBarren as "Is Barren"
FROM TTradePoints tp
INNER JOIN TTypes t ON tp.TypeID = t.TypeID