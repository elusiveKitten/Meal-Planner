using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class IngredientDao : IIngredientDao
    {
        private readonly string connectionString;

        public IngredientDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Ingredient GetIngredientById(int ingredientId)
        {
            Ingredient ingredient = new Ingredient();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ingredient_id, ingredient_name FROM ingredients WHERE ingredient_id = " + ingredientId + "", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ingredient = GetIngredientFromReader(reader);
                    }
                    reader.Close();
                }
                return ingredient;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            int newIngredientId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ingredients(ingredient_name) VALUES('" + ingredient.IngredientName + "'); SELECT @@IDENTITY", conn);
                    newIngredientId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return GetIngredientById(newIngredientId);
            }
            catch (SqlException)
            {
                throw new Exception("Ingredient may already exist");
            }
        }
        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ingredients", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Ingredient ingredient = GetIngredientFromReader(reader);
                        if (ingredient != null)
                        {
                            ingredients.Add(ingredient);
                        }
                    }
                    reader.Close();
                }
                return ingredients;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        public List<RecipeIngredient> GetIngredientsByRecipe(int recipeId)
        {
            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ingredients.ingredient_id, ingredient_name, amount, unit FROM ingredients " +
                        "JOIN recipe_ingredients ON ingredients.ingredient_id = recipe_ingredients.ingredient_id " +
                        "JOIN recipes ON recipe_ingredients.recipe_id = recipes.recipe_id " +
                        "WHERE recipes.recipe_id = @recipeId", conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RecipeIngredient ingredient = GetRecipeIngredientFromReader(reader);
                        if(ingredient != null)
                        {
                            recipeIngredients.Add(ingredient);
                        }
                    }
                    reader.Close();
                }
                return recipeIngredients;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        private RecipeIngredient GetRecipeIngredientFromReader(SqlDataReader reader)
        {
            try
            {
                RecipeIngredient ingredient = new RecipeIngredient()
                {
                    //ingredients.ingredient_id may be an issue in the future!!
                    IngredientId = Convert.ToInt32(reader["ingredient_id"]),
                    IngredientName = Convert.ToString(reader["ingredient_name"]),
                    Amount = Convert.ToString(reader["amount"]),
                    Unit = Convert.ToString(reader["unit"]),
                };
                return ingredient;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
        private Ingredient GetIngredientFromReader(SqlDataReader reader)
        {
            try
            {
                Ingredient ingredient = new Ingredient()
                {
                    //ingredients.ingredient_id may be an issue in the future!!
                    IngredientId = Convert.ToInt32(reader["ingredient_id"]),
                    IngredientName = Convert.ToString(reader["ingredient_name"]),
                };
                return ingredient;
            }
            catch (SqlException)
            {
                throw new Exception();
            }
        }
    }
}
