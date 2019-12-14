<?php
    $ketnoi['host'] = 'mysql06.dotvndns.vn:3306'; //Tên server, nếu dùng hosting free thì cần thay đổi
    $ketnoi['dbname'] = 'iottechn_asp'; //Đây là tên của Database
    $ketnoi['username'] = 'iotechn'; //Tên sử dụng Database
    $ketnoi['password'] = 'admin1@';//Mật khẩu của tên sử dụng Database
    @mysql_connect(
        "{$ketnoi['host']}",
        "{$ketnoi['username']}",
        "{$ketnoi['password']}")
    or
        die("Không thể kết nối database");
    @mysql_select_db(
        "{$ketnoi['dbname']}") 
    or
        die("Không thể chọn database");
?>