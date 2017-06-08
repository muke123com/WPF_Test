using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private String url = "http://47.92.68.251:3000/douban/book/series?seriesId=1";
        private String filePath = "F:/json.json";
        private String fileText; //数据json字符串
        private JArray BookInfoList; //图书列表数组
        LocalData localData = new LocalData();

        public MainWindow()
        {
            InitializeComponent();

            //获取服务器内容
            fileText = ServerData.GetServerData(url);
            //写入本地文件
            LocalData.WriteLocalData(filePath, fileText);
            //获取本地文件内容
            fileText = LocalData.GetLocalData(filePath);

            //listbox数据显示
            Item_List.ItemsSource = Items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// 填充数据List
        /// </summary>
        private List<BooksInfo> Items
        {
            get
            {

                JObject bookSeries = ManageJson.GetJson(fileText); ///获取json数据
                int count = (int)bookSeries["count"];
                int total = (int)bookSeries["total"];
                int length = count < total ? count : total;
                List<BooksInfo> result = new List<BooksInfo>();
                for(int i = 0; i < length; i++)
                {
                    BooksInfo book = new BooksInfo();

                    BookInfoList = (JArray)bookSeries["books"];

                    int bookId = (int)bookSeries["books"][i]["id"];
                    String bookTitle = bookSeries["books"][i]["title"].ToString(); ///图书标题
                    String bookPublisher = bookSeries["books"][i]["publisher"].ToString(); ///
                    var bookAuthorArray = bookSeries["books"][i]["author"]; ///作者数组
                    String bookAuthor = "";
                    foreach(String author in bookAuthorArray)
                    {
                        bookAuthor += author + " ";
                    }
                    book.Id = bookId;
                    book.Title = bookTitle;
                    book.Publisher = bookPublisher;
                    book.Author = bookAuthor;
                    result.Add(book);

                }
                return result;
            }
        }
        /// <summary>
        /// 点击列表项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Selected_Item(object sender, SelectionChangedEventArgs e)
        {
            BooksInfo booksInfo = new BooksInfo();
            booksInfo = (BooksInfo)Item_List.SelectedItem;
            int bookId = booksInfo.Id;
            foreach(JObject bookDetail in BookInfoList)
            {
                if ((int)bookDetail["id"] == bookId)
                {
                    String authors = "";
                    foreach (String author in bookDetail["author"])
                    {
                        authors += author + " | ";
                    }
                    booksInfo.Image = bookDetail["images"]["large"].ToString();
                    booksInfo.Title = bookDetail["title"].ToString();
                    booksInfo.Author = authors;
                    BookDetail.DataContext = booksInfo;
                    break;
                };
            }

        }
        
        public JObject GetBookData(String fileText)
        {
            var BookInfo = JsonConvert.DeserializeObject<JObject>(fileText);
            
            return BookInfo;
        }

    }

    /// <summary>
    /// 图书信息实体类
    /// </summary>
    public class BooksInfo
    {
        public int Id { set; get; }
        public String Title { set; get; }
        public String Author { set; get; }
        public String Publisher { set; get; }
        public String Image { set; get; }
    }
}

