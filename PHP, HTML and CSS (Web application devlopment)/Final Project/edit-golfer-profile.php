<!DOCTYPE html>
<html>

	<head>
	<title>Final Project - Edit Profile</title>
	<link rel="stylesheet" href="../../Styles/Final Project - edit-golfer-profile.css">
	</head>
	<body>
<?php
include "db_connection.php";

// Get ID
$intGolferID = $_GET['id'];

// Get Golfer Infomation
$clsResult = mysqli_query($clsConn, "SELECT * FROM TGolfers WHERE intGolferID = $intGolferID");
$clsGenders = mysqli_query($clsConn, "SELECT intGenderID, strGender FROM TGenders");
$clsStates = mysqli_query($clsConn, "SELECT intStateID, strState FROM TStates");
$clsShirtSize = mysqli_query($clsConn, "SELECT intShirtSizeID, strShirtSize FROM TShirtSizes");

if(mysqli_num_rows($clsResult) > 0)
{
	$aRow =  mysqli_fetch_array($clsResult);
}

?>

	<h3 align="center">Enter information below:</h3>
	
	<div class="form-container01">
		<form name="frmGolfers" method="post" action="process_updateplayer.php?id=<?php echo $aRow['intGolferID']; ?>">
			<table>
			
			<tr>
				<td><label>Name</label></td>
			</tr>
				<tr>
					<!-- First Name -->
					<td>
						<input class="txtFirstName" type="text" id="txtFirstName" name="txtFirstName" placeholder="First Name" 
						value="<?php echo htmlspecialchars($aRow['strFirstName']); ?>" required>
					</td>
				
					<!-- Last Name -->
					<td>
						<input class="txtLastName" type="text" id="txtLastName" name="txtLastName" placeholder="Last Name"
						value="<?php echo htmlspecialchars($aRow['strLastName']); ?>" required>
					</td>
					
				</tr>
				
				<tr>
					<td><label>City & State</label></td>
				</tr>
				

				<tr>
					<!-- City -->
					<td>
						<input class="txtCity" type="text" id="txtCity" name="txtCity" placeholder="City" 
						value="<?php echo htmlspecialchars($aRow['strCity']); ?>" required>
					</td>
				
					<!-- State -->	
					<td>
					
						<select class="selState"  name="selState" required>
							<option value="">Select State</option>
							<?php
							

							
								if (mysqli_num_rows($clsStates) > 0) 
								{
									while($aRow2 = mysqli_fetch_assoc($clsStates)) 
									{
										if ($aRow2['intStateID'] == $aRow['intStateID']) 
										{
											$selected = "selected";
										} else {
											$selected = "";
										}
										
										echo "<option value ='".$aRow2["intStateID"]."' $selected>" . $aRow2["strState"].  "</option>";
										
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
						<label>Address</label>
					</td>
				</tr>
				<!-- Address -->
				<tr>
					<td colspan="2"><input class="txtInput" type="text" id="txtAddress" name="txtAddress" placeholder="Address" 
					value="<?php echo htmlspecialchars($aRow['strAddress']); ?>" required></td>
				</tr>
				
				<tr>
					<td>
						<label>Zip Code</label>
					</td>
				</tr>
				<!-- Zip Code -->
				<tr>
					<td colspan="2"><input class="txtInput" type="text" id="txtZipCode" name="txtZipCode" placeholder="Zip Code" 
					value="<?php echo htmlspecialchars($aRow['strZipCode']); ?>"required></td>
				</tr>
				
				
				<tr>
					<td><label>Phone Number</label></td>
				</tr>
				<!-- Phone Number -->
				<tr>
					<td colspan="2"><input class="txtInput" type="tel" id="txtPhoneNumber" name="txtPhoneNumber" placeholder="Phone Number" 
					value="<?php echo htmlspecialchars($aRow['strPhoneNumber']); ?>" required></td>
				</tr>

				<tr>
				<td>
					<label>Email Address</label>
				</td>
				</tr>
				<!-- Email -->
				<tr>
					<td colspan="2"><input class="txtInput" type="email" id="strEmail" name="txtEmail" placeholder="Email" 
					value="<?php echo htmlspecialchars($aRow['strEmail']); ?>" required></td>
				</tr>
				
				<tr>
				<td>
					<label>Shirt Size</label>
				</td>
				</tr>
				<!-- Shirt Size -->
				<tr>
					<td colspan="2">
						<select class="selSelect" name="selShirtSize" required>
						<option value="">Select Shirt Size</option>
							<?php
								if (mysqli_num_rows($clsShirtSize) > 0) 
								{
									while($aRow2 = mysqli_fetch_assoc($clsShirtSize)) 
									{
										if ($aRow2['intShirtSizeID'] == $aRow['intShirtSizeID']) 
										{
											$selected = "selected";
										} else {
											$selected = "";
										}
										
										echo "<option value ='".$aRow2["intShirtSizeID"]."' $selected>" . $aRow2["strShirtSize"].  "</option>";
										
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
				
				
				<!-- Gender -->
				
				<tr>
				<td>
					<label>Gender</label>
				</td>
				</tr>
				<tr>
					<td colspan="2">
						<select class="selSelect" name="selGender" required>
						<option value="">Select Gender</option>
							<?php
								if (mysqli_num_rows($clsGenders) > 0) 
								{
									while($aRow2 = mysqli_fetch_assoc($clsGenders)) 
									{
										if ($aRow2['intGenderID'] == $aRow['intGenderID']) 
										{
											$selected = "selected";
										} else {
											$selected = "";
										}
										
										echo "<option value ='".$aRow2["intGenderID"]."' $selected>" . $aRow2["strGender"].  "</option>";
										
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
				
				<!-- Submit and Clear Buttons -->
				<tr>
					<td colspan="2">
						<input class="button" type="submit" value="Submit" align="center">
						<input class="button" type="reset" value="Clear" align="center">
					</td>
				</tr>
			</table>
		</form>
	</div>

	</body>
	<?php
	// Close connection
	mysqli_close($clsConn);
	?>
	
</html>
