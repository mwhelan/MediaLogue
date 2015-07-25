namespace Specs.Library.MediaLogue.TestData
{
    public class ShowStub
    {
        private readonly string _fullSeriesXmlFileName;
        private string _fullSeriesXml;

        public ShowStub(int id, string fullSeriesXmlFileName)
        {
            _fullSeriesXmlFileName = fullSeriesXmlFileName;
            Id = id;
        }

        public int Id { get; set; }

        public string FullSeriesXml
        {
            get
            {
                if (_fullSeriesXml == null)
                {
                    _fullSeriesXml = Utilities.GetContentsFromEmbeddedResource(_fullSeriesXmlFileName);
                }
                return _fullSeriesXml;
            }
        }
    }
}