-- --------------------------------------------------------------------------------
-- Name: Nicholas Colvin
-- Class: IT-111 
-- Abstract: Test 2 Part 2
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE DBSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
--	Step #13 Add Drop Tables
-- --------------------------------------------------------------------------------

IF OBJECT_ID ('TCustomerPolicies')	IS NOT NULL DROP TABLE TCustomerPolicies
IF OBJECT_ID ('TCustomers')			IS NOT NULL DROP TABLE TCustomers
IF OBJECT_ID ('TClaims')			IS NOT NULL DROP TABLE TClaims
IF OBJECT_ID ('TPolicies')			IS NOT NULL DROP TABLE TPolicies
IF OBJECT_ID ('TAgents')			IS NOT NULL DROP TABLE TAgents
IF OBJECT_ID ('TStates')			IS NOT NULL DROP TABLE TStates
IF OBJECT_ID ('TRaces')				IS NOT NULL DROP TABLE TRaces
IF OBJECT_ID ('TGenders')			IS NOT NULL DROP TABLE TGenders
IF OBJECT_ID ('TCities')			IS NOT NULL DROP TABLE TCities
IF OBJECT_ID ('TIncomeRange')		IS NOT NULL DROP TABLE TIncomeRange
IF OBJECT_ID ('TMarriageStatus')	IS NOT NULL DROP TABLE TMarriageStatus
IF OBJECT_ID ('TRanks')				IS NOT NULL DROP TABLE TRanks



-- --------------------------------------------------------------------------------
-- Step #9 Create tables and insert data into those tables
-- --------------------------------------------------------------------------------

CREATE TABLE TCustomers
(
	 intCustomerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strSSN					VARCHAR(255)	NOT NULL
	,intCityID				INTEGER			NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,dtmDateOfBirth			DATETIME		NOT NULL
	,intRaceID				INTEGER			NOT NULL
	,intGenderID			INTEGER			NOT NULL
	,intIncomeRangeID		INTEGER			NOT NULL
	,intMarriageStatusID	INTEGER			NOT NULL
	,CONSTRAINT TCustomers_PK PRIMARY KEY ( intCustomerID )
)

CREATE TABLE TCities
(
	 intCityID			INTEGER			NOT NULL
	,strCity			VARCHAR(255)	NOT NULL
	,CONSTRAINT TCities_PK PRIMARY KEY ( intCityID )
)

CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)

CREATE TABLE TRaces
(
	 intRaceID			INTEGER			NOT NULL
	,strRace			VARCHAR(255)	NOT NULL
	,CONSTRAINT TRaces_PK PRIMARY KEY ( intRaceID )
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER			NOT NULL
	,strGender			VARCHAR(255)	NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TIncomeRange
(
	 intIncomeRangeID		INTEGER			NOT NULL
	,strIncomeRange			VARCHAR(255)	NOT NULL
	,CONSTRAINT TIncomeRange_PK PRIMARY KEY ( intIncomeRangeID )
)

CREATE TABLE TMarriageStatus
(
	 intMarriageStatusID		INTEGER			NOT NULL
	,strMarriageStatus			VARCHAR(255)	NOT NULL
	,CONSTRAINT TMarriageStatus_PK PRIMARY KEY ( intMarriageStatusID )
)

CREATE TABLE TAgents
(
	 intAgentID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strSSN					VARCHAR(255)	NOT NULL
	,intCityID				INTEGER			NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,dtmDateOfBirth			DATETIME		NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,intRaceID				INTEGER			NOT NULL
	,intGenderID			INTEGER			NOT NULL
	,intRankID				INTEGER			NOT NULL
	,CONSTRAINT TAgents_PK PRIMARY KEY ( intAgentID )
)

CREATE TABLE TRanks
(
	 intRankID			INTEGER			NOT NULL
	,strRank			VARCHAR(255)	NOT NULL
	,CONSTRAINT TRanks_PK PRIMARY KEY ( intRankID )
)

CREATE TABLE TPolicies
(
	 intPolicyID			INTEGER			NOT NULL
	,intPolicyNumber		INTEGER			NOT NULL
	,monDeductible			MONEY			NOT NULL
	,monCostofProduct		MONEY			NOT NULL
	,monRetailCost			MONEY			NOT NULL
	,monVauleOfInsured		MONEY			NOT NULL
	,strPolicyType			VARCHAR(255)	NOT NULL
	,dteDateOfPurchase		DATETIME		NOT NULL
	,intAgentID				INTEGER			NOT NULL
	,CONSTRAINT TProducts_PK PRIMARY KEY ( intPolicyID )
)



CREATE TABLE TClaims
(
	 intClaimID				INTEGER			NOT NULL
	,intPolicyID			INTEGER			NOT NULL
	,strClaimStatus			VARCHAR(255)	NOT NULL
	,strClaimReason			VARCHAR(255)	NOT NULL
	,intClaimAmount			INTEGER			NOT NULL
	,strClaimSpecialistName	VARCHAR(255)	NOT NULL
	,dtmDateOfClaim			DATETIME		NOT NULL
	,CONSTRAINT TClaims_PK PRIMARY KEY ( intClaimID )
)

CREATE TABLE TCustomerPolicies
(
	 intCustomerPoliciesID	INTEGER			NOT NULL
	,intCustomerID			INTEGER			NOT NULL
	,intPolicyID			INTEGER			NOT NULL
	,CONSTRAINT TCustomerPolicies_PK PRIMARY KEY ( intCustomerPoliciesID )
)


-- --------------------------------------------------------------------------------
-- Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')

INSERT INTO TCities( intCityID, strCity)
VALUES				(1, 'Cincinnati')
				   ,(2, 'Florence')
				   ,(3, 'Norwood')
				   ,(4, 'Milford')
				   ,(5, 'West Chester')

INSERT INTO TRaces( intRaceID, strRace)
VALUES				(1, 'Hispanic')
				   ,(2, 'African American')
				   ,(3, 'Cuacasion')
				   ,(4, 'Asian')

INSERT INTO TGenders( intGenderID, strGender)
VALUES				(1, 'Male')
				   ,(2, 'Female')
				   ,(3, 'Other')

INSERT INTO TIncomeRange( intIncomeRangeID, strIncomeRange)
VALUES				(1, '$20,001 - $50,000')
				   ,(2, '$50,001 - $100,000')
				   ,(3, 'Over $100,000')

INSERT INTO TMarriageStatus( intMarriageStatusID, strMarriageStatus)
VALUES				(1, 'Single')
				   ,(2, 'Married')


INSERT INTO TCustomers (intCustomerID, strFirstName, strLastName, strSSN, strAddress, intCityID, intStateID, strZip, dtmDateOfBirth, intRaceID, intGenderID, intIncomeRangeID, intMarriageStatusID)
VALUES				  (1, 'James', 'Jones', '111-00-1111', '321 Elm St.', 1, 1, '45201', '1/1/1997', 1, 1, 1, 1)
					 ,(2, 'Sally', 'Smith', '222-11-2222', '987 Main St.', 3, 1, '45218', '12/1/1999', 2, 2, 2, 2)
					 ,(3, 'Jose', 'Hernandez', '333-22-3333', '1569 Windisch Rd.', 5, 1, '45069', '9/23/1998', 1, 1, 3, 1)
					 ,(4, 'Lan', 'Kim', '444-33-4444', '44561 Oak Ave.', 4, 1, '45246', '6/11/1999', 4, 1, 2, 2)
					 ,(5, 'Bob', 'Nields', '555-44-5555', '44561 Oak Ave.', 4, 1, '45246', '6/11/1999', 4, 1, 3, 2)

INSERT INTO TClaims( intClaimID, strClaimStatus, strClaimReason, intClaimAmount, strClaimSpecialistName, intPolicyID, dtmDateOfClaim)
VALUES				(1, 'Pending', 'Car Accident', 5000, 'John Doe', 1, '2022-03-15')
				   ,(2, 'Approved', 'House Fire', 20000, 'Jane Smith', 4, '2023-05-27')
				   ,(3, 'Rejected', 'Water Damage', 3000, 'Alice Johnson', 2, '2021-07-10')
				   ,(4, 'Pending', 'Theft', 10000, 'Bob Martin', 5, '2019-09-22')
				   ,(5, 'Pending', 'Motorcycle Accident', 3000, 'Diana Prince', 3, '2020-11-05')


INSERT INTO TPolicies (intPolicyID, intPolicyNumber, monDeductible, monCostofProduct, monRetailCost, monVauleOfInsured, strPolicyType, dteDateOfPurchase, intAgentID)
VALUES (1, 1001, 500.00, 800.00, 900.00, 20000.00, 'Auto', '2023-01-10', 1)
	  ,(2, 1002, 600.00, 1200.00, 1400.00, 30000.00, 'Boat', '2020-03-15', 2)
	  ,(3, 1003, 300.00, 500.00, 550.00, 15000.00, 'Motorcycle', '2023-05-05', 5)
	  ,(4, 1004, 1000.00, 2500.00, 2700.00, 200000.00, 'Home', '2023-08-20', 3)
	  ,(5, 1005, 200.00, 350.00, 375.00, 50000.00, 'Renter', '2023-11-01', 4)

INSERT INTO TRanks( intRankID, strRank)
VALUES				(1, 'Junior Sales Agent')
				   ,(2, 'Sale Agent')
				   ,(3, 'Senior Sales Agent')

INSERT INTO TAgents (intAgentID, strFirstName, strLastName, strAddress, strSSN, intCityID, intStateID, strZip, dtmDateOfBirth, dtmDateOfHire, intRaceID, intGenderID, intRankID)
VALUES (1, 'Sarah', 'Johnson', '123 Main St', '123-45-6789', 1, 1, '12345', '1990-01-15 00:00:00', '2022-03-10 08:00:00', 1, 2, 2)
	   ,(2, 'David', 'Smith', '456 Elm St', '987-65-4321', 2, 2, '54321', '1985-07-20 00:00:00', '2021-05-05 09:30:00', 2, 1, 3)
	   ,(3, 'Rachel', 'Miller', '789 Oak Rd', '456-78-9012', 3, 3, '67890', '1982-11-03 00:00:00', '2020-12-01 10:15:00', 1, 2, 1)
	   ,(4, 'Daniel', 'Brown', '101 Pine Ln', '789-01-2345', 4, 1, '34567', '1995-04-25 00:00:00', '2023-02-20 11:45:00', 3, 2, 2)
	   ,(5, 'Laura', 'Wilson', '222 Cedar Dr', '555-12-3456', 5, 1, '45678', '1988-09-10 00:00:00', '2022-08-15 14:20:00', 4, 2, 2)


INSERT INTO TCustomerPolicies (intCustomerPoliciesID, intCustomerID, intPolicyID)
VALUES
    (1, 1, 2),
    (2, 2, 1),
    (3, 3, 3),
    (4, 4, 4),
    (5, 5, 5);

-- --------------------------------------------------------------------------------
--	Step #10 and 12 : Establish Referential Integrity and Create Foreign Key Constranits
-- --------------------------------------------------------------------------------
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TClaims							TPolicies					intPolicyID
-- 2	TPolicies						TAgents						IntAgentID
-- 3	TCustomerPolicies				TPolicies					intPolicyID
-- 4	TCustomerPolicies				TCustomers					intCustomerID
-- 5	TCustomers						TStates						intStateID
-- 6	TCustomers						TCities						intCityID
-- 7	TCustomers						TGenders					intGenderID
-- 8	TCustomers						TRaces						intRaceID
-- 9	TCustomers						TIncomeRange				intIncomeRangeID
-- 10	TCustomers						TMarriageStatus				intMarriageStatusID
-- 11	TAgents							TStates						intStateID
-- 12	TAgents							TCities						intCityID
-- 13	TAgents							TGenders					intGenderID
-- 14	TAgents							TRaces						intRaceID


--1
ALTER TABLE TClaims ADD CONSTRAINT TClaims_TPolicies_FK 
FOREIGN KEY ( intPolicyID ) REFERENCES TPolicies ( intPolicyID )

--2
ALTER TABLE TPolicies ADD CONSTRAINT TPolicies_TAgents_FK 
FOREIGN KEY ( IntAgentID ) REFERENCES TAgents ( IntAgentID )

--3
ALTER TABLE TCustomerPolicies ADD CONSTRAINT TCustomerPolicies_TPolicies_FK 
FOREIGN KEY ( intPolicyID ) REFERENCES TPolicies ( intPolicyID )

--4
ALTER TABLE TCustomerPolicies ADD CONSTRAINT TCustomerPolicies_TCustomers_FK 
FOREIGN KEY ( intCustomerID ) REFERENCES TCustomers ( intCustomerID )

--5
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) ON DELETE CASCADE

--6
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TGenders_FK 
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID ) ON DELETE CASCADE

--7
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TRaces_FK 
FOREIGN KEY ( intRaceID ) REFERENCES TRaces ( intRaceID ) ON DELETE CASCADE

--8
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TIncomeRange_FK 
FOREIGN KEY ( intIncomeRangeID ) REFERENCES TIncomeRange ( intIncomeRangeID ) 

--9
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TMarriageStatus_FK 
FOREIGN KEY ( intMarriageStatusID ) REFERENCES TMarriageStatus ( intMarriageStatusID )

--10
ALTER TABLE TCustomers ADD CONSTRAINT TCustomers_TCities_FK 
FOREIGN KEY ( intCityID ) REFERENCES TCities ( intCityID ) ON DELETE CASCADE

--11
ALTER TABLE TAgents ADD CONSTRAINT TAgents_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) ON DELETE CASCADE

--12
ALTER TABLE TAgents ADD CONSTRAINT TAgents_TCities_FK 
FOREIGN KEY ( intCityID ) REFERENCES TCities ( intCityID ) ON DELETE CASCADE
--13
ALTER TABLE TAgents ADD CONSTRAINT TAgents_TGenders_FK 
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID ) ON DELETE CASCADE

--14
ALTER TABLE TAgents ADD CONSTRAINT TAgents_TRaces_FK 
FOREIGN KEY ( intRaceID ) REFERENCES TRaces ( intRaceID ) ON DELETE CASCADE


select * from TAgents

-- --------------------------------------------------------------------------------
--	Step #15 Write the EXPLICIT SQL Select Statements
-- --------------------------------------------------------------------------------

-- a.
Select	 TC.intCustomerID
		,TC.strFirstName
		,TC.strLastName
		,TP.strPolicyType
		,TP.intPolicyNumber
From TCustomers AS TC 
	JOIN TCustomerPolicies as TCP
		ON TC.intCustomerID = TCP.intCustomerID
	JOIN TPolicies AS TP
		ON TCP.intPolicyID = TP.intPolicyID

-- b.
Select	 TC.intCustomerID
		,TC.strFirstName
		,TC.strLastName
		,TCA.strClaimStatus
		,TCA.intClaimID
From TCustomers AS TC 
	JOIN TCustomerPolicies as TCP
		ON TC.intCustomerID = TCP.intCustomerID
	JOIN TPolicies AS TP
		ON TCP.intPolicyID = TP.intPolicyID
	JOIN TClaims AS TCA
		ON TP.intPolicyID = TCA.intPolicyID
WHERE TCA.strClaimStatus = 'Pending'

-- c.
Select	 TC.intCustomerID
		,TC.strFirstName
		,TC.strLastName
		,TCA.strClaimStatus
		,TCA.intClaimID
		,TG.strGender
From TCustomers AS TC 
	JOIN TCustomerPolicies as TCP
		ON TC.intCustomerID = TCP.intCustomerID
	JOIN TPolicies AS TP
		ON TCP.intPolicyID = TP.intPolicyID
	JOIN TClaims AS TCA
		ON TP.intPolicyID = TCA.intPolicyID
	JOIN TGenders AS TG
		ON TC.intGenderID = TG.intGenderID
WHERE TP.strPolicyType = 'Auto' and TG.strGender = 'Male'

-- d.

Select	 TC.intCustomerID
		,TC.strFirstName
		,TC.strLastName
		,TP.strPolicyType
		,TP.intPolicyNumber
		,TP.monCostofProduct
		,TA.intAgentID
		,TA.strFirstName
		,TA.strLastName
From TCustomers AS TC 
	JOIN TCustomerPolicies as TCP
		ON TC.intCustomerID = TCP.intCustomerID
	JOIN TPolicies AS TP
		ON TCP.intPolicyID = TP.intPolicyID
	JOIN TAgents as TA
		ON TP.intAgentID = TA.intAgentID

-- e.

Select	 TCA.strClaimSpecialistName
		,TCA.dtmDateOfClaim
		,TCA.strClaimStatus
		,TP.dteDateOfPurchase
		,TP.strPolicyType
		,TC.intCustomerID
		,TC.strFirstName
		,TC.strLastName
From TCustomers AS TC 
	JOIN TCustomerPolicies as TCP
		ON TC.intCustomerID = TCP.intCustomerID
	JOIN TPolicies AS TP
		ON TCP.intPolicyID = TP.intPolicyID
	JOIN TClaims AS TCA
		ON TP.intPolicyID = TCA.intPolicyID
WHERE TCA.strClaimStatus = 'Rejected'