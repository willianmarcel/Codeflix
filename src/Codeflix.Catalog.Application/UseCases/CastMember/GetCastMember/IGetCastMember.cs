using Codeflix.Catalog.Application.UseCases.CastMember.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.GetCastMember;
public interface IGetCastMember
    : IRequestHandler<GetCastMemberInput, CastMemberModelOutput>
{ }
