-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 20, 2022 at 10:58 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `reserveringsysteem`
--

-- --------------------------------------------------------

--
-- Table structure for table `accommodations`
--

CREATE TABLE `accommodations` (
  `AccommodationId` int(6) NOT NULL,
  `Price` double(5,2) NOT NULL,
  `AccommodationType` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `accommodations`
--

INSERT INTO `accommodations` (`AccommodationId`, `Price`, `AccommodationType`) VALUES
(1, 25.00, 'Camper'),
(2, 25.00, 'Camper'),
(3, 25.00, 'Camper'),
(4, 25.00, 'Camper'),
(5, 25.00, 'Camper'),
(6, 25.00, 'Camper'),
(7, 25.00, 'Camper');

-- --------------------------------------------------------

--
-- Table structure for table `guests`
--

CREATE TABLE `guests` (
  `GuestId` int(11) NOT NULL,
  `AmountOfDays` int(11) NOT NULL,
  `TypeOfGuest` enum('Adult','Child','Pet','') NOT NULL,
  `Price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `guests`
--

INSERT INTO `guests` (`GuestId`, `AmountOfDays`, `TypeOfGuest`, `Price`) VALUES
(1, 3, 'Adult', 45),
(2, 5, 'Adult', 75);

-- --------------------------------------------------------

--
-- Table structure for table `occupancies`
--

CREATE TABLE `occupancies` (
  `OccupancyId` int(6) NOT NULL,
  `AccommodationId` int(6) NOT NULL,
  `ReservationId` int(6) NOT NULL,
  `ArrivalDate` date NOT NULL,
  `DepartureDate` date NOT NULL,
  `PaymentStatus` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `prices`
--

CREATE TABLE `prices` (
  `PriceId` int(6) NOT NULL,
  `Amount` double(5,2) NOT NULL,
  `Name` varchar(25) NOT NULL,
  `IsTax` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `prices`
--

INSERT INTO `prices` (`PriceId`, `Amount`, `Name`, `IsTax`) VALUES
(1, 0.00, 'string', 1);

-- --------------------------------------------------------

--
-- Table structure for table `reservations`
--

CREATE TABLE `reservations` (
  `ReservationId` int(11) NOT NULL,
  `FirstName` varchar(25) NOT NULL,
  `LastName` varchar(35) NOT NULL,
  `PrefixName` varchar(100) DEFAULT NULL,
  `streetname` varchar(155) NOT NULL,
  `LicensePlateName` varchar(10) NOT NULL,
  `ArrivalDate` date NOT NULL,
  `DepartureDate` date NOT NULL,
  `AccommodationId` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `AmountOfExtraAdults` int(2) NOT NULL,
  `AmountOfExtraChildren` int(2) NOT NULL,
  `AmountOfExtraPets` int(2) NOT NULL,
  `TotalCost` double(5,2) NOT NULL,
  `PaymentStatus` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reservations`
--

INSERT INTO `reservations` (`ReservationId`, `FirstName`, `LastName`, `PrefixName`, `streetname`, `LicensePlateName`, `ArrivalDate`, `DepartureDate`, `AccommodationId`, `AmountOfExtraAdults`, `AmountOfExtraChildren`, `AmountOfExtraPets`, `TotalCost`, `PaymentStatus`) VALUES
(1, 'Harry', 'Kosse', '', 'laan v/d bork', 'blabla', '2022-06-18', '2022-06-20', '2', 0, 0, 0, 75.00, 0),
(2, 'harry', 'Leuw', '', 'laan v/d bork', 'blabla', '2022-06-19', '2022-06-25', '4', 0, 0, 0, 75.00, 0),
(3, 'harry', 'Leuw', '', 'laan v/d bork', 'blabla', '2022-06-21', '2022-06-22', '5', 0, 0, 0, 75.00, 0),
(4, 'harry', 'Buzz', '', 'laan v/d bork', 'blabla', '2022-06-19', '2022-06-28', '6', 0, 0, 0, 75.00, 0),
(5, 'harry', 'Woody', '', 'laan v/d bork', 'blabla', '2022-06-25', '2022-06-28', '7', 0, 0, 0, 75.00, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accommodations`
--
ALTER TABLE `accommodations`
  ADD PRIMARY KEY (`AccommodationId`);

--
-- Indexes for table `guests`
--
ALTER TABLE `guests`
  ADD PRIMARY KEY (`GuestId`);

--
-- Indexes for table `occupancies`
--
ALTER TABLE `occupancies`
  ADD PRIMARY KEY (`OccupancyId`);

--
-- Indexes for table `prices`
--
ALTER TABLE `prices`
  ADD PRIMARY KEY (`PriceId`);

--
-- Indexes for table `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`ReservationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accommodations`
--
ALTER TABLE `accommodations`
  MODIFY `AccommodationId` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `guests`
--
ALTER TABLE `guests`
  MODIFY `GuestId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `occupancies`
--
ALTER TABLE `occupancies`
  MODIFY `OccupancyId` int(6) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `prices`
--
ALTER TABLE `prices`
  MODIFY `PriceId` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `reservations`
--
ALTER TABLE `reservations`
  MODIFY `ReservationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
