-- What is TCL?

-- TCL is used to control transactions (changes in database)
-- Simple meaning:
-- “Do you want to save changes or cancel them?”
 

-- Real-life idea

-- Think like editing a document:

-- You edit → changes are temporary
-- Click Save → changes permanent
-- Click Undo → changes removed

-- Same thing in SQL


-- | Command             | Meaning                   |
-- | ------------------- | ------------------------- |
-- | `BEGIN TRANSACTION` | Start work                |
-- | `COMMIT`            | Save changes              |
-- | `ROLLBACK`          | Undo changes              |
-- | `SAVEPOINT`         | Mark a point to return to |

-----------------------------------------------------------




-- Step-by-step understanding
-- 1. BEGIN TRANSACTION (start work)
BEGIN TRANSACTION;

-- Now whatever you do is temporary

-- 2. Do some operation
USE NFSDB;

UPDATE dbo.WiproEmployees 
SET Name = 'Aniket' 
WHERE ID = 1;

-- Data is changed, but not saved permanently yet

-- 3. COMMIT (save)
COMMIT;

-- Now change is permanent


-- 4. ROLLBACK (undo)
ROLLBACK;

-- Everything goes back to original


Select * FRom WiproEmployees;



-- Important understanding

-- Without COMMIT:
-- changes can be undone

-- After COMMIT:
-- changes are final







-----------------------------------------------------------------------


-- Example 1 (Success case)
BEGIN TRANSACTION;

USE NFSDB;

UPDATE dbo.WiproEmployees 
SET Name = 'Right Name' 
WHERE ID = 1;

COMMIT;

Select * FRom WiproEmployees;


-- Change saved

-- Example 2 (Failure case)
BEGIN TRANSACTION;

USE NFSDB;

UPDATE dbo.WiproEmployees 
SET Name = 'Wrong Name' 
WHERE ID = 1;

ROLLBACK;


Select * FRom WiproEmployees;

-- Change cancelled





-----------------------------------------------------------------------



-- SAVEPOINT = checkpoint

BEGIN TRANSACTION;
USE NFSDB;

UPDATE dbo.WiproEmployees SET Name = 'Updated Name' WHERE ID = 2;

SAVE TRANSACTION SavePoint1;

UPDATE dbo.WiproEmployees SET Age = 35 WHERE ID = 2;

ROLLBACK TRANSACTION SavePoint1;

COMMIT;


SELECT * FROM WiproEmployees;

------ Rollback TO savepoint ------
-- Result:
-- Name change  -  stays
-- Age change   -  removed






-- Summary
-- BEGIN → start
-- COMMIT → save
-- ROLLBACK → undo all
-- SAVEPOINT → undo partially