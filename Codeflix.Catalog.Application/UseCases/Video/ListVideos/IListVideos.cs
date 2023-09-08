using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.ListVideos;

public interface IListVideos : IRequestHandler<ListVideosInput, ListVideosOutput>
{ }
