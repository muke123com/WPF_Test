using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileText;

        public MainWindow()
        {
            InitializeComponent();

            ///读取文件
            FileInfo file = new FileInfo("F:/json.json");
            StreamReader sf = file.OpenText();
            fileText = sf.ReadLine();

            ///listbox数据显示
            Item_List.ItemsSource = Items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string message = "Quit the application?";
            string title = "System Information";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage img = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(
            message, title, button, img);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true; // 取消退出
            }
        }

        private List<BooksInfo> Items
        {
            get
            {

                JObject bookSeries = GetBookData(fileText); ///获取json数据
                int count = (int)bookSeries["count"];
                List<BooksInfo> result = new List<BooksInfo>();
                for(int i = 0; i < count; i++)
                {
                    BooksInfo book = new BooksInfo();
                    String bookTitle = bookSeries["books"][i]["title"].ToString(); ///图书标题
                    String bookPublisher = bookSeries["books"][i]["publisher"].ToString(); ///
                    var bookAuthorArray = bookSeries["books"][i]["author"]; ///作者数组
                    String bookAuthor = "";
                    foreach(String author in bookAuthorArray)
                    {
                        bookAuthor += author + " ";
                    }
                    book.Title = bookTitle;
                    book.Publisher = bookPublisher;
                    book.Author = bookAuthor;
                    result.Add(book);

                }
                return result;
            }
        }

        private void Selected_Item(object sender, SelectionChangedEventArgs e)
        {
            
            Text_Show.Text = e.ToString();
            
        }

        public JObject GetBookData(String fileText)
        {
            var BookInfo = JsonConvert.DeserializeObject<JObject>(fileText);
            
            return BookInfo;
        }

        private void Go_CarWindow(object sender, RoutedEventArgs e)
        {
            CarWindow car = new CarWindow();
            car.Show();
        }
    }

    public struct Series
    {
        public int count;
        public int start;
        public int total;
        public List<BooksInfo> books;
    }

    public class BooksInfo
    {
        public String Title { set; get; }
        public String Author { set; get; }
        public String Publisher { set; get; }
    }
}

