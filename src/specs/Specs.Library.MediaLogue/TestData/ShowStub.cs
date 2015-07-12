namespace Specs.Library.MediaLogue.TestData
{
    public class ShowStub
    {
        private readonly string _fullSeriesXmlFileName;
        private string _fullSeriesXml;

        public ShowStub(int id, string fullSeriesXmlFileName)
        {
            this._fullSeriesXmlFileName = fullSeriesXmlFileName;
            this.Id = id;
        }

        public int Id { get; set; }

        public string FullSeriesXml
        {
            get
            {
                if (this._fullSeriesXml == null)
                {
                    this._fullSeriesXml = Utilities.GetContentsFromEmbeddedResource(this._fullSeriesXmlFileName);
                }
                return this._fullSeriesXml;
            }
        }
    }
}