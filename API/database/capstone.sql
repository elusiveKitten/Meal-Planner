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
	recipe_name VARCHAR(200) NOT NULL,
	calories VARCHAR(100) NULL,
	instructions VARCHAR(2000) NOT NULL,
	CONSTRAINT PK_recipes PRIMARY KEY (recipe_id),

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
	ingredient_name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_ingredients PRIMARY KEY (ingredient_id),
	UNIQUE(ingredient_name)
);
--create table to connect recipes and ingredients
CREATE TABLE recipe_ingredients (
	recipe_id INT NOT NULL,
	ingredient_id INT NOT NULL,
	amount VARCHAR(50) NOT NULL,
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
--relational category-recipes
CREATE TABLE recipe_category(
	recipe_id INT NOT NULL,
	category_id INT NOT NULL,
	CONSTRAINT FK_recipe_category_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_recipe_category_category FOREIGN KEY (category_id) REFERENCES category(category_id)
);
--create meal_plan table
CREATE TABLE meal_plan (
	meal_plan_id INT IDENTITY (1,1) NOT NULL,
	meal_plan_name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_meal_plan PRIMARY KEY (meal_plan_id),
);
--Meal_Plan_User
CREATE TABLE meal_plan_user(
	meal_plan_id INT NOT NULL,
	user_id INT NOT NULL,
	CONSTRAINT FK_meal_plan_user_meal_plan FOREIGN KEY (meal_plan_id) REFERENCES meal_plan(meal_plan_id),
	CONSTRAINT FK_meal_plan_user_users FOREIGN KEY (user_id) REFERENCES users(user_id)
);
CREATE TABLE meal_plan_recipe(
	meal_plan_id INT NOT NULL,
	recipe_id INT NOT NULL,
	CONSTRAINT FK_meal_plan_recipe_meal_plan FOREIGN KEY (meal_plan_id) REFERENCES meal_plan(meal_plan_id),
	CONSTRAINT FK_meal_plan_recipe_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id)
);
CREATE TABLE dish_type(
	dish_type_id INT IDENTITY(1,1) NOT NULL,
	dish_type_name VARCHAR(100) NOT NULL,
	CONSTRAINT PK_dish_type PRIMARY KEY (dish_type_id)
);
CREATE TABLE recipe_dish_type(
	dish_type_id INT NOT NULL,
	recipe_id INT NOT NULL,
	CONSTRAINT FK_recipe_dish_type_dish_type FOREIGN KEY (dish_type_id) REFERENCES dish_type(dish_type_id),
	CONSTRAINT FK_recipe_dish_type_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id)
);

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--GO
INSERT INTO category (category_name) VALUES ('Vegetarian');
INSERT INTO category (category_name) VALUES ('Easy');

--Insert Users

INSERT INTO ingredients (ingredient_name)
VALUES
('Basil Leaf'),
('Chicken'),
('Rice'),
('Garbanzo Beans'),
('Green Beans'),
('Black Pepper'),
('Olive Oil'),
('Kosher Salt'),
('Butter'),
('Flour'),
('Milk'),
('Cheddar Cheese'),
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
('Penne Pasta'),
('Broccoli'),
('Alfredo Sauce'),
('Lasagna Noodles'),
('Ricotta Cheese'),
('Pasta Sauce'),
('Mixed Veggies'),
('Mozzarella Cheese'),
('Elbow Macaroni'),
('Salt');

--add recipes
INSERT INTO recipes (recipe_name, calories, instructions)
VALUES ('Easy Cheesy Ground Beef Enchiladas', '517' , 'Heat oven to 375°. Brown ground beef until thoroughly cooked; drain. Stir in 3/4 cup enchilada sauce and one cup of cheese.
Spoon meat mixture onto tortillas roll-up and place seam-side down in lightly greased baking dish. Pour remaining enchilada sauce over top. Cover with remaining cheese. Bake for 15 to 20 minutes or until cheese melts. Serve with yellow rice and refried beans. Garnish with sour cream, salsa, and lettuce.');
INSERT INTO recipes (recipe_name, calories, instructions)
VALUES ('Vegetable Lasagna', '330', 'Preheat oven to 350°F. Spread a thin layer of sauce on the bottom of a 9"x13" casserole. Cover with a layer of noodles (3 or 4 noodles should be enough). Place ricotta in a bowl and add about 1/4 cup of water, stirring until blended. Spread 1/3 of this mixture over the pasta (you can use a cake spatula).
Spread 1/3 of the remaining pasta sauce over the cheese. Spread 1/3 of the vegetables over the sauce. Sprinkle 1/3 of the mozzarella over the veggies. Repeat twice starting with the noodles and ending with the mozzarella. Cover and bake until the noodles are tender (35 to 40 minutes). Remove cover and bake 5 minutes until cheese starts to become golden. Remove from oven and allow to stand for 5 minutes before cutting into squares.');
INSERT INTO recipes (recipe_name, calories, instructions)
VALUES ('Grilled Tomatoes', '43', 'First seed the tomatoes, next cut the tomatoes in half and season them with salt and pepper, brush the tomatoes with olive oil, grill tomatoes(cut side down) for 2-4 minutes')
INSERT INTO recipes(recipe_name, calories, instructions)
VALUES ('Simple Mac n Cheese', '630', 'Bring a large pot of lightly salted water to a boil. Boil elbow macaroni for 8 minutes, then drain. Melt butter in a saucepan over medium heat; stir in flour, salt, and pepper until smooth, about 5 minutes. Slowly pour milk into butter-flour mixture while continuously stirring until mixture is smooth and bubbling. Stir cheese into mixture until cheese is melting.');

--add recipe categories
INSERT INTO recipe_category(recipe_id, category_id)
VALUES
	((SELECT recipe_id FROM recipes WHERE recipe_name = 'Simple Mac n Cheese'),(SELECT category_id FROM category WHERE category_name = 'Easy'));

--add recipe ingredients
INSERT INTO dish_type (dish_type_name) 
VALUES
	('Main Dish'),
	('Side Dish');

--Add meal plans
INSERT INTO meal_plan(meal_plan_name)
VALUES ('Cheesetastic');

--Add meal plan recipes
INSERT INTO meal_plan_recipe(meal_plan_id,recipe_id)
VALUES 
	((SELECT meal_plan_id FROM meal_plan WHERE meal_plan_name = 'Cheesetastic'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Simple Mac n Cheese')),
	((SELECT meal_plan_id FROM meal_plan WHERE meal_plan_name = 'Cheesetastic'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Easy Cheesy Ground Beef Enchiladas')),
	((SELECT meal_plan_id FROM meal_plan WHERE meal_plan_name = 'Cheesetastic'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Grilled Tomatoes'));
--Add dish type to recipes
INSERT INTO recipe_dish_type (dish_type_id, recipe_id)
VALUES 
	((SELECT dish_type_id FROM dish_type WHERE dish_type_name = 'Side Dish'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Grilled Tomatoes')),
	((SELECT dish_type_id FROM dish_type WHERE dish_type_name = 'Main Dish'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Easy Cheesy Ground Beef Enchiladas')),
	((SELECT dish_type_id FROM dish_type WHERE dish_type_name = 'Main Dish'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Vegetable Lasagna')),
	((SELECT dish_type_id FROM dish_type WHERE dish_type_name = 'Side Dish'),(SELECT recipe_id FROM recipes WHERE recipe_name = 'Simple Mac n Cheese'));

--Add recipe ingredients
INSERT INTO recipe_ingredients (recipe_id, ingredient_id,amount,unit)
VALUES
	(1,14,'1','lb'),
	(1,12,'1','10 oz can'),
	(1,7,'8','oz'),
	(1,8,'8','oz'),
	(1,13,'12','6"');
INSERT INTO recipe_ingredients (recipe_id, ingredient_id,amount,unit)
VALUES
	(2,21,'1','28 oz jar'),
	(2,19,'8','oz'),
	(2,20,'15','oz'),
	(2,22,'3','cups'),
	(2,23,'8','oz');
INSERT INTO recipe_ingredients (recipe_id, ingredient_id, amount, unit)
VALUES
	(3, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Tomato'), '2', 'Tomatoes'),
	(3, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Olive Oil'), 'user defined', 'user defined'),
	(3, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Kosher Salt'), 'user defined', 'user defined'),
	(3, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Black Pepper'), 'user defined', 'user defined'),
	(3, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Basil Leaf'), '4', 'Leaves');
INSERT INTO recipe_ingredients(recipe_id, ingredient_id,amount,unit)
VALUES
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Butter'),'1/4','Cup'),
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Flour'),'1/4','Cup'),
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Salt'),'1/2','tsp'),
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Black Pepper'),'to tastse','Not Applicable'),
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Milk'), '2', 'Cups'),
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Elbow Macaroni'), '8', 'Oz'),
	(4, (SELECT ingredient_id FROM ingredients WHERE ingredient_name = 'Cheddar Cheese'), '2', 'Cups');

