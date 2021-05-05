CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "JobApplication" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_JobApplication" PRIMARY KEY AUTOINCREMENT,
    "JobApplicationRef" TEXT NULL,
    "Title" TEXT NULL,
    "Description" TEXT NULL,
    "DateApplied" TEXT NOT NULL,
    "Outcome" INTEGER NOT NULL
);

CREATE TABLE "SoftwareProject" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_SoftwareProject" PRIMARY KEY AUTOINCREMENT,
    "ProjectRef" TEXT NULL,
    "Name" TEXT NULL,
    "Description" TEXT NULL,
    "DateCreated" TEXT NOT NULL
);

CREATE TABLE "WoodworkProject" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_WoodworkProject" PRIMARY KEY AUTOINCREMENT,
    "ProjectRef" TEXT NULL,
    "Name" TEXT NULL,
    "Description" TEXT NULL,
    "DateCreated" TEXT NOT NULL
);

CREATE TABLE "SoftwareProjectImage" (
    "SoftwareProjectImageId" INTEGER NOT NULL CONSTRAINT "PK_SoftwareProjectImage" PRIMARY KEY AUTOINCREMENT,
    "ImageUrl" TEXT NULL,
    "Description" TEXT NULL,
    "SoftwareProjectId" INTEGER NOT NULL,
    CONSTRAINT "FK_SoftwareProjectImage_SoftwareProject_SoftwareProjectId" FOREIGN KEY ("SoftwareProjectId") REFERENCES "SoftwareProject" ("Id") ON DELETE CASCADE
);

CREATE TABLE "WoodworkProjectImage" (
    "WoodworkProjectImageId" INTEGER NOT NULL CONSTRAINT "PK_WoodworkProjectImage" PRIMARY KEY AUTOINCREMENT,
    "ImageUrl" TEXT NULL,
    "Description" TEXT NULL,
    "WoodworkProjectId" INTEGER NOT NULL,
    CONSTRAINT "FK_WoodworkProjectImage_WoodworkProject_WoodworkProjectId" FOREIGN KEY ("WoodworkProjectId") REFERENCES "WoodworkProject" ("Id") ON DELETE CASCADE
);

INSERT INTO "SoftwareProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (1, '2013-01-01 00:00:00', 'Skill action calculator for video game Runescape', 'Runescape Calculator', 'rsCalc');

INSERT INTO "SoftwareProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (2, '2016-10-01 00:00:00', NULL, 'University e-commerce book store', 'uniEcomm');

INSERT INTO "SoftwareProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (3, '2016-10-01 00:00:00', NULL, 'Loyalty Pro Android App', 'loyaltyProApp');

INSERT INTO "SoftwareProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (4, '2017-05-01 00:00:00', NULL, 'University Dissertation - GPS Logger', 'uniDis');

INSERT INTO "WoodworkProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (1, '2017-07-05 00:00:00', NULL, 'Side Gate', 'sideGate');

INSERT INTO "WoodworkProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (2, '2017-08-21 00:00:00', NULL, 'Workbench', 'workbench');

INSERT INTO "WoodworkProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (3, '2017-08-21 00:00:00', NULL, 'Bird table', 'birdTable');

INSERT INTO "WoodworkProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (4, '2020-05-01 00:00:00', NULL, 'Raised Garden bed (Small)', 'raisedGardenBendSmall');

INSERT INTO "WoodworkProject" ("Id", "DateCreated", "Description", "Name", "ProjectRef")
VALUES (5, '2020-09-01 00:00:00', NULL, 'Raised Garden bed (Large)', 'raisedGardenBendLarge');

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (1, 'Agility skill calculator', 'images\software-images\rs-calculator\1.png', 1);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (21, 'Open side bar', 'images\software-images\gps-logger\5.png', 4);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (20, 'Staypoint shown on map', 'images\software-images\gps-logger\4.png', 4);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (19, 'Staypoint overview showing individual visits', 'images\software-images\gps-logger\3.png', 4);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (18, 'Individual journey view', 'images\software-images\gps-logger\2.png', 4);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (17, 'Display showing journeys between two staypoints', 'images\software-images\gps-logger\1.png', 4);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (16, 'Manual log in page', 'images\software-images\loyalty-pro-app\6.png', 3);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (15, 'Initial unlogged in page', 'images\software-images\loyalty-pro-app\5.png', 3);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (14, 'Vouchers overview page', 'images\software-images\loyalty-pro-app\4.png', 3);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (12, 'Balance overview page', 'images\software-images\loyalty-pro-app\2.png', 3);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (13, 'Personal details page', 'images\software-images\loyalty-pro-app\3.png', 3);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (10, 'Ecommerce contact us page', 'images\software-images\ecommerce-site\6.png', 2);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (9, 'Ecommerce admin page - Edit listing', 'images\software-images\ecommerce-site\5.png', 2);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (8, 'Ecommerce admin page', 'images\software-images\ecommerce-site\4.png', 2);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (7, 'Ecommerce basket page', 'images\software-images\ecommerce-site\3.png', 2);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (6, 'Ecommerce product page', 'images\software-images\ecommerce-site\2.png', 2);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (5, 'Ecommerce homepage', 'images\software-images\ecommerce-site\1.png', 2);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (4, 'Dropdown showing skill subcategories', 'images\software-images\rs-calculator\4.png', 1);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (3, 'Dropdown showing which skills are included', 'images\software-images\rs-calculator\3.png', 1);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (2, 'Fishing skill calculator', 'images\software-images\rs-calculator\2.png', 1);

INSERT INTO "SoftwareProjectImage" ("SoftwareProjectImageId", "Description", "ImageUrl", "SoftwareProjectId")
VALUES (11, 'Main menu', 'images\software-images\loyalty-pro-app\1.png', 3);

INSERT INTO "WoodworkProjectImage" ("WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId")
VALUES (4, 'All raised garden beds', 'images\woodwork-images\raised-garden-bed\all-in-view.jpg', 4);

INSERT INTO "WoodworkProjectImage" ("WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId")
VALUES (1, 'Unhung gate', 'images\woodwork-images\side-gate\sidegate-unhung.jpg', 1);

INSERT INTO "WoodworkProjectImage" ("WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId")
VALUES (2, 'Unfinished workbench', 'images\woodwork-images\workbench\workbench-unfinished.jpg', 2);

INSERT INTO "WoodworkProjectImage" ("WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId")
VALUES (3, 'Unfinished workbench', 'images\woodwork-images\bird-table\bird-table.jpg', 3);

INSERT INTO "WoodworkProjectImage" ("WoodworkProjectImageId", "Description", "ImageUrl", "WoodworkProjectId")
VALUES (5, 'All raised garden beds', 'images\woodwork-images\raised-garden-bed\all-in-view.jpg', 5);

CREATE INDEX "IX_SoftwareProjectImage_SoftwareProjectId" ON "SoftwareProjectImage" ("SoftwareProjectId");

CREATE INDEX "IX_WoodworkProjectImage_WoodworkProjectId" ON "WoodworkProjectImage" ("WoodworkProjectId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210505143722_Initial', '5.0.5');

COMMIT;

