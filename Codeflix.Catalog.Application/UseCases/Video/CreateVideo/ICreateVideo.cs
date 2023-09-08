using Codeflix.Catalog.Application.UseCases.Video.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.CreateVideo;

public interface ICreateVideo : IRequestHandler<CreateVideoInput, VideoModelOutput>
{}
