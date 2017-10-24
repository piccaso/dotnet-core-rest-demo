using System;
using System.Collections.Generic;

namespace DbModel
{
    public partial class ArticleGroup
    {
        public ArticleGroup()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }

        public ICollection<Article> Article { get; set; }
    }
}
