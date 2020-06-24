USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [cfeUser]    Script Date: 22/6/2020 19:43:41 ******/
CREATE LOGIN [cfeUser] WITH PASSWORD=N'MC3NeHqxdh/AHXvm+PeVdDBROyvGNZcxFs/tjh/i3po=', DEFAULT_DATABASE=[bdcfe], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [cfeUser] DISABLE
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [cfeUser]
GO