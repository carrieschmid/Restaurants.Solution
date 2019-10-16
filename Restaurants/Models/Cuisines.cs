using System.Collections.Generic;

namespace Restaurant.Models
{
  public class Cuisines
    {
        public Cuisines()
        {
            this.Items = new HashSet<Item>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}