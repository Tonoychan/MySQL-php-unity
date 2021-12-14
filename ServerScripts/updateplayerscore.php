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
$score = $_POST["score"];

$usernamecheckquery = "SELECT * FROM players WHERE username = '" .$username. "'";
$usernamecheckresult = mysqli_query($con, $usernamecheckquery) or die("2");

if($usernamecheckresult->num_rows !=1){
    echo ("3");
    exit();
}

$updateuserquery = "UPDATE players SET score = '" .$score. "' WHERE username = '".$username."';";
mysqli_query($con, $updateuserquery) or die("4");

echo ("0");

$con->close();


//Error Codes
//0 - Success!
//1 - Database Connection Error
//2 - Username query error;
//3 - Username not existing or there is more than 1 in the table
//4 - Update failed;


?>