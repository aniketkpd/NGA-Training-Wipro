-- User Story 1: Transparent Data Encryption (TDE) at rest — run on SQL Server by a DBA.
-- Requires SQL Server Enterprise or equivalent edition that supports TDE.
-- Application also uses AES column encryption in code for sensitive fields.

USE master;
GO

-- 1. Create a master key in the master database (once per server)
-- CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Use-A-Strong-Password-From-Key-Vault!';

-- 2. Create certificate used to protect the database encryption key
-- CREATE CERTIFICATE SecureJwtApiTdeCert WITH SUBJECT = 'SecureJwtApi TDE Certificate';

USE SecureJwtApiDb;
GO

-- 3. Create database encryption key
-- CREATE DATABASE ENCRYPTION KEY
-- WITH ALGORITHM = AES_256
-- ENCRYPTION BY SERVER CERTIFICATE SecureJwtApiTdeCert;

-- 4. Enable TDE on the database
-- ALTER DATABASE SecureJwtApiDb SET ENCRYPTION ON;

-- Verify:
-- SELECT db.name, encrypt.encryption_state
-- FROM sys.databases db
-- JOIN sys.dm_database_encryption_keys encrypt ON db.database_id = encrypt.database_id
-- WHERE db.name = 'SecureJwtApiDb';
