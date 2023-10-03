using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeProgram
{
    class ImageItem
    {
        public string Url { get; set; }
        public string Author { get; set; }

        public ImageItem(string url, string author)
        {
            Url = url;
            Author = author;
        }
        public override string ToString()
        {
            return Author;
        }

    }
}
