using BugFixer.Exceptions;

namespace BugFixer
{
    class Program
    {
        static void Main(string[] args)
        {           
            var shop = new Shop();
            var customer = new Customer();
            while (true)
            {
                Console.Clear();
                shop.PrintItems();
                Console.WriteLine();
                Console.WriteLine("What do you want to buy?");
                Console.WriteLine("if finished shopping, write 0");
                Console.WriteLine();

                var itemNumber = Console.ReadLine()!;
                if (itemNumber == "0")
                {
                    try
                    {
                        Console.Clear();
                        Shop.CheckOut(customer);
                        Thread.Sleep(2000);
                        break;
                    }
                    catch (ShopException shopException)
                    {
                        switch (shopException)
                        {
                            case NotEnoughBalanceException:
                                Console.Clear();
                                Console.WriteLine("Not enough balance");
                                try
                                {
                                    Shop.HandleNotEnoughBalance(customer);
                                }
                                catch (ShopException)
                                {
                                    Console.WriteLine("Something went wrong while checking out");
                                    Thread.Sleep(3000);
                                    continue;
                                }

                                break;
                            case NoItemsInCartException:
                                Console.WriteLine("There is no items in cart to checkout");
                                Thread.Sleep(2000);
                                continue;
                        }
                    }
                }

                var item = shop.ShopItems.Find(item => item.Id == itemNumber);
                if (item == null) continue;
                customer.AddItemToShoppingCart(item);
                customer.PrintItemsInCart();
                Thread.Sleep(2000);
            }
        }
    }
}
