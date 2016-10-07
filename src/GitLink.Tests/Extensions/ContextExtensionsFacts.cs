using GitLink.Providers;
using NUnit.Framework;

namespace GitLink.Tests.Extensions {
    public class ContextExtensionsFacts {
        [TestFixture]
        public class TheGetRelativePathMethod {
            [TestCase]
            public void ReturnsRelativePathWithDirectoryDownwards() {
                var context = new Context(new ProviderManager()) {
                    SolutionDirectory = @"c:\source\GitLink"
                };

                var relativePath = context.GetRelativePath(@"c:\source\GitLink\src\subdir1\somefile.cs");

                Assert.AreEqual(@"src\subdir1\somefile.cs", relativePath);
            }

            [TestCase]
            public void ReturnsRelativePathWithDirectoryUpwards() {
                var context = new Context(new ProviderManager()) {
                    SolutionDirectory = @"c:\source\GitLink"
                };

                var relativePath = context.GetRelativePath(@"c:\source\catel\src\subdir1\somefile.cs");

                Assert.AreEqual(@"..\catel\src\subdir1\somefile.cs", relativePath);
            }
        }
    }
}