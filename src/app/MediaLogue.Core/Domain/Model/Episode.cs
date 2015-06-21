﻿using System;
using System.Collections.Generic;

namespace MediaLogue.Core.Domain.Model
{
    /// <summary>
    /// Entity describing an episode of a <see cref="Show" />show.
    /// </summary>
    public class Episode : Entity
    {
        public Episode(int id) 
            : base(id) { }

        /// <summary>
        /// This episode's season id.
        /// </summary>
        public int? SeasonId { get; set; }

        /// <summary>
        /// This episode's season number.
        /// </summary>
        public int? SeasonNumber { get; set; }

        /// <summary>
        /// This episode's number in the appropriate season.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Main language spoken in the episode.
        /// </summary>
        public Language? Language { get; set; }

        /// <summary>
        /// This episode's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A short description of the episode.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Path of the episode thumbnail
        /// </summary>
        public string ThumbRemotePath { get; set; }

        /// <summary>
        /// Director of the episode.
        /// </summary>
        public IReadOnlyCollection<string> Directors { get; set; }

        /// <summary>
        /// Writers(s) of the episode.
        /// </summary>
        public IReadOnlyCollection<string> Writers { get; set; }

        /// <summary>
        /// A list of guest stars.
        /// </summary>
        public IReadOnlyCollection<string> GuestStars { get; set; }

        /// <summary>
        /// The date of the first time this episode has aired.
        /// </summary>
        public DateTime? FirstAired { get; set; }

        /// <summary>
        /// Average rating as shown on IMDb.
        /// </summary>
        public double? Rating { get; set; }

        /// <summary>
        /// Amount of votes cast.
        /// </summary>
        public int? RatingCount { get; set; }

        /// <summary>
        /// Timestamp of the last update to this episode.
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Width dimension of the thumbnail in pixels;
        /// </summary>
        public int? ThumbWidth { get; set; }

        /// <summary>
        /// Height dimension of the thumbnail in pixels.
        /// </summary>
        public int? ThumbHeight { get; set; }
    }
}