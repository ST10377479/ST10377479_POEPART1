using System;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Welcome to RecipeApp!");
        Console.ResetColor();

        Console.WriteLine("\n======================");

        Recipe recipe = new Recipe();

        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Enter recipe details");
            Console.WriteLine("2. Display recipe");
            Console.WriteLine("3. Scale recipe");
            Console.WriteLine("4. Reset quantities");
            Console.WriteLine("5. Clear recipe");
            Console.WriteLine("6. Exit");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Choice: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string choice = Console.ReadLine();
            Console.ResetColor();

            switch (choice)
            {
                case "1":
                    recipe.EnterDetails();
                    break;
                case "2":
                    recipe.DisplayRecipe();
                    break;
                case "3":
                    Console.Write("Enter scale factor: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    double factor;
                    if (double.TryParse(Console.ReadLine(), out factor))
                    {
                        recipe.ScaleRecipe(factor);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Please enter a valid numeric value for the scale factor.");
                    }
                    Console.ResetColor();
                    break;
                case "4":
                    recipe.ResetQuantities();
                    break;
                case "5":
                    recipe.ClearRecipe();
                    break;
                case "6":
                    continueRunning = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThank you for using RecipeApp!");
        Console.ResetColor();
    }
}