using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CourseProject
{
    class LightTheme
    {
        public Color LayoutRTB;
        public Color LayoutRightColumn;
        public Color btnPressedState;
        public Color btnUnpressedState;
        public Color LayoutTopGrid;
        public Color LayoutLeftColumn;
        public Color PencilColor;
        public LightTheme()
        {
            LayoutRTB = (Color)ColorConverter.ConvertFromString("#FFDEDCDC");
            LayoutRightColumn = (Color)ColorConverter.ConvertFromString("#FFF7F7F7");
            btnPressedState = (Color)ColorConverter.ConvertFromString("#FFBFAFAF");
            btnUnpressedState = (Color)ColorConverter.ConvertFromString("#FFF1F1F1");
            LayoutTopGrid = (Color)ColorConverter.ConvertFromString("#FFFDFDFD");
            LayoutLeftColumn = (Color)ColorConverter.ConvertFromString("#FFFDFDFD");
            PencilColor = (Color)ColorConverter.ConvertFromString("#FF292727");
        }
    }
}
