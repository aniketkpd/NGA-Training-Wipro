-- User Story 4: Least-privilege database access (run as sysadmin, adjust passwords via Key Vault).

USE master;
GO

-- Application login (no sysadmin; only DML on app database)
-- CREATE LOGIN SecureJwtApiApp WITH PASSWORD = 'Store-In-Azure-Key-Vault-Or-AWS-Secrets';
-- GO

-- USE SecureJwtApiDb;
-- GO
-- CREATE USER SecureJwtApiApp FOR LOGIN SecureJwtApiApp;
-- GO
-- ALTER ROLE db_datareader ADD MEMBER SecureJwtApiApp;
-- ALTER ROLE db_datawriter ADD MEMBER SecureJwtApiApp;
-- DENY SELECT, INSERT, UPDATE, DELETE ON dbo.SecurityAuditLogs TO SecureJwtApiApp; -- optional: restrict audit table

-- Connection string example (User Secrets / Key Vault — never commit real passwords):
-- Server=...;Database=SecureJwtApiDb;User Id=SecureJwtApiApp;Password=***;Encrypt=True;TrustServerCertificate=False;
