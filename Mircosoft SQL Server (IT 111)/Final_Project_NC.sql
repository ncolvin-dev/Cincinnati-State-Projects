-- --------------------------------------------------------------------------------
-- Name: Nicholas Colvin 
-- Class: IT-111 
-- Abstract: Final Project
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE DBSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors


-- --------------------------------------------------------------------------------
-- Drop Table Statements		 
-- --------------------------------------------------------------------------------

IF OBJECT_ID ('TJobWorkers')		IS NOT NULL DROP TABLE TJobWorkers
IF OBJECT_ID ('TJobMaterials')		IS NOT NULL DROP TABLE TJobMaterials
IF OBJECT_ID ('TWorkerSkills')		IS NOT NULL DROP TABLE TWorkerSkills
IF OBJECT_ID ('TJobs')				IS NOT NULL DROP TABLE TJobs
IF OBJECT_ID ('TStatuses')			IS NOT NULL DROP TABLE TStatuses
IF OBJECT_ID ('TCustomers')			IS NOT NULL DROP TABLE TCustomers
IF OBJECT_ID ('TMaterials')			IS NOT NULL DROP TABLE TMaterials
IF OBJECT_ID ('TVendors')			IS NOT NULL DROP TABLE TVendors
IF OBJECT_ID ('TWorkers')			IS NOT NULL DROP TABLE TWorkers
IF OBJECT_ID ('TSkills')			IS NOT NULL DROP TABLE TSkills
IF OBJECT_ID ('TStates')			IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
-- Step 1: Design and Create Tables in Third Normal Form
-- --------------------------------------------------------------------------------

CREATE TABLE TJobs
(
	 intJobID							INTEGER				NOT NULL
	,intCustomerID						INTEGER				NOT NULL
	,intStatusID						INTEGER				NOT NULL
	,dtmStartDate						DATE				NOT NULL
	,dtmEndDate							DATE				NOT NULL
	,strJobDesc							VARCHAR(2000)		NOT NULL
	,CONSTRAINT TJobs_PK				PRIMARY KEY ( intJobID )
)


CREATE TABLE TCustomers
(
	  intCustomerID						INTEGER				NOT NULL
	 ,strFirstName						VARCHAR(50)			NOT NULL
	 ,strLastName						VARCHAR(50)			NOT NULL
	 ,strAddress						VARCHAR(50)			NOT NULL
	 ,strCity							VARCHAR(50)			NOT NULL
	 ,intStateID						INTEGER				NOT NULL
	 ,strZip							VARCHAR(50)			NOT NULL
	 ,strPhoneNumber					VARCHAR(50)			NOT NULL
	 ,CONSTRAINT TCustomer_PK			PRIMARY KEY ( intCustomerID )
)


CREATE TABLE TStatuses
(
	 intStatusID						INTEGER				NOT NULL
	,strStatus							VARCHAR(50)			NOT NULL
	,CONSTRAINT TStatuses_PK			PRIMARY KEY ( intStatusID )
)

CREATE TABLE TJobMaterials
(
	 intJobMaterialID					INTEGER				NOT NULL
	,intJobID							INTEGER				NOT NULL
	,intMaterialID						INTEGER				NOT NULL
	,intQuantity						INTEGER				NOT NULL
	,CONSTRAINT TCustomerJobMaterials_PK PRIMARY KEY ( intJobMaterialID )
)

CREATE TABLE TMaterials
(
	 intMaterialID						INTEGER				NOT NULL
	,strDescription						VARCHAR(100)		NOT NULL
	,monCost							MONEY				NOT NULL
	,intVendorID						INTEGER				NOT NULL
	,CONSTRAINT TMaterials_PK			PRIMARY KEY ( intMaterialID )
)

CREATE TABLE TVendors
(
	 intVendorID						INTEGER				NOT NULL
	,strVendorName						VARCHAR(50)			NOT NULL
	,strAddress							VARCHAR(50)			NOT NULL
	,strCity							VARCHAR(50)			NOT NULL
	,intStateID							INTEGER				NOT NULL
	,strZip								VARCHAR(50)			NOT NULL
	,strPhoneNumber						VARCHAR(50)			NOT NULL
	,CONSTRAINT TVendors_PK				PRIMARY KEY ( intVendorID )
)

CREATE TABLE TJobWorkers
(
	 intJobWorkerID						INTEGER				NOT NULL
	,intJobID							INTEGER				NOT NULL
	,intWorkerID						INTEGER				NOT NULL
	,intHoursWorked						INTEGER				NOT NULL
	,CONSTRAINT TCustomerJobWorkers_PK	PRIMARY KEY ( intJobWorkerID )
)

CREATE TABLE TWorkers
(
	 intWorkerID						INTEGER				NOT NULL
	 ,strFirstName						VARCHAR(50)			NOT NULL
	 ,strLastName						VARCHAR(50)			NOT NULL
	 ,strAddress						VARCHAR(50)			NOT NULL
	 ,strCity							VARCHAR(50)			NOT NULL
	 ,intStateID						INTEGER				NOT NULL
	 ,strZip							VARCHAR(50)			NOT NULL
	 ,strPhoneNumber					VARCHAR(50)			NOT NULL
	 ,dtmHireDate						DATE				NOT NULL
	 ,monHourlyRate						MONEY				NOT NULL
	 ,CONSTRAINT TWorkers_PK			PRIMARY KEY ( intWorkerID )
)

CREATE TABLE TWorkerSkills
(
	 intWorkerSkillID					INTEGER				NOT NULL
	,intWorkerID						INTEGER				NOT NULL
	,intSkillID							INTEGER				NOT NULL
	,CONSTRAINT	TWorkerSkills_PK		PRIMARY KEY ( intWorkerSkillID )
)

CREATE TABLE TSkills
(
	 intSkillID							INTEGER				NOT NULL
	,strSkill							VARCHAR(50)			NOT NULL
	,strDescription						VARCHAR(100)		NOT NULL
	,CONSTRAINT TSkills_PK				PRIMARY KEY ( intSkillID )
)

CREATE TABLE TStates
(
	 intStateID							INTEGER				NOT NULL
	,strState							VARCHAR(50)			NOT NULL
	,CONSTRAINT TStates_PK				PRIMARY KEY ( intStateID )
)

-- --------------------------------------------------------------------------------
-- Step 1.2: Create Foregin Key Constrants
-- --------------------------------------------------------------------------------
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TJobs							TCustomers					intCustomerID	
-- 2	TJobs							TStatuses					intStatusID
-- 3	TJobMaterials					TJobs						intJobID
-- 4	TJobMaterials					TMaterials					intMaterialID
-- 5	TJobWorkers						TJobs						intJobID 
-- 6	TJobWorkers						TWorkers					intWorkerID
-- 7	TMaterials						TVendors					intVendorID
-- 8	TCustomers						TStates						intStateID
-- 9	TWorkers						TStates						intStateID
-- 10	TVenders						TStates						intStateID
-- 11	TWorkerSkills					TWorkers					intWorkerID
-- 12	TWorkerSkills					TSkills						intSkillID

--1
ALTER TABLE TJobs ADD CONSTRAINT TJobs_TCustomers_FK 
FOREIGN KEY ( intCustomerID ) REFERENCES TCustomers ( intCustomerID )

--2
ALTER TABLE TJobs ADD CONSTRAINT TJobs_TStatuses_FK 
FOREIGN KEY ( intStatusID ) REFERENCES TStatuses ( intStatusID )

--3
ALTER TABLE TJobMaterials ADD CONSTRAINT TJobMaterials_TJobs_FK 
FOREIGN KEY ( intJobID ) REFERENCES TJobs ( intJobID )

--4
ALTER TABLE TJobMaterials ADD CONSTRAINT TJobMaterials_TProducts_FK 
FOREIGN KEY ( intMaterialID ) REFERENCES TMaterials ( intMaterialID )

--5
ALTER TABLE TJobWorkers ADD CONSTRAINT TJobWorkers_TJobs_FK 
FOREIGN KEY ( intJobID ) REFERENCES TJobs (intJobID )

--6
ALTER TABLE TJobWorkers	 ADD CONSTRAINT TJobWorkers_TWorkers_FK 
FOREIGN KEY ( intWorkerID ) REFERENCES TWorkers (intWorkerID )

--7
ALTER TABLE TMaterials ADD CONSTRAINT TMaterials_TVendors_FK 
FOREIGN KEY ( intVendorID ) REFERENCES TVendors (intVendorID )
--8
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates (intStateID )

--9
ALTER TABLE TWorkers ADD CONSTRAINT TWorkers_TStates_FK 
FOREIGN KEY (intStateID) REFERENCES TStates (intStateID)

--10
ALTER TABLE TVendors ADD CONSTRAINT TVendors_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates (intStateID )

--11
ALTER TABLE TWorkerSkills ADD CONSTRAINT TWorkerSkills_TWorkers_FK 
FOREIGN KEY ( intWorkerID ) REFERENCES TWorkers (intWorkerID )

--12
ALTER TABLE TWorkerSkills ADD CONSTRAINT TWorkerSkills_TSkills_FK 
FOREIGN KEY ( intSkillID ) REFERENCES TSkills (intSkillID )

-- --------------------------------------------------------------------------------
-- Step 2: Populate Each Table with Test Data
-- --------------------------------------------------------------------------------

INSERT INTO TStates( intStateID, strState )
VALUES	
	(1, 'Ohio'),
	(2, 'Kentucky'),
	(3, 'Indiana' ),
	(4, 'illinois')

INSERT INTO TCustomers(intCustomerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber)
VALUES	 
	(1, 'John', 'Doe', '123 Oak St', 'Columbus', 1, '43201', '555-123-4567'),
	(2, 'Jane', 'Smith', '456 Elm St', 'Lexington', 2, '40502', '555-987-6543'),
	(3, 'Robert', 'Johnson', '789 Main St', 'Indianapolis', 3, '46201', '555-321-7890'),
	(4, 'Susan', 'Williams', '101 Main St', 'Chicago', 4, '60601', '555-555-5555'),
	(5, 'Michael', 'Brown', '222 Main St', 'Louisville', 2, '40202', '555-111-2222');

INSERT INTO TStatuses (intStatusID,strStatus)
VALUES	 
	(1, 'Open'),
    (2, 'In Process'),
    (3, 'Complete')

INSERT INTO TJobs( intJobID, intCustomerID, intStatusID, dtmStartDate, dtmEndDate, strJobDesc)
VALUES	     
	(1, 1, 3, '2023-01-15', '2023-01-20', 'Fix leaking faucet in the kitchen and Kitchen Rewiring'),
	(2, 2, 1, '2023-02-05', '2023-02-10', 'Install new electrical outlets in the living room'),
	(3, 3, 2, '2023-03-10', '2023-03-15', 'Service HVAC system in the basement'),
	(4, 4, 3, '2023-04-20', '2023-04-25', 'Replace circuit breaker in the garage'),
	(5, 5, 1, '2023-05-01', '2023-05-05', 'Inspect and repair water heater in the bathroom'),
	(6, 1, 3, '2023-06-10', '2023-06-15', 'Repair electrical wiring in the bedroom'),
    (7, 2, 1, '2023-07-20', '2023-07-25', 'Install new HVAC system in the attic'),
    (8, 1, 3, '2023-08-05', '2023-08-10', 'Fixed plumbing issues in the bathroom'),
	(9, 1, 2, '2022-08-05', '2022-08-10', 'Fixed Air Conditioning Issues Throughout the House'),
	(10, 1, 3, '2023-09-15', '2023-09-20', 'Install new plumbing fixtures in the kitchen'),
	(11, 5, 1, '2018-09-5', '2018-09-10', 'Installed New Waterheater in the basement')


INSERT INTO TWorkers (intWorkerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, dtmHireDate, monHourlyRate)
VALUES
    (1, 'John', 'Smith', '123 Elm St', 'Columbus', 1, '43201', '555-123-4567', '2020-01-15', 25.50),
    (2, 'Sarah', 'Johnson', '456 Oak St', 'Lexington', 2, '40502', '555-987-6543', '2023-02-05', 28.75),
    (3, 'Michael', 'Brown', '789 Maple St', 'Indianapolis', 3, '46201', '555-321-7890', '2020-03-10', 23.00),
    (4, 'Emily', 'Davis', '101 Pine St', 'Chicago', 4, '60601', '555-555-5555', '2010-04-20', 26.00),
    (5, 'David', 'Wilson', '222 Birch St', 'Louisville', 2, '40202', '555-111-2222', '2019-05-01', 30.25)

INSERT INTO TSkills (intSkillID, strSkill, strDescription)
VALUES
    (1, 'Plumbing', 'Expertise in plumbing repairs and installations'),
    (2, 'Electrical', 'Proficiency in electrical wiring and installations'),
    (3, 'HVAC', 'Skills in heating, ventilation, and air conditioning systems'),
    (4, 'Carpentry', 'Experience in carpentry and woodworking'),
    (5, 'Painting', 'Ability to perform interior and exterior painting tasks');

INSERT INTO TWorkerSkills (intWorkerSkillID, intWorkerID, intSkillID)
VALUES
    (1, 1, 1), 
    (2, 2, 2), 
    (3, 3, 3), 
    (4, 4, 4), 
    (5, 5, 5), 
    (6, 1, 2), 
    (7, 2, 1); 

INSERT INTO TJobWorkers (intJobWorkerID, intJobID, intWorkerID, intHoursWorked)
VALUES
    (1, 1, 1, 8), 
    (2, 2, 2, 10), 
    (3, 3, 3, 6),  
    (4, 4, 4, 9),  
    (5, 5, 5, 7),  
    (6, 1, 2, 5),  
    (7, 2, 1, 7),  
	(8, 7, 4, 12), 
    (9, 8, 5, 8),  
    (10, 9, 1, 21),  
    (11, 10, 3, 8),  
	(12, 6, 4, 0),
	(13, 11, 3, 0)

INSERT INTO TVendors (intVendorID, strVendorName, strAddress, strCity, intStateID, strZip, strPhoneNumber)
VALUES
    (1, 'ABC Plumbing Supplies', '123 Plumbing Ave', 'Columbus', 1, '43201', '555-123-4567'),
    (2, 'XYZ Electrical Supply', '456 Electrical St', 'Lexington', 2, '40502', '555-987-6543'),
    (3, 'CoolTech HVAC Parts', '789 HVAC Rd', 'Indianapolis', 3, '46201', '555-321-7890'),
    (4, 'WoodWorks Lumber Co.', '101 Lumber Ln', 'Chicago', 4, '60601', '555-555-5555'),
    (5, 'ColorMaster Paints', '222 Painters Blvd', 'Louisville', 2, '40202', '555-111-2222');

INSERT INTO TMaterials (intMaterialID, strDescription, monCost, intVendorID)
VALUES
    (1, 'Faucet', 40.00, 1),
    (2, 'Electrical Wire', 2.00, 2),
    (3, 'HVAC Filter', 15.00, 3),
    (4, 'Lumber', 10.25, 4),
    (5, 'Paint', 20.00, 5),
	(6, 'Pipes', 10.00, 1),
	(7, 'Studs', 4.00, 4)

INSERT INTO TJobMaterials (intJobMaterialID, intJobID, intMaterialID, intQuantity)
VALUES
    (1, 1, 1, 2),  
    (2, 2, 2, 100), 
    (3, 3, 3, 4),  
    (4, 4, 4, 50),  
    (5, 5, 5, 10),
    (6, 1, 2, 5), 
    (7, 2, 1, 1),  
	(8, 6, 2, 30),
	(9, 7, 3, 5),
	(10,8, 6, 5),
	(11,9, 3, 4),
	(12,10,6, 7),
	(13,11,6, 5)

-- --------------------------------------------------------------------------------
-- Step 3: Update And Delete Statements
-- --------------------------------------------------------------------------------

-- 3.1: Create SQL to update data for a specific customer.

SELECT * FROM TCustomers

UPDATE TCustomers
SET strAddress = '444 Cherry St'
Where strLastName = 'Doe'

SELECT * FROM TCustomers

-- 3.2: Create SQL to increase the hourly rate by $2 for each worker that has been an employee for at least 1 year

SELECT * FROM TWorkers

UPDATE TWorkers
SET monHourlyRate = monHourlyRate + 2
WHERE DATEDIFF(year, dtmHireDate, getdate()) > 1

SELECT * FROM TWorkers

-- 3.3: Create SQL to delete a specific job that has associated work hours and materials assigned to it
SELECT *
FROM
TJobs

SELECT *
FROM
TJobWorkers

SELECT *
FROM
TJobMaterials

DELETE FROM TJobMaterials
WHERE intJobMaterialID = 13

DELETE FROM TJobWorkers
WHERE intJobWorkerID = 13

DELETE FROM TJobs
WHERE intJobID = 11

SELECT *
FROM
TJobs

SELECT *
FROM
TJobWorkers

SELECT *
FROM
TJobMaterials

-- --------------------------------------------------------------------------------
-- Step 4: Queries
-- --------------------------------------------------------------------------------
-- 4.1: Write a query to list all jobs that are in process
SELECT 
 intJobID
,strJobDesc
,dtmStartDate
,TC.intCustomerID
,strFirstName + ', ' + strLastName as Name
FROM
 TJobs as TJ
 JOIN TStatuses as TS
 ON TJ.intStatusID = TS.intStatusID
 JOIN TCustomers as TC
 ON TC.intCustomerID = TJ.intCustomerID
 WHERE
 strStatus = 'In Process' 
 ORDER BY
 intJobID


-- 4.2  Write a query to list all complete jobs for a specific customer and the materials used on each job

SELECT 
 TJ.intJobID
,strJobDesc
,strDescription
,strStatus
,intQuantity
,monCost as UnitCost
,(intQuantity * monCost) as TotalCost
FROM
 TJobs as TJ
 JOIN TStatuses as TS
 ON TJ.intStatusID = TS.intStatusID
 JOIN TCustomers as TC
 ON TC.intCustomerID = TJ.intCustomerID
 JOIN TJobMaterials as TJM
 ON tjm.intJobID = TJ.intJobID
 JOIN TMaterials as TM
 ON tjm.intMaterialID = TM.intMaterialID
 WHERE
 strStatus = 'Complete' and TC.intCustomerID = 1
 ORDER BY
  intJobID
 ,Tm.intMaterialID

 -- 4.3: Write a query to list the total cost for all materials for each completed job for the customer

  SELECT  
  SUM(monCost * intQuantity) as TotalCostOfJobMaterials
  FROM TJobs as TJ
  JOIN TCustomers as TC
  ON TC.intCustomerID = TJ.intCustomerID
  JOIN TStatuses as TS
  ON TS.intStatusID = TS.intStatusID
  JOIN TJobMaterials AS TJM
  ON TJ.intJobID = TJM.intJobID
  JOIN TMaterials as TM
  ON TJM.intMaterialID = TM.intMaterialID
  WHERE strStatus = 'Complete' and TC.intCustomerID = 1
  GROUP BY
  TJ.intJobID


-- 4.4: Write a query to list all jobs that have work entered for them. Include the job ID, job description, and job status description. List the total hours worked for each job with the lowest, highest, and average hourly rate

SELECT
 TJ.intJobID
,strJobDesc
,strStatus
,SUM(intHoursWorked) as TotalHoursWorked
,MIN(monHourlyRate) as MaxHourlyRate
,MAX(monHourlyRate) as MinHourlyRate
,AVG(monHourlyRate) as AverageHourlyRate
FROM
TJobs as TJ
JOIN TStatuses as TS
On TJ.intStatusID = TS.intStatusID
JOIN TJobWorkers as TJW
on TJW.intJobID = TJ.intJobID
JOIN TWorkers as TW
ON TJW.intWorkerID = TW.intWorkerID
WHERE intHoursWorked > 0
GROUP BY
 tj.intJobID
,strJobDesc
,strStatus
ORDER BY
AVG(monHourlyRate)


-- 4.5: Write a query that lists all materials that have not been used on any jobs

SELECT
 TM.intMaterialID
,strDescription
FROM
TJobs as TJ
RIGHT JOIN TJobMaterials as TJM
ON TJM.intJobID = TJ.intJobID
RIGHT JOIN TMaterials as TM
ON TM.intMaterialID = TJM.intMaterialID
WHERE intQuantity IS NULL
ORDER BY 
intMaterialID

-- 4.6: Create a query that lists all workers with a specific skill, their hire date, and the total number of jobs that they worked on

SELECT
 TW.intWorkerID
,strLastName  + ', ' + strFirstName as Name
,TS.intSkillID
,strSkill
,TS.strDescription
,dtmHireDate
,COUNT(TJ.intJobID) as TotalNumberOfJobsWorkedOn 
FROM
TJobs as TJ
JOIN TJobWorkers as TJW
ON tj.intJobID = TJW. intJobID
JOIN TWorkers as TW
ON TJW.intWorkerID = TW.intWorkerID
JOIN TWorkerSkills as TWS
ON TW.intWorkerID = TWS.intWorkerID
JOIN TSkills as TS
ON TWS.intSkillID = TS.intSkillID
GROUP BY
TW.intWorkerID
,strLastName
,strFirstName
,TS.intSkillID
,strSkill
,TS.strDescription
,dtmHireDate

-- 4.7: Create a query that lists all workers that worked greater than 20 hours for all jobs that they worked on.

SELECT
 TW.intWorkerID
,strLastName  + ', ' + strFirstName as Name
,COUNT(TJ.intJobID) as TotalNumberOfJobsWorkedOn
,SUM(intHoursWorked) as TotalHoursWorked
FROM
TJobs as TJ
JOIN TJobWorkers as TJW
ON TJ.intJobID = TJW.intJobID
JOIN TWorkers as TW
ON TW.intWorkerID = TJW.intJobWorkerID 
GROUP BY
 TW.intWorkerID
,TW.strFirstName
,TW.strLastName
HAVING 
SUM(intHoursWorked) > 20
ORDER BY TW.intWorkerID

-- 4.8: Create a query that includes the labor costs associated with each job.
SELECT
TC.intCustomerID
,TC.strLastName  + ', ' + TC.strFirstName as Name
,(intHoursWorked * monHourlyRate) as LaborCosts
FROM
TJobs as TJ
JOIN TCustomers as TC
ON TJ.intCustomerID = TC.intCustomerID
JOIN TJobWorkers as TJW
ON TJW.intJobID = TJ.intJobID
JOIN TWorkers as TW
ON TJW.intWorkerID = TW.intWorkerID

-- 4.9: Write a query that lists all customers who are located on 'Main Street'. Include the customer Id and full address
SELECT
intCustomerID
,strAddress
FROM
TCustomers as TC

WHERE 
strAddress LIKE '%Main St%'
--4.10: Write a query to list completed jobs that started and ended in the same month.
SELECT
 intJobID
,strStatus
,dtmStartDate
,dtmEndDate
FROM
TJobs as TJ
JOIN TCustomers as TC
ON TJ.intCustomerID = TC.intCustomerID
JOIN TStatuses as TS
ON TS.intStatusID = TJ.intStatusID
WHERE
MONTH (dtmstartdate) = MONTH(dtmEndDate)


-- 4.11: Create a query to list workers that worked on three or more jobs for the same customer

SELECT
TC.intCustomerID
,COUNT(TJ.intJobID) as TotalNumberOfWorkerWith3orMoreJobs
FROM
TJobs as TJ
JOIN TCustomers as TC
ON TC.intCustomerID = TJ.intCustomerID
JOIN TJobWorkers as TJW
ON TJW.intJobID = TJ.intJobID
JOIN TWorkers as TW
ON TW.intWorkerID = TJW.intWorkerID
GROUP BY
TW.intWorkerID,
TC.intCustomerID

-- 4.12: Create a query to list all workers and their total # of skills. Make sure that you have workers that have multiple skills and that you have at least 1 worker with no skills
SELECT 
COUNT(TS.strDescription) as TotalNumberOfSkillsForEachWorker
FROM
TWorkers as TW
JOIN TWorkerSkills as TWS
ON TWS.intWorkerID = TW.intWorkerID
JOIN TSkills as TS
ON TS.intSkillID = TWS.intSkillID
GROUP BY
TW.intWorkerID
ORDER BY
Tw.intWorkerID

-- 4.13: Write a query to list the total Charge to the customer for each job
SELECT
tj.intJobID
,SUM(intQuantity * monCost) + SUM(intHoursWorked * monHourlyRate) * 1.3 as TotalChargeForEachCustomer
FROM
TJobs as TJ
JOIN TCustomers as TC
ON TC.intCustomerID = TJ.intCustomerID
JOIN TJobMaterials as TJM
ON TJM.intJobID = TJ.intJobID
JOIN TMaterials as TM
ON TJM.intMaterialID = TM.intMaterialID
JOIN TJobWorkers as TJW
ON TJW.intJobID = Tj.intJobID
JOIN TWorkers as TW
on TJW.intWorkerID = TW.intWorkerID
GROUP BY
TJ.intJobID

-- 4.14: Write a query that totals what is owed to each vendor for a particular job. 
SELECT
Tj.intJobID
,SUM(intQuantity * monCost) as TotalAmountOwed
FROM
TJobs as TJ
JOIN TJobMaterials as TJM
ON TJ.intJobID = TJM.intJobID
JOIN TMaterials as TM
ON TM.intMaterialID = TJM.intMaterialID
JOIN TVendors as TV
ON TM.intVendorID = TV.intVendorID
GROUP BY
tj.intJobID