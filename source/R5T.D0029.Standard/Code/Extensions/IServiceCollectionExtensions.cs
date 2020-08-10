using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0001;
using R5T.D0010;
using R5T.D0017;
using R5T.D0017.Default;
using R5T.D0019;
using R5T.D0019.Default;
using R5T.D0021;
using R5T.D0021.Default;
using R5T.D0022;
using R5T.D0022.Default;
using R5T.D0029.Default;
using R5T.D0034.Default;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.D0029.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static (
    IServiceAction<IVisualStudioProjectFileSerializer> main,
    IServiceAction<IFunctionalVisualStudioProjectFileSerializationModifier> functionalVisualStudioProjectFileSerializationModifierAction,
    IServiceAction<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer> relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
    IServiceAction<IVisualStudioProjectFileTransformer> visualStudioProjectFileTransformerAction,
    IServiceAction<IVisualStudioProjectFileXDocumentPrettifier> visualStudioProjectFileXDocumentPrettifierAction,
    IServiceAction<IXDocumentVisualStudioProjectFileSerializer> xDocumentVisualStudioProjectFileSerializerAction
    )
    AddVisualStudioProjectFileSerializerAction(this IServiceCollection services,
    IServiceAction<INowUtcProvider> nowUtcProviderAction,
    IServiceAction<IMessageSink> messageSinkAction,
    IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // 0.
            var visualStudioProjectFileTransformerAction = services.AddVisualStudioProjectFileTransformerAction();
            var visualStudioProjectFileXDocumentPrettifierAction = services.AddVisualStudioProjectFileXDocumentPrettifierAction();

            // 1.
            var visualStudioProjectFileProjectReferencePathProviderAction = services.AddVisualStudioProjectFileProjectReferencePathProviderAction(
                stringlyTypedPathOperatorAction);
            var relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction = services.AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializerAction(
                nowUtcProviderAction);

            // 2.
            var functionalVisualStudioProjectFileSerializationModifierAction = services.AddFunctionalVisualStudioProjectFileSerializationModifierAction(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileProjectReferencePathProviderAction);
            
            // 3.
            var xDocumentVisualStudioProjectFileSerializerAction = services.AddXDocumentVisualStudioProjectFileSerializerAction(
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                messageSinkAction,
                visualStudioProjectFileXDocumentPrettifierAction);

            var visualStudioProjectFileSerializerAction = services.AddVisualStudioProjectFileSerializerAction(
                visualStudioProjectFileTransformerAction,
                xDocumentVisualStudioProjectFileSerializerAction);

            return (
                visualStudioProjectFileSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                visualStudioProjectFileTransformerAction,
                visualStudioProjectFileXDocumentPrettifierAction,
                xDocumentVisualStudioProjectFileSerializerAction);
        }

        public static IServiceCollection AddVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var visualStudioProjectFileSerializerAction = services.AddVisualStudioProjectFileSerializerAction(
                nowUtcProviderAction,
                messageSinkAction,
                stringlyTypedPathOperatorAction);

            services.Run(visualStudioProjectFileSerializerAction.main);

            return services;
        }

        public static (
            IServiceAction<IAsFilePathVisualStudioProjectFileSerializer> main,
            IServiceAction<IFunctionalVisualStudioProjectFileSerializationModifier> functionalVisualStudioProjectFileSerializationModifierAction,
            IServiceAction<IRelativePathsXDocumentVisualStudioProjectFileStreamSerializer> relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
            IServiceAction<IVisualStudioProjectFileTransformer> visualStudioProjectFileTransformerAction,
            IServiceAction<IVisualStudioProjectFileXDocumentPrettifier> visualStudioProjectFileXDocumentPrettifierAction,
            IServiceAction<IAsFilePathXDocumentVisualStudioProjectFileSerializer> xDocumentVisualStudioProjectFileSerializerAction
            )
            AddAsFilePathVisualStudioProjectFileSerializerAction(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // 0.
            var visualStudioProjectFileTransformerAction = services.AddVisualStudioProjectFileTransformerAction();
            var visualStudioProjectFileXDocumentPrettifierAction = services.AddVisualStudioProjectFileXDocumentPrettifierAction();

            // 1.
            var visualStudioProjectFileProjectReferencePathProviderAction = services.AddVisualStudioProjectFileProjectReferencePathProviderAction(
                stringlyTypedPathOperatorAction);
            var relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction = services.AddRelativePathsXDocumentVisualStudioProjectFileStreamSerializerAction(
                nowUtcProviderAction);

            // 2.
            var functionalVisualStudioProjectFileSerializationModifierAction = services.AddFunctionalVisualStudioProjectFileSerializationModifierAction(
                stringlyTypedPathOperatorAction,
                visualStudioProjectFileProjectReferencePathProviderAction);

            // 3.
            var xAsFilePathDocumentVisualStudioProjectFileSerializerAction = services.AddAsFilePathXDocumentVisualStudioProjectFileSerializerAction(
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                messageSinkAction,
                visualStudioProjectFileXDocumentPrettifierAction);

            var asFilePathVisualStudioProjectFileSerializerAction = services.AddAsFilePathVisualStudioProjectFileSerializerAction(
                visualStudioProjectFileTransformerAction,
                xAsFilePathDocumentVisualStudioProjectFileSerializerAction);

            return (
                asFilePathVisualStudioProjectFileSerializerAction,
                functionalVisualStudioProjectFileSerializationModifierAction,
                relativePathsXDocumentVisualStudioProjectFileStreamSerializerAction,
                visualStudioProjectFileTransformerAction,
                visualStudioProjectFileXDocumentPrettifierAction,
                xAsFilePathDocumentVisualStudioProjectFileSerializerAction);
        }

        public static IServiceCollection AddAsFilePathVisualStudioProjectFileSerializer(this IServiceCollection services,
            IServiceAction<INowUtcProvider> nowUtcProviderAction,
            IServiceAction<IMessageSink> messageSinkAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var asFilePathVisualStudioProjectFileSerializerAction = services.AddAsFilePathVisualStudioProjectFileSerializerAction(
                nowUtcProviderAction,
                messageSinkAction,
                stringlyTypedPathOperatorAction);

            services.Run(asFilePathVisualStudioProjectFileSerializerAction.main);

            return services;
        }
    }
}
