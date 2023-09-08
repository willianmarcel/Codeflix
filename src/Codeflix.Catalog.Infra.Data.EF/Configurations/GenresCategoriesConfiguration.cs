﻿using Codeflix.Catalog.Infra.Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Codeflix.Catalog.Infra.Data.EF.Configurations;
internal class GenresCategoriesConfiguration
    : IEntityTypeConfiguration<GenresCategories>
{
    public void Configure(EntityTypeBuilder<GenresCategories> builder)
        => builder.HasKey(relation => new { 
            relation.CategoryId, 
            relation.GenreId
        });
}
