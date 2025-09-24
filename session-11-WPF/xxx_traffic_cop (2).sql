

--
-- Database: `xxx_traffic_cop`
--

CREATE DATABASE xxx_traffic_cop;
USE xxx_traffic_cop;
SHOW DATABASES;
CREATE USER 'xxx_traffic_cop_user'@'localhost' IDENTIFIED BY 'Password1';
GRANT USAGE ON *.* TO 'xxx_traffic_cop_user'@'localhost';
GRANT EXECUTE, SELECT, SHOW VIEW, ALTER, ALTER ROUTINE, CREATE, CREATE ROUTINE, CREATE TEMPORARY TABLES, CREATE VIEW, DELETE, DROP, EVENT, INDEX, INSERT, REFERENCES, TRIGGER, UPDATE, LOCK TABLES  ON `test\_dummy`.* TO 'xxx_traffic_cop_user'@'localhost' WITH GRANT OPTION;
GRANT ALL ON `test\_dummy`.* TO 'xxx_traffic_cop_user'@'localhost' WITH GRANT OPTION;

--
-- Table structure for table `demerits`
--

CREATE TABLE `demerits` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `above_limit_start` int(11) NOT NULL DEFAULT '0',
  `above_limit_end` int(11) NOT NULL DEFAULT '0',
  `penalty_points` int(10) UNSIGNED NOT NULL DEFAULT '0',
  `demerit_points` int(10) UNSIGNED NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `demerits`
--

INSERT INTO `demerits` (`id`, `above_limit_start`, `above_limit_end`, `penalty_points`, `demerit_points`) VALUES
(1, 0, 0, 0, 0),
(2, 1, 9, 2, 0),
(3, 10, 19, 4, 2),
(4, 20, 29, 8, 3),
(5, 30, 40, 16, 6),
(6, 41, 9999, 24, 7);

-- --------------------------------------------------------

--
-- Table structure for table `traffic`
--

CREATE TABLE `traffic` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `number_plate` varchar(9) NOT NULL,
  `speed` int(11) NOT NULL DEFAULT '0',
  `speed_limit` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `traffic`
--

INSERT INTO `traffic` (`id`, `number_plate`, `speed`, `speed_limit`) VALUES
(3, '1INX 571', 90, 60),
(4, '1CSH 439', 90, 60),
(6, '1MTU 977', 90, 60),
(8, '2SPY 703', 90, 60),
(10, '1YNB 347', 90, 60),
(11, '1GXM 801', 90, 60),
(13, '2SYX 392', 90, 60),
(14, '2PZV 818', 90, 60),
(15, '1VFW 546', 90, 60),
(16, '2VBZ 348', 90, 60),
(17, '2RRF 069', 90, 60),
(18, '2RPK 408', 90, 60),
(19, '1ZRQ 913', 90, 60),
(20, '2WBB 504', 90, 60),
(21, '2KHF 555', 90, 60),
(22, '1VPQ 348', 90, 60),
(23, '2AFF 742', 90, 60),
(24, '1CKP 345', 90, 60),
(25, '1TPY 846', 90, 60),
(26, '1RPW 445', 90, 60),
(27, '2IAO 457', 90, 60),
(28, '2JMN 251', 90, 60),
(29, '2TUT 530', 90, 60),
(30, '2NWB 352', 90, 60),
(31, '2LCG 105', 90, 60),
(32, '1RUT 772', 90, 60),
(33, '1BAS 375', 90, 60),
(34, '2PLB 335', 90, 60),
(35, '1EFM 552', 90, 60),
(36, '1SQV 761', 90, 60),
(37, '1LSH 685', 90, 60),
(38, '2GUF 516', 80, 80),
(39, '1YAN 631', 90, 60),
(40, '2QCT 748', 90, 60),
(130, 'ABC 345', 70, 60),
(131, 'XYZ 345', 80, 60),
(135, 'AAA 111', 100, 90),
(140, 'WER 123', 70, 50),
(145, 'LUKE 100', 79, 80),
(150, 'NNN 123', 80, 60),
(156, 'NAM1234', 90, 90),
(160, 'JOHGHUN', 100, 100),
(170, 'Sah1234', 80, 80),
(171, 'Lily 123', 65, 70);

--
--