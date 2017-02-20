--
-- ������ ������������ Devart dbForge Studio for SQL Server, ������ 5.4.215.0
-- �������� �������� ��������: http://www.devart.com/ru/dbforge/sql/studio
-- ���� �������: 20.02.2017 2:22:22
-- ������ �������: 11.00.2100
-- ������ �������: 
--



USE Control
GO

IF DB_NAME() <> N'Control' SET NOEXEC ON
GO

--
-- ������� ������� [dbo].[Scores]
--
PRINT (N'������� ������� [dbo].[Scores]')
GO
CREATE TABLE dbo.Scores (
  PlayerId int NOT NULL,
  MatchId int NOT NULL,
  TimeMinute int NOT NULL
)
ON [PRIMARY]
GO
-- 
-- ����� ������ ��� ������� Scores
--
INSERT dbo.Scores VALUES (9, 4, 10)
INSERT dbo.Scores VALUES (15, 4, 15)
INSERT dbo.Scores VALUES (2, 4, 16)
INSERT dbo.Scores VALUES (6, 4, 25)
INSERT dbo.Scores VALUES (26, 7, 23)
INSERT dbo.Scores VALUES (31, 7, 30)
INSERT dbo.Scores VALUES (70, 7, 36)
INSERT dbo.Scores VALUES (26, 6, 24)
INSERT dbo.Scores VALUES (31, 6, 45)
INSERT dbo.Scores VALUES (17, 6, 20)
INSERT dbo.Scores VALUES (76, 6, 36)
INSERT dbo.Scores VALUES (17, 6, 40)
INSERT dbo.Scores VALUES (87, 6, 56)
INSERT dbo.Scores VALUES (89, 6, 25)
INSERT dbo.Scores VALUES (26, 6, 43)
INSERT dbo.Scores VALUES (42, 4, 23)
GO

USE Control
GO

IF DB_NAME() <> N'Control' SET NOEXEC ON
GO

--
-- ������� ������� ���� ��� ������� ���� ������� [dbo].[Scores]
--
PRINT (N'������� ������� ���� ��� ������� ���� ������� [dbo].[Scores]')
GO
ALTER TABLE dbo.Scores WITH NOCHECK
  ADD FOREIGN KEY (MatchId) REFERENCES dbo.Matches (Id)
GO

--
-- ������� ������� ���� ��� ������� ���� ������� [dbo].[Scores]
--
PRINT (N'������� ������� ���� ��� ������� ���� ������� [dbo].[Scores]')
GO
ALTER TABLE dbo.Scores WITH NOCHECK
  ADD FOREIGN KEY (PlayerId) REFERENCES dbo.Players (Id)
GO
SET NOEXEC OFF
GO