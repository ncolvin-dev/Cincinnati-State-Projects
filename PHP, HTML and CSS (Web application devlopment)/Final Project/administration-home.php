<!DOCTYPE html>

<html>
<head>
	<title>Administration Home</title>
	<link rel="stylesheet", href="../../Styles/final-project-administration-homepage.css">
	<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>
<body>
<div ID="wrapper">
	<div class="OptionPanel">
	
		<tr>
			<td>
				<form method="post" action="addevent.php">
					<input type="submit" value="Add an event"></input>
				</form>
			</td>
		</tr>


			

		<tr>
			<td>
				<form method="post" action="manage-golfers.php">
					<input type="submit" value="Manage Event Golfers"></input>
				</form>
			</td>
		</tr>

		
		<tr>
			<td>
				<form method="post" action="homepage.php">
					<input type="submit" value="Logout"></input>
				</form>
			</td>
		</tr>
	</div>
	
</div>
</body>
	
</html>



<!--
$intID = $_GET["id"];

//Connect to MySQL
$strServerName = "itd2.cincinnatistate.edu";
$strDBUsername = "nacolvin";
$strDBPassword = "0721755";
$strDBName = "01WAPP1400ColvinN";

$clsConn = mysqli_connect($strServerName, $strDBUsername, $strDBPassword, $strDBName);

//Check connection
if (!$clsConn) {
	die("Connection failed: " . mysqli_connect_error());
}

$clsResult = mysqli_query($clsConn, "SELECT strFirstName, strLastName FROM TAdmins WHERE intAdminID = " . $intID);

if ($clsResult)
{
	$aRow = mysqli_fetch_assoc($clsResult);
	
	$strFirstName = $aRow['strFirstName'];
	$strLastName  = $aRow['strLastName'];
	echo "<h2> Welcome ". $strFirstName . " " .  $strLastName . "!</h2>";
}
else
{
	echo "<h2> Welcome Admin </h2>";
}
-->

