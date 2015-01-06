USE [master]
GO

/****** Object:  Database [TestPractico]    Script Date: 01/06/2015 11:28:16 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'TestPractico')
DROP DATABASE [TestPractico]
GO

USE [master]
GO

/****** Object:  Database [TestPractico]    Script Date: 01/06/2015 11:28:16 ******/
CREATE DATABASE [TestPractico] ON  PRIMARY 
( NAME = N'TestPractico', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\TestPractico.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestPractico_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\TestPractico_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [TestPractico] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestPractico].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TestPractico] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TestPractico] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TestPractico] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TestPractico] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TestPractico] SET ARITHABORT OFF 
GO

ALTER DATABASE [TestPractico] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TestPractico] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [TestPractico] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TestPractico] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TestPractico] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TestPractico] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TestPractico] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TestPractico] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TestPractico] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TestPractico] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TestPractico] SET  DISABLE_BROKER 
GO

ALTER DATABASE [TestPractico] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TestPractico] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TestPractico] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TestPractico] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TestPractico] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TestPractico] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [TestPractico] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TestPractico] SET  READ_WRITE 
GO

ALTER DATABASE [TestPractico] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [TestPractico] SET  MULTI_USER 
GO

ALTER DATABASE [TestPractico] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TestPractico] SET DB_CHAINING OFF 
GO

