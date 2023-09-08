﻿using Codeflix.Catalog.Infra.Data.EF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Codeflix.Catalog.Infra.Data.EF.Configurations;

internal class VideosCategoriesConfiguration
    : IEntityTypeConfiguration<VideosCategories>
{
    public void Configure(EntityTypeBuilder<VideosCategories> builder)
        => builder.HasKey(relation => new {
            relation.CategoryId,
            relation.VideoId
        });
}