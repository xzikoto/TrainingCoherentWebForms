USE SurveysDB
GO

IF OBJECT_ID('QuestionOptions', 'U') IS NOT NULL  
    DROP TABLE QuestionOptions
GO

CREATE TABLE QuestionOptions 
(
	OptionId int not null identity primary key, 
	QuestionId int not null FOREIGN KEY REFERENCES Questions(QuestionId),
	IsCorrect bit not null,
	[Option] nvarchar(50) not null
)
