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
                    while(reader.Read())
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
            catch(SqlException)
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
    }
