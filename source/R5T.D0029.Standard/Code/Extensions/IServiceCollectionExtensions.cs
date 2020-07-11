using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0001;
using R5T.D0010;
using R5T.D0017.Default;
using R5T.D0019.Default;
using R5T.D0021.Default;
using R5T.D0022.Default;
using R5T.D0029.Default;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.D0029.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // 0.
            var visualStudioProjectFileTransformerAction = services.AddVisualStudioProjectFileTransformerAction();
            var visualStudioProjectFileXDocumentPrettifierAction = services.AddVisualStudioProjectFileXDocumentPrettifierAction();

            // 1.
            var functionalVisualStudioProjectFileSerializationModifierAction = services.AddFunctionalVisualStudioProjectFileSerializationModifierAction(
                stringlyTypedPathOperatorAction);
            var relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction = services.AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializerAction(
                nowUtcProviderAction);

            // 2.
            var xDocumentVisualStudioProjectFileSerializerAction = services.AddXDocumentVisualStudioProjectFileSerializerAction(
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                messageSinkAction,
                visualStudioProjectFileXDocumentPrettifierAction);

            services.AddVisualStudioProjectFileSerializer(
                visualStudioProjectFileTransformerAction,
                xDocumentVisualStudioProjectFileSerializerAction);

            return services;
        }

        public static IServiceCollection AddAsFilePathVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // 0.
            var visualStudioProjectFileTransformerAction = services.AddVisualStudioProjectFileTransformerAction();
            var visualStudioProjectFileXDocumentPrettifierAction = services.AddVisualStudioProjectFileXDocumentPrettifierAction();

            // 1.
            var functionalVisualStudioProjectFileSerializationModifierAction = services.AddFunctionalVisualStudioProjectFileSerializationModifierAction(
                stringlyTypedPathOperatorAction);
            var relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction = services.AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializerAction(
                nowUtcProviderAction);

            // 2.
            var asFilePathXDocumentVisualStudioProjectFileSerializer = services.AddAsFilePathXDocumentVisualStudioProjectFileSerializerAction(
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                messageSinkAction,
                visualStudioProjectFileXDocumentPrettifierAction);                

            services.AddAsFilePathVisualStudioProjectFileSerializerAction(
                visualStudioProjectFileTransformerAction,
                asFilePathXDocumentVisualStudioProjectFileSerializer);

            return services;
        }
    }
}
