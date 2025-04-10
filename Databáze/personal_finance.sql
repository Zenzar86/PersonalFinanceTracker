-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Počítač: 127.0.0.1
-- Vytvořeno: Čtv 10. dub 2025, 09:36
-- Verze serveru: 10.4.32-MariaDB
-- Verze PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `personal_finance`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `categories`
--

INSERT INTO `categories` (`category_id`, `name`, `description`, `created_at`) VALUES
(1, 'Mzda', 'Pravidelný příjem ze zaměstnání', '2025-04-08 05:50:27'),
(2, 'Potraviny', 'Nákupy jídla a pití', '2025-04-08 05:50:27'),
(3, 'Bydlení', 'Nájem, hypotéka, energie', '2025-04-08 05:50:27'),
(4, 'Doprava', 'Náklady na auto, MHD', '2025-04-08 05:50:27'),
(5, 'Zábava', 'Kino, restaurace, koníčky', '2025-04-08 05:50:27'),
(6, 'Ostatní výdaje', 'Nepravidelné nebo nekategorizované výdaje', '2025-04-08 05:50:27'),
(7, 'Ostatní příjmy', 'Nepravidelné nebo nekategorizované příjmy', '2025-04-08 05:50:27');

-- --------------------------------------------------------

--
-- Struktura tabulky `transactions`
--

CREATE TABLE `transactions` (
  `transaction_id` int(11) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `type` enum('Příjem','Výdej') NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `description` text DEFAULT NULL,
  `transaction_date` date NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_czech_ci;

--
-- Vypisuji data pro tabulku `transactions`
--

INSERT INTO `transactions` (`transaction_id`, `category_id`, `type`, `amount`, `description`, `transaction_date`, `created_at`) VALUES
(7, 1, 'Příjem', 5000.00, 'Bonus', '2025-04-09', '2025-04-09 10:14:03');

--
-- Indexy pro exportované tabulky
--

--
-- Indexy pro tabulku `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexy pro tabulku `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `category_id` (`category_id`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT pro tabulku `transactions`
--
ALTER TABLE `transactions`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
