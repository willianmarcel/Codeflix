using Codeflix.Catalog.UnitTests.Application.CastMember.Common;
using DomainEntity = Codeflix.Catalog.Domain.Entity;

namespace Codeflix.Catalog.UnitTests.Application.CastMember.ListCastMembers;

[CollectionDefinition(nameof(ListCastMembersTestFixture))]
public class ListCastMembersTestFixtureCollection
    : ICollectionFixture<ListCastMembersTestFixture>
{ }

public class ListCastMembersTestFixture
    : CastMemberUseCasesBaseFixture
{
    public List<DomainEntity.CastMember> GetExampleCastMembersList(int quantity)
        => Enumerable
            .Range(1, quantity)
            .Select(_ => GetExampleCastMember())
            .ToList();
}
