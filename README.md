# WebAppAPI
Simple REST API with Google and Microsoft Account authentication. It was a part of an university project. Data model is very simple, because the main part of this application was external provider authetication.

# Testing endpoints
Run as WebAppAPI (not ISS Express)
You can use Postman or web for GET endpoints


//----CARS----//	------------------------------------------------------------------------------------------------------------------------------------------------

GET all
https://localhost:5001/api/CarItems

GET index 
https://localhost:5001/api/CarItems/vin    vin is a key

POST
https://localhost:5001/api/CarItems + CarItem
example json 
{
  "vin": "1",
  "brandid":1,
  "model":"Cayenne",
  "productionyear":1994,
  "mileage": 12500,
  "fuel": "gasolinecc",
  "enginepower": 350,
  "color": "reddd",
  "photo": null,
  "description":"very niiice car, buyit pls"
}

PUT
https://localhost:5001/api/CarItems/vin + CarItem	vin is a key

DELETE 
https://localhost:5001/api/CarItems/vin 	vin is a key

//----BRANDS----//	------------------------------------------------------------------------------------------------------------------------------------------------

GET all
https://localhost:5001/api/BrandItems

GET index 
https://localhost:5001/api/BrandItems/index    index is a key
POST
https://localhost:5001/api/BrandItems + BrandItem
example json 
{
  "name": "Fiat"
}

DELETE 
https://localhost:5001/api/BrandItems/index 	index is a key

//----COUNTRIES----//	-------------------------------------------------------------------------------------------------------------------------------------------------

GET all
https://localhost:5001/api/CountryItems

GET index 
https://localhost:5001/api/CountryItems/index    index is a key

POST
https://localhost:5001/api/CountryItems + CountryItem
example json 
{
  "name": "Great Britain"
}

DELETE 
https://localhost:5001/api/CountryItems/index 	index is a key

GET CAR PRICE WITH TAX INCLUDED
https://localhost:5001/api/CountryItems/countryId/VIN
np
https://localhost:5001/api/CountryItems/1/123asd
