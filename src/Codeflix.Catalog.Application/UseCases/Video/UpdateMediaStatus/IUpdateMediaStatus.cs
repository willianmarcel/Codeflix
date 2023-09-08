using Codeflix.Catalog.Application.UseCases.Video.Common;
using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.UpdateMediaStatus;
public interface IUpdateMediaStatus
    : IRequestHandler<UpdateMediaStatusInput, VideoModelOutput>
{
}
