USE TasksDB
GO

IF OBJECT_ID('TasksTable', 'U') IS NOT NULL  
    DROP TABLE TasksTable
GO

CREATE TABLE TasksTable 
(
	task_id int not null identity primary key, 
	task_name nvarchar(150) not null,
	category nvarchar(20) not null, CHECK(category LIKE 'LOW' OR category LIKE 'MEDIUM' OR category LIKE 'HIGH'),
	[date] datetime not null
)
