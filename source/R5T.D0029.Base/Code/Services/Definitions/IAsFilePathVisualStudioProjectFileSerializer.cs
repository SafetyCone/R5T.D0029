using System;
using System.Threading.Tasks;

using R5T.T0002;
using R5T.T0064;


namespace R5T.D0029
{
    /// <summary>
    /// Allows serializing a <see cref="IVisualStudioProjectFile"/> to one path, while allowing the file to think it's being serialized to a different path (for determining any project-reference project file relative paths).
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IAsFilePathVisualStudioProjectFileSerializer : IServiceDefinition
    {
        Task SerializeAsync(string actualfilePath, string asFilePath, IVisualStudioProjectFile visualStudioProjectFile, bool overwrite = true);
    }
}
