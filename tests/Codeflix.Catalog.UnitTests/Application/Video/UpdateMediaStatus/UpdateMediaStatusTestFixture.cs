﻿using Codeflix.Catalog.Application.UseCases.Video.UpdateMediaStatus;
using Codeflix.Catalog.Domain.Enum;
using Codeflix.Catalog.UnitTests.Common.Fixtures;

namespace Codeflix.Catalog.UnitTests.Application.Video.UpdateMediaStatus;

[CollectionDefinition(nameof(UpdateMediaStatusTestFixture))]
public class UpdateMediaStatusTestFixtureCollection : ICollectionFixture<UpdateMediaStatusTestFixture>
{

}
public class UpdateMediaStatusTestFixture : VideoTestFixtureBase
{
    public UpdateMediaStatusInput GetSuccededEncodingInput(Guid videoId)
        => new UpdateMediaStatusInput(
            videoId,
            MediaStatus.Completed,
            EncodedPath: GetValidMediaPath());

    public UpdateMediaStatusInput GetFailedEncodingInput(Guid videoId)
        => new UpdateMediaStatusInput(
            videoId,
            MediaStatus.Error,
            ErrorMessage: "There was an error while trying to encode video.");

    public UpdateMediaStatusInput GetInvalidStatusInput(Guid videoId)
        => new UpdateMediaStatusInput(
            videoId,
            MediaStatus.Processing,
            ErrorMessage: "There was an error while trying to encode video.");
}
