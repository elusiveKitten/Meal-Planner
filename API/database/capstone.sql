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
--create recipes table - nb
CREATE TABLE recipes (
	recipe_id INT IDENTITY(1,1) NOT NULL,
	user_id INT NOT NULL,
	recipe_name VARCHAR(200) NOT NULL,
	directions VARCHAR(2000) NOT NULL,

	CONSTRAINT PK_recipes PRIMARY KEY (recipe_id),
	CONSTRAINT fk_recipes FOREIGN KEY (user_id) REFERENCES users(user_id)
);
--create recipes_users table - nb
CREATE TABLE recipes_users (
	recipe_id INT IDENTITY (1,1) NOT NULL,
	user_id INT NOT NULL,
	CONSTRAINT PK_recipes_users PRIMARY KEY (recipe_id, user_id),
	CONSTRAINT FK_recipes_users_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_recipes_users_users FOREIGN KEY (user_id) REFERENCES users(user_id)
);
--create ingredients table - nb
CREATE TABLE ingredients (
	ingredient_id INT IDENTITY (1,1) NOT NULL,
	name VARCHAR(100) NOT NULL,
	category VARCHAR(100) NULL,
	CONSTRAINT PK_ingredients PRIMARY KEY (ingredient_id)
);
CREATE TABLE recipe_ingredients (
	recipe_id INT NOT NULL,
	ingredient_id INT NOT NULL,
	amount INT NOT NULL,
	unit VARCHAR(50) NOT NULL,
	CONSTRAINT PK_recipe_ingredients PRIMARY KEY (recipe_id, ingredient_id),
	CONSTRAINT FK_recipes_ingredients_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_recipes_ingredients_users FOREIGN KEY (ingredient_id) REFERENCES ingredients(ingredient_id)
);
CREATE TABLE category (
	category_id INT IDENTITY (1,1) NOT NULL,
	category_name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_category PRIMARY KEY (category_id)
);
CREATE TABLE meal_plan (
	meal_plan_id INT IDENTITY (1,1) NOT NULL,
	recipe_id INT NOT NULL,
	user_id INT NOT NULL,
	name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_meal_plan PRIMARY KEY (meal_plan_id),
	CONSTRAINT FK_meal_plan_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_meal_plan_users FOREIGN KEY (user_id) REFERENCES users(user_id)
);
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
INSERT INTO category (category_name) VALUES ('Keto');
INSERT INTO category (category_name) VALUES ('Gluten-Free');
