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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            const string PinkColor = "Pink";
            const string LightColor = "Light";
            const string DarkColor = "Dark";
            const string FontStyleFile = "FontStyle.txt";
            InitializeComponent();
            string StyleType = File.ReadAllText(FontStyleFile);
            if (StyleType == PinkColor)
            {
                ColorizeInPink();
            }
            if (StyleType == DarkColor)
            {
                ColorizeInBlack();
            }
            if (StyleType == LightColor)
            {
                ColorizeInLight();
            }
        }

        private void ColorizeInPink()
        {
            PinkTheme theme = new PinkTheme();
            BottomGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
            MainGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
            TextOpacity.Foreground = new SolidColorBrush(theme.PencilColor);
            TopGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
        }

        private void ColorizeInBlack()
        {
            DarkTheme theme = new DarkTheme();
            BottomGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
            MainGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
            TextOpacity.Foreground = new SolidColorBrush(theme.PencilColor);
            TopGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
        }

        private void ColorizeInLight()
        {
            LightTheme theme = new LightTheme();
            BottomGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
            MainGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
            TextOpacity.Foreground = new SolidColorBrush(theme.PencilColor);
            TopGrid.Background = new SolidColorBrush(theme.LayoutRightColumn);
        }

        private void NotPressedGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Grid).Visibility = Visibility.Collapsed;
            PressedGrid.Visibility = Visibility.Visible;
            this.UpdateLayout();
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

        private void btnCloseMove_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
