using Goreu.Firma.Services.Implementations;
using Goreu.Firma.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Goreu.Firma.Services.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            //services
            //    .AddSingleton<IItemMapper, ItemMapper>()
            //    .AddSingleton<IArtistMapper, ArtistMapper>()
            //    .AddSingleton<IGenreMapper, GenreMapper>()
            //    .AddSingleton<IMarcaMapper, MarcaMapper>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IImageDownloadService, ImageDownloadService>()
                .AddScoped<IFileDownloadService, FileDownloadService>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IFileUploadService, FileUploadService>();

            return services;
        }

        //public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        //{
        //    builder
        //        .AddFluentValidation(configuration =>
        //            configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

        //    return builder;
        //}
    }
}
