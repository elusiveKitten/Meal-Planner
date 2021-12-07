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

        public List<Ingredient> GetIngredientsByRecipe(int recipeId)
        {
            List<Ingredient> recipeIngredients = new List<Ingredient>();
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
                        Ingredient ingredient = GetIngredientFromReader(reader);
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
        private Ingredient GetIngredientFromReader(SqlDataReader reader)
        {
            try
            {
                Ingredient ingredient = new Ingredient()
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
    }
}
