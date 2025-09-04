-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 20, 2021 at 08:11 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `digital_signage`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `id` int(11) NOT NULL,
  `addr` text NOT NULL,
  `email` text NOT NULL,
  `phone` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`id`, `addr`, `email`, `phone`) VALUES
(1, 'University of Punjab Gujranwala campus', '17581556-060@mail.pugc.edu.pk  17581556-071@mail.pugc.edu.pk', '+923045117536');

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `email` text NOT NULL,
  `password` text NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `email`, `password`, `status`, `created_at`) VALUES
(1, 'admin', 'admin@gmail.com', '0192023a7bbd73250516f069df18b500', 1, '2021-05-09 11:00:40'),
(2, 'Sultan', '17581556-093@uog.edu.pk', '81dc9bdb52d04dc20036dbd8313ed055', 1, '2021-06-20 14:21:08');

-- --------------------------------------------------------

--
-- Table structure for table `brand`
--

CREATE TABLE `brand` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `brand`
--

INSERT INTO `brand` (`id`, `name`) VALUES
(4, 'Samsung'),
(5, 'OPPO'),
(6, 'IPhone'),
(7, 'HP'),
(8, 'SanDisk'),
(9, 'Dawlance'),
(10, 'Orient'),
(11, 'Haier'),
(12, 'Canon'),
(13, 'PEL'),
(14, 'Kingston'),
(15, 'LG');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `session` text NOT NULL,
  `quantity` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`id`, `product_id`, `session`, `quantity`, `created_at`) VALUES
(1, 7, '0', 9, '2021-05-20 18:25:36'),
(2, 7, '19', 0, '2021-05-18 20:59:35'),
(5, 7, '29', 0, '2021-05-19 10:07:13'),
(6, 7, '14', 0, '2021-05-19 10:26:52'),
(7, 6, '19', 0, '2021-05-19 10:28:09'),
(8, 5, '19', 0, '2021-05-19 10:28:11'),
(11, 7, '21', 1, '2021-05-19 11:35:10'),
(14, 7, '15', 1, '2021-05-20 18:05:45'),
(15, 7, '1', 1, '2021-05-20 18:07:29'),
(16, 7, '11', 1, '2021-05-20 18:21:57'),
(18, 7, '6', 1, '2021-05-20 18:23:54'),
(19, 5, '0', 3, '2021-05-20 18:27:01'),
(20, 6, '0', 1, '2021-05-20 18:26:51'),
(21, 5, '20', 2, '2021-05-20 19:44:06'),
(25, 7, '16', 1, '2021-05-20 19:05:58'),
(26, 7, '28', 1, '2021-05-20 19:10:10'),
(28, 7, '20', 3, '2021-05-20 19:44:45'),
(29, 7, '22', 1, '2021-05-20 21:02:33'),
(30, 5, '22', 1, '2021-05-20 21:02:41'),
(31, 6, '22', 1, '2021-05-20 21:02:43'),
(32, 7, '27', 1, '2021-05-20 21:08:50'),
(33, 7, '10', 1, '2021-05-20 21:11:08'),
(34, 5, '10', 2, '2021-05-21 06:09:21'),
(35, 6, '10', 3, '2021-05-21 06:09:25'),
(38, 14, '0', 1, '2021-05-22 20:13:44'),
(39, 5, '16', 1, '2021-05-22 20:49:28'),
(41, 0, '5', 1, '2021-05-24 13:20:37'),
(42, 5, '23', 1, '2021-05-24 13:35:45'),
(43, 13, '23', 1, '2021-05-24 13:35:49'),
(48, 16, '4', 1, '2021-05-29 09:47:14'),
(53, 18, '12', 1, '2021-06-17 11:29:38'),
(54, 30, '12', 1, '2021-06-17 11:29:46'),
(55, 69, '12', 1, '2021-06-17 11:30:12'),
(57, 70, '12', 1, '2021-06-17 11:40:25'),
(60, 69, '4', 1, '2021-06-20 08:15:03'),
(61, 22, '9', 1, '2021-06-20 12:13:54'),
(62, 22, '25', 1, '2021-06-20 12:49:49');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `image` text NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`, `image`, `status`, `created_at`) VALUES
(16, 'Mobile Phones', 'images/logo_mobilephone.png', 1, '2021-06-01 06:12:41'),
(17, 'Laptop', 'images/logo_laptop.jpg', 1, '2021-06-01 06:13:00'),
(18, 'Cameras', 'images/logo_camera.jpg', 1, '2021-06-01 06:14:19'),
(19, 'Computer Accessories', 'images/logo_accessy.jpg', 1, '2021-06-01 06:15:24'),
(20, 'Home Appliances', 'images/logo_appliances.jpg', 1, '2021-06-01 06:15:55');

-- --------------------------------------------------------

--
-- Table structure for table `favorite`
--

CREATE TABLE `favorite` (
  `id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `email` text NOT NULL,
  `phone_number` text NOT NULL,
  `city` text NOT NULL,
  `address` text NOT NULL,
  `status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `orders`
--
INSERT INTO `orders` (`id`, `username`, `email`, `phone_number`, `city`, `address`, `status`, `order_date`) VALUES
(1,  'Aleeza Aftab', 'aleeza@gmail.com', '03013356886', 'Multan', '935 Johnson Club', 'Pending', '2025-03-04')),
(2,  'Ayesha Shahbaz', 'ayesha@gmail.com', '03128728463', 'Multan', '903 English Road Apt. 712', 'Completed', '2025-04-28')),
(3,  'Mary Leon', 'greenrebecca@miller.net', '03355667651', 'Islamabad', '7480 Michael Points Suite 737', 'Completed', '2025-02-28')),
(4,  'Steven Willis', 'warechristine@matthews.com', '03223718431', 'Gujranwala', '65221 Meza Oval', 'Pending', '2025-02-13')),
(5,  'Joseph Johnson', 'rowejoseph@wilcox.org', '03256164955', 'Rawalpindi', '86812 Robin Ways', 'Pending', '2025-05-15')),
(6,  'Kimberly Navarro', 'vmartin@kerr.com', '03071662963', 'Rawalpindi', '2181 Dixon Shoal', 'Completed', '2025-05-30')),
(7,  'Elizabeth Yates', 'david76@parker.com', '03320576383', 'Rawalpindi', '56371 Kenneth Shoal Suite 391', 'Pending', '2025-05-18')),
(8,  'Wesley Chase', 'nathan24@brown-richards.org', '03458537831', 'Rawalpindi', '504 Hill Island Suite 725', 'Completed', '2025-05-02')),
(9,  'Ivan Lloyd', 'nkramer@yahoo.com', '03016150444', 'Multan', '4977 Natalie Passage', 'Completed', '2025-05-10')),
(10,  'Dr. Erin Mack MD', 'michelle37@smith.biz', '03220709497', 'Faisalabad', '97264 Sheila Plains Apt. 218', 'Completed', '2025-05-22')),
(11,  'Stephanie Edwards', 'dmoreno@hotmail.com', '03061019678', 'Islamabad', '434 Jones Loop Suite 440', 'Pending', '2025-04-23')),
(12,  'Mary Salas', 'martha42@yahoo.com', '03231831063', 'Islamabad', '1238 Norman Summit Suite 660', 'Pending', '2025-02-27')),
(13,  'Angela Reilly', 'christopher62@fitzgerald-rodriguez.com', '03296977837', 'Gujranwala', '843 Russell Curve Suite 991', 'Canceled', '2025-04-23')),
(14,  'Cody Williams', 'ipennington@davis-woodard.net', '03181691040', 'Multan', '843 Danielle Point', 'Completed', '2025-02-21')),
(15,  'Mr. Timothy Hines', 'davidaaron@gmail.com', '03360929647', 'Islamabad', '980 Bryan Ramp Apt. 231', 'Canceled', '2025-04-30')),
(16,  'Matthew Smith', 'vegalinda@gmail.com', '03439476249', 'Multan', '1630 Sarah Island Suite 117', 'Pending', '2025-05-19')),
(17,  'Yvonne Torres', 'jensenmarilyn@yahoo.com', '03040742311', 'Faisalabad', '6418 Mason Burgs Apt. 118', 'Completed', '2025-05-15')),
(18,  'Tina Tanner', 'wintersmichael@parsons-ellison.com', '03263843426', 'Islamabad', '4360 Pamela Circle Suite 055', 'Completed', '2025-02-28')),
(19,  'Jamie Ellison', 'bblack@gmail.com', '03452235350', 'Lahore', '404 Diane Rue', 'Canceled', '2025-04-05')),
(20,  'Jacob Washington', 'mgomez@hotmail.com', '03396282117', 'Karachi', '686 Gina Port', 'Completed', '2025-03-06')),
(21,  'Julia Evans', 'jodi37@baird.com', '03143101783', 'Multan', '609 Bradford Landing', 'Canceled', '2025-04-10')),
(22,  'Allison Chavez', 'qdouglas@yahoo.com', '03288461803', 'Karachi', '98346 David Orchard Suite 954', 'Canceled', '2025-03-24')),
(23,  'Dakota Shepard', 'jessica59@mueller.com', '03239436733', 'Lahore', '375 Ashley Fords', 'Canceled', '2025-04-05')),
(24,  'Craig Madden', 'franceschavez@gibson.com', '03016323852', 'Faisalabad', '744 Holmes Courts Suite 224', 'Completed', '2025-02-20')),
(25,  'Hannah Robertson', 'hprice@yahoo.com', '03166661351', 'Rawalpindi', '42045 Chambers Via', 'Completed', '2025-03-22')),
(26,  'David Torres', 'jonathan60@hotmail.com', '03389978790', 'Karachi', '6364 Douglas Mount Apt. 532', 'Canceled', '2025-03-05')),
(27,  'David Thompson', 'hrocha@gmail.com', '03411540956', 'Multan', '460 Ronald Spurs Apt. 689', 'Canceled', '2025-02-15')),
(28,  'Wanda Holden', 'michelle21@yahoo.com', '03445812670', 'Faisalabad', '868 William Falls', 'Canceled', '2025-03-16')),
(29,  'Mark Stewart', 'walkersusan@summers.org', '03049392920', 'Karachi', '0976 Katherine Mission', 'Completed', '2025-03-31')),
(30,  'Steven Stevens', 'christopherthomas@gmail.com', '03045351479', 'Rawalpindi', '3380 Robin Brooks Suite 509', 'Completed', '2025-04-06')),
(31,  'Ronnie Manning', 'isimon@hotmail.com', '03093926371', 'Islamabad', '48864 Charles View', 'Canceled', '2025-04-06')),
(32,  'Theresa Hernandez', 'bestbrenda@williams-thompson.com', '03436697396', 'Lahore', '119 Shaw Parks Apt. 602', 'Pending', '2025-05-09')),
(33,  'Dana Dillon', 'imiller@yahoo.com', '03182394227', 'Faisalabad', '114 Colton Squares', 'Canceled', '2025-05-29')),
(34,  'Dana Holland', 'melissahodge@bruce.biz', '03090388981', 'Islamabad', '4656 Kathryn Greens', 'Pending', '2025-02-03')),
(35,  'Cheryl Blankenship', 'hking@yahoo.com', '03058718453', 'Faisalabad', '487 Mark Points', 'Pending', '2025-03-03')),
(36,  'Daniel Green', 'kevinmcfarland@johnson-moore.biz', '03042329237', 'Rawalpindi', '207 Briana Island', 'Completed', '2025-02-11')),
(37,  'John Atkins', 'agregory@hotmail.com', '03319289546', 'Faisalabad', '83027 Thomas Light', 'Canceled', '2025-05-10')),
(38,  'David Wilkerson', 'robinmiller@zamora.com', '03127232410', 'Multan', '1194 Holmes Pine Suite 199', 'Pending', '2025-04-12')),
(39,  'Laurie Bailey', 'laura76@yahoo.com', '03145575298', 'Rawalpindi', '6073 Keller Glen', 'Canceled', '2025-03-27')),
(40,  'Ricky Thompson', 'lozanocindy@yahoo.com', '03182383095', 'Faisalabad', '915 Michael Lake', 'Canceled', '2025-04-30')),
(41,  'Sarah Wade', 'yflores@yahoo.com', '03151837852', 'Karachi', '287 Nixon Throughway', 'Canceled', '2025-04-25')),
(42,  'Chelsea Meyer', 'ryan23@spears-chavez.net', '03268800797', 'Rawalpindi', '4806 Jake Groves', 'Pending', '2025-02-16')),
(43,  'Diane Woods', 'edgar58@velasquez.com', '03140158366', 'Gujranwala', '3978 William Drives', 'Pending', '2025-02-03')),
(44,  'Derrick Bennett', 'jyu@smith.net', '03484346088', 'Lahore', '563 Caroline Manors', 'Canceled', '2025-03-01')),
(45,  'Anthony Martinez', 'johnhernandez@russell.com', '03019528530', 'Multan', '4107 Mindy Cove Apt. 184', 'Canceled', '2025-02-08');)
(46, 'Michael Anderson', 'mitchelldarren@yahoo.com', '03054349361', 'Gujranwala', '905 Nichols Radial Suite 603', 'Canceled', '2025-03-03'),
(47, 'Sandra Webb', 'jamesmarc@gonzalez.com', '03299788677', 'Karachi', '480 Ford Squares Suite 258', 'Completed', '2025-04-11'),
(48, 'Mary Romero', 'kimcastro@yahoo.com', '03186644106', 'Rawalpindi', '4387 Barnett Burg Apt. 357', 'Pending', '2025-03-04'),
(49, 'Diane Mcclain', 'michael25@hotmail.com', '03364634663', 'Lahore', '464 York Glens', 'Completed', '2025-02-13'),
(50, 'Aaron Lynch', 'bentleyjason@yahoo.com', '03357553014', 'Karachi', '6467 Danielle Mall', 'Pending', '2025-04-01');

-- --------------------------------------------------------

--
-- Table structure for table `order_products`
--

CREATE TABLE `order_products` (
  `id` int(11) NOT NULL,
  `order_id` text NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_price` text NOT NULL,
  `quantity` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `order_products`
--

INSERT INTO `order_products` (`id`, `order_id`, `product_id`, `product_price`, `quantity`) VALUES
(1, '1', 7, '520', '1'),
(2, '1', 5, '22222', '1'),
(3, '1', 6, '10000', '1'),
(4, '0', 7, '520', '1'),
(5, '5', 7, '520', '1'),
(6, '6', 7, '520', '1'),
(7, '6', 5, '22222', '2'),
(8, '6', 6, '10000', '3'),
(9, '7', 7, '520', '1'),
(10, '8', 7, '520', '1'),
(11, '8', 16, '1000', '1'),
(12, '9', 16, '1000', '3'),
(13, '10', 16, '1000', '1'),
(14, '11', 16, '1000', '5'),
(15, '12', 30, '200000', '1'),
(16, '13', 30, '200000', '1');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `title` text NOT NULL,
  `brand` int(11) NOT NULL,
  `image` text NOT NULL,
  `image2` text NOT NULL,
  `image3` text NOT NULL,
  `image4` text NOT NULL,
  `new_price` int(11) NOT NULL,
  `rating` int(11) NOT NULL,
  `details` text NOT NULL,
  `is_top_rate` int(11) NOT NULL,
  `is_hot_product` int(11) NOT NULL,
  `is_best_deal` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `sub_category_id` int(11) NOT NULL,
  `created_id` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `quantity` int(11) NOT NULL,
  `qr_code` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `title`, `brand`, `image`, `image2`, `image3`, `image4`, `new_price`, `rating`, `details`, `is_top_rate`, `is_hot_product`, `is_best_deal`, `category_id`, `sub_category_id`, `created_id`, `quantity`, `qr_code`) VALUES
(22, 'Galaxy Note20', 4, 'images/Samsung-Galaxy-Note-20-Image-1.jpg', 'images/Samsung-Galaxy-Note-20-Image-2.jpg', 'images/Samsung-Galaxy-Note-20-Image-3.jpg', 'images/Samsung-Galaxy-Note-20-Image-4.jpg', 199999, 0, '<figure class=\"table\"><table><tbody><tr><th rowspan=\"6\"><strong>Build</strong></th><td><strong>OS</strong></td><td colspan=\"2\">Android 10 OS &nbsp;</td></tr><tr><td><strong>UI</strong></td><td colspan=\"2\">OneUI 2.5 &nbsp;</td></tr><tr><td><strong>Dimensions</strong></td><td colspan=\"2\">161.6 x 75.2 x 8.3 mm &nbsp;</td></tr><tr><td><strong>Weight</strong></td><td colspan=\"2\">192 g &nbsp;</td></tr><tr><td><strong>SIM</strong></td><td colspan=\"2\">Hybrid Dual Sim, Dual Standby, eSIM, (Nano-SIM) &nbsp;</td></tr><tr><td><strong>Colors</strong></td><td colspan=\"2\">Mystic Grey, Mystic Green, Mystic Bronze &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Frequency</strong></th><td><strong>2G Band</strong></td><td colspan=\"2\"><strong>SIM1:</strong> GSM 850 / 900 / 1800 / 1900<br><strong>SIM2:</strong> GSM 850 / 900 / 1800 / 1900 &nbsp;</td></tr><tr><td><strong>3G Band</strong></td><td colspan=\"2\">HSDPA 850 / 900 / 1700(AWS) / 1900 / 2100 &nbsp;</td></tr><tr><td><strong>4G Band</strong></td><td colspan=\"2\">LTE band 1(2100), 2(1900), 3(1800), 4(1700/2100), 5(850), 7(2600), 8(900), 12(700), 13(700), 17(700), 18(800), 19(800), 20(800), 25(1900), 26(850), 28(700), 32(1500), 38(2600), 39(1900), 40(2300), 41(2500), 66(1700/2100) &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Processor</strong></th><td><strong>CPU</strong></td><td colspan=\"2\">Octa-core (2 x 2.73 GHz Mongoose M5 + 2 x 2.50 GHz Cortex-A76 + 4 x 2.0 GHz Cortex-A55) &nbsp;</td></tr><tr><td><strong>Chipset</strong></td><td colspan=\"2\">Exynos 990 (7 nm+) &nbsp;</td></tr><tr><td><strong>GPU</strong></td><td colspan=\"2\">Mali-G77 MP11 &nbsp;</td></tr><tr><th rowspan=\"4\"><strong>Display</strong></th><td><strong>Technology</strong></td><td colspan=\"2\">Super AMOLED Capacitive Touchscreen, 16M Colors, Multitouch &nbsp;</td></tr><tr><td><strong>Size</strong></td><td colspan=\"2\">6.7 Inches &nbsp;</td></tr><tr><td><strong>Resolution</strong></td><td colspan=\"2\">1080 x 2400 Pixels (~393 PPI) &nbsp;</td></tr><tr><td><strong>Extra Features</strong></td><td colspan=\"2\">HDR10+, Always-on display &nbsp;</td></tr><tr><th rowspan=\"2\"><strong>Memory</strong></th><td><strong>Built-in</strong></td><td colspan=\"2\">256GB Built-in, 8GB RAM, UFS 3.1 &nbsp;</td></tr><tr><td><strong>Card</strong></td><td colspan=\"2\">No &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Camera</strong></th><td><strong>Main</strong></td><td colspan=\"2\">Triple Camera: 12 MP, f/1.8, 26mm (wide), 1/1.76\", Dual Pixel PDAF, OIS + 64 MP, f/2.0, 29mm (telephoto), 1/1.72\", PDAF, OIS, 1.1x optical zoom, 3x hybrid zoom + 12 MP, f/2.2, 13mm (ultrawide), 1/2.55\", PDAF, Super Steady video, LED Flash &nbsp;</td></tr><tr><td><strong>Features</strong></td><td colspan=\"2\">Geo-tagging, touch focus, face/smile detection, Auto HDR, panorama, Video (8K@24fps, 4K@30/60fps, 1080p@30/60/240fps, 720p@960fps, HDR10+, stereo sound rec., gyro-EIS &amp; OIS) &nbsp;</td></tr><tr><td><strong>Front</strong></td><td colspan=\"2\">10 MP, f/2.2, 26mm (wide), Dual video call, Auto-HDR, Video (4K@30/60fps, 1080p@30fps) &nbsp;</td></tr><tr><th rowspan=\"6\"><strong>Connectivity</strong></th><td><strong>WLAN</strong></td><td colspan=\"2\">Wi-Fi 802.11 a/b/g/n/ac/6, dual-band, Wi-Fi Direct, hotspot &nbsp;</td></tr><tr><td><strong>Bluetooth</strong></td><td colspan=\"2\">v5.0 with A2DP, LE, apt-X &nbsp;</td></tr><tr><td><strong>GPS</strong></td><td colspan=\"2\">Yes + A-GPS support &amp; Glonass, BDS, GALILEO &nbsp;</td></tr><tr><td><strong>USB</strong></td><td colspan=\"2\">3.2, Type-C 1.0 reversible connector, USB On-The-Go &nbsp;</td></tr><tr><td><strong>NFC</strong></td><td colspan=\"2\">Yes &nbsp;</td></tr><tr><td><strong>Data</strong></td><td colspan=\"2\"><strong>GPRS</strong>, Edge, 3G (HSPA 42.2/5.76 Mbps), 4G LTE-A &nbsp;</td></tr><tr><th rowspan=\"7\"><strong>Features</strong></th><td><strong>Sensors</strong></td><td colspan=\"2\">Accelerometer, Barometer, Compass, Fingerprint (under display, ultrasonic), Gyro &nbsp;</td></tr><tr><td><strong>Audio</strong></td><td colspan=\"2\">32-bit/384kHz audio, MP4/DivX/XviD/WMV/H.265 player, MP3/WAV/WMA/eAAC+/FLAC player, Speaker Phone &nbsp;</td></tr><tr><td><strong>Browser</strong></td><td colspan=\"2\">HTML5 &nbsp;</td></tr><tr><td><strong>Messaging</strong></td><td colspan=\"2\">SMS(threaded view), MMS, Email, Push Mail, IM &nbsp;</td></tr><tr><td><strong>Games</strong></td><td colspan=\"2\">Built-in + Downloadable &nbsp;</td></tr><tr><td><strong>Torch</strong></td><td colspan=\"2\">Yes &nbsp;</td></tr><tr><td><strong>Extra</strong></td><td colspan=\"2\">Tuned by AKG, Active noise cancellation with dedicated mic, Samsung DeX (desktop experience support), ANT+, Bixby natural language commands and dictation, Samsung Pay (Visa, MasterCard certified), IP68 dust/water proof (up to 1.5m for 30 mins), Stylus (Bluetooth integration, accelerometer, gyro) &nbsp;</td></tr><tr><th rowspan=\"2\"><strong>Battery</strong></th><td><strong>Capacity</strong></td><td colspan=\"2\">(Li-Po Non removable), 4300 mAh &nbsp;</td></tr><tr><td>&nbsp;</td><td colspan=\"2\">- Fast charging 25W, USB Power Delivery 3.0, Fast Qi/PMA wireless charging, Reverse wireless charging 9W &nbsp;</td></tr></tbody></table></figure><figure class=\"table\"><table><tbody><tr><th rowspan=\"1\"><h2><strong>Price</strong></h2></th><td colspan=\"2\">Price in Rs: <strong>199,999</strong> &nbsp;&nbsp;&nbsp; Price in USD: <strong>$1341</strong> &nbsp;</td></tr></tbody></table></figure>', 0, 1, 1, 16, 7, '2021-06-20 14:20:26', 15, '15'),
(23, 'Galaxy A72', 4, 'images/A72-1.jpg', 'images/a72-3.jpg', 'images/A72-4.jpg', 'images/a72-5.jpg', 69999, 0, '<figure class=\"table\"><table><tbody><tr><th rowspan=\"6\"><strong>Build</strong></th><td><strong>OS</strong></td><td colspan=\"2\">Android 11 OS &nbsp;</td></tr><tr><td><strong>UI</strong></td><td colspan=\"2\">One UI 3.1 &nbsp;</td></tr><tr><td><strong>Dimensions</strong></td><td colspan=\"2\">165 x 77.4 x 8.4 mm &nbsp;</td></tr><tr><td><strong>Weight</strong></td><td colspan=\"2\">203 g &nbsp;</td></tr><tr><td><strong>SIM</strong></td><td colspan=\"2\">Hybrid Dual SIM, Dual Standby, (Nano-SIM) &nbsp;</td></tr><tr><td><strong>Colors</strong></td><td colspan=\"2\">Awesome Black, Awesome White, Awesome Blue, Awesome Violet &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Frequency</strong></th><td><strong>2G Band</strong></td><td colspan=\"2\"><strong>SIM1:</strong> GSM 850 / 900 / 1800 / 1900<br><strong>SIM2:</strong> GSM 850 / 900 / 1800 / 1900 &nbsp;</td></tr><tr><td><strong>3G Band</strong></td><td colspan=\"2\">HSDPA 850 / 900 / 1900 / 2100 &nbsp;</td></tr><tr><td><strong>4G Band</strong></td><td colspan=\"2\">LTE band 1(2100), 3(1800), 5(850), 7(2600), 8(900), 20(800), 38(2600), 40(2300), 41(2500) &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Processor</strong></th><td><strong>CPU</strong></td><td colspan=\"2\">Octa-core (2 x 2.3 GHz Kryo 465 Gold + 6 x 1.8 GHz Kryo 465 Silver) &nbsp;</td></tr><tr><td><strong>Chipset</strong></td><td colspan=\"2\">Qualcomm SM7125 Snapdragon 720G (8 nm) &nbsp;</td></tr><tr><td><strong>GPU</strong></td><td colspan=\"2\">Adreno 618 &nbsp;</td></tr><tr><th rowspan=\"5\"><strong>Display</strong></th><td><strong>Technology</strong></td><td colspan=\"2\">Super AMOLED Capacitive Touchscreen, Multitouch &nbsp;</td></tr><tr><td><strong>Size</strong></td><td colspan=\"2\">6.7 Inches &nbsp;</td></tr><tr><td><strong>Resolution</strong></td><td colspan=\"2\">1080 x 2400 Pixels (~393 PPI) &nbsp;</td></tr><tr><td><strong>Protection</strong></td><td colspan=\"2\">Corning Gorilla Glass &nbsp;</td></tr><tr><td><strong>Extra Features</strong></td><td colspan=\"2\">90Hz, 800 nits (peak) &nbsp;</td></tr><tr><th rowspan=\"2\"><strong>Memory</strong></th><td><strong>Built-in</strong></td><td colspan=\"2\">128GB Built-in, 8GB RAM &nbsp;</td></tr><tr><td><strong>Card</strong></td><td colspan=\"2\">microSD Card, (supports up to 1TB) &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Camera</strong></th><td><strong>Main</strong></td><td colspan=\"2\">Quad Camera: 64 MP, f/1.8, 26mm (wide), 1/1.7X\", PDAF, OIS + 8 MP, f/2.4, (telephoto), PDAF, OIS, 3x optical zoom + 12 MP, f/2.2, (ultrawide) + 5 MP, f/2.4, (macro), LED Flash &nbsp;</td></tr><tr><td><strong>Features</strong></td><td colspan=\"2\">Funmode, Single Take, Live focus effects, Spin Bokeh, Zoom Bokeh blur, Color point), panorama, HDR, Video (4K@30fps, 1080p@30/120fps; gyro-EIS) &nbsp;</td></tr><tr><td><strong>Front</strong></td><td colspan=\"2\">32 MP, f/2.2, 26mm (wide), 1/2.8\", HDR, Video (4K@30fps, 1080p@30fps) &nbsp;</td></tr><tr><th rowspan=\"7\"><strong>Connectivity</strong></th><td><strong>WLAN</strong></td><td colspan=\"2\">Wi-Fi 802.11 a/b/g/n/ac, dual-band, Wi-Fi Direct, hotspot &nbsp;</td></tr><tr><td><strong>Bluetooth</strong></td><td colspan=\"2\">v5.0 with A2DP, LE &nbsp;</td></tr><tr><td><strong>GPS</strong></td><td colspan=\"2\">Yes + A-GPS support &amp; Glonass, BDS, GALILEO, BDS &nbsp;</td></tr><tr><td><strong>Radio</strong></td><td colspan=\"2\">FM Radio (Unspecified) &nbsp;</td></tr><tr><td><strong>USB</strong></td><td colspan=\"2\">USB Type-C 2.0, USB On-The-Go &nbsp;</td></tr><tr><td><strong>NFC</strong></td><td colspan=\"2\">Yes &nbsp;</td></tr><tr><td><strong>Data</strong></td><td colspan=\"2\"><strong>GPRS</strong>, <strong>EDGE</strong>, 3G (HSPA 42.2/5.76 Mbps), 4G LTE-A &nbsp;</td></tr><tr><th rowspan=\"7\"><strong>Features</strong></th><td><strong>Sensors</strong></td><td colspan=\"2\">Accelerometer, gyro, proximity, compass, Fingerprint (under display, optical) &nbsp;</td></tr><tr><td><strong>Audio</strong></td><td colspan=\"2\">3.5mm Audio Jack, MP3/WAV/WMA/eAAC+/FLAC player, MP4/WMV/H.265 player, Speaker Phone &nbsp;</td></tr><tr><td><strong>Browser</strong></td><td colspan=\"2\">HTML5 &nbsp;</td></tr><tr><td><strong>Messaging</strong></td><td colspan=\"2\">SMS(threaded view), MMS, Email, Push Mail, IM &nbsp;</td></tr><tr><td><strong>Games</strong></td><td colspan=\"2\">Built-in + Downloadable &nbsp;</td></tr><tr><td><strong>Torch</strong></td><td colspan=\"2\">Yes &nbsp;</td></tr><tr><td><strong>Extra</strong></td><td colspan=\"2\">IP67 dust/water resistant (up to 1m for 30 mins), ANT+ support, Active noise cancellation with dedicated mic, Photo/video editor, Document viewer &nbsp;</td></tr><tr><th rowspan=\"2\"><strong>Battery</strong></th><td><strong>Capacity</strong></td><td colspan=\"2\">(Li-Po Non removable), 5000 mAh &nbsp;</td></tr><tr><td>&nbsp;</td><td colspan=\"2\">- Fast battery charging 25W &nbsp;</td></tr></tbody></table></figure><figure class=\"table\"><table><tbody><tr><th rowspan=\"1\"><h2><strong>Price</strong></h2></th><td colspan=\"2\">Price in Rs: <strong>69,999</strong> &nbsp;&nbsp;&nbsp; Price in USD: <strong>$434</strong> &nbsp;</td></tr></tbody></table></figure>', 0, 0, 0, 16, 7, '2021-06-20 15:22:59', 15, 'SAM_A72'),
(24, 'OPPO F15', 5, 'images/oppo f15.jpg', 'images/Oppo-F15-Image-1.jpg', 'images/Oppo-F15-Image-2.jpg', 'images/Oppo-F15-Image-3.jpg', 38900, 0, '<figure class=\"table\"><table><tbody><tr><th rowspan=\"6\"><strong>Build</strong></th><td><strong>OS</strong></td><td colspan=\"2\">Android 9.0 (Pie) &nbsp;</td></tr><tr><td><strong>UI</strong></td><td colspan=\"2\">ColorOS 6.1 &nbsp;</td></tr><tr><td><strong>Dimensions</strong></td><td colspan=\"2\">160.2 x 73.3 x 7.9 mm &nbsp;</td></tr><tr><td><strong>Weight</strong></td><td colspan=\"2\">172 g &nbsp;</td></tr><tr><td><strong>SIM</strong></td><td colspan=\"2\">Dual Sim, Dual Standby (Nano-SIM) &nbsp;</td></tr><tr><td><strong>Colors</strong></td><td colspan=\"2\">Lightening Black, Unicorn White &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Frequency</strong></th><td><strong>2G Band</strong></td><td colspan=\"2\"><strong>SIM1:</strong> GSM 850 / 900 / 1800 / 1900<br><strong>SIM2:</strong> GSM 850 / 900 / 1800 / 1900 &nbsp;</td></tr><tr><td><strong>3G Band</strong></td><td colspan=\"2\">HSDPA 850 / 900 / 1900 / 2100 &nbsp;</td></tr><tr><td><strong>4G Band</strong></td><td colspan=\"2\">LTE band 1(2100), 3(1800), 5(850), 7(2600), 8(900), 34(2000), 38(2600), 39(1900), 40(2300), 41(2500) &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Processor</strong></th><td><strong>CPU</strong></td><td colspan=\"2\">Octa-core (4 x 2.1 GHz Cortex-A73 + 4 x 2.0 GHz Cortex-A53) &nbsp;</td></tr><tr><td><strong>Chipset</strong></td><td colspan=\"2\">Mediatek MT6771V Helio P70 (12nm) &nbsp;</td></tr><tr><td><strong>GPU</strong></td><td colspan=\"2\">Mali-G72 MP3 &nbsp;</td></tr><tr><th rowspan=\"5\"><strong>Display</strong></th><td><strong>Technology</strong></td><td colspan=\"2\">AMOLED Capacitive Touchscreen, 16M Colors, Multitouch &nbsp;</td></tr><tr><td><strong>Size</strong></td><td colspan=\"2\">6.4 Inches &nbsp;</td></tr><tr><td><strong>Resolution</strong></td><td colspan=\"2\">1080 x 2400 Pixels (~411 PPI) &nbsp;</td></tr><tr><td><strong>Protection</strong></td><td colspan=\"2\">Corning Gorilla Glass 5 &nbsp;</td></tr><tr><td><strong>Extra Features</strong></td><td colspan=\"2\">Corning Gorilla Glass 5, 430 nits typ. brightness &nbsp;</td></tr><tr><th rowspan=\"2\"><strong>Memory</strong></th><td><strong>Built-in</strong></td><td colspan=\"2\">128GB Built-in, 8GB RAM, UFS 2.1 &nbsp;</td></tr><tr><td><strong>Card</strong></td><td colspan=\"2\">microSD Card, (supports up to 256GB) (dedicated slot) &nbsp;</td></tr><tr><th rowspan=\"3\"><strong>Camera</strong></th><td><strong>Main</strong></td><td colspan=\"2\">Quad Camera: 48 MP, f/1.8, 26mm (wide), 1/2.0\", PDAF + 8 MP, f/2.2, 13mm (ultrawide), 1/4.0\" + 2 MP, f/2.4, 1/5\", (dedicated macro camera) + 2 MP, f/2.4, 1/5\", depth sensor, LED Flash &nbsp;</td></tr><tr><td><strong>Features</strong></td><td colspan=\"2\">Phase detection, Geo-tagging, touch focus, face detection, HDR, panorama, Video (1080p@30fps) &nbsp;</td></tr><tr><td><strong>Front</strong></td><td colspan=\"2\">16 MP, f/2.0, 26mm (wide), 1/3.1 &nbsp;</td></tr><tr><th rowspan=\"7\"><strong>Connectivity</strong></th><td><strong>WLAN</strong></td><td colspan=\"2\">Wi-Fi 802.11 a/b/g/n/ac, dual-band, Wi-Fi Direct, hotspot &nbsp;</td></tr><tr><td><strong>Bluetooth</strong></td><td colspan=\"2\">v5.0 with A2DP, LE, apt-X HD &nbsp;</td></tr><tr><td><strong>GPS</strong></td><td colspan=\"2\">Yes + A-GPS support &nbsp;</td></tr><tr><td><strong>Radio</strong></td><td colspan=\"2\">FM Radio &nbsp;</td></tr><tr><td><strong>USB</strong></td><td colspan=\"2\">2.0, Type-C 1.0 reversible connector, USB On-The-Go &nbsp;</td></tr><tr><td><strong>NFC</strong></td><td colspan=\"2\">No &nbsp;</td></tr><tr><td><strong>Data</strong></td><td colspan=\"2\"><strong>GPRS</strong>, Edge, 3G (HSPA 42.2/11.5 Mbps), 4G LTE-A &nbsp;</td></tr><tr><th rowspan=\"7\"><strong>Features</strong></th><td><strong>Sensors</strong></td><td colspan=\"2\">Accelerometer, Compass, Fingerprint (under display, optical), Gyro, Proximity &nbsp;</td></tr><tr><td><strong>Audio</strong></td><td colspan=\"2\">3.5mm Audio Jack, MP4/H.264/FLAC player, MP3/eAAC+/WAV player, Speaker Phone &nbsp;</td></tr><tr><td><strong>Browser</strong></td><td colspan=\"2\">HTML5 &nbsp;</td></tr><tr><td><strong>Messaging</strong></td><td colspan=\"2\">SMS(threaded view), MMS, Email, Push Mail, IM &nbsp;</td></tr><tr><td><strong>Games</strong></td><td colspan=\"2\">Built-in + Downloadable &nbsp;</td></tr><tr><td><strong>Torch</strong></td><td colspan=\"2\">Yes &nbsp;</td></tr><tr><td><strong>Extra</strong></td><td colspan=\"2\">Active noise cancellation with dedicated mic, Document editor, Photo/video editor &nbsp;</td></tr><tr><th rowspan=\"2\"><strong>Battery</strong></th><td><strong>Capacity</strong></td><td colspan=\"2\">(Li-Po Non removable), 4025 mAh &nbsp;</td></tr><tr><td>&nbsp;</td><td colspan=\"2\">- Fast battery charging 20W: 50% in 30 min (VOOC Flash Charge 3.0) &nbsp;</td></tr></tbody></table></figure><figure class=\"table\"><table><tbody><tr><th rowspan=\"1\"><h2><strong>Price</strong></h2></th><td colspan=\"2\">Price in Rs: 38900 Price in USD: <strong>$250</strong></td></tr></tbody></table></figure>', 0, 0, 0, 16, 9, '2021-06-20 15:28:08', 10, 'OPPO-F15'),
(25, 'OPPO Reno 5 pro', 5, 'images/OPPO Reno5 pro.png', 'images/OPPO Reno5 pro-1.png', 'images/OPPO Reno5 pro-2.png', 'images/OPPO Reno5 pro-3.png', 199999, 0, '<figure class=\"table\"><table><thead><tr><th colspan=\"2\">General Features</th></tr></thead><tbody><tr><th><strong>Release Date</strong></th><td>2020, December 10</td></tr><tr><th><strong>SIM Support</strong></th><td>Dual SIM (Nano-SIM, dual stand-by)</td></tr><tr><th><strong>Phone Dimensions</strong></th><td>159.7 x 73.2 x 7.6 mm</td></tr><tr><th><strong>Phone Weight</strong></th><td>173 g</td></tr><tr><th><strong>Operating System</strong></th><td>Android 11, ColorOS 11.1</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Display</th></tr></thead><tbody><tr><th><strong>Screen Size</strong></th><td>6.55 inches</td></tr><tr><th><strong>Screen Resolution</strong></th><td>1080 x 2400 pixels</td></tr><tr><th><strong>Screen Type</strong></th><td>Super AMOLED Capacitive Touchscreen, 16M Colors, Multitouch</td></tr><tr><th><strong>Screen Protection</strong></th><td>Corning Gorilla Glass 5</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Memory</th></tr></thead><tbody><tr><th><strong>Internal Memory</strong></th><td>256 GB</td></tr><tr><th><strong>RAM</strong></th><td>12 GB</td></tr><tr><th><strong>Card Slot</strong></th><td>No</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Performance</th></tr></thead><tbody><tr><th><strong>Processor</strong></th><td>Mediatek MT6889Z Dimensity 1000+</td></tr><tr><th><strong>GPU</strong></th><td>Mali-G77 MC9</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Battery</th></tr></thead><tbody><tr><th><strong>Type</strong></th><td>Li-Po 4350 mAh, non-removable</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Camera</th></tr></thead><tbody><tr><th><strong>Front Camera</strong></th><td>32 MP</td></tr><tr><th><strong>Front Flash Light</strong></th><td>No</td></tr><tr><th><strong>Front Video Recording</strong></th><td>1080p@30fps, gyro-EIS</td></tr><tr><th><strong>Back Flash Light</strong></th><td>Yes</td></tr><tr><th><strong>Back Camera</strong></th><td>64 MP + 8 MP + 2 MP + 2 MP</td></tr><tr><th><strong>Back Video Recording</strong></th><td>4K@30fps, 1080p@30/60/120fps; gyro-EIS, HDR</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Connectivity</th></tr></thead><tbody><tr><th><strong>Bluetooth</strong></th><td>Yes</td></tr><tr><th><strong>3G</strong></th><td>Yes</td></tr><tr><th><strong>4G/LTE</strong></th><td>Yes</td></tr><tr><th><strong>Radio</strong></th><td>No</td></tr><tr><th><strong>WiFi</strong></th><td>Yes</td></tr><tr><th><strong>NFC</strong></th><td>Yes (market/region dependent)</td></tr></tbody></table></figure>', 1, 0, 0, 16, 9, '2021-06-20 15:42:56', 10, '100'),
(26, 'IPhone 12 pro MINI', 6, 'images/iphone 12 pro mini-1.jpg', 'images/iphone 12 pro mini-2.jpg', 'images/iphone 12 pro mini-3.jpg', 'images/iphone 12 pro mini-4.jpg', 149999, 0, '<figure class=\"table\"><table><thead><tr><th colspan=\"2\">General Features</th></tr></thead><tbody><tr><th><strong>Release Date</strong></th><td>2020, October 13</td></tr><tr><th><strong>SIM Support</strong></th><td>Single SIM (Nano-SIM and/or eSIM)</td></tr><tr><th><strong>Phone Dimensions</strong></th><td>131.5 x 64.2 x 7.4 mm</td></tr><tr><th><strong>Phone Weight</strong></th><td>135 g</td></tr><tr><th><strong>Operating System</strong></th><td>iOS 14</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Display</th></tr></thead><tbody><tr><th><strong>Screen Size</strong></th><td>5.4 inches</td></tr><tr><th><strong>Screen Resolution</strong></th><td>1080 x 2340 pixels</td></tr><tr><th><strong>Screen Type</strong></th><td>Super Retina XDR OLED, HDR10, 625 nits (typ), 1200 nits (peak)</td></tr><tr><th><strong>Screen Protection</strong></th><td>Scratch-resistant glass, oleophobic coating</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Memory</th></tr></thead><tbody><tr><th><strong>Internal Memory</strong></th><td>64/128/256 GB</td></tr><tr><th><strong>RAM</strong></th><td>4 GB</td></tr><tr><th><strong>Card Slot</strong></th><td>No</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Performance</th></tr></thead><tbody><tr><th><strong>Processor</strong></th><td>Apple A14 Bionic</td></tr><tr><th><strong>GPU</strong></th><td>Apple GPU (4-core graphics)</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Battery</th></tr></thead><tbody><tr><th><strong>Type</strong></th><td>Li-Ion 2227 mAh, non-removable</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Camera</th></tr></thead><tbody><tr><th><strong>Front Camera</strong></th><td>12 MP, f/2.2</td></tr><tr><th><strong>Front Flash Light</strong></th><td>No</td></tr><tr><th><strong>Front Video Recording</strong></th><td>4K@24/30/60fps, 1080p@30/60/120fps, gyro-EIS</td></tr><tr><th><strong>Back Flash Light</strong></th><td>Yes</td></tr><tr><th><strong>Back Camera</strong></th><td>12 MP + 12 MP</td></tr><tr><th><strong>Back Video Recording</strong></th><td>4K@24/30/60fps, 1080p@30/60/120/240fps, HDR, Dolby Vision HDR (up to 30fps), stereo sound rec.</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Connectivity</th></tr></thead><tbody><tr><th><strong>Bluetooth</strong></th><td>Yes</td></tr><tr><th><strong>3G</strong></th><td>Yes</td></tr><tr><th><strong>4G/LTE</strong></th><td>Yes</td></tr><tr><th><strong>Radio</strong></th><td>No</td></tr><tr><th><strong>WiFi</strong></th><td>Yes</td></tr><tr><th><strong>NFC</strong></th><td>Yes</td></tr></tbody></table></figure>', 1, 0, 1, 16, 8, '2021-06-20 15:37:20', 12, 'I-12'),
(27, 'IPhone 12 pro MAX', 6, 'images/iphone 12 pro max-1.jpg', 'images/iphone 12 pro max-2.jpg', 'images/iphone 12 pro max-3.jpg', 'images/iphone 12 pro max-4.jpg', 199999, 0, '<figure class=\"table\"><table><thead><tr><th colspan=\"2\">General Features</th></tr></thead><tbody><tr><th><strong>Release Date</strong></th><td>2020, October 13</td></tr><tr><th><strong>SIM Support</strong></th><td>Single SIM (Nano-SIM and/or eSIM)</td></tr><tr><th><strong>Phone Dimensions</strong></th><td>160.8 x 78.1 x 7.4 mm</td></tr><tr><th><strong>Phone Weight</strong></th><td>228 g</td></tr><tr><th><strong>Operating System</strong></th><td>iOS 14</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Display</th></tr></thead><tbody><tr><th><strong>Screen Size</strong></th><td>6.7 inches</td></tr><tr><th><strong>Screen Resolution</strong></th><td>1284 x 2778 pixels</td></tr><tr><th><strong>Screen Type</strong></th><td>Super Retina XDR OLED, HDR10, 800 nits (typ), 1200 nits (peak)</td></tr><tr><th><strong>Screen Protection</strong></th><td>Scratch-resistant glass, oleophobic coating</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Memory</th></tr></thead><tbody><tr><th><strong>Internal Memory</strong></th><td>128/256/512 GB</td></tr><tr><th><strong>RAM</strong></th><td>6 GB</td></tr><tr><th><strong>Card Slot</strong></th><td>No</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Performance</th></tr></thead><tbody><tr><th><strong>Processor</strong></th><td>Apple A14 Bionic</td></tr><tr><th><strong>GPU</strong></th><td>Apple GPU (4-core graphics)</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Battery</th></tr></thead><tbody><tr><th><strong>Type</strong></th><td>(Li-Po Non removable), 3687 mAh</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Camera</th></tr></thead><tbody><tr><th><strong>Front Camera</strong></th><td>12 MP, f/2.2</td></tr><tr><th><strong>Front Flash Light</strong></th><td>No</td></tr><tr><th><strong>Front Video Recording</strong></th><td>4K@24/30/60fps, 1080p@30/60/120fps, gyro-EIS</td></tr><tr><th><strong>Back Flash Light</strong></th><td>Yes</td></tr><tr><th><strong>Back Camera</strong></th><td>12 MP + 12 MP + 12 MP</td></tr><tr><th><strong>Back Video Recording</strong></th><td>4K@24/30/60fps, 1080p@30/60/120/240fps, 10‑bit HDR, Dolby Vision HDR (up to 60fps), stereo sound rec.</td></tr></tbody></table></figure><figure class=\"table\"><table><thead><tr><th colspan=\"2\">Connectivity</th></tr></thead><tbody><tr><th><strong>Bluetooth</strong></th><td>Yes</td></tr><tr><th><strong>3G</strong></th><td>Yes</td></tr><tr><th><strong>4G/LTE</strong></th><td>Yes</td></tr><tr><th><strong>5G</strong></th><td>Yes</td></tr><tr><th><strong>Radio</strong></th><td>No</td></tr><tr><th><strong>WiFi</strong></th><td>Yes</td></tr><tr><th><strong>NFC</strong></th><td>Yes</td></tr></tbody></table></figure>', 0, 1, 0, 16, 8, '2021-06-20 15:40:08', 12, 'I-12pro'),
(28, 'Dawlance Cruise Pro Inverter 30 1.5 Ton Split AC', 9, 'images/LVS Pro 30.jpg', 'images/LVS Pro 30-1.jpg', 'images/LVS Pro 30-2.jpg', 'images/LVS Pro 30-3.jpg', 69500, 0, '<figure class=\"table\"><table><tbody><tr><th><strong>SPECIFICATION</strong></th><th>12K AERO Plus</th></tr><tr><th><strong>Rated Capacity - Cooling</strong></th><th>3500(1400-4000) W</th></tr><tr><th><strong>Rated Running Current - Cooling</strong></th><th>4.9(2.0-6.0) A</th></tr><tr><th><strong>Maximum Current</strong></th><th>7 A</th></tr><tr><th><strong>Rated Power Cooling</strong></th><th>1130(400-1450) W</th></tr><tr><th><strong>Maximum Power</strong></th><th>1450 W</th></tr><tr><th><strong>Seasonal / Energy Efficiency Ratio (SEER/EER)</strong></th><th>3.40 W/W</th></tr><tr><th><strong>Power supply source</strong></th><th>220~240V/50Hz V/Ph/Hz</th></tr><tr><th><strong>Refrigerant</strong></th><th>R410a/960 Gas</th></tr><tr><th><strong>Air Flow Volume</strong></th><th>650 m3/h</th></tr><tr><th><strong>Outdoor Noise level</strong></th><th>42/51 dB(A)</th></tr><tr><th><strong>Indoor unit weight （Net )</strong></th><th>10 Kg</th></tr><tr><th><strong>Outdoor unit weight (Net )</strong></th><th>28 Kg</th></tr><tr><th><strong>Net Dimension - Indoor (WidthxDepthxHeight)</strong></th><th>850×296×205 mm</th></tr><tr><th><strong>Net Dimension - Outdoor (WidthxDepthxHeight)</strong></th><th>730×285×545 mm</th></tr></tbody></table></figure><figure class=\"table\"><table><tbody><tr><th>Compressor Warranty</th><th>10 Years</th></tr><tr><th>PCB Kit Warranty</th><th>02 Years</th></tr><tr><th>Parts Warranty</th><th>1 Year</th></tr></tbody></table></figure><p>&nbsp;</p><h2><strong>Split AC installation Cost:</strong></h2><figure class=\"table\"><table><tbody><tr><th><strong>Description (Wall Mounted Split AC 1-2 Ton)</strong></th><th><strong>Tariff (PKR)</strong></th></tr><tr><th><strong>PEL Technician Installation</strong></th><th><strong>3000</strong></th></tr><tr><th><strong>Dismantling Charges in case of previous AC</strong></th><th><strong>1300</strong></th></tr><tr><th><strong>Extra Copper Pipe (RFT)</strong></th><th><strong>350</strong></th></tr><tr><th><strong>PVC Drain Pipe (RFT)</strong></th><th><strong>60</strong></th></tr><tr><th><strong>Simple Grooving without Pipe Concealing (RFT)</strong></th><th><strong>50</strong></th></tr><tr><th><strong>Iron Frame Charges (Powder Coated)</strong></th><th><strong>950</strong></th></tr><tr><th><strong>Filling of Holes with white Plaster of Paris (RFT)</strong></th><th><strong>200</strong></th></tr><tr><th><strong>PVC Duct for Refrigeration pipe (RFT)</strong></th><th><strong>240</strong></th></tr></tbody></table></figure>', 0, 0, 0, 20, 13, '2021-06-20 17:06:42', 10, 'D-6C'),
(29, 'PEL 2.0 Ton FIT Series Inverter AC', 13, 'images/pel-1.jpg', 'images/pel-2.jpg', 'images/pel-3.jpg', 'images/pel-4.jpg', 69500, 0, '<figure class=\"table\"><table><tbody><tr><th><strong>SPECIFICATION</strong></th><th>12K AERO Plus</th></tr><tr><th><strong>Rated Capacity - Cooling</strong></th><th>3500(1400-4000) W</th></tr><tr><th><strong>Rated Running Current - Cooling</strong></th><th>4.9(2.0-6.0) A</th></tr><tr><th><strong>Maximum Current</strong></th><th>7 A</th></tr><tr><th><strong>Rated Power Cooling</strong></th><th>1130(400-1450) W</th></tr><tr><th><strong>Maximum Power</strong></th><th>1450 W</th></tr><tr><th><strong>Seasonal / Energy Efficiency Ratio (SEER/EER)</strong></th><th>3.40 W/W</th></tr><tr><th><strong>Power supply source</strong></th><th>220~240V/50Hz V/Ph/Hz</th></tr><tr><th><strong>Refrigerant</strong></th><th>R410a/960 Gas</th></tr><tr><th><strong>Air Flow Volume</strong></th><th>650 m3/h</th></tr><tr><th><strong>Outdoor Noise level</strong></th><th>42/51 dB(A)</th></tr><tr><th><strong>Indoor unit weight （Net )</strong></th><th>10 Kg</th></tr><tr><th><strong>Outdoor unit weight (Net )</strong></th><th>28 Kg</th></tr><tr><th><strong>Net Dimension - Indoor (WidthxDepthxHeight)</strong></th><th>850×296×205 mm</th></tr><tr><th><strong>Net Dimension - Outdoor (WidthxDepthxHeight)</strong></th><th>730×285×545 mm</th></tr></tbody></table></figure><figure class=\"table\"><table><tbody><tr><th>Compressor Warranty</th><th>10 Years</th></tr><tr><th>PCB Kit Warranty</th><th>02 Years</th></tr><tr><th>Parts Warranty</th><th>1 Year</th></tr></tbody></table></figure><p>&nbsp;</p><h2><strong>Split AC installation Cost:</strong></h2><figure class=\"table\"><table><tbody><tr><th><strong>Description (Wall Mounted Split AC 1-2 Ton)</strong></th><th><strong>Tariff (PKR)</strong></th></tr><tr><th><strong>PEL Technician Installation</strong></th><th><strong>3000</strong></th></tr><tr><th><strong>Dismantling Charges in case of previous AC</strong></th><th><strong>1300</strong></th></tr><tr><th><strong>Extra Copper Pipe (RFT)</strong></th><th><strong>350</strong></th></tr><tr><th><strong>PVC Drain Pipe (RFT)</strong></th><th><strong>60</strong></th></tr><tr><th><strong>Simple Grooving without Pipe Concealing (RFT)</strong></th><th><strong>50</strong></th></tr><tr><th><strong>Iron Frame Charges (Powder Coated)</strong></th><th><strong>950</strong></th></tr><tr><th><strong>Filling of Holes with white Plaster of Paris (RFT)</strong></th><th><strong>200</strong></th></tr><tr><th><strong>PVC Duct for Refrigeration pipe (RFT)</strong></th><th><strong>240</strong></th></tr></tbody></table></figure>', 0, 0, 0, 20, 13, '2021-06-20 17:11:31', 10, 'PEL_2000'),
(30, 'Dawlance Double Door', 9, 'images/dawlance-double-door.jpg', 'images/dfd-1.jpg', 'images/dfd-2.png', 'images/dfd-3.jpg', 149999, 0, '<h3>Features</h3><ul><li>World’s largest direct cool refrigerator</li><li>4 door premium design Pillar less design</li><li>Separate door opening- for convenience and saving cool air</li><li>Tempered glass shelves- can hold weight up to 100kgs</li><li>Capacity:&nbsp;702- 24.8</li><li>Dimensions:&nbsp;900 x 1860 x 750 mm</li></ul><p><strong>Warranty:</strong></p><p>• 1 Year Parts</p><p>• 12 Years Compressor.</p>', 1, 0, 0, 20, 11, '2021-06-20 17:19:20', 15, 'DFD'),
(31, 'PEL PRINVOGD-2350 Inverteron Curved Glass Door Refrigerator', 11, 'images/h-1.jpg', 'images/h-2.jpg', 'images/h-3.jpg', 'images/h-4.jpg', 149999, 0, '<h3>Features</h3><ul><li>World’s largest direct cool refrigerator</li><li>4 door premium design Pillar less design</li><li>Separate door opening- for convenience and saving cool air</li><li>Tempered glass shelves- can hold weight up to 100kgs</li><li>Capacity:&nbsp;702- 24.8</li><li>Dimensions:&nbsp;900 x 1860 x 750 mm</li></ul><p><strong>Warranty:</strong></p><p>• 1 Year Parts</p><p>• 12 Years Compressor.</p>', 0, 0, 0, 20, 11, '2021-06-20 17:29:27', 10, 'H-PI'),
(32, 'Haier Dryer', 11, 'images/hd-1.jpg', 'images/hd-2.jpg', 'images/hd-3.jpg', 'images/hd-4.jpg', 42999, 0, '<h2>Basic</h2><p>Color:</p><p>Grey</p><p>Type:</p><p>Series Front Loading</p><h2>Capacity (Kg)</h2><p>Wash Capacity:</p><p>8</p><p>Spin Capacity:</p><p>8</p><h2>Spin Speed</h2><p>RPM:</p><p>1400</p><h2>Programs</h2><p>Cotton:</p><p>N</p><p>Mix:</p><p>Y</p><p>Sport:</p><p>N</p><p>Hygienic:</p><p>Y</p><p>Shirts:</p><p>Y</p><p>Quick 15:</p><p>Y</p><p>Delicate:</p><p>Y</p><p>Bedding:</p><p>Y</p><p>Duvet:</p><p>Y</p><p>Disinfectant:</p><p>Y</p><p>Kid Wear:</p><p>Y</p><p>Silk:</p><p>N</p><p>Sterilization:</p><p>Y</p><p>Wool:</p><p>Y</p><p>Bulky:</p><p>N</p><h2>Features</h2><p>Display:</p><p>LED</p><p>Touch:</p><p>Y</p><p>Delay:</p><p>Y</p><p>Spinning Speed (All Settings):</p><p>Y</p><p>Adjustable Thermostat (º C):</p><p>Y</p><p>Adjustable wash time:</p><p>Y</p><p>Extra Rinse:</p><p>Y</p><p>Child lock:</p><p>Y</p><p>Memo Function:</p><p>Y</p><p>Smart Dosing:</p><p>N</p><p>Self Clean:</p><p>Y</p><p>Auto weight:</p><p>Y</p><p>ABT:</p><p>Y</p><p>ABT Window pad:</p><p>Y</p><p>Auto Lock Door:</p><p>Y</p><p>Automatic Regulation of Water Consuption:</p><p>Y</p><p>Window screen:</p><p>Y</p><p>Adjustable feet:</p><p>N</p><p>Stainless Steel Drum:</p><p>Y</p><p>Drum Light:</p><p>Y</p><p>Smart Dual Spray:</p><p>Y</p><p>UV Light:</p><p>Y</p><p>Motor:</p><p>DD motor</p><h2>Dimention(mm)</h2><p>Dimention(mm)h*w*d:</p><p>850x595x530</p><h2>Warranty</h2><p>Parts:</p><p>1 year</p><p>Motor Warranty:</p><p>10 Years</p>', 0, 0, 0, 20, 14, '2021-06-20 17:36:32', 10, 'H-MI'),
(33, 'HP v150w 16GB', 7, 'images/usb1.png', 'images/usb2.png', 'images/usb3.png', 'images/usb4.png', 1499, 0, '<h3><strong>Specifications</strong></h3><ul><li>Storage Capacity : 16GB/ 32GB/ 64GB/ 128GB</li><li>Interface: USB 2.0</li><li>USB Connector: USB Type-A</li><li>Read Performance : Minimum of 14 MB/s</li><li>Write Performance : Minimum of 4 MB/s</li><li>Dimensions (L × W × H) : 55.0 mm x 17.2 mm x 9.5 mm</li><li>Weight : 8.8g</li><li>Operating Temperature : 0°C to 60°C</li><li>Storage Temperature : -25°C to 85°C&nbsp;</li><li>System Compatibility</li><li>Windows 7, 8, 10<br>Mac OS : 10.x and above</li><li>Operating Voltage : 4.5~5.5 VDC</li><li>Warranty : 2-year Limited Warranty</li></ul>', 0, 0, 1, 19, 12, '2021-06-20 17:39:58', 12, 'HP-16'),
(34, 'Canon 1500D DSLR Camera', 12, 'images/c1.png', 'images/c2.jpg', 'images/c3.jpg', 'images/c4.png', 65999, 0, '<h3><strong>Type</strong></h3><p><br>Digital, AF/AE single-lens reflex camera with built-in flash</p><h3><strong>Recording Media</strong></h3><p><br>SD, SDHC and SDXC Memory Cards<br><br>SD speed class compatibility.<br>UHS speed class compatibility.<br>High-speed writing is supported when a UHS-I compatible SD card is used.<br>Compatible with Eye-Fi Cards.<br>Multimedia cards (MMC) cannot be used (card error will be displayed).</p><h3><strong>Image Format</strong></h3><p><br>Approx. 22.5mm x 15.0mm (APS-C)</p><h3><strong>Compatible Lenses</strong></h3><p><br>Canon EF Lenses (including EF-S lenses, excluding EF-M lenses)</p><h3><strong>Lens Mount</strong></h3><p><br>Canon EF Mount</p><p>&nbsp;</p><h4>Image Sensor</h4><h3><strong>Type</strong></h3><p><br>CMOS Sensor</p><h3><strong>Pixels</strong></h3><p><br>Approx. 24.2 megapixels</p><h3><strong>Pixel Unit</strong></h3><p><br>Approx. 3.72 µm square</p><h3><strong>Total Pixels</strong></h3><p><br>Approx. 25.8 megapixels</p><h3><strong>Aspect Ratio</strong></h3><p><br>3:2 (Horizontal: Vertical)</p><h3><strong>Color Filter System</strong></h3><p><br>RGB primary color filters</p><h3><strong>Low Pass Filter</strong></h3><p><br>Fixed position in front of the image sensor</p><h3><strong>Dust Deletion Feature</strong></h3><ol><li>Self Cleaning Sensor Unit<ul><li>Removes dust adhering to the low-pass filter.</li><li>Self-cleaning can be done automatically when the power is turned on or off. Manual cleaning also possible.</li></ul></li><li>Dust Delete Data acquisition and appending<ul><li>The coordinates of the dust adhering to the low-pass filter are detected by a test shot and appended to subsequent images.</li><li>The dust coordinate data appended to the image is used by the EOS software to automatically erase the dust spots.</li></ul></li><li>Manual cleaning</li></ol>', 0, 0, 0, 18, 10, '2021-06-20 17:45:09', 15, 'CAN_1500'),
(35, 'HP ELITE DragonFly', 7, 'images/ef_hero1.jpg', 'images/ef_hero2.jpg', 'images/ef_hero3.jpg', 'images/ef_hero4.jpg', 215999, 0, '<p><strong>OPERATING SYSTEM</strong></p><p>Windows 10 Pro - HP recommends Windows 10 Pro<br>Windows 10 Home</p><p><strong>BASE FEATURES</strong></p><p>HP Elite Folio 13.5\" 2-in-1, Qualcomm® Snapdragon™ 8cx Gen 2 processor, 8GB RAM, Integrated Adreno™ 690 Graphics - 18V33AV<br>HP Elite Folio 13.5\" 2-in-1, Qualcomm® Snapdragon™ 8cx Gen 2 processor, 16GB RAM, Integrated Adreno™ 690 Graphics - 1W9S8AV</p><p><strong>PROCESSOR</strong></p><p>Qualcomm® Snapdragon™ 8cx Gen2 5G with integrated Adreno™ 690 Graphics (up to 3.0 GHz frequency, 4 MB L3 cache, 8 cores)</p><p><strong>DISPLAY</strong></p><p>13.5\" IPS WUXGA+ (1920x1280) BrightView Touchscreen with Corning® Gorilla® Glass 5, IR webcam, ALS, 400 nits<br>13.5\" IPS WUXGA+ (1920x1280) BrightView Touchscreen, Corning® Gorilla® Glass 5, IR webcam, ALS, 1000 nits, Sure View Reflect</p><p><strong>WEBCAM</strong></p><p>User facing HD hybrid IR camera</p><p><strong>GRAPHICS</strong></p><p>Integrated Qualcomm® Adreno™ 690 Graphics</p><p>MEMORY</p><p>8 or 16 GB LPDDR4X-4266 SDRAM (soldered down)</p><p>INTERNAL STORAGE</p><p>128 GB PCIe NVMe TLC SSD<br>256 GB PCIe NVMe TLC SSD<br>512 GB PCIe NVMe TLC SSD</p><p>KEYBOARD</p><p>HP Quiet Keyboard, spill-resistant, with HP Dura Keys and Clickpad, Backlit<br>HP Quiet Keyboard, spill-resistant, with HP Dura Keys and Clickpad, Backlit, Privacy</p><p>WIRELESS TECHNOLOGY</p><p>Qualcomm® Wi-Fi 6 802.11a/b/g/n/ax (2x2) and Bluetooth® 5 combo</p><p>HP MOBILE BROADBAND</p><p>No WWAN Broadband Wireless<br>Qualcomm® Snapdragon™ X20 LTE (Cat16)<br>Qualcomm® Snapdragon™ X55 5G LTE (Cat 20)</p><p>BROADBAND SERVICE PROVIDER</p><p>Gemalto Programmable eSIM pre-installed</p><p>AC ADAPTER</p><p>65-watt AC Adapter, Straight USB-C connector, nPFC, slim</p><p>POWER CORD</p><p>1.0m Premium Power Cord with C5 connector</p><p>BATTERY</p><p>4-cell, 46 WHr Long Life Battery (Internal and not replaceable by customer. Serviceable by warranty.)</p><p>WARRANTY</p><p>One-year limited warranty (1/1/0)<br>Three-year limited warranty (3/3/0)</p><p>AUDIO</p><p>Bang &amp; Olufsen, quad stereo speakers, dual array microphones</p><p>ACCESSORIES</p><p>HP Executive 15.6 Backpack<br>HP Executive Slim 14.1\" Top Load Case<br>HP Wireless Bluetooth Earbuds</p><p><strong>EXTERNAL I/O PORTS</strong></p><p>2 SuperSpeed USB Type-C® 5Gbps signaling rate (USB Power Delivery, DisplayPort™ 1.4); 1 headphone/microphone combo</p><p><strong>EXPANSION SLOTS</strong></p><p>1 nano SIM</p><p><strong>SOFTWARE INCLUDED</strong></p><p>Bing Search for IE11; HP PC Hardware Diagnostics UEFI</p><p><strong>DIMENSIONS (W X D X H)</strong></p><p>11.75 x 9.03 x 0.63 in</p><p><strong>WEIGHT</strong></p><p>Starting at 2.92 lb</p>', 1, 0, 1, 17, 15, '2021-06-20 17:50:45', 10, 'H-MI');

-- --------------------------------------------------------

--
-- Table structure for table `slider`
--

CREATE TABLE `slider` (
  `id` int(11) NOT NULL,
  `image` text NOT NULL,
  `status` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `slider`
--

INSERT INTO `slider` (`id`, `image`, `status`, `created_at`) VALUES
(7, 'images/banner 3.jpg', 0, '2021-06-01 10:23:24'),
(9, 'images/banner 4.jpg', 0, '2021-06-01 10:25:06'),
(10, 'images/banner 2.jpg', 0, '2021-06-01 10:29:23'),
(11, 'images/banner 1.jpg', 0, '2021-06-01 10:31:28');

-- --------------------------------------------------------

--
-- Table structure for table `social`
--

CREATE TABLE `social` (
  `facebook` text NOT NULL,
  `twitter` text NOT NULL,
  `linkdin` text NOT NULL,
  `google` text NOT NULL,
  `pinterest` text NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `social`
--

INSERT INTO `social` (`facebook`, `twitter`, `linkdin`, `google`, `pinterest`, `id`) VALUES
('https://www.facebook.com/', 'https://twitter.com/', 'https://pk.linkedin.com/', 'https://accounts.google.com/signin/v2/identifier?flowName=GlifWebSignIn&flowEntry=ServiceLogin', 'https://www.pinterest.com/', 1);

-- --------------------------------------------------------

--
-- Table structure for table `splash_banner`
--

CREATE TABLE `splash_banner` (
  `id` int(11) NOT NULL,
  `image` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `splash_banner`
--

INSERT INTO `splash_banner` (`id`, `image`) VALUES
(3, 'images/promotion.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `sub_categories`
--

CREATE TABLE `sub_categories` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `image` text NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `category_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sub_categories`
--

INSERT INTO `sub_categories` (`id`, `name`, `image`, `status`, `category_id`, `created_at`) VALUES
(6, 'Shirt', 'images/men.jpg', 1, 15, '2021-05-29 09:14:23'),
(7, 'Samsung', 'images/logo-samM.jpg', 1, 16, '2021-06-01 06:27:52'),
(8, 'IPhone', 'images/logo-iphone.jpg', 1, 16, '2021-06-01 06:28:12'),
(9, 'OPPO', 'images/logo_oppo.jpg', 1, 16, '2021-06-01 06:28:28'),
(10, 'DSLR', 'images/logo_camera.jpg', 1, 18, '2021-06-03 07:26:15'),
(11, 'Refrigerator', 'images/logo_refrig.jpg', 1, 20, '2021-06-03 07:40:53'),
(12, 'USB', 'images/2.jpg', 1, 19, '2021-06-03 07:53:05'),
(13, 'Air Conditioner', 'images/logo_AC.jpg', 1, 20, '2021-06-03 09:54:27'),
(14, 'Dryer', 'images/logo_dryer.jpg', 1, 20, '2021-06-03 10:06:47'),
(15, 'HP', 'images/logo_laptop.jpg', 1, 17, '2021-06-03 10:35:19');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `email` text NOT NULL,
  `password` text NOT NULL,
  `phone_number` text NOT NULL,
  `address` text DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `wish_list`
--

CREATE TABLE `wish_list` (
  `id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `wish_list`
--

INSERT INTO `wish_list` (`id`, `product_id`, `created_at`) VALUES
(17, 7, '2021-05-18 09:07:47'),
(19, 5, '2021-05-22 20:13:40'),
(24, 22, '2021-06-20 12:49:38');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `favorite`
--
ALTER TABLE `favorite`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `order_products`
--
ALTER TABLE `order_products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `slider`
--
ALTER TABLE `slider`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `social`
--
ALTER TABLE `social`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `splash_banner`
--
ALTER TABLE `splash_banner`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sub_categories`
--
ALTER TABLE `sub_categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `wish_list`
--
ALTER TABLE `wish_list`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `brand`
--
ALTER TABLE `brand`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `favorite`
--
ALTER TABLE `favorite`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `order_products`
--
ALTER TABLE `order_products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `slider`
--
ALTER TABLE `slider`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `social`
--
ALTER TABLE `social`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `splash_banner`
--
ALTER TABLE `splash_banner`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `sub_categories`
--
ALTER TABLE `sub_categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `wish_list`
--
ALTER TABLE `wish_list`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
