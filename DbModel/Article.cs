using System;
using System.Collections.Generic;

namespace DbModel
{
    public partial class Article
    {
        public Article()
        {
            Vote = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public int FkGroup { get; set; }
        public string SourceUrl { get; set; }
        public bool ArticleIsTrue { get; set; }
        public int FkScreenshot { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public int? MetricsAlteration { get; set; }
        public bool? MetricsTrue { get; set; }
        public int? FbShares { get; set; }
        public int? FbLikes { get; set; }
        public int? FbComments { get; set; }
        public int? TwRetweets { get; set; }
        public int? TwLikes { get; set; }

        public ArticleGroup FkGroupNavigation { get; set; }
        public Image FkScreenshotNavigation { get; set; }
        public ICollection<Vote> Vote { get; set; }
    }
}
