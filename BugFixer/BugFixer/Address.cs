namespace BugFixer
{
    public class Address
    {
        public string StreetName { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public string HouseNumber { get; set; }
        
        public Address()
        {
            StreetName = "Test Street";
            Municipality = "Test Municipality";
            City = "Test City";
            HouseNumber = "Test HouseNumber";
        }
        
        public Address(string streetName, string municipality, string city, string houseNumber) : this()
        {
            StreetName = streetName;
            Municipality = municipality;
            City = city;
            HouseNumber = houseNumber;
        }

        
    }
}
