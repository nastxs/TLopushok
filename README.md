create table Material(ID int primary key,
					 name varchar(200)); 
					 
create table Type(ID int primary key,
					 name varchar(200)); 
					 
create table Product(ID int primary key,
					 name varchar(200),
					image varchar(200),
					price int,
					articul varchar(20),
					TypeID int references Type(ID) on delete cascade on update cascade,
					MaterialID int references Material(ID) on delete cascade on update cascade);
					
					
create or replace view myProduct as 
select Product.name as name, image as image, price as price, articul as articul, 
       Type.name as type, Material.name as material
from Material, Type, Product
where Type.ID = Product.TypeID and Material.ID = Product.MaterialID;
