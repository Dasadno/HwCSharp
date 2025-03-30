using static System.Formats.Asn1.AsnWriter;

namespace HwCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store<Product> store = new Store<Product>();

            store.Add(new Product(1, "Hamburger", 1200, "IT", 140));
            store.Add(new Product(2, "Arbuz", 200, "IT", 200));
            store.Add(new Product(3, "Oleg", 1, "Vegetable", 1));
            store.Add(new Product(4, "Artem", 2, "Vegetable", 1));

            store.Remove(4);



        }
    }
}
