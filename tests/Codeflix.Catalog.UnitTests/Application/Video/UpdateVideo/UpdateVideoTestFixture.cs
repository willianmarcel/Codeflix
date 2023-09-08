using Codeflix.Catalog.Application.UseCases.Video.Common;
using Codeflix.Catalog.UnitTests.Common.Fixtures;
using UseCase = Codeflix.Catalog.Application.UseCases.Video.UpdateVideo;

namespace Codeflix.Catalog.UnitTests.Application.Video.UpdateVideo;

[CollectionDefinition(nameof(UpdateVideoTestFixture))]
public class UpdateVideoTestFixtureCollection : ICollectionFixture<UpdateVideoTestFixture>
{ }

public class UpdateVideoTestFixture : VideoTestFixtureBase
{
    public UseCase.UpdateVideoInput CreateValidInput(
        Guid videoId,
        List<Guid>? genreIds = null,
        List<Guid>? categoryIds = null,
        List<Guid>? castMemberIds = null,
        FileInput? banner = null,
        FileInput? thumb = null,
        FileInput? thumbHalf = null)
        => new (
            videoId,
            GetValidTitle(),
            GetValidDescription(),
            GetValidYearLaunched(),
            GetRandomBoolean(),
            GetRandomBoolean(),
            GetValidDuration(),
            GetRandomRating(),
            genreIds,
            categoryIds,
            castMemberIds,
            banner,
            thumb,
            thumbHalf
        );
}
