CREATE TABLE Flights (

FlightID	INT	Primary Key,
DepartureTime Datetime	Not Null,
ArrivalTime datetime	Not Null,
Status varchar(9) NOT NULL CHECK (Status='Departing' OR Status='Delayed'OR Status='Arrived'OR Status='Cancelled'),
OriginAirportID  INT,
DestinationAirportID INT,
AirlineID	INT,
CONSTRAINT FK_Flights_Airports_Origins Foreign key (OriginAirportID) references Airports (AirportID),
CONSTRAINT FK_Flights_Airports_Destinations Foreign key (DestinationAirportID) references Airports (AirportID),
CONSTRAINT FK_Flifhts_Airlines foreign key (AirlineID) references Airlines (AirlineID)
)


CREATE TABLE Tickets(
TicketID INT Primary Key,
Price float(2) not null,
Class varchar(6) NOT NULL CHECK (Class='First' OR Class='Second'OR Class='Third'),
Seat	varchar(5) not null,
CustomerID INT,
FlightID	INT,
CONSTRAINT FK_Tickets_Customers foreign key (CustomerId) references Customers (CustomerID),
CONSTRAINT FK_Tickets_Flights foreign key (FlightID) references Flights (FlightID)
)