<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Final Project</title>
	<link rel="stylesheet", href="../../Styles/final-project-donate.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>

<?php
// Connect
include "db_connection.php";

// Get States and Payment Types
$clsStates = mysqli_query($clsConn, "SELECT intStateID, strState FROM TStates");
$clsPaymentTypes = mysqli_query($clsConn, "SELECT strPaymentType, intPaymentTypeID FROM TPaymentTypes;");

// Get Event ID
$clsEventID = mysqli_query($clsConn, "SELECT intEventID FROM TEvents ORDER BY intEventID DESC LIMIT 1");
$aResult = mysqli_fetch_array($clsEventID);
$intEventID = $aResult[0];

// Get players that have not recived a donataion yet 
$strSQL = "SELECT TG.intGolferID, TG.strFirstName, TG.strLastName 
FROM TGolfers AS TG
INNER JOIN TEventGolfers AS TEG 
ON TG.intGolferID = TEG.intGolferID 
AND TEG.intEventID = $intEventID
LEFT JOIN teventgolfersponsors AS TEGS
ON TEG.intEventGolferID = TEGS.intEventGolferID
WHERE TEGS.intEventGolferID IS NULL;";

$clsGolfers = mysqli_query($clsConn, $strSQL);

?>

<body>
<div ID="wrapper" >
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
	
		<h2 align="center">Enter information below:</h2>
	

	<main>
	<div class="table-wrapper">
		<form name="frmDonor" method="post" action="thank-you-page.php">
			<table align="center" valign="center">

				<tr>
					<td colspan="2"><label>Full Name</label></td>
				</tr>
				<tr>
					<td><input type="text" name="txtFirstName" placeholder="First Name" required></input></td>
					<td><input type="text" name="txtLastName" placeholder="Last Name" required></input></td>
				</tr>


				<tr>
					<td colspan="2"><label>Address</label></td>
				</tr>
				<tr>
					<td colspan="2"><input type="text" name="txtAddress" placeholder="Address" required></input></td>
				</tr>
				
				<tr>
					<td colspan="2"><label>City</label></td>
				</tr>
				<tr>
					<td colspan="2"><input type="text" name="txtCity" placeholder="City" required></input></td>
				</tr>
				
				<tr>
					<td colspan="2"><label>State</label></td>
				</tr>
				<tr>
					<td colspan="2">
						<select class="selState"  name="selState" required>
						<option value="">Select State</option>
						<?php					
							if (mysqli_num_rows($clsStates) > 0) 
							{
								while($aStateData = mysqli_fetch_assoc($clsStates)) 
								{
									echo "<option value ='".$aStateData["intStateID"]."' >" . $aStateData["strState"].  "</option>";
									
								}
							} 
							else 
							{
								echo "0 results";
							}
						?>
					</td>
				</tr>
				
				<tr>
					<td colspan="2"><label>Zip Code</label></td>
				</tr>
				<tr>
					<td colspan="2"><input type="text" name="txtZipcode" placeholder="Zip Code" required></td>
				</tr>
				
				
				<tr>
					<td colspan="2"><label>Phone Number</label></td>
				</tr>
				<tr>
					<td colspan="2"><input type="text" name="txtPhoneNumber" placeholder="Phone Number" required></td>
				</tr>
				
				
				<tr>
					<td colspan="2"><label>Email</label></td>
				</tr>
				<tr>
					<td colspan="2"><input type="email" name="txtEmail" placeholder="Email" required></td>
				</tr>
				
				<tr>
					<td colspan="2"><label>Players</label></td>
				</tr>
				<tr>
					<td colspan="2">
						<select class="selState"  name="selGolfer" required>
						<option value="">Select Golfer</option>
						<?php					
							if (mysqli_num_rows($clsGolfers) > 0) 
							{
								while($aGolferData = mysqli_fetch_assoc($clsGolfers)) 
								{
									echo "<option value='".$aGolferData["intGolferID"]."'>" . $aGolferData["strFirstName"] . " " . $aGolferData["strLastName"] . "</option>";
								}
							} 
							else 
							{
								echo "0 results";
							}
						?>
					</td>
				</tr>
				
				<tr>
					<td colspan="2"><label>Amount to donate per hole **100 holes**</label></td>
				</tr>
				<tr>
					<td><input type="number" min="0" name="dblAmount" placeholder="Amount to donate)" required></td>
					<td>					
					<select class="selState"  name="selPaymentType" required>
					<option value="">Select Payment Type</option>
					<?php					
						if (mysqli_num_rows($clsPaymentTypes) > 0) 
						{
							while($aPaymentTypes = mysqli_fetch_assoc($clsPaymentTypes)) 
							{
								echo "<option value ='".$aPaymentTypes["strPaymentType"]."'>" . $aPaymentTypes["strPaymentType"] . "</option>";
								
							}
						} 
						else 
						{
							echo "0 results";
						}
					?>
					</td>
				</tr>
				<tr>
					<td><input class="button" type="submit" value="Submit" align="center"></td>
					<td><input class="button" type="reset" value="Clear" align="center"></td>
				</tr>
			</table>
		</form>
	</div>
	</main>	
</div>
</body>

<?php
// Close connection
mysqli_close($clsConn);
?>
</html>