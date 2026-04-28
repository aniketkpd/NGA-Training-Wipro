CREATE Database NFSDB;
use NFSDB;

CREATE TABLE WiproEmployees
(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [Age] [int] NOT NULL,
    [City] [varchar](50) NOT NULL
);

-- Insert some sample data into the WiproEmployees table
insert into WiproEmployees (Name, Age, City) values ('John Doe', 30, 'New York');
insert into WiproEmployees (Name, Age, City) values ('Jane Smith', 25, 'Los Angeles');
INSERT INTO WiproEmployees (Name, Age, City) VALUES ('Alice Johnson', 28, 'Chicago');
INSERT INTO WiproEmployees (Name, Age, City) VALUES ('Bob Brown', 35, 'Houston');
INSERT INTO WiproEmployees (Name, Age, City) VALUES ('Charlie Davis', 32, 'Phoenix');

-- Showing content of the table
Select * from WiproEmployees;

-- instead of * we should always go with
Select ID, Name, Age, City from WiproEmployees;


-- update in the table
-- update can be based on any column with a condition like
-- update WiproEmployees set City='San Francisco' where Name='Alice Johnson';
Update WiproEmployees set City='San Francisco' where Name='Alice Johnson';

-- update on the basis of ID
Update WiproEmployees set Age=29 where ID=3;

-- delete from the table
delete from WiproEmployees where Name='Bob Brown';