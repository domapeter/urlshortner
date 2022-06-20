using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configurators
{
    public class LinkPairConfigurator : IEntityTypeConfiguration<LinkPair>
    {
        public void Configure(EntityTypeBuilder<LinkPair> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}