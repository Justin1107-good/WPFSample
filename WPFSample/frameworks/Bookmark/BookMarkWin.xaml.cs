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
using WPFSample.frameworks.Bookmark.Models;

namespace WPFSample.frameworks.Bookmark
{
    /// <summary>
    /// BookMarkWin.xaml 的交互逻辑
    /// </summary>
    public partial class BookMarkWin : Window
    {
        public delegate void DataPassedDelegate(BookInfo data);

        private ObservableCollection<BookInfo> bookmarks = new ObservableCollection<BookInfo>();
        public BookMarkWin()
        {
            InitializeComponent();
            bookmarkListBox.ItemsSource = bookmarks;
        }
        private void AddBookmark_Click(object sender, RoutedEventArgs e)
        {
            CreateBook createBook = new CreateBook();

            createBook.DataPassedCallback = HandleDataFromChild;

            createBook.Show();
            //.Add(new Bookmark { Title = ".NET WPF", URL = "https://github.com/" });
            //bookmarkListBox.ItemsSource = bookmarks;

            // Open a dialog to get bookmark information (Title and URL)
            //AddBookmarkDialog dialog = new AddBookmarkDialog();
            //if (dialog.ShowDialog() == true)
            //{
            //    // Add the new bookmark to the ObservableCollection
            //    bookmarks.Add(new Bookmark { Title = dialog.BookmarkTitle, URL = dialog.BookmarkURL });
            //}
        }
        public void HandleDataFromChild(BookInfo data)
        {
            bookmarks.Add(new BookInfo { id = Guid.NewGuid(), bookName = data.bookName, bookContemt = data.bookContemt, bookPictrue = data.bookPictrue, bookTag = data.bookTag, bookUrl = data.bookUrl });
            bookmarkListBox.ItemsSource = bookmarks;
        }

        private void ShareMenu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                BookInfo book = bookmarkListBox.SelectedItem as BookInfo; 
                if (book != null)
                {
                    //BookInfo selectBook= boxItem as BookInfo;
                    MessageBox.Show($"分享成功！\n分享的内容：\n书签：{book.bookName}","提示",MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);

            return null;
        }

        private void MenuItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //  Click="ShareMenu_Click"
        }

        private void bookmarkListBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
    public class Bookmark
    {
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
