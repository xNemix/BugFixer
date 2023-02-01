namespace BugFixer
{
    public class ShopItem
    {
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Id { get; set; }


        public ShopItem()
        {
            
        }
        
        public ShopItem(string itemName, int price, string id) : this()
        {
            ItemName = itemName;
            Price = price;
            Id = id;
        }
    }
}
