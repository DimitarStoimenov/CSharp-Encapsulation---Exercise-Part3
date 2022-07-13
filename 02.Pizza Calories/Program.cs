using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughtInfo = Console.ReadLine().Split();

                string pizzaName = pizzaInfo[1];
                string doughFlourType = doughtInfo[1];
                string bakingTechnique = doughtInfo[2];
                double doughWeight = double.Parse(doughtInfo[3]);

                Dough dough = new Dough(doughFlourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingType = Console.ReadLine();

                while (toppingType != "END")
                {
                    string[] toppingInfo = toppingType.Split();
                    string type = toppingInfo[1];
                    double weight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);

                    toppingType = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():F2} Calories.");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
