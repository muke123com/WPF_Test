using System;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Loading.xaml 的交互逻辑
    /// </summary>
    public partial class Loading : Window
    {
        private String baseUrl = "http://47.92.68.251:3000/douban/book/series?seriesId=";
        private String url;
        private String filePath = "F:/json.json";
        public Loading()
        {
            InitializeComponent();
            
        }

        private void Loading_Data(object sender, RoutedEventArgs e)
        {
            url = GetUrl(5);
            String fileText = "";
            //获取服务器内容
            fileText += ServerData.GetServerData(GetUrl(1));
            fileText += ServerData.GetServerData(GetUrl(2));
            fileText += ServerData.GetServerData(GetUrl(3));
            //写入本地文件
            LocalData.WriteLocalData(filePath, fileText);
            Loading_Text.Text = "载入数据中。。。";
            //Load_Ready();
        }

        private void Load_Ready()
        {
            //Loading_Text.Text = "载入完成";
            MainWindow main = new MainWindow();
            //this.Close();
            //main.Show();
        }

        public String GetUrl(int seriesId)
        {
            String newUrl = baseUrl + seriesId;
            return newUrl;
        }
    }
}
