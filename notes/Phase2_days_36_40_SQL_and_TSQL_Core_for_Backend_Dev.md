Here is your content formatted as a Markdown (.md) file ready for GitHub:

# Backend Career Preparation: SQL, T-SQL & LINQ

**For my backend career preparation, I will focus on mastering SQL and T-SQL for database development, while using LINQ within my application code for efficient data querying.**

---

## 1. SQL Overview  
SQL (Structured Query Language) is used to create, read, update, and delete (CRUD) data in relational databases.

## 2. Database Basics  
- **Database:** container of data  
- **Table:** like a spreadsheet (rows = records, columns = fields)  
- **Row:** one record (e.g., one user)  
- **Column:** one attribute (e.g., name, email)

## 3. SQL Data Types Cheat Sheet

| Type      | Size / Limit          | Example              | Use                  | Notes                        |
|-----------|----------------------|----------------------|----------------------|------------------------------|
| INT       | 4 bytes (±2.1B)      | age INT              | Whole numbers        | Use BIGINT for very large numbers |
| BIGINT    | 8 bytes (±9 quintillion) | views BIGINT       | Very large numbers   | Often used for IDs            |
| DECIMAL(x,y) | Fixed: x digits, y decimals | price DECIMAL(10,2) | Exact decimal (money) | No rounding errors            |
| FLOAT/REAL | Approximate (binary) | score FLOAT          | Fast decimal         | Use DECIMAL if precision matters |
| BOOLEAN/BOOL | 1 byte (0/1)       | is_active BOOLEAN    | True/False flags     | Stored as TINYINT(1) in MySQL |
| CHAR(n)   | Fixed length (n chars) | code CHAR(2)        | Short codes          | Always takes full length      |
| VARCHAR(n) | Variable (max n chars) | name VARCHAR(50)    | General short strings| Efficient, commonly used      |
| TEXT      | Up to 64KB (MySQL)    | bio TEXT             | Long text            | Can't use with indexes easily |
| DATE      | YYYY-MM-DD            | birthdate DATE       | Dates only           | No time included             |
| TIME      | HH:MM:SS              | login_time TIME      | Time only            | No date included             |
| DATETIME  | YYYY-MM-DD HH:MM:SS   | created_at DATETIME  | Full date & time     | Used for timestamps          |
| TIMESTAMP | Like DATETIME + auto update | updated_at TIMESTAMP | Auto-updated on row change | Default CURRENT_TIMESTAMP works here |
| BLOB      | Binary data           | image_data BLOB      | Store files/images   | Size-limited by DB engine    |

**Notes:**  
- Use VARCHAR for most text unless very large input expected (then use TEXT).  
- Use DECIMAL for money, not FLOAT.  
- TIMESTAMP often used with DEFAULT CURRENT_TIMESTAMP for auto time tracking.  
- Avoid NULL in critical columns if possible (use NOT NULL).

---

## 4. ALTER TABLE Examples

```sql
-- 1. ADD COLUMN
ALTER TABLE table_name ADD column_name column_datatype;
-- Example:
ALTER TABLE Employees ADD Email VARCHAR(100);

-- 2. ADD MULTIPLE COLUMNS
ALTER TABLE table_name 
ADD (column_1 column_definition, column_2 column_definition, ...);
-- Example:
ALTER TABLE Employees 
ADD (Address VARCHAR(255), Age INT);

-- 3. MODIFY COLUMN
ALTER TABLE table_name MODIFY column_name column_datatype;
-- Example:
ALTER TABLE Employees MODIFY Age SMALLINT;

-- 4. MODIFY MULTIPLE COLUMNS
ALTER TABLE table_name 
MODIFY (column_1 column_type, column_2 column_type, ...);
-- Example:
ALTER TABLE Employees 
MODIFY (Age SMALLINT, Address VARCHAR(500));

-- 5. DROP COLUMN
ALTER TABLE table_name DROP COLUMN column_name;
-- Example:
ALTER TABLE Employees DROP COLUMN Email;

-- 6. RENAME COLUMN
ALTER TABLE table_name RENAME COLUMN old_name TO new_name;
-- Example:
ALTER TABLE Employees RENAME COLUMN Address TO Location;

-- 7. RENAME TABLE
ALTER TABLE old_table_name RENAME TO new_table_name;
-- Example:
ALTER TABLE Employees RENAME TO Staff;

-- 8. DROP TABLE
DROP TABLE table_name;
-- Example:
DROP TABLE Staff;
5. Constraints Examples

-- ADD PRIMARY KEY
ALTER TABLE table_name ADD CONSTRAINT constraint_name PRIMARY KEY (column_name);
-- Example:
ALTER TABLE Employees ADD CONSTRAINT pk_emp PRIMARY KEY (EmployeeID);

-- ADD FOREIGN KEY
ALTER TABLE table_name 
ADD CONSTRAINT constraint_name 
FOREIGN KEY (column_name) REFERENCES other_table(other_column);
-- Example:
ALTER TABLE Orders 
ADD CONSTRAINT fk_customer FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID);

-- ADD UNIQUE CONSTRAINT
ALTER TABLE table_name ADD CONSTRAINT constraint_name UNIQUE (column_name);
-- Example:
ALTER TABLE Employees ADD CONSTRAINT uq_email UNIQUE (Email);
6. Data Manipulation Language (DML)

-- INSERT
INSERT INTO employees (name, age) VALUES ('Ali', 30);
-- Insert full row without column names
INSERT INTO employees VALUES ('Ali', 30);

-- UPDATE
UPDATE employees SET age = 31 WHERE name = 'Ali';
-- Update all rows without WHERE
UPDATE employees SET age = 31;

-- DELETE
DELETE FROM employees WHERE name = 'Ali';

-- SELECT
SELECT name, age FROM employees;

-- SELECT with WHERE
SELECT name FROM employees WHERE age > 25;
SELECT name FROM employees WHERE age = 30;
SELECT name FROM employees WHERE age <> 40;
SELECT name FROM employees WHERE age >= 25;
SELECT name FROM employees WHERE age <= 35;
7. Operators in SELECT

-- Alias Names
SELECT first_name AS fname FROM employees;
SELECT last_name "surname" FROM employees;

-- Concatenation (||)
SELECT first_name || ' ' || last_name AS "Full name" FROM employees;

-- Arithmetic Operators (+, -, *, /)
SELECT salary, salary * 12 AS "annual salary" FROM employees;

-- DISTINCT
SELECT DISTINCT department FROM employees;
8. WHERE Clause and Operators

-- Comparison Operators: =, <>, >, <, >=, <=
SELECT * FROM employees WHERE age = 30;
SELECT * FROM employees WHERE salary <> 5000;

-- BETWEEN (inclusive range)
SELECT * FROM employees WHERE age BETWEEN 25 AND 35;

-- IN (multiple values)
SELECT * FROM employees WHERE department IN ('HR', 'IT', 'Sales');

-- LIKE (pattern matching)
SELECT * FROM employees WHERE name LIKE 'A%';   -- starts with A
SELECT * FROM employees WHERE name LIKE '%a';   -- ends with a
SELECT * FROM employees WHERE name LIKE '_li';  -- 3-letter names ending with 'li'
9. Logical Operators in WHERE

-- AND (all conditions true)
SELECT * FROM employees WHERE age > 25 AND department = 'IT';

-- OR (any condition true)
SELECT * FROM employees WHERE department = 'HR' OR department = 'Sales';

-- NOT (negates condition)
SELECT * FROM employees WHERE NOT department = 'Finance';

-- Combined example
SELECT * FROM employees 
WHERE (age > 25 AND department = 'IT') OR NOT (salary < 5000);
10. ORDER BY Examples

-- Sort by department_id descending
SELECT employee_id, first_name, department_id
FROM employees
ORDER BY department_id DESC;

-- Sort by first_name ascending (default)
SELECT employee_id, first_name, department_id
FROM employees
ORDER BY first_name ASC;
11. NULL Handling

-- IS NULL and IS NOT NULL
SELECT * FROM employees WHERE commission_pct IS NULL;
SELECT * FROM employees WHERE commission_pct IS NOT NULL;

-- NVL(exp1, exp2)
SELECT employee_id, NVL(commission_pct, 0) AS commission FROM employees;

-- NVL2(exp1, exp2, exp3)
SELECT employee_id, NVL2(commission_pct, 10, 0) AS comm_flag FROM employees;

-- NULLIF(exp1, exp2)
SELECT employee_id, NULLIF(salary, 9000) AS salary_check FROM employees;
12. String Functions

SELECT LOWER(first_name) AS lower_name FROM employees;
SELECT UPPER(first_name) AS upper_name FROM employees;
SELECT INITCAP(first_name) AS initcap_name FROM employees;
SELECT SUBSTR(first_name, 1, 3) AS substr_name FROM employees;
SELECT LENGTH(first_name) AS name_length FROM employees;
SELECT CONCAT(first_name, last_name) AS full_name FROM employees;
SELECT REPLACE(first_name, 'a', 'x') AS replaced_name FROM employees;
13. Numeric Functions

SELECT MOD(29, 3) FROM dual;
SELECT ROUND(5.567, 2) FROM dual;
SELECT ROUND(55.67, -1) FROM dual;
SELECT TRUNC(125.815, 1) FROM dual;
SELECT TRUNC(125.815, -1) FROM dual;
14. TO_CHAR() and TO_DATE() (Oracle Specific)

-- TO_CHAR(date, format)
SELECT TO_CHAR(SYSDATE, 'DD-MON-YYYY HH24:MI:SS') AS formatted_date FROM dual;

-- TO_DATE(string, format)
SELECT TO_DATE('2025-07-27', 'YYYY-MM-DD') FROM dual;
15. Aggregate Functions

SELECT SUM(salary) AS total_salary FROM employees;
SELECT AVG(salary) AS avg_salary FROM employees;
SELECT COUNT(employee_id) AS employee_count FROM employees;
SELECT MIN(salary) AS min_salary FROM employees;
SELECT MAX(salary) AS max_salary FROM employees;
16. GROUP BY and HAVING

SELECT department_id, SUM(salary) AS total_salary
FROM employees
GROUP BY department_id;

SELECT department_id, SUM(salary) AS total_salary
FROM employees
GROUP BY department_id
HAVING SUM(salary) > 100000;
17. Subqueries

SELECT employee_id, first_name, salary
FROM employees
WHERE salary > (SELECT AVG(salary) FROM employees);
18. UNION and CROSS JOIN

-- UNION: combine SELECT results (same columns & types)
SELECT employee_id, first_name FROM employees
UNION
SELECT manager_id, manager_name FROM managers;

-- CROSS JOIN (Cartesian product)
SELECT * FROM A CROSS JOIN B;
-- or
SELECT * FROM A, B;

-- Equi Join example
SELECT e.employee_id, e.first_name, e.department_id, d.department_name
FROM employees e, departments d
WHERE e.department_id = d.department_id;
19. Table Constraints Examples

-- NOT NULL
CREATE TABLE student (
  id NUMBER(3) NOT NULL,
  name VARCHAR2(10),
  mark NUMBER(4)
);

-- DEFAULT
CREATE TABLE student (
  id NUMBER(3),
  name VARCHAR2(10),
  mark NUMBER(4) DEFAULT 50
);

-- UNIQUE
CREATE TABLE student (
  id NUMBER(3) UNIQUE,
  name VARCHAR2(10),
  mark NUMBER(4)
);

-- PRIMARY KEY
CREATE TABLE student (
  id NUMBER(3) PRIMARY KEY,
  name VARCHAR2(10),
  mark NUMBER(4)
);

-- FOREIGN KEY
CREATE TABLE classes (
  c_id NUMBER(3),
  c_date DATE,
  s_id NUMBER(3) REFERENCES student(id)
);

-- CHECK
CREATE TABLE student (
  id NUMBER(3),
  name VARCHAR2(10),
  mark NUMBER(4) CHECK (mark > 50)
);
Summary
Learn SQL and T-SQL deeply for backend and database work.
Use LINQ in my application code for efficient, readable querying.
Strong SQL skills are crucial in real backend jobs, even with LINQ in use.
i will Focus on writing queries, understanding joins, subqueries, aggregate functions, constraints, and data manipulation.
This note will guide my backend journey to master databases and querying efficiently and professionally.











T-SQL principles:
## 📊 T-SQL Core Principles for Backend Development

Mastering T-SQL is essential for efficient database operations in SQL Server backend roles. Below are key concepts with syntax and examples:

### 1. Basic CRUD Operations

```sql
-- Create (Insert)
INSERT INTO Employees (Name, Age, Department)
VALUES ('Ali', 30, 'IT');

-- Read (Select)
SELECT * FROM Employees WHERE Age > 25;

-- Update
UPDATE Employees SET Age = 31 WHERE Name = 'Ali';

-- Delete
DELETE FROM Employees WHERE Name = 'Ali';
2. Filtering, Sorting, and Paging

SELECT Name, Age FROM Employees
WHERE Department = 'HR'
ORDER BY Age DESC
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;  -- Paging example
3. Joins

-- Inner Join
SELECT e.Name, d.DepartmentName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.ID;

-- Left Join
SELECT e.Name, d.DepartmentName
FROM Employees e
LEFT JOIN Departments d ON e.DepartmentID = d.ID;
4. Aggregation & Grouping

SELECT Department, COUNT(*) AS EmployeeCount, AVG(Age) AS AvgAge
FROM Employees
GROUP BY Department
HAVING COUNT(*) > 5;
5. Conditional Logic with CASE

SELECT Name, Age,
  CASE 
    WHEN Age < 18 THEN 'Minor'
    WHEN Age >= 18 AND Age < 65 THEN 'Adult'
    ELSE 'Senior'
  END AS AgeGroup
FROM Employees;
6. Transactions

BEGIN TRANSACTION;
UPDATE Accounts SET Balance = Balance - 100 WHERE AccountID = 1;
UPDATE Accounts SET Balance = Balance + 100 WHERE AccountID = 2;
COMMIT;
7. Stored Procedures & Variables

CREATE PROCEDURE GetEmployeesByDept
  @DeptName VARCHAR(50)
AS
BEGIN
  SELECT * FROM Employees WHERE Department = @DeptName;
END;

-- Execute procedure
EXEC GetEmployeesByDept 'IT';
Next Steps to Master T-SQL for Backend Jobs
Learn query optimization and indexing strategies

Practice window functions (ROW_NUMBER, RANK, etc.)

Understand error handling (TRY...CATCH)

Explore security with roles and permissions

Combine T-SQL knowledge with LINQ in your C# apps


