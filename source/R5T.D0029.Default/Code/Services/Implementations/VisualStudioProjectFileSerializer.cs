using System;
using System.Threading.Tasks;

using R5T.D0019;
using R5T.D0021;
using R5T.T0002;
using R5T.T0004;using R5T.T0064;


namespace R5T.D0029.Default
{[ServiceImplementationMarker]
    public class VisualStudioProjectFileSerializer : IVisualStudioProjectFileSerializer,IServiceImplementation
    {
        private IVisualStudioProjectFileTransformer VisualStudioProjectFileTransformer { get; }
        private IXDocumentVisualStudioProjectFileSerializer XDocumentVisualStudioProjectFileSerializer { get; }



        public VisualStudioProjectFileSerializer(
            IVisualStudioProjectFileTransformer visualStudioProjectFileTransformer,
            IXDocumentVisualStudioProjectFileSerializer xDocumentVisualStudioProjectFileSerializer)
        {
            this.VisualStudioProjectFileTransformer = visualStudioProjectFileTransformer;
            this.XDocumentVisualStudioProjectFileSerializer = xDocumentVisualStudioProjectFileSerializer;
        }

        public async Task<IVisualStudioProjectFile> Deserialize(string projectFilePath)
        {
            var visualStudioProjectFile = await this.XDocumentVisualStudioProjectFileSerializer.Deserialize(projectFilePath);
            return visualStudioProjectFile;
        }

        public async Task Serialize(string projectFilePath, IVisualStudioProjectFile visualStudioProjectFile, bool overwrite = true)
        {
            var isXDocumentVisualStudioProjectFile = visualStudioProjectFile is XDocumentVisualStudioProjectFile;

            XDocumentVisualStudioProjectFile xDocumentVisualStudioProjectFile;
            if (isXDocumentVisualStudioProjectFile)
            {
                xDocumentVisualStudioProjectFile = visualStudioProjectFile as XDocumentVisualStudioProjectFile;
            }
            else
            {
                // If not, create a new XDocument Visual Studio Project File instance, then transform it into the input instance.
                xDocumentVisualStudioProjectFile = XDocumentVisualStudioProjectFile.New();

                await this.VisualStudioProjectFileTransformer.CopySourceToDestinationAsync(visualStudioProjectFile, xDocumentVisualStudioProjectFile);
            }

            await this.XDocumentVisualStudioProjectFileSerializer.Serialize(projectFilePath, xDocumentVisualStudioProjectFile, overwrite);
        }
    }
}
