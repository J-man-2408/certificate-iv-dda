-- Session 5

DROP DATABASE IF EXISTS class_work;
CREATE DATABASE class_work;


USE class_work; 

CREATE TABLE if NOT EXISTS students (
	id BIGINT PRIMARY KEY AUTO_INCREMENT,
	student_number VARCHAR(255),
	
	first_name VARCHAR(255),
	last_name VARCHAR(255),
	address VARCHAR(255)
);


CREATE TABLE if NOT EXISTS classes (
	id BIGINT PRIMARY KEY AUTO_INCREMENT,
	`name` VARCHAR(255),
	`code` VARCHAR(255)
);


CREATE TABLE if NOT EXISTS enrolments (
	id BIGINT PRIMARY KEY AUTO_INCREMENT,
	class_id BIGINT NOT NULL,
	student_id BIGINT NOT NULL,
	FOREIGN KEY(student_id) REFERENCES students(id)
);



DESCRIBE students;
DESCRIBE classes;
DESCRIBE enrolments;


INSERT INTO students 
	(student_number, first_name, last_name, address)
VALUES
	('J123', 'Mila', 'Maxwell', 'The plain of spirits'),
	('2032', 'Jude', 'Mathis', 'Fennmont'),
	('0123', 'Lloyd','Irving', 'Iselia');

 

INSERT INTO classes
 (`name`, `code`)
VALUES

	('Version Control and Object Oriented', 'RIoT'),
	('Data Driven Applications', 'DDA');
	

SELECT * FROM students;
SELECT * FROM classes;	

INSERT INTO enrolments
	(student_id, class_id)
VALUES
	(1,1),
	(1,2),
	(2,1),
	(3,1);
 

SELECT * FROM students;
SELECT * FROM classes;
SELECT * FROM enrolments;    