USE SurveysDB
GO

IF OBJECT_ID('Users', 'U') IS NOT NULL  
    DROP TABLE Users
GO

CREATE TABLE Users 
(
	UserId int not null identity primary key, 
	[Name] nvarchar(150),
	Age smallint not null, CHECK(Age > 0 AND Age < 120),
	Gender nvarchar(20), CHECK(Gender LIKE 'MAN' OR Gender LIKE 'WOMAN' OR Gender LIKE 'CHILD' )
)