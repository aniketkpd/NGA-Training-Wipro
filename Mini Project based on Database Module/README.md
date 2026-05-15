# Hotel Reservation System DBMS Project

## Domain Description
This project designs and implements a Microsoft SQL Server database for hotel operations. It supports customer management, room category and pricing management, room availability tracking, reservation handling, check-in/check-out flow, billing, payment processing, audit logging, and reporting for occupancy and revenue.

The project is based on the P4 - Hotel Reservation System problem statement from the Database Module mini project brief.

## Features Implemented
- Master data management for hotels, room categories, rooms, customers, staff, services, and payment methods.
- Reservation management with support for multiple rooms in one reservation.
- Check-in and check-out status tracking.
- Room availability tracking through a table-valued function.
- Billing calculation through a scalar function.
- Payment processing and payment status tracking.
- Constraints using primary keys, foreign keys, `NOT NULL`, `UNIQUE`, `CHECK`, and default values.
- DDL operations including `CREATE`, `ALTER`, `DROP`, and `TRUNCATE` examples.
- DML operations including `INSERT`, `UPDATE`, and `DELETE`.
- Complex reporting queries using joins, aggregation, subqueries, correlated subqueries, and nested subqueries.
- Views for reservation details, occupancy, revenue, and current room status.
- Indexes for availability checks, customer lookup, reservation dates, and payment reporting.
- Triggers for insert, update, delete audit logging and double-booking prevention.
- Transaction control examples using `COMMIT` and `ROLLBACK`.
- Role-based access simulation using `GRANT` and `REVOKE`.

## Database Design Approach
The database is normalized up to 3NF/BCNF. Repeating groups are separated into child tables, non-key attributes depend only on table keys, and many-to-many relationships are resolved using bridge tables.

Core entities:
- `Hotel`
- `RoomCategory`
- `Room`
- `Customer`
- `Staff`
- `Reservation`
- `ReservationRoom`
- `Service`
- `ReservationService`
- `PaymentMethod`
- `Payment`
- `AuditLog`

## How to Execute Scripts
Run the scripts in SQL Server Management Studio in this order:

1. `SQL/ddl_scripts.sql`
2. `SQL/dml_scripts.sql`
3. `SQL/views.sql`
4. `SQL/functions.sql`
5. `SQL/triggers.sql`
6. `SQL/indexes.sql`
7. `SQL/queries.sql`
8. `SQL/transactions_dcl_demo.sql`
9. `SQL/drop_truncate_demo.sql` only when demonstrating DDL cleanup behavior.

The project creates and uses the database `HotelReservationDB`.

## Sample Queries and Outputs
Sample query outputs are provided in `Output/sample_results.xlsx`.

Example reports included:
- Available rooms for a requested date range.
- Reservation details with customer and room information.
- Occupancy rate by room category.
- Monthly revenue.
- Customers with high-value bookings.
- Reservations with pending payment.
- Trigger audit log output.

## Final Demonstration Checklist
- ER diagram uploaded in `ERD/er_diagram.png`.
- Normalization explained in `Documentation/normalization_report.pdf`.
- SQL scripts are grouped by assignment deliverables.
- More than 10 complex queries are included.
- Scalar function and table-valued function are included.
- Insert, update, and delete triggers are included.
- Transaction rollback and commit scenarios are included.
- DCL simulation using `GRANT` and `REVOKE` is included.
