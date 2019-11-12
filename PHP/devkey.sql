-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3307
-- Generation Time: 31-Out-2019 às 21:14
-- Versão do servidor: 10.3.14-MariaDB
-- versão do PHP: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `devkey`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `dev_tarefa`
--

DROP TABLE IF EXISTS `dev_tarefa`;
CREATE TABLE IF NOT EXISTS `dev_tarefa` (
  `trf_id` int(11) NOT NULL AUTO_INCREMENT,
  `trf_nome` varchar(255) NOT NULL,
  `trf_descricao` varchar(255) DEFAULT NULL,
  `trf_usu` int(11) NOT NULL,
  `trf_data_ini` date DEFAULT NULL,
  `trf_data_fim` date DEFAULT NULL,
  `trf_status` varchar(3) DEFAULT 'pen',
  `trf_ordem` int(11) DEFAULT NULL,
  PRIMARY KEY (`trf_id`),
  KEY `fk_trf_usu` (`trf_usu`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `dev_tarefa`
--

INSERT INTO `dev_tarefa` (`trf_id`, `trf_nome`, `trf_descricao`, `trf_usu`, `trf_data_ini`, `trf_data_fim`, `trf_status`, `trf_ordem`) VALUES
(1, 'Documentação', NULL, 1, '2019-10-01', '2019-10-31', 'exe', 3),
(2, 'Banner', NULL, 2, '2019-10-01', '2019-10-24', 'exe', 2),
(3, 'Diagrama de Classe', NULL, 3, '2019-10-02', '2019-10-30', 'fin', 3),
(4, 'Caso de Uso', 'Sistema ASP NET', 5, '2019-09-01', '2019-11-29', 'fin', 4),
(5, 'oio', 'oio', 1, NULL, NULL, 'pen', 2),
(6, 'tarefa', 'tarefa tarefada', 1, NULL, NULL, 'fin', 1),
(7, 'eee', '        eee', 3, NULL, NULL, 'exe', 1),
(8, 'aaaa', '        aaaaa', 4, NULL, NULL, 'pen', 3),
(9, 'aaaa', '        aaaaa', 4, NULL, NULL, 'pen', 4),
(10, 'qqqq', '        qqqq', 1, NULL, NULL, 'pen', 5),
(11, 'oioioi', '        oioioioio', 7, NULL, NULL, 'pen', 1),
(12, 'testeteste', '       hhhhhhhhhhhhhhhhhhhhhhhhhhhhhh ', 8, NULL, NULL, 'fin', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `dev_usuario`
--

DROP TABLE IF EXISTS `dev_usuario`;
CREATE TABLE IF NOT EXISTS `dev_usuario` (
  `usu_id` int(11) NOT NULL AUTO_INCREMENT,
  `usu_nome` varchar(20) DEFAULT NULL,
  `usu_email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`usu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `dev_usuario`
--

INSERT INTO `dev_usuario` (`usu_id`, `usu_nome`, `usu_email`) VALUES
(1, 'andy', 'andy@teste.com'),
(2, 'andy2', 'andy2@teste.com'),
(3, 'andy3', 'andy3@teste.com'),
(4, 'andy4', 'andy4@teste.com'),
(5, 'andy5', 'andy5@teste.com'),
(6, 'hdhd', 'teste@teste.com'),
(7, 'qqqqqqqqqqqqqq', 'qqqqqqqqqqqqqqq@ddd.com'),
(8, 'teste', 'teste@nn.com');

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `dev_tarefa`
--
ALTER TABLE `dev_tarefa`
  ADD CONSTRAINT `fk_trf_usu` FOREIGN KEY (`trf_usu`) REFERENCES `dev_usuario` (`usu_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
