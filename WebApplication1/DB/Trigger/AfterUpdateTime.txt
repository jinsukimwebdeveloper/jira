CREATE TRIGGER dbo.AfterUpdateUsers ON Jira.dbo.Users
AFTER INSERT, UPDATE 
AS
BEGIN
  UPDATE dbo.Users
  SET UpdatedTimeStamp = GETDATE()
  FROM Inserted i
  WHERE dbo.Users.UserId = i.UserId AND dbo.Users.UserId = i.UserId
END

CREATE TRIGGER dbo.AfterUpdateComponent ON Jira.dbo.Component
AFTER INSERT, UPDATE 
AS
BEGIN
  UPDATE dbo.Component
  SET UpdatedTimeStamp = GETDATE()
  FROM Inserted i
  WHERE dbo.Component.Id = i.Id AND dbo.Component.Id = i.Id
END

CREATE TRIGGER dbo.AfterUpdateStatus ON Jira.dbo.Status
AFTER INSERT, UPDATE 
AS
BEGIN
  UPDATE dbo.Status
  SET UpdatedTimeStamp = GETDATE()
  FROM Inserted i
  WHERE dbo.Status.Id = i.Id AND dbo.Status.Id = i.Id
END

CREATE TRIGGER dbo.AfterUpdatePriority ON Jira.dbo.Priority
AFTER INSERT, UPDATE 
AS
BEGIN
  UPDATE dbo.Priority
  SET UpdatedTimeStamp = GETDATE()
  FROM Inserted i
  WHERE dbo.Priority.Id = i.Id AND dbo.Priority.Id = i.Id
END

CREATE TRIGGER dbo.AfterUpdateIssues ON Jira.dbo.Issues
AFTER INSERT, UPDATE 
AS
BEGIN
  UPDATE dbo.Issues
  SET UpdatedTimeStamp = GETDATE()
  FROM Inserted i
  WHERE dbo.Issues.Id = i.Id AND dbo.Issues.Id = i.Id
END

CREATE TRIGGER dbo.AfterUpdateProject ON Jira.dbo.Project
AFTER INSERT, UPDATE 
AS
BEGIN
  UPDATE dbo.Project
  SET UpdatedTimeStamp = GETDATE()
  FROM Inserted i
  WHERE dbo.Project.Id = i.Id AND dbo.Project.Id = i.Id
END


select * from sys.triggers