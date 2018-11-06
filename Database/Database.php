<?php
    $db_host = "sql2.freemysqlhosting.net";
    $db_username = "sql2264315";
    $db_password = "lL9*sL2!";
    $db_name = "sql2264315";
    
    $connection = new mysqli($db_host, $db_username, $db_password, $db_name);
    
    if ($connection->connect_error) {
        die("Connection failed: " . $connection->connect_error);
    }
?>