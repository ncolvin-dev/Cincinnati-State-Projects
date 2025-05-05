<!DOCTYPE html>

<html>
<head>
	<title>Golfer Fundrasier - Login</title>
	<link rel="stylesheet", href="../../Styles/final-project-login-page.css">
	<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">
</head>


<body>
<div ID="wrapper">
	<div class="LoginWrapper">
		<h2>Login for Administration</h2>
		<form name="frmGolfers" method="post" action="check-info.php">
			<table>
				<tr>
					<td><label>Username</label></td>
				</tr>
				<tr>
					<td colspan="2"><input class="txtLogin" type="text" name="txtUsername" placeholder="User Name" required></td>
				</tr>
				<tr>
					<td><label>Password</label></td>
				</tr>
				<tr>
					<td colspan="2"><input class="txtLogin" type="password"  name="txtPassword" placeholder="Password" required></td>
				</tr>
				
				<tr>
					<td colspan="2"><input class="btnButton" type="submit"  name="btnSumbit" value="Submit" required></td>
				</tr>
				<tr>
					<td colspan="2" class="AdminInfo">**username: isoring**  **password: ispassword**</td>
				</tr>
			</table>
		</form>
	</div>
</div>
</body>
</html>