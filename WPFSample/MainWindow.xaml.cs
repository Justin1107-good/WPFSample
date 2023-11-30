using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TestModel> tvData;
        public MainWindow()
        {
            InitializeComponent();
            ReloadData();
            this._tv.ItemsSource = tvData;
        }
        void ReloadData()
        {
            tvData = new ObservableCollection<TestModel>
            {
                 new TestModel{ ID=1,Name="张三", tvData =new ObservableCollection<TestModel>{
                       new TestModel{ ID=2,Name="张李四" },
                       new TestModel{ ID=3,Name="张王五" },
                       new TestModel{ ID=4,Name="张马六" },
                       new TestModel{ ID=5,Name="张张善芬" },
                 } },
                  new TestModel{ ID=1,Name="张三", tvData =new ObservableCollection<TestModel>{
                       new TestModel{ ID=2,Name="张李四" },
                       new TestModel{ ID=3,Name="张王五" },
                       new TestModel{ ID=4,Name="张马六" },
                       new TestModel{ ID=5,Name="张张善芬" },
                 } },
            };
        }
    }
    public class TestModel : INotifyPropertyChanged
    {
        private int _ID;
        private string _Name;
        private ObservableCollection<TestModel> _tvData;
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ObservableCollection<TestModel> tvData
        {
            get { return _tvData; }
            set
            {
                _tvData = value;
                OnPropertyChanged(nameof(tvData));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
