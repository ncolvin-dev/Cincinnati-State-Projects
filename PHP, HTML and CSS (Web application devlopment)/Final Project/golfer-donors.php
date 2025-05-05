
<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Golfer Donors List</title>
	<link rel="stylesheet", href="../../Styles/final-project-statistics.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>

<body>

<main>
<?php
	// Connect
	include "db_connection.php";
	
	// Get ID
	$intGolferID = $_GET["id"];
	
	
	
	$strSQL = "
	SELECT TS.strFirstName, TS.strLastName, dblPledgePerHole * 100 AS DonationAmount
	FROM TSponsors AS TS
	JOIN TEventGolferSponsors AS TEGS ON TS.intSponsorID = TEGS.intSponsorID
	JOIN TEventGolfers AS TEG ON TEGS.intEventGolferID = TEG.intEventGolferID
	JOIN TGolfers AS TG ON TEG.intGolferID = TG.intGolferID
	WHERE TG.intGolferID = $intGolferID
	  AND TEG.intEventID = (
		  SELECT MAX(intEventID)
		  FROM TEventGolfers
		  WHERE intGolferID = $intGolferID
	  )
	";
	
	// Successful?
	if ($clsGolfers = mysqli_query($clsConn, $strSQL) )
	{
		// Yes, display event golfer information
		echo "<table border=1>";
			echo "<tr>";
				echo "<th>First Name</th>";
				echo "<th>Last Name</th>";
				echo "<th>Amount Donated</th>";
			echo "</tr>";
		// Not null?
		if(mysqli_num_rows($clsGolfers) > 0)
		{
			// Yes, display information
			while($aGolferData = mysqli_fetch_array($clsGolfers))
			{
				echo "<tr>";
					echo "<td>" . $aGolferData['strFirstName'] . "</td>";
					echo "<td>" . $aGolferData['strLastName'] . "</td>";
					echo "<td>" . $aGolferData['DonationAmount']  ."</td>";
				echo "</tr>";
			}
			echo "</table>";
		}
	}
?>

<a href="golfer-statistics.php"><button type='button'>Go Back</button>
</main>
<?php
// Close connection
mysqli_close($clsConn);
?>	
	
</body>
	
</html>