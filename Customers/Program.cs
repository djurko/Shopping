using ShoppingBasket;
using Stores;
using System;

namespace Customers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SCENARIJ 1
            Console.WriteLine("Pero Perić walks into Kaufland and picks up a basket.");
            IShoppingBasket kauflandBasket = new ShoppingBasket.ShoppingBasket();
            Store1 kaufland = new Store1(kauflandBasket);

            // Buy2ButtersGet1Bread50PercentOffDiscount sam mogao napraviti static metodom jer trenutno Store1 klasa
            // ne koristi nikakve podatke iz vlastite instance, ali moguće je da će u budućnosti koristiti (možda 
            // povezivati se na neku bazu, raditi dodatne interne izračune i dodati nove vlastite propertye itd.)
            //kauflandBasket.RegisterDiscountMethod(Store1.Buy2ButtersGet1Bread50PercentOffDiscount);

            Console.WriteLine("Pero Perić puts 2 butters and 2 breads in the basket.");
            kaufland.PrepareBasket();

            Console.WriteLine("Pero Perić totals the basket.");
            Console.WriteLine($"Pero Perić pays {kauflandBasket.CalculateTotal():C2}");
            Console.WriteLine();

            // SCENARIJ 2
            Console.WriteLine("Ana Anić walks into Lidl and picks up a basket.");
            IShoppingBasket lidlBasket = new ShoppingBasket.ShoppingBasket();
            Store2 lidl = new Store2(lidlBasket);

            Console.WriteLine("Ana Anić puts 4 milks in the basket.");
            lidl.PrepareBasket();

            Console.WriteLine("Ana Anić totals the basket.");
            Console.WriteLine($"Ana Anić pays {lidlBasket.CalculateTotal():C2}");
            Console.WriteLine();

            // SCENARIJ 3
            Console.WriteLine("Luka Lukić walks into Interspar and picks up a basket.");
            IShoppingBasket intersparBasket = new ShoppingBasket.ShoppingBasket();
            Store3 interspar = new Store3(intersparBasket);

            Console.WriteLine("Luka Lukić puts 2 butters, 1 bread and 8 milks in the basket.");
            interspar.PrepareBasket();

            Console.WriteLine("Luka Lukić totals the basket.");
            Console.WriteLine($"Luka Lukić pays {intersparBasket.CalculateTotal():C2}");
            Console.WriteLine();

            // SCENARIJ 4
            Console.WriteLine("Hrvoje Horvat walks into Interspar and picks up a basket.");
            IShoppingBasket intersparBasket2 = new ShoppingBasket.ShoppingBasket();
            interspar = new Store3(intersparBasket2);

            Console.WriteLine("Hrvoje Horvat puts 1 butter, 1 bread and 1 milk in the basket.");
            interspar.PrepareBasketWithoutDiscounts();

            Console.WriteLine("Hrvoje Horvat totals the basket.");
            Console.WriteLine($"Hrvoje Horvat pays {intersparBasket2.CalculateTotal():C2}");
            Console.WriteLine();
        }
    }
}
