﻿using Codeflix.Catalog.Application.Common;
using Codeflix.Catalog.Application.UseCases.Video.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.ListVideos;

public class ListVideosOutput : PaginatedListOutput<VideoModelOutput>
{
    public ListVideosOutput(
        int page, 
        int perPage, 
        int total, 
        IReadOnlyList<VideoModelOutput> items) 
        : base(page, perPage, total, items)
    { }
}
