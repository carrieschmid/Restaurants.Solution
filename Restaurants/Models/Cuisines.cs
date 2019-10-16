using System.Collections.Generic;

namespace Restaurant.Models
{
  public class Cuisines
    {
        public Cuisines()
        {
            this.Restaurants = new HashSet<Restaurants>();
        }

        public int CusinesId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Restaurants> Restaurants { get; set; }
    }
}


