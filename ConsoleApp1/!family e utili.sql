-- SELECT column|expression|group_function(column|expression [alias]),…}
-- FROM table
-- [WHERE condition(s)]
-- [GROUP BY {col(s)|expr}]
-- [HAVING group_condition(s)]
-- [ORDER BY {col(s)|expr|numeric_pos} [ASC|DESC] [NULLS FIRST|LAST]];
select hacker_id, name, score from hackers h, (select hacker_id from submissions) s 
  where h.hacker_id = s.hacker_id and s.score > 0 order by s.score desc;

select countrycode, count(countryCode) count from world.city where population > 1000000 
group by countryCode having count > 10 order by count desc;

-- A subquery can return: a value, a row, a column, or a table
SELECT SupplierName FROM Suppliers WHERE EXISTS 
	(SELECT ProductName FROM Products WHERE Products.SupplierID = Suppliers.supplierID AND Price < 20);
-- What kind of store is present in one or more cities?
SELECT DISTINCT store_type FROM stores
  WHERE EXISTS (SELECT * FROM cities_stores WHERE cities_stores.store_type = stores.store_type);
-- What kind of store is present in no cities?
SELECT DISTINCT store_type FROM stores
  WHERE NOT EXISTS (SELECT * FROM cities_stores WHERE cities_stores.store_type = stores.store_type);

-- When used with a subquery, the word IN is an alias for = ANY
SELECT s1 FROM t1 WHERE s1 = ANY (SELECT s1 FROM t2); -- same as:
SELECT s1 FROM t1 WHERE s1 IN    (SELECT s1 FROM t2);
SELECT ProductName FROM Products WHERE ProductID = ANY -- any returns true/false, selects multiple rows
  (SELECT ProductID FROM OrderDetails WHERE Quantity = 10); -- returns multiple records
SELECT ProductName FROM Products WHERE ProductID = ALL --  used with SELECT, and WHERE or HAVING
  (SELECT ProductID FROM OrderDetails WHERE Quantity = 10); -- returns multiple records
select substring(name, 1, 3), name from world.city; -- selects the first 3 letters
select substring(name, 3), name from world.city; -- selects from the 3rd letter to the end
select replace(name, 'dam', 'xxx'), name from world.city;
SELECT article, dealer, price FROM shop s1 -- For each article, find dealer(s) w most expensive price
	WHERE price=(SELECT MAX(s2.price) FROM shop s2 WHERE s1.article = s2.article) ORDER BY article;
    
SELECT @min_price:=MIN(price), @max_price:=MAX(price) FROM shop; -- creates variables
SELECT * FROM shop WHERE price=@min_price OR price=@max_price;
set @number = 10;

drop table orders if exists; drop table persons;
create table persons (name varchar (20), personid int PRIMARY KEY not null);
CREATE TABLE Orders (OrderID int NOT NULL, OrderNumber int NOT NULL, 
	PersonID int PRIMARY KEY, FOREIGN KEY (PersonID) REFERENCES Persons(PersonID));

select rpad('Ciao', 10, 'XX'); -- CiaoXXXXXX
select lower('CiaoVix'); -- ciaovix   see upper()
-- LTRIM(str)	Remove leading spaces, RTRIM(str)
-- REPLACE, REVERSE(s), RIGHT(str, len), SPACE(n) 
SELECT RIGHT("12345", 2);
select concat('<', space(5), '>'); -- <     >
SELECT SUBSTRING('123456' FROM 4); -- 456
-- SUBSTRING(str,pos,len) SUBSTRING('Quadratically', 5, 6); 'ratica'
-- SUBSTRING(str FROM pos FOR len) SUBSTRING('Sakila' FROM -4 FOR 2); 'ki'
-- SUBSTRING(str,pos) SUBSTRING('Quadratically', 5); 'ratically
-- SUBSTRING('Sakila', -3); 'ila'
-- SUBSTRING('Sakila', -5, 3); 'aki'

drop table if exists family; drop table if exists children; drop table if exists schools;

create table children (
  id int not null primary key,
  name varchar(10) not null,
  age int  not null,
  birth date not null,
  school_id int
);

CREATE TABLE FAMILY (
  id serial primary key not null,
  dad_name varchar(10),
  dad_age int,
  child_id int references children(id)
);

create table schools (
	id int AUTO_INCREMENT primary key ,
	name varchar(20)
);

insert into children values (1, 'fia', 8, '2015-07-05', 1);
delete from children where id = 1;
delete from children;
insert into children values (1, 'fia', 8, '2015-07-05', 1), (2, 'alex', 12, '2012-09-22', 2);
insert into family values (1, 'vix', 50, 1);
insert into family values (2, 'mom', 45, 1);
-- delete from family where dad_name = 'mom';
update children set name='myphia' where id =1 ;
alter table children add fav_color varchar(15);
alter table children modify name varchar(15); -- change column type
update children set fav_color='red' where name='alex';
update children set fav_color='pink' where name='myphia';
insert into schools(name) values ('prairie'), ('liberty'), ('discover');

select * from children where name like 'S%';
SELECT COUNT(DISTINCT name) FROM children;
update children set name = concat(name, ' Pat');
SELECT name, COUNT(DISTINCT name) FROM children group by name;
select * from children, schools where children.school_id = schools.id;
select * from children join schools on children.school_id = schools.id; -- where also works instead of on
select * from children, (select * from schools) s where children.school_id = s.id;
-- ilike      case sensitive
-- % represents zero, one, or multiple characters.
-- _ represents one single character.
-- is null, not null, not like, not ilike, not between, not in
-- SELECT * FROM customers WHERE customer_id IN (SELECT customer_id FROM orders);
-- between 8 and 10

-- SELECT DATE("2017-06-15");
SELECT CAST("2017-08-29" AS DATE);
-- SELECT DATE("2017-06-15 09:34:21");
-- The DATE type is used for values with a date part but no time part. MySQL retrieves and displays DATE values in 'YYYY-MM-DD' format. The supported range is '1000-01-01' to '9999-12-31'.
-- The DATETIME type is used for values that contain both date and time parts. MySQL retrieves and displays DATETIME values in 'YYYY-MM-DD hh:mm:ss' format. The supported range is '1000-01-01 00:00:00' to '9999-12-31 23:59:59'.
-- The TIMESTAMP data type is used for values that contain both date and time parts. TIMESTAMP has a range of '1970-01-01 00:00:01' UTC to '2038-01-19 03:14:07' UTC.

select TRUNCATE(0.16645, 2); -- 0.16 decimals
select ROUND(0.166, 2); -- 0.17
select ROUND(0.164, 2); -- 0.16
select avg(city.population) from city; -- 350468.2236
select floor(avg(city.population)) from city; -- 350468
select round(avg(city.population)) from city; -- 350468
select cast(17.800000 as dec(3,1)); -- 17.8

-- SELECT * FROM city LIMIT 20 OFFSET 40; -- 20 rows starting from 41st;
-- SELECT MIN(price) or MAX, SUM, AVG
-- SELECT CONCAT(first_name, ' ', last_name) AS Name FROM test.student -- Concatenates the values
-- SELECT COUNT(customer_id), country FROM customers GROUP BY country; -- anche COUNT(distinct 
-- SELECT COUNT(customer_id), country FROM customers GROUP BY country HAVING COUNT(customer_id) > 5;
-- SELECT customers.customer_name FROM customers 
-- 	WHERE EXISTS (SELECT order_id FROM orders WHERE customer_id = customers.customer_id); (anche: NOT EXIST)
-- SELECT product_name FROM products WHERE product_id = 
--   ANY (SELECT product_id FROM order_details WHERE quantity > 120); (ANY usato perche' c'e' WHERE >)
-- SELECT product_name FROM products WHERE product_id = 
--   ALL (SELECT product_id FROM order_details WHERE quantity > 10); all of them must satisfy the condition

select distinct children.name, children.age, children.fav_color as color, birth, 
	dad_name "dad name", concat(dad_age, 'yo') as "dad age"
	from children, family 
	order by children.age desc;
-- name, age, color, birth, dad name, dad age
-- 'alex Pat', '12', 'red', '2012-09-22', 'vix', '50yo'
-- 'myphia Pat', '8', 'pink', '2015-07-05', 'vix', '50yo'

-- generates a table with 8 colums (duplicating the columns) and 2 rows
select * from children c1 join (select * from children order by id desc) c2 on c1.id = c2.school_id;
-- generates 2 colums and 3 rows, the 3rd is [null, discover] 
select children.name "child name", schools.name
	from children right join schools on schools.id = children.school_id;

-- INNER JOIN: matching values in both tables
-- LEFT JOIN: all records from left table, and matched records from the right table
-- RIGHT JOIN: all records from the right table, and matched records from the left table
select children.name "child name", schools.name -- 9 records di cui due dalla children
	from children right join schools on schools.id = children.school_id; 
-- FULL JOIN: Returns all records when there is a match in either left or right table
-- CROSS JOIN matches ALL records from the "left" table with EACH record from the "right" table
-- UNION operator is used to combine the result-set of two or more queries. UNION ALL returns duplicates

-- select s, replace(s, '!', '') as res from removeexclamationmarks

-- HACKERRANK
-- select count(city) - count(distinct city) from station;
-- Select City, LENGTH (City) From Station ORDER By LENGTH (City) DESC, City LIMIT 1;
-- Select City, LENGTH (City) From Station ORDER By LENGTH (City) ASC, City LIMIT 1;
-- select distinct city from station where substring(city, 1, 1) in ('a', 'e', 'i', 'o', 'u');
-- substring starts from 1!!!
-- select case when a is null then 'A IS NULL' else '!!!ERROR!!!' end from triangles;
-- select occupation, count(occupation) from occupations group by occupation;
-- SELECT CAST (miles AS INT) FROM Flights
-- select * from (select max(months * salary), count(name) from employee 
--       group by (months * salary) order by (months * salary) desc )  where rownum <= 1 ;

-- SELECT * FROM v$version WHERE banner LIKE 'Oracle%'; 
-- Oracle Database 11g Express Edition Release 11.2.0.2.0 - 64bit Production

-- select continent, trunc(avg(city.population)) from city, country where city.countrycode = code group by continent;
-- trunc rounds down to integer

SELECT * FROM t1
  WHERE (col1,col2) = (SELECT col3, col4 FROM t2 WHERE id = 10);
SELECT * FROM t1
  WHERE ROW(col1,col2) = (SELECT col3, col4 FROM t2 WHERE id = 10);

-- query_expression_body UNION [ALL | DISTINCT] query_block
--     [UNION [ALL | DISTINCT] query_expression_body]
--     [...]

-- triangle 
create table table_10_rows (id int);
insert into table_10_rows values (1), (2), (3), (4), (5), (6), (7), (8), (9), (10));
SET @NUMBER = 10;
SELECT REPEAT('* ', @NUMBER := @NUMBER - 1) as upside_tree
    FROM table_10_rows; 
SET @NUMBER = 0;
SELECT REPEAT('* ', @NUMBER := @NUMBER + 1) as tree
    FROM table_10_rows; 

SET @NUMBER = 10;
SELECT REPEAT('* ', @NUMBER := @NUMBER - 1)
    FROM information_schema.tables 
LIMIT 10;    
    
select '*' union select '**' union select '***'    

-- 2 columns name ant city_type and one row for each city
SELECT name, 
	CASE WHEN population > 10000 THEN 'Big city' 
		 WHEN population < 10000 THEN 'Small town'
		 ELSE 'Normal city'
	END as city_type
FROM city;

-- 2 rows: Big City and Small Towwn 
SELECT (select 
			CASE WHEN population > 10000 THEN 'Big city' 
				 WHEN population < 10000 THEN 'Small town'
				 ELSE 'Normal city'
			END ) as type
FROM city
group by type;

