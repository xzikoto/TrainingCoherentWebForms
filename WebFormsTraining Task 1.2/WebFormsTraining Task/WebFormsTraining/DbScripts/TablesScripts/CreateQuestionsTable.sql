USE SurveysDB
GO

IF OBJECT_ID('Questions', 'U') IS NOT NULL  
    DROP TABLE Questions
GO

CREATE TABLE Questions 
(
	QuestionId int not null identity primary key, 
	Question nvarchar(150) not null,
	IsActive bit
)
