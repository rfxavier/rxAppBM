﻿using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class RsDataConfig : EntityTypeConfiguration<RsData>
    {
        public RsDataConfig()
        {
            HasKey(r => r.RsDataId);

            Property(r => r.RsDataId).HasColumnType("bigint");
        }
    }
}