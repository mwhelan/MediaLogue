using System.IO;

namespace Specs.Library.MediaLogue
{
    using Specs.Library.MediaLogue.TestData;

    public static class Utilities
    {
        public static string GetContentsFromEmbeddedResource(string resourceName)
        {
            var assembly = typeof (ShowData).Assembly;
            //var names = assembly.GetManifestResourceNames();
            resourceName = string.Format("Specs.Library.MediaLogue.TestData.Raw.{0}", resourceName);
            
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