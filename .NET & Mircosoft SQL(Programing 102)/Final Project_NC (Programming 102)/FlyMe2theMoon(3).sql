-- --------------------------------------------------------------------------------
-- Name: Bob Nields 
 
-- Abstract: FlyMe2theMoon
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TAdminPilots')				IS NOT NULL DROP TABLE TAdminPilots
IF OBJECT_ID ('TAdminAttendants')				IS NOT NULL DROP TABLE TAdminAttendants
IF OBJECT_ID ('TAdmins')				IS NOT NULL DROP TABLE TAdmins
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers
IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers
IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates
IF OBJECT_ID ('TEmployees')				IS NOT NULL DROP TABLE TEmployees


-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,strLoginID				VARCHAR(255)	NOT	NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,dtmDateofBirth			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)


CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
    ,dblFlightCost				DECIMAL			NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

CREATE TABLE TEmployees
(
	 intEmployeeTableID		INTEGER			NOT NULL
	,strEmployeeLoginID		VARCHAR(255)	NOT NULL
	,strEmployeePassword	VARCHAR(255)	NOT NULL
	,strEmployeeRole		VARCHAR(255)	NOT NULL
	,intEmployeeID			INTEGER			NOT NULL
	,CONSTRAINT TEmployees_PK PRIMARY KEY ( intEmployeeTableID )
)

CREATE TABLE TAdminPilots
(
	  intAdminPilotID		INTEGER		NOT NULL
	 ,intPilotID		    INTEGER		NOT NULL
	 ,intAdminID			INTEGER		NOT NULL
	 ,CONSTRAINT TAdminPilots_PK PRIMARY KEY ( intAdminPilotID )
)

CREATE TABLE TAdminAttendants
(
	  intAdminAttendantID		INTEGER		NOT NULL
	 ,intAttendantID		INTEGER		NOT NULL
	 ,intAdminID			INTEGER		NOT NULL
	 ,CONSTRAINT TAdminAttendants_PK PRIMARY KEY ( intAdminAttendantID )
)

CREATE TABLE TAdmins
(
	  intAdminID			INTEGER			NOT NULL
	 ,strFirstName			VARCHAR(255)	NOT NULL
	 ,strLastName			VARCHAR(255)	NOT NULL
	 ,CONSTRAINT TAdmins_PK PRIMARY KEY ( intAdminID )
)




-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID
-- 16	TAdminPilots					TAdmins						intAdminID
-- 17	TAdminPilots					TPilots						intPilotID
-- 18	TAdminAttendants				TAttendants					intAttendantID
-- 19	TAdminAttendants				TAdmins						intAdminID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) ON DELETE CASCADE

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID )ON DELETE CASCADE

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID )ON DELETE CASCADE

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID )ON DELETE CASCADE

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) ON DELETE CASCADE

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) ON DELETE CASCADE

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) ON DELETE CASCADE

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID ) ON DELETE CASCADE

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )  ON DELETE CASCADE

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  ON DELETE CASCADE

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID ) ON DELETE CASCADE

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID )ON DELETE CASCADE

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )

--16
ALTER TABLE TAdminPilots  ADD CONSTRAINT TAdminPilots_TAdmins_FK 
FOREIGN KEY ( intAdminID ) REFERENCES TAdmins (intAdminID) 

--17
ALTER TABLE TAdminPilots  ADD CONSTRAINT TAdminPilots_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots ( intPilotID ) 

-- 18
ALTER TABLE TAdminAttendants  ADD CONSTRAINT TAdminAttendants_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants ( intAttendantID ) 

-- 19
ALTER TABLE TAdminAttendants  ADD CONSTRAINT TAdminAttendants_TAdmins_FK 
FOREIGN KEY ( intAdminID ) REFERENCES TAdmins ( intAdminID ) 


-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLoginID, strPassword, dtmDateofBirth)
VALUES				  (1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com', 'knervious', 'knpassword', '12/1/1958')
					 ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com', 'owaite', 'owpassword', '8/11/1976')
					 ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com', 'eawnewe', 'eapassword', '4/25/1990')
					 ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com', 'beninocean', 'bepassword', '6/20/1992')
					 ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com', 'whyjeked', 'whpassword', '5/13/1995')
					 ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com','koss', 'kopassword', '2/12/1994')


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')


INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2022', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2022', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2022','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2022','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2022','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2022', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2022', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2022', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '4/22/2022', '091','10:00:00', '12:00:00', 2, 1, 1200, 6)
					 ,(11, '5/20/2028', '088','17:00:00', '20:00:00', 4, 2, 1300, 5)
					 ,(12, '5/10/2028', '080','08:00:00', '10:00:00', 2, 1, 900, 2)
					 ,(13, '4/30/2028', '070','12:00:00', '15:00:00', 3, 4, 1400, 3)


INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )



INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )

					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat , dblFlightCost)
VALUES				 ( 1, 1, 1, '1A', 300)
					,( 2, 1, 2, '2A', 400 )
					,( 3, 1, 3, '1B', 475.40 )
					,( 4, 1, 4, '1C', 425.20 )
					,( 5, 1, 5, '1D', 250 )
					,( 6, 2, 5, '1A', 360 )
					,( 7, 2, 4, '2A', 350 )
					,( 8, 2, 3, '1B', 300 )
					,( 9, 3, 1, '1B', 500 )
					,( 10, 3, 2, '2A', 525.50 )
					,( 11, 3, 3, '1B', 250 )
					,( 12, 3, 4, '1C', 385.20 )
					,( 13, 3, 5, '1D', 625 )
					,( 14, 4, 2, '1A', 295 )
					,( 15, 4, 3, '1B', 340 )
					,( 16, 4, 4, '1C', 325)
					,( 17, 4, 5, '1D', 300 )
					,( 18, 5, 1, '1A', 390 )
					,( 19, 5, 2, '2A', 370 )
					,( 20, 5, 3, '1B', 480 )
					,( 21, 5, 4, '2B', 590.25 )
					,( 22, 6, 1, '1A', 350 )
					,( 23, 6, 2, '2A', 400 )
					,( 24, 6, 3, '3A', 500 )

					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )


INSERT INTO TAdmins (intAdminID, strFirstName, strLastName)
VALUES			 (1, 'Ima', 'Soring')
				,(2, 'Iwanna', 'Knapp')
				,(3, 'Buhh', 'Biy')
				,(4, 'Sherley', 'Ujest')

INSERT INTO TAdminPilots(intAdminPilotID, intAdminID, intPilotID)
VALUES			 (1, 1, 2)
				,(2, 2, 4)

INSERT INTO TAdminAttendants(intAdminAttendantID, intAdminID, intAttendantID)
VALUES			 (1, 3, 3)
				,(2, 4, 2)



INSERT INTO TEmployees (intEmployeeTableID,	strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intEmployeeID)
VALUES			 (1, 'tseenow', 'tspassword', 'Pilot', 1)
				,(2, 'isoring', 'ispassword', 'Pilot', 2)
				,(3, 'hencharge', 'hepassword', 'Pilot', 3)
				,(4, 'rennair', 'enpassword', 'Pilot', 5)
				,(5, 'iknapp', 'ikpassword', 'Pilot', 4)
				,(6, 'mtyme', 'mtpassword', 'Attendant', 1)
				,(7, 'sujest', 'supassword', 'Attendant', 2)
				,(8, 'bbiy', 'bbpassword', 'Attendant', 3)
				,(9, 'mamanie', 'mapassword', 'Attendant', 4)
				,(10, 'wtoexet', 'wtpassword', 'Attendant', 5)
				,(11, 'isadmin', 'ispassword', 'Admin', 2)
				,(12, 'tsadmin', 'tspassword', 'Admin', 1)

--SELECT TF.strFlightNumber, TF.dtmFlightDate, TF.dtmTimeofDeparture, dtmTimeOfLanding
--       From TAttendantFlights As TAF Join TAttendants As TA On TA.intAttendantID = TAF.intAttendantID
--       Join TFlights As TF On TF.intFlightID = TAF.intFlightID Where TA.intAttendantID = 3

--SELECT TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding
--FROM TPilotFlights JOIN
--TPilots ON TPilotFlights.intPilotID = TPilots.intPilotID JOIN
--TFlights ON TPilotFlights.intFlightID = TFlights.intFlightID
--WHERE TPilotFlights.intPilotID = 3

--SELECT
--strFirstName,
--strLastName,
--strAddress,
--strCity,
--strState,
--strZip,
--strPhoneNumber,
--strEmail
--FROM TPassengers as TP 
--JOIN TStates as TS 
--ON TP.intStateID = TS.intStateID

--SELECT strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail
--            FROM TPassengers as TP WHERE intPassengerID = 3

--SELECT TF.intFlightID, strFlightNumber FROM TFlights as TF WHERE TF.dtmFlightDate > '2023'

--SELECT MAX(intFlightPassengerID) + 1 AS intNextPrimaryKey  FROM TFlightPassengers


--SELECT dtmFlightDate, strFlightNumber, dtmTimeofDeparture, dtmTimeOfLanding, intMilesFlown, strPlaneType FROM TFlights as TF 
--JOIN TPilotFlights as TPF ON TF.intFlightID = TPF.intFlightID
--JOIN TPlanes as TP ON TP.intPlaneID = TF.intPlaneID
--JOIN TPlaneTypes as TPT ON TPT.intPlaneTypeID = TP.intPlaneTypeID
--WHERE TPF.intPilotID = 1 AND TF.dtmFlightDate < GETDATE()


--SELECT intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, strPilotRole 
--FROM TPilots JOIN TPilotRoles on TPilots.intPilotRoleID = TPilotRoles.intPilotRoleID
--WHERE TPilots.intPilotID = 2


--SELECT COUNT(intPassengerID) as TotalCustomerCount FROM TPassengers
--SELECT COUNT(intFlightPassengerID) as TotalFlightsTaken FROM TFlightPassengers
--SELECT AVG(intMilesFlown) as AverageMilesFlown FROM TFlightPassengers JOIN TFlights ON TFlightPassengers.intFlightID = TFlights.intFlightID

--SELECT SUM(intMilesFlown) as TotalMilesFlownForEachPilot, strFirstName, strLastName 
--FROM TPilots LEFT JOIN TPilotFlights ON TPilots.intPilotID = TPilotFlights.intPilotID 
--LEFT JOIN TFlights ON TFlights.intFlightID = TPilotFlights.intFlightID
--GROUP BY strFirstName,strLastName

--SELECT SUM(intMilesFlown) as TotalMilesFlownForEachPilot, strFirstName, strLastName 
--FROM TAttendants LEFT JOIN TAttendantFlights ON TAttendants.intAttendantID = TAttendantFlights.intAttendantID 
--LEFT JOIN TFlights ON TFlights.intFlightID = TAttendantFlights.intFlightID
--GROUP BY
--strFirstName,
--strLastName


--SELECT * FROM TPassengers

--SELECT strLoginID, strPassword FROM TPassengers

--WHERE TPassengers.intPassengerID = 1

--SELECT * FROM TEmployees
--WHERE strEmployeeLoginID = 'isoring' and strEmployeePassword = 'ispassword'

--SELECT strEmployeeLoginID, strEmployeePassword FROM TEmployees WHERE strEmployeeRole = 'Pilot' and intEmployeeID = 1

--SELECT intEmployeeID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole  FROM TEmployees


--SELECT COUNT(intPassengerID) as TotalPassengersOnFlight FROM TFlightPassengers as TFP
--WHERE TFP.intFlightID = 1

--SELECT strPlaneType FROM TFlights as TF 
--JOIN TPlanes as TP on TP.intPlaneID = TF.intPlaneID 
--JOIN TPlaneTypes as TPT on TPT.intPlaneTypeID = TP.intPlaneTypeID
--WHERE TF.intFlightID = 1

--SELECT DATEDIFF(YY,dtmDateofBirth, GETDATE()) as Age FROM TPassengers as TP 
--WHERE intPassengerID = 1


--SELECT COUNT(intFlightID) as TotaFlights FROM TFlightPassengers as TFP
--WHERE TFP.intPassengerID = 1

--SELECT intMilesFlown FROM TFlights as TF
--WHERE intFlightID = 1


