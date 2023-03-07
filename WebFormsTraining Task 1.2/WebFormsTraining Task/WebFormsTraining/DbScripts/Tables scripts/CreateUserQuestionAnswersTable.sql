USE SurveysDB
GO

IF OBJECT_ID('UserQuestionAnswers', 'U') IS NOT NULL  
    DROP TABLE UserQuestionAnswers
GO

CREATE TABLE UserQuestionAnswers 
(
	UserId int not null primary key FOREIGN KEY REFERENCES Users(UserId), 
	QuestionId int not null  FOREIGN KEY REFERENCES Questions(QuestionId),
	OptionId int not null  FOREIGN KEY REFERENCES QuestionOptions(OptionId),
	IsCorrect bit not null
)