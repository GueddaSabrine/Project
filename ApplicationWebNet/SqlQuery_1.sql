CREATE DATABASE [AgendaCourtier]
GO

USE [AgendaCourtier]
GO
/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Customers
------------------------------------------------------------*/
CREATE TABLE Customers(
	idCustomer    INT IDENTITY (1,1) NOT NULL ,
	lastname      NVARCHAR (50) NOT NULL ,
	firstname     NVARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL  ,
	CONSTRAINT Customers_PK PRIMARY KEY (idCustomer)
);


/*------------------------------------------------------------
-- Table: Brokers
------------------------------------------------------------*/
CREATE TABLE Brokers(
	idBroker      INT IDENTITY (1,1) NOT NULL ,
	lastname      NVARCHAR (50) NOT NULL ,
	firstname     NVARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL  ,
	CONSTRAINT Brokers_PK PRIMARY KEY (idBroker)
);


/*------------------------------------------------------------
-- Table: Appointments
------------------------------------------------------------*/
CREATE TABLE Appointments(
	idAppointment   INT IDENTITY (1,1) NOT NULL ,
	dateHour        DATETIME  NOT NULL ,
	subject         TEXT  NOT NULL ,
	idCustomer      INT  NOT NULL ,
	idBroker        INT  NOT NULL  ,
	CONSTRAINT Appointments_PK PRIMARY KEY (idAppointment)

	,CONSTRAINT Appointments_Customers_FK FOREIGN KEY (idCustomer) REFERENCES Customers(idCustomer)
	,CONSTRAINT Appointments_Brokers0_FK FOREIGN KEY (idBroker) REFERENCES Brokers(idBroker)
);



