<?php
    $db_host = "localhost";
    $db_username = "tomcofm323_Slicebeat";
    $db_password = "Slicebeat";
    $db_name = "tomcofm323_Slicebeat";
    
    $connection = new mysqli($db_host, $db_username, $db_password, $db_name);
    

    //Check if connection is made
    if (!$connection) 
    {
        die("Connection failed: " . mysqli_connect_error()); //If not kill the script
    }
?>