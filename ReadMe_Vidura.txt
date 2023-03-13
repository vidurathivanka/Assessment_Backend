-----------------------Vidura Assessment------------------------

I have atached DB script to create Order and Cutomer table and sample data for insert.
I ahve changed the USer name and password of the connection to mine

below are the sample API data

API sample 
---Create Customer-----------
{
  "firstName": "TEST",
  "lastName": "End Name",
  "dateOfBirth": "2003-03-12"
}
 
--Update Flight Rate ---
{
  "id": "05f26806-06d3-4ec0-b874-733e0fc9beed",
  "price": {
    "value": 5000,
    "currency": 0
  }
}

---Draft Order ------------------
{
  "customerId": "5eba1dad-a1f3-40bf-b227-8589c3b39535",
  "flightId": "2bdf08eb-8926-4c84-be56-7d5a03913d0c",
  "flightRateId": "05f26806-06d3-4ec0-b874-733e0fc9beed",
  "amount": 0,
  "status": 0,
  "quantity": 0
}

---------Submit Order---------------
{
  "id": "5eba1dad-a1f3-40bf-b227-8589c3b39789",
  "status": 0
}