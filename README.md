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
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjUyNjhlNGQzLWQyYzEtNDJiZC1hYjFiLTIxNzgwOTI3NWQ3YyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImFkbWluQHJvb3QuY29tIiwiZnVsbE5hbWUiOiJyb290IEFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InJvb3QiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdXJuYW1lIjoiQWRtaW4iLCJpcEFkZHJlc3MiOiIwLjAuMC4xIiwidGVuYW50Ijoicm9vdCIsImltYWdlX3VybCI6IiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiIiwiZXhwIjoxNzE0ODUzMDY1fQ.0rXF2vRtk4BXVh3Weyj4L4jNlAOmJu5WSOnwzaQOBFw


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