<!DOCTYPE html>
<html>
<body>
<?php
include "db_connection.php";
$intEventGolferSponsorID = $_GET["id"];

// Get current intPaymentStatusID
$clsPaymentStatus = mysqli_query($clsConn, "SELECT intPaymentStatusID
FROM TEventGolferSponsors WHERE intEventGolferSponsorID = " . $intEventGolferSponsorID);

if (mysqli_num_rows($clsPaymentStatus) > 0)
{
	$aRow = mysqli_fetch_array($clsPaymentStatus);
	$intCurrentStatus = $aRow["intPaymentStatusID"];
	// Flip it the id's
	if ($intCurrentStatus == 1)
	{
		$intPaymentStatusID = 2;
	}
	elseif ($intCurrentStatus == 2)
	{
		$intPaymentStatusID = 1;
	}
}

if (isset($intPaymentStatusID))
{
	$strSQL = "UPDATE TEventGolferSponsors SET intPaymentStatusID = $intPaymentStatusID WHERE intEventGolferSponsorID = $intEventGolferSponsorID;";

	if (mysqli_query($clsConn, $strSQL) ) 
	{
		echo "<meta http-equiv='refresh' content='5;url=donor-list.php'>";
		echo "<h1> Payment Status Updated! Transering back to page in 5 seconds.</h1>";
	} 
	else 
	{
		echo "Error updating record: " . mysqli_error($clsConn);
	}	
}

// Close connection
mysqli_close($clsConn);
?>
</body>
</html>