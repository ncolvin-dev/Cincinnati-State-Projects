<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Final Project</title>
	<link rel="stylesheet", href="../../Styles/Final Project - homepage.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>

<body>
<div id="wrapper" >

		<h2>Select an Event: </h2>
		<form method="post">
			<select class="selSelect" name="selEventID" required>
				<option value=""> Select Event </option>
					<?php
					include "db_connection.php";
					$clsEvents = mysqli_query($clsConn, "SELECT intEventID FROM tevents");
						
						if (mysqli_num_rows($clsEvents) > 0) 
						{
							while($row = mysqli_fetch_assoc($clsEvents)) 
							{
								
								echo "<option value='" . $row["intEventID"] . "'>" . "Event: " . $row["intEventID"] . "</option>";
								
							}
						} 
						else 
						{
							echo "0 results";
						}
					?>
			</select>
			<input type="submit" value="View Totals">
		</form>






<?php
$intEventID = $_POST["selEventID"];

// Collect total amount earned per EventGolfer
$strEventGolferSQL = "SELECT SUM(dblPledgePerHole * 100) as TotalGolferEarnings, TG.intGolferID, strFirstName, strLastName  
FROM TGolfers as TG 
JOIN teventgolfers as TEG on TEG.intGolferID = TG.intGolferID
JOIN teventgolfersponsors as TEGS on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = " . $intEventID ."
AND TEGS.intPaymentStatusID = 2
GROUP BY
TG.intGolferID,
strFirstName,
strLastName;";

// Total pledged
$strTotalPledgedSQL = "SELECT SUM(dblPledgePerHole * 100) as TotalAmountPlegedPerHole
FROM
TEventGolferSponsors;";


// Total pledged
$strTotalEarnedSQL = "SELECT SUM(dblPledgePerHole * 100) as TotalAmountPlegedPerHole
FROM
TEventGolferSponsors
WHERE
intPaymentStatusID = 2;";



// Has the user selected an event?
if (isset($_POST["selEventID"]) ) 
{
	// Yes, query succesful?
	if($clsEventGolfers = mysqli_query($clsConn, $strEventGolferSQL) )
	{

		// Yes, display event golfer information
		echo "<table border=1>";
			echo "<tr>";
				echo "<th>Golfer ID</th>";
				echo "<th>First Name</th>";
				echo "<th>Last Name</th>";
				echo "<th>TotalGolferEarnings</th>";
			echo "</tr>";
		// Not null?
		if(mysqli_num_rows($clsEventGolfers) > 0)
		{
			// Yes, display information
			while($aEventGolferData = mysqli_fetch_array($clsEventGolfers))
			{
				echo "<tr>";
					echo "<td><a href='donor-list.php?id=" . $aEventGolferData['intGolferID'] . "'>" . $aEventGolferData['intGolferID'] . "</a></td>";
					echo "<td>" . $aEventGolferData['strFirstName'] . "</td>";
					echo "<td>" . $aEventGolferData['strLastName'] . "</td>";
					echo "<td>" . $aEventGolferData['TotalGolferEarnings'] . "</td>";
				echo "</tr>";
			}
			echo "</table>";
		}
	}
	else {
		// No, Display Error
		echo "Query failed: " . mysqli_error($clsConn);
	}
	
	// Query succesful?
	if($clsTotalPledged = mysqli_query($clsConn, $strTotalPledgedSQL) )
	{
		// Not null?
		if(mysqli_num_rows($clsTotalPledged) > 0)
		{
			$aintTotalPledged = mysqli_fetch_array($clsTotalPledged);
			// Yes, Display Total Pledged
			echo "<h1> Total Pledged: </h1> <br>";
			echo $aintTotalPledged[0] . "<br>";
		}
	}
	
	// Query succesful?
	if($clsTotalEarned = mysqli_query($clsConn, $strTotalEarnedSQL) )
	{
		// Not null?
		if(mysqli_num_rows($clsTotalEarned) > 0)
		{
			$aintTotalEarned = mysqli_fetch_array($clsTotalEarned);
			// Yes, Display Total Pledged
			echo "<h1> Total Earned: </h1> <br>";
			echo $aintTotalEarned[0];
		}
	}
	
}

	

?>
</div>
</body>
	<?php
	// Close connection
	mysqli_close($clsConn);
	?>
</html>