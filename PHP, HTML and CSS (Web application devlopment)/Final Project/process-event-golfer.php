<?php
// Connect to DB
include "db_connection.php";

// Get Golfer ID
$intGolferID = $_POST["selGolfers"];

// Get Event ID and Year
$clsEvent = mysqli_query($clsConn, "SELECT intEventID FROM TEvents ORDER BY intEventID DESC LIMIT 1");
$aEventData = mysqli_fetch_assoc($clsEvent);
$intEventID = $aEventData["intEventID"];

// Check if golfer is already registered for this event
$clsCheck = mysqli_query($clsConn, 
    "SELECT intEventGolferID 
     FROM TEventGolfers 
     WHERE intEventID = $intEventID 
     AND intGolferID = $intGolferID"
);

if (mysqli_num_rows($clsCheck) == 0)
{
    // Get next available intEventGolferID
    $clsResultID = mysqli_query($clsConn, "SELECT MAX(intEventGolferID) FROM TEventGolfers");
    $aintRow = mysqli_fetch_row($clsResultID);

    if ($aintRow[0] == NULL) {
        $intEventGolferID = 1;
    } else {
        $intEventGolferID = $aintRow[0] + 1;
    }

    // Insert new record
    $strSQLInsert = "INSERT INTO TEventGolfers (intEventGolferID, intEventID, intGolferID) 
                     VALUES ($intEventGolferID, $intEventID , $intGolferID)";
    $clsInsert = mysqli_query($clsConn, $strSQLInsert);
} 
else 
{
    // Already registered
    $clsInsert = false;
}

// Redirect based on outcome
if ($clsInsert) {
    header("Location: golfer-registration.php?blnSuccess=true");
} else {
    header("Location: golfer-registration.php?blnSuccess=false");
}

// Close connection
mysqli_close($clsConn);
?>
