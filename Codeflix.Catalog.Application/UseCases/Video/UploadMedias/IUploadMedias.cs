using MediatR;

namespace Codeflix.Catalog.Application.UseCases.Video.UploadMedias;

public interface IUploadMedias : IRequestHandler<UploadMediasInput>
{ }
