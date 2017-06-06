using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Loading.xaml 的交互逻辑
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            InitializeComponent();
            
        }

        private void Loading_Data(object sender, RoutedEventArgs e)
        {
            Loading_Text.Text = "载入数据中。。。";
            Load_Ready();
        }

        private void Load_Ready()
        {
            //Loading_Text.Text = "载入完成";
            MainWindow main = new MainWindow();
            //this.Close();
            //main.Show();
        }

    }
}
