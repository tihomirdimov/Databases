SELECT TOP 5 f.FlightID,
             f.DepartureTime,
             f.ArrivalTime,
		   a.AirportName as Origin,
		   b.AirportName as Destination
FROM Flights AS f
     Left JOIN Airports AS a ON a.AirportID = f.OriginAirportID
	Left JOIN Airports AS b ON b.AirportID = f.DestinationAirportID
WHERE f.Status = 'Departing'
ORDER BY f.DepartureTime ASC,
         f.FlightID ASC;