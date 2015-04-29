DROP TABLE Users
CREATE TABLE Users
(
UserId int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
Password nvarchar(255),
Email nvarchar(255),
Mobile nvarchar(255),
Org nvarchar(255),
Dept nvarchar(255),
Status bit,
ImageUrl nvarchar(255),
CreatedTimeStamp datetime2 NOT NULL CONSTRAINT DF_Users_CreateDate_GETDATE DEFAULT GETDATE(),
UpdatedTimeStamp datetime2 
)
TRUNCATE TABLE Users
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl) VALUES('±èÁø¼ö', '12345', 'dhammi@hanmail.net', 1, '010-1111-1234', 'JIRA', '°³¹ßÆÀ', 'http://goo.gl/MI4oSV');
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl) VALUES('±èÁø¾Æ', '12345', 'jina@hanmail.net', 1, '010-1111-1234', 'JIRA', '°³¹ßÆÀ', 'http://goo.gl/MI4oSV');
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl) VALUES('ÀÌ¼öÇö', '12345', 'suhyen@hanmail.net', 1, '010-1111-1234', 'JIRA', '°³¹ßÆÀ', 'http://goo.gl/MI4oSV');
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl) VALUES('¸íÁ¤Àº', '12345', 'mje@hanmail.net', 1, '010-1111-1234', 'JIRA', '°³¹ßÆÀ', 'http://goo.gl/MI4oSV');
SELECT * FROM Users