BEGIN TRANSACTION;
CREATE TABLE "Departments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Departments" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Budget" REAL NOT NULL,
    "StartDate" TEXT NOT NULL,
    "DepartmentHeadId" INTEGER NOT NULL,
    CONSTRAINT "FK_Departments_Instructors_DepartmentHeadId" FOREIGN KEY ("DepartmentHeadId") REFERENCES "Instructors" ("Id")
);

CREATE UNIQUE INDEX "IX_Departments_DepartmentHeadId" ON "Departments" ("DepartmentHeadId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250922114952_V6__AddDepartment', '9.0.9');

COMMIT;

