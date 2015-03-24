CREATE TABLE LoginHistory
(
Id int IDENTITY(1,1) PRIMARY KEY,
UserId int,
Status int,
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_LoginHistory_CreateDate_GETDATE DEFAULT GETDATE()
)