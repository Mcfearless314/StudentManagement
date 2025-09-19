BEGIN TRANSACTION;
ALTER TABLE "Courses" ADD "InstructorId" INTEGER NOT NULL DEFAULT 0;

CREATE TABLE "Instructor" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Instructor" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Email" TEXT NULL,
    "HireDate" TEXT NOT NULL
);

CREATE INDEX "IX_Courses_InstructorId" ON "Courses" ("InstructorId");

CREATE TABLE "ef_temp_Courses" (
    "CourseId" INTEGER NOT NULL CONSTRAINT "PK_Courses" PRIMARY KEY AUTOINCREMENT,
    "Credits" INTEGER NOT NULL,
    "InstructorId" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    CONSTRAINT "FK_Courses_Instructor_InstructorId" FOREIGN KEY ("InstructorId") REFERENCES "Instructor" ("Id")
);

INSERT INTO "ef_temp_Courses" ("CourseId", "Credits", "InstructorId", "Title")
SELECT "CourseId", "Credits", "InstructorId", "Title"
FROM "Courses";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;
DROP TABLE "Courses";

ALTER TABLE "ef_temp_Courses" RENAME TO "Courses";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;
CREATE INDEX "IX_Courses_InstructorId" ON "Courses" ("InstructorId");

COMMIT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250919133634_V4__AddInstructor', '9.0.9');

