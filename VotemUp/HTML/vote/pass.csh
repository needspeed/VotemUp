<html>
<head>
<style type="text/css">
@import url("Design.css");
</style>
</head>
<body>
<header>
<div id="act">
<a href="index.csh"><img src="button1.png" height="50px"></a>
</div>
<div id="inact">
<a href="vote.csh"><img src="arrow.png" height="50px"></a>
</div>
</header>
<div id="wrapper">
  <div id="scroll-content">
    	<form action=index.cs method=post>
        	<table width="100%" cellpadding="3" cellspacing="3">
	<tr>
		<td id="input">Username</td>
		<td><input type="text" name="user" id="infield"></td>
	</tr>
	<tr>
		<td id="input">Password</td>
		<td><input type="password" name="pw" id="infield"></td>
	</tr>
	<tr>
		<td id="input">SongID</td>
		<td><input type="text" name="uid" id="infield" value="<cs>getVar($UID);</cs>"></td>
	</tr>
</table>
<input type="submit" value="submit">

        	
    </form>
    </div>
</div>
</body>
</html>
