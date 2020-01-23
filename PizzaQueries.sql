 Create Database PizzaDB;
go;
create schema OOP;
go; 
DROP SCHEMA PizzaDB;

Create table _User(
username varchar(50) not null,
Pass varchar(50) not null,
PRIMARY KEY (username),
);

go;
DROP TABLE _User;

Create table Pizzas(
pizzaId int identity (1,1),
crust varchar(50) not null,
size varchar(50) not null,
username varchar(50) not null, 
pizzaType varchar(50) not null,
price money not null,
PRIMARY KEY (pizzaId),
FOREIGN KEY (username) REFERENCES _USER(username),
);

DROP TABLE Pizzas;

Create table Orders(
orderId int identity (1,1) not null,
totalCharges money not null,
placedAt varchar(50) not null,
username varchar(50) not null,
storeName varchar(50) not null,
PRIMARY KEY (orderId),
FOREIGN KEY (storeName) REFERENCES Store(storeName),
FOREIGN KEY (username) REFERENCES _User(username),
);
DROP TABLE Orders;

select * from PizzaDB._User;

Create table Store(

storeName varchar(50) not null,
venue varchar(50) not null,
PRIMARY KEY (storeName),
);

DROP TABLE Store;

create table CompletedOrders(
orderId int not null,
PRIMARY KEY (orderId),
FOREIGN KEY (orderId) REFERENCES Orders(orderId),
);

DROP TABLE CompletedOrders;

USE OOP;
ALTER TABLE dbo.Pizzas
ADD pizzaType varchar(50);
select * from dbo.Pizzas;
delete from dbo.Orders;
select * from dbo._User;