<?php
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
?>
