using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfApp1
{
    /// <summary>
    /// CarWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CarWindow : Window
    {
        List<Car> _carList;
        public CarWindow()
        {
            InitializeComponent();

            _carList = new List<Car>()
            {
                new Car(){Name = "Aodi1", ImagePath=@"/Resources/Images/Aodi.jpg", Automarker=@"/Resources/Images/01077_1.png", Year="1990"},
                new Car(){Name = "Aodi2", ImagePath=@"/Resources/Images/Aodi.png", Automarker=@"/Resources/Images/01077_1.png", Year="2001"},
            };

            _listBoxCars.ItemsSource = _carList;
        }
    }

    /// <summary>  
    /// Car数据类型 -- 必须定义成属性{ get; set; }  
    /// </summary>  
    public class Car
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Automarker { get; set; }
        public string Year { get; set; }
    }


}
