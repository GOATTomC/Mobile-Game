<?php
    $username = $_POST["Username"];
    $score = $_POST["Score"];
    $level = $_POST["Level"];
    $sql = "INSERT INTO Score('username', 'score', 'level') VALUES('$username', '$score', '$level')";

    if ($connection->query($sql) === true)
    {
        echo("Upload succeeded")
    }
    else
    {
    }
?>