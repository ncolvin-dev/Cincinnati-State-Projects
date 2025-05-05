<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Final Project</title>
	<link rel="stylesheet", href="../../Styles/final-project-golfer-registration.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>


<?php
include "db_connection.php";


// Get the latest event
$clsEventIDResult = mysqli_query($clsConn, "SELECT intEventID
FROM TEvents 
ORDER BY 
dtmEventYear DESC,
intEventID DESC
LIMIT 1;");
$row = mysqli_fetch_assoc($clsEventIDResult);

if ($row) 
{
	$intEventID = $row['intEventID'];
} else 
{
	die("No current event found.");
}

// Display all golfers that are NOT registered the current event
$strSQL = "
SELECT TG.intGolferID, TG.strFirstName, TG.strLastName 
FROM TGolfers AS TG
LEFT JOIN TEventGolfers AS TEG 
  ON TG.intGolferID = TEG.intGolferID 
  AND TEG.intEventID = $intEventID
WHERE TEG.intEventGolferID IS NULL
";
$clsGolfers = mysqli_query($clsConn, $strSQL);


?>


<body>
<div id="wrapper">
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
	<div class="table-wrapper">
		<form method="post" action="process-event-golfer.php">
		
			<table>
				<tr>
					<td>
						<h3>Select a golfer to add: </h3>
						<select class="selSelect" name="selGolfers" required>
							<option value=""> Select Golfer </option>
								<?php
									if (mysqli_num_rows($clsGolfers) > 0) 
									{
										while($row = mysqli_fetch_assoc($clsGolfers)) 
										{
											
											echo "<option value='" . $row["intGolferID"] . "'>" . $row["strFirstName"] . " " . $row["strLastName"] . "</option>";
											
										}
									} 
									else 
									{
										echo "0 results";
									}
								?>
						</select>
					</td>
				</tr>
				<tr>
					<td>
						<input class="button" type="submit" value="Register">
						<input type="hidden" name="intEventID" value="<?php echo $intEventID; ?>">
					</td>
				</tr>
			</table>
		</form>
	</div>
</main>
	
		<?php if (isset($_GET['blnSuccess']) && $_GET['blnSuccess'] == true): ?>
		<p style="color: green; font-weight: bold;">Golfer successfully registered!</p>
		<?php elseif (isset($_GET['blnSuccess']) && $_GET['blnSuccess'] == false):?>
		<p style="color: red; font-weight: bold;">ERROR: Golfer not added</p>
		<?php endif;?>
	
</div>
</body>
	<?php
	// Close connection
	mysqli_close($clsConn);
	?>
</html>