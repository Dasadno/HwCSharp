using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCSharp
{
    public class Store<T> : IStore<T> where T : IProduct
    {
        private List<T> store = new List<T>();

        public void Add(T product)
        {
            bool storeContains = store.Any(i => i.Id == product.Id);
            if (!storeContains)
            {
                store.Add(product);
            }
            else
            {
                throw new Exception("item already exist");
            }
        }

        public void Remove(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var rm = store.First(i => i.Id == id);
                store.Remove(rm);
        }

        public T GetProductById(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var item = store.FirstOrDefault(i => i.Id == id);
            return item;
            
            
        }

        public void UpdatePrice(int id, decimal newPrice)
        {
            ArgumentNullException.ThrowIfNull(id);
            var item = store.First(i => i.Id == id);
                item.Price = newPrice;
                Console.WriteLine($"new price: {item.Price}");
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            ArgumentNullException.ThrowIfNull(id);
            var item = store.First(i => i.Id == id);
            
                item.Quantity = newQuantity;
                Console.WriteLine($"new quantity: {item.Quantity}");
            
        }

        public List<T> GetProductsByCategory(string category)
        {
            ArgumentNullException.ThrowIfNull(category);
            return store.Where(i => i.Category == category).ToList();
        }

        public Dictionary<string, List<T>> GroupByCategory()
        {
            Dictionary<string, List<T>> groups = new Dictionary<string, List<T>>();
            var result = store.GroupBy(i => i.Category);

            foreach (var i in result)
            {
                groups[i.Key] = i.ToList();
            }

            return groups;
        }
    }
}
