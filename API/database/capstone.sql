USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END
GO -- added this GO - not sure if it's needed

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);
--create recipes table
CREATE TABLE recipes (
	recipe_id INT IDENTITY(1,1) NOT NULL,
	--user_id INT NULL,
	category VARCHAR(50) NULL,
	recipe_name VARCHAR(200) NOT NULL,
	type VARCHAR(100) NOT NULL,
	instructions VARCHAR(2000) NOT NULL,

	CONSTRAINT PK_recipes PRIMARY KEY (recipe_id),
	--CONSTRAINT FK_recipes_users FOREIGN KEY (user_id) REFERENCES users(user_id),
);
--create recipes_users table
CREATE TABLE recipes_users (
	recipe_id INT IDENTITY (1,1) NOT NULL,
	user_id INT NOT NULL,
	CONSTRAINT PK_recipes_users PRIMARY KEY (recipe_id, user_id),
	CONSTRAINT FK_recipes_users_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_recipes_users_users FOREIGN KEY (user_id) REFERENCES users(user_id)
);
--create ingredients table
CREATE TABLE ingredients (
	ingredient_id INT IDENTITY (1,1) NOT NULL,
	name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_ingredients PRIMARY KEY (ingredient_id)
);
--create table to connect recipes and ingredients
CREATE TABLE recipe_ingredients (
	recipe_id INT NOT NULL,
	ingredient_id INT NOT NULL,
	amount INT NOT NULL,
	unit VARCHAR(100) NOT NULL,
	CONSTRAINT PK_recipe_ingredients PRIMARY KEY (recipe_id, ingredient_id),
	CONSTRAINT FK_recipe_ingredients_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_recipe_ingredients_users FOREIGN KEY (ingredient_id) REFERENCES ingredients(ingredient_id)
);
--create category table
CREATE TABLE category (
	category_id INT IDENTITY (1,1) NOT NULL,
	category_name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_category PRIMARY KEY (category_id)
);
--create meal_plan table
CREATE TABLE meal_plan (
	meal_plan_id INT IDENTITY (1,1) NOT NULL,
	recipe_id INT NOT NULL,
	user_id INT NOT NULL,
	name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_meal_plan PRIMARY KEY (meal_plan_id),
	CONSTRAINT FK_meal_plan_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_meal_plan_users FOREIGN KEY (user_id) REFERENCES users(user_id)
);
--create grocery_list table
CREATE TABLE grocery_list (
	grocery_list_id INT IDENTITY (1,1) NOT NULL,
	user_id INT NOT NULL,
	name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_grocery_list PRIMARY KEY (grocery_list_id),
	CONSTRAINT FK_grocery_list FOREIGN KEY (user_id) REFERENCES users(user_id)
);

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--GO
INSERT INTO category (category_name) VALUES ('Vegetarian');
INSERT INTO category (category_name) VALUES ('Easy');

INSERT INTO ingredients (name)
VALUES ('Chicken'),
('Rice'),
('Garbanzo Beans'),
('Green Beans'),
('Butternut Squash'),
('Salmon'),
('Shredded Mexican Blend Cheese'),
('Shredded Cheddar Cheese'),
('Potato'),
('Onion'),
('Tomato'),
('Red Enchilada Sauce'),
('Flour Tortilla'),
('Ground Beef'),
('Tomato'),
('Penne Pasta'),
('Broccoli'),
('Alfredo Sauce'),
('Lasagna Noodles'),
('Ricotta Cheese'),
('Pasta Sauce'),
('Mixed Veggies'),
('Mozzarella Cheese');

INSERT INTO recipes (category, recipe_name, type, instructions)
VALUES ('Easy', 'Easy Cheesy Ground Beef Enchiladas','Main Meal','Heat oven to 375°. Brown ground beef until thoroughly cooked; drain. Stir in 3/4 cup enchilada sauce and one cup of cheese.
Spoon meat mixture onto tortillas roll-up and place seam-side down in lightly greased baking dish. Pour remaining enchilada sauce over top. Cover with remaining cheese. Bake for 15 to 20 minutes or until cheese melts. Serve with yellow rice and refried beans. Garnish with sour cream, salsa, and lettuce.');
INSERT INTO recipes (category, recipe_name, type, instructions)
VALUES ('Vegetarian', 'Vegetable Lasagna', 'Main Meal','Preheat oven to 350°F. Spread a thin layer of sauce on the bottom of a 9"x13" casserole. Cover with a layer of noodles (3 or 4 noodles should be enough). Place ricotta in a bowl and add about 1/4 cup of water, stirring until blended. Spread 1/3 of this mixture over the pasta (you can use a cake spatula).
Spread 1/3 of the remaining pasta sauce over the cheese. Spread 1/3 of the vegetables over the sauce. Sprinkle 1/3 of the mozzarella over the veggies. Repeat twice starting with the noodles and ending with the mozzarella. Cover and bake until the noodles are tender (35 to 40 minutes). Remove cover and bake 5 minutes until cheese starts to become golden. Remove from oven and allow to stand for 5 minutes before cutting into squares.');

INSERT INTO recipe_ingredients (recipe_id, ingredient_id,amount,unit)
VALUES
	(1,14,1,'lb'),
	(1,12,1,'10 oz can'),
	(1,7,8,'oz'),
	(1,8,8,'oz'),
	(1,13,12,'6"');
INSERT INTO recipe_ingredients (recipe_id, ingredient_id,amount,unit)
VALUES
	(2,21,1,'28 oz jar'),
	(2,19,8,'oz'),
	(2,20,15,'oz'),
	(2,22,3,'cups'),
	(2,23,8,'oz');

