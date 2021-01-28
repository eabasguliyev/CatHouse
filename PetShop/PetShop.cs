using System;

namespace PetShop
{
    class PetShop
    {
        public string Name { get; set; }
        public CatHouse[] CatHouses { get; set; }


        public void AddCatHouse(ref CatHouse catHouse)
        {
            var newLength = (CatHouses != null) ? CatHouses.Length + 1 : 1;
            var temp = new CatHouse[newLength];
            if (CatHouses != null)
            {
                CatHouses.CopyTo(temp, 0);
            }

            temp[newLength - 1] = catHouse;

            CatHouses = temp;
        }

        public void RemoveCatHouse(int id)
        {
            var index = Array.FindIndex(CatHouses, house => house.Id == id);

            if (index >= 0)
            {
                var temp = new CatHouse[CatHouses.Length - 1];

                if (temp != null)
                {
                    Array.Copy(CatHouses, 0, temp, 0, index);
                    Array.Copy(CatHouses, index + 1, temp, index, CatHouses.Length - index - 1);
                }

                CatHouses = temp;
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("---------- Petshop info ----------");
            Console.WriteLine();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cat House count: {CatHouses?.Length}");
            Console.WriteLine($"Total meal quantity: {GetTotalMealQuantity()}");
            Console.WriteLine($"Total eaten mealquantity: {GetTotalMealEaten()}");
            Console.WriteLine($"Total cat price: {GetTotalCatPrice():C2}");
            Console.ResetColor();
        }

        public int GetTotalMealQuantity()
        {
            var total = 0;
            if (CatHouses != null)
            {
                foreach (var catHouse in CatHouses)
                {
                    total += catHouse.GetTotalMealQuantity();
                }
            }

            return total;
        }

        public int GetTotalMealEaten()
        {
            var total = 0;
            if (CatHouses != null)
            {
                foreach (var catHouse in CatHouses)
                {
                    total += catHouse.GetTotalMealEaten();
                }
            }

            return total;
        }
        public double GetTotalCatPrice()
        {
            var total = 0.0;
            if (CatHouses != null)
            {
                foreach (var catHouse in CatHouses)
                {
                    total += catHouse.GetTotalCatPrice();
                }
            }

            return total;
        }
    }
}