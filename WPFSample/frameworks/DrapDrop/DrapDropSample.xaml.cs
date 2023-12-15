using System;
using System.Collections.Generic;
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

namespace WPFSample.frameworks.DrapDrop
{
    /// <summary>
    /// DrapDropSample.xaml 的交互逻辑
    /// </summary>
    public partial class DrapDropSample : Window
    {
        private DFileInfoViewModel _vm;
        private Point startPoint;
        public DrapDropSample()
        {
            InitializeComponent();
            _vm = new DFileInfoViewModel();
            _vm.Show();
            this.DataContext = _vm;
        }

        private void lv_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            ListView lv = new ListView();
            if (lv != null)
            {
                ListViewItem draggedItem = GetListViewItem((DependencyObject)e.OriginalSource);
                if (draggedItem != null)
                {
                    DFileInfo fileInfo = draggedItem.DataContext as DFileInfo;
                    string[] files = new string[] { fileInfo.filePath };

                    string format = DataFormats.FileDrop;
                    DataObject dataObject = new DataObject(format, files);
                     DragDrop.DoDragDrop(lv, dataObject, DragDropEffects.Copy); 
                }
            }

        }
        //private void OnDrop(object sender, DragEventArgs e)
        //{
        //    Point dropPoint = e.GetPosition(null);

        //    // 判断是否是合法的拖放操作
        //    if (Math.Abs(dropPoint.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
        //        Math.Abs(dropPoint.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
        //    {
        //        return;
        //    }

        //    // 获取拖放的文件路径
        //    if (e.Data.GetDataPresent(typeof(DFileInfo)))
        //    {
        //        DFileInfo file = (DFileInfo)e.Data.GetData(typeof(DFileInfo));
        //        string[] files = new string[] { file.filePath };
        //        // 在桌面上生成文件
        //        foreach (string filePath in files)
        //        {
        //            string fileName = System.IO.Path.GetFileName(filePath);
        //            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //            string destinationPath = System.IO.Path.Combine(desktopPath, fileName);

        //            // 复制文件
        //            System.IO.File.Copy(filePath, destinationPath, true);
        //        }
        //    }
        //}

        private ListViewItem GetListViewItem(DependencyObject obj)
        {
            while (obj != null && !(obj is ListViewItem))
            {
                obj = VisualTreeHelper.GetParent(obj);
            }

            return obj as ListViewItem;
        }
    }
}

