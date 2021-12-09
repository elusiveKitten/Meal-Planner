﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IIngredientDao
    {
        public List<RecipeIngredient> GetIngredientsByRecipe(int recipeId);

        public List<Ingredient> GetAllIngredients();

        public Ingredient CreateIngredient(Ingredient ingredient);
     
        public Ingredient GetIngredientById(int ingredientId);
    }
}
