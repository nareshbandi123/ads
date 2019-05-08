CREATE SCHEMA "automatic_test_connection" 
GO
CREATE TABLE "automatic_test_connection"."AUTOMATIC_TEST_CONNECTION_1"(c1 char(25), c2 char(25))
GO
INSERT INTO "automatic_test_connection"."AUTOMATIC_TEST_CONNECTION_1" VALUES('TEST1', 'TEST2')
GO
SELECT c1, c2 FROM "automatic_test_connection"."AUTOMATIC_TEST_CONNECTION_1"
GO