using Codeflix.Catalog.Application.UseCases.Video.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.UpdateVideo;

public interface IUpdateVideo 
    : IRequestHandler<UpdateVideoInput, VideoModelOutput>
{ }
