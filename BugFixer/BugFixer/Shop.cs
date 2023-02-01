using BugFixer.Exceptions;

namespace BugFixer
{
    public class Shop
    {
        public List<ShopItem> ShopItems { get; set; }

        public Shop()
        {
            ShopItems = new List<ShopItem>();

            ShopItems.Add(new ShopItem { ItemName = "Pizza", Price = 67, Id= "1" });
            ShopItems.Add(new ShopItem { ItemName = "Pants", Price = 499, Id = "2" });
            ShopItems.Add(new ShopItem { ItemName = "Juice", Price = 32, Id = "3" });
            ShopItems.Add(new ShopItem { ItemName = "Milk", Price = 25, Id = "4" });
            ShopItems.Add(new ShopItem { ItemName = "Shirt", Price = 150, Id = "5" });
            ShopItems.Add(new ShopItem { ItemName = "Sweater", Price = 459, Id = "6" });
            ShopItems.Add(new ShopItem { ItemName = "Glasses", Price = 2700, Id = "7" }); 
            ShopItems.Add(new ShopItem { ItemName = "Computer", Price = 3790, Id = "8" });
            ShopItems.Add(new ShopItem { ItemName = "Phone", Price = 7999, Id = "9" });
            ShopItems.Add(new ShopItem { ItemName = "TV", Price = 13780, Id = "10" });
            ShopItems.Add(new ShopItem { ItemName = "Yoghurt", Price = 30, Id = "11" });
            ShopItems.Add(new ShopItem { ItemName = "Jacket", Price = 750, Id = "12" });
            ShopItems.Add(new ShopItem { ItemName = "Hat", Price = 540, Id = "13" });
            ShopItems.Add(new ShopItem { ItemName = "Cup", Price = 150, Id = "14" });
            ShopItems.Add(new ShopItem { ItemName = "Speaker", Price = 990, Id = "15" });
            ShopItems.Add(new ShopItem { ItemName = "Bread", Price = 30, Id = "16" });
            ShopItems.Add(new ShopItem { ItemName = "Napkin", Price = 50, Id = "17" });
        }

        public void PrintItems()
        {
            foreach(var item in ShopItems)
            {
                Console.WriteLine($"item: {item.Id} {item.ItemName} costs {item.Price}.");
            }
        }

        public static void CheckOut(Customer customer)
        {
            try
            {
                customer.BuyItemsInCart();
            }
            catch (ShopException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e);
            }
        }

        public static void HandleNotEnoughBalance(Customer customer)
        {
            try
            {
                customer.HandleNotEnoughBalance();
            }
            catch (ShopException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new UnknownErrorException(e);
            }
        }
    }
}
