SELECT c.CustomerID,
       c.FirstName+' '+c.LastName AS FullName,
       tw.TownName AS HomeTown
FROM Customers AS c
     INNER JOIN Tickets AS tk ON tk.CustomerID = c.CustomerID
     INNER JOIN Flights AS f ON f.FlightID = tk.FlightID
     INNER JOIN Towns AS tw ON tw.TownID = f.OriginAirportID
WHERE f.Status = 'Departing'
      AND f.OriginAirportID = c.HomeTownID
ORDER BY c.CustomerID ASC;