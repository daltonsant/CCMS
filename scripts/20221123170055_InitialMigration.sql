CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Accountables` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Code` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `DisplayName` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
    `Sector` varchar(128) CHARACTER SET utf8mb4 NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Accountables` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ApplicationRoles` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_ApplicationRoles` PRIMARY KEY (`Id`)
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

CREATE TABLE `Categories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Categories` PRIMARY KEY (`Id`)
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

CREATE TABLE `Steps` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Steps` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Types` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Types` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ApplicationUsers` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Code` varchar(12) CHARACTER SET utf8mb4 NOT NULL,
    `FirstName` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    `LastName` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
    `Photo` longtext CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NOT NULL,
    `IsFirstAccess` tinyint(1) NOT NULL,
    `AccountableId` bigint unsigned NOT NULL,
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
    CONSTRAINT `PK_ApplicationUsers` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ApplicationUsers_Accountables_AccountableId` FOREIGN KEY (`AccountableId`) REFERENCES `Accountables` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_ApplicationRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `ApplicationRoles` (`Id`) ON DELETE CASCADE
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
    `ReporterId` bigint unsigned NULL,
    `Order` int NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_TaskItems` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TaskItems_Accountables_ReporterId` FOREIGN KEY (`ReporterId`) REFERENCES `Accountables` (`Id`),
    CONSTRAINT `FK_TaskItems_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TaskItems_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TaskItems_Steps_StepId` FOREIGN KEY (`StepId`) REFERENCES `Steps` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TaskItems_TaskItems_ParentTaskId` FOREIGN KEY (`ParentTaskId`) REFERENCES `TaskItems` (`Id`),
    CONSTRAINT `FK_TaskItems_Types_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `Types` (`Id`) ON DELETE CASCADE
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

CREATE TABLE `AssetProject` (
    `AssetsId` bigint unsigned NOT NULL,
    `ProjectsId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_AssetProject` PRIMARY KEY (`AssetsId`, `ProjectsId`),
    CONSTRAINT `FK_AssetProject_Assets_AssetsId` FOREIGN KEY (`AssetsId`) REFERENCES `Assets` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AssetProject_Projects_ProjectsId` FOREIGN KEY (`ProjectsId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AssetProjectStatus` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `StepId` int NOT NULL,
    `Status` int NOT NULL,
    `StartDate` datetime(6) NULL,
    `DueDate` datetime(6) NULL,
    `AssetId` bigint unsigned NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_AssetProjectStatus` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AssetProjectStatus_Assets_AssetId` FOREIGN KEY (`AssetId`) REFERENCES `Assets` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AssetProjectStatus_Steps_StepId` FOREIGN KEY (`StepId`) REFERENCES `Steps` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AccountableTaskItem` (
    `AssignedTasksId` bigint unsigned NOT NULL,
    `AssigneesId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_AccountableTaskItem` PRIMARY KEY (`AssignedTasksId`, `AssigneesId`),
    CONSTRAINT `FK_AccountableTaskItem_Accountables_AssigneesId` FOREIGN KEY (`AssigneesId`) REFERENCES `Accountables` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AccountableTaskItem_TaskItems_AssignedTasksId` FOREIGN KEY (`AssignedTasksId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `AssetTaskItem` (
    `AssetsId` bigint unsigned NOT NULL,
    `TasksId` bigint unsigned NOT NULL,
    CONSTRAINT `PK_AssetTaskItem` PRIMARY KEY (`AssetsId`, `TasksId`),
    CONSTRAINT `FK_AssetTaskItem_Assets_AssetsId` FOREIGN KEY (`AssetsId`) REFERENCES `Assets` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AssetTaskItem_TaskItems_TasksId` FOREIGN KEY (`TasksId`) REFERENCES `TaskItems` (`Id`) ON DELETE CASCADE
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

CREATE TABLE `Attachments` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Size` int NOT NULL,
    `Path` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `AssetStatusId` bigint unsigned NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Attachments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Attachments_AssetProjectStatus_AssetStatusId` FOREIGN KEY (`AssetStatusId`) REFERENCES `AssetProjectStatus` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Comments` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Content` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NULL,
    `AssetStatusId` bigint unsigned NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Comments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Comments_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `ApplicationUsers` (`Id`),
    CONSTRAINT `FK_Comments_AssetProjectStatus_AssetStatusId` FOREIGN KEY (`AssetStatusId`) REFERENCES `AssetProjectStatus` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Logs` (
    `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
    `Text` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `AssetStatusId` bigint unsigned NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Logs` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Logs_AssetProjectStatus_AssetStatusId` FOREIGN KEY (`AssetStatusId`) REFERENCES `AssetProjectStatus` (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('b97c49d6-8186-4129-a7cd-92d88df5eea0', 'c48c74fd-c2ab-4811-a888-6ad40195c229', 'Administrador do sistema', 'Administrator', 'ADMINISTRATOR');
INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('d9beec0c-0596-4ce1-8157-93934530e91c', '02c65148-083a-4fc7-8c7f-2967f11bd77f', 'Usuário comum do sistema', 'User', 'USER');

INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-11-23 14:00:54', 'Civil', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-11-23 14:00:54', 'Eletromecânico', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-11-23 14:00:54', 'Aterramento', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-11-23 14:00:54', 'Projeto', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-11-23 14:00:54', 'Painéis', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (6, TIMESTAMP '2022-11-23 14:00:54', 'Equipamentos', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (7, TIMESTAMP '2022-11-23 14:00:54', 'Interligações', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (8, TIMESTAMP '2022-11-23 14:00:54', 'SPCS', NULL);

INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-11-23 14:00:54', 'Planejamento', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-11-23 14:00:54', 'TAC Equip. Interlig.', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-11-23 14:00:54', 'TAF SPCS', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-11-23 14:00:54', 'TAC SPCS', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-11-23 14:00:54', 'Energização', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (6, TIMESTAMP '2022-11-23 14:00:54', 'SAP', NULL);

INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-11-23 14:00:54', 'Informativo', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-11-23 14:00:54', 'Acompanhamento', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-11-23 14:00:54', 'Pendência não impeditiva', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-11-23 14:00:54', 'Pendência impeditiva', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-11-23 14:00:54', 'Não conformidade', NULL);

CREATE INDEX `IX_AccountableTaskItem_AssigneesId` ON `AccountableTaskItem` (`AssigneesId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `ApplicationRoles` (`NormalizedName`);

CREATE INDEX `EmailIndex` ON `ApplicationUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `IX_ApplicationUsers_AccountableId` ON `ApplicationUsers` (`AccountableId`);

CREATE UNIQUE INDEX `IX_ApplicationUsers_Code` ON `ApplicationUsers` (`Code`);

CREATE UNIQUE INDEX `UserNameIndex` ON `ApplicationUsers` (`NormalizedUserName`);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `IX_AssetProject_ProjectsId` ON `AssetProject` (`ProjectsId`);

CREATE UNIQUE INDEX `IX_AssetProjectStatus_AssetId` ON `AssetProjectStatus` (`AssetId`);

CREATE INDEX `IX_AssetProjectStatus_StepId` ON `AssetProjectStatus` (`StepId`);

CREATE UNIQUE INDEX `IX_Assets_Code` ON `Assets` (`Code`);

CREATE INDEX `IX_Assets_TypeId` ON `Assets` (`TypeId`);

CREATE INDEX `IX_AssetTaskItem_TasksId` ON `AssetTaskItem` (`TasksId`);

CREATE UNIQUE INDEX `IX_AssetTypes_Name` ON `AssetTypes` (`Name`);

CREATE INDEX `IX_Attachments_AssetStatusId` ON `Attachments` (`AssetStatusId`);

CREATE UNIQUE INDEX `IX_Categories_Name` ON `Categories` (`Name`);

CREATE INDEX `IX_CheckListItems_TaskId` ON `CheckListItems` (`TaskId`);

CREATE INDEX `IX_Comments_AssetStatusId` ON `Comments` (`AssetStatusId`);

CREATE INDEX `IX_Comments_UserId` ON `Comments` (`UserId`);

CREATE INDEX `IX_LabelTaskItem_TasksId` ON `LabelTaskItem` (`TasksId`);

CREATE INDEX `IX_LinkedTasks_ObjectTaskId` ON `LinkedTasks` (`ObjectTaskId`);

CREATE INDEX `IX_LinkedTasks_SubjectTaskId` ON `LinkedTasks` (`SubjectTaskId`);

CREATE INDEX `IX_Logs_AssetStatusId` ON `Logs` (`AssetStatusId`);

CREATE UNIQUE INDEX `IX_Steps_Name` ON `Steps` (`Name`);

CREATE INDEX `IX_TaskItems_CategoryId` ON `TaskItems` (`CategoryId`);

CREATE INDEX `IX_TaskItems_ParentTaskId` ON `TaskItems` (`ParentTaskId`);

CREATE INDEX `IX_TaskItems_ProjectId` ON `TaskItems` (`ProjectId`);

CREATE INDEX `IX_TaskItems_ReporterId` ON `TaskItems` (`ReporterId`);

CREATE INDEX `IX_TaskItems_StepId` ON `TaskItems` (`StepId`);

CREATE INDEX `IX_TaskItems_TypeId` ON `TaskItems` (`TypeId`);

CREATE UNIQUE INDEX `IX_Types_Name` ON `Types` (`Name`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221123170055_InitialMigration', '6.0.7');

COMMIT;

