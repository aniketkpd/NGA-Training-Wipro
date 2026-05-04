USE mydb;

SELECT name FROM sys.tables;

CREATE TABLE EventLog (
    EventId        INT PRIMARY KEY,
    EventName      VARCHAR(100),
    EventDate      DATE,
    EventDateTime  DATETIME,
    EventSmall     SMALLDATETIME,
    EventTime      TIME,
    EventStamp     TIMESTAMP
);

INSERT INTO EventLog (EventId, EventName, EventDate, EventDateTime, EventSmall, EventTime) VALUES
(1, 'Server Startup',   '2024-01-15', '2024-01-15 08:30:45', '2024-01-15 08:30:00', '08:30:45'),
(2, 'User Login',       '2024-03-22', '2024-03-22 13:15:30', '2024-03-22 13:15:00', '13:15:30'),
(3, 'Backup Started',   '2024-06-10', '2024-06-10 23:59:59', '2024-06-10 23:59:00', '23:59:59'),
(4, 'Report Generated', '2024-09-05', '2024-09-05 17:45:10', '2024-09-05 17:45:00', '17:45:10'),
(5, 'System Shutdown',  '2024-12-31', '2024-12-31 22:00:00', '2024-12-31 22:00:00', '22:00:00');


SELECT * FROM EventLog;

SELECT EventId, EventName, EventDate INTO shorteventlog
FROM EventLog;


SELECT * FROM shorteventlog;