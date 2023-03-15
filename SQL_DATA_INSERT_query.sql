-- Insert Values to AirportT Table with Primary Id for API testing
INSERT INTO public."Airports"(
	"Id", "Code", "Name")
	VALUES ('b8c4e407-6690-4a85-8a70-12e9d198dc80', 'KAS', 'Katunayaka Airport Srilanka');
INSERT INTO public."Airports"(
	"Id", "Code", "Name")
	VALUES ('b8c4e407-6690-4a85-8a70-12e9d198dc90', 'MAS', 'Mattala Airport Srilanka');	
	
-- Insert Values to Flights Table with Primary Id for API testing	
INSERT INTO public."Flights"(
	"Id", "OriginAirportId", "DestinationAirportId", "Departure", "Arrival")
	VALUES ('aa714f5d-dd51-489a-a403-f61d01d5c980', 'b8c4e407-6690-4a85-8a70-12e9d198dc80', 'b8c4e407-6690-4a85-8a70-12e9d198dc90', '2021-09-01 22:22:00+05:30', '2021-09-02 08:22:00+05:30');
	
-- Insert Values to FlightRates Table with Primary Id for API testing
INSERT INTO public."FlightRates"(
	"Id", "Name", "Price_Value", "Price_Currency", "Available", "FlightId")
	VALUES ('aa714f5d-dd51-489a-a403-f61d01d5c990','Economy class', 300, 0, 100, 'aa714f5d-dd51-489a-a403-f61d01d5c980');
INSERT INTO public."FlightRates"(
	"Id", "Name", "Price_Value", "Price_Currency", "Available", "FlightId")
	VALUES ('aa714f5d-dd51-489a-a403-f61d01d5c991','Business class', 350, 0, 100, 'aa714f5d-dd51-489a-a403-f61d01d5c980');
	
-- Insert Values to Customer Table with Primary Id for API testing
INSERT INTO public."Customer"(
	"Id", "FirstName", "LastName", "DateOfBirth")
	VALUES ('5eba1dad-a1f3-40bf-b227-8589c3b39539','Sahan', 'Perera', '"2000-03-12"');
	
-- Insert Values to Order Table with Primary Id for API testing 
INSERT INTO public."Order"(
	"Id", "CustomerId", "FlightId", "Amount", "Status", "Quantity", "FlightRateId")
	VALUES ('5eba1dad-a1f3-40bf-b227-8589c3b39798','5eba1dad-a1f3-40bf-b227-8589c3b39539','aa714f5d-dd51-489a-a403-f61d01d5c980', 350, 0, 5, 'aa714f5d-dd51-489a-a403-f61d01d5c991');