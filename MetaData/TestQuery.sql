CREATE DATABASE chartstest
use  chartstest
CREATE TABLE months(
    year int DEFAULT(year(getdate())) ,
    name VARCHAR(100),
    price money
)
--janvier, février, mars, avril, mai, juin, juillet, août, septembre, octobre, novembre et décembre
-- Insert rows into table 'months' in schema '[dbo]'
INSERT INTO [dbo].[months]
( -- Columns to insert data into
 [name], [price]
)
VALUES
( -- First row: values for the columns in the list above
  'Janvier', 50.00
),
( -- Second row: values for the columns in the list above
  'Février', 75.98
),
( -- Second row: values for the columns in the list above
  'Mars', 70
),
( -- Second row: values for the columns in the list above
  'Avril', 73
),
( -- Second row: values for the columns in the list above
  'Mai', 20
),
( -- Second row: values for the columns in the list above
  'Juin', 79.10
),
( -- First row: values for the columns in the list above
  'Juillet', 5.00
),
( -- Second row: values for the columns in the list above
  'Août', 20.98
),
( -- Second row: values for the columns in the list above
  'Septembre', 78.12
),
( -- Second row: values for the columns in the list above
  'Octobre', 150
),
( -- Second row: values for the columns in the list above
  'Novembre', 90
),
( -- Second row: values for the columns in the list above
  'Décembre', 10
)
-- Add more rows here
GO

SELECT * FROM months
-- Update rows in table '[months]' in schema '[dbo]'
UPDATE [dbo].[months]
SET
    [price] = 30.00
    -- Add more columns and values here
WHERE [name] = 'may'
GO
