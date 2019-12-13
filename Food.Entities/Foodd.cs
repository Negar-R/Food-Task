using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Entities
{
    public class Foodd : BaseEntity
    {
        public Foodd()
        {
            Recepies = new List<Recipe>();
        }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }
        public virtual ICollection<Recipe> Recepies { get; set; }
    }
}
