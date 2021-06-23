using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PrintScreenWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ScreenCaptrue(out BitmapSource bitmapSource) == "1")
            {
                imageCtrl.Source = bitmapSource;
            }
        }

        /// <summary>
        /// 截取屏幕
        /// </summary>
        /// <param name="bitmapSource"></param>
        /// <returns></returns>
        /// <remarks>WinForm的话也一样的，只是换成WinForm对应的GetImage返回值就行了</remarks>
        public static string ScreenCaptrue(out BitmapSource bitmapSource)
        {
            bitmapSource = null;
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ScreenCaptrue\ScreenCaptrue.exe");
            process.Start();
            process.WaitForExit();
            string resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ScreenCaptrue\ScreenCaptrue.txt");
            string printResult = string.Empty;
            if (File.Exists(resultFilePath))
            {
                printResult = File.ReadAllText(resultFilePath);
                if (printResult == "1")
                {
                    bitmapSource = Clipboard.GetImage();
                }
                //lblResult.Text = printResult == "0" ? "取消截图" : (printResult == "1" ? "截图确认完成" : "截图工具直接保存");
            }
            //else
            //{
            //    lblResult.Text = "读取操作结果失败";
            //    Image image = Clipboard.GetImage();
            //    if (image != null)
            //    {
            //        pictureBox1.Image?.Dispose();
            //        pictureBox1.Image = image;
            //    }
            //}

            return printResult;
        }
    }
}
