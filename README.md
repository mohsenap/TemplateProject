Please clone the project


modify the connection strings in  the files below

database.json

hangfire.json



Run the project

The database will be created automatically


Run the script below for the base data


DECLARE @Userid UNIQUEIDENTIFIER
SELECT @Userid = Id from [Identity].Users WHERE Email ='admin@root.com'
INSERT INTO Catalog.InsuranceCoverage (Id, InsurenceCover, MinimumAmount, MaximumAmount, Description, TenantId, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy)
	VALUES (NEWID(), 1, 5000, 500000000, N'Surgery', N'root', @Userid, SYSDATETIME(), @Userid, SYSDATETIME(), NULL, NULL);

INSERT INTO Catalog.InsuranceCoverage (Id, InsurenceCover, MinimumAmount, MaximumAmount, Description, TenantId, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy)
	VALUES (NEWID(), 2, 4000, 400000000, N'Dentith', N'root', @Userid, SYSDATETIME(), @Userid, SYSDATETIME(), NULL, NULL);


INSERT INTO Catalog.InsuranceCoverage (Id, InsurenceCover, MinimumAmount, MaximumAmount, Description, TenantId, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy)
VALUES (NEWID(), 3, 2000, 200000000, N'Hospitalization', N'root', @Userid, SYSDATETIME(), @Userid, SYSDATETIME(), NULL, NULL);




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