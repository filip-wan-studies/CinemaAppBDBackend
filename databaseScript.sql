/*Tworzenie bazy danych*/
DROP DATABASE bazdan;
CREATE DATABASE IF NOT EXISTS bazdan;
USE bazdan;
CREATE TABLE IF NOT EXISTS Genres (Id smallint unsigned not null auto_increment, Name varchar(20) not null, constraint primary key (Id));
CREATE TABLE IF NOT EXISTS Discounts (Id tinyint unsigned not null auto_increment, Name varchar(20) not null, Ammount smallint not null check(Ammount>=0) check(Ammount<=100), constraint primary key (Id));
CREATE TABLE IF NOT EXISTS Prices (Id tinyint unsigned not null auto_increment,  Name varchar(20) not null, Ammount tinyint not null, constraint primary key (Id));
CREATE TABLE IF NOT EXISTS Rooms (Id tinyint unsigned not null, Name varchar(20), SeatCount smallint not null, constraint primary key(Id));
CREATE TABLE IF NOT EXISTS Seats (Id smallint unsigned not null auto_increment, RoomId tinyint unsigned, Rowing tinyint not null, SeatNumber tinyint not null, constraint primary key(Id), constraint foreign key(RoomId) references Rooms(Id)); 
CREATE TABLE IF NOT EXISTS Employees(Id smallint unsigned not null auto_increment, Name varchar(40) not null, Surname varchar(40) not null, PhoneNumber decimal(11,0), Email varchar(50) not null, Salary mediumint not null check(Salary>0), Secret varchar(50) not null, constraint primary key(Id));
CREATE TABLE IF NOT EXISTS Films (Id int unsigned not null auto_increment, Title varchar(200) not null, GenreId smallint unsigned not null, ImdbId varchar(100) unique, constraint primary key(Id), constraint foreign key(GenreId) references Genres(Id));
CREATE TABLE IF NOT EXISTS Screenings(Id int unsigned not null auto_increment, FilmId int unsigned not null, PriceId tinyint unsigned not null, ScreeningDate datetime not null, RoomId tinyint unsigned not null, constraint primary key(Id), constraint foreign key(FilmId) references Films(Id), constraint foreign key(PriceId) references Prices(Id), constraint foreign key(RoomId) references Rooms(Id));
CREATE TABLE IF NOT EXISTS Clients (Id mediumint unsigned not null auto_increment, Name varchar(40) not null, Surname varchar(40) not null, PhoneNumber decimal(11,0), Email varchar(50), Secret varchar(50) not null, constraint primary key(Id));
CREATE TABLE IF NOT EXISTS Tickets (Id int unsigned not null auto_increment, IssuedDate datetime, SeatId smallint unsigned not null, DiscountId  tinyint unsigned, EmployeeId smallint unsigned, ScreeningId int unsigned not null, constraint primary key(Id), constraint foreign key(DiscountId) references Discounts(Id), constraint foreign key(EmployeeId) references Employees(Id), constraint foreign key(ScreeningId) references Screenings(Id), constraint foreign key(SeatId) references Seats(Id));
CREATE TABLE IF NOT EXISTS Reservations(Id int unsigned not null auto_increment, TicketId int unsigned not null, SubmissionDate datetime not null, ClientId mediumint unsigned, Email varchar(50), constraint primary key(Id), constraint foreign key(ClientId) references Clients(Id), constraint foreign key(TicketId) references Tickets(Id));
CREATE TABLE IF NOT EXISTS Admins(Id smallint unsigned not null auto_increment, Name varchar(40) not null, Surname varchar(40) not null, PhoneNumber decimal(11,0), Email varchar(50) not null, Salary mediumint not null check(Salary>0), Secret varchar(50) not null, constraint primary key(Id));

/*Dodanie danych*/
# Zniżki
INSERT INTO Discounts (Id, name, Ammount) VALUES (null, 'Uczniowska', 20);
INSERT INTO Discounts (Id, name, Ammount) VALUES (null, 'Studencka', 22);
INSERT INTO Discounts (Id, name, Ammount) VALUES (null, 'Dzieci', 50);
INSERT INTO Discounts (Id, name, Ammount) VALUES (null, 'Seniorska', 60);
INSERT INTO Discounts (Id, name, Ammount) VALUES (null, 'Grupowa', 40);

# Gatunki filmów
INSERT INTO Genres (Id, name) VALUES (null, 'Sci-Fi');
INSERT INTO Genres (Id, name) VALUES (null, 'Akcja');
INSERT INTO Genres (Id, name) VALUES (null, 'Horror');
INSERT INTO Genres (Id, name) VALUES (null, 'Dramat');
INSERT INTO Genres (Id, name) VALUES (null, 'Historyczny');
INSERT INTO Genres (Id, name) VALUES (null, 'Dokumentarny');
INSERT INTO Genres (Id, name) VALUES (null, 'Biograficzny');
INSERT INTO Genres (Id, name) VALUES (null, 'Komedia');
INSERT INTO Genres (Id, name) VALUES (null, 'Romantyczny');
INSERT INTO Genres (Id, name) VALUES (null, 'Animowany');
INSERT INTO Genres (Id, name) VALUES (null, 'Przygodowy');
INSERT INTO Genres (Id, name) VALUES (null, 'Kryminał');
INSERT INTO Genres (Id, name) VALUES (null, 'Thriller');
INSERT INTO Genres (Id, name) VALUES (null, 'Rodzinny');
INSERT INTO Genres (Id, name) VALUES (null, 'Musical');
INSERT INTO Genres (Id, name) VALUES (null, 'Western');
INSERT INTO Genres (Id, name) VALUES (null, 'Fantastyka');
INSERT INTO Genres (Id, name) VALUES (null, 'N/A');

# Ceny
INSERT INTO Prices (Id, name, Ammount) VALUES (null, '2D', 20);
INSERT INTO Prices (Id, name, Ammount) VALUES (null, 'Dolby', 22);
INSERT INTO Prices (Id, name, Ammount) VALUES (null, '3D', 30);
INSERT INTO Prices (Id, name, Ammount) VALUES (null, 'IMAX', 38);
INSERT INTO Prices (Id, name, Ammount) VALUES (null, 'SKODA 4DX', 55);

# Pokoje
INSERT INTO Rooms (Id, name, SeatCount) VALUES (1, 'Sala 1', 40);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (2, 'Sala 2', 40);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (3, 'Sala 3', 60);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (4, 'Sala 4', 60);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (5, 'Sala 5', 60);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (6, 'Sala 6', 60);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (7, 'Sala 7', 80);
INSERT INTO Rooms (Id, name, SeatCount) VALUES (8, 'Sala 8', 80);

# Administratorzy 
INSERT INTO Admins (Id, Name, Surname, PhoneNumber, Email, Salary, Secret) VALUES (null, 'Zbigniew', 'Skis', 48666444444, 'zbig.zgiz@pwr.edu.pl', 12000, 'bestpassword');

# Pracownicy
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/siedzenia.csv' INTO TABLE Seats FIELDS TERMINATED BY ';';

# Pracownicy
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/pracownik.csv' INTO TABLE Employees FIELDS TERMINATED BY ';';

# Filmy
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/filmy.csv' INTO TABLE Films FIELDS TERMINATED BY ';';

# Seanse
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/seans.csv' INTO TABLE Screenings FIELDS TERMINATED BY ';';

# Tickets
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/bilet.csv' INTO TABLE Tickets FIELDS TERMINATED BY ';' 
(Id, SeatId, DiscountId, EmployeeId, ScreeningId) ;

# Klienci
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/klienci.csv' INTO TABLE Clients FIELDS TERMINATED BY ';';

# Reservations
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/rezerwacje.csv' INTO TABLE Reservations FIELDS TERMINATED BY ';' LINES TERMINATED BY '\n'
(Id, TicketId, @dummy, SubmissionDate, ClientId, @vEmail)
SET Email = nullif(@vemial, '');