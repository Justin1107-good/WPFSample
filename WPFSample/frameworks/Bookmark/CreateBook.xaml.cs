using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
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
    /// CreateBook.xaml 的交互逻辑
    /// </summary>
    public partial class CreateBook : Window
    {// 定义委托变量
        public BookMarkWin.DataPassedDelegate DataPassedCallback;
        public CreateBook()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            // 获取子窗体数据
            Models.BookInfo data = GetDataFromChild();

            // 调用委托传递数据给父窗体
            DataPassedCallback?.Invoke(data);

            // 关闭子窗体
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private BookInfo GetDataFromChild()
        {
            Guid guid = Guid.NewGuid();
            string bookName = this.TextBoxBookName.Text;
            string bookContent = GetRichTextBoxText(RichTXBookContent);
            ImageSource imageSource = this.ImageBook.Source;
            string image = string.Empty;
            if (imageSource != null)
            {
                image = imageSource.ToString();
            }

            string bookTag = this.BookTag.Content.ToString();
            string url = this.TextBoxBookUrl.Text;
            return new BookInfo { id = guid, bookName = bookName, bookContemt = bookContent, bookPictrue = image, bookTag = bookTag, bookUrl = url };
        }
        private string GetRichTextBoxText(RichTextBox richTextBox)
        {
            // 使用TextRange类来获取RichTextBox的文本
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            // 将文本从TextRange转换为字符串
            StringBuilder sb = new StringBuilder();
            sb.Append(textRange.Text);

            return sb.ToString();
        }

        private void ImageBook_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                string path = "~/Images/";
                string pathSave = "~/Images/";
                if (!string.IsNullOrEmpty(selectedFilePath.Trim()))
                {
                    path = System.IO.Path.Combine(path, selectedFilePath);
                }

                Regex r = new Regex("\\|/", RegexOptions.None);
                path = r.Replace(path, System.IO.Path.DirectorySeparatorChar.ToString());

               string name= GetRenewName(path, System.IO.Path.GetFileName(selectedFilePath));

                path = System.IO.Path.Combine(pathSave, name);
                BuildPath(path);

                // 构建相对 URI
                //Uri relativeUri = new Uri($"/Images/{System.IO.Path.GetFileName(selectedFilePath)}", UriKind.Relative);

                // 构建完整 URI
                //Uri uri = new Uri("pack://application:,,,/" + relativeUri.ToString());
                // 将选择的文件保存到 Images 文件夹下
                //using (FileStream fs = new FileStream(uri.LocalPath, FileMode.Create))
                //{
                //    File.Copy(selectedFilePath, "D:\\ComPany\\Skycore\\IT_RD\\Exercise_Project\\dotnet\\wpf\\WPFSample\\WPFSample\\Images\\nullp222.png");
                //}

                //String savePath = $"pack://application:,,,/Images/{System.IO.Path.GetFileName(selectedFilePath)}";
                //// 将选择的文件上传到项目目录（请替换为你的项目目录）
                //string destinationPath =System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", System.IO.Path.GetFileName(selectedFilePath));
                //System.IO.File.Copy(selectedFilePath, destinationPath, true);

                // 显示图片

                // 显示图片

                //BitmapImage bitmapImage = new BitmapImage(uri);
                //ImageBook.Source = bitmapImage;
            }
        }
        private string GetRenewName(string path, string fileName)
        {
            string strFullPath = string.Empty;
            string strNewName = fileName;
            //文件名，不含后缀
            string fileNameNoExt = fileName;
            //文件后缀名，包含“.”
            string fileExtension = string.Empty;
            int i = fileName.LastIndexOf('.');
            if (i > 0)
            {
                //文件名，不含后缀，Substring截取时不包括endindex，此处不需减1
                fileNameNoExt = fileName.Substring(0, i);
                //文件后缀
                fileExtension = fileName.Substring(i, fileName.Length - i);
            }
            //用GUID作为文件名
            strNewName = string.Format("{0}_{1}{2}",
                         DateTime.Now.ToString("yyyy-MM-dd"),
                         Guid.NewGuid(), fileExtension);
            return strNewName;
        }
        private static string BuildPath(string path)
        {
            //如果有path就转换为绝对路径
            if (!System.IO.Path.IsPathRooted(path))
            {
                path = HttpContext.Current.Server.MapPath(path);
            }
            //如果没有这个文件夹就创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return System.IO.Path.GetFullPath(path);
        }
    }
}
