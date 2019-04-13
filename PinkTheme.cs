using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CourseProject
{
    class PinkTheme
    {
        public  Color LayoutRTB;
        public  Color LayoutRightColumn;
        public  Color btnPressedState;
        public  Color btnUnpressedState;
        public  Color LayoutTopGrid;
        public  Color LayoutLeftColumn;
        public  Color PencilColor;
        public PinkTheme()
        {
            LayoutRTB = (Color)ColorConverter.ConvertFromString("#FFD8CED8");
            LayoutRightColumn = (Color)ColorConverter.ConvertFromString("#FFE8E4E4");
            btnPressedState = (Color)ColorConverter.ConvertFromString("#FFBFAFAF");
            btnUnpressedState = (Color)ColorConverter.ConvertFromString("#FFF1F1F1");
            LayoutTopGrid = (Color)ColorConverter.ConvertFromString("#FFF1EFEF");
            LayoutLeftColumn = (Color)ColorConverter.ConvertFromString("#FFF1EFEF");
            PencilColor = (Color)ColorConverter.ConvertFromString("#FF443D3D");
        }
    }
}
