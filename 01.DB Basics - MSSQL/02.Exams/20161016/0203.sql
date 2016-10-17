UPDATE Tickets
  SET
      Price = Price * 1.5
FROM Tickets
     INNER JOIN Flights ON Flights.FlightID = Tickets.FlightID
     INNER JOIN Airlines ON Airlines.AirlineID = Flights.AirlineID
WHERE Rating =
(
    SELECT MAX(Rating)
    FROM Airlines
);