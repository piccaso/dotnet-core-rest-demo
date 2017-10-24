using System;
using System.Collections.Generic;

namespace DbModel
{
    public partial class Image
    {
        public Image()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }

        public ICollection<Article> Article { get; set; }
    }
}
