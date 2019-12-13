using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
        }
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
