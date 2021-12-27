using CustomLlaunchingApp.Controls;
using CustomLlaunchingApp.lib;
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

namespace CustomLlaunchingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeyboardHook.KeyHook keyHook;
        UcAutoClicker.Lib.TimerTick timerTick = new UcAutoClicker.Lib.TimerTick();
        UIElement select_panel = null;
        Point select_panel_cur_pos = new Point();
        public MainWindow()
        {
            InitializeComponent();
            UpdateWindowApp();

            #region hide
            //Win32Icon.GetFileIcon(
            //    @"C:\Users\UnderKo\Downloads\Win 10 Tweaker.exe",
            //    Win32Icon.IconSize.s_32_32
            //    ).Save("test.png" );

            //FData fData = new FData();
            //fData.add("asd", "asd", "asd");
            //fData.add("asd", "asd", "asd");
            //fData.add("asd", "asd", "asd");
            //fData.add("asd", "asd", "asd");
            //fData.add("asd", "asd", "asd");
            //fData.save("test.txt");

            #endregion




            this.ShowInTaskbar = false;

            foreach (UIElement item in prog_panels.Children)
            {
                item.PreviewMouseLeftButtonDown += (o, e) =>
                {
                    select_panel = item;
                    select_panel_cur_pos = e.GetPosition(select_panel);
                };
                item.PreviewMouseLeftButtonUp += (o, e) =>
                {
                    select_panel = null;
                    select_panel_cur_pos = new Point();
                };
            }


            keyHook = new KeyboardHook.KeyHook(106);
            keyHook.KeyPressed += (o, e) =>
            {
                

                switch (this.Visibility)
                {
                    case Visibility.Visible:
                        this.Hide();
                        this.Topmost = false;
                        break;
                    case Visibility.Hidden:
                        this.Show();
                        this.Topmost = true;
                        break;
                    case Visibility.Collapsed:
                        break;
                    default:
                        break;
                }

                

                UpdateWindowApp();
            };
            keyHook.SetHook();

            border_add_app.PreviewMouseLeftButtonDown += (o, e) =>
            {
                grid_new_app.Visibility = grid_new_app.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
                switch (grid_new_app.Visibility)
                {
                    case Visibility.Visible:
                        timerTick.Start();                       
                        break;
                    case Visibility.Hidden:
                        break;
                    case Visibility.Collapsed:
                        timerTick.Stop();
                        break;
                    default:
                        break;
                }
            };
            prog_panels.MouseAction = (Ppoint p , (MouseButtonState buttonState, MouseButton mouseButton , UIElement ui) button ) =>
            {
               
                //ldebug.Content = $"{p}\n{button.buttonState}\n{button.mouseButton}\n{select_panel}";

                switch (button.buttonState)
                {
                    case MouseButtonState.Released:
                        break;
                    case MouseButtonState.Pressed:
                        if (select_panel == null)
                            return;
                        (select_panel as DApp).Margin = new Thickness(
                            p.X - select_panel_cur_pos.X, 
                            p.Y - select_panel_cur_pos.Y, 
                            
                            0.1, 0.1);
                        break;
                    default:
                        break;
                }


            };
            grid_new_app.Drop += (o, e) =>
            {
                
                if (!e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                    return;
                string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                if (!Directory.Exists("Images"))
                    Directory.CreateDirectory("Images");

                foreach (var item in files)
                {
                    if(File.Exists(item))
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        string new_img_ = System.IO.Path.Combine("Images", fileInfo.Name.Replace(fileInfo.Extension, ".png"));
                        if (lib.Table.HasValue( new string[] { ".png" , ".jpeg" } , fileInfo.Extension))
                        {
                            File.Copy(item, fileInfo.FullName);
                        }
                        else
                        {
                            
                            if (!File.Exists(new_img_))
                                Win32Icon.GetFileIcon(
                                item,
                                Win32Icon.IconSize.s_32_32
                                ).Save(new_img_);
                        }
                        

                        Point p = e.GetPosition(grid_new_app);

                        DApp dApp = new DApp()
                        {
                            PathIcon = new FileInfo(new_img_).FullName,
                            VerticalAlignment = VerticalAlignment.Top,
                            HorizontalAlignment = HorizontalAlignment.Left,

                            Margin = new Thickness(p.X, p.Y, 0.1, 0.1),
                        };
                        dApp.PreviewMouseLeftButtonDown += (oo, ee) =>
                        {
                            select_panel = dApp;
                            select_panel_cur_pos = ee.GetPosition(select_panel);
                            dApp.UpdateImage();
                        };
                        dApp.PreviewMouseLeftButtonUp += (oo, ee) =>
                        {
                            select_panel = null;
                            select_panel_cur_pos = new Point();
                        };

                        prog_panels.Children.Add(dApp);
                    }
                   

                }
                foreach (DApp item in prog_panels.Children)
                {
                    item.UpdateImage();
                }
                ldebug.Content += $"{ string.Join(" " , files)}";
            };
            timerTick.Tick += (o, e) =>
            {
                if (!this.IsActive)
                    this.Hide();
            };
            timerTick.Start();

        }
        public void UpdateWindowApp()
        {
            System.Drawing.Rectangle workingRectangle = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            Console.WriteLine(workingRectangle.Width + " " + workingRectangle.Height);

            this.Width = workingRectangle.Width * 0.6;
            this.Height = workingRectangle.Height * 0.5;

            this.Left = workingRectangle.Width / 2 - this.Width / 2;
            this.Top = workingRectangle.Height - this.Height;

            //grid_new_app.Width = this.Width * 0.7;
            //grid_new_app.Height = this.Height * 0.7;
        }
    }
}
