using Codeflix.Catalog.Application.UseCases.CastMember.Common;
using Codeflix.Catalog.Domain.Enum;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.CastMember.UpdateCastMember;
public class UpdateCastMemberInput : IRequest<CastMemberModelOutput>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CastMemberType Type { get; set; }

    public UpdateCastMemberInput(Guid id, string name, CastMemberType type)
    {
        this.Id = id;
        Name = name;
        Type = type;
    }
}
