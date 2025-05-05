<?php

// --------------------------------------------------------------------------------
// Name: check-info.php 
// Abstract: Check if user input is correct, redicret accodingly 
// --------------------------------------------------------------------------------

include "db_connection.php";

$blnLoginSuccessful = false;
$intUserID = 0;
$strInputedUsername = $_POST["txtUsername"];
$strInputedPassword = $_POST["txtPassword"];


// Query Successful?
if ($clsResult = mysqli_query($clsConn, "SELECT * FROM TAdmins"))
{
	// Yes, loop through all data
	// Note: Everytime mysqli_fetch_assoc is called, it will increment.
	while($astrData = mysqli_fetch_assoc($clsResult))
	{
		// Equal?
		if ($astrData['strUserName'] == $strInputedUsername 
		and $astrData['strPassword'] == $strInputedPassword)
		{
			// Yes, set to true and break
			$blnLoginSuccessful = true;
			break;
		}
	}
}

// Close connection
mysqli_close($clsConn);

// Correct username & password?
if($blnLoginSuccessful == true)
{
	// Yes, send to admin page
	header("location: administration-home.php?id=" . $astrData = ['intAdminID']);
}
else
{
	// No, send back to login page
	header("location: login.php");
}


?>