﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace noteBook
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileName = "";
        string newFileName = "";

        string saveText = "";
        string thisText = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        // 保存
        void Save()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                System.IO.File.WriteAllText(dlg.FileName, Textarea.Text);
                fileName = dlg.FileName;
                saveText = thisText; ;
                TitlenameTxt.Text = dlg.SafeFileName + ".txt";
            }
        }

        // 打開
        void Open()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                Textarea.Text = System.IO.File.ReadAllText(dlg.FileName);
                fileName = dlg.FileName;
                saveText = Textarea.Text;
                TitlenameTxt.Text = dlg.SafeFileName + ".txt";
            }
        }

        // 打開新文檔
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (saveText != thisText)
                if (MessageBox.Show("Do you want to Save?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    Open();
                }
                else
                {
                    Open();
                }
            else
            {
                Open();
            }
        }

        // 保存文檔
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileName == newFileName)
            {
                Save();
            }
            else
            {
                System.IO.File.WriteAllText(fileName, Textarea.Text);
                saveText = thisText;
            }
        }

        // 另存新檔
        private void SaveasBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dig = new Microsoft.Win32.SaveFileDialog();

            // 显示视窗
            Nullable<bool> result = dig.ShowDialog();
            if (result == true)
            {
                // 写入文本中
                System.IO.File.WriteAllText(dig.FileName, Textarea.Text);
            }
        }

        // 改變字體大小
        private void SmallsizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Textarea.FontSize = 15;
            SmallsizeBtn.Foreground = Brushes.White;
            ModelsizeBtn.Foreground = Brushes.Gray;
            BigsizeBtn.Foreground = Brushes.Gray;
        }

        private void ModelsizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Textarea.FontSize = 20;
            SmallsizeBtn.Foreground = Brushes.Gray;
            ModelsizeBtn.Foreground = Brushes.White ;
            BigsizeBtn.Foreground = Brushes.Gray;
        }

        private void BigsizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Textarea.FontSize = 25;
            SmallsizeBtn.Foreground = Brushes.Gray ;
            ModelsizeBtn.Foreground = Brushes.Gray;
            BigsizeBtn.Foreground = Brushes.White ;
        }

        // 深色主題
        private void DarkBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.Background = Brushes.Gray;
            Textarea.Foreground = Brushes.White;
            Textarea.BorderBrush = Brushes.Gray;
            TitleBlock.Background = Brushes.Gray;
            MinimizeBtn.Foreground = Brushes.White;
            MaximizeBtn.Foreground = Brushes.White;
            ExitBtn.Foreground = Brushes.White;
            EmptyTb.Background = Brushes.Gray;
            DarkBtn.Stroke = Brushes.DarkGray;
            LightBtn.Stroke = Brushes.LightGray;
        }

        // 淺色主題
        private void LightBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.Background = Brushes.White;
            Textarea.Foreground = Brushes.Gray;
            Textarea.BorderBrush = Brushes.White;
            TitleBlock.Background = Brushes.White;
            MinimizeBtn.Foreground = Brushes.Gray;
            MaximizeBtn.Foreground = Brushes.Gray;
            ExitBtn.Foreground = Brushes.Gray;
            EmptyTb.Background = Brushes.White;
            DarkBtn.Stroke = Brushes.LightGray;
            LightBtn.Stroke = Brushes.DarkGray;

        }

        // 窗口移動
        private void TitleBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        // 窗口的縮放
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // 窗口的放大與還原
        private void MaximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            // 设置窗口还原
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; 
            }

            // 设置窗口最大化
            else
            {
                this.WindowState = WindowState.Maximized; 
            }
        }

        // 關閉視窗
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
