using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Text;
using Food.Entities;
using FluentNHibernate.Automapping;

namespace Food.Data
{
    public class FoodMap : IAutoMappingOverride<Foodd>
    {
        public void Override(AutoMapping<Foodd> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned(); ;
            mapping.Map(x => x.Name);
            mapping.Map(x => x.Price);
            mapping.HasMany(x => x.Recepies).Cascade.AllDeleteOrphan();
        }
    }
}
