USE master
GO

IF DB_ID('catcards') IS NOT NULL
BEGIN
    ALTER DATABASE catcards SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE catcards;
END

CREATE DATABASE catcards
GO

USE catcards
GO

BEGIN TRANSACTION

CREATE TABLE catcards (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	img_url varchar(256) NOT NULL,  -- image URL
	fact varchar(1000) NOT NULL, -- Cat Fact
	caption varchar(256) NOT NULL, -- User-provided caption
)

COMMIT TRANSACTION
