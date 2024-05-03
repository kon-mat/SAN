DROP TABLE item;
DROP TABLE location;

CREATE TABLE location (
    id SERIAL PRIMARY KEY
	, loc_row INTEGER NOT NULL
    , loc_column INTEGER NOT NULL
	, loc_shelf INTEGER NOT NULL
);

CREATE TABLE item (
    id SERIAL PRIMARY KEY
	, EAN VARCHAR(10) NOT NULL
	, brand VARCHAR(100) DEFAULT 'Unknown'
	, size VARCHAR(5) NOT NULL
	, color VARCHAR(20) NOT NULL
	, locationId INTEGER NOT NULL
	, FOREIGN KEY (locationId) REFERENCES location(id)
);

INSERT INTO location (loc_row, loc_column, loc_shelf)
VALUES (1, 1, 1);

INSERT INTO location (loc_row, loc_column, loc_shelf)
VALUES (1, 2, 5);

INSERT INTO location (loc_row, loc_column, loc_shelf)
VALUES (2, 3, 4);

INSERT INTO location (loc_row, loc_column, loc_shelf)
VALUES (3, 1, 3);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('5463214851', 'Zara', 'L', 'black', 1);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('5566837796', 'Nike', 'S', 'green', 2);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('7123938538', 'Louis Vuitton', 'M', 'grey', 3);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('9567605227', 'Gucci', 'XXL', 'blue', 4);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('2139173320', 'Adidas', 'XS', 'red', 1);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('4111298669', 'H&M', 'S', 'yellow', 2);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('6853843787', 'Cartier', 'XL', 'violet', 3);

INSERT INTO item (EAN, brand, size, color, locationId)
VALUES ('4388452479', 'Dior', 'M', 'pink', 4);
