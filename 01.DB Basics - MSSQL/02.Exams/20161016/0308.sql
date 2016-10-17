SELECT TOP 3 c.CustomerID,
             c.FirstName+' '+c.LastName AS FullName,
             tk.Price,
             a.AirportName
FROM Customers AS c
     INNER JOIN Tickets AS tk ON tk.CustomerID = c.CustomerID
     INNER JOIN Flights AS f ON f.FlightID = tk.FlightID
     INNER JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
WHERE f.Status ='Delayed'
ORDER by tk.Price desc, c.CustomerID asc