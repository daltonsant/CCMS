START TRANSACTION;

ALTER TABLE `TaskItems` DROP FOREIGN KEY `FK_TaskItems_TaskCategories_CategoryId`;

ALTER TABLE `TaskItems` DROP FOREIGN KEY `FK_TaskItems_TaskSteps_StepId`;

ALTER TABLE `TaskItems` DROP FOREIGN KEY `FK_TaskItems_TaskTypes_TypeId`;

DROP TABLE `TaskCategories`;

DROP TABLE `TaskSteps`;

DROP TABLE `TaskTypes`;

DELETE FROM `ApplicationRoles`
WHERE `Id` = 'cc4ab119-be38-4eab-94eb-5fbbcab6bbb5';
SELECT ROW_COUNT();


DELETE FROM `ApplicationRoles`
WHERE `Id` = 'e52bcf97-e128-4209-b662-d5675b214836';
SELECT ROW_COUNT();


CREATE TABLE `Categories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    CONSTRAINT `PK_Categories` PRIMARY KEY (`Id`)
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

INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('2f892af8-b3dc-4160-b348-0f9e07b35c60', '0bd20131-9282-4e5c-85e9-83c78660b4bf', 'Usuário comum do sistema', 'User', 'USER');
INSERT INTO `ApplicationRoles` (`Id`, `ConcurrencyStamp`, `Description`, `Name`, `NormalizedName`)
VALUES ('c844e220-6e6e-4b70-b0fe-4eb3e96e45cc', '992ae190-9caf-4008-8d3e-62281c629a1d', 'Administrador do sistema', 'Administrator', 'ADMINISTRATOR');

INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-11-22 17:38:16', 'Civil', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-11-22 17:38:16', 'Eletromecânico', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-11-22 17:38:16', 'Aterramento', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-11-22 17:38:16', 'Projeto', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-11-22 17:38:16', 'Painéis', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (6, TIMESTAMP '2022-11-22 17:38:16', 'Equipamentos', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (7, TIMESTAMP '2022-11-22 17:38:16', 'Interligações', NULL);
INSERT INTO `Categories` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (8, TIMESTAMP '2022-11-22 17:38:16', 'SPCS', NULL);

INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-11-22 17:38:16', 'Planejamento', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-11-22 17:38:16', 'TAC Equip. Interlig.', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-11-22 17:38:16', 'TAF SPCS', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-11-22 17:38:16', 'TAC SPCS', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-11-22 17:38:16', 'Energização', NULL);
INSERT INTO `Steps` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (6, TIMESTAMP '2022-11-22 17:38:16', 'SAP', NULL);

INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (1, TIMESTAMP '2022-11-22 17:38:16', 'Informativo', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (2, TIMESTAMP '2022-11-22 17:38:16', 'Acompanhamento', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (3, TIMESTAMP '2022-11-22 17:38:16', 'Pendência não impeditiva', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (4, TIMESTAMP '2022-11-22 17:38:16', 'Pendência impeditiva', NULL);
INSERT INTO `Types` (`Id`, `CreateDate`, `Name`, `UpdateDate`)
VALUES (5, TIMESTAMP '2022-11-22 17:38:16', 'Não conformidade', NULL);

CREATE UNIQUE INDEX `IX_Categories_Name` ON `Categories` (`Name`);

CREATE UNIQUE INDEX `IX_Steps_Name` ON `Steps` (`Name`);

CREATE UNIQUE INDEX `IX_Types_Name` ON `Types` (`Name`);

ALTER TABLE `TaskItems` ADD CONSTRAINT `FK_TaskItems_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE;

ALTER TABLE `TaskItems` ADD CONSTRAINT `FK_TaskItems_Steps_StepId` FOREIGN KEY (`StepId`) REFERENCES `Steps` (`Id`) ON DELETE CASCADE;

ALTER TABLE `TaskItems` ADD CONSTRAINT `FK_TaskItems_Types_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `Types` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20221122203817_RefactorTasksAndPendencies_v1', '6.0.7');

COMMIT;

