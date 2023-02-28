USE SurveysDB
GO

IF OBJECT_ID('OnlineExam', 'U') IS NOT NULL  
    DROP TABLE OnlineExam
GO

CREATE TABLE OnlineExam 
(
	QuestionId int not null identity primary key, 
	QUESTION nvarchar(150) not null,
	Option1 nvarchar(150) not null,
	Option2 nvarchar(150) not null,
	Option3 nvarchar(150) not null,
	Option4 nvarchar(150) not null,
	Correctans nvarchar(150) not null
)
