using Codeflix.Catalog.Application;
using Codeflix.Catalog.Application.EventHandlers;
using Codeflix.Catalog.Application.Interfaces;
using Codeflix.Catalog.Application.UseCases.Category.CreateCategory;
using Codeflix.Catalog.Domain.Events;
using Codeflix.Catalog.Domain.Repository;
using Codeflix.Catalog.Domain.SeedWork;
using Codeflix.Catalog.Infra.Data.EF;
using Codeflix.Catalog.Infra.Data.EF.Repositories;
using MediatR;

namespace Codeflix.Catalog.Api.Configurations;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(
        this IServiceCollection services
    )
    {
        services.AddMediatR(typeof(CreateCategory));
        services.AddRepositories();
        services.AddDomainEvents();
        return services;
    }

    private static IServiceCollection AddRepositories(
            this IServiceCollection services
        )
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<ICastMemberRepository, CastMemberRepository>();
        services.AddTransient<IVideoRepository, VideoRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }

    private static IServiceCollection AddDomainEvents(
        this IServiceCollection services)
    {
        services.AddTransient<IDomainEventPublisher, DomainEventPublisher>();
        services.AddTransient<IDomainEventHandler<VideoUploadedEvent>,
            SendToEncoderEventHandler>();

        return services;
    }


}
