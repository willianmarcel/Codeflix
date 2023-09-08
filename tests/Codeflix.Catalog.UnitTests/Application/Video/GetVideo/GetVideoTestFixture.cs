using Codeflix.Catalog.UnitTests.Common.Fixtures;

namespace Codeflix.Catalog.UnitTests.Application.Video.GetVideo;

[CollectionDefinition(nameof(GetVideoTestFixture))]
public class GetVideoTestFixtureCollection
    : ICollectionFixture<GetVideoTestFixture>
{ }

public class GetVideoTestFixture : VideoTestFixtureBase
{ }
