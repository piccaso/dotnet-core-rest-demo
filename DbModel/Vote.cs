using System;
using System.Collections.Generic;

namespace DbModel
{
    public partial class Vote
    {
        public int Id { get; set; }
        public bool Value { get; set; }
        public int FkArticle { get; set; }
        public DateTime Ts { get; set; }

        public Article FkArticleNavigation { get; set; }
    }
}
