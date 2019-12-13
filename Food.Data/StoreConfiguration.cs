using FluentNHibernate;
using FluentNHibernate.Automapping;
using Food.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Data
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return typeof(BaseEntity).IsAssignableFrom(type) && !type.IsAbstract;
        }
    }
}
