<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Final Project</title>
	<link rel="stylesheet", href="../../Styles/Final Project - homepage.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>


<body>

<?php
// GET ID
include "db_connection.php";

$intGolferID = $_GET["id"];

$strSQL = "SELECT 
strFirstName, strLastName, dblPledgePerHole* 100 as DonationAmount, strPaymentStatus, TEGS.intEventGolferSponsorID
FROM
TSponsors as TS
JOIN TEventGolferSponsors as TEGS on TS.intSponsorID = TEGS.intSponsorID
JOIN tpaymentstatuses as TPS on TPS.intPaymentStatusID = TEGS.intPaymentStatusID
WHERE
TEGS.intEventGolferID = " . $intGolferID;

// Yes, query succesful?
if($clsDonorList = mysqli_query($clsConn, $strSQL) )
{

	// Yes, display event golfer information
	echo "<table border=1>";
		echo "<tr>";
			echo "<th>First Name</th>";
			echo "<th>Last Name</th>";
			echo "<th>Donation Amount</th>";
			echo "<th>Payment Status</th>";
			echo "<th>Change?</th>";
		echo "</tr>";
	// Not null?
	if(mysqli_num_rows($clsDonorList) > 0)
	{
		// Yes, display information
		while($aDonorData = mysqli_fetch_array($clsDonorList))
		{
			echo "<tr>";
				echo "<td>" . $aDonorData['strFirstName']     . "</td>";
				echo "<td>" . $aDonorData['strLastName']      . "</td>";
				echo "<td>" . number_format($aDonorData['DonationAmount'], 2) . "</td>";
				echo "<td>" . $aDonorData['strPaymentStatus'] . "</td>";
				echo "<td><a href='change-status.php?id=" . $aDonorData['TEGS.intEventGolferSponsorID'] . "'>Change Status</a></td>";
			echo "</tr>";
		}
		echo "</table>";
	}
}
else 
{
	// No, Display Error
	echo "Query failed: " . mysqli_error($clsConn);
}

// Close connection
mysqli_close($clsConn);
?>
</body>
	
</html>