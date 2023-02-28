USE SurveysDB
GO

IF OBJECT_ID('ExamAnswers', 'U') IS NOT NULL  
    DROP TABLE ExamAnswers
GO

CREATE TABLE ExamAnswers 
(
	AnswerId int not null identity primary key, 
	AnswerQuestion1 nvarchar(150) not null,
	AnswerQuestion2 nvarchar(150) not null,
	AnswerQuestion3 nvarchar(150) not null,
	CorrectAnswers smallint not null,
	[Name] nvarchar(50) not null,
	Age nvarchar(20) not null, CHECK(Age > 0 AND AGE < 120),
	Gender nvarchar(20) not null, CHECK(Gender LIKE 'MAN' OR Gender LIKE 'WOMAN')
)
