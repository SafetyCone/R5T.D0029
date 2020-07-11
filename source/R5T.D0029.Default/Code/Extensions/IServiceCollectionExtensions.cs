using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0019;
using R5T.D0021;

using R5T.Dacia;


namespace R5T.D0029.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="VisualStudioProjectFileSerializer"/> implementation of <see cref="IVisualStudioProjectFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<IVisualStudioProjectFileTransformer> visualStudioProjectFileTransformerAction,
            IServiceAction<IXDocumentVisualStudioProjectFileSerializer> xDocumentVisualStudioProjectFileSerializerAction)
        {
            services
                .AddSingleton<IVisualStudioProjectFileSerializer, VisualStudioProjectFileSerializer>()
                .Run(visualStudioProjectFileTransformerAction)
                .Run(xDocumentVisualStudioProjectFileSerializerAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="VisualStudioProjectFileSerializer"/> implementation of <see cref="IVisualStudioProjectFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IVisualStudioProjectFileSerializer> AddVisualStudioProjectFileSerializerAction(this IServiceCollection services,
            IServiceAction<IVisualStudioProjectFileTransformer> visualStudioProjectFileTransformerAction,
            IServiceAction<IXDocumentVisualStudioProjectFileSerializer> xDocumentVisualStudioProjectFileSerializerAction)
        {
            var serviceAction = ServiceAction.New<IVisualStudioProjectFileSerializer>(() => services.AddVisualStudioProjectFileSerializer(
                visualStudioProjectFileTransformerAction,
                xDocumentVisualStudioProjectFileSerializerAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="VisualStudioProjectFileSerializer"/> implementation of <see cref="IVisualStudioProjectFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAsFilePathVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<IVisualStudioProjectFileTransformer> visualStudioProjectFileTransformerAction,
            IServiceAction<IAsFilePathXDocumentVisualStudioProjectFileSerializer> asFilePathXDocumentVisualStudioProjectFileSerializer)
        {
            services
                .AddSingleton<IAsFilePathVisualStudioProjectFileSerializer, AsFilePathVisualStudioProjectFileSerializer>()
                .Run(visualStudioProjectFileTransformerAction)
                .Run(asFilePathXDocumentVisualStudioProjectFileSerializer)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="VisualStudioProjectFileSerializer"/> implementation of <see cref="IVisualStudioProjectFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAsFilePathVisualStudioProjectFileSerializer> AddAsFilePathVisualStudioProjectFileSerializerAction(this IServiceCollection services,
            IServiceAction<IVisualStudioProjectFileTransformer> visualStudioProjectFileTransformerAction,
            IServiceAction<IAsFilePathXDocumentVisualStudioProjectFileSerializer> asFilePathXDocumentVisualStudioProjectFileSerializer)
        {
            var serviceAction = ServiceAction.New<IAsFilePathVisualStudioProjectFileSerializer>(() => services.AddAsFilePathVisualStudioProjectFileSerializer(
                visualStudioProjectFileTransformerAction,
                asFilePathXDocumentVisualStudioProjectFileSerializer));

            return serviceAction;
        }
    }
}
