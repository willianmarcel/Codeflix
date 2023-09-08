using Codeflix.Catalog.Application.UseCases.CastMember.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.UpdateCastMember;
public interface IUpdateCastMember
    : IRequestHandler<UpdateCastMemberInput, CastMemberModelOutput>
{
}
