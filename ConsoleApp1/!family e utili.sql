select hacker_id, name, score from hackers h, (select hacker_id from submissions) s where h.hacker_id = s.hacker_id and s.score > 0 order by s.score desc;

drop table family;
drop table children;
drop table schools;

create table children (
  id int not null primary key,
  name varchar(10) not null,
  age int,
  birth date,
  school_id int
);

CREATE TABLE FAMILY (
  id serial primary key not null,
  dad_name varchar(10),
  dad_age int,
  child_id int references children(id)
);

create table schools (
	id serial not null,
	name varchar(20)
);

insert into children values (1, 'fia', 8, '2013-07-01', 1), (2, 'alex', 12, '04/30/2018', 2);
insert into family values (1, 'vix', 50, 1);
insert into family values (2, 'mom', 45, 1);
delete from family where dad_name = 'mom';
update children set name='Sofia' where id =1 ;
alter table children add fav_color varchar(15);
alter table children alter column name type varchar(15);
update children set fav_color='red' where name='alex';
update children set fav_color='pink' where name='Sofia';
insert into schools values (1, 'prairie'), (2, 'liberty');

select * from children where name like 'S%';
-- ilike      case sensitive
-- % represents zero, one, or multiple characters.
-- _ represents one single character.
-- is null, not null, not like, not ilike, not between, not in
-- SELECT * FROM customers WHERE customer_id IN (SELECT customer_id FROM orders);
-- between 8 and 10

select * from family;
SELECT COUNT(DISTINCT name) FROM children;
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

