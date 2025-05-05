<!DOCTYPE html>
<html>

	<head>
	<title>Assignment 13 - process_updateplayer.php</title>

	<!--
	Name: Nicholas Colvin
	Class:  IT-117-400
	Abstract: Assignment 13
	Date: 4/14/25

	-->
	</head>

<body>
	Name: Nicholas Colvin <br>
	Class:  IT-117-400 <br>
	Abstract: Assignment 13 - process_updateplayer.php <br>
<hr>



<?php
// Connect to MySQL
$strServerName = "itd2.cincinnatistate.edu";
$strUsername = "nacolvin";
$strPassword = "0721755";
$strDBName = "01WAPP1400ColvinN";

$clsConn = mysqli_connect($strServerName, $strUsername, $strPassword, $strDBName);

// Check connection
if (!$clsConn) 
{
	die("Connection failed: " . mysqli_connect_error());
}

// Get ID from URL 
$intGolferID = $_GET['id'];

// Get form inputs
$strFirstName = $_POST['txtFirstName'];
$strLastName = $_POST['txtLastName'];
$strAddress = $_POST['txtAddress'];
$strCity = $_POST['txtCity'];
$intStateID = $_POST['selState'];
$strZipCode = $_POST['txtZipCode'];
$strPhoneNumber = $_POST['txtPhoneNumber'];
$strEmail = $_POST['txtEmail'];
$intShirtSizeID = $_POST['selShirtSize'];
$intGenderID = $_POST['selGender'];

// Build update query
$strSQL = "UPDATE TGolfers SET 
	strFirstName = '$strFirstName',
	strLastName = '$strLastName',
	strAddress = '$strAddress',
	strCity = '$strCity',
	intStateID = $intStateID,
	strZipCode = '$strZipCode',
	strPhoneNumber = '$strPhoneNumber',
	strEmail = '$strEmail',
	intShirtSizeID = $intShirtSizeID,
	intGenderID = $intGenderID
WHERE intGolferID = $intGolferID";

// Run query
if (mysqli_query($clsConn, $strSQL)) 
{
	echo "Golfer updated successfully!";
} 
else 
{
	echo "Error updating golfer: " . mysqli_error($clsConn);
}

// Close connection
mysqli_close($clsConn);

?>
</body>
</html>