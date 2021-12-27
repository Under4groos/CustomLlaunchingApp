using System;
using System.Collections.Generic;
using System.IO;
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

namespace CustomLlaunchingApp.Controls
{
    /// <summary>
    /// Логика взаимодействия для DApp.xaml
    /// </summary>
    public partial class DApp : UserControl
    {
        public string PathApp { get; set; }
        public string PathIcon { get; set; }
        public DApp()
        {
            InitializeComponent();
             
        }
        public void UpdateImage()
        {
            if(image_app.Source == null){
                
            }
            open_img(PathIcon);
        }
        public void open_img(string path)
        {
            if (!File.Exists(path))
            {
                 
                return;
            }
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path);
            bitmap.EndInit();
            image_app.Source = bitmap;

             
        }
    }
}
