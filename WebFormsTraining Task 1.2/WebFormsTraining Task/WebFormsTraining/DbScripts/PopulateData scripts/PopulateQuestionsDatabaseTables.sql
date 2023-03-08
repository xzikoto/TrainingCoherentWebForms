USE SurveysDB
GO

IF OBJECT_ID('Questions', 'U') IS NOT NULL  
    INSERT INTO Questions (Question, IsActive)
    VALUES ('What is the capital of Bulgaria?', 1);
GO

IF OBJECT_ID('QuestionOptions', 'U') IS NOT NULL  
    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (1,'Sofia', 1);

    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (1,'Brussels', 0);

    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (1,'Skopje', 0);

    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (1,'Valletta', 0);
GO



IF OBJECT_ID('Questions', 'U') IS NOT NULL  
    INSERT INTO Questions (Question, IsActive)
    VALUES ('What is the capital of Germany?', 1);
GO

IF OBJECT_ID('QuestionOptions', 'U') IS NOT NULL  
    
    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (2,'Kabul', 0);

    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (2,'Berlin', 1);

    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (2,'Brasilia', 0);

    INSERT INTO QuestionOptions (QuestionId, [Option], IsCorrect)
    VALUES (2,'Washington', 0);

GO

