﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IIngredientDao
    {
        public List<Ingredient> GetIngredientsByRecipe(int recipeId);
    }
}
