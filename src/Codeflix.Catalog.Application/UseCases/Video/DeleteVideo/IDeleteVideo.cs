using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.DeleteVideo;

public interface IDeleteVideo : IRequestHandler<DeleteVideoInput>
{ }
