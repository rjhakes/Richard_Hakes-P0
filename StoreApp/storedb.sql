--Drop Sequence for Tables
drop table addresses;
drop table customerCarts;
drop table managersCarts;
drop table customerOrderHistory;
drop table storeOrderHistory;
drop table customerOrderLineItems;
drop table inventoryLineItems;
drop table inventory;
drop table storeOrderLineItems;
drop table managers;
drop table locations;
drop table products;
drop table categories;
drop table customers;


create table categories 
(
	id int identity primary key,
	category varchar(20) not null
);

create table customers
(
	id int identity primary key,
	customerName varchar(100) not null,
	--customerUserName varchar(100) unique not null,
	customerEmail varchar(100) unique not null,
	customerPasswordHash varchar(200) not null,
	customerPhone varchar(10) not null,
	customerAddress varchar(200)
);

create table products
(
	id int identity primary key,
	prodName varchar(200) not null,
	prodPrice float not null,
	prodCategory int references categories(id),
	prodBrandName varchar(100) not null,
);
create table locations
(
	id int identity primary key,
	locName varchar(100) unique not null,
	locPhone varchar(10) unique not null,
	locAddress varchar(200) unique not null,
);

create table customerOrderLineItems 
(
	id int identity primary key,
	orderID int not null,
	prodID int references products(id),
	quantity int,
	prodPrice float,
);
create table storeOrderLineItems 
(
	id int identity primary key,
	orderID int,
	prodID int references products(id),
	quantity int,
	prodPrice float
);

create table inventory
(
	id int identity primary key,
	locID int unique not null references locations(id) on delete cascade
);
create table inventoryLineItems
(
	id int identity primary key,
	inventoryID int references inventory(id) on delete cascade,
	productID int references products(id),
	quantity int
);
create table managers
(
	id int identity primary key,
	managerName varchar(100) not null,
	managerEmail varchar(100) unique not null,
	managerPasswordHash varchar(200) not null,
	managerPhone varchar(10) not null,
	managerLocID int references locations(id),
);

create table customerOrderHistory
(
	id int identity primary key,
	locID int references locations(id),
	custID int references customers(id),
	orderDate date not null,
	orderID int unique not null,
	total float
);
create table customerCarts
(
	id int identity primary key,
	custID int references customers(id),
	locID int references locations(id),
	currentItemsID int
);
create table managersCarts
(
	id int identity primary key,
	managerID int unique not null references managers(id),
	locID int unique not null references locations(id),
	orderID int,
);
create table storeOrderHistory
(
	id int identity primary key,
	locID int references locations(id),
	managerID int references managers(id),
	orderDate date not null,
	orderID int,
	total float
);
--change table addresses from string
create table addresses
(
	id int identity primary key,
	street varchar 50,
	city varchar(50),
	aState varchar(20),
	postalCode varchar(5),
	customer int unique not null references customers(id) on delete cascade
);

--Add seed data
insert into categories (category) values
('Brakes'), ('Exhaust'), ('Intake'), ('Drivetrain'), 
('ForcedInduction'), ('Styling'), ('Engine'), ('Fueling'), 
('Suspension'), ('TuningAndGuages'), ('Wheels'), ('Accessories');

insert into customers (customerName, customerEmail, customerPasswordHash, customerPhone, customerAddress) values
('Richard Hakes', 'richard.hakes@revature.net', 'fuxy8zJoT6XdIvBuV6joPaHzrzBp6kKCm0wEYjE30zvD/J9J', '9876543210', '1234 Fake St. Clifton, Colorado, 81520'),
('RJ Hakes', 'rjhakes@yahoo.com', 'EyEpHUZauhRLeKzId\u002B2hJokIN484fYgD46hQW0cpsv89SCCg', '1234567890', '789 NoName Ave. Fruita, Colorado 81521');

insert into locations (locName, locPhone, locAddress) values
('North', '1593574562', '159 Park St. Denver, Colorado 45678'),
('South', '7531594789', '658 McRoady Rd. Austin, Texas 74125');

insert into products (prodName, prodPrice, prodCategory, prodBrandName) values
('Cobb Tuning LF Bypass valve | 15-21 Subaru WRX / 14-18 Forester XT (745670)', 325, 5, 'Cobb Tuning'),
('SuperPro Front Sway Bar Link Kit - Heavy Duty Adjustable | Multiple Subaru Fitments', 109.99, 9, 'SuperPro'),
('SuperPro Front and Rear Performance Sway Bar Upgrade Kit | 2015-2019 Subaru WRX', 649.99, 9, 'SuperPro');

insert into managers (managerName, managerEmail, managerPasswordHash, managerPhone, managerLocID) values
('Admin', 'admin@store.com', 'FWxyOU1CMPBKRxzcPdwUEOMqaniZI18EEC9OdM\u002BbJpybS4cs', '1596357485', '1');

insert into customerCarts (custID, locID, currentItemsID) values
(1, 2, 7), (1, 2, 5), (2,1,6);

insert into customerOrderLineItems (orderID, prodID, quantity, prodPrice) values
(1, 1, 1, 325), (1, 2, 2, 109.99), (1, 3, 1, 649.99), (2, 2, 1, 109.99), (3, 1, 1, 325), (4, 1, 1, 325), (4, 2, 2, 109.99), (5, 2, 1, 109.99), (6, 1, 1, 325);

insert into customerOrderHistory (locID, custID, orderDate, orderID, total) values
(1, 1, '2/22/2021', 1, 1194.97), (2, 1, '2/23/2021', 2, 109.99), (1,2,'2/25/2021', 3, 325), (1, 1, '2/26/2021', 4, 544.98);

insert into inventory (locID) values
(1);

insert into managersCarts (managerID, locID, orderID) values
(1, 1, 2);

insert into storeOrderLineItems (orderID, prodID, quantity, prodPrice) values
(1, 1, 20, 325), (1, 2, 20, 109.99), (1, 3, 20, 649.99);

insert into storeOrderHistory (locID, managerID, orderDate, orderID, total) values
(1, 1, '2/10/2021', 1, 21699.6);

insert into inventoryLineItems(inventoryID, productID, quantity) values
(1, 1, 18), (1, 2, 17), (1, 3, 19);

select * from categories;
select * from customers;
select * from locations;
select * from products;
select * from managers;
select * from customerCarts
select * from customerOrderLineItems
select * from customerOrderHistory
select * from inventory;
select * from managersCarts;
select * from storeOrderLineItems;
select * from storeOrderHistory;
select * from inventoryLineItems;


drop view v_CustomerOrderHistory
create view v_CustomerOrderHistory as
select coh1.orderDate, coh1.orderID, cust1.customerEmail, loc1.locName, p1.prodName, coli1.quantity, coli1.prodPrice, (coli1.quantity*coli1.prodPrice) as 'ItemizedTotal', coh1.total as 'CartTotal'
from customerOrderHistory coh1
inner join customers cust1 on cust1.id = coh1.custID
inner join locations loc1 on loc1.id = coh1.locID
inner join customerOrderLineItems coli1 on coli1.orderID = coh1.orderID
inner join products p1 on p1.id = coli1.prodID;

select * from v_CustomerOrderHistory;
select * from v_CustomerOrderHistory where customerEmail = 'richard.hakes@revature.net' and locName = 'North' order by orderID;
select distinct orderDate as 'Date', customerEmail as 'Customer Email', locName as 'Store Name', CartTotal as 'Cart Total', orderID 
from v_CustomerOrderHistory where customerEmail = 'richard.hakes@revature.net' order by orderID;
------------
------------
drop view mv_CustomerOrderHistory
create view mv_CustomerOrderHistory with schemabinding as
select coli1.id, coh1.orderDate, coh1.orderID, cust1.customerEmail, loc1.locName, p1.prodName, coli1.quantity, coli1.prodPrice, (coli1.quantity*coli1.prodPrice) as 'ItemizedTotal', coh1.total as 'CartTotal'
from dbo.customerOrderHistory coh1
inner join dbo.customers cust1 on cust1.id = coh1.custID
inner join dbo.locations loc1 on loc1.id = coh1.locID
inner join dbo.customerOrderLineItems coli1 on coli1.orderID = coh1.orderID
inner join dbo.products p1 on p1.id = coli1.prodID;

create unique clustered index ix_mv_CustomerOrderHistory_id on mv_CustomerOrderHistory
(
	id
)

create index ix_mv_CustomerOrderHistory_orderID on mv_CustomerOrderHistory
(
	orderID
)

select * from mv_CustomerOrderHistory;
select * from mv_CustomerOrderHistory with(index(id)) where customerEmail = 'richard.hakes@revature.net' and locName = 'North' order by orderID;
select distinct orderDate as 'Date', customerEmail as 'Customer Email', locName as 'Store Name', CartTotal as 'Cart Total', orderID 
from v_CustomerOrderHistory with(index(orderID)) where customerEmail = 'richard.hakes@revature.net' order by orderID;