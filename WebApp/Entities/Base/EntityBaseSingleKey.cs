using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Base
{
    public abstract class EntityBaseSingleKey<T> : EntityBase, IEntitySingleKey<T>
    {
        public T Id { get; set; }
    }
}