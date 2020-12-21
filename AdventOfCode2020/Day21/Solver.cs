namespace AdventOfCode2020.Day21
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    public class Solver : ISolver
    {
        private Dictionary<string, HashSet<string>> allergenIngredientsDict = new Dictionary<string, HashSet<string>>();
        private List<string> ingredients = new List<string>();
        public Solver(IEnumerable<Food> input)
        {
            foreach (var food in input)
            {
                foreach (var allergen in food.Allergens)
                {
                    if (allergenIngredientsDict.ContainsKey(allergen))
                    {
                        allergenIngredientsDict[allergen].IntersectWith(food.Ingredients);
                    }
                    else
                    {
                        allergenIngredientsDict[allergen] = new HashSet<string>(food.Ingredients);
                    }
                }
                ingredients.AddRange(food.Ingredients);
            }
        }

        public string GetPartOneSolution()
        {
            var possibleIngredientsWithAllergen = allergenIngredientsDict
                .Values.Aggregate(new HashSet<string>(), (s, h) => { s.UnionWith(h); return s; });
            ingredients.RemoveAll(s => possibleIngredientsWithAllergen.Contains(s));
            return ingredients.Count.ToString();
        }

        public string GetPartTwoSolution()
        {
            Dictionary<string, string> allergenDictionary = new Dictionary<string, string>();
            while (allergenIngredientsDict.Count > 0)
            {
                var trivialAllergenes = allergenIngredientsDict.Where(d => d.Value.Count == 1).Select(ai => ai.Key);
                foreach (var trivialAllergene in trivialAllergenes)
                {
                    var trivialAllergeneIngredient = allergenIngredientsDict[trivialAllergene].First();
                    allergenDictionary[trivialAllergene] = trivialAllergeneIngredient;
                    allergenIngredientsDict.Remove(trivialAllergene);
                    foreach (var item in allergenIngredientsDict)
                    {
                        item.Value.Remove(trivialAllergeneIngredient);
                    }
                }
            }
            return string.Join(',',allergenDictionary.OrderBy(k => k.Key).Select(k => k.Value));
        }
    }
}
