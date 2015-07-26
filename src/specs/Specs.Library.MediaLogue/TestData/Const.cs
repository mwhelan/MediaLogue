namespace Specs.Library.MediaLogue.TestData
{
    public static class Const
    {
        public static class Urls
        {
            public static class Shows
            {
                public static string Get(int id)
                {
                    return string.Format("api/shows/{0}", id);
                }
            }

            public static class Tvdb
            {
                public static string Get(int id)
                {
                    return string.Format("api/tvdb/{0}", id);
                }
            }
        }
    }
}