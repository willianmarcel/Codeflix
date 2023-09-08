﻿using Codeflix.Catalog.Domain.Entity;
using Codeflix.Catalog.Domain.SeedWork;
using Codeflix.Catalog.Domain.SeedWork.SearchableRepository;

namespace Codeflix.Catalog.Domain.Repository;
public interface IVideoRepository :
    IGenericRepository<Video>,
    ISearchableRepository<Video>
{
}
