CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `ApplicationRoles` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_ApplicationRoles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ApplicationUsers` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Code` varchar(12) CHARACTER SET utf8mb4 NOT NULL,
    `FirstName` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `LastName` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `Photo` longtext CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `IsFirstAccess` tinyint(1) NOT NULL,
    `UserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `PasswordHash` longtext CHARACTER SET utf8mb4 NULL,
    `SecurityStamp` longtext CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumberConfirmed` tinyint(1) NOT NULL,
    `TwoFactorEnabled` tinyint(1) NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` tinyint(1) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    CONSTRAINT `PK_ApplicationUsers` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AssetTypes` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_AssetTypes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Labels` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(16) CHARACTER SET utf8mb4 NOT NULL,
    `Color` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Labels` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Projects` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Name` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `Code` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Projects` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TaskCategories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_TaskCategories` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TaskSteps` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_TaskSteps` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TaskTypes` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_TaskTypes` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_ApplicationRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `ApplicationRoles` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderKey` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_ApplicationRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `ApplicationRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LoginProvider` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `Value` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Assets` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Description` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `Code` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `TypeId` bigint unsigned NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Assets` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Assets_AssetTypes_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `AssetTypes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `TaskItems` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `ProjectId` bigint unsigned NOT NULL,
    `Title` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `SapNoteNumber` varchar(128) CHARACTER SET utf8mb4 NULL,
    `CategoryId` int NOT NULL,
    `Priority` int NULL,
    `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
    `TypeId` bigint unsigned NOT NULL,
    `Status` int NOT NULL,
    `StepId` int NOT NULL,
    `ParentTaskId` bigint unsigned NULL,
    `StartDate` datetime(6) NULL,
    `DueDate` datetime(6) NULL,
    `PlannedDate` datetime(6) NULL,
    `CompletedDate` datetime(6) NULL,
    `ReporterId` varchar(255) CHARACTER SET utf8mb4 NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_TaskItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TaskItems_ApplicationUsers_ReporterId` FOREIGN KEY (`ReporterId`) REFERENCES `ApplicationUsers` (`Id`),
    CONSTRAINT `FK_TaskItems_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TaskItems_TaskCategories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `TaskCategories` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TaskItems_TaskItems_ParentTaskId` FOREIGN KEY (`ParentTaskId`) REFERENCES `TaskItems` (`Id`),
    CONSTRAINT `FK_TaskItems_TaskSteps_StepId` FOREIGN KEY (`StepId`) REFERENCES `TaskSteps` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TaskItems_TaskTypes_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `TaskTypes` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AssetProject` (
    `AssetsId` bigint unsigned NOT NULL,
    `ProjectsId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_AssetProject` PRIMARY KEY (`AssetsId`, `ProjectsId`),
    CONSTRAINT `FK_AssetProject_Assets_AssetsId` FOREIGN KEY (`AssetsId`) REFERENCES `Assets` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AssetProject_Projects_ProjectsId` FOREIGN KEY (`ProjectsId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `ApplicationUserTaskItem` (
    `AssignedTasksId` bigint unsigned NOT NULL,
    `AssigneesId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_ApplicationUserTaskItem` PRIMARY KEY (`AssignedTasksId`, `AssigneesId`),
    CONSTRAINT `FK_ApplicationUserTaskItem_ApplicationUsers_AssigneesId` FOREIGN KEY (`AssigneesId`) REFERENCES `ApplicationUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ApplicationUserTaskItem_TaskItems_AssignedTasksId` FOREIGN KEY (`AssignedTasksId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AssetTaskItem` (
    `AssetsId` bigint unsigned NOT NULL,
    `TasksId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_AssetTaskItem` PRIMARY KEY (`AssetsId`, `TasksId`),
    CONSTRAINT `FK_AssetTaskItem_Assets_AssetsId` FOREIGN KEY (`AssetsId`) REFERENCES `Assets` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AssetTaskItem_TaskItems_TasksId` FOREIGN KEY (`TasksId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Attachments` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Size` int NOT NULL,
    `Path` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `TaskId` bigint unsigned NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Attachments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Attachments_TaskItems_TaskId` FOREIGN KEY (`TaskId`) REFERENCES `TaskItems` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `CheckListItems` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Name` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `Value` tinyint(1) NOT NULL,
    `TaskId` bigint unsigned NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_CheckListItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_CheckListItems_TaskItems_TaskId` FOREIGN KEY (`TaskId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Comments` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Content` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NULL,
    `TaskId` bigint unsigned NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Comments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Comments_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`),
    CONSTRAINT `FK_Comments_TaskItems_TaskId` FOREIGN KEY (`TaskId`) REFERENCES `TaskItems` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `LabelTaskItem` (
    `LabelsId` int NOT NULL,
    `TasksId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_LabelTaskItem` PRIMARY KEY (`LabelsId`, `TasksId`),
    CONSTRAINT `FK_LabelTaskItem_Labels_LabelsId` FOREIGN KEY (`LabelsId`) REFERENCES `Labels` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_LabelTaskItem_TaskItems_TasksId` FOREIGN KEY (`TasksId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `LinkedTasks` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `SubjectTaskId` bigint unsigned NOT NULL,
    `Type` int NOT NULL,
    `ObjectTaskId` bigint unsigned NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_LinkedTasks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_LinkedTasks_TaskItems_ObjectTaskId` FOREIGN KEY (`ObjectTaskId`) REFERENCES `TaskItems` (`Id`),
    CONSTRAINT `FK_LinkedTasks_TaskItems_SubjectTaskId` FOREIGN KEY (`SubjectTaskId`) REFERENCES `TaskItems` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TaskLogs` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Log` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NULL,
    `TaskId` bigint unsigned NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_TaskLogs` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TaskLogs_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`),
    CONSTRAINT `FK_TaskLogs_TaskItems_TaskId` FOREIGN KEY (`TaskId`) REFERENCES `TaskItems` (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('9641e920-d9fb-46ca-8a80-609c95e93fae', '23e614ba-cb92-4c24-a2d8-6ea572fd6ba9', 'Administrador do sistema', 'Administrator', 'ADMINISTRATOR');
INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('a23a5bc0-27e4-40a3-8bb3-01ee83fee45b', 'f334fbc6-2efb-4caf-8138-251740eb9cef', 'Usuário comum do sistema', 'User', 'USER');

INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-08-26 16:28:20', 'Civil', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-08-26 16:28:20', 'Eletromecânico', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-08-26 16:28:20', 'Aterramento', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-08-26 16:28:20', 'Projeto', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-08-26 16:28:20', 'Painéis', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (6, TIMESTAMP '2022-08-26 16:28:20', 'Equipamentos', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (7, TIMESTAMP '2022-08-26 16:28:20', 'Interligações', NULL);
INSERT INTO `TaskCategories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (8, TIMESTAMP '2022-08-26 16:28:20', 'SPCS', NULL);

INSERT INTO `TaskSteps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-08-26 16:28:20', 'Planejamento', NULL);
INSERT INTO `TaskSteps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-08-26 16:28:20', 'TAC Equip. Interlig.', NULL);
INSERT INTO `TaskSteps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-08-26 16:28:20', 'TAF SPCS', NULL);
INSERT INTO `TaskSteps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-08-26 16:28:20', 'TAC SPCS', NULL);
INSERT INTO `TaskSteps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-08-26 16:28:20', 'Energização', NULL);
INSERT INTO `TaskSteps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (6, TIMESTAMP '2022-08-26 16:28:20', 'SAP', NULL);

INSERT INTO `TaskTypes` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-08-26 16:28:20', 'Informativo', NULL);
INSERT INTO `TaskTypes` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-08-26 16:28:20', 'Acompanhamento', NULL);
INSERT INTO `TaskTypes` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-08-26 16:28:20', 'Pendência não impeditiva', NULL);
INSERT INTO `TaskTypes` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-08-26 16:28:20', 'Pendência impeditiva', NULL);
INSERT INTO `TaskTypes` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-08-26 16:28:20', 'Não conformidade', NULL);

CREATE UNIQUE INDEX `RoleNameIndex` ON `ApplicationRoles` (`NormalizedName`);

CREATE INDEX `EmailIndex` ON `ApplicationUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `IX_ApplicationUsers_Code` ON `ApplicationUsers` (`Code`);

CREATE UNIQUE INDEX `UserNameIndex` ON `ApplicationUsers` (`NormalizedUserName`);

CREATE INDEX `IX_ApplicationUserTaskItem_AssigneesId` ON `ApplicationUserTaskItem` (`AssigneesId`);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `IX_AssetProject_ProjectsId` ON `AssetProject` (`ProjectsId`);

CREATE UNIQUE INDEX `IX_Assets_Code` ON `Assets` (`Code`);

CREATE INDEX `IX_Assets_TypeId` ON `Assets` (`TypeId`);

CREATE INDEX `IX_AssetTaskItem_TasksId` ON `AssetTaskItem` (`TasksId`);

CREATE UNIQUE INDEX `IX_AssetTypes_Name` ON `AssetTypes` (`Name`);

CREATE INDEX `IX_Attachments_TaskId` ON `Attachments` (`TaskId`);

CREATE INDEX `IX_CheckListItems_TaskId` ON `CheckListItems` (`TaskId`);

CREATE INDEX `IX_Comments_TaskId` ON `Comments` (`TaskId`);

CREATE INDEX `IX_Comments_UserId` ON `Comments` (`UserId`);

CREATE INDEX `IX_LabelTaskItem_TasksId` ON `LabelTaskItem` (`TasksId`);

CREATE INDEX `IX_LinkedTasks_ObjectTaskId` ON `LinkedTasks` (`ObjectTaskId`);

CREATE INDEX `IX_LinkedTasks_SubjectTaskId` ON `LinkedTasks` (`SubjectTaskId`);

CREATE UNIQUE INDEX `IX_TaskCategories_Name` ON `TaskCategories` (`Name`);

CREATE INDEX `IX_TaskItems_CategoryId` ON `TaskItems` (`CategoryId`);

CREATE INDEX `IX_TaskItems_ParentTaskId` ON `TaskItems` (`ParentTaskId`);

CREATE INDEX `IX_TaskItems_ProjectId` ON `TaskItems` (`ProjectId`);

CREATE INDEX `IX_TaskItems_ReporterId` ON `TaskItems` (`ReporterId`);

CREATE INDEX `IX_TaskItems_StepId` ON `TaskItems` (`StepId`);

CREATE INDEX `IX_TaskItems_TypeId` ON `TaskItems` (`TypeId`);

CREATE INDEX `IX_TaskLogs_TaskId` ON `TaskLogs` (`TaskId`);

CREATE INDEX `IX_TaskLogs_UserId` ON `TaskLogs` (`UserId`);

CREATE UNIQUE INDEX `IX_TaskSteps_Name` ON `TaskSteps` (`Name`);

CREATE UNIQUE INDEX `IX_TaskTypes_Name` ON `TaskTypes` (`Name`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220826192820_Initial', '6.0.7');

COMMIT;

START TRANSACTION;

DELETE FROM `ApplicationRoles`
WHERE `Id` = '9641e920-d9fb-46ca-8a80-609c95e93fae';
SELECT ROW_COUNT();


DELETE FROM `ApplicationRoles`
WHERE `Id` = 'a23a5bc0-27e4-40a3-8bb3-01ee83fee45b';
SELECT ROW_COUNT();


ALTER TABLE `TaskItems` ADD `Order` int NOT NULL DEFAULT 0;

INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('066766ef-a5ea-40ee-997a-22e7328c668c', '2e2f6529-165b-4ebf-bf72-02cbace794d5', 'Administrador do sistema', 'Administrator', 'ADMINISTRATOR');
INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('8f04e1da-bd81-444a-b8f3-8b1711fc11b0', '4225326f-7730-42ea-bc0c-6c55149d06c5', 'Usuário comum do sistema', 'User', 'USER');

UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 5;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 6;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 7;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 8;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 5;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 6;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-09-01 13:33:05'
WHERE `Id` = 5;
SELECT ROW_COUNT();


INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220901163305_AddOrderToTasks', '6.0.7');

COMMIT;

START TRANSACTION;

ALTER TABLE `TaskItems` DROP FOREIGN KEY `FK_TaskItems_ApplicationUsers_ReporterId`;

DROP TABLE `ApplicationUserTaskItem`;

DELETE FROM `ApplicationRoles`
WHERE `Id` = '066766ef-a5ea-40ee-997a-22e7328c668c';
SELECT ROW_COUNT();


DELETE FROM `ApplicationRoles`
WHERE `Id` = '8f04e1da-bd81-444a-b8f3-8b1711fc11b0';
SELECT ROW_COUNT();


ALTER TABLE `TaskItems` MODIFY COLUMN `ReporterId` bigint unsigned NULL;

ALTER TABLE `ApplicationUsers` ADD `AccountableId` bigint unsigned NOT NULL DEFAULT 0;

CREATE TABLE `Accountables` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Code` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `DisplayName` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `Sector` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Accountables` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `AccountableTaskItem` (
    `AssignedTasksId` bigint unsigned NOT NULL,
    `AssigneesId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_AccountableTaskItem` PRIMARY KEY (`AssignedTasksId`, `AssigneesId`),
    CONSTRAINT `FK_AccountableTaskItem_Accountables_AssigneesId` FOREIGN KEY (`AssigneesId`) REFERENCES `Accountables` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AccountableTaskItem_TaskItems_AssignedTasksId` FOREIGN KEY (`AssignedTasksId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('c269eb03-6a0c-4863-8690-81fd0ef2b88f', 'dea3c12e-caed-4f5c-ac10-4fcb32ba0b3f', 'Usuário comum do sistema', 'User', 'USER');
INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('cc33265f-0881-4687-a05e-ce8adea09b0d', '74f4f201-07a2-4d72-9351-a7b843a5cb2f', 'Administrador do sistema', 'Administrator', 'ADMINISTRATOR');

UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 5;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 6;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 7;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 8;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 5;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 6;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:08:31'
WHERE `Id` = 5;
SELECT ROW_COUNT();


CREATE UNIQUE INDEX `IX_ApplicationUsers_AccountableId` ON `ApplicationUsers` (`AccountableId`);

CREATE INDEX `IX_AccountableTaskItem_AssigneesId` ON `AccountableTaskItem` (`AssigneesId`);

ALTER TABLE `ApplicationUsers` ADD CONSTRAINT `FK_ApplicationUsers_Accountables_AccountableId` FOREIGN KEY (`AccountableId`) REFERENCES `Accountables` (`Id`) ON DELETE CASCADE;

ALTER TABLE `TaskItems` ADD CONSTRAINT `FK_TaskItems_Accountables_ReporterId` FOREIGN KEY (`ReporterId`) REFERENCES `Accountables` (`Id`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221122140832_AccountableChange', '6.0.7');

COMMIT;

START TRANSACTION;

DELETE FROM `ApplicationRoles`
WHERE `Id` = 'c269eb03-6a0c-4863-8690-81fd0ef2b88f';
SELECT ROW_COUNT();


DELETE FROM `ApplicationRoles`
WHERE `Id` = 'cc33265f-0881-4687-a05e-ce8adea09b0d';
SELECT ROW_COUNT();


ALTER TABLE `Accountables` MODIFY COLUMN `Sector` varchar(128) CHARACTER SET utf8mb4 NULL;

INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('cc4ab119-be38-4eab-94eb-5fbbcab6bbb5', '94ce2696-e958-455b-9e06-b0a5285e715d', 'Administrador do sistema', 'Administrator', 'ADMINISTRATOR');
INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('e52bcf97-e128-4209-b662-d5675b214836', 'ee30eee7-6f72-47ea-b952-642e3150fd24', 'Usuário comum do sistema', 'User', 'USER');

UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 5;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 6;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 7;
SELECT ROW_COUNT();


UPDATE `TaskCategories` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 8;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 5;
SELECT ROW_COUNT();


UPDATE `TaskSteps` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 6;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 1;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 2;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 3;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 4;
SELECT ROW_COUNT();


UPDATE `TaskTypes` SET `CreateDate` = TIMESTAMP '2022-11-22 11:37:12'
WHERE `Id` = 5;
SELECT ROW_COUNT();


INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221122143712_AccountableChange2', '6.0.7');

COMMIT;

