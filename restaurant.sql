USE [master]
GO
/****** Object:  Database [restaurant]    Script Date: 2/25/2016 4:36:55 PM ******/
CREATE DATABASE [restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurant', FILENAME = N'C:\Users\epicodus_student\restaurant.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'restaurant_log', FILENAME = N'C:\Users\epicodus_student\restaurant_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [restaurant] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restaurant] SET  ENABLE_BROKER 
GO
ALTER DATABASE [restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restaurant] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
USE [restaurant]
GO
/****** Object:  Table [dbo].[cuisine]    Script Date: 2/25/2016 4:36:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cuisine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[restaurant]    Script Date: 2/25/2016 4:36:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[restaurant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL,
	[cuisine_id] [int] NULL,
	[address] [varchar](255) NULL,
	[phone] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[review]    Script Date: 2/25/2016 4:36:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[review](
	[description] [varchar](255) NULL,
	[username] [varchar](255) NULL,
	[restaurant_id] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[cuisine] ON 

INSERT [dbo].[cuisine] ([id], [description]) VALUES (1, N'Indian')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (2, N'Italian')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (3, N'Greek')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (4, N'Thai')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (5, N'Egyptian')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (6, N'Chinese')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (7, N'Lebanese')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (8, N'Spanish')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (9, N'American')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (10, N'Argentinean')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (11, N'Cuban')
INSERT [dbo].[cuisine] ([id], [description]) VALUES (12, N'African')
SET IDENTITY_INSERT [dbo].[cuisine] OFF
SET IDENTITY_INSERT [dbo].[restaurant] ON 

INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (8, N'Olive Garden', 2, N'123 Example St', N'555-555-5555')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (9, N'Bangkok Kitchen', 4, N'123 Example St', N'555-555-5555')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (10, N'Verona', 2, N'123 Example St', N'555-555-5555')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (16, N'Toro Bravo', 8, N'120 NE Russell St', N'(503) 281-4464')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (12, N'Taste of India', 1, N'123 Example St', N'555-555-5555')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (15, N'Different', 6, N'123 Example St', N'555-555-5555')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (17, N'Nicholas Restaurant', 7, N'3223 NE Broadway St', N'(503) 445-4700')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (18, N'Ned Ludd', 9, N'3925 NE Martin Luther King Jr Blvd', N'(503) 288-6900')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (19, N'OX Restaurant', 10, N'2225 NE Martin Luther King Jr Blvd', N'(503) 284-3366')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (20, N'Pambiche', 11, N'2811 NE Glisan St', N'(503) 233-0511')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (21, N'Queen of Sheba ', 12, N' 2413 NE Martin Luther King Jr Blvd', N'(503) 287-6302')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (22, N'Bollywood Theater', 1, N'2039 NE Alberta St', N'(971) 200-4711')
INSERT [dbo].[restaurant] ([id], [description], [cuisine_id], [address], [phone]) VALUES (23, N'Namaste Indian Cuisine', 1, N'1403 NE Weidler St', N'(503) 442-3841')
SET IDENTITY_INSERT [dbo].[restaurant] OFF
SET IDENTITY_INSERT [dbo].[review] ON 

INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'Dang this curry is great.', N'jmk22', 12, 3)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'awesome kebab', N'michael', 11, 4)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'holy kebab!', N'jmk22', 0, 13)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'Delicious all-you-can-eat Indian buffet, the kind which is strangely missing around Portland, compared to some other west coast cities.', N'Jon Van Oast', 23, 17)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'I''ve been trying several Indian restaurants and so far this is the one that I always come back to. They offer a buffet that costs $13 for dinner and $10 for lunch.', N'Ibrahim Alsamnan', 23, 18)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'Omg this place is delicious! The staff was friendly and the place is very cute. The food is hearty and extremely tasty. The lunch buffet is $10 and the dinner buffet is $13. I''ll definitely be back!', N'fiema kurinzi', 23, 19)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'We thoroughly enjoyed this place. We came with my husbands cousin, who frequents it often. We ordered the beet salad, it was delicious if you like beets! ', N'Hannah Sivilay', 22, 20)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'Great ambience, great service. The food is just too expensive and tastes alright. ', N'Shaveen Kumar', 22, 21)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'This was a fun place to visit and the food was tasty. However, if you have no understanding of Indian foods, you will have a tough time making selections.', N'Gil Gerretsen', 22, 23)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'This is bad indian food people. I got take out from here twice. First time I gave them the benefit of doubt.', N'Robert Lazar', 12, 24)
INSERT [dbo].[review] ([description], [username], [restaurant_id], [id]) VALUES (N'They have the best paneer cheese entr?e I''ve ever had at any Indian restaurant or food cart and having option to add lamb just makes it so much better!', N'Tabitha Teo', 12, 25)
SET IDENTITY_INSERT [dbo].[review] OFF
USE [master]
GO
ALTER DATABASE [restaurant] SET  READ_WRITE 
GO
