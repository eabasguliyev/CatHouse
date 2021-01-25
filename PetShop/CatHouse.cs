using System;

namespace PetShop
{
    class CatHouse
    {
        public int Id { get; private set; }
        public Cat[] Cats { get; private set; } = null;

        public static int CatHouseId { get; private set; } = default;

        public CatHouse()
        {
            Id = ++CatHouseId;
        }

        public void AddCat(ref Cat cat)
        {
            var newCatCount = (Cats != null) ? Cats.Length + 1 : 1;
            var temp = new Cat[newCatCount];

            if (Cats != null)
            {
                Cats.CopyTo(temp, 0);
            }

            temp[newCatCount - 1] = cat;

            Cats = temp;
        }

        public void RemoveByNickname(string nickName)
        {
            var catIndex = Array.FindIndex(Cats, cat => cat.Nickname.ToLower() == nickName.ToLower());

            if (catIndex >= 0)
            {
                var temp = new Cat[Cats.Length - 1];

                if (temp != null)
                {
                    Array.Copy(Cats, temp, catIndex);
                    Array.Copy(Cats, catIndex + 1, temp, catIndex, Cats.Length - catIndex - 1);
                }

                Cats = temp;
            }
        }

        public void ShowCats()
        {
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    cat.Show();
                }
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------- Cat House Info ----------");
            Console.WriteLine();
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Cat count: {Cats.Length}");
            Console.WriteLine($"Total meal quantity: {GetTotalMealQuantity()}");
            Console.WriteLine($"Total cat price: {GetTotalCatPrice():C2}");
            Console.ResetColor();
        }

        public int GetTotalMealQuantity()
        {
            var total = 0;
            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    total += cat.MealQuantity;
                }
            }

            return total;
        }

        public double GetTotalCatPrice()
        {
            var total = 0.0;

            if (Cats != null)
            {
                foreach (var cat in Cats)
                {
                    total += cat.Price;
                }
            }

            return total;
        }

    }
}