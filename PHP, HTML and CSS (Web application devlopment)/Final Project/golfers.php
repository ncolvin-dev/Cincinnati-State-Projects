<html>
<head>
	<title>Golfer Fundrasier - The Golfers</title>
	<link rel="stylesheet", href="../../Styles/final-project-golfers.css">
	<link href="https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Special+Gothic+Expanded+One&display=swap" rel="stylesheet">
</head>



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



	
	<main>
		<?php
			include "db_connection.php";
			$strSQL = "SELECT strFirstName, strLastName, intGolferID FROM TGolfers";
			
			// Successful?
			if ($clsGolfers = mysqli_query($clsConn, $strSQL) )
			{
				// Yes, display event golfer information
				echo "<table border=1>";
					echo "<tr>";
						echo "<th>First Name</th>";
						echo "<th>Last Name</th>";
						echo "<th>Profile</th>";
					echo "</tr>";
				// Not null?
				if(mysqli_num_rows($clsGolfers) > 0)
				{
					// Yes, display information
					while($aGolferData = mysqli_fetch_array($clsGolfers))
					{
						echo "<tr>";
							echo "<td>" . $aGolferData['strFirstName'] . "</td>";
							echo "<td>" . $aGolferData['strLastName'] . "</td>";
							echo "<td><a href='edit-golfer-profile.php?id=" . $aGolferData['intGolferID'] . "'>  <button type='button'>Edit Profile</button>  </a></td>";
						echo "</tr>";
					}
					echo "</table>";
				}
			}
		?>
	</main>
	
	<?php
	// Close connection
	mysqli_close($clsConn);
	?>
	
</div>
</body>