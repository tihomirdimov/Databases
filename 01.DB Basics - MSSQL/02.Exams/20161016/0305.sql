SELECT t.TicketID,
       a.AirportName,
       c.FirstName+' '+c.LastName AS FullName
FROM Tickets AS t
     INNER JOIN Flights AS f ON f.FlightID = t.FlightID
     INNER JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
     INNER JOIN Customers AS c ON c.CustomerID = t.CustomerID
WHERE t.Class = 'First' AND t.Price < 5000
ORDER BY t.TicketID ASC;