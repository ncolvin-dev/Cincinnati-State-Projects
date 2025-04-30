--Stored Procedures
--Nicholas Colvin

--1
CREATE PROCEDURE uspAddAttendant

     @intAttendantID		    AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strEmployeeID				AS VARCHAR(255)
    ,@dtmDateofHire				AS Date	 
    ,@dtmDateofTermination		AS Date 
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intAttendantID = MAX(intAttendantID) + 1 
    FROM TAttendants (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT @intAttendantID = COALESCE(@intAttendantID, 1)
    INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination)
    VALUES (@intAttendantID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateofHire, @dtmDateofTermination)
COMMIT TRANSACTION

--2
CREATE PROCEDURE uspAddFutureFlight

	  @intFlightID as INTEGER 
	 ,@dtmFlightDate as DATE
	 ,@strFlightNumber as VARCHAR(255)
	 ,@dtmTimeofDeparture as TIME 
	 ,@dtmTimeOfLanding as TIME
	 ,@intToAirportID as INTEGER
	 ,@intFromAirportID as INTEGER
	 ,@intMilesFlown as INTEGER 
	 ,@intPlaneID as INTEGER

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
		
    SELECT @intFlightID = MAX(intFlightID) + 1 
    FROM TFlights (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT intFlightID = COALESCE(@intFlightID, 1)
    INSERT INTO TFlights(intFlightID, dtmFlightDate, strFlightNumber, dtmTimeofDeparture, dtmTimeOfLanding, intToAirportID,intFromAirportID, intMilesFlown, intPlaneID)
    VALUES (@intFlightID, @dtmFlightDate, @strFlightNumber, @dtmTimeofDeparture, @dtmTimeOfLanding, @intToAirportID, @intFromAirportID, @intMilesFlown, @intPlaneID)


COMMIT TRANSACTION

--3
CREATE PROCEDURE uspAddFutureFlight

	  @intFlightID as INTEGER 
	 ,@dtmFlightDate as DATE
	 ,@strFlightNumber as VARCHAR(255)
	 ,@dtmTimeofDeparture as TIME 
	 ,@dtmTimeOfLanding as TIME
	 ,@intToAirportID as INTEGER
	 ,@intFromAirportID as INTEGER
	 ,@intMilesFlown as INTEGER 
	 ,@intPlaneID as INTEGER

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
		
    SELECT @intFlightID = MAX(intFlightID) + 1 
    FROM TFlights (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT intFlightID = COALESCE(@intFlightID, 1)
    INSERT INTO TFlights(intFlightID, dtmFlightDate, strFlightNumber, dtmTimeofDeparture, dtmTimeOfLanding, intToAirportID,intFromAirportID, intMilesFlown, intPlaneID)
    VALUES (@intFlightID, @dtmFlightDate, @strFlightNumber, @dtmTimeofDeparture, @dtmTimeOfLanding, @intToAirportID, @intFromAirportID, @intMilesFlown, @intPlaneID)


COMMIT TRANSACTION


--4
CREATE PROCEDURE uspAddPassenger
     @intPassengerID				AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strAddress				AS VARCHAR(255)
    ,@strCity					AS VARCHAR(255) 
    ,@intState					AS INTEGER 
    ,@strZip					AS VARCHAR(255)
    ,@strPhoneNumber			AS VARCHAR(255)
    ,@strEmail					AS VARCHAR(255)
	,@strLoginID				AS VARCHAR(255)
	,@strPassword				AS VARCHAR(255)
	,@dtmDateOfBirth			AS Date
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intPassengerID = MAX(intPassengerID) + 1 
    FROM TPassengers (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT @intPassengerID = COALESCE(@intPassengerID, 1)
    INSERT INTO TPassengers(intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLoginID, strPassword, dtmDateofBirth)
    VALUES (@intPassengerID, @strFirstName, @strLastName, @strAddress, @strCity, @intState, @strZip, @strPhoneNumber, @strEmail, @strLoginID, @strPassword, @dtmDateOfBirth)

COMMIT TRANSACTION

--5
CREATE PROCEDURE uspAddPilot

     @intPilotID		    AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strEmployeeID				AS VARCHAR(255)
    ,@dtmDateofHire				AS Date
    ,@dtmDateofTermination		AS Date
	,@dtmDateofLicense			AS Date
	,@intPilotRoleID				AS INTEGER 
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intPilotID = MAX(intPilotID) + 1 
    FROM TPilots (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT @intPilotID = COALESCE(@intPilotID, 1)
    INSERT INTO TPilots(intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination, dtmDateOfLicense, intPilotRoleID)
    VALUES (@intPilotID, @strFirstName, @strLastName, @strEmployeeID, @dtmDateofHire, @dtmDateofTermination, @dtmDateofLicense, @intPilotRoleID)
COMMIT TRANSACTION


--6
CREATE PROCEDURE uspAssignAttendantFlight

     @intAttendantFlightID		AS INTEGER OUTPUT
    ,@intAttendantID			AS INTEGER
    ,@intFlightID			AS INTEGER

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intAttendantFlightID = MAX(intAttendantFlightID) + 1 
    FROM TAttendantFlights (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT TAttendantFlights = COALESCE(@intAttendantFlightID, 1)
    INSERT INTO TAttendantFlights(intAttendantFlightID, intAttendantID, intFlightID)
    VALUES (@intAttendantFlightID, @intAttendantID, @intFlightID)
COMMIT TRANSACTION

CREATE PROCEDURE uspAssignPilotFlight

     @intPilotFlightID		AS INTEGER OUTPUT
    ,@intPilotID			AS INTEGER
    ,@intFlightID			AS INTEGER

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intPilotFlightID = MAX(intPilotFlightID) + 1 
    FROM TPilotFlights (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT TPilotFlights = COALESCE(@intPilotFlightID, 1)
    INSERT INTO TPilotFlights(intPilotFlightID, intPilotID, intFlightID)
    VALUES (@intPilotFlightID, @intPilotID, @intFlightID)
COMMIT TRANSACTION

--7
CREATE PROCEDURE uspBookFlight

     @intFlightPassengerID		AS INTEGER OUTPUT
    ,@intFlightID				AS INTEGER
    ,@intPassengerID			AS INTEGER
    ,@strSeat					AS VARCHAR(255)
	,@dblFlightCost				AS DECIMAL

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intFlightPassengerID = MAX(intFlightPassengerID) + 1 
    FROM TFlightPassengers (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT TFlightPassengers = COALESCE(@intFlightPassengerID, 1)
    INSERT INTO TFlightPassengers(intFlightPassengerID, intFlightID, intPassengerID, strSeat, dblFlightCost)
    VALUES (@intFlightPassengerID, @intFlightID, @intPassengerID, @strSeat, @dblFlightCost)
COMMIT TRANSACTION


--8
CREATE PROCEDURE uspCustomerCount
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
	SELECT
		 COUNT(intPassengerID) as TotalCustomerCount 
	FROM
		TPassengers

COMMIT TRANSACTION

--9
CREATE PROCEDURE uspDeletePilot
     @intPilotID		AS INTEGER  
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
             DELETE FROM TPilots WHERE intPilotID = @intPilotID
COMMIT TRANSACTION

--10
CREATE PROCEDURE uspListCustomerInfo
	@PassengerID as Integer 
AS
BEGIN
	SELECT
		 strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strLoginID, strPassword, dtmDateOfBirth
	FROM
		TPassengers
	WHERE 
		intPassengerID = @PassengerID
END

--11
CREATE PROCEDURE uspListPastFlightCustomer
	@PassengerID as Integer 
AS
BEGIN
	SELECT
		 strFlightNumber, dtmFlightDate
	FROM
		TFlights as TF JOIN TFlightPassengers as TFP ON TF.intFlightID = TFP.intFlightID

	WHERE 
		intPassengerID = @PassengerID
		AND TF.dtmFlightDate < GETDATE()
END

CREATE PROCEDURE uspListStates
AS
BEGIN
	SELECT
		 intStateID, strState
	FROM
		TStates
END


--12
CREATE PROCEDURE uspPassengerAge

	 @intPassengerID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
		
SELECT DATEDIFF(YY,dtmDateofBirth, GETDATE()) as Age FROM TPassengers as TP 
WHERE intPassengerID = @intPassengerID

COMMIT TRANSACTION

CREATE PROCEDURE uspPassengerPreviousFlights
	 @intPassengerID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
		
SELECT COUNT(intFlightID) as TotaFlights FROM TFlightPassengers as TFP
WHERE TFP.intPassengerID = @intPassengerID


COMMIT TRANSACTION


--13
CREATE PROCEDURE uspPlaneUsedOnFlight
	 @intFlightID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
		
		SELECT strPlaneType FROM TFlights as TF 
		JOIN TPlanes as TP on TP.intPlaneID = TF.intPlaneID 
		JOIN TPlaneTypes as TPT on TPT.intPlaneTypeID = TP.intPlaneTypeID
		WHERE TF.intFlightID = @intFlightID

COMMIT TRANSACTION


--14
CREATE PROCEDURE uspSelectCustomer
	@PassengerID as INTEGER 
AS
BEGIN
	SELECT
		 intPassengerID 
	FROM
		TPassengers
	WHERE 
		intPassengerID = @PassengerID
END


--15
CREATE PROCEDURE uspSelectFlight
	@Flight_ID as Integer 
AS
BEGIN
	SELECT
		TF.intFlightID 
	FROM
		 TFlights as TF 

	WHERE 
		TF.intFlightID = @Flight_ID
END


--16
CREATE PROCEDURE uspTotalMilesFlownAttendants
AS
BEGIN
	SELECT
		 SUM(intMilesFlown) as TotalMilesFlownForEachAttendant, strFirstName, strLastName
	FROM
		TAttendants 
		LEFT JOIN TAttendantFlights ON TAttendants.intAttendantID = TAttendantFlights.intAttendantID
		LEFT JOIN TFlights ON TFlights.intFlightID = TAttendantFlights.intFlightID

	GROUP BY 
	strFirstName,
	strLastName

END


--17
CREATE PROCEDURE uspTotalMilesFlownPilots
AS
BEGIN
	SELECT
		SUM(intMilesFlown) as TotalMilesFlownForEachPilot, strFirstName, strLastName
	FROM
		 TPilots LEFT JOIN TPilotFlights ON TPilots.intPilotID = TPilotFlights.intPilotID
		 LEFT JOIN TFlights ON TFlights.intFlightID = TPilotFlights.intFlightID

		GROUP BY 
		strFirstName,
		strLastName
END


--18
CREATE PROCEDURE uspTotalPassengersOnFlight

	 @intPassengerID as Integer

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
		
		SELECT COUNT(intPassengerID) as TotalPassengersOnFlight FROM TFlightPassengers as TFP
		WHERE TFP.intFlightID = @intPassengerID

COMMIT TRANSACTION


--19
CREATE PROCEDURE uspUpdateEmployeeAttendant
	 @strEmployeeLoginID		AS VARCHAR(255)
	,@strEmployeePassword		AS VARCHAR(255)
	,@intEmployeeID				AS INTEGER
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
             UPDATE TEmployees Set 
			 strEmployeeLoginID = @strEmployeeLoginID,
			 strEmployeePassword = @strEmployeePassword
			
			WHERE strEmployeeRole = 'Attendant' and intEmployeeID = @intEmployeeID
COMMIT TRANSACTION


--20
CREATE PROCEDURE uspUpdateEmployeePilot
	 @strEmployeeLoginID		AS VARCHAR(255)
	,@strEmployeePassword		AS VARCHAR(255)
	,@intEmployeeID				AS INTEGER
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
             UPDATE TEmployees Set 
			 strEmployeeLoginID = @strEmployeeLoginID,
			 strEmployeePassword = @strEmployeePassword
			
			WHERE strEmployeeRole = 'Pilot' and intEmployeeID = @intEmployeeID
COMMIT TRANSACTION


--21
CREATE PROCEDURE uspUpdatePassenger
     @intPassengerID			AS INTEGER  
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strAddress				AS VARCHAR(255)
    ,@strCity					AS VARCHAR(255) 
    ,@intState					AS INTEGER 
    ,@strZip					AS VARCHAR(255)
    ,@strPhoneNumber			AS VARCHAR(255)
    ,@strEmail					AS VARCHAR(255)
	,@strLoginID				AS VARCHAR(255)
	,@strPassword				AS VARCHAR(255)
	,@dtmDateOfBirth			AS DATE
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
             UPDATE TPassengers Set 
                 strLastName = @strLastName, 
                 strFirstName = @strFirstName, 
                 strAddress = @strAddress, 
                 strCity = @strCity, 
                 intStateID =  @intState, 
                 strZip =  @strZip, 
                 strPhoneNumber = @strPhoneNumber,
                 strEmail = @strEmail,
				 strLoginID =	 @strLoginID,
				 strPassword =	 @strPassword,
				 dtmDateofBirth = @dtmDateOfBirth
			
	WHERE intPassengerID = @intPassengerID
COMMIT TRANSACTION