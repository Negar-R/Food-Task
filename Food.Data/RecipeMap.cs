using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Food.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Data
{
    public class RecipeMap : IAutoMappingOverride<Recipe>
    {
        public void Override(AutoMapping<Recipe> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned(); ;
            mapping.Map(x => x.Name);
            mapping.Map(x => x.Unit);
        }
    }
}
