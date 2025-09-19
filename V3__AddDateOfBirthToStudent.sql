BEGIN TRANSACTION;
ALTER TABLE "Students" ADD "DateOfBirth" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250919130609_V3__AddDateOfBirthToStudent', '9.0.9');

COMMIT;

