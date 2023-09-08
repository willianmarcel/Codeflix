﻿using Codeflix.Catalog.Application.Common;
using Codeflix.Catalog.Domain.SeedWork.SearchableRepository;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.ListVideos;

public class ListVideosInput : PaginatedListInput, IRequest<ListVideosOutput>
{
    public ListVideosInput(
        int page = 1,
        int perPage = 15,
        string search = "",
        string sort = "",
        SearchOrder dir = SearchOrder.Asc) 
        : base(page, perPage, search, sort, dir)
    { }
}
