using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFSample.frameworks.Bookmark
{
    /// <summary>
    /// BookMarkWin.xaml 的交互逻辑
    /// </summary>
    public partial class BookMarkWin : Window
    {
        private ObservableCollection<Bookmark> bookmarks = new ObservableCollection<Bookmark>();
        public BookMarkWin()
        {
            InitializeComponent();
            bookmarkListBox.ItemsSource = bookmarks;
        }
        private void AddBookmark_Click(object sender, RoutedEventArgs e)
        {
            bookmarks.Add(new Bookmark { Title = ".NET WPF", URL = "https://github.com/" });
            bookmarkListBox.ItemsSource = bookmarks;

            // Open a dialog to get bookmark information (Title and URL)
            //AddBookmarkDialog dialog = new AddBookmarkDialog();
            //if (dialog.ShowDialog() == true)
            //{
            //    // Add the new bookmark to the ObservableCollection
            //    bookmarks.Add(new Bookmark { Title = dialog.BookmarkTitle, URL = dialog.BookmarkURL });
            //}
        }
    }
    public class Bookmark
    {
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
