CREATE TABLE Component
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Component_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2
)

INSERT INTO Component(Name) Values('WEB')
INSERT INTO Component(Name) Values('DB')
INSERT INTO Component(Name) Values('Requirement')
SELECT * FROM Component

CREATE TABLE Status
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Status_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2
)

INSERT INTO Status(Name) Values('Open')
INSERT INTO Status(Name) Values('Resolved')
INSERT INTO Status(Name) Values('Verified')
INSERT INTO Status(Name) Values('Closed')
SELECT * FROM Status

CREATE TABLE Priority
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Priority_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2
)
INSERT INTO Priority(Name) Values('Major')
INSERT INTO Priority(Name) Values('Trivial')
INSERT INTO Priority(Name) Values('Minor')
SELECT * FROM Priority

CREATE TABLE ProjectMembers
(
Id int IDENTITY(1,1) PRIMARY KEY,
Member int,
Role int,
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Project_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2,
)

CREATE TABLE Role
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Role_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2
)

INSERT INTO Role(Name) Values('Developer')
INSERT INTO Role(Name) Values('DBA')
INSERT INTO Role(Name) Values('BA')
INSERT INTO Role(Name) Values('PM')

DROP TABLE PROJECT

CREATE TABLE Member
(
Id int IDENTITY(1,1) PRIMARY KEY,
ProjectMembers int,
UsersNo int,
Role int
)

select * from Member

INSERT INTO Member (ProjectMembers, UsersNo, Role) Values(1,1,1)
INSERT INTO Member (ProjectMembers, UsersNo, Role) Values(1,2,2)
INSERT INTO Member (ProjectMembers, UsersNo, Role) Values(1,3,3)
