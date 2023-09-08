using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.DeleteCastMember;
public interface IDeleteCastMember
    : IRequestHandler<DeleteCastMemberInput>
{ }
