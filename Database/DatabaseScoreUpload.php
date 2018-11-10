<?php
    $username = $_POST["Username"];
    $score = $_POST["Score"];
    $level = $_POST["Level"];
    
    $sql = "INSERT INTO HighScore(username, score, level) VALUES('".$username."', '".$score."', '".$level."')";
    $result = mysqli_query($connection, $sql);
    
?>