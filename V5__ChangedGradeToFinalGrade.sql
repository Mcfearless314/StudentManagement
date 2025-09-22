BEGIN TRANSACTION;
ALTER TABLE "Instructor" RENAME TO "Instructors";

ALTER TABLE "Enrollments" RENAME COLUMN "Grade" TO "FinalGrade";

CREATE TABLE "ef_temp_Courses" (
    "CourseId" INTEGER NOT NULL CONSTRAINT "PK_Courses" PRIMARY KEY AUTOINCREMENT,
    "Credits" INTEGER NOT NULL,
    "InstructorId" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    CONSTRAINT "FK_Courses_Instructors_InstructorId" FOREIGN KEY ("InstructorId") REFERENCES "Instructors" ("Id")
);

INSERT INTO "ef_temp_Courses" ("CourseId", "Credits", "InstructorId", "Title")
SELECT "CourseId", "Credits", "InstructorId", "Title"
FROM "Courses";

CREATE TABLE "ef_temp_Instructors" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Instructors" PRIMARY KEY AUTOINCREMENT,
    "Email" TEXT NULL,
    "FirstName" TEXT NOT NULL,
    "HireDate" TEXT NOT NULL,
    "LastName" TEXT NOT NULL
);

INSERT INTO "ef_temp_Instructors" ("Id", "Email", "FirstName", "HireDate", "LastName")
SELECT "Id", "Email", "FirstName", "HireDate", "LastName"
FROM "Instructors";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;
DROP TABLE "Courses";

ALTER TABLE "ef_temp_Courses" RENAME TO "Courses";

DROP TABLE "Instructors";

ALTER TABLE "ef_temp_Instructors" RENAME TO "Instructors";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;
CREATE INDEX "IX_Courses_InstructorId" ON "Courses" ("InstructorId");

COMMIT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250922105256_V5__ChangedGradeToFinalGrade', '9.0.9');

