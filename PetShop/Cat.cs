using System;
using System.Net.Configuration;

namespace PetShop
{
    class Cat
    {
        public int Id { get; private set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Energy { get; private set; } = 100;
        public double Price { get; set; }
        public int MealQuantity { get; set; }
        public int NumberOfMealEaten { get; private set; } = default;
        public static int CatId { get; private set; }

        public Cat()
        {
            Id = ++CatId;
        }

        public void Eat()
        {
            if (Energy < 100 && MealQuantity > 0)
            {
                Energy += 30;
                MealQuantity -= 3;
                NumberOfMealEaten += 3;
                Price += 0.5;
                if (Energy > 100)
                    Energy = 100;
            }
        }

        public void Sleep()
        {
            Energy += 40;

            if (Energy > 100)
                Energy = 100;
        }

        public void Play()
        {
            Energy -= 5;

            if (Energy <= 0)
            {
                Energy = 0;
                Sleep();
            }
        }

        public void Show()
        {
            var gender = Gender ? "male" : "female";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------- Cat Info ----------");
            Console.WriteLine();
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Nickname: {Nickname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"Price: {Price:C2}");
            Console.WriteLine($"Meal quantity: {MealQuantity}");
            Console.ResetColor();
        }

        public void Caress()
        {
            Energy -= 2;

            if (Energy <= 0)
            {
                Energy = 0;
                Sleep();
            }
        }
    }
}