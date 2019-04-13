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
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string MainMessage, string Arg1, string Arg2)
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
            MessageText.Text = MainMessage;
            TextArg1.Text = Arg1;
            TextArg2.Text = Arg2;
        }

        private void ColorizeInPink()
        {
            PinkTheme pink = new PinkTheme();
            MainGrid.Background = new SolidColorBrush(pink.LayoutRightColumn);
            TopGrid.Background = new SolidColorBrush(pink.LayoutRightColumn);
            btnArg1.BorderBrush = new SolidColorBrush(pink.PencilColor);
            btnArg2.BorderBrush = new SolidColorBrush(pink.PencilColor);
            TextArg1.Foreground = new SolidColorBrush(pink.PencilColor);
            TextArg2.Foreground = new SolidColorBrush(pink.PencilColor);
            MessageText.Foreground = new SolidColorBrush(pink.PencilColor);
        }

        private void ColorizeInBlack()
        {
            DarkTheme dark = new DarkTheme();
            MainGrid.Background = new SolidColorBrush(dark.LayoutRightColumn);
            TopGrid.Background = new SolidColorBrush(dark.LayoutRightColumn);
            btnArg1.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);
            btnArg2.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);
            TextArg1.Foreground = new SolidColorBrush(dark.PencilColor);
            TextArg2.Foreground = new SolidColorBrush(dark.PencilColor);
            MessageText.Foreground = new SolidColorBrush(dark.PencilColor);
        }

        private void ColorizeInLight()
        {
            LightTheme light = new LightTheme();
            MainGrid.Background = new SolidColorBrush(light.LayoutRightColumn);
            TopGrid.Background = new SolidColorBrush(light.LayoutRightColumn);
            btnArg1.BorderBrush = new SolidColorBrush(light.PencilColor);
            btnArg2.BorderBrush = new SolidColorBrush(light.PencilColor);
            TextArg1.Foreground = new SolidColorBrush(light.PencilColor);
            TextArg2.Foreground = new SolidColorBrush(light.PencilColor);
            MessageText.Foreground = new SolidColorBrush(light.PencilColor);
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

        private void btnArg1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = this.Owner as MainWindow;
            if (temp != null)
            {
                temp.ReturnArg1Yes();
            }
        }

        private void btnArg2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow temp = this.Owner as MainWindow;
            if (temp != null)
            {
                temp.ReturnArg2No();
            }
        }
    }
}
