USE SurveysDB
GO

IF OBJECT_ID('OnlineExam', 'U') IS NOT NULL  
    INSERT INTO OnlineExam (QUESTION, Option1, Option2, Option3, Option4, Correctans)
    VALUES ('What it the capital of Yamoussoukro', 'Burundi', 'Moldova', 'Cyprus', 'Côte d’Ivoire', 'Côte d’Ivoire');

	INSERT INTO OnlineExam (QUESTION, Option1, Option2, Option3, Option4, Correctans)
    VALUES ('What it the capital of Georgetown', 'Guyana', 'Marshall Islands', 'Afghanistan', 'South Africa', 'Guyana');

	INSERT INTO OnlineExam (QUESTION, Option1, Option2, Option3, Option4, Correctans)
    VALUES ('What it the capital of Windhoek', 'Republic of the Congo', 'Mali', 'Namibia', 'Australia', 'Namibia');

GO