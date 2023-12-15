using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSample.frameworks.DrapDrop
{
    public class DFileInfoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DFileInfo> _lvDatas;
        public ObservableCollection<DFileInfo> lvDatas
        {
            get { return _lvDatas; }
            set
            {
                _lvDatas = value;
                OnPropertyChanged(nameof(lvDatas));
            }
        }
        public DFileInfoViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Show()
        {
            lvDatas = new ObservableCollection<DFileInfo>
            {
                new DFileInfo{ id =1, fileName="2020日志", filePath="D:\\Logs\\2020日志.log", fileSize="2 KB" },
                new DFileInfo{ id =2, fileName="2021日志", filePath="D:\\Logs\\2021日志.log", fileSize="200 MB" },
                new DFileInfo{ id =3, fileName="2022日志", filePath="D:\\Logs\\2022日志.log", fileSize="50 KB" },
                new DFileInfo{ id =4, fileName="2023日志", filePath="D:\\Logs\\2023日志.log", fileSize="100 KB" },
                new DFileInfo{ id =5, fileName="fsdf", filePath="D:\\Logs\\fsdf.log", fileSize="1 KB" },
            };
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
