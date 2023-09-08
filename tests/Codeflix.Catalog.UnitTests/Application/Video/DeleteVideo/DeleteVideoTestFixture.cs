using Codeflix.Catalog.Application.UseCases.Video.DeleteVideo;
using Codeflix.Catalog.UnitTests.Common.Fixtures;

namespace Codeflix.Catalog.UnitTests.Application.Video.DeleteVideo;

[CollectionDefinition(nameof(DeleteVideoTestFixture))]
public class DeleteVideoTestFixtureCollection
    : ICollectionFixture<DeleteVideoTestFixture>
{ }

public class DeleteVideoTestFixture : VideoTestFixtureBase
{
    internal DeleteVideoInput GetValidInput(Guid? id = null) 
        => new(id ?? Guid.NewGuid());
}
