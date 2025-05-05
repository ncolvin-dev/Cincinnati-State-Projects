<html>
<head>
	<title>Golfer Fundrasier - Add Event</title>
</head>

<?php

include "db_connection.php";

$strYear = date("Y");


// Get the next avalible event ID
$clsResultID = mysqli_query($clsConn, "SELECT MAX(intEventID) from TEvents");
$aintRow = mysqli_fetch_row($clsResultID);

// Null?
if ($aintRow[0] == NULL)
{
	// Yes, Set the value to 1
	$intEventID = 1;
}
else
{
	// No, Increment
	$intEventID = $aintRow[0] + 1;
}


$strSQL = "INSERT INTO TEvents (intEventID, dtmEventYear)
VALUES ($intEventID, '$strYear')";

//echo $strSQL;

//Query Successful?
if ($clsResult = mysqli_query($clsConn, $strSQL))
{
	//Yes, return to admin home page
	header("location: administration-home.php");
}
else
{
	echo "ERROR: Insert failed.";
}


// Close connection
mysqli_close($clsConn);

?>


<body>
<div ID="wrapper">
</div>
</body>