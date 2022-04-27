using System;

using R5T.D0013;
using R5T.T0002;
using R5T.T0064;


namespace R5T.D0029
{
    [ServiceDefinitionMarker]
    public interface IVisualStudioProjectFileSerializer : IFileSerializer<IVisualStudioProjectFile>, IServiceDefinition
    {
    }
}
