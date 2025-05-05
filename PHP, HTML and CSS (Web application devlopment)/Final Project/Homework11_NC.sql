-- --------------------------------------------------------------------------------
-- Name: Nicholas Colvin
-- Class: WAPP 1
-- Abstract: Homework 11 - First Database!
-- --------------------------------------------------------------------------------

-- USE --;
USE dbTesting;
-- DROP STATEMENTS
DROP TABLE IF EXISTS TEventGolferSponsors;
DROP TABLE IF EXISTS TEventGolfers;
DROP TABLE IF EXISTS TEvents;
DROP TABLE IF EXISTS TGolfers;
DROP TABLE IF EXISTS TShirtSizes;
DROP TABLE IF EXISTS TGenders;
DROP TABLE IF EXISTS TStates;
DROP TABLE IF EXISTS TPaymentTypes;
DROP TABLE IF EXISTS TPaymentStatuses;
DROP TABLE IF EXISTS TSponsors;
DROP TABLE IF EXISTS TAdmins;

-- --------------------------------------------------------------------------------
-- Step #1 : Create Tables
-- --------------------------------------------------------------------------------

CREATE TABLE TEvents(
  intEventID  INT NOT NULL,
  dtmEventYear VARCHAR(255) NOT NULL,
  PRIMARY KEY (intEventID)
);


CREATE TABLE TAdmins(
  intAdminID  INT NOT NULL,
  strFirstName VARCHAR(255) NOT NULL,
  strLastName VARCHAR(255) NOT NULL,
  strUserName VARCHAR(255) NOT NULL,
  strPassword VARCHAR(255) NOT NULL,
  PRIMARY KEY (intAdminID)
);


CREATE TABLE TEventGolfers(
  intEventGolferID  INT NOT NULL,
  intEventID  INT NOT NULL,
  intGolferID INT NOT NULL,
  PRIMARY KEY (intEventGolferID) 
);



CREATE TABLE TEventGolferSponsors(
  intEventGolferSponsorID INT NOT NULL,
  intEventGolferID INT NOT NULL,
  intSponsorID INT NOT NULL,
  dtmDateOfPledge DATE NOT NULL,
  dblPledgePerHole DOUBLE NOT NULL,
  intPaymentTypeID INT NOT NULL,
  intPaymentStatusID INT NOT NULL,
  PRIMARY KEY (intEventGolferSponsorID)
);



CREATE TABLE TSponsors(
  intSponsorID INT NOT NULL,
  strFirstName VARCHAR(255) NOT NULL,
  strLastName VARCHAR(255) NOT NULL,
  strAddress VARCHAR(255) NOT NULL,
  strCity VARCHAR(255) NOT NULL,
  intStateID INT NOT NULL,
  strZipCode VARCHAR(255) NOT NULL,
  strPhoneNumber VARCHAR(255) NOT NULL,
  strEmail VARCHAR(255) NOT NULL,
  PRIMARY KEY (intSponsorID) 
);



CREATE TABLE TPaymentTypes(
  intPaymentTypeID INT NOT NULL,
  strPaymentType VARCHAR(255) NOT NULL,
  PRIMARY KEY (intPaymentTypeID)
);



CREATE TABLE TPaymentStatuses(
  intPaymentStatusID INT NOT NULL,
  strPaymentStatus VARCHAR(255) NOT NULL,
  PRIMARY KEY (intPaymentStatusID)
);



CREATE TABLE TGolfers(
  intGolferID INT NOT NULL,
  strFirstName VARCHAR(255) NOT NULL,
  strLastName VARCHAR(255) NOT NULL,
  strAddress VARCHAR(255) NOT NULL,
  strCity VARCHAR(255) NOT NULL,
  intStateID INT NOT NULL,
  strZipCode VARCHAR(255) NOT NULL,
  strPhoneNumber VARCHAR(255) NOT NULL,
  strEmail VARCHAR(255) NOT NULL,
  intShirtSizeID INT NOT NULL,
  intGenderID INT NOT NULL,
  PRIMARY KEY (intGolferID)
);



CREATE TABLE TGenders(
  intGenderID INT NOT NULL,
  strGender VARCHAR(255) NOT NULL,
  PRIMARY KEY (intGenderID)
);



CREATE TABLE TStates(
  intStateID INT NOT NULL,
  strState VARCHAR(255) NOT NULL,
  PRIMARY KEY (intStateID)
);



CREATE TABLE TShirtSizes(
  intShirtSizeID INT NOT NULL,
  strShirtSize VARCHAR(255) NOT NULL,
  PRIMARY KEY (intShirtSizeID)
);

-- --------------------------------------------------------------------------------
-- Step #2 : Establish Referential Integrity
-- --------------------------------------------------------------------------------
-- CHILD           			 PARENT                ID
-- 1 TEventGolfers      	 TEvents               intEventID
-- 2 TEventGolfers	         TGolfers              intGolferID
-- 3 TGolfers            	 TStates        	   intStateID
-- 4 TGolfers        		 TShirtSizes           intShirtSizeID
-- 5 TGolfers        		 TGenders              intGenderID
-- 6 TEventGolferSponsors    TEventGolfers         intEventGolferID
-- 7 TEventGolferSponsors    TSponser              intSponsorID
-- 8 TEventGolferSponsors    TPaymentStatuses      intPaymentStatusID
-- 9 TEventGolferSponsors    TPaymentTypes         intPaymentTypeID



-- 1
ALTER TABLE TEventGolfers ADD CONSTRAINT TEventGolfers_TEvents_FK
FOREIGN KEY (intEventID) REFERENCES TEvents(intEventID);

-- 2
ALTER TABLE TEventGolfers ADD CONSTRAINT TEventGolfers_TGolfers_FK
FOREIGN KEY (intGolferID) REFERENCES TGolfers(intGolferID);

-- 3
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TStates_FK
FOREIGN KEY (intStateID) REFERENCES TStates(intStateID);

-- 4
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY (intShirtSizeID) REFERENCES TShirtSizes(intShirtSizeID);

-- 5
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY (intGenderID) REFERENCES TGenders(intGenderID);

-- 6
ALTER TABLE TEventGolferSponsors ADD CONSTRAINT TEventGolferSponsors_TEventGolfers_FK
FOREIGN KEY (intEventGolferID) REFERENCES TEventGolfers(intEventGolferID);

-- 7
ALTER TABLE TEventGolferSponsors ADD CONSTRAINT TEventGolferSponsors_TSponser_FK
FOREIGN KEY (intSponsorID) REFERENCES TSponsors(intSponsorID);

-- 8
ALTER TABLE TEventGolferSponsors ADD CONSTRAINT TEventGolferSponsors_TPaymentStatuses_FK
FOREIGN KEY (intPaymentStatusID) REFERENCES TPaymentStatuses(intPaymentStatusID);

-- 9
ALTER TABLE TEventGolferSponsors ADD CONSTRAINT TEventGolferSponsors_TPaymentTypes_FK
FOREIGN KEY (intPaymentTypeID) REFERENCES TPaymentTypes(intPaymentTypeID);


-- --------------------------------------------------------------------------------
-- Step #3 : Inserts
-- --------------------------------------------------------------------------------


INSERT INTO TPaymentTypes( intPaymentTypeID, strPaymentType )
VALUES	 ( 1, 'Check' )
		,( 2, 'Cash' )
		,( 3, 'Credit Card' );


INSERT INTO TPaymentStatuses( intPaymentStatusID, strPaymentStatus)
VALUES	 ( 1, 'Unpaid' )
		,( 2, 'Paid' );


INSERT INTO TShirtSizes(intShirtSizeID, strShirtSize )
VALUES	 ( 1, 'Mens Small' )
		,( 2, 'Mens Medium' )
		,( 3, 'Mens Large' )
		,( 4, 'Mens XLarge' )
		,( 5, 'Womens Small' )
		,( 6, 'Womens Medium' )
		,( 7, 'Womens Large' )
		,( 8, 'Womens XLarge' );


INSERT INTO TStates ( intStateID, strState )
VALUES	 ( 1, 'Ohio' )
		,( 2, 'Kentucky' )
		,( 3, 'Indiana' );


INSERT INTO TGenders ( intGenderID, strGender )
VALUES	 ( 1, 'Male' )
		,( 2, 'Female' );


INSERT INTO TAdmins ( intAdminID, strFirstName, strLastName, strUserName, strPassword)
VALUES	 ( 1, 'Ima', 'Soring', 'isoring', 'ispassword');


INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strAddress, strCity, intStateID, strZipCode, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
VALUES	 ( 1, 'Ima', 'Knapp', '414 Knapp Street', 'Dayton', 1, "55555", "888-888-8888", "iknapp@example.com", 3, 1),
		 ( 2, 'John', 'Doe', '414 Doe Street', 'Kenton', 2, "55555", "777-774-7777", "jdoe@example.com", 2, 1),
         ( 3, 'Arrow', 'Smith', '414 Smith Street', 'Cincinnati', 1, "55555", "777-775-7777", "asmith@example.com", 2, 1),
         ( 4, 'Jen', 'Smith', '414 Smith Street', 'Cincinnati', 1, "55555", "777-776-7777", "jsmith@example.com", 6, 2);


INSERT INTO TEvents ( intEventID, dtmEventYear )
VALUES	 ( 1, 2025 )
		,( 2, 2022 );


INSERT INTO TEventGolfers ( intEventGolferID, intEventID, intGolferID)
VALUES	 ( 1, 1, 1),
		 ( 2, 1, 2),
         ( 3, 2, 3);


INSERT INTO TSponsors (intSponsorID, strFirstName, strLastName, strAddress, strCity, intStateID, strZipCode, strPhoneNumber, strEmail) 
VALUES   (1, 'Emily', 'Johnson', '123 Oak Street', 'Cincinnati', 35, '45202', '513-555-1234', 'emily.johnson@example.com'),
		 (2, 'Michael', 'Thompson', '456 Pine Lane', 'Columbus', 35, '43215', '614-555-5678', 'michael.thompson@example.org'),
		 (3, 'Sarah', 'Lopez', '789 Maple Ave', 'Cleveland', 35, '44114', '216-555-7890', 'sarah.lopez@example.net'),
		 (4, 'David', 'Nguyen', '321 Birch Blvd', 'Toledo', 35, '43604', '419-555-2468', 'david.nguyen@example.com'),
		 (5, 'Olivia', 'Brown', '555 Cedar Dr', 'Dayton', 35, '45402', '937-555-1357', 'olivia.brown@example.org');


INSERT INTO TEventGolferSponsors ( intEventGolferSponsorID, intEventGolferID, intSponsorID, dtmDateOfPledge, dblPledgePerHole, intPaymentTypeID, intPaymentStatusID)
VALUES	 (1, 1, 1, '2025/5/1', 10.00, 1, 2),
		 (2, 1, 1, '2025/5/2', 5.00, 2, 2),
         (3, 2, 1, '2025/5/2', 3.00, 2, 2),
         (4, 2, 1, '2025/5/1', 15.00, 3, 1);


-- --------------------------------------------------------------------------------
-- Step #3 : Select Statements
-- --------------------------------------------------------------------------------

-- 1
SELECT intEventID
FROM TEvents 
ORDER BY dtmEventYear DESC LIMIT 1; 

-- 2
SELECT TG.intGolferID, TG.strFirstName, TG.strLastName FROM TGolfers as TG 
LEFT JOIN TEventGolfers as TEG on TG.intGolferID = TEG.intGolferID and TEG.intEventID = 1
WHERE TEG.intGolferID IS NULL;

-- 3
SELECT MAX(TEG.intEventID) from teventgolfers as TEG JOIN tevents as TE ON TE.intEventID = TEG.intEventID WHERE dtmEventYear = YEAR(current_date());

 -- 4: Total earned per golfer
SELECT SUM(dblPledgePerHole * 100) as TotalGolferEarnings, TG.intGolferID, strFirstName, strLastName  
FROM TGolfers as TG 
JOIN teventgolfers as TEG on TEG.intGolferID = TG.intGolferID
JOIN teventgolfersponsors as TEGS on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = 1 
AND TEGS.intPaymentStatusID = 2
GROUP BY
TG.intGolferID,
strFirstName,
strLastName;

-- 5: Total pledged
SELECT SUM(dblPledgePerHole * 100) as TotalAmountPlegedPerHole
FROM TEventGolferSponsors AS TEGS
JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = 1;

-- 6: Total earned
SELECT SUM(dblPledgePerHole * 100) as TotalAmountPlegedPerHole
FROM TEventGolferSponsors AS TEGS
JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = 1 and intPaymentStatusID = 2;

-- 8: Golfer who has rasied the most
SELECT TG.strFirstName, TG.strLastName, SUM(dblPledgePerHole * 100) as TotalRaised
FROM TEventGolferSponsors as TEGS
JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
JOIN TGolfers as TG on TG.intGolferID = TEG.intGolferID
GROUP BY
strFirstName,
strLastName
ORDER BY
TotalRaised
DESC LIMIT 1;

-- 9: Total Number of golfers
SELECT COUNT(intGolferID)
FROM teventgolfers
WHERE intEventID = 1;

-- 9: Player donor list
SELECT 
strFirstName, strLastName, dblPledgePerHole* 100 as DonationAmount, strPaymentStatus
FROM
TSponsors as TS
JOIN TEventGolferSponsors as TEGS on TS.intSponsorID = TEGS.intSponsorID
JOIN tpaymentstatuses as TPS on TPS.intPaymentStatusID = TEGS.intPaymentStatusID
WHERE
TEGS.intEventGolferID = 1;

-- Total Pledges per golfer
SELECT TG.intGolferID, TG.strFirstName, TG.strLastName, SUM(dblPledgePerHole* 100) as DonationAmount
FROM TGolfers as TG
LEFT JOIN teventgolfers as TEG ON TG.intGolferID = TEG.intGolferID
LEFT JOIN TEventGolferSponsors as TEGS on TEG.intEventGolferID = TEGS.intEventGolferID
GROUP BY
TG.intGolferID,
TS.strFirstName,
TS.strLastName
ORDER BY
DonationAmount DESC;

-- Total Number of donations
SELECT COUNT(*) as TotalDonations
FROM TEventGolferSponsors AS TEGS
JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = 1;


-- Average donation
SELECT AVG(dblPledgePerHole* 100) as AverageDonation
FROM TEventGolferSponsors AS TEGS
JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = 1;