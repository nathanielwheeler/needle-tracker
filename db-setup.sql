USE needletracker

CREATE TABLE users (
	id VARCHAR(255) NOT NULL,
	username VARCHAR(255) NOT NULL,
	email VARCHAR(255) NOT NULL,
	hash VARCHAR(255) NOT NULL,
	PRIMARY KEY (id),
	UNIQUE KEY email (email)
);

CREATE TABLE entries (
	id int NOT NULL AUTO_INCREMENT,
	timestamp VARCHAR(255) NOT NULL,
	needlesIn INT DEFAULT 0,
	needlesOut INT DEFAULT 0,
	isVoid TINYINT DEFAULT 0,
	userId VARCHAR(255),
	FOREIGN KEY (userId)
		REFERENCES users(id),
	PRIMARY KEY (id)
);