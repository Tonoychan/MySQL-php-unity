<?php

$con = mysqli_connect('localhost:8889', 'root', 'root', 'learn');

if(mysqli_connect_errno()){
    echo("1");
    exit();
}

//wwwform from Unity
$username = $_POST["username"];
$usernameClean = filter_var($username, FILTER_SANITIZE_EMAIL);
$email = $_POST["email"];
$emailClean = filter_var($email, FILTER_SANITIZE_EMAIL);
$password = $_POST["password"];
//$passhash = password_hash($password, PASSWORD_DEFAULT);
//$appkey = $_POST["apppassword"];

// if($appkey != "thisisfromtheapp!"){
//     exit();
// }

$usernamecheckquery = "SELECT username FROM players WHERE username = '" . $usernameClean . "'; ";
$usernamecheck = mysqli_query($con, $usernamecheckquery) or die("2");

if(mysqli_num_rows($usernamecheck)>0){
    echo("3");
    exit();
}

$emailcheckquery = "SELECT email FROM players WHERE email = '" . $emailClean . "'; ";
$emailcheck = mysqli_query($con, $emailcheckquery) or die("4");

if(mysqli_num_rows($emailcheck)>0){
    echo("5");
    exit();
}

$insertuserquery = "INSERT INTO players(username, email, password) VALUES('". $usernameClean ."', '". $emailClean."', '". $password ."');";
mysqli_query($con, $insertuserquery) or die("6");
echo ("0");

$con->close();


//Error Codes
//1 - Database Connection Error
//2 - Usernamecheck query run into an error;
//3 - User already exists;
//4 - Emailcheck query failed;
//5 - Email already exists;
//6 - Insert user failed

?>