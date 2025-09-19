BEGIN TRANSACTION;
ALTER TABLE "Students" ADD "MiddleName" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250919130126_V2__AddMiddleNameToStudent', '9.0.9');

COMMIT;

