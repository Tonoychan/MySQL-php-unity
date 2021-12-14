<?php

$con = mysqli_connect('localhost', 'root', 'root', 'learn');

if(mysqli_connect_errno()){
    echo("1");
    exit();
}


$appkey = $_POST["apppassword"];

if($appkey != "thisisfromtheapp!"){
    exit();
}


$tablequery = "SELECT username, score FROM players ORDER BY score DESC;";
$result = $con->query($tablequery) or die("2");

if($result->num_rows >0){
    $json_array= array();
    while($row = mysqli_fetch_assoc($result)){
        $json_array[] = $row;
    }
    echo json_encode($json_array);
} else {
    echo ("3");
}

//Error Codes
//1 - Database Connection Error
//2 - Table query Error;
//3 - Result didn't have any info


?>