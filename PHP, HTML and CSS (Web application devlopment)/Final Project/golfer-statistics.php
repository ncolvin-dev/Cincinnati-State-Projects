<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Final Project</title>
	<link rel="stylesheet", href="../../Styles/final-project-statistics.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>

<body>
<div ID="wrapper" >
<?php
	include "db_connection.php";
	
	// Get Event ID
	$strEventIDSQL = "SELECT intEventID
	FROM TEvents 
	ORDER BY 
	dtmEventYear DESC,
	intEventID DESC
	LIMIT 1;";
	$clsEventID = mysqli_query($clsConn, $strEventIDSQL);
	$aResult0 = mysqli_fetch_assoc($clsEventID);
	$intEventID = $aResult0["intEventID"];
	
	
	// Total amount Pledged in this current event
	$strTotalPledgedSQL = "SELECT SUM(dblPledgePerHole * 100) as TotalAmountPledgedPerHole
	FROM TEventGolferSponsors AS TEGS
	JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
	WHERE TEG.intEventID = " . $intEventID;
	$clsTotalPledged = mysqli_query($clsConn, $strTotalPledgedSQL);
	$aResult1 = mysqli_fetch_assoc($clsTotalPledged);
	$dblTotalPledged = $aResult1["TotalAmountPledgedPerHole"];

	// Total Number of donations for the event
	$strTotalDonationsSQL = "SELECT COUNT(*) as TotalDonations
	FROM TEventGolferSponsors AS TEGS
	JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
	WHERE TEG.intEventID = " . $intEventID;
	$clsTotalDonations = mysqli_query($clsConn, $strTotalDonationsSQL);
	$aResult2 = mysqli_fetch_assoc($clsTotalDonations);
	$intTotalDonations = $aResult2["TotalDonations"];

	// Average Donation
	$strAverageDonationSQL = "SELECT AVG(dblPledgePerHole* 100) as AverageDonation
	FROM TEventGolferSponsors AS TEGS
	JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
	WHERE TEG.intEventID = " . $intEventID;

	$clsAverageDonation = mysqli_query($clsConn, $strAverageDonationSQL);
	$aResult3 = mysqli_fetch_assoc($clsAverageDonation);
	$dblAverageDonation = $aResult3["AverageDonation"];
	
	if ($dblTotalPledged == null)
	{
		$dblTotalPledged = 0;
	}
	
	if ($intTotalDonations == null)
	{
		$intTotalDonations = 0;
	}
	
	if ($dblAverageDonation == null)
	{
		$dblAverageDonation = 0;
	}

?>

	<div class="clsNavbar">
		<h3><a href="homepage.php">Golfer Fundrasier</a></h3>
		<nav>
			<ul>
				<li><a href="golfer-registration.php">Register to golf</a></li>
				<li><a href="golfers.php">The Golfers</a></li>
				<li><a href="donors.php">Make a donation</a></li>
				<li><a href="golfer-statistics.php">Golfer Statistics</a></li>
				<li><a href="Login.php">Administration Login</a></li>
			</ul>
		</nav>
	</div>
    <main>
		<section class="stats-container">
		<div class="stat-card">
		  <h2>Total Amount Pledged</h2>
		  <?php echo "<p>" . number_format($dblTotalPledged, 2). "</p>"; ?>
		</div>
		<div class="stat-card">
		  <h2>Total Number of donations</h2>
		  <?php echo "<p>$intTotalDonations</p>"; ?>
		</div>
		<div class="stat-card">
		  <h2>Average donation</h2>
		  <?php echo "<p>" . number_format($dblAverageDonation, 2). "</p>"; ?>
		</div>
		</section>
		<div class="">
		<?php
			$strSQL = "
			SELECT TG.intGolferID, TG.strFirstName, TG.strLastName, 
				   SUM(dblPledgePerHole * 100) as DonationAmount
			FROM TGolfers as TG
			LEFT JOIN teventgolfers as TEG ON TG.intGolferID = TEG.intGolferID
			LEFT JOIN TEventGolferSponsors as TEGS ON TEG.intEventGolferID = TEGS.intEventGolferID
			WHERE TEG.intEventID = $intEventID
			GROUP BY TG.intGolferID, TG.strFirstName, TG.strLastName
			ORDER BY DonationAmount DESC;";
			
			// Successful?
			if ($clsGolfers = mysqli_query($clsConn, $strSQL) )
			{
				// Yes, display event golfer information
				echo "<table border=1>";
					echo "<tr>";
						echo "<th>First Name</th>";
						echo "<th>Last Name</th>";
						echo "<th>Total Pledges</th>";
						echo "<th>Donors</th>";
					echo "</tr>";
				// Not null?
				if(mysqli_num_rows($clsGolfers) > 0)
				{
					// Yes, display information
					while($aGolferData = mysqli_fetch_array($clsGolfers) )
					{
						if ($aGolferData['DonationAmount'] == null)
						{
							$aGolferData['DonationAmount'] = 0;
						}
						echo "<tr>";
							echo "<td>" . $aGolferData['strFirstName'] . "</td>";
							echo "<td>" . $aGolferData['strLastName'] . "</td>";
							echo "<td>" . $aGolferData['DonationAmount'] . "</td>";
							echo "<td><a href='golfer-donors.php?id=" . $aGolferData['intGolferID'] . "'>  <button type='button'>View Donors</button>  </a></td>";
						echo "</tr>";
					}
					echo "</table>";
				}
			}
		?>
		
	<?php
	// Close connection
	mysqli_close($clsConn);
	?>	
		</div>
    </main>
	
</body>
	
</html>