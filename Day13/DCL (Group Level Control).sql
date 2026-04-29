-- What is “Group control” (Role)?

-- A role is just a group of users.
-- Instead of giving permissions to each user:
-- You give permission to the role
-- Then add users to that role

-- Simple idea
-- Role = “Team”
-- Users = “Members of the team”
--------------------------------------------------------------------



-- Step-by-step (Role-based control)

-- Step 0: Create login (server level)
CREATE LOGIN User1Login WITH PASSWORD = 'Password@123';

-- Step 1: Create user (database level)
USE NFSDB;
CREATE USER User1 FOR LOGIN User1Login;

-- Step 2: Create a role
CREATE ROLE SalesRole;

-- You created a group called SalesRole

-- Step 3: Give permission to the role
GRANT SELECT, INSERT ON dbo.WiproEmployees TO SalesRole;

-- Anyone inside SalesRole can read & insert data

-- Step 4: Add user to role
ALTER ROLE SalesRole ADD MEMBER User1;

-- User1 now inherits all permissions
-- Step 5: Remove user from role
ALTER ROLE SalesRole DROP MEMBER User1;

-- User1 loses all role permissions

-- Step 6: Revoke permission from role
REVOKE SELECT, INSERT ON dbo.WiproEmployees FROM SalesRole;

-- Now no one in the role has access

-- Step 7: Drop role
DROP ROLE SalesRole;

-- Step 8: Drop user
DROP USER User1;

-- Step 9: Drop login
DROP LOGIN User1Login;



-- CREATE ROLE → GRANT → ADD USER → REMOVE USER → REVOKE → DROP ROLE