-- --------------------------------------------------------------------------------
-- Name:  
-- Class: IT-111 
-- Abstract: Assignment 13 Solution
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE  DBSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
--						 
-- --------------------------------------------------------------------------------

-- Drop Table Statements


IF OBJECT_ID ('TCustomerSongs')		IS NOT NULL DROP TABLE TCustomerSongs
IF OBJECT_ID ('TCustomers')			IS NOT NULL DROP TABLE TCustomers
IF OBJECT_ID ('TCities')			IS NOT NULL DROP TABLE TCities
IF OBJECT_ID ('TStates')			IS NOT NULL DROP TABLE TStates
IF OBJECT_ID ('TRaces')				IS NOT NULL DROP TABLE TRaces
IF OBJECT_ID ('TGenders')			IS NOT NULL DROP TABLE TGenders
IF OBJECT_ID ('TSongs')				IS NOT NULL DROP TABLE TSongs
IF OBJECT_ID ('TGenres')			IS NOT NULL DROP TABLE TGenres
IF OBJECT_ID ('TRecordLabels')		IS NOT NULL DROP TABLE TRecordLabels
IF OBJECT_ID ('TArtists')			IS NOT NULL DROP TABLE TArtists


-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TCustomers
(
	 intCustomerID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(255)	NOT NULL
	,strLastName		VARCHAR(255)	NOT NULL
	,strAddress			VARCHAR(255)	NOT NULL
	,intCityID			INTEGER			NOT NULL
	,intStateID			INTEGER			NOT NULL
	,strZip				VARCHAR(255)	NOT NULL
	,dtmDateOfBirth		DATETIME		NOT NULL
	,intRaceID			INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
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

CREATE TABLE TSongs
(
	 intSongID			INTEGER			NOT NULL
	,intArtistID		INTEGER			NOT NULL
	,strSongName		VARCHAR(255)	NOT NULL
	,intGenreID			INTEGER			NOT NULL
	,intRecordLabelID	INTEGER			NOT NULL
	,dtmDateRecorded	DATETIME		NOT NULL
	,CONSTRAINT TSongs_PK PRIMARY KEY ( intSongID )
)

CREATE TABLE TGenres
(
	 intGenreID			INTEGER			NOT NULL
	,strGenre			VARCHAR(255)	NOT NULL
	,CONSTRAINT TGenres_PK PRIMARY KEY ( intGenreID )
)

CREATE TABLE TRecordLabels
(
	 intRecordLabelID			INTEGER			NOT NULL
	,strRecordLabel				VARCHAR(255)	NOT NULL
	,CONSTRAINT TRecordLabels_PK PRIMARY KEY ( intRecordLabelID )
)

CREATE TABLE TArtists
(
	 intArtistID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(255)	NOT NULL
	,strLastName		VARCHAR(255)	NOT NULL
	,CONSTRAINT TArtists_PK PRIMARY KEY ( intArtistID )
)

CREATE TABLE TCustomerSongs
(
	 intCustomerSongID	INTEGER			NOT NULL
	,intCustomerID		INTEGER			NOT NULL
	,intSongID			INTEGER			NOT NULL
	,CONSTRAINT TCustomerSongs_PK PRIMARY KEY (  intCustomerSongID )
)


-- --------------------------------------------------------------------------------
--	Step #2 : Establishing Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TSongs							TArtists					intArtistID						 
-- 2	TCustomerSongs					TCustomers					intCustomerID 
-- 3	TCustomerSongs					TSongs						intSongID
-- 4	TCustomers						TStates						intStateID
-- 5	TCustomers						TCities						intCityID
-- 6	TCustomers						TGenders					intGenderID
-- 7	TCustomers						TRaces						intRaceID
-- 8	TSongs							TGenres						intGenreID
-- 9	TSongs							TRecordLabels				intRecordLabelID

--1
ALTER TABLE TSongs ADD CONSTRAINT TSongs_TArtists_FK 
FOREIGN KEY ( intArtistID ) REFERENCES TArtists ( intArtistID ) ON DELETE CASCADE

--2
ALTER TABLE TCustomerSongs	 ADD CONSTRAINT TCustomerSongs_TCustomers_FK 
FOREIGN KEY ( intCustomerID ) REFERENCES TCustomers ( intCustomerID ) ON DELETE CASCADE

--3
ALTER TABLE TCustomerSongs	 ADD CONSTRAINT TCustomerSongs_TSongs_FK 
FOREIGN KEY ( intSongID ) REFERENCES TSongs ( intSongID ) ON DELETE CASCADE

--4
ALTER TABLE TCustomers	 ADD CONSTRAINT TCustomers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates (intStateID ) ON DELETE CASCADE

--5
ALTER TABLE TCustomers	 ADD CONSTRAINT TCustomers_TCities_FK 
FOREIGN KEY ( intCityID ) REFERENCES TCities (intCityID ) ON DELETE CASCADE

--6
ALTER TABLE TCustomers	 ADD CONSTRAINT TCustomers_TRaces_FK 
FOREIGN KEY ( intRaceID ) REFERENCES TRaces (intRaceID ) ON DELETE CASCADE

--7
ALTER TABLE TCustomers	 ADD CONSTRAINT TCustomers_TGenders_FK 
FOREIGN KEY ( intGenderID ) REFERENCES TGenders (intGenderID ) ON DELETE CASCADE

--8
ALTER TABLE TSongs	ADD CONSTRAINT TSongs_TGenre_FK 
FOREIGN KEY ( intGenreID ) REFERENCES TGenres (intGenreID ) ON DELETE CASCADE

--9
ALTER TABLE TSongs	ADD CONSTRAINT TSongs_TRecordLabels_FK 
FOREIGN KEY ( intRecordLabelID ) REFERENCES TRecordLabels (intRecordLabelID ) ON DELETE CASCADE

-- --------------------------------------------------------------------------------
--	Step #3 : Add Sample Data - INSERTS
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

INSERT INTO TCustomers (intCustomerID, strFirstName, strLastName, strAddress, intCityID, intStateID, strZip, dtmDateOfBirth, intRaceID, intGenderID)
VALUES				  (1, 'James', 'Jones', '321 Elm St.', 1, 1, '45201', '1/1/1997', 1, 1)
					 ,(2, 'Sally', 'Smith', '987 Main St.', 3, 1, '45218', '12/1/1999', 2, 2)
					 ,(3, 'Jose', 'Hernandez', '1569 Windisch Rd.', 5, 1, '45069', '9/23/1998', 1, 1)
					 ,(4, 'Lan', 'Kim', '44561 Oak Ave.', 4, 1, '45246', '6/11/1999', 4, 1)

INSERT INTO TArtists( intArtistID, strFirstName, strLastName)
VALUES				(1, 'Bob', 'Nields')
				   ,(2, 'Ray', 'Harmon')
				   ,(3, 'Pam', 'Ransdell')

INSERT INTO TGenres( intGenreID, strGenre)
VALUES				(1, 'Rock')
				   ,(2, 'Pop')
				   ,(3, 'Blues')
				   ,(4, 'Country')

INSERT INTO TRecordLabels( intRecordLabelID, strRecordLabel )
VALUES				(1, 'MyOwn')
				   ,(2, 'HisOwn')
				   ,(3, 'CountingToes')
				   ,(4, 'DeepMusic')

INSERT INTO TSongs ( intSongID, intArtistID, strSongName, intGenreID, intRecordLabelID, dtmDateRecorded)
VALUES				 ( 1, 1,'Hey Jude', 1, 1, '8/28/2017')
					,( 2, 2,'School House Rock', 1, 2, '8/28/2007')
					,( 3, 3,'Rocking on the Porch', 4, 3, '8/28/1997')
					,( 4, 1,'Blue Jude', 3, 4, '8/28/2009')

INSERT INTO TCustomerSongs (intCustomerSongID, intCustomerID, intSongID)
VALUES				    	( 1, 1, 1)
						   ,( 2, 1, 2)
						   ,( 3, 1, 3)
						   ,( 4, 1, 4)
						   ,( 5, 2, 2)
						   ,( 6, 2, 3)
						   ,( 7, 3, 4)
						   ,( 8, 4, 1)
						   ,( 9, 4, 4)

-- --------------------------------------------------------------------------------
--	Explicit Join Examples 
-- --------------------------------------------------------------------------------


SELECT TC.strFirstName, TC.strLastName, TG.strGender, TS.strSongName
FROM TCustomers as TC
	 JOIN TGenders as TG 
		 ON TC.intGenderID = TG.intGenderID

	 Join TCustomerSongs as TCS 
		 ON TCS.intCustomerID = TC.intCustomerID

	 Join TSongs as TS 
		 ON TCS.intSongID = TS.intSongID
		
Where TG.strGender = 'Female'



SELECT TC.strFirstName, TC.strLastName, TG.strGender, TS.strSongName
FROM TCustomers as TC
	 ,TGenders as TG 
	 ,TCustomerSongs as TCS 
	 ,TSongs as TS 	 
Where 
TC.intGenderID = TG.intGenderID
and TCS.intCustomerID = TC.intCustomerID
and TCS.intSongID = TS.intSongID
and TG.strGender = 'Female'


-- --------------------------------------------------------------------------------
--	Explicit Joins
-- --------------------------------------------------------------------------------

-- 1
SELECT TC.strFirstName, TC.strLastName, TG.strGender, TS.strSongName
FROM TCustomers as TC
	 JOIN TGenders as TG 
		 ON TC.intGenderID = TG.intGenderID

	 Join TCustomerSongs as TCS 
		 ON TCS.intCustomerID = TC.intCustomerID

	 Join TSongs as TS 
		 ON TCS.intSongID = TS.intSongID

-- 2

SELECT TS.strSongName, TS.dtmDateRecorded, TR.strRecordLabel
FROM TSongs as TS 
	 JOIN TRecordLabels as TR
		ON TS.intRecordLabelID = TR.intRecordLabelID
WHERE TS.dtmDateRecorded > '1/1/2010'
ORDER BY TR.strRecordLabel, TS.strSongName

-- 3

SELECT TC.strFirstName, TC.strLastName, TG.strGender, TS.strSongName, TA.strFirstName, TA.strLastName
FROM TCustomers as TC
	 JOIN TGenders as TG 
		 ON TC.intGenderID = TG.intGenderID

	 Join TCustomerSongs as TCS 
		 ON TCS.intCustomerID = TC.intCustomerID

	 Join TSongs as TS 
		 ON TCS.intSongID = TS.intSongID

	 JOIN TArtists as TA 
		 ON TS.intArtistID = TA.intArtistID
ORDER BY TG.strGender

-- 4

SELECT TC.strFirstName, TC.strLastName, TG.strGender, TS.strSongName, TA.strFirstName, TA.strLastName
FROM TCustomers as TC
	 JOIN TGenders as TG 
		 ON TC.intGenderID = TG.intGenderID

	 Join TCustomerSongs as TCS 
		 ON TCS.intCustomerID = TC.intCustomerID

	 Join TSongs as TS 
		 ON TCS.intSongID = TS.intSongID

	 JOIN TArtists as TA 
		 ON TS.intArtistID = TA.intArtistID
WHERE TG.strGender = 'Female'
ORDER BY TG.strGender

-- 5

SELECT TC.strFirstName, TC.strLastName, TG.strGender, gen.strGenre, TS.strSongName, TA.strFirstName, TA.strLastName, TR.strRecordLabel
FROM TCustomers as TC
	 JOIN TGenders as TG 
		 ON TC.intGenderID = TG.intGenderID

	 JOIN TCustomerSongs as TCS 
		 ON TCS.intCustomerID = TC.intCustomerID

	 JOIN TSongs as TS 
		 ON TCS.intSongID = TS.intSongID

	 JOIN TRecordLabels as TR
		 ON TS.intRecordLabelID = TR.intRecordLabelID

	 JOIN TGenres as gen
		ON TS.intGenreID = gen.intGenreID

	 JOIN TArtists as TA 
		 ON TS.intArtistID = TA.intArtistID

ORDER BY gen.strGenre

