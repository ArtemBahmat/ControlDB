--
-- Скрипт сгенерирован Devart dbForge Studio for SQL Server, Версия 5.4.215.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/sql/studio
-- Дата скрипта: 20.02.2017 2:22:22
-- Версия сервера: 11.00.2100
-- Версия клиента: 
--



USE Control
GO

IF DB_NAME() <> N'Control' SET NOEXEC ON
GO

--
-- Создать таблицу [dbo].[Scores]
--
PRINT (N'Создать таблицу [dbo].[Scores]')
GO
CREATE TABLE dbo.Scores (
  PlayerId int NOT NULL,
  MatchId int NOT NULL,
  TimeMinute int NOT NULL
)
ON [PRIMARY]
GO
-- 
-- Вывод данных для таблицы Scores
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
-- Создать внешний ключ для объекта типа таблица [dbo].[Scores]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[Scores]')
GO
ALTER TABLE dbo.Scores WITH NOCHECK
  ADD FOREIGN KEY (MatchId) REFERENCES dbo.Matches (Id)
GO

--
-- Создать внешний ключ для объекта типа таблица [dbo].[Scores]
--
PRINT (N'Создать внешний ключ для объекта типа таблица [dbo].[Scores]')
GO
ALTER TABLE dbo.Scores WITH NOCHECK
  ADD FOREIGN KEY (PlayerId) REFERENCES dbo.Players (Id)
GO
SET NOEXEC OFF
GO