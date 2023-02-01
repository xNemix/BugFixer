using BugFixer.Exceptions;

namespace BugFixer
{
    public class Customer
    {
        public string Name { get; set; }
        public Address CustomerAddress { get; set; }
        public BankInformation CustomerBankInfo {get;set;} 
        public List<ShopItem> ShoppingCart { get; set; }
        public List<ShopItem> Inventory { get; set; }

        public Customer()
        {
            Name = "Customer";
            CustomerAddress = new Address();
            CustomerBankInfo = new BankInformation();
            ShoppingCart = new List<ShopItem>();
            Inventory = new List<ShopItem>();
        }
        public Customer(string name) : this()
        {
            Name = name;
        }
        
        public Customer(string name, Address address, BankInformation bankInfo) : this(name)
        {
            CustomerAddress = address;
            CustomerBankInfo = bankInfo;
        }
        
        public void AddItemToShoppingCart(ShopItem item)
        {
            ShoppingCart.Add(item);
        }

        private void RemoveItemFromShoppingCart(ShopItem item)
        {
            ShoppingCart.Remove(item);
        }
        public void PrintItemsInCart()
        {
            Console.WriteLine("ShoppingCart now has: ");
            var totalPrice = 0;
            var i = 0;
            foreach(var item in ShoppingCart)
            {
                Console.WriteLine($"[{i + 1}]item: {item.Id} {item.ItemName} costs {item.Price}.");
                totalPrice += item.Price;
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("total price is: " + totalPrice);
            Console.WriteLine();
        }
        public void BuyItemsInCart()
        {
            var totalPrice = GetTotalPrice();
            if (CustomerBankInfo.Balance < totalPrice) throw new NotEnoughBalanceException();
            if (ShoppingCart.Count <= 0) throw new NoItemsInCartException();
            Inventory = ShoppingCart;

            foreach (var item in ShoppingCart)
            {
                ShoppingCart.Remove(item);
            }
            CustomerBankInfo.Balance -= totalPrice;
            Console.WriteLine("Items bought");
        }

        
        public void HandleNotEnoughBalance()
        {
            PrintItemsInCart();
            Console.WriteLine($"Your current balance is {CustomerBankInfo.Balance}");
            Console.WriteLine("Would you like to add more balance or remove items from shopping cart");
            Console.WriteLine("1: Add Balance");
            Console.WriteLine("2: Remove Item(s) From Cart");
            Console.WriteLine("3: Quit Shopping");
            var selection = Console.ReadLine()!;
            if (selection == "1")
            {
                try
                {
                    Console.Clear();
                    HandleAddBalance();
                }
                catch (ShopException)
                {
                    Console.WriteLine("Something went wrong when trying to add more balance...");
                    throw;
                }
            }
            else if (selection == "2")
            {
                try
                {
                    Console.Clear();
                    HandleRemoveItems();
                }
                catch (ShopException)
                {
                    Console.WriteLine("Something went wrong when trying to remove this item...");
                    throw;
                }
            }
            else if (selection == "3")
            {
                Console.Clear();
                HandleQuitShopping();
            }
            else
            {
                throw new InvalidInputException();
            }
            
        }

        private void HandleAddBalance()
        {
            try
            {
                CustomerBankInfo.AddBalance();
            }
            catch (InvalidInputException)
            {
                Console.WriteLine("Invalid balance input");
                throw;
            }

            try
            {
                BuyItemsInCart();
            }
            catch (NotEnoughBalanceException)
            {
                Console.WriteLine("Balance is still not enough");
                throw;
            }
            catch (NoItemsInCartException)
            {
                Console.WriteLine("You dont have any items in your shopping cart");
                throw;
            }
        }


        private int GetTotalPrice()
        {
            var totalPrice = 0;
            foreach (var item in ShoppingCart)
            {
                totalPrice = +item.Price;
            }

            return totalPrice;
        }
        
        
        private void HandleQuitShopping()
        {
            Console.WriteLine("Exiting your session");
            foreach (var item in ShoppingCart)
            {
                RemoveItemFromShoppingCart(item);
            }
        }

        private void HandleRemoveItems()
        {
            PrintItemsInCart();
            Console.Write("Which item would you like to remove? Use itemNumber");
            var selection = Convert.ToInt32(Console.ReadLine());
            var index = selection - 1;
            var item = ShoppingCart[index];
            if (ShoppingCart.Count < index) throw new NoItemsInCartException();
            RemoveItemFromShoppingCart(item);
        }
        
        
        
    }
}
