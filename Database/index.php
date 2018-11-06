<?php

//Make connection with database;
require("Database.php");

$db_action = $_POST["Action"];

switch($db_action)
{
    case "UploadScore":
        require("DatabaseScoreUpload.php");
    break;
}
?>