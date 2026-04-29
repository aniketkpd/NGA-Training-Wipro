-- User-level permissions (direct control)
-- This part is about one user only.
-------------------------------------------------

-- Flow:
-- create user
-- grant permission
-- revoke permission
-- drop user

-- Meaning:
-- You give permission directly to a user
-- You control everything individually
-- Example thinking:

-- “User1 can read Customers table”



-- In SQL Server, there are 2 levels:

-- LOGIN → server level (enter SQL Server)
-- USER → database level (enter a specific database)








-- Step-by-step in plain language

-- 0. CREATE LOGIN → “Allow entry to server”
CREATE LOGIN User1Login WITH PASSWORD = 'Password@123';

--This means:
-- “Hey SQL Server, this person can now log in.”
-- But… they still can’t access any database yet



-- 1. CREATE USER → “Give access to a database”
USE NFSDB;
CREATE USER User1 FOR LOGIN User1Login;

-- Now the person can enter the NFSDB database
-- Still… they can’t do anything yet




-- 2. GRANT → “Give permission to do something”
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.WiproEmployees TO User1;

-- Now User1 can Read data from Customers table
-- “You can look at files, but not edit them”


-- 3. REVOKE → “Take back permission”
REVOKE SELECT, INSERT, UPDATE, DELETE ON dbo.WiproEmployees FROM User1;

-- Now user can’t read anymore
-- All permissions removed


-- 3.xx (Extra but important): DENY
-- DENY SELECT ON dbo.Customers TO User1;

-- This blocks access completely (stronger than revoke)


-- Step 4: Drop user
DROP USER User1;


-- Step 5: (optional cleanup) Drop login
DROP LOGIN User1Login;


-- CREATE LOGIN → CREATE USER → GRANT → REVOKE/DENY → DROP USER → DROP LOGIN









