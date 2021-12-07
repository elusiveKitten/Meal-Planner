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

        public List<string> GetAllRecipes()
        {
            List<string> recipes = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT recipe_name FROM recipes", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        string recipe = Convert.ToString(reader["recipe_name"]);   
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
    }
}
