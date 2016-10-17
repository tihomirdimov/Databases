SELECT e.TicketID,
       e.Price,
       e.Class,
       e.Seat
FROM Tickets
AS e
ORDER BY TicketID ASC;