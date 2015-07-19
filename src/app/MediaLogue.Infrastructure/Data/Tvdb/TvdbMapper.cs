using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Model;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    public class TvdbMapper : ITvdbMapper
    {
        private readonly EpisodeParseService _episodeParseService = new EpisodeParseService();

        /// <summary>
        /// Parse series xml document and returns null if xml is not valid
        /// </summary>
        /// <param name="seriesRaw">Series xml document</param>
        /// <returns>Returns the parsed series or null if xml is not valid</returns>
        public Show MapShowFrom(string seriesRaw)
        {
            if (seriesRaw == null) throw new ArgumentNullException(seriesRaw);

            // If xml cannot be created return null
            XDocument doc;
            try
            {
                doc = XDocument.Parse(seriesRaw);
            }
            catch (XmlException e)
            {
                throw new Exception("Show string cannot be parsed into an XML document.", e);
            }

            // If Data element is missing return null
            var seriesXml = doc.Element("Data");
            if (seriesXml == null) throw new Exception("Error while parsing Show XML document. Xml element 'Data' is missing.");

            // If Series element is missing return null
            var seriesMetaXml = seriesXml.Element("Series");
            if (seriesMetaXml == null) throw new Exception("Error while parsing Show XML document. Xml Element 'Series' is missing.");

            // Parsing series metadata...
            // If parsing failed a ParseException will be thrown in the Parse method.
            var series = Parse(seriesMetaXml);

            // Parsing episodes
            series.Episodes = seriesXml.Elements("Episode")
                .Select(episodeXml => _episodeParseService.Parse(episodeXml))
                .Where(episode => episode != null)
                .ToList();

            return series;
        }

        /// <summary>
        /// Parse series metadata as xml element and returns null if xml is not valid (series has no id) 
        /// </summary>
        /// <param name="seriesXml">Series metadata as xml element</param>
        /// <param name="isSearchElement"></param>
        /// <returns>Returns the successfully parsed series</returns>
        public Show Parse(XElement seriesXml, bool isSearchElement = false)
        {
            if (seriesXml == null) throw new ArgumentNullException("seriesXml");

            // If series has no id throw ParseException
            var id = seriesXml.ElementAsInt("id");
            if (!id.HasValue) throw new Exception("Error while parsing a series xml element. Id is missing.");

            var series = new Show()
            {
                Id = id.Value,
                ImdbId = seriesXml.ElementAsString("IMDB_ID"),
                Title = seriesXml.ElementAsString("SeriesName", true),
                Network = seriesXml.ElementAsString("Network"),
                Description = seriesXml.ElementAsString("Overview", true),
                Rating = seriesXml.ElementAsDouble("Rating"),
                RatingCount = seriesXml.ElementAsInt("RatingCount"),
                Runtime = seriesXml.ElementAsInt("Runtime"),
                BannerRemotePath = seriesXml.ElementAsString("banner"),
                FanartRemotePath = seriesXml.ElementAsString("fanart"),
                LastUpdated = seriesXml.ElementFromEpochToDateTime("lastupdated"),
                PosterRemotePath = seriesXml.ElementAsString("poster"),
                FirstAired = seriesXml.ElementAsDateTime("FirstAired"),
                AirTime = seriesXml.ElementAsTimeSpan("Airs_Time"),
                AirDay = seriesXml.ElementAsEnum<Frequency>("Airs_DayOfWeek"),
                Status = seriesXml.ElementAsEnum<Status>("Status"),
                ContentRating = seriesXml.ElementAsString("ContentRating").ToContentRating(),
                Genres = seriesXml.ElementAsString("Genre").SplitByPipe()
            };

            if (series.FirstAired.HasValue)
            {
                series.Title = series.Title.Replace(string.Format(" ({0})", series.FirstAired.Value.Year), "");
            }

            return series;
        }
    }
    public class EpisodeParseService 
    {
        /// <summary>
        /// Parse episode xml document as string and return null if xml is not valid
        /// </summary>
        /// <param name="episodeRaw">Episode xml document as string</param>
        /// <returns>Return parsed episode or null if xml is not valid</returns>
        public Episode Parse(string episodeRaw)
        {
            if (episodeRaw == null) throw new ArgumentNullException("episodeRaw");

            // If xml cannot be created return null
            XDocument doc;
            try
            {
                doc = XDocument.Parse(episodeRaw);
            }
            catch (XmlException e)
            {
                throw new Exception("Episode string cannot be parsed into an XML document.", e);
            }

            // If Data element is missing return null
            var dataXml = doc.Element("Data");
            if (dataXml == null) throw new Exception("Error while parsing Episode XML document. Xml Element 'Data' is missing.");

            // If episode element is missing return null
            var episodeXml = dataXml.Element("Episode");
            if (episodeXml == null) throw new Exception("Error while parsing Episode XML document. Xml Element 'Episode' is missing.");

            return Parse(episodeXml);
        }

        /// <summary>
        /// Parse episode xml element and returns null if xml is not valid
        /// </summary>
        /// <param name="episodeXml">Episode xml element</param>
        /// <returns>Return parsed episode or null if xml is not valid</returns>
        public Episode Parse(XElement episodeXml)
        {
            if (episodeXml == null) throw new ArgumentNullException("episodeXml");

            // If episode has no id or number skip parsing and return null
            var id = episodeXml.ElementAsInt("id");
            if (!id.HasValue) throw new Exception("Error while parsing an episode xml element. Id is missing.");

            var number = episodeXml.ElementAsInt("EpisodeNumber");
            if (!number.HasValue) throw new Exception("Error while parsing an episode xml element. EpisodeNumber is missing.");

            return new Episode()
            {
                Id = id.Value,
                SeasonId = episodeXml.ElementAsInt("seasonid"),
                SeasonNumber = episodeXml.ElementAsInt("SeasonNumber"),
                FirstAired = episodeXml.ElementAsDateTime("FirstAired"),
                Number = number.Value,
                Title = episodeXml.ElementAsString("EpisodeName"),
                Directors = episodeXml.ElementAsString("Director").SplitByPipe(),
                GuestStars = episodeXml.ElementAsString("GuestStars").SplitByPipe(),
                Description = episodeXml.ElementAsString("Overview", true),
                Rating = episodeXml.ElementAsDouble("Rating"),
                Writers = episodeXml.ElementAsString("Writer").SplitByPipe(),
                RatingCount = episodeXml.ElementAsInt("RatingCount"),
                ThumbWidth = episodeXml.ElementAsInt("thumb_width"),
                ThumbHeight = episodeXml.ElementAsInt("thumb_height"),
                ThumbRemotePath = episodeXml.ElementAsString("filename"),
                LastUpdated = episodeXml.ElementFromEpochToDateTime("lastupdated")
            };
        }
    }

}
