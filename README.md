Please clone the project

FIrst run the script.sql file to make the database

Run the project

type the https://localhost:5001/swagger/index.html in your project to test by swagger.

In swagger first call the /api/tokens with the body below

header 

teanant: root

json body
{
  "email": "admin@root.com",
  "password": "123Pa$$word!"
}


from the above response copy the value field of token and paste on swagger authorization


Then expand the node User Request and call the APIs

for create with the body below
{
  "title": "درخواست 3",
  "amount": 3344555,
  "insurenceCovers": [
    1,2,3
  ]
}


for get with body below
{
  
  "pageNumber": 1,
  "pageSize": 100,
  "orderBy": [
    
  ]
}