using System;
public class Recipe
{
    private Ingredient[] ingredients;
    private Ingredient[] originalIngredients; // Store original quantities
    private RecipeStep[] steps;

    private bool scaled = false; // Track if the recipe has been scaled
    private double scalingFactor = 1; // Initialize scaling factor to 1

    public void EnterDetails()
    {
        Console.WriteLine("\nEnter the number of ingredients:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int ingredientCount;
        if (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Please enter a valid positive integer for the number of ingredients.");
            Console.ResetColor();
            return;
        }
        Console.ResetColor();
        ingredients = new Ingredient[ingredientCount];
        originalIngredients = new Ingredient[ingredientCount]; 

        for (int i = 0; i < ingredientCount; i++)
        {
            string name;
            do
            {
                Console.WriteLine($"\nEnter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name) || !IsLettersOnly(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please enter a valid ingredient name (letters only).");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(name) || !IsLettersOnly(name));

            Console.ResetColor();
            Console.Write("Quantity: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            double quantity;
            if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Please enter a valid positive quantity (numeric value only).");
                Console.ResetColor();
                i--;
                continue;
            }
            Console.ResetColor();
            Console.Write("Unit: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string unit = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(unit) || !IsValidUnit(unit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Please enter a valid unit of measurement.");
                Console.ResetColor();
                i--;
                continue;
            }
            Console.ResetColor();

            ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            originalIngredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit }; 
        }

        Console.WriteLine("\nEnter the number of steps:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int stepCount;
        if (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Please enter a valid positive integer for the number of steps.");
            Console.ResetColor();
            return;
        }
        Console.ResetColor();
        steps = new RecipeStep[stepCount];

        for (int i = 0; i < stepCount; i++)
        {
            Console.WriteLine($"\nEnter step {i + 1}:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string description = Console.ReadLine();
            Console.ResetColor();
            steps[i] = new RecipeStep { Description = description };
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nRecipe details entered successfully!");
        Console.ResetColor();
    }

    public void DisplayRecipe()
    {
        if (ingredients != null && steps != null)
        {
            Console.WriteLine("\nRecipe Details:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo recipe data available. Please enter recipe details first.");
            Console.ResetColor();
        }
    }

    public void ScaleRecipe(double factor)
    {
        if (!scaled)
        {
            // If recipe has not been scaled yet, clone original quantities and set scaling factor
            originalIngredients = (Ingredient[])ingredients.Clone();
            scaled = true;
            scalingFactor = factor; // Set scaling factor
        }

        foreach (var ingredient in ingredients)
        {
            ingredient.Quantity *= factor;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nRecipe scaled by a factor of {factor} successfully!");
        Console.ResetColor();
    }

    public void ResetQuantities()
    {
        if (scaled)
        {
            // Reset quantities to original values
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].Quantity = originalIngredients[i].Quantity / scalingFactor;
            }
            scaled = false; // Reset scaled flag
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nQuantities have been reset to original values.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nQuantities are already at original values.");
            Console.ResetColor();
        }
    }

    public void ClearRecipe()
    {
        ingredients = null;
        originalIngredients = null;
        steps = null;
        scaled = false; // Reset scaled flag
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nAll data has been cleared.");
        Console.ResetColor();
    }

    private bool IsLettersOnly(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    private bool IsValidUnit(string unit)
    {
        // Add your custom validation for valid units of measurement here
        // For simplicity, let's assume any non-empty string is a valid unit
        return !string.IsNullOrWhiteSpace(unit);
    }
}

