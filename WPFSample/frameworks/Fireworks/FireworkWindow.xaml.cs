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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFSample.frameworks.Fireworks
{
    /// <summary>
    /// FireworkWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FireworkWindow : Window
    {
        private Random random = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        public FireworkWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CreateFirework();
        }
        /// <summary>
        /// 每个烟花都有一个向上的动画
        /// </summary>
        //private void CreateFirework()
        //{
        //    // 创建椭圆作为烟花
        //    Ellipse firework = new Ellipse
        //    {
        //        Width = 10,
        //        Height = 10,
        //        Fill = new SolidColorBrush(RandomColor())
        //    };

        //    // 设置烟花的起始位置
        //    Canvas.SetLeft(firework, random.Next((int)fireworksCanvas.ActualWidth - 10));
        //    Canvas.SetTop(firework, fireworksCanvas.ActualHeight);

        //    // 将烟花添加到Canvas上
        //    fireworksCanvas.Children.Add(firework);

        //    // 创建动画
        //    DoubleAnimation verticalAnimation = new DoubleAnimation
        //    {
        //        To = -random.Next(100, 300),
        //        Duration = TimeSpan.FromSeconds(2),
        //        FillBehavior = FillBehavior.Stop
        //    };

        //    // 配置动画完成时的处理
        //    verticalAnimation.Completed += (s, e) =>
        //    {
        //        fireworksCanvas.Children.Remove(firework);
        //    };

        //    // 启动动画
        //    firework.BeginAnimation(Canvas.TopProperty, verticalAnimation);
        //}
        //private void CreateFirework()
        //{
        //    // 创建椭圆作为烟花
        //    Ellipse firework = new Ellipse
        //    {
        //        Width = 10,
        //        Height = 10,
        //        Fill = new SolidColorBrush(RandomColor())
        //    };

        //    // 设置烟花的起始位置
        //    double startX = random.Next((int)fireworksCanvas.ActualWidth - 10);
        //    double startY = fireworksCanvas.ActualHeight;

        //    Canvas.SetLeft(firework, startX);
        //    Canvas.SetTop(firework, startY);

        //    // 将烟花添加到Canvas上
        //    fireworksCanvas.Children.Add(firework);

        //    // 创建动画
        //    DoubleAnimation verticalAnimation = new DoubleAnimation
        //    {
        //        To = -random.Next(100, 300),
        //        Duration = TimeSpan.FromSeconds(2),
        //        FillBehavior = FillBehavior.Stop
        //    };

        //    DoubleAnimation horizontalAnimation = new DoubleAnimation
        //    {
        //        To = random.Next(-200, 200),
        //        Duration = TimeSpan.FromSeconds(2),
        //        FillBehavior = FillBehavior.Stop
        //    };

        //    // 配置动画完成时的处理
        //    verticalAnimation.Completed += (s, e) =>
        //    {
        //        fireworksCanvas.Children.Remove(firework);
        //    };

        //    // 启动动画
        //    firework.BeginAnimation(Canvas.TopProperty, verticalAnimation);
        //    firework.BeginAnimation(Canvas.LeftProperty, horizontalAnimation);
        //}


        #region 高级感的烟花 爆炸效果的烟花
        private void CreateFirework()
        {
            int particleCount = random.Next(50, 100);
            double startX = random.Next((int)fireworksCanvas.ActualWidth);
            double startY = random.Next((int)(fireworksCanvas.ActualHeight * 0.6), (int)fireworksCanvas.ActualHeight);

            for (int i = 0; i < particleCount; i++)
            {
                double angle = random.NextDouble() * 360;
                double distance = random.Next(100, 200);

                CreateParticle(startX, startY, angle, distance);
            }
        }
        private void CreateParticle(double startX, double startY, double angle, double distance)
        {
            Ellipse particle = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = new SolidColorBrush(RandomColor())
            };

            fireworksCanvas.Children.Add(particle);

            double radians = angle * Math.PI / 180;
            double endX = startX + distance * Math.Cos(radians);
            double endY = startY + distance * Math.Sin(radians);

            ParticleAnimation(particle, startX, startY, endX, endY);
        }
        private void ParticleAnimation(Ellipse particle, double startX, double startY, double endX, double endY)
        {
            Duration duration = TimeSpan.FromSeconds(1);

            DoubleAnimation animationX = new DoubleAnimation(startX, endX, duration);
            DoubleAnimation animationY = new DoubleAnimation(startY, endY, duration);

            Storyboard.SetTarget(animationX, particle);
            Storyboard.SetTarget(animationY, particle);

            Storyboard.SetTargetProperty(animationX, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(animationY, new PropertyPath(Canvas.TopProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);

            storyboard.Completed += (s, e) =>
            {
                fireworksCanvas.Children.Remove(particle);
            };

            storyboard.Begin();
        }
        #endregion
        private Color RandomColor()
        {
            return Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
        }
    }
}
