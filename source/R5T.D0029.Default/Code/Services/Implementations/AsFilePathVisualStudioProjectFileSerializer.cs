using System;
using System.Threading.Tasks;

using R5T.D0019;
using R5T.D0021;
using R5T.T0002;
using R5T.T0004;


namespace R5T.D0029.Default
{
    public class AsFilePathVisualStudioProjectFileSerializer : IAsFilePathVisualStudioProjectFileSerializer
    {
        private IVisualStudioProjectFileTransformer VisualStudioProjectFileTransformer { get; }
        private IAsFilePathXDocumentVisualStudioProjectFileSerializer AsFilePathXDocumentVisualStudioProjectFileSerializer { get; }


        public AsFilePathVisualStudioProjectFileSerializer(
            IVisualStudioProjectFileTransformer visualStudioProjectFileTransformer,
            IAsFilePathXDocumentVisualStudioProjectFileSerializer asFilePathXDocumentVisualStudioProjectFileSerializer)
        {
            this.VisualStudioProjectFileTransformer = visualStudioProjectFileTransformer;
            this.AsFilePathXDocumentVisualStudioProjectFileSerializer = asFilePathXDocumentVisualStudioProjectFileSerializer;
        }

        public async Task SerializeAsync(string actualfilePath, string asFilePath, IVisualStudioProjectFile visualStudioProjectFile, bool overwrite = true)
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

            await this.AsFilePathXDocumentVisualStudioProjectFileSerializer.SerializeAsync(actualfilePath, asFilePath, xDocumentVisualStudioProjectFile, overwrite);
        }
    }
}
