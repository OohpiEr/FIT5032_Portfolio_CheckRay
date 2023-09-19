--drop table Facility;
--drop table Patient;
--drop table Doctor;
--drop table Admin;
--drop table Review;
--drop table Booking;

--create table Patient
CREATE TABLE [dbo].[Patient] (
	[patientId] int IDENTITY(1,1) NOT NULL,
	[patientEmail] nvarchar(50),
	[patientFirstName] nvarchar(50),
	[patientLastName] nvarchar(50)
	PRIMARY KEY (patientId)
);
GO

--create table Doctor
CREATE TABLE [dbo].[Doctor] (
	[doctorId] int IDENTITY(1,1) NOT NULL,
	[doctorEmail] nvarchar(50),
	[doctorFirstName] nvarchar(50),
	[doctorLastName] nvarchar(50)
	PRIMARY KEY (doctorId)
);
GO

--create table Admin
CREATE TABLE [dbo].[Admin] (
	[adminId] int IDENTITY(1,1) NOT NULL,
	[adminEmail] nvarchar(50),
	[adminFirstName] nvarchar(50),
	[adminLastName] nvarchar(50)
	PRIMARY KEY (adminId)
);
GO

--create table Review
CREATE TABLE [dbo].[Review] (
	[reviewId] int IDENTITY(1,1) NOT NULL,
	[reviewRating] int,
	[reviewComment] nvarchar(max),
	[patientId] int
	PRIMARY KEY (reviewId),
	FOREIGN KEY (patientId) REFERENCES [Patient] (patientId)
);
GO

--create table Facility
CREATE TABLE [dbo].[Facility] (
	[facilityId] int IDENTITY(1,1) NOT NULL,
	[facilityName] nvarchar(max) NOT NULL,
	[facilityAddress] nvarchar(max) NOT NULL
	PRIMARY KEY (facilityId)
);
GO

--create table Booking
CREATE TABLE [dbo].[Booking] (
	[bookingId] int IDENTITY(1,1) NOT NULL,
	[doctorId] int,
	[patientId] int NOT NULL,
	[facilityId] int NOT NULL,
	[status] bit DEFAULT 0,
	[reviewId] int
	PRIMARY KEY (bookingId),
	FOREIGN KEY (patientId) REFERENCES [Patient] (patientId),
	FOREIGN KEY (doctorId) REFERENCES [Doctor] (doctorId),
	FOREIGN KEY (facilityId) REFERENCES [Facility] (facilityId),
	FOREIGN KEY (reviewId) REFERENCES [Review] (reviewId)
);
GO


