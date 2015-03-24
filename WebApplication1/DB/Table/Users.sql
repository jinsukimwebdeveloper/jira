CREATE TABLE Users
(
UserId int IDENTITY(1,1) PRIMARY KEY,
Name varchar(255),
Password varchar(255),
Email varchar(255),
Status bit,
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Users_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2
)
INSERT INTO Users (Name, Password, Email, Status) VALUES('±èÁø¼ö', '12345', 'dhammi@hanmail.net', 1);

