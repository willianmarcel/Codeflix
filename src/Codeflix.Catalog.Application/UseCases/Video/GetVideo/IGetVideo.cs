using Codeflix.Catalog.Application.UseCases.Video.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.GetVideo;

public interface IGetVideo : IRequestHandler<GetVideoInput, VideoModelOutput>
{ }
