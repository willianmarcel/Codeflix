using Codeflix.Catalog.UnitTests.Common.Fixtures;
using UseCase = Codeflix.Catalog.Application.UseCases.Video.UploadMedias;

namespace Codeflix.Catalog.UnitTests.Application.Video.UploadMedias;

[CollectionDefinition(nameof(UploadMediasTestFixture))]
public class UploadMediasTestFixtureCollection 
    : ICollectionFixture<UploadMediasTestFixture>
{ }

public class UploadMediasTestFixture : VideoTestFixtureBase
{
    public UseCase.UploadMediasInput GetValidInput(
        Guid? videoId = null,
        bool withVideoFile = true,
        bool withTrailerFile = true,
        bool withBannerFile = true,
        bool withThumbFile = true,
        bool withThumbHalfFile = true)
        => new(
            videoId ?? Guid.NewGuid(),
            withVideoFile ? GetValidMediaFileInput(): null,
            withTrailerFile ? GetValidMediaFileInput() : null,
            withBannerFile ? GetValidMediaFileInput() : null,
            withThumbFile ? GetValidMediaFileInput() : null,
            withThumbHalfFile ? GetValidMediaFileInput() : null
        );
}
