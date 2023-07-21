Insert Into EntireMissionsDB 
(Name, Description, State, DeadLine, CreationDate, RealFinishingDate, Difficulty, Priority)
Values (N'собрать чемодан', N'продумать что взять, чего не хватает куить', 1, '2024-08-17 00:00:00.000', '2023-07-17 00:00:00.000', NULL , 1, 2)
--update EntireMissionsDB set Description = N'понять что хочу от программы' where Id = 2   
--update EntireMissionsDB set State = 0 where State = 1