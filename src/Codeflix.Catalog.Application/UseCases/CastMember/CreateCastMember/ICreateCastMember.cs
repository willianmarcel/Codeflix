using Codeflix.Catalog.Application.UseCases.CastMember.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.CreateCastMember;
public interface ICreateCastMember
    : IRequestHandler<CreateCastMemberInput, CastMemberModelOutput>
{
}
