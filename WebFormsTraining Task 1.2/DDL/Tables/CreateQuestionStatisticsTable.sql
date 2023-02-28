USE SurveysDB
GO

IF OBJECT_ID('QuestionStatisticsTable', 'U') IS NOT NULL  
    DROP TABLE QuestionStatisticsTable
GO

CREATE TABLE QuestionStatisticsTable 
(
	QuestionId int not null identity, 
	Question nvarchar(150) not null,
	IsCorrect smallint not null,
	Gender nvarchar(20) not null, CHECK(Gender LIKE 'MAN' OR Gender LIKE 'WOMAN')
)