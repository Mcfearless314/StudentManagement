BEGIN TRANSACTION;
CREATE TABLE "ef_temp_Courses" (
    "CourseId" INTEGER NOT NULL CONSTRAINT "PK_Courses" PRIMARY KEY AUTOINCREMENT,
    "Credits" decimal(5, 2) NOT NULL,
    "InstructorId" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    CONSTRAINT "FK_Courses_Instructors_InstructorId" FOREIGN KEY ("InstructorId") REFERENCES "Instructors" ("Id")
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
VALUES ('20250922122239_V7__ModifyCourseCredit', '9.0.9');

