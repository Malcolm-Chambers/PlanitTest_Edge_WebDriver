namespace PlanitTest_Edge_WebDriver.Helpers
{
    public static class LocatorsInShop
    {
        // Magic string should only be stored in one place.  This the place to store strings that are used to locate fields
        public static string ProductList { get; set; } = "/html/body/div[2]/div/ul";
        public static string CartButton { get; set; } = "/ html / body / div[1] / div / div / div / ul[2] / li[4] / a";
    }
}
