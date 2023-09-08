using Codeflix.Catalog.Application.Common;
using FluentAssertions;

namespace Codeflix.Catalog.UnitTests.Application.Common;
public class StorageFileNameTest
{
    [Fact()]
    [Trait("Application", "StorageName - Common")]
    public void CreateStorageNameForFile()
    {
        var exampleId = Guid.NewGuid();
        var exampleExtension = "mp4";
        var propertyName = "Video";

        var name = StorageFileName.Create(exampleId, propertyName, exampleExtension);

        name.Should().Be($"{exampleId}/{propertyName.ToLower()}.{exampleExtension}");
    }
}
