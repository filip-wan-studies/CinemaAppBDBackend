/*Tworzenie bazy danych*/
DROP DATABASE bazdan;
CREATE DATABASE IF NOT EXISTS bazdan;
USE bazdan;
CREATE TABLE IF NOT EXISTS Genres (id_genre smallint unsigned not null auto_increment, name varchar(20) not null, constraint primary key (id_genre));
CREATE TABLE IF NOT EXISTS Discounts (id_discount tinyint unsigned not null auto_increment, name varchar(20) not null, ammount smallint not null check(ammount>=0) check(ammount<=100), constraint primary key (id_discount));
CREATE TABLE IF NOT EXISTS Prices (id_price tinyint unsigned not null auto_increment,  name varchar(20) not null, ammount tinyint not null, constraint primary key (id_price));
CREATE TABLE IF NOT EXISTS Rooms (id_room tinyint unsigned not null, name varchar(20), seat_count smallint not null, constraint primary key(id_room));
CREATE TABLE IF NOT EXISTS Employees(id_employee smallint unsigned not null auto_increment, name varchar(40) not null, surname varchar(40) not null, phone_number decimal(11,0), email varchar(50) not null, salary mediumint not null check(salary>0), secret varchar(50) not null, constraint primary key(id_employee));
CREATE TABLE IF NOT EXISTS Films (id_film int unsigned not null auto_increment, title varchar(200) not null, id_genre smallint unsigned not null, id_imbd varchar(100) unique, constraint primary key(id_film), constraint foreign key(id_genre) references Genres(id_genre));
CREATE TABLE IF NOT EXISTS Screenings(id_screening int unsigned not null auto_increment, id_film int unsigned not null, id_price tinyint unsigned not null, date_screening datetime not null, constraint primary key(id_screening), constraint foreign key(id_film) references Films(id_film), constraint foreign key(id_price) references Prices(id_price));
CREATE TABLE IF NOT EXISTS Tickets (id_ticket int unsigned not null auto_increment, seat_number tinyint not null, id_room tinyint unsigned not null, id_price tinyint unsigned not null, id_discount  tinyint unsigned not null, id_employee smallint unsigned not null, id_screening int unsigned not null, constraint primary key(id_ticket), constraint foreign key(id_room) references Rooms(id_room), constraint foreign key(id_price) references Prices(id_price), constraint foreign key(id_discount) references Discounts(id_discount), constraint foreign key(id_employee) references Employees(id_employee), constraint foreign key(id_screening) references Screenings(id_screening));
CREATE TABLE IF NOT EXISTS Clients (id_client mediumint unsigned not null auto_increment, name varchar(40) not null, surname varchar(40) not null, phone_number decimal(11,0), email varchar(50), secret varchar(50) not null, constraint primary key(id_client));
CREATE TABLE IF NOT EXISTS Reservations(id_reservation int unsigned not null auto_increment, id_ticket int unsigned not null, date_issued datetime, date_submission datetime not null, id_client mediumint unsigned, email varchar(50), constraint primary key(id_reservation), constraint foreign key(id_client) references Clients(id_client), constraint foreign key(id_ticket) references Tickets(id_ticket), constraint check (date_issued>date_submission));
CREATE TABLE IF NOT EXISTS Admins(id_admin smallint unsigned not null auto_increment, name varchar(40) not null, surname varchar(40) not null, phone_number decimal(11,0), email varchar(50) not null, salary mediumint not null check(salary>0), constraint primary key(id_admin));

/*Dodanie danych*/
# Zniżki
INSERT INTO Discounts (id_discount, name, ammount) VALUES (null, 'Uczniowska', 20);
INSERT INTO Discounts (id_discount, name, ammount) VALUES (null, 'Studencka', 22);
INSERT INTO Discounts (id_discount, name, ammount) VALUES (null, 'Dzieci', 50);
INSERT INTO Discounts (id_discount, name, ammount) VALUES (null, 'Seniorska', 60);
INSERT INTO Discounts (id_discount, name, ammount) VALUES (null, 'Grupowa', 40);

# Gatunki filmów
INSERT INTO Genres (id_genre, name) VALUES (null, 'Sci-Fi');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Akcja');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Horror');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Dramat');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Historyczny');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Dokumentarny');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Biograficzny');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Komedia');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Romantyczny');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Animowany');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Przygodowy');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Kryminał');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Thriller');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Rodzinny');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Musical');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Western');
INSERT INTO Genres (id_genre, name) VALUES (null, 'Fantastyka');
INSERT INTO Genres (id_genre, name) VALUES (null, 'N/A');

# Ceny
INSERT INTO Prices (id_price, name, ammount) VALUES (null, '2D', 20);
INSERT INTO Prices (id_price, name, ammount) VALUES (null, 'Dolby', 22);
INSERT INTO Prices (id_price, name, ammount) VALUES (null, '3D', 30);
INSERT INTO Prices (id_price, name, ammount) VALUES (null, 'IMAX', 38);
INSERT INTO Prices (id_price, name, ammount) VALUES (null, 'SKODA 4DX', 55);

# Pokoje
INSERT INTO Rooms (id_room, name, seat_count) VALUES (1, 'Sala 1', 40);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (2, 'Sala 2', 40);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (3, 'Sala 3', 60);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (4, 'Sala 4', 60);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (5, 'Sala 5', 60);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (6, 'Sala 6', 60);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (7, 'Sala 7', 80);
INSERT INTO Rooms (id_room, name, seat_count) VALUES (8, 'Sala 8', 80);

# Administratorzy 
INSERT INTO Admins (id_admin, name, surname, phone_number, email, salary) VALUES (null, 'Zbigniew', 'Skis', 48666444444, 'zbig.zgiz@pwr.edu.pl', 12000);

# Pracownicy
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/pracownik.csv' INTO TABLE Employees FIELDS TERMINATED BY ';';

# Filmy
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/filmy.csv' INTO TABLE Films FIELDS TERMINATED BY ';';

# Seanse
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/seans.csv' INTO TABLE Screenings FIELDS TERMINATED BY ';';

# Tickets
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/bilet.csv' INTO TABLE Tickets FIELDS TERMINATED BY ';';

# Klienci
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/klienci.csv' INTO TABLE Clients FIELDS TERMINATED BY ';';

# Reservations
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/rezerwacje.csv' INTO TABLE Reservations FIELDS TERMINATED BY ';' LINES TERMINATED BY '\n'
(id_reservation, id_ticket, date_issued, date_submission, id_client, @vemail)
SET email = nullif(@vemial, '');