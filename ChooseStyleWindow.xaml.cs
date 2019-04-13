using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for ChooseStyleWindow.xaml
    /// </summary>
    public partial class ChooseStyleWindow : Window
    {
        const string PinkColor = "Pink";
        const string LightColor = "Light";
        const string DarkColor = "Dark";
        const string FontStyleFile = "FontStyle.txt";
        public ChooseStyleWindow()
        {
            InitializeComponent();
            string StyleType = File.ReadAllText(FontStyleFile);
            if(StyleType == PinkColor)
            {
                ColorizeInPink();
            }
            if(StyleType == DarkColor)
            {
                ColorizeInBlack();
            }
            if(StyleType == LightColor)
            {
                ColorizeInLight();
            }
           // MessageBox.Show(StyleType);
        }

        private void NotPressedGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Grid).Visibility = Visibility.Collapsed;
            PressedGrid.Visibility = Visibility.Visible;
            this.UpdateLayout();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnMaximized_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PressedGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Grid).Visibility = Visibility.Collapsed;
            NotPressedGrid.Visibility = Visibility.Visible;
            this.UpdateLayout();
        }

        private void btnMinimizedMove_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnMaximizedMove_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void btnCloseMove_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ColorizeInBlack()
        {
            DarkTheme theme = new DarkTheme();
            MainGrid.Background = new SolidColorBrush(theme.LayoutLeftColumn);
            MainText.Foreground = new SolidColorBrush(theme.PencilColor);
        }

        private void ColorizeInLight()
        {
            LightTheme theme = new LightTheme();
            MainGrid.Background = new SolidColorBrush(theme.LayoutLeftColumn);
            MainText.Foreground = new SolidColorBrush(theme.PencilColor);
        }

        private void ColorizeInPink()
        {
            PinkTheme theme = new PinkTheme();
            MainGrid.Background = new SolidColorBrush(theme.LayoutLeftColumn);
            MainText.Foreground = new SolidColorBrush(theme.PencilColor);
        }

        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = this.Owner as MainWindow;
            if (temp != null)
            {
                if (rbtnDark.IsChecked == true)
                {
                    temp.IsDark = true;
                    temp.IsPink = false;
                    temp.IsLight = false;
                    ColorizeInBlack();

                    File.WriteAllText(FontStyleFile, DarkColor);
                }
                if (rbtnLight.IsChecked == true)
                {
                    temp.IsLight = true;
                    temp.IsDark = false;
                    temp.IsPink = false;
                    ColorizeInLight();

                    File.WriteAllText(FontStyleFile, LightColor);
                }
                if (rbtnPink.IsChecked == true)
                {
                    temp.IsPink = true;
                    temp.IsLight = false;
                    temp.IsDark = false;
                    ColorizeInPink();

                    File.WriteAllText(FontStyleFile, PinkColor);
                }
                temp.ReplaceTheme();
            }
            this.Close();
        }
    }
}
