using Codeflix.Catalog.Application.UseCases.Video.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.GetVideo;

public record GetVideoInput(Guid VideoId) : IRequest<VideoModelOutput>;
