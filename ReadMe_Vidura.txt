-----------------------Vidura Assessment------------------------

I have atached DB script to create Order and Cutomer table and sample data for insert.
I ahve changed the USer name and password of the connection to mine

below are the sample API data
NOTE - please run the 'SQL_DATA_INSERT_query.sql' before call the API

API sample 

----------Get Flights--
user can inser the destination airport code and get the available flights details,
	if there is no any flights available it will give warrning message
	if there is no any match airport for the given code it will show warning message.

---Create Customer-----------
{
  "firstName": "Kasun",
  "lastName": "Prabath",
  "dateOfBirth": "2001-03-12"
}
 
------Get Customer -------------
user can search by string, system will return customer details which conatins in first name or last name.

--Update Flight Rate ---
{
  "id": "aa714f5d-dd51-489a-a403-f61d01d5c990",
  "price": {
    "value": 5000,
    "currency": 0
  }
}

---Draft Order ------------------
{
  "customerId": "5eba1dad-a1f3-40bf-b227-8589c3b39539",
  "flightId": "aa714f5d-dd51-489a-a403-f61d01d5c980",
  "flightRateId": "aa714f5d-dd51-489a-a403-f61d01d5c991", 
  "quantity": 8
}

---------Submit Order---------------
{
  "id": "5eba1dad-a1f3-40bf-b227-8589c3b39789",
  "status": 0
}