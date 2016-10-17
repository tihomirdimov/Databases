SELECT TOP 5 a.AirlineID,
             a.AirlineName,
             a.Nationality,
             a.Rating
FROM Airlines AS a
     INNER JOIN Flights AS f ON f.AirlineID = a.AirlineID
GROUP BY a.AirlineID,a.AirlineName,a.Nationality,a.Rating order BY a.Rating Desc;