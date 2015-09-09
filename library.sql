# ************************************************************
# Sequel Pro SQL dump
# Version 4096
#
# http://www.sequelpro.com/
# http://code.google.com/p/sequel-pro/
#
# Host: 127.0.0.1 (MySQL 5.6.26)
# Database: library
# Generation Time: 2015-09-09 09:02:07 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table book_database
# ------------------------------------------------------------

DROP TABLE IF EXISTS `book_database`;

CREATE TABLE `book_database` (
  `book_id` int(11) NOT NULL,
  `title` varchar(30) NOT NULL,
  `author` varchar(30) DEFAULT NULL,
  `genre` varchar(30) NOT NULL,
  `no_of_copies` int(11) NOT NULL,
  PRIMARY KEY (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table borrowed_books
# ------------------------------------------------------------

DROP TABLE IF EXISTS `borrowed_books`;

CREATE TABLE `borrowed_books` (
  `book_id` int(11) NOT NULL,
  `card_no` int(11) NOT NULL,
  `issue_date` varchar(30) NOT NULL,
  `due_date` varchar(30) NOT NULL,
  PRIMARY KEY (`card_no`),
  KEY `book_id` (`book_id`),
  CONSTRAINT `borrowed_books_ibfk_1` FOREIGN KEY (`card_no`) REFERENCES `borrower_details` (`card_no`),
  CONSTRAINT `borrowed_books_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `book_database` (`book_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table borrower_details
# ------------------------------------------------------------

DROP TABLE IF EXISTS `borrower_details`;

CREATE TABLE `borrower_details` (
  `card_no` int(11) NOT NULL,
  `name` varchar(10) NOT NULL,
  `contact_no` varchar(30) NOT NULL,
  `fine` int(11) DEFAULT NULL,
  PRIMARY KEY (`card_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table login_credential
# ------------------------------------------------------------

DROP TABLE IF EXISTS `login_credential`;

CREATE TABLE `login_credential` (
  `username` varchar(10) NOT NULL DEFAULT '',
  `password` varchar(16) DEFAULT NULL,
  `id` int(11) DEFAULT NULL,
  PRIMARY KEY (`username`),
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `login_credential` WRITE;
/*!40000 ALTER TABLE `login_credential` DISABLE KEYS */;

INSERT INTO `login_credential` (`username`, `password`, `id`)
VALUES
	('admin','admin',1);

/*!40000 ALTER TABLE `login_credential` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
