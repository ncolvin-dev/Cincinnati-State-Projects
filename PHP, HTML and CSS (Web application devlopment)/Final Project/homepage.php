<!DOCTYPE html>
<html>
<head>
	<title>Golfer Fundrasier - Final Project</title>
	<link rel="stylesheet" href="../../Styles/final-project-homepage.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>

<body>
<div id="wrapper">
<?php
// Connect
include "db_connection.php";

// Get the latest Event ID first
$strEventIDSQL = "SELECT intEventID
FROM TEvents 
ORDER BY dtmEventYear DESC, intEventID DESC
LIMIT 1;";
$clsEventID = mysqli_query($clsConn, $strEventIDSQL);
$aResultEventID = mysqli_fetch_assoc($clsEventID);
$intEventID = $aResultEventID["intEventID"];

// Total earnings in this current event
$strTotalEarnedSQL = "SELECT SUM(dblPledgePerHole * 100) as TotalAmountEarned
FROM TEventGolferSponsors AS TEGS
JOIN teventgolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
WHERE TEG.intEventID = $intEventID and intPaymentStatusID = 2;";
$clsTotalEarned = mysqli_query($clsConn, $strTotalEarnedSQL);
$aResult1 = mysqli_fetch_assoc($clsTotalEarned);
$dblTotalEarned = $aResult1["TotalAmountEarned"];

// Golfer who has raised the most
$strTopGolferSQL = "SELECT TG.strFirstName, TG.strLastName, SUM(TEGS.dblPledgePerHole * 100) as TotalRaised
FROM TEventGolferSponsors as TEGS
JOIN TEventGolfers as TEG on TEGS.intEventGolferID = TEG.intEventGolferID
JOIN TGolfers as TG on TG.intGolferID = TEG.intGolferID
WHERE TEG.intEventID = $intEventID
GROUP BY TG.strFirstName, TG.strLastName
ORDER BY TotalRaised DESC
LIMIT 1;";
$clsTopGolfer = mysqli_query($clsConn, $strTopGolferSQL);
$aResult2 = mysqli_fetch_assoc($clsTopGolfer);
$strGolferName = $aResult2["strFirstName"] . " " . $aResult2["strLastName"];
$dblTopGolfer = $aResult2["TotalRaised"];

// Total Golfers 
$strTotalGolfersSQL = "SELECT COUNT(intGolferID) as GolferCount
FROM TEventGolfers
WHERE intEventID = " . $intEventID;
$clsTotalGolfers = mysqli_query($clsConn, $strTotalGolfersSQL);
$aResult3 = mysqli_fetch_assoc($clsTotalGolfers);
$intTotalGolfers = $aResult3["GolferCount"];

// Default/fallback values
if ($dblTotalEarned == null) {
	$dblTotalEarned = 0;
}

if ($dblTopGolfer == null) {
	$dblTopGolfer = 0;
}

if ($intTotalGolfers == null) {
	$intTotalGolfers = 0;
}

if (trim($strGolferName) == "") {
	$strGolferName = "N/A";
}
?>

	<div class="clsNavbar">
		<h3><a href="#">Golfer Fundrasier</a></h3>
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
          <h2>Total Amount Raised</h2>
          <?php echo "<p>$" . number_format($dblTotalEarned, 2) . "</p>"; ?>
        </div>
        <div class="stat-card">
          <h2>Top Golfer Earnings</h2>
          <?php echo "<p>$strGolferName - $" . number_format($dblTopGolfer, 2) . "</p>"; ?>
        </div>
        <div class="stat-card">
          <h2>Total Golfers</h2>
          <?php echo "<p>$intTotalGolfers</p>"; ?>
        </div>
      </section>
    </main>

<?php
// Close connection
mysqli_close($clsConn);
?>
</body>
</html>
