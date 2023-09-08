﻿using Codeflix.Catalog.Application.UseCases.Genre.Common;
using Codeflix.Catalog.Domain.Repository;

namespace Codeflix.Catalog.Application.UseCases.Genre.GetGenre;
public class GetGenre
    : IGetGenre
{
    private readonly IGenreRepository _genreRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetGenre(
        IGenreRepository genreRepository,
        ICategoryRepository categoryRepository)
    {
        _genreRepository = genreRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<GenreModelOutput> Handle(
        GetGenreInput request,
        CancellationToken cancellationToken
    )
    {
        var genre = await _genreRepository
            .Get(request.Id, cancellationToken);
        var output = GenreModelOutput.FromGenre(genre);
        if (output.Categories.Count > 0)
        {
            var categories = (await _categoryRepository
                .GetListByIds(output.Categories
                    .Select(x => x.Id).ToList(), cancellationToken))
                        .ToDictionary(x => x.Id);
            foreach (var category in output.Categories) 
                category.Name = categories[category.Id].Name;
        }

        return output;
    }
}
