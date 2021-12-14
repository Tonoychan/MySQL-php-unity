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

$Search = $_POST["search"];
$searchClean = filter_var($Search, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_HIGH);

$searchquery = "SELECT username, score FROM players WHERE username LIKE '%".$searchClean."%' or email LIKE '%".$searchClean."%' ORDER BY score DESC;";
$result = $con->query($searchquery) or die("2");

if($result->num_rows >0){
    $json_array = array();
    while($row = mysqli_fetch_assoc($result)){
        $json_array[] = $row;
    }

    echo json_encode($json_array);
} else {
    echo("0");
}

$con->close();




//Error Codes
//1 - Database Connection Error
//2 - Error with the search
//0 - No Results


?>