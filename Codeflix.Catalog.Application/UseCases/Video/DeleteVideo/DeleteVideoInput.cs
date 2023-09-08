using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.DeleteVideo;

public record DeleteVideoInput(Guid VideoId) : IRequest;
