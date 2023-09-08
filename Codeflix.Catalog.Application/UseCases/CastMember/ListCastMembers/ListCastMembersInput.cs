﻿using Codeflix.Catalog.Application.Common;
using Codeflix.Catalog.Domain.SeedWork.SearchableRepository;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.ListCastMembers;
public class ListCastMembersInput
    : PaginatedListInput, IRequest<ListCastMembersOutput>
{
    public ListCastMembersInput(int page, int perPage, string search, string sort, SearchOrder dir)
        : base(page, perPage, search, sort, dir)
    { }

    public ListCastMembersInput()
        : base(1, 15, "", "", SearchOrder.Asc)
    { }
}
