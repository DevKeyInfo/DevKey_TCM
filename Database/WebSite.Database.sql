USE [master]
GO
/****** Object:  Database [WebSite]    Script Date: 11/11/2019 1:06:44 PM ******/
CREATE DATABASE [WebSite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CadastroLogin', FILENAME = N'C:\MSSQL\DATA\WebSite.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CadastroLogin_log', FILENAME = N'C:\MSSQL\LOG\WebSite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebSite] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebSite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebSite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebSite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebSite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebSite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebSite] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebSite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebSite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebSite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebSite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebSite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebSite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebSite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebSite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebSite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebSite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebSite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebSite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebSite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebSite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebSite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebSite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebSite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebSite] SET RECOVERY FULL 
GO
ALTER DATABASE [WebSite] SET  MULTI_USER 
GO
ALTER DATABASE [WebSite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebSite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebSite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebSite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebSite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebSite] SET QUERY_STORE = OFF
GO
ALTER DATABASE [WebSite] SET  READ_WRITE 
GO
