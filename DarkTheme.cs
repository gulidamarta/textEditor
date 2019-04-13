using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CourseProject
{
    class DarkTheme
    {
        public  Color LayoutRTB;
        public  Color LayoutRightColumn;
        public  Color btnPressedState;
        public  Color btnUnpressedState;
        public  Color LayoutTopGrid;
        public  Color LayoutLeftColumn;
        public  Color PencilColor;
        public DarkTheme()
        {
            LayoutRTB = (Color)ColorConverter.ConvertFromString("#FF322E32");
            LayoutRightColumn = (Color)ColorConverter.ConvertFromString("#FF4F4A4F");
            btnPressedState = (Color)ColorConverter.ConvertFromString("#FFBFAFAF");
            btnUnpressedState = (Color)ColorConverter.ConvertFromString("#FFF1F1F1");
            LayoutTopGrid = (Color)ColorConverter.ConvertFromString("#FF5F5B5F");
            LayoutLeftColumn = (Color)ColorConverter.ConvertFromString("#FF5F5B5F");
            PencilColor = (Color)ColorConverter.ConvertFromString("#FFE8E4E4");
        }
    }
}
