DROP TABLE PROJECT

CREATE TABLE Project
(
Id int IDENTITY(1,1) PRIMARY KEY,
Subject nvarchar(255),
Description(1000),
Status int,
SourceRespository nvarchar(255),
ReleasedVersion nvarchar(255),
RecentSprint int,
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Project_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2,
StartTime datetime2,
EndTime datetime2,
Members int,
LastUpdatedBy int,
Description nvarchar(1000)
)

INSERT INTO PROJECT (Subject, Status, SourceRespository, ReleasedVersion, RecentSprint, StartTime, EndTime, LastUpdatedBy)
VALUES('CRM', 1, 'http://github.com/crm.git', '1.00', 1, '2015-01-01', '2016-06-01', 1)

select * from Project