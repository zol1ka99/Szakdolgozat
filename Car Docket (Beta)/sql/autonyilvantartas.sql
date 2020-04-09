-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Ápr 09. 00:10
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `autonyilvantartas`
--
CREATE DATABASE IF NOT EXISTS `autonyilvantartas` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `autonyilvantartas`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cars`
--

CREATE TABLE `cars` (
  `id` int(11) NOT NULL,
  `marka` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `tipus` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `gyartasi_ev` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  `vetelar` int(15) DEFAULT NULL,
  `rendszam` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `kilometeroraallas` int(10) DEFAULT NULL,
  `alvazszam` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `gepkocsi_tipusa` varchar(5) COLLATE utf8_hungarian_ci NOT NULL,
  `uzemanyag` varchar(15) COLLATE utf8_hungarian_ci NOT NULL,
  `sebessegvalto_tipusa` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `tulid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `cars`:
--   `tulid`
--       `tulajdonosok` -> `tulid`
--

--
-- A tábla adatainak kiíratása `cars`
--

INSERT INTO `cars` (`id`, `marka`, `tipus`, `gyartasi_ev`, `vetelar`, `rendszam`, `kilometeroraallas`, `alvazszam`, `gepkocsi_tipusa`, `uzemanyag`, `sebessegvalto_tipusa`, `tulid`) VALUES
(1, 'Audi', 'A5', '2018-01-02', 2005000, 'RSF-123', 15000, 'AZR8123654987547T', 'SzGK', 'Benzin', 'Automata', 1),
(2, 'BMW', '520D', '2018-04-14', 2007000, 'RZT-874', 150000, 'AZR8123665487547T', 'SzGK', 'Benzin', 'Automata', 1),
(3, 'Opel', 'Astra', '2018-12-16', 2400000, 'OTU-756', 155400, 'AZR8122764987547T', 'SzGK', 'Dízel', 'Manuális', 2),
(4, 'BMW', 'M5', '2020-02-15', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 2),
(5, 'Skoda', 'Fabia', '2005-05-25', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 3),
(6, 'BMW', 'X5', '2014-01-18', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 3),
(7, 'Skoda', 'Octavia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', 4),
(8, 'Skoda', 'Citygo', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 4),
(9, 'BMW', '330I', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', 5),
(10, 'BMW', 'X1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 5),
(11, 'Skoda', 'Karoq', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 6),
(12, 'BMW', 'X7', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', 6),
(13, 'Skoda', 'Fabia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 7),
(14, 'Audi', 'A1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 7),
(15, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 8),
(16, 'Volkswagen', 'Golf', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 8),
(17, 'BMW', '520D', '2018-04-14', 2007000, 'RZT-874', 150000, 'AZR8123665487547T', 'SzGK', 'Benzin', 'Automata', 9),
(18, 'Opel', 'Astra', '2018-12-16', 2400000, 'OTU-756', 155400, 'AZR8122764987547T', 'SzGK', 'Dízel', 'Manuális', 9),
(19, 'BMW', 'M5', '2020-02-15', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 10),
(20, 'Skoda', 'Fabia', '2005-05-25', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 10),
(21, 'BMW', 'X5', '2014-01-18', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 11),
(22, 'Skoda', 'Octavia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', 11),
(23, 'Skoda', 'Citygo', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 12),
(24, 'BMW', '330I', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', 12),
(25, 'BMW', 'X1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 13),
(26, 'Skoda', 'Karoq', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 13),
(27, 'BMW', 'X7', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Hibrid', 'Automata', 14),
(28, 'Skoda', 'Fabia', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 14),
(29, 'Audi', 'A1', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Manuális', 15),
(30, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(31, 'BMW', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(32, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(33, 'Skoda', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(34, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(35, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(36, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(37, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(38, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(39, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(40, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(41, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(42, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(43, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(44, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(45, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(46, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(47, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(48, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(49, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(50, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(51, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(52, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(53, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(54, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(55, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(56, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(57, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(58, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(59, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(60, 'Bugatti', 'Chiron', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Dízel', 'Automata', 15),
(61, 'Volkswagen', 'Golf', '2018-08-12', 2900000, 'RPT-543', 150800, 'AZR8168254987547T', 'SzGK', 'Benzin', 'Automata', 16);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cegek`
--

CREATE TABLE `cegek` (
  `cegid` int(11) NOT NULL,
  `cegnev` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `adoszam` int(13) NOT NULL,
  `varos` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `utca` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `szam` varchar(7) COLLATE utf8_hungarian_ci NOT NULL,
  `ceg_email_cim` varchar(40) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `cegek`:
--

--
-- A tábla adatainak kiíratása `cegek`
--

INSERT INTO `cegek` (`cegid`, `cegnev`, `adoszam`, `varos`, `utca`, `szam`, `ceg_email_cim`) VALUES
(1, 'Test kft', 123456, 'Szeged', 'Valami utca', '12', 'test1@gmail.com'),
(2, 'Test2 kft', 765344, 'Deszk', 'Valami1 utca', '14', 'test2@gmail.com'),
(3, 'Test3 kft', 873456, 'Budapest', 'Valami2 utca', '16', 'test3@gmail.com'),
(4, 'Test4 kft', 878496, 'Deszk', 'Valami3 utca', '20', 'test4@gmail.com'),
(5, 'Test5 kft', 878496, 'Szeged', 'Valami3 utca', '20', 'test5@gmail.com'),
(6, 'Test6 kft', 878496, 'Pécs', 'Valami3 utca', '20', 'test6@gmail.com'),
(7, 'Test7 kft', 878496, 'Szeged', 'Valami3 utca', '20', 'test7@gmail.com'),
(8, 'Test8 kft', 878496, 'Budapest', 'Valami3 utca', '20', 'test8@gmail.com');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `id` int(11) NOT NULL,
  `felhasznalonev` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `emailcimfelhasznalo` varchar(30) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `felhasznalok`:
--

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`id`, `felhasznalonev`, `jelszo`, `emailcimfelhasznalo`) VALUES
(1, 'admin', 'admin', 'proba1@gmail.com'),
(2, 'Teszt1', '1234', 'proba2@gmail.com'),
(3, 'Teszt2', '1234', 'proba3@gmail.com'),
(4, 'Teszt3', '1234', 'proba4@gmail.com');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tulajdonosok`
--

CREATE TABLE `tulajdonosok` (
  `tulid` int(11) NOT NULL,
  `tulajdonos_nev` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `tulajdonos_szemelyiigszam` varchar(8) COLLATE utf8_hungarian_ci NOT NULL,
  `jogositvany_azon` int(11) NOT NULL,
  `email_cim` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `telefonszam` int(11) NOT NULL,
  `cegid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `tulajdonosok`:
--   `cegid`
--       `cegek` -> `cegid`
--

--
-- A tábla adatainak kiíratása `tulajdonosok`
--

INSERT INTO `tulajdonosok` (`tulid`, `tulajdonos_nev`, `tulajdonos_szemelyiigszam`, `jogositvany_azon`, `email_cim`, `telefonszam`, `cegid`) VALUES
(1, 'Kiss Ferenc1', '1234', 12351, 'feribacsi@valami1.com', 202663557, 1),
(2, 'Kiss Ferenc2', '1234', 12351, 'feribacsi@valami2.com', 202623457, 1),
(3, 'Kiss Ferenc3', '1234', 12351, 'feribacsi@valami3.com', 202606547, 2),
(4, 'Kiss Ferenc4', '1234', 12351, 'feribacsi@valami4.com', 207756655, 2),
(5, 'Kiss Ferenc5', '1234', 12351, 'feribacsi@valami5.com', 207756655, 3),
(6, 'Kiss Ferenc6', '1234', 12351, 'feribacsi@valami6.com', 207756655, 3),
(7, 'Kiss Ferenc7', '1234', 12351, 'feribacsi@valami7.com', 207756655, 4),
(8, 'Kiss Ferenc8', '1234', 12351, 'feribacsi@valami8.com', 207756655, 4),
(9, 'Kiss Ferenc9', '1234', 12351, 'feribacsi@valami9.com', 202663557, 5),
(10, 'Kiss Ferenc10', '1234', 12351, 'feribacsi@valami10.com', 202623457, 5),
(11, 'Kiss Ferenc11', '1234', 12351, 'feribacsi@valami11.com', 202606547, 6),
(12, 'Kiss Ferenc12', '1234', 12351, 'feribacsi@valami12.com', 207756655, 6),
(13, 'Kiss Ferenc13', '1234', 12351, 'feribacsi@valami13.com', 207756655, 7),
(14, 'Kiss Ferenc14', '1234', 12351, 'feribacsi@valami14.com', 207756655, 7),
(15, 'Kiss Ferenc15', '1234', 12351, 'feribacsi@valami15.com', 207756655, 8),
(16, 'Kiss Ferenc16', '1234', 12351, 'feribacsi@valami16.com', 207756655, 8);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`id`),
  ADD KEY `cars_ibfk_1` (`tulid`);

--
-- A tábla indexei `cegek`
--
ALTER TABLE `cegek`
  ADD PRIMARY KEY (`cegid`);

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `tulajdonosok`
--
ALTER TABLE `tulajdonosok`
  ADD PRIMARY KEY (`tulid`),
  ADD KEY `tulajdonosok_ibfk_1` (`cegid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `cars`
--
ALTER TABLE `cars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- AUTO_INCREMENT a táblához `cegek`
--
ALTER TABLE `cegek`
  MODIFY `cegid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `tulajdonosok`
--
ALTER TABLE `tulajdonosok`
  MODIFY `tulid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `cars`
--
ALTER TABLE `cars`
  ADD CONSTRAINT `cars_ibfk_1` FOREIGN KEY (`tulid`) REFERENCES `tulajdonosok` (`tulid`);

--
-- Megkötések a táblához `tulajdonosok`
--
ALTER TABLE `tulajdonosok`
  ADD CONSTRAINT `tulajdonosok_ibfk_1` FOREIGN KEY (`cegid`) REFERENCES `cegek` (`cegid`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
