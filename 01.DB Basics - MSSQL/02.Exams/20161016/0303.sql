SELECT e.FlightID,
       e.DepartureTime,
       e.ArrivalTime
FROM Flights
AS e
WHERE e.Status='Delayed'
ORDER BY FlightID ASC;