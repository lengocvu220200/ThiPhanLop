-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th9 14, 2021 lúc 01:55 PM
-- Phiên bản máy phục vụ: 10.4.14-MariaDB
-- Phiên bản PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `thihk2_quanlytrungtam`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dsnguoiduthi`
--

CREATE TABLE `dsnguoiduthi` (
  `dsnguoiduthi_id` int(10) NOT NULL,
  `dsnguoiduthi_idngthi` int(10) NOT NULL,
  `dsnguoiduthi_idphthi` int(10) NOT NULL,
  `dsnguoiduthi_sbd` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `dsnguoiduthi`
--

INSERT INTO `dsnguoiduthi` (`dsnguoiduthi_id`, `dsnguoiduthi_idngthi`, `dsnguoiduthi_idphthi`, `dsnguoiduthi_sbd`) VALUES
(1, 4, 1, 'A2001'),
(2, 5, 1, 'A2002'),
(5, 4, 2, 'A2003'),
(7, 6, 2, 'A2005'),
(8, 9, 2, 'A2006'),
(9, 7, 3, 'B1001'),
(10, 8, 3, 'B1002'),
(11, 10, 1, 'A2007');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ketqua`
--

CREATE TABLE `ketqua` (
  `ketqua_id` int(10) NOT NULL,
  `ketqua_iddsngthi` int(10) NOT NULL,
  `ketqua_diemnghe` double NOT NULL,
  `ketqua_diemnoi` double NOT NULL,
  `ketqua_diemdoc` double NOT NULL,
  `ketqua_diemviet` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `ketqua`
--

INSERT INTO `ketqua` (`ketqua_id`, `ketqua_iddsngthi`, `ketqua_diemnghe`, `ketqua_diemnoi`, `ketqua_diemdoc`, `ketqua_diemviet`) VALUES
(2, 2, 9, 7, 9.1, 5),
(3, 11, 7, 8, 8, 8.5),
(4, 7, 7, 6, 6, 6),
(5, 8, 7, 6, 6, 6);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khoathi`
--

CREATE TABLE `khoathi` (
  `khoathi_id` int(10) NOT NULL,
  `khoathi_ten` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `khoathi`
--

INSERT INTO `khoathi` (`khoathi_id`, `khoathi_ten`) VALUES
(1, 'Tháng 1 - 2021'),
(2, 'Tháng 2 - 2021'),
(3, 'Tháng 3 - 2021'),
(4, 'Tháng 4 - 2021'),
(5, 'Tháng 5 - 2021'),
(6, 'Tháng 6 - 2021'),
(7, 'Tháng 7 - 2021'),
(8, 'Tháng 8 - 2021'),
(9, 'Tháng 9 - 2021'),
(10, 'Tháng 10 - 2021'),
(11, 'Tháng 11 - 2021'),
(12, 'Tháng 12 - 2021');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nguoiduthi`
--

CREATE TABLE `nguoiduthi` (
  `nguoiduthi_id` int(10) NOT NULL,
  `nguoiduthi_hoten` varchar(50) NOT NULL,
  `nguoiduthi_namsinh` varchar(10) NOT NULL,
  `nguoiduthi_gioitinh` varchar(5) NOT NULL,
  `nguoiduthi_cmnd` varchar(12) NOT NULL,
  `nguoiduthi_sdt` varchar(10) NOT NULL,
  `nguoiduthi_diachi` varchar(255) NOT NULL,
  `nguoiduthi_idkhoathi` int(200) NOT NULL,
  `nguoiduthi_idtrinhdo` int(10) NOT NULL,
  `nguoiduthi_trangthaiDS` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `nguoiduthi`
--

INSERT INTO `nguoiduthi` (`nguoiduthi_id`, `nguoiduthi_hoten`, `nguoiduthi_namsinh`, `nguoiduthi_gioitinh`, `nguoiduthi_cmnd`, `nguoiduthi_sdt`, `nguoiduthi_diachi`, `nguoiduthi_idkhoathi`, `nguoiduthi_idtrinhdo`, `nguoiduthi_trangthaiDS`) VALUES
(4, 'Lê Lan', '22/02/2000', 'Nữ', '123456789', '0987654321', 'ádasđ', 9, 1, 2),
(5, 'Nguyễn', '22/02/2000', 'Nam', '123456789', '0898726716', 'ádasđ', 9, 1, 2),
(6, 'trân', '19/01/2000', 'Nữ', '123456789', '0789898761', 'ádsa', 9, 1, 2),
(7, 'Hiền', '23/03/1996', 'Nữ', '123456789', '023456789', 'âsd', 9, 2, 2),
(8, 'Mai', '09/09/2003', 'Nam', '123456789', '0765419871', 'âs', 9, 2, 2),
(9, 'Bé Mai', '08/09/1998', 'Nữ', '123456789', '0945654672', 'đâs', 9, 1, 2),
(10, 'Gà', '22/07/1996', 'Nam', '123456789', '0987777779', 'sdsdsd', 9, 1, 2);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phongthi`
--

CREATE TABLE `phongthi` (
  `phongthi_id` int(10) NOT NULL,
  `phongthi_idkhoa` int(10) NOT NULL,
  `phongthi_idtrinhdo` int(10) NOT NULL,
  `phongthi_ten` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `phongthi`
--

INSERT INTO `phongthi` (`phongthi_id`, `phongthi_idkhoa`, `phongthi_idtrinhdo`, `phongthi_ten`) VALUES
(1, 9, 1, 'A2P01'),
(2, 9, 1, 'A2P02'),
(3, 9, 2, 'B1P03'),
(4, 9, 2, 'B1P04'),
(5, 9, 1, 'A2P05');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `trinhdo`
--

CREATE TABLE `trinhdo` (
  `trinhdo_id` int(10) NOT NULL,
  `trinhdo_ten` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `trinhdo`
--

INSERT INTO `trinhdo` (`trinhdo_id`, `trinhdo_ten`) VALUES
(1, 'A2'),
(2, 'B1');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `dsnguoiduthi`
--
ALTER TABLE `dsnguoiduthi`
  ADD PRIMARY KEY (`dsnguoiduthi_id`),
  ADD KEY `dsnguoiduthi_idngthi` (`dsnguoiduthi_idngthi`),
  ADD KEY `dsnguoiduthi_idphthi` (`dsnguoiduthi_idphthi`);

--
-- Chỉ mục cho bảng `ketqua`
--
ALTER TABLE `ketqua`
  ADD PRIMARY KEY (`ketqua_id`),
  ADD KEY `ketqua_iddsngthi` (`ketqua_iddsngthi`);

--
-- Chỉ mục cho bảng `khoathi`
--
ALTER TABLE `khoathi`
  ADD PRIMARY KEY (`khoathi_id`);

--
-- Chỉ mục cho bảng `nguoiduthi`
--
ALTER TABLE `nguoiduthi`
  ADD PRIMARY KEY (`nguoiduthi_id`),
  ADD KEY `nguoiduthi_idkhoathi` (`nguoiduthi_idkhoathi`),
  ADD KEY `nguoiduthi_idtrinhdo` (`nguoiduthi_idtrinhdo`);

--
-- Chỉ mục cho bảng `phongthi`
--
ALTER TABLE `phongthi`
  ADD PRIMARY KEY (`phongthi_id`),
  ADD KEY `phongthi_idkhoa` (`phongthi_idkhoa`),
  ADD KEY `phongthi_idtrinhdo` (`phongthi_idtrinhdo`);

--
-- Chỉ mục cho bảng `trinhdo`
--
ALTER TABLE `trinhdo`
  ADD PRIMARY KEY (`trinhdo_id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `dsnguoiduthi`
--
ALTER TABLE `dsnguoiduthi`
  MODIFY `dsnguoiduthi_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT cho bảng `ketqua`
--
ALTER TABLE `ketqua`
  MODIFY `ketqua_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `khoathi`
--
ALTER TABLE `khoathi`
  MODIFY `khoathi_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT cho bảng `nguoiduthi`
--
ALTER TABLE `nguoiduthi`
  MODIFY `nguoiduthi_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `phongthi`
--
ALTER TABLE `phongthi`
  MODIFY `phongthi_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `trinhdo`
--
ALTER TABLE `trinhdo`
  MODIFY `trinhdo_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `dsnguoiduthi`
--
ALTER TABLE `dsnguoiduthi`
  ADD CONSTRAINT `dsnguoiduthi_ibfk_1` FOREIGN KEY (`dsnguoiduthi_idngthi`) REFERENCES `nguoiduthi` (`nguoiduthi_id`),
  ADD CONSTRAINT `dsnguoiduthi_ibfk_2` FOREIGN KEY (`dsnguoiduthi_idphthi`) REFERENCES `phongthi` (`phongthi_id`);

--
-- Các ràng buộc cho bảng `ketqua`
--
ALTER TABLE `ketqua`
  ADD CONSTRAINT `ketqua_ibfk_1` FOREIGN KEY (`ketqua_iddsngthi`) REFERENCES `dsnguoiduthi` (`dsnguoiduthi_id`);

--
-- Các ràng buộc cho bảng `nguoiduthi`
--
ALTER TABLE `nguoiduthi`
  ADD CONSTRAINT `nguoiduthi_ibfk_1` FOREIGN KEY (`nguoiduthi_idkhoathi`) REFERENCES `khoathi` (`khoathi_id`),
  ADD CONSTRAINT `nguoiduthi_ibfk_2` FOREIGN KEY (`nguoiduthi_idtrinhdo`) REFERENCES `trinhdo` (`trinhdo_id`);

--
-- Các ràng buộc cho bảng `phongthi`
--
ALTER TABLE `phongthi`
  ADD CONSTRAINT `phongthi_ibfk_1` FOREIGN KEY (`phongthi_idkhoa`) REFERENCES `khoathi` (`khoathi_id`),
  ADD CONSTRAINT `phongthi_ibfk_2` FOREIGN KEY (`phongthi_idtrinhdo`) REFERENCES `trinhdo` (`trinhdo_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
