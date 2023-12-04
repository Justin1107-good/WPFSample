using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFSample.frameworks.Bookmark.Models
{
    public class BookInfo
    {
        public Guid id { get; set; }
        public string bookName { get; set; }
        public string bookContemt { get; set; }
        public string bookPictrue { get; set; }
        public string bookTag { get; set; }
        public string bookUrl { get; set; }
    }
}
