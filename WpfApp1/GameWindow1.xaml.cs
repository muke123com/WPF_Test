using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// GameWindow1.xaml 的交互逻辑
    /// </summary>
    public partial class GameWindow1 : Window
    {
        Rectangle rect = new Rectangle();
        public GameWindow1()
        {
            InitializeComponent();
            rect.Fill = new SolidColorBrush(Colors.Red);
            rect.Width = 50;
            rect.Height = 50;
            rect.RadiusX = 5;
            rect.RadiusY = 5;
            Carrier.Children.Add(rect);
            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //创建移动动画
            Point p = e.GetPosition(Carrier);
            Storyboard storyboard = new Storyboard();
            //x轴
            DoubleAnimation doubleAnimation = new DoubleAnimation(
                Canvas.GetLeft(rect),
                p.X,
                new Duration(TimeSpan.FromMilliseconds(500))
            );
            Storyboard.SetTarget(doubleAnimation, rect);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            //Y轴
            doubleAnimation = new DoubleAnimation(
              Canvas.GetTop(rect),
              p.Y,
              new Duration(TimeSpan.FromMilliseconds(500))
            );
            Storyboard.SetTarget(doubleAnimation, rect);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation);
            //将动画动态加载进资源内
            if (!Resources.Contains("rectAnimation"))
            {
                Resources.Add("rectAnimation", storyboard);
            }
            //动画播放
            storyboard.Begin();
            /*首先获取鼠标点击点相对于Carrier中的坐标位置p，然后创建故事板storyboard和Double类型动画doubleAnimation，doubleAnimation有3个参数，
             * 分别代表开始值，结束值，动画经历时间，接着通过Storyboard.SetTarget()和Storyboard.SetTargetProperty()分别设置动画的目标及要修改
             * 的动画目标属性，再下来将doubleAnimation添加进storyboard中，这样重复两次分别实现X轴和Y轴方向的动画。当这些处理完后，最后还需要将
             * storyboard添加进Resources资源内，这样程序才能识别（将它去掉也同样可以通过编译，后面章节中才会用到它，这里只是提前做个说明）。一
             * 切就绪后，通过代码storyboard.Begin()来开始动画。*/
        }
    }
}
