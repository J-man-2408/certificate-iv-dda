DROP USER IF EXISTS 'sakila_app_user'@'localhost';
CREATE USER 'sakila_app_user'@'localhost' IDENTIFIED BY "Hunter2!";
GRANT CREATE, ALTER, INSERT, UPDATE, DELETE, SELECT, REFERENCES, RELOAD
ON *.*
TO 'sakila_app_user'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;


UPDATE sakila.film
SET release_year = (SELECT FLOOR(RAND()*70 + 1955))
WHERE release_year IS NOT NULL;
