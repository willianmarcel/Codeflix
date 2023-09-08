﻿using Codeflix.Catalog.Application.Exceptions;
using Codeflix.Catalog.Application.Interfaces;
using Codeflix.Catalog.Domain.Repository;
using FluentAssertions;
using Moq;
using DomainEntity = Codeflix.Catalog.Domain.Entity;
using UseCase = Codeflix.Catalog.Application.UseCases.Video.DeleteVideo;

namespace Codeflix.Catalog.UnitTests.Application.Video.DeleteVideo;

[Collection(nameof(DeleteVideoTestFixture))]
public class DeleteVideoTest
{
    private readonly DeleteVideoTestFixture _fixture;
    private readonly UseCase.DeleteVideo _useCase;
    private readonly Mock<IVideoRepository> _repositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IStorageService> _storageService;

    public DeleteVideoTest(DeleteVideoTestFixture fixture)
    {
        _fixture = fixture;
        _repositoryMock = new Mock<IVideoRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _storageService = new Mock<IStorageService>();
        _useCase = new UseCase.DeleteVideo(
            _repositoryMock.Object, 
            _unitOfWorkMock.Object,
            _storageService.Object
        );
    }

    [Fact(DisplayName = nameof(DeleteVideo))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideo()
    {
        var videoExample = _fixture.GetValidVideo();
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithAllMediasAndClearStorage))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithAllMediasAndClearStorage()
    {
        var videoExample = _fixture.GetValidVideo();
        videoExample.UpdateMedia(_fixture.GetValidMediaPath());
        videoExample.UpdateTrailer(_fixture.GetValidMediaPath());
        videoExample.UpdateBanner(_fixture.GetValidImagePath());
        videoExample.UpdateThumb(_fixture.GetValidImagePath());
        videoExample.UpdateThumbHalf(_fixture.GetValidImagePath());
        var filePaths = new List<string>() {
            videoExample.Media!.FilePath,
            videoExample.Trailer!.FilePath,
            videoExample.Banner!.Path,
            videoExample.Thumb!.Path,
            videoExample.ThumbHalf!.Path,
        };
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.Is<string>(filePath => filePaths.Contains(filePath)),
                It.IsAny<CancellationToken>())
            , Times.Exactly(5));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Exactly(5));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithOnlyTrailerAndClearStorageOnlyForTrailer))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithOnlyTrailerAndClearStorageOnlyForTrailer()
    {
        var videoExample = _fixture.GetValidVideo();
        videoExample.UpdateTrailer(_fixture.GetValidMediaPath());
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.Is<string>(filePath => filePath == videoExample.Trailer!.FilePath),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithOnlyBannerAndClearStorageOnlyForBanner))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithOnlyBannerAndClearStorageOnlyForBanner()
    {
        var videoExample = _fixture.GetValidVideo();
        videoExample.UpdateBanner(_fixture.GetValidImagePath());
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.Is<string>(filePath => filePath == videoExample.Banner!.Path),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithOnlyThumbAndClearStorageOnlyForThumb))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithOnlyThumbAndClearStorageOnlyForThumb()
    {
        var videoExample = _fixture.GetValidVideo();
        videoExample.UpdateThumb(_fixture.GetValidImagePath());
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.Is<string>(filePath => filePath == videoExample.Thumb!.Path),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithOnlyThumbHalfAndClearStorageOnlyForThumbHalf))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithOnlyThumbHalfAndClearStorageOnlyForThumbHalf()
    {
        var videoExample = _fixture.GetValidVideo();
        videoExample.UpdateThumbHalf(_fixture.GetValidImagePath());
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.Is<string>(filePath => filePath == videoExample.ThumbHalf!.Path),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithOnlyMediaAndClearStorageOnlyForMedia))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithOnlyMediaAndClearStorageOnlyForMedia()
    {
        var videoExample = _fixture.GetValidVideo();
        videoExample.UpdateMedia(_fixture.GetValidMediaPath());
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.Is<string>(filePath => filePath == videoExample.Media!.FilePath),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Exactly(1));
    }

    [Fact(DisplayName = nameof(DeleteVideoWithoutAnyMediaAndDontClearStorage))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task DeleteVideoWithoutAnyMediaAndDontClearStorage()
    {
        var videoExample = _fixture.GetValidVideo();
        var input = _fixture.GetValidInput(videoExample.Id);
        _repositoryMock.Setup(x => x.Get(
                It.Is<Guid>(id => id == videoExample.Id),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(videoExample);

        await _useCase.Handle(input, CancellationToken.None);

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.Is<DomainEntity.Video>(video => video.Id == videoExample.Id),
                It.IsAny<CancellationToken>())
            , Times.Once);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()));
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Never);
    }

    [Fact(DisplayName = nameof(ThrowsNotFoundExceptionWhenVideoNotFound))]
    [Trait("Application", "DeleteVideo - Use Cases")]
    public async Task ThrowsNotFoundExceptionWhenVideoNotFound()
    {
        var input = _fixture.GetValidInput();
        _repositoryMock.Setup(x => x.Get(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()
            )).ThrowsAsync(new NotFoundException("Video not found"));

        var action = () => _useCase.Handle(input, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage("Video not found");

        _repositoryMock.VerifyAll();
        _repositoryMock.Verify(x => x.Delete(
                It.IsAny<DomainEntity.Video>(), 
                It.IsAny<CancellationToken>())
            , Times.Never);
        _unitOfWorkMock.Verify(x => x.Commit(It.IsAny<CancellationToken>()), Times.Never);
        _storageService.Verify(x => x.Delete(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>())
            , Times.Never);
    }
}
