using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RecipeDao : IRecipeDao
    {
        private readonly string connectionString;

        public RecipeDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<MealRecipe> GetRecipesByUser(int userId)
        {
            List<MealRecipe> userRecipes = new List<MealRecipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipes.recipe_id, recipe_name, calories, instructions, category_name, dish_type_name  FROM recipes " +
                        "JOIN recipe_category ON recipes.recipe_id = recipe_category.recipe_id " +
                        "JOIN recipe_dish_type ON recipes.recipe_id = recipe_dish_type.recipe_id " +
                        "JOIN category ON recipe_category.category_id = category.category_id " +
                        "JOIN dish_type ON recipe_dish_type.dish_type_id = dish_type.dish_type_id " +
                        "JOIN recipes_users ON recipes.recipe_id = recipes_users.recipe_id " +
                        "JOIN users ON recipes_users.user_id = users.user_id " +
                        "WHERE users.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MealRecipe mealRecipe = GetMealRecipeFromReader(reader);
                        if(mealRecipe != null)
                        {
                            userRecipes.Add(mealRecipe);
                        }
                    }
                    reader.Close();
                }
                return userRecipes;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public MealRecipe GetRecipe(int recipeId)
        {
            MealRecipe mealRecipe = new MealRecipe();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipes.recipe_id, recipe_name, calories, instructions, category_name, dish_type_name  FROM recipes " +
                        "JOIN recipe_category on recipes.recipe_id = recipe_category.recipe_id " +
                        "JOIN recipe_dish_type on recipes.recipe_id = recipe_dish_type.recipe_id " +
                        "JOIN category on recipe_category.category_id = category.category_id " +
                        "JOIN dish_type on recipe_dish_type.dish_type_id = dish_type.dish_type_id " +
                        "where recipes.recipe_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mealRecipe = GetMealRecipeFromReader(reader);
                    }
                    reader.Close();
                }
                return mealRecipe;
            }
            catch(SqlException)
            {
                throw new Exception();
            }
        }
        public UserRecipe ConfirmUserRecipe(int userId, int recipeId)
        {
            UserRecipe userRecipe = new UserRecipe();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipe_id, user_id FROM recipes_users WHERE user_id = " + userId + " AND recipe_id = " + recipeId + ";", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userRecipe = new UserRecipe()
                        {
                            //recipes.recipe_id could be an issue in the future!! Otherwise it may be the fix!
                            RecipeId = Convert.ToInt32(reader["recipe_id"]),
                            UserId = Convert.ToInt32(reader["user_id"])
                        };
                    }
                    reader.Close();
                }
                return userRecipe;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public List<MealRecipe> GetAllRecipes()
        {
            List<MealRecipe> recipes = new List<MealRecipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipes.recipe_id, recipe_name, calories, instructions, category_name, dish_type_name  FROM recipes " +
                        "JOIN recipe_category on recipes.recipe_id = recipe_category.recipe_id " +
                        "JOIN recipe_dish_type on recipes.recipe_id = recipe_dish_type.recipe_id " +
                        "JOIN category on recipe_category.category_id = category.category_id " +
                        "JOIN dish_type on recipe_dish_type.dish_type_id = dish_type.dish_type_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MealRecipe recipe = GetMealRecipeFromReader(reader);
                        if (recipe != null)
                        {
                            recipes.Add(recipe);
                        }
                    }
                    reader.Close();
                }
                return recipes;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public List<MealRecipe> SearchByCategory(string category)
        {
            List<MealRecipe> recipes = new List<MealRecipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipes.recipe_id, recipe_name, calories, instructions, category_name, dish_type_name FROM recipes " +
                        "JOIN recipe_category on recipes.recipe_id = recipe_category.recipe_id " +
                        "JOIN recipe_dish_type on recipes.recipe_id = recipe_dish_type.recipe_id " +
                        "JOIN category on recipe_category.category_id = category.category_id " +
                        "JOIN dish_type on recipe_dish_type.dish_type_id = dish_type.dish_type_id " +
                        "WHERE category.category_name LIKE '%" + category + "%'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MealRecipe recipe = GetMealRecipeFromReader(reader);
                        if (recipe != null)
                        {
                            recipes.Add(recipe);
                        }
                    }
                    reader.Close();
                }
                return recipes;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public UserRecipe AddUserRecipe(UserRecipe newRecipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO recipes_users(recipe_id, user_id) VALUES(" + newRecipe.RecipeId + ", " + newRecipe.UserId + ");", conn);
                    cmd.ExecuteNonQuery();
                }
                return ConfirmUserRecipe(newRecipe.UserId, newRecipe.RecipeId);
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public List<MealRecipe> SearchByIngredient(string ingredient)
        {
            List<MealRecipe> recipes = new List<MealRecipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipes.recipe_id, recipe_name, calories, instructions, category_name, dish_type_name FROM recipes " +
                        "JOIN recipe_category on recipes.recipe_id = recipe_category.recipe_id " +
                        "JOIN recipe_dish_type on recipes.recipe_id = recipe_dish_type.recipe_id " +
                        "JOIN category on recipe_category.category_id = category.category_id " +
                        "JOIN dish_type on recipe_dish_type.dish_type_id = dish_type.dish_type_id " +
                        "JOIN recipe_ingredients ON recipes.recipe_id = recipe_ingredients.recipe_id " +
                        "JOIN ingredients ON recipe_ingredients.ingredient_id = ingredients.ingredient_id " +
                        "WHERE ingredients.ingredient_name LIKE '%" + ingredient + "%'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MealRecipe recipe = GetMealRecipeFromReader(reader);
                        if (recipe != null)
                        {
                            recipes.Add(recipe);
                        }
                    }
                    reader.Close();
                }
                return recipes;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        private MealRecipe GetMealRecipeFromReader(SqlDataReader reader)
        {
            try
            {
                MealRecipe recipe = new MealRecipe()
                {
                    //recipes.recipe_id could be an issue in the future!! Otherwise it may be the fix!
                    RecipeId = Convert.ToInt32(reader["recipe_id"]),
                    RecipeName = Convert.ToString(reader["recipe_name"]),
                    Calories = Convert.ToString(reader["calories"]),
                    Instructions = Convert.ToString(reader["instructions"]),
                    Category = Convert.ToString(reader["category_name"]),
                    DishType = Convert.ToString(reader["dish_type_name"])
                };
                return recipe;
            }
            catch (SqlException)
            {
                throw new Exception();
            }

        }
    }
}
