using System;
using System.Threading;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {

            var cat1 = new Cat()
            {
                Nickname = "Tom", 
                Age = 14, 
                Gender = true, 
                MealQuantity = 20, 
                Price = 100
            };

            var cat2 = new Cat()
            {
                Nickname = "Puppy",
                Age = 4,
                Gender = false,
                MealQuantity = 42,
                Price = 70
            };

            var catHouse = new CatHouse();
            catHouse.AddCat(ref cat1);
            catHouse.AddCat(ref cat2);
            
            //catHouse.RemoveByNickname("puppy");

            catHouse.ShowCats();

            var petShop = new PetShop() {Name = "Alpha"};

            petShop.AddCatHouse(ref catHouse);
            //petShop.RemoveCatHouse(1);

            Console.Clear();
            catHouse.Show();
            petShop.Show();
            

            Console.ReadLine();
            foreach (var itemHouse in petShop.CatHouses)
            {
                foreach (var cat in itemHouse.Cats)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        cat.Play();
                        cat.Show();
                        Thread.Sleep(300);
                        Console.Clear();
                    }

                    for (int i = 0; i < 15; i++)
                    {
                        cat.Caress();
                        cat.Show();
                        Thread.Sleep(300);
                        Console.Clear();
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        cat.Eat();
                        cat.Show();
                        Thread.Sleep(300);
                        Console.Clear();
                    }
                }
            }

            Console.Clear();
            catHouse.Show();
            petShop.Show();
        }
    }
}
