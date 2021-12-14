<?php

$con = mysqli_connect('localhost:8889', 'root', 'root', 'learn');

if(mysqli_connect_errno()){
    echo ("1");
    exit();
}

//$appkey = $_POST["apppassword"];
// if($appkey != "thisisfromtheapp!"){
//     exit();
// }

$username = $_POST["username"];
$usernameClean = filter_var($username, FILTER_SANITIZE_EMAIL);
$password = $_POST["password"];

$usernamecheckquery = "SELECT * FROM players WHERE username = '" . $usernameClean . "';";
$usernamecheckresult = mysqli_query($con, $usernamecheckquery) or die ("2");

if($usernamecheckresult->num_rows !=1){
    echo("3");
    exit();
} else {
    $fetchedpassword = mysqli_fetch_assoc($usernamecheckresult)["password"];
    if($password==$fetchedpassword){
        $playerInfo = "SELECT * FROM players WHERE username = '" . $usernameClean . "';";
        $playerInfoResult = mysqli_query($con, $playerInfo) or die ("5");
        $existingPlayerInfo = mysqli_fetch_assoc($playerInfoResult);
        $playerUsername = $existingPlayerInfo["username"];
        $playerScore = $existingPlayerInfo["score"];
        echo($playerUsername . ":" . $playerScore);
    } else {
        echo ("4");
    }
}

$con->close();

//Error Codes
//1 - Database Connection Error
//2 - Username query error;
//3 - Username not existing or there is more than 1 in the table
//4 - Password was not able to be verified
//5 - Playerinfo Query Failed;


?>