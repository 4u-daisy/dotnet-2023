﻿using DotNet2023.Domain.InstitutionStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
public class BaseSectionConfiguration : IEntityTypeConfiguration<BaseSection>
{
    public void Configure(EntityTypeBuilder<BaseSection> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Name)
            .HasMaxLength(127);
        builder
            .Property(x => x.Email)
            .HasMaxLength(63);
        builder
            .Property(x => x.Phone)
            .HasMaxLength(15);
    }
}
