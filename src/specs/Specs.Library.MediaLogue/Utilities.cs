using System.IO;
using Specs.Library.MediaLogue.TestData;

namespace Specs.Library.MediaLogue
{
    public static class Utilities
    {
        public static string GetContentsFromEmbeddedResource(string resourceName)
        {
            var assembly = typeof (ShowData).Assembly;
            //var names = assembly.GetManifestResourceNames();
            
            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException();
            }

            string contents;
            using (var reader = new StreamReader(stream))
            {
                contents = reader.ReadToEnd();
            }
            return contents;
        }
    }
}