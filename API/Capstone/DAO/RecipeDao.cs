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

        public MealRecipe GetRecipe(int recipeId)
        {
            MealRecipe mealRecipe = new MealRecipe();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT SELECT recipes.recipe_id, recipe_name, instructions, category_name, dish_type_name FROM recipes " +
                        "JOIN recipe_category on recipes.recipe_id = recipe_category.recipe_id " +
                        "JOIN recipe_dish_type on recipes.recipe_id = recipe_dish_type.recipe_id " +
                        "JOIN category on recipe_category.category_id = category.category_id " +
                        "JOIN dish_type on recipe_dish_type.dish_type_id = dish_type.dish_type_id " +
                        "where recipes.recipe_id = @id)", conn);
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

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipe_id, recipe_name FROM recipes", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Recipe recipe = GetRecipeFromReader(reader);
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
        private Recipe GetRecipeFromReader(SqlDataReader reader)
        {
            try
            {
                Recipe recipe = new Recipe()
                {
                    RecipeId = Convert.ToInt32(reader["recipe_id"]),
                    RecipeName = Convert.ToString(reader["recipe_name"]),
                };
                return recipe;
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
                    RecipeId = Convert.ToInt32(reader["recipes.recipe_id"]),
                    RecipeName = Convert.ToString(reader["recipe_name"]),
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
