namespace Specs.Library.MediaLogue.TestData
{
    public static class Const
    {
        public static class Urls
        {
            public static string Tvdb_GetShow(int id)
            {
                return string.Format("api/tvdb/{0}", id);
            }
        }
    }
}