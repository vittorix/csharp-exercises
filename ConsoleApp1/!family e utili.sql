select hacker_id, name, score from hackers h, (select hacker_id from submissions) s 
  where h.hacker_id = s.hacker_id and s.score > 0 order by s.score desc;

select countrycode, count(countryCode) count from world.city where population > 1000000 
group by countryCode having count > 10 order by count desc;

SELECT SupplierName FROM Suppliers WHERE EXISTS 
	(SELECT ProductName FROM Products WHERE Products.SupplierID = Suppliers.supplierID AND Price < 20);
SELECT ProductName FROM Products WHERE ProductID = ANY -- any returns true/false, selects multiple rows
  (SELECT ProductID FROM OrderDetails WHERE Quantity = 10); -- returns multiple records
SELECT ProductName FROM Products WHERE ProductID = ALL --  used with SELECT, and WHERE or HAVING
  (SELECT ProductID FROM OrderDetails WHERE Quantity = 10); -- returns multiple records
select substring(name, 1, 3), name from world.city; -- selects the first 3 letters
select substring(name, 3), name from world.city; -- selects from the 3rd letter to the end
select replace(name, 'dam', 'xxx'), name from world.city;
SELECT article, dealer, price FROM shop s1 -- For each article, find dealer(s) w most expensive price
	WHERE price=(SELECT MAX(s2.price) FROM shop s2 WHERE s1.article = s2.article) ORDER BY article;
    
SELECT @min_price:=MIN(price), @max_price:=MAX(price) FROM shop;
SELECT * FROM shop WHERE price=@min_price OR price=@max_price;

drop table orders; drop table persons;
create table persons (name varchar (20), personid int PRIMARY KEY not null);
CREATE TABLE Orders (OrderID int NOT NULL, OrderNumber int NOT NULL, 
	PersonID int PRIMARY KEY, FOREIGN KEY (PersonID) REFERENCES Persons(PersonID));

select rpad('Ciao', 10, 'XX'); -- CiaoXXXXXX
select lower('CiaoVix'); -- ciaovix   see upper()
-- LTRIM(str)	Remove leading spaces, RTRIM(str)
-- REPLACE, REVERSE(s), RIGHT(str, lenn), SPACE(n)
-- SUBSTRING(str,pos), SUBSTRING(str FROM pos), SUBSTRING(str,pos,len), SUBSTRING(str FROM pos FOR len)
-- SUBSTRING('Quadratically', 5); 'ratically
-- SUBSTRING('Quadratically', 5, 6); 'ratica'
-- SUBSTRING('Sakila', -3); 'ila'
-- SUBSTRING('Sakila', -5, 3); 'aki'
-- SUBSTRING('Sakila' FROM -4 FOR 2); 'ki'

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
update children set name='Sofia' where id =1 ;
alter table children add fav_color varchar(15);
alter table children modify name varchar(15); -- change column type
update children set fav_color='red' where name='alex';
update children set fav_color='pink' where name='Sofia';
insert into schools(name) values ('prairie'), ('liberty');

select * from children where name like 'S%';
-- ilike      case sensitive
-- % represents zero, one, or multiple characters.
-- _ represents one single character.
-- is null, not null, not like, not ilike, not between, not in
-- SELECT * FROM customers WHERE customer_id IN (SELECT customer_id FROM orders);
-- between 8 and 10

select * from family;
SELECT COUNT(DISTINCT name) FROM children;

-- SELECT DATE("2017-06-15");
-- SELECT DATE("2017-06-15 09:34:21");
-- The DATE type is used for values with a date part but no time part. MySQL retrieves and displays DATE values in 'YYYY-MM-DD' format. The supported range is '1000-01-01' to '9999-12-31'.
-- The DATETIME type is used for values that contain both date and time parts. MySQL retrieves and displays DATETIME values in 'YYYY-MM-DD hh:mm:ss' format. The supported range is '1000-01-01 00:00:00' to '9999-12-31 23:59:59'.
-- The TIMESTAMP data type is used for values that contain both date and time parts. TIMESTAMP has a range of '1970-01-01 00:00:01' UTC to '2038-01-19 03:14:07' UTC.


-- SELECT * FROM customers LIMIT 20 OFFSET 40; -- 20 rows starting from 41st;
-- SELECT MIN(price) FROM products; or MAX
-- SELECT SUM(quantity) FROM order_details;
-- SELECT AVG(price)::NUMERIC(10,2) FROM products;
-- SELECT CONCAT(first_name, ' ', last_name) AS Name FROM test.student -- Concatenates the values

-- SELECT COUNT(customer_id), country FROM customers GROUP BY country;
-- SELECT COUNT(customer_id), country FROM customers GROUP BY country HAVING COUNT(customer_id) > 5;
-- SELECT customers.customer_name FROM customers 
-- 	WHERE EXISTS (SELECT order_id FROM orders WHERE customer_id = customers.customer_id); (anche: NOT EXIST)
-- SELECT product_name FROM products WHERE product_id = 
--   ANY (SELECT product_id FROM order_details WHERE quantity > 120); (ANY usato perche' c'e' WHERE >)
-- SELECT product_name FROM products WHERE product_id = 
--   ALL (SELECT product_id FROM order_details WHERE quantity > 10); all of them must satisfy the condition

-- SELECT product_name, 
-- 	CASE WHEN price < 10 THEN 'Low price product' WHEN price > 50 THEN 'High price product'
-- 	ELSE 'Normal product'
-- 	END
-- FROM products;

select distinct children.name, children.age, children.fav_color as color, birth, 
	dad_name "dad name", dad_age || 'yo' as "dad age"
	from children, family 
	order by children.age desc;

select children.name "child name", schools.name
	from children inner join schools on schools.id = children.school_id;
-- INNER JOIN: matching values in both tables
-- LEFT JOIN: all records from left table, and matched records from the right table
-- RIGHT JOIN: all records from the right table, and matched records from the left table
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
-- select * from (select max(months * salary), count(name) from employee group by (months * salary) order by (months * salary) desc )  where rownum <= 1 ;

-- SELECT column|expression|group_function(column|expression [alias]),…}
-- FROM table
-- [WHERE condition(s)]
-- [GROUP BY {col(s)|expr}]
-- [HAVING group_condition(s)]
-- [ORDER BY {col(s)|expr|numeric_pos} [ASC|DESC] [NULLS FIRST|LAST]];

-- SELECT * FROM v$version WHERE banner LIKE 'Oracle%'; 
-- Oracle Database 11g Express Edition Release 11.2.0.2.0 - 64bit Production

-- select continent, trunc(avg(city.population)) from city, country where city.countrycode = code group by continent;
-- trunc rounds down to integer

