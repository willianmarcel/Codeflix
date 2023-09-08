using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.ListCastMembers;
public interface IListCastMembers
    : IRequestHandler<ListCastMembersInput, ListCastMembersOutput>
{
}
