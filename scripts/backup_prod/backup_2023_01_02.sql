CREATE DATABASE  IF NOT EXISTS `nsps` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `nsps`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: nsps
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--
-- ORDER BY:  `MigrationId`

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20221202121430_InitialMigration','6.0.7');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accountableassetprojectstatus`
--

DROP TABLE IF EXISTS `accountableassetprojectstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accountableassetprojectstatus` (
  `AssetStatusPerAccountableId` bigint unsigned NOT NULL,
  `AssigneesId` bigint unsigned NOT NULL,
  PRIMARY KEY (`AssetStatusPerAccountableId`,`AssigneesId`),
  KEY `IX_AccountableAssetProjectStatus_AssigneesId` (`AssigneesId`),
  CONSTRAINT `FK_AccountableAssetProjectStatus_Accountables_AssigneesId` FOREIGN KEY (`AssigneesId`) REFERENCES `accountables` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AccountableAssetProjectStatus_AssetProjectStatus_AssetStatus~` FOREIGN KEY (`AssetStatusPerAccountableId`) REFERENCES `assetprojectstatus` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accountableassetprojectstatus`
--
-- ORDER BY:  `AssetStatusPerAccountableId`,`AssigneesId`

LOCK TABLES `accountableassetprojectstatus` WRITE;
/*!40000 ALTER TABLE `accountableassetprojectstatus` DISABLE KEYS */;
INSERT INTO `accountableassetprojectstatus` VALUES (9,3),(13,3);
/*!40000 ALTER TABLE `accountableassetprojectstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accountables`
--

DROP TABLE IF EXISTS `accountables`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accountables` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Code` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DisplayName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sector` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accountables`
--
-- ORDER BY:  `Id`

LOCK TABLES `accountables` WRITE;
/*!40000 ALTER TABLE `accountables` DISABLE KEYS */;
INSERT INTO `accountables` VALUES (1,'U355107','Dalton Pessoa',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-02 13:32:29.806994'),(2,'u466018','Alison Ferreira',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-02 13:34:02.448257'),(3,'u465553','Luiz Cândido',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-02 13:35:39.079919'),(4,'u466165','George Malheiros',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-02 13:36:46.626870');
/*!40000 ALTER TABLE `accountables` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accountabletaskitem`
--

DROP TABLE IF EXISTS `accountabletaskitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `accountabletaskitem` (
  `AssignedTasksId` bigint unsigned NOT NULL,
  `AssigneesId` bigint unsigned NOT NULL,
  PRIMARY KEY (`AssignedTasksId`,`AssigneesId`),
  KEY `IX_AccountableTaskItem_AssigneesId` (`AssigneesId`),
  CONSTRAINT `FK_AccountableTaskItem_Accountables_AssigneesId` FOREIGN KEY (`AssigneesId`) REFERENCES `accountables` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AccountableTaskItem_TaskItems_AssignedTasksId` FOREIGN KEY (`AssignedTasksId`) REFERENCES `taskitems` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accountabletaskitem`
--
-- ORDER BY:  `AssignedTasksId`,`AssigneesId`

LOCK TABLES `accountabletaskitem` WRITE;
/*!40000 ALTER TABLE `accountabletaskitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `accountabletaskitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applicationroles`
--

DROP TABLE IF EXISTS `applicationroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `applicationroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationroles`
--
-- ORDER BY:  `Id`

LOCK TABLES `applicationroles` WRITE;
/*!40000 ALTER TABLE `applicationroles` DISABLE KEYS */;
INSERT INTO `applicationroles` VALUES ('bc96ce98-6da2-4433-85ad-88bf228bb4bb','Usuário comum do sistema','User','USER','24debfdc-24ea-4dc3-bcdd-9d277891b447'),('ece2b104-3d0e-49ba-9ac4-969911b8cfc6','Administrador do sistema','Administrator','ADMINISTRATOR','4e45f1e8-55e5-4a07-af6f-ff14107c1724');
/*!40000 ALTER TABLE `applicationroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applicationusers`
--

DROP TABLE IF EXISTS `applicationusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `applicationusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FirstName` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Photo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsActive` tinyint(1) NOT NULL,
  `IsFirstAccess` tinyint(1) NOT NULL,
  `AccountableId` bigint unsigned NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_ApplicationUsers_AccountableId` (`AccountableId`),
  UNIQUE KEY `IX_ApplicationUsers_Code` (`Code`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  CONSTRAINT `FK_ApplicationUsers_Accountables_AccountableId` FOREIGN KEY (`AccountableId`) REFERENCES `accountables` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationusers`
--
-- ORDER BY:  `Id`

LOCK TABLES `applicationusers` WRITE;
/*!40000 ALTER TABLE `applicationusers` DISABLE KEYS */;
INSERT INTO `applicationusers` VALUES ('3545ae57-73f3-41c8-b14c-aed1fc85435b','u466165','George','Malheiros',NULL,1,0,4,'u466165','U466165','george.fonseca@neoenergia.com','GEORGE.FONSECA@NEOENERGIA.COM',0,'AQAAAAEAACcQAAAAEBeRhqt9iUL9RVxj7axKxSu0g/DT+y8x20Gnr2blRegaWptG9Iup3Brae6HfTYEdAQ==','4DZMX2RPPX4OKSHET772SQXY4CZPBUMI','ae9f08a8-1105-4949-9fff-e3245e1d4091',NULL,0,0,NULL,1,0),('53332665-eb7b-4287-b685-bb6aaa28fba3','u466018','Alison','Ferreira',NULL,1,0,2,'u466018','U466018','alison.ferreira@neoenergia.com','ALISON.FERREIRA@NEOENERGIA.COM',0,'AQAAAAEAACcQAAAAEIJ7QJakDZN42B6f/mIZ36b/W6naaxEtol5651yw0L/7MLPSRoxxlpPD3NvKMbdd+g==','V7MCJNGWTFUSWNIPIN3WOAHFEQYNFMED','ecf38dde-dcf9-4a2f-bbbd-54a4f63bfb8f',NULL,0,0,NULL,1,0),('61c73167-cf6a-4c79-a225-4de6918342ec','u465553','Luiz','Cândido',NULL,1,0,3,'u465553','U465553','luizcandido@neoenergia.com','LUIZCANDIDO@NEOENERGIA.COM',0,'AQAAAAEAACcQAAAAENM6ODC8LD2qTYp7oP/+hTk0qSnn7zz72GBN7i5N1hTWEMUT6pd5axQHBEclBC7xYw==','NVXS3YTFCACQILK345N3FD6E4NBYM65W','2e8bd5ad-5530-4262-a137-e117de04f9ed',NULL,0,0,NULL,1,0),('c377ced6-0e65-4a26-bc34-7eacc3ca9aa1','U355107','Dalton','Pessoa',NULL,1,0,1,'U355107','U355107','dalton.pessoa@neoenergia.com','DALTON.PESSOA@NEOENERGIA.COM',0,'AQAAAAEAACcQAAAAEIYRn4nS0YORigzCLOHSBYq53bEcegW1bHbeChN1hXHToaWbCVHTi0gHkAEmU5HkMg==','HOJO3ZMG5XU6IMSIDJONHVGYZGEC2OJ5','0c459818-f4ca-4140-b7ec-e4867fddfa2f',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `applicationusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_ApplicationRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `applicationroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--
-- ORDER BY:  `Id`

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `applicationusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--
-- ORDER BY:  `Id`

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `applicationusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--
-- ORDER BY:  `LoginProvider`,`ProviderKey`

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_ApplicationRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `applicationroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `applicationusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--
-- ORDER BY:  `UserId`,`RoleId`

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('3545ae57-73f3-41c8-b14c-aed1fc85435b','bc96ce98-6da2-4433-85ad-88bf228bb4bb'),('53332665-eb7b-4287-b685-bb6aaa28fba3','bc96ce98-6da2-4433-85ad-88bf228bb4bb'),('61c73167-cf6a-4c79-a225-4de6918342ec','bc96ce98-6da2-4433-85ad-88bf228bb4bb'),('c377ced6-0e65-4a26-bc34-7eacc3ca9aa1','ece2b104-3d0e-49ba-9ac4-969911b8cfc6');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_ApplicationUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `applicationusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--
-- ORDER BY:  `UserId`,`LoginProvider`,`Name`

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assetprojectstatus`
--

DROP TABLE IF EXISTS `assetprojectstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assetprojectstatus` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `StepId` int DEFAULT NULL,
  `Status` int NOT NULL,
  `StartDate` datetime(6) DEFAULT NULL,
  `DueDate` datetime(6) DEFAULT NULL,
  `AssetId` bigint unsigned NOT NULL,
  `CategoryId` int DEFAULT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_AssetProjectStatus_AssetId` (`AssetId`),
  KEY `IX_AssetProjectStatus_CategoryId` (`CategoryId`),
  KEY `IX_AssetProjectStatus_StepId` (`StepId`),
  CONSTRAINT `FK_AssetProjectStatus_Assets_AssetId` FOREIGN KEY (`AssetId`) REFERENCES `assets` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AssetProjectStatus_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`),
  CONSTRAINT `FK_AssetProjectStatus_Steps_StepId` FOREIGN KEY (`StepId`) REFERENCES `steps` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assetprojectstatus`
--
-- ORDER BY:  `Id`

LOCK TABLES `assetprojectstatus` WRITE;
/*!40000 ALTER TABLE `assetprojectstatus` DISABLE KEYS */;
INSERT INTO `assetprojectstatus` VALUES (1,6,3,NULL,NULL,1,6,'2022-12-05 10:39:46.011715','2022-12-26 15:08:02.780738','2022-12-26 18:08:02.780738'),(2,6,3,NULL,NULL,2,6,'2022-12-05 10:40:36.727640','2022-12-26 15:07:15.574835','2022-12-26 18:07:15.730836'),(3,6,3,NULL,NULL,3,6,'2022-12-05 10:41:14.479882','2022-12-26 15:07:34.482156','2022-12-26 18:07:34.482156'),(4,1,0,NULL,NULL,4,6,'2022-12-05 10:41:49.112104','2023-01-02 11:14:42.451661','2023-01-02 14:14:42.467260'),(5,NULL,0,NULL,NULL,5,NULL,'2022-12-12 08:55:09.781694',NULL,'2022-12-12 11:55:09.859694'),(6,NULL,0,NULL,NULL,6,NULL,'2022-12-12 09:07:36.667682',NULL,'2022-12-12 12:07:36.667682'),(7,NULL,0,NULL,NULL,7,NULL,'2022-12-12 09:08:20.020360',NULL,'2022-12-12 12:08:20.020360'),(8,NULL,0,NULL,NULL,8,NULL,'2022-12-12 09:09:53.636560',NULL,'2022-12-12 12:09:53.636560'),(9,5,1,NULL,NULL,9,6,'2022-12-26 16:24:47.982440','2023-01-02 08:26:08.086172','2023-01-02 11:26:08.086172'),(10,3,1,NULL,'2023-01-20 00:00:00.000000',10,6,'2022-12-26 16:26:05.811339','2023-01-02 08:34:08.787653','2023-01-02 11:34:08.787653'),(11,3,1,NULL,'2023-01-20 00:00:00.000000',11,6,'2022-12-26 16:26:30.599898','2023-01-02 08:33:06.090851','2023-01-02 11:33:06.090851'),(12,3,1,NULL,'2023-01-20 00:00:00.000000',12,6,'2022-12-26 16:26:54.858054','2023-01-02 08:32:54.468777','2023-01-02 11:32:54.468777'),(13,5,1,NULL,'2023-01-20 00:00:00.000000',13,6,'2022-12-26 16:27:46.634786','2023-01-02 08:26:01.362529','2023-01-02 11:26:01.378129'),(14,3,1,NULL,'2023-01-20 00:00:00.000000',14,7,'2022-12-26 16:45:11.030280','2023-01-02 08:16:34.330094','2023-01-02 11:16:34.330094'),(15,3,1,NULL,'2023-01-06 00:00:00.000000',15,6,'2022-12-27 13:55:02.192093','2023-01-02 08:32:42.191498','2023-01-02 11:32:42.191498'),(16,3,1,NULL,'2023-01-06 00:00:00.000000',16,6,'2022-12-27 13:55:57.260446','2023-01-02 08:32:28.011007','2023-01-02 11:32:28.011007'),(17,3,1,NULL,'2023-01-06 00:00:00.000000',17,6,'2022-12-27 13:56:34.997088','2023-01-02 08:32:15.328126','2023-01-02 11:32:15.343726'),(18,5,0,NULL,'2023-01-06 00:00:00.000000',18,6,'2022-12-27 13:57:09.691711','2023-01-02 08:19:39.971284','2023-01-02 11:19:39.971284'),(19,5,1,NULL,'2023-01-06 00:00:00.000000',19,6,'2022-12-27 13:58:25.336596','2023-01-02 08:17:09.555120','2023-01-02 11:17:09.570720'),(20,3,1,NULL,'2023-01-06 00:00:00.000000',20,6,'2022-12-27 14:00:01.480012','2023-01-02 08:31:55.672000','2023-01-02 11:31:55.672000'),(21,3,1,NULL,'2023-01-06 00:00:00.000000',21,6,'2022-12-27 14:00:26.611773','2023-01-02 08:31:41.897112','2023-01-02 11:31:41.897112'),(22,3,1,NULL,'2023-01-06 00:00:00.000000',22,6,'2022-12-27 14:00:59.247182','2023-01-02 08:30:51.087586','2023-01-02 11:30:51.087586'),(23,5,0,NULL,'2023-01-06 00:00:00.000000',23,6,'2022-12-27 14:01:57.324646','2023-01-02 08:24:51.879683','2023-01-02 11:24:51.879683'),(24,5,1,NULL,'2023-01-06 00:00:00.000000',24,6,'2022-12-27 14:02:53.040217','2023-01-02 08:17:38.368504','2023-01-02 11:17:38.384105'),(25,3,1,NULL,'2023-01-20 00:00:00.000000',25,6,'2022-12-27 14:07:12.148345','2023-01-02 08:30:12.258937','2023-01-02 11:30:12.258937'),(26,3,1,NULL,'2023-01-20 00:00:00.000000',26,6,'2022-12-27 14:07:44.846154','2023-01-02 08:29:59.654056','2023-01-02 11:29:59.654056'),(27,3,1,NULL,'2023-01-20 00:00:00.000000',27,6,'2022-12-27 14:08:17.965166','2023-01-02 08:29:48.312784','2023-01-02 11:29:48.312784'),(28,5,1,NULL,'2023-01-20 00:00:00.000000',28,6,'2022-12-27 14:08:48.931365','2023-01-02 08:26:12.001797','2023-01-02 11:26:12.001797'),(29,5,1,NULL,'2023-01-20 00:00:00.000000',29,6,'2022-12-27 14:09:16.122339','2023-01-02 08:15:00.604693','2023-01-02 11:15:00.745094'),(30,3,1,NULL,'2023-01-20 00:00:00.000000',30,6,'2022-12-27 14:09:58.258209','2023-01-02 08:29:34.491095','2023-01-02 11:29:34.491095'),(31,3,1,NULL,'2023-01-20 00:00:00.000000',31,6,'2022-12-27 14:10:18.382338','2023-01-02 08:29:15.022170','2023-01-02 11:29:15.022170'),(32,3,1,NULL,'2023-01-20 00:00:00.000000',32,6,'2022-12-27 14:10:48.069329','2023-01-02 08:29:04.039700','2023-01-02 11:29:04.039700'),(33,5,1,NULL,'2023-01-20 00:00:00.000000',33,6,'2022-12-27 14:11:09.706667','2023-01-02 08:26:48.521631','2023-01-02 11:26:48.521631'),(34,5,1,NULL,'2023-01-20 00:00:00.000000',34,6,'2022-12-27 14:11:32.217612','2023-01-02 08:17:55.341413','2023-01-02 11:17:55.341413'),(35,3,1,NULL,'2023-01-06 00:00:00.000000',35,6,'2022-12-27 14:12:37.675631','2023-01-02 08:28:50.654814','2023-01-02 11:28:50.654814'),(36,3,1,NULL,'2023-01-06 00:00:00.000000',36,6,'2022-12-27 14:13:00.342577','2023-01-02 08:28:17.801003','2023-01-02 11:28:17.801003'),(37,3,1,NULL,'2023-01-06 00:00:00.000000',37,6,'2022-12-27 14:13:22.603919','2023-01-02 08:28:05.508125','2023-01-02 11:28:05.508125'),(38,3,1,NULL,'2023-01-06 00:00:00.000000',38,6,'2022-12-27 14:13:52.805713','2023-01-02 08:35:22.466926','2023-01-02 11:35:22.466926'),(39,5,1,NULL,'2023-01-06 00:00:00.000000',39,6,'2022-12-27 14:14:08.499413','2023-01-02 08:15:56.234650','2023-01-02 11:15:56.250250'),(40,3,1,NULL,'2023-01-06 00:00:00.000000',42,6,'2022-12-27 14:31:50.518758','2023-01-02 08:27:52.887644','2023-01-02 11:27:52.887644'),(41,3,1,NULL,'2023-01-06 00:00:00.000000',43,6,'2022-12-27 14:35:57.000338','2023-01-02 08:27:39.518358','2023-01-02 11:27:39.518358'),(42,3,1,NULL,'2023-01-06 00:00:00.000000',44,6,'2022-12-27 14:37:15.936844','2023-01-02 08:27:21.531443','2023-01-02 11:27:21.531443'),(43,3,1,NULL,'2023-01-06 00:00:00.000000',45,6,'2022-12-27 14:37:51.208670','2023-01-02 08:35:06.757625','2023-01-02 11:35:06.757625'),(44,5,1,NULL,'2023-01-06 00:00:00.000000',46,6,'2022-12-27 14:38:11.129998','2023-01-02 08:19:22.904775','2023-01-02 11:19:22.920375');
/*!40000 ALTER TABLE `assetprojectstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assets`
--

DROP TABLE IF EXISTS `assets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assets` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Description` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Code` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TypeId` bigint unsigned NOT NULL,
  `ProjectId` bigint unsigned NOT NULL,
  `AttachmentsLink` varchar(384) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `TaskItemId` bigint unsigned DEFAULT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_Assets_ProjectId` (`ProjectId`),
  KEY `IX_Assets_TaskItemId` (`TaskItemId`),
  KEY `IX_Assets_TypeId` (`TypeId`),
  CONSTRAINT `FK_Assets_AssetTypes_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `assettypes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Assets_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Assets_TaskItems_TaskItemId` FOREIGN KEY (`TaskItemId`) REFERENCES `taskitems` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assets`
--
-- ORDER BY:  `Id`

LOCK TABLES `assets` WRITE;
/*!40000 ALTER TABLE `assets` DISABLE KEYS */;
INSERT INTO `assets` VALUES (1,'Disjuntor 69 kV do trafo 02T2','12T2',2,1,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BBR?csf=1&web=1&e=VqMY9t',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-05 13:39:46.105316'),(2,'Trafo de 69 kV','02T2',1,1,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BBR?csf=1&web=1&e=VqMY9t',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-05 13:40:36.727640'),(3,'Disjuntor de 13.8 kV do 02T2','11T2',3,1,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BBR?csf=1&web=1&e=VqMY9t',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-05 13:41:14.479882'),(4,'Disjuntor de banco de capacitor','11H4',3,1,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BBR?csf=1&web=1&e=VqMY9t',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 18:10:04.555118'),(5,'Chave de Saída','32F2-5',6,2,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/TDD?csf=1&web=1&e=fRm4Vd',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:55:09.844094'),(6,'Chave By-pass','32F2-6',6,2,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/TDD?csf=1&web=1&e=fRm4Vd',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-12 12:07:36.667682'),(7,'Chave de Entrada','32F2-4',6,2,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/TDD?csf=1&web=1&e=fRm4Vd',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-12 12:08:20.020360'),(8,'Disjuntor','12F2',2,2,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/TDD?csf=1&web=1&e=fRm4Vd',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-12 12:09:53.636560'),(9,'Disjuntor 69kv','12L5',2,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=T9KacN',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:24:48.122841'),(10,'Chave de entrada do disjuntor','32L5-4',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=T9KacN',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:26:05.811339'),(11,'Chave de saida do disjuntor','32L5-5',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=T9KacN',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:26:30.599898'),(12,'chave bypass do disjuntor','32L5-6',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=T9KacN',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:26:54.858054'),(13,'TC do disjuntor','72L5',5,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=T9KacN',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:27:46.634786'),(14,'Tp de linha','82L5',4,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=T9KacN',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:45:11.030280'),(15,'Chave anterior ao 12Y7','32Y7-4',6,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:03:56.852598'),(16,'Chave posterior ao 12Y7','32Y7-5',6,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:04:37.712684'),(17,'Chave bypass do 12Y7','32Y7-6',6,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:04:49.826895'),(18,'TC do 12Y7','72Y7',5,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:03:44.453358'),(19,'Disjuntor de linha','12Y7',2,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:04:22.432156'),(20,'Chave anterior ao 12J1','32J1-4',6,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:04:56.440556'),(21,'Chave posterior ao 12J1','32J1-5',6,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:05:18.044716'),(22,'Chave bypass do 12J1','32J1-6',6,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:05:24.717384'),(23,'TC do 12J1','72J1',5,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:05:09.417854'),(24,'Disjuntor de linha','12J1',2,3,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/SUB?csf=1&web=1&e=casN7W',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:02:53.042218'),(25,'Chave anterior ao 12C9','32C9-4',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:07:12.148345'),(26,'Chave posterior ao 12C9','32C9-5',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:07:44.846154'),(27,'Chave bypass ao 12C9','32C9-6',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:08:17.965166'),(28,'TC do 12C9','72C9',5,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:08:48.931365'),(29,'Disjuntor da linha','12C9',2,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:09:16.122339'),(30,'Chave anterior ao 12C8','32C8-4',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:09:58.258209'),(31,'Chave posterior ao 12C8','32C8-5',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:10:18.382338'),(32,'Chave bypass do 12C8','32C8-6',6,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:10:48.069329'),(33,'TC do 12C8','72C8',5,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:11:09.706667'),(34,'Disjuntor da linha','12C8',2,4,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/BON?csf=1&web=1&e=hGnqDn',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:11:32.217612'),(35,'Chave anterior ao 12C5','32C5-4',6,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:12:37.675631'),(36,'Chave posterior ao 12C5','32C5-5',6,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:13:00.342577'),(37,'Chave bypass do 12C5','32C5-6',6,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:13:22.603919'),(38,'TC do 12C5','72C5',5,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:13:52.805713'),(39,'Disjuntor','12C5',2,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:14:08.499413'),(42,'Chave anterior ao 12C8','32C8-4',6,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:31:50.518758'),(43,'Chave posterior ao 12C8','32C8-5',6,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:35:57.000338'),(44,'Chave bypass do 12C8','32C8-6',6,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:37:15.936844'),(45,'TC do disjuntor 12C8','72C8',5,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:37:51.208670'),(46,'Disjuntor de linha','12C8',2,5,'https://iberdrola-my.sharepoint.com/:f:/r/personal/dalton_pessoa_neoenergia_com/Documents/Comissionamento/CSF?csf=1&web=1&e=WgPhnj',NULL,'0001-01-01 00:00:00.000000',NULL,'2022-12-27 17:38:11.129998');
/*!40000 ALTER TABLE `assets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assettypes`
--

DROP TABLE IF EXISTS `assettypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assettypes` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_AssetTypes_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assettypes`
--
-- ORDER BY:  `Id`

LOCK TABLES `assettypes` WRITE;
/*!40000 ALTER TABLE `assettypes` DISABLE KEYS */;
INSERT INTO `assettypes` VALUES (1,'TF','Trafo de força 69 kV','0001-01-01 00:00:00.000000',NULL,'2022-12-05 13:34:31.123697'),(2,'DI','Disjuntor 69 kV','0001-01-01 00:00:00.000000',NULL,'2022-12-13 17:03:20.971387'),(3,'DI13','Disjuntor 13.8 kV','0001-01-01 00:00:00.000000',NULL,'2022-12-13 17:03:28.334634'),(4,'TP','transformador de potencial','0001-01-01 00:00:00.000000',NULL,'2022-12-13 17:03:47.631957'),(5,'TC','transformador de corrente','0001-01-01 00:00:00.000000',NULL,'2022-12-13 17:03:53.949998'),(6,'CH','Chave de seccionadora','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:48:59.154518');
/*!40000 ALTER TABLE `assettypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assettypestep`
--

DROP TABLE IF EXISTS `assettypestep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assettypestep` (
  `AllowedStepsId` int NOT NULL,
  `AssetTypesId` bigint unsigned NOT NULL,
  PRIMARY KEY (`AllowedStepsId`,`AssetTypesId`),
  KEY `IX_AssetTypeStep_AssetTypesId` (`AssetTypesId`),
  CONSTRAINT `FK_AssetTypeStep_AssetTypes_AssetTypesId` FOREIGN KEY (`AssetTypesId`) REFERENCES `assettypes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AssetTypeStep_Steps_AllowedStepsId` FOREIGN KEY (`AllowedStepsId`) REFERENCES `steps` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assettypestep`
--
-- ORDER BY:  `AllowedStepsId`,`AssetTypesId`

LOCK TABLES `assettypestep` WRITE;
/*!40000 ALTER TABLE `assettypestep` DISABLE KEYS */;
INSERT INTO `assettypestep` VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(4,1),(4,2),(4,3),(4,4),(4,5),(4,6),(5,1),(5,2),(5,3),(5,4),(5,5),(5,6),(6,1),(6,2),(6,3),(6,4),(6,5),(6,6),(7,1),(7,2),(7,3),(7,4),(7,5),(7,6);
/*!40000 ALTER TABLE `assettypestep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attachments`
--

DROP TABLE IF EXISTS `attachments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attachments` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Size` int NOT NULL,
  `Path` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AssetStatusId` bigint unsigned DEFAULT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_Attachments_AssetStatusId` (`AssetStatusId`),
  CONSTRAINT `FK_Attachments_AssetProjectStatus_AssetStatusId` FOREIGN KEY (`AssetStatusId`) REFERENCES `assetprojectstatus` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attachments`
--
-- ORDER BY:  `Id`

LOCK TABLES `attachments` WRITE;
/*!40000 ALTER TABLE `attachments` DISABLE KEYS */;
/*!40000 ALTER TABLE `attachments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Categories_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--
-- ORDER BY:  `Id`

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Civil','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:42.903308'),(2,'Eletromecânico','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:42.961314'),(3,'Aterramento','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:42.974315'),(4,'Projeto','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:42.992317'),(5,'Painéis','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.007318'),(6,'Equipamentos','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.018320'),(7,'Interligações','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.030321'),(8,'SPCS','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.042322');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `checklistitems`
--

DROP TABLE IF EXISTS `checklistitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `checklistitems` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` tinyint(1) NOT NULL,
  `TaskId` bigint unsigned NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_CheckListItems_TaskId` (`TaskId`),
  CONSTRAINT `FK_CheckListItems_TaskItems_TaskId` FOREIGN KEY (`TaskId`) REFERENCES `taskitems` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checklistitems`
--
-- ORDER BY:  `Id`

LOCK TABLES `checklistitems` WRITE;
/*!40000 ALTER TABLE `checklistitems` DISABLE KEYS */;
/*!40000 ALTER TABLE `checklistitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comments` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Content` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` bigint unsigned DEFAULT NULL,
  `AssetStatusId` bigint unsigned DEFAULT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_Comments_AssetStatusId` (`AssetStatusId`),
  KEY `IX_Comments_UserId` (`UserId`),
  CONSTRAINT `FK_Comments_Accountables_UserId` FOREIGN KEY (`UserId`) REFERENCES `accountables` (`Id`),
  CONSTRAINT `FK_Comments_AssetProjectStatus_AssetStatusId` FOREIGN KEY (`AssetStatusId`) REFERENCES `assetprojectstatus` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--
-- ORDER BY:  `Id`

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `labels`
--

DROP TABLE IF EXISTS `labels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `labels` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Color` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `labels`
--
-- ORDER BY:  `Id`

LOCK TABLES `labels` WRITE;
/*!40000 ALTER TABLE `labels` DISABLE KEYS */;
/*!40000 ALTER TABLE `labels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `labeltaskitem`
--

DROP TABLE IF EXISTS `labeltaskitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `labeltaskitem` (
  `LabelsId` int NOT NULL,
  `TasksId` bigint unsigned NOT NULL,
  PRIMARY KEY (`LabelsId`,`TasksId`),
  KEY `IX_LabelTaskItem_TasksId` (`TasksId`),
  CONSTRAINT `FK_LabelTaskItem_Labels_LabelsId` FOREIGN KEY (`LabelsId`) REFERENCES `labels` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_LabelTaskItem_TaskItems_TasksId` FOREIGN KEY (`TasksId`) REFERENCES `taskitems` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `labeltaskitem`
--
-- ORDER BY:  `LabelsId`,`TasksId`

LOCK TABLES `labeltaskitem` WRITE;
/*!40000 ALTER TABLE `labeltaskitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `labeltaskitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `linkedtasks`
--

DROP TABLE IF EXISTS `linkedtasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `linkedtasks` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `SubjectTaskId` bigint unsigned NOT NULL,
  `Type` int NOT NULL,
  `ObjectTaskId` bigint unsigned NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_LinkedTasks_ObjectTaskId` (`ObjectTaskId`),
  KEY `IX_LinkedTasks_SubjectTaskId` (`SubjectTaskId`),
  CONSTRAINT `FK_LinkedTasks_TaskItems_ObjectTaskId` FOREIGN KEY (`ObjectTaskId`) REFERENCES `taskitems` (`Id`),
  CONSTRAINT `FK_LinkedTasks_TaskItems_SubjectTaskId` FOREIGN KEY (`SubjectTaskId`) REFERENCES `taskitems` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `linkedtasks`
--
-- ORDER BY:  `Id`

LOCK TABLES `linkedtasks` WRITE;
/*!40000 ALTER TABLE `linkedtasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `linkedtasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logs` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Text` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AssetStatusId` bigint unsigned DEFAULT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_Logs_AssetStatusId` (`AssetStatusId`),
  CONSTRAINT `FK_Logs_AssetProjectStatus_AssetStatusId` FOREIGN KEY (`AssetStatusId`) REFERENCES `assetprojectstatus` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logs`
--
-- ORDER BY:  `Id`

LOCK TABLES `logs` WRITE;
/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Code` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--
-- ORDER BY:  `Id`

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
INSERT INTO `projects` VALUES (1,'Beberibe','BBR','0001-01-01 00:00:00.000000',NULL,'2022-12-05 13:33:01.313921'),(2,'Trindade','TDD','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:27:12.053339'),(3,'Surubim','SUB','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:27:39.166313'),(4,'Bonito','BON','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:27:49.711981'),(5,'Camocim de São Felix','CSF','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:36:44.015406'),(6,'Salgado','SGO','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:36:57.259891'),(7,'Ipubi','IPB','0001-01-01 00:00:00.000000',NULL,'2022-12-12 11:39:28.284459');
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `steps`
--

DROP TABLE IF EXISTS `steps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `steps` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Steps_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `steps`
--
-- ORDER BY:  `Id`

LOCK TABLES `steps` WRITE;
/*!40000 ALTER TABLE `steps` DISABLE KEYS */;
INSERT INTO `steps` VALUES (1,'Planejamento','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.054323'),(2,'Inspeção','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.068325'),(3,'TAC Equip. Interlig.','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.090327'),(4,'TAF SPCS','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.108329'),(5,'TAC SPCS','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.120330'),(6,'Energização','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.133331'),(7,'SAP','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.146332');
/*!40000 ALTER TABLE `steps` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `taskitems`
--

DROP TABLE IF EXISTS `taskitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `taskitems` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `ProjectId` bigint unsigned NOT NULL,
  `Title` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SapNoteNumber` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CategoryId` int NOT NULL,
  `Priority` int DEFAULT NULL,
  `Description` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `TypeId` bigint unsigned NOT NULL,
  `Status` int NOT NULL,
  `StepId` int NOT NULL,
  `ParentTaskId` bigint unsigned DEFAULT NULL,
  `StartDate` datetime(6) DEFAULT NULL,
  `DueDate` datetime(6) DEFAULT NULL,
  `PlannedDate` datetime(6) DEFAULT NULL,
  `CompletedDate` datetime(6) DEFAULT NULL,
  `ReporterId` bigint unsigned DEFAULT NULL,
  `Order` int NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  KEY `IX_TaskItems_CategoryId` (`CategoryId`),
  KEY `IX_TaskItems_ParentTaskId` (`ParentTaskId`),
  KEY `IX_TaskItems_ProjectId` (`ProjectId`),
  KEY `IX_TaskItems_ReporterId` (`ReporterId`),
  KEY `IX_TaskItems_StepId` (`StepId`),
  KEY `IX_TaskItems_TypeId` (`TypeId`),
  CONSTRAINT `FK_TaskItems_Accountables_ReporterId` FOREIGN KEY (`ReporterId`) REFERENCES `accountables` (`Id`),
  CONSTRAINT `FK_TaskItems_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TaskItems_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `projects` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TaskItems_Steps_StepId` FOREIGN KEY (`StepId`) REFERENCES `steps` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TaskItems_TaskItems_ParentTaskId` FOREIGN KEY (`ParentTaskId`) REFERENCES `taskitems` (`Id`),
  CONSTRAINT `FK_TaskItems_Types_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `types` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `taskitems`
--
-- ORDER BY:  `Id`

LOCK TABLES `taskitems` WRITE;
/*!40000 ALTER TABLE `taskitems` DISABLE KEYS */;
INSERT INTO `taskitems` VALUES (1,2,'Falta placa de identificação dos equipamentos',NULL,6,NULL,'Pendências de placa de identificação dos equipamentos, disjunção, transferencia, aterramento e os cadeados das chaves 4/5/6/7 e identificação de IEDs 12P4_12F2 nos painéis internos',3,1,3,NULL,NULL,NULL,NULL,NULL,NULL,0,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 18:50:13.231541'),(2,4,'Falta anilha de identificação no IED 12L5',NULL,5,NULL,'Falta colocar Anilha de identificação no IED 12L5. Anilhas encontram-se confeccionadas dentro do QADP. Foi certificado o ponto a ponto pela TAG e veia dos cabos, operacionalmente. Ficou alinhado para serem finalizados durante o comiss. do 12C8 e 12C9',3,0,5,NULL,NULL,NULL,NULL,NULL,NULL,0,'0001-01-01 00:00:00.000000',NULL,'2022-12-26 19:44:02.171439');
/*!40000 ALTER TABLE `taskitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `types`
--

DROP TABLE IF EXISTS `types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `types` (
  `Id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `RowVersion` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Types_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `types`
--
-- ORDER BY:  `Id`

LOCK TABLES `types` WRITE;
/*!40000 ALTER TABLE `types` DISABLE KEYS */;
INSERT INTO `types` VALUES (1,'Informativo','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.165334'),(2,'Acompanhamento','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.237341'),(3,'Pendência não impeditiva','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.258344'),(4,'Pendência impeditiva','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.270345'),(5,'Não conformidade','2022-12-02 09:14:30.000000',NULL,'2022-12-02 13:24:43.281346');
/*!40000 ALTER TABLE `types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'nsps'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-02 11:38:36
