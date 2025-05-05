<!DOCTYPE html>
<html>
<?php
include "db_connection.php";

$clsEvent = mysqli_query($clsConn, "SELECT intEventID FROM TEvents ORDER BY intEventID DESC LIMIT 1");
$aEventData = mysqli_fetch_assoc($clsEvent);
$intEventID = $aEventData["intEventID"];

$clsSponsorID = mysqli_query($clsConn, "SELECT MAX(intSponsorID) as ID FROM TSponsors");
$aSponsorData = mysqli_fetch_assoc($clsSponsorID);
$intSponsorID = $aSponsorData["ID"];
$intSponsorID += 1;

echo $intSponsorID . "<br>";

$strFirstName = $_POST['txtFirstName'];
$strLastName = $_POST['txtLastName'];
$strAddress = $_POST['txtAddress'];
$strCity = $_POST['txtCity'];
$intStateID = $_POST['selState'];
$strZipCode = $_POST['txtZipcode'];
$strPhoneNumber = $_POST['txtPhoneNumber'];
$strEmail = $_POST['txtEmail'];

$intGolferID = $_POST['selGolfer'];
$clsEventGolferID = mysqli_query($clsConn, "SELECT intEventGolferID FROM teventgolfers WHERE intGolferID = $intGolferID and intEventID = $intEventID;");
$aEventGolferData = mysqli_fetch_assoc($clsEventGolferID);
$intEventGolferID = $aEventGolferData["intEventGolferID"];


$dblAmount = $_POST['dblAmount'];

$strPaymentType = $_POST["selPaymentType"];
$clsPaymentTypeID = mysqli_query($clsConn, "SELECT intPaymentTypeID FROM TPaymentTypes WHERE strPaymentType = '" .$strPaymentType . "'" );
$aPaymentTypeData = mysqli_fetch_assoc($clsPaymentTypeID);
$intPaymentTypeID = $aPaymentTypeData["intPaymentTypeID"];

$strSQLInsert = "INSERT INTO TSponsors (intSponsorID, strFirstName, strLastName, strAddress, strCity, intStateID, strZipCode, strPhoneNumber, strEmail) 
 VALUES ($intSponsorID, '$strFirstName', '$strLastName', '$strAddress', '$strCity', $intStateID, '$strZipCode', '$strPhoneNumber', '$strEmail')";
echo $strSQLInsert . "<br>";
$clsInsert = mysqli_query($clsConn, $strSQLInsert);
// Capture form data 

if ($clsInsert) {
    echo "Insert successful!";
} else {
    echo "Insert failed: " . mysqli_error($clsConn);
}


$clsEventSponsorID = mysqli_query($clsConn, "SELECT MAX(intEventGolferSponsorID) as ID FROM TEventGolferSponsors");
$aEventSponsorData = mysqli_fetch_assoc($clsEventSponsorID);
$intEventGolferSponsorID = $aEventSponsorData["ID"];
$intEventGolferSponsorID += 1;
$dtmDateOfPledge = date("Y/m/d");

$strSQLInsert2 = "INSERT INTO TEventGolferSponsors ( intEventGolferSponsorID, intEventGolferID, intSponsorID, dtmDateOfPledge, dblPledgePerHole, intPaymentTypeID, intPaymentStatusID)
VALUES ($intEventGolferSponsorID, $intEventGolferID, $intSponsorID, '$dtmDateOfPledge', $dblAmount, $intPaymentTypeID, 2)";
echo $strSQLInsert2 . "<br>";

$clsInsert2 = mysqli_query($clsConn, $strSQLInsert2);

if ($clsInsert2) {
    echo "Insert successful!";
} else {
    echo "Insert failed: " . mysqli_error($clsConn);
}


?>

<head>
    <title>Thank You - Golfer Fundraiser</title>
    <link rel="stylesheet" href="../../Styles/Final Project - homepage.css">
    <link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
    <style>
        .thank-you-container {
            max-width: 600px;
            margin: 80px auto;
            padding: 30px;
            text-align: center;
            background-color: #f4f4f4;
            border-radius: 10px;
        }
        .thank-you-container h1 {
            color: #2e8b57;
        }
        .thank-you-details {
            margin-top: 20px;
            font-size: 18px;
        }
    </style>
</head>
<body>
    <div class="thank-you-container">
        <h1>Thank You for Your Donation!</h1>

        <?php
		
		$dblAmount = $dblAmount * 100;
        echo "<div class='thank-you-details'>";
        echo "<p><strong>Donor:</strong> $strFirstName $strLastName</p>";
        echo "<p><strong>Amount Donated:</strong> $dblAmount</p>";
        echo "<p><strong>Supported Golfer:</strong> $intEventGolferID</p>";
        echo "</div>";
        ?>

        <p>We appreciate your generous contribution to support our event and golfers.</p>
        <br>
        <a href="homepage.php">Back to Homepage</a>
    </div>
</body>
<?php
// Close connection
mysqli_close($clsConn);
?>
</html>