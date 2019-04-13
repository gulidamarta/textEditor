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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            // for loading needed style
            const string PinkColor = "Pink";
            const string LightColor = "Light";
            const string DarkColor = "Dark";

            // start values of the form
            const string FontStyleFile = "FontStyle.txt";
            const byte DefaultFontSize = 5;
            const byte DefaultFontFamily = 63;

            InitializeComponent();

            // choose and load theme
            string StyleType = File.ReadAllText(FontStyleFile);
            if(StyleType == DarkColor)
            {
                ColorizeInDark();
            }
            if(StyleType == LightColor)
            {
                ColorizeInLight();
            }
            if(StyleType == PinkColor)
            {
                ColorizeInPink();
            }

            // initialize form's components
            DocumentTitle.Text = "NewTextFile";
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbFontSize.SelectedItem =  cmbFontSize.Items[DefaultFontSize];
            cmbFontFamily.SelectedItem = cmbFontFamily.Items[DefaultFontFamily];


            const string FileAutoTabMode = "AutoTabMode.txt";
            const string FileCheckSpelling = "CheckSpelling.txt";
            const string FileAutoReturnMode = "AutoReturnMode.txt";
            const string IsTrue = "true";

            string IsAutoTabMode = File.ReadAllText(FileAutoTabMode);
            if (IsAutoTabMode == IsTrue)
                Text_Field.AcceptsTab = true;
            else
                Text_Field.AcceptsTab = false;

            string IsCheckSpellingMode = File.ReadAllText(FileCheckSpelling);
            if (IsCheckSpellingMode == IsTrue)
                Text_Field.SpellCheck.IsEnabled = true;
            else
                Text_Field.SpellCheck.IsEnabled = false;

            string IsAutoReturnMode = File.ReadAllText(FileAutoReturnMode);
            if (IsAutoReturnMode == IsTrue)
                Text_Field.AcceptsReturn = true;
            else
                Text_Field.AcceptsReturn = false;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            {
                int index = int.Parse(((Button)e.Source).Uid);
                switch (index)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }
        }

        private void MainWindow_1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextGrid.Width = MainWindow_1.Width;
            Text_Field.Width = MainWindow_1.Width - 370;

            Text_Field.Height = MainWindow_1.Height - Tools_Grid.Height;
            TextGrid.Height = MainWindow_1.Height - Tools_Grid.Height;
        }

        private void MainWindow_1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            GridBackground.Background.Opacity = 50;
            
        }

        private string InitialFileName = ""; 

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "TXT Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|DOC Files (*.doc)" +
                "|*.doc|HTML Files (*.html)|*.html";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a title of the form 
            if (result == true)
            {
                // Open document
                
                string filename = dlg.FileName;
                InitialFileName = filename;

                string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(filename);

                var b = new StreamReader(filename, Encoding.Default);
                FlowDocument flow = new FlowDocument(new Paragraph(new Run(b.ReadToEnd())));
                Text_Field.Document = flow;
                DocumentTitle.Text = filenameWithoutExt;

                b.Dispose();
                b.Close();
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
                          "Confirmation",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
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
       
        private void btnMinimized_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageMinimized = null;

            Image myImage3 = new Image();
            myImage3.Width = 25;
            myImage3.Height = 25;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("apple_minimized.png", UriKind.Relative);
            bi3.EndInit();
            myImage3.Source = bi3;

            ImageMinimized = myImage3;
        }

        private void btnMinimized_MouseMove(object sender, MouseEventArgs e)
        {
            ImageMinimized = null;

            Image myImage3 = new Image();
            myImage3.Width = 25;
            myImage3.Height = 25;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("apple_minimized.png", UriKind.Relative);
            bi3.EndInit();
            myImage3.Source = bi3;

            ImageMinimized = myImage3;
        }

        private void SaveCommand()
        {
            // Create SaveFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "TXT Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|DOC Files (*.doc)" +
                "|*.doc|HTML Files (*.html)|*.html";
            dlg.RestoreDirectory = true;

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            TextRange range;
            FileStream fStream;
            range = new TextRange(Text_Field.Document.ContentStart, Text_Field.Document.ContentEnd);

            // Get the selected file name and display in a title
            if (result == true)
            {
                // if file exist - append this file if not create and write there information
                fStream = new FileStream(dlg.FileName, FileMode.Append);

                // display name of the file on the title of the form
                string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
                range.Save(fStream, DataFormats.Text);
                DocumentTitle.Text = filenameWithoutExt;

                fStream.Close();
            }
        }

        private void SaveCommand(string FileName)
        {
            if (FileName != ""){
                FileStream fstream = new FileStream(FileName, FileMode.Append);
                TextRange range = new TextRange(Text_Field.Document.ContentStart, Text_Field.Document.ContentEnd);

                range.Save(fstream, DataFormats.Text);
                fstream.Close();
            }
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveCommand();
        }


        // Print RichTextBox content
        private void PrintCommand()
        {
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                //use either one of the below      
                pd.PrintVisual(Text_Field as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)Text_Field.Document).DocumentPaginator), "printing as paginator");
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintCommand();
        }

        // begin: implementation of the main functions
        private void Undo()
        {
            Text_Field.Undo();
        }

        private void Redo()
        {
            Text_Field.Redo();
        }

        private void Copy()
        {
            Text_Field.Copy();
        }

        private void Cut()
        {
            Text_Field.Cut();
        }

        private void Paste()
        {
            Text_Field.Paste();
        }

        private void ClearDocumnet()
        {
            Text_Field.Document.Blocks.Clear();
        }


        private void ApplyToSelection(DependencyProperty property, object value) 
        {
            if(value != null)
            {
                Text_Field.Selection.ApplyPropertyValue(property, value);
            }
        }
        // end: implementation of the main functions

        private bool WasChanges = false;
        private void Text_Field_SelectionChanged(object sender, RoutedEventArgs e)
        {
            WasChanges = true;
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbFontFamily.FontFamily = new FontFamily(cmbFontFamily.Text);
            if (cmbFontFamily.SelectedItem != null)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }

        public bool IsRichTextBoxEmpty(RichTextBox rtb)
        {
            if (rtb.Document.Blocks.Count == 0) return true;
            TextPointer startPointer = rtb.Document.ContentStart.GetNextInsertionPosition(LogicalDirection.Forward);
            TextPointer endPointer = rtb.Document.ContentEnd.GetNextInsertionPosition(LogicalDirection.Backward);
            return startPointer.CompareTo(endPointer) == 0;
        }

        private void btnNewProject_Click(object sender, RoutedEventArgs e)
        {
            if (!IsRichTextBoxEmpty(Text_Field))
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                if ((result == MessageBoxResult.Yes) && (DocumentTitle.Text == "NewTextFile"))
                {
                    SaveCommand();
                    Text_Field.Document.Blocks.Clear(); 
                }
                else
                {
                    if ((result == MessageBoxResult.Yes) && (DocumentTitle.Text != "NewTextFile"))
                    {
                        SaveCommand(InitialFileName);
                        Text_Field.Document.Blocks.Clear(); 
                    }
                }
                if ((result == MessageBoxResult.No) || (result == MessageBoxResult.Cancel))
                {
                    Text_Field.Document.Blocks.Clear();
                } 
            }

        }


        private void NotPressedGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Grid).Visibility = Visibility.Collapsed;
            PressedGrid.Visibility = Visibility.Visible;
            this.UpdateLayout();
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

        private void btnMinimizedMove_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        public void ReturnArg1Yes()
        {
            if (DocumentTitle.Text == "NewTextFile")
            {
                SaveCommand();
                Text_Field.Document.Blocks.Clear();
            }
            else
            {
                SaveCommand(InitialFileName);
                Text_Field.Document.Blocks.Clear();
            }
            Application.Current.Shutdown();
        }

        public void ReturnArg2No()
        {
            Text_Field.Document.Blocks.Clear();
            Application.Current.Shutdown();
        }

        private void btnCloseMove_Click(object sender, RoutedEventArgs e)
        {
            if ((!IsRichTextBoxEmpty(Text_Field)) && WasChanges)
            {
                CustomMessageBox temp = new CustomMessageBox("Do you want to save changes ?", "Yes", "No");
                temp.Owner = this;
                temp.ShowDialog();
            }
            else
                Application.Current.Shutdown();
        }

        private void PressedGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Grid).Visibility = Visibility.Collapsed;
            NotPressedGrid.Visibility = Visibility.Visible;
            this.UpdateLayout();
        }

        private string DarkPink = "#FFBFAFAF";
        private string LightGrey = "#FFF1F1F1";
        private bool IsBold = false;
        private bool IsUnderline = false;
        private bool IsItalic = false;
        private bool IsExtraBold = false;
        private bool IsOverline = false;
        private bool IsBaseline = false;
        private bool IsStriketrough = false;

        private void MakeBold()
        {
            if (!IsBold)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
                btnMakeBold.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                IsBold = true;
            }
            else
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
                btnMakeBold.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsBold = false;
            }
        }

        private void MakeNone()
        {
            Text_Field.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            Text_Field.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);

            // FOR UNDERLINE AND SO ON
            string richText = new TextRange(Text_Field.Document.ContentStart, Text_Field.Document.ContentEnd).Text;
            IsBold = false;
            IsUnderline = false;
            IsItalic = false;
            IsExtraBold = false;
            IsOverline = false;
            IsBaseline = false;
            IsStriketrough = false;
        }

        private void MakeExtraBold()
        {
            if (!IsExtraBold)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.ExtraBold);
                IsExtraBold = true;
            }
        }

        private void MakeOverline()
        {
            if (!IsOverline)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.OverLine);
                IsOverline = true;
            }
        }

        private void MakeBaseline()
        {
            if (!IsBaseline)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Baseline);
                IsBaseline = true;
            }
        }

        private void MakeStrikethrough()
        {
            if (!IsStriketrough)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
                IsStriketrough = true;
            }
        }

        private void btnMakeBold_Click(object sender, RoutedEventArgs e)
        {
            MakeBold();
        }

        private void cmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedItem);
            }
        }

        private void btnChooseColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.ForegroundProperty, new SolidColorBrush(Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B)));
                btnColourful.Background = new SolidColorBrush(Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B));
            } 
        }

        private void btnPasteAll_Click(object sender, RoutedEventArgs e)
        {
            Paste();
        }

        private void btnCopyAll_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        private void btnMakeBold_Checked(object sender, RoutedEventArgs e)
        {
            MakeBold();
        }


        private void MakeItalic()
        {
            if (!IsItalic)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
                btnMakeItalic.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                IsItalic = true;
            }
            else
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
                btnMakeItalic.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsItalic = false;
            }
        }

        private void btnMakeItalic_Click(object sender, RoutedEventArgs e)
        {
            MakeItalic();
        }


        private void MakeUnderline()
        {
            if (!IsUnderline)
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                btnMakeUnderline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                IsUnderline = true;
            }
            else
            {
                Text_Field.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
                btnMakeUnderline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsUnderline = false;
            }
        }

        private void btnMakeUnderline_Click(object sender, RoutedEventArgs e)
        {
            MakeUnderline();
        }

        private void cbmCharacterStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbmCharacterStyle.SelectedIndex)
            {
                case 0:
                    MakeNone();
                    break;
                case 1:
                    MakeUnderline();
                    break;
                case 2:
                    MakeItalic();
                    break;
                case 3:
                    MakeExtraBold();
                    break;
                case 4:
                    MakeOverline();
                    break;
                case 5:
                    MakeBaseline();
                    break;
                case 6:
                    MakeStrikethrough();
                    break;
            }
        }

        private bool IsRightAlignment = false;
        private bool IsLeffAlignment = false;
        private bool IsCenterAlignment = false;
        private bool IsJustifyAlignment = false;

        private void btnRightAlignment_Click(object sender, RoutedEventArgs e)
        {
            if (!IsRightAlignment)
            {
                btnRightAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                btnLeftAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnCenterAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnJustifyAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsLeffAlignment = false;
                IsCenterAlignment = false;
                IsJustifyAlignment = false;
                IsRightAlignment = true;
            }
            else
            {
                btnRightAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsRightAlignment = false;
            }
        }

        private void cmbSapcing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSapcing.SelectedIndex == 0)
            {

            }
            if(cmbSapcing.SelectedIndex == 1)
            {

            }
        }

        public bool IsPink = false;
        public bool IsDark = false;
        public bool IsLight = false;
        private void btnChooseStyle_Click(object sender, RoutedEventArgs e)
        {
            ChooseStyleWindow chooseStyleWindow = new ChooseStyleWindow();
            chooseStyleWindow.Owner = this;
            chooseStyleWindow.ShowDialog();
        }

        public void ColorizeInPink()
        {
            // change color of main grids and dockpanels
            PinkTheme pink = new PinkTheme();
            Window.Background = new SolidColorBrush(pink.LayoutRTB);
            Tools_Grid.Background = new SolidColorBrush(pink.LayoutTopGrid);
            TopGrid.Background = new SolidColorBrush(pink.LayoutTopGrid);
            DockPanelRight.Background = new SolidColorBrush(pink.LayoutRightColumn);
            GridMenu.Background = new SolidColorBrush(pink.LayoutTopGrid);
            btnChooseColor.BorderBrush = new SolidColorBrush(pink.LayoutTopGrid);
            btnColourful.BorderBrush = new SolidColorBrush(pink.LayoutTopGrid);

            btnStyle_right.BorderBrush = new SolidColorBrush(pink.LayoutTopGrid);
            btnStyle_right.Foreground = new SolidColorBrush(pink.PencilColor);
            btnLayout_right.BorderBrush = new SolidColorBrush(pink.LayoutTopGrid);
            btnLayout_right.Foreground = new SolidColorBrush(pink.PencilColor);
            btnMore_right.BorderBrush = new SolidColorBrush(pink.LayoutTopGrid);
            btnMore_right.Foreground = new SolidColorBrush(pink.PencilColor);

            //change color of pencils
            TextAccount.Foreground = new SolidColorBrush(pink.PencilColor);
            TextAddPage.Foreground = new SolidColorBrush(pink.PencilColor);
            TextAfterParagraph.Foreground = new SolidColorBrush(pink.PencilColor);
            TextAlignment.Foreground = new SolidColorBrush(pink.PencilColor);
            TextBeforeParagraph.Foreground = new SolidColorBrush(pink.PencilColor);
            TextCharacterStyle.Foreground = new SolidColorBrush(pink.PencilColor);
            TextChart.Foreground = new SolidColorBrush(pink.PencilColor);
            TextCopy.Foreground = new SolidColorBrush(pink.PencilColor);
            TextFind.Foreground = new SolidColorBrush(pink.PencilColor);
            TextFont.Foreground = new SolidColorBrush(pink.PencilColor);
            TextHome.Foreground = new SolidColorBrush(pink.PencilColor);
            TextImage.Foreground = new SolidColorBrush(pink.PencilColor);
            TextInsert.Foreground = new SolidColorBrush(pink.PencilColor);
            TextNewFile.Foreground = new SolidColorBrush(pink.PencilColor);
            TextOpen.Foreground = new SolidColorBrush(pink.PencilColor);
            TextPasteAll.Foreground = new SolidColorBrush(pink.PencilColor);
            TextPrint.Foreground = new SolidColorBrush(pink.PencilColor);
            TextSave.Foreground = new SolidColorBrush(pink.PencilColor);
            TextSettings.Foreground = new SolidColorBrush(pink.PencilColor);
            TextSpacing.Foreground = new SolidColorBrush(pink.PencilColor);
            TextStyle.Foreground = new SolidColorBrush(pink.PencilColor);
            TextTable.Foreground = new SolidColorBrush(pink.PencilColor);
            TextText.Foreground = new SolidColorBrush(pink.PencilColor);
            TextZoom.Foreground = new SolidColorBrush(pink.PencilColor);
        }

        public void ColorizeInDark()
        {
            // change color of main grids and dockpanels
            DarkTheme dark = new DarkTheme();
            Window.Background = new SolidColorBrush(dark.LayoutRTB);
            Tools_Grid.Background = new SolidColorBrush(dark.LayoutTopGrid);
            TopGrid.Background = new SolidColorBrush(dark.LayoutTopGrid);
            DockPanelRight.Background = new SolidColorBrush(dark.LayoutRightColumn);
            GridMenu.Background = new SolidColorBrush(dark.LayoutTopGrid);
            btnChooseColor.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);
            btnColourful.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);

            btnStyle_right.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);
            btnStyle_right.Foreground = new SolidColorBrush(dark.PencilColor);
            btnLayout_right.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);
            btnLayout_right.Foreground = new SolidColorBrush(dark.PencilColor);
            btnMore_right.BorderBrush = new SolidColorBrush(dark.LayoutTopGrid);
            btnMore_right.Foreground = new SolidColorBrush(dark.PencilColor);

            //change color of pencils
            TextAccount.Foreground = new SolidColorBrush(dark.PencilColor);
            TextAddPage.Foreground = new SolidColorBrush(dark.PencilColor);
            TextAfterParagraph.Foreground = new SolidColorBrush(dark.PencilColor);
            TextAlignment.Foreground = new SolidColorBrush(dark.PencilColor);
            TextBeforeParagraph.Foreground = new SolidColorBrush(dark.PencilColor);
            TextCharacterStyle.Foreground = new SolidColorBrush(dark.PencilColor);
            TextChart.Foreground = new SolidColorBrush(dark.PencilColor);
            TextCopy.Foreground = new SolidColorBrush(dark.PencilColor);
            TextFind.Foreground = new SolidColorBrush(dark.PencilColor);
            TextFont.Foreground = new SolidColorBrush(dark.PencilColor);
            TextHome.Foreground = new SolidColorBrush(dark.PencilColor);
            TextImage.Foreground = new SolidColorBrush(dark.PencilColor);
            TextInsert.Foreground = new SolidColorBrush(dark.PencilColor);
            TextNewFile.Foreground = new SolidColorBrush(dark.PencilColor);
            TextOpen.Foreground = new SolidColorBrush(dark.PencilColor);
            TextPasteAll.Foreground = new SolidColorBrush(dark.PencilColor);
            TextPrint.Foreground = new SolidColorBrush(dark.PencilColor);
            TextSave.Foreground = new SolidColorBrush(dark.PencilColor);
            TextSettings.Foreground = new SolidColorBrush(dark.PencilColor);
            TextSpacing.Foreground = new SolidColorBrush(dark.PencilColor);
            TextStyle.Foreground = new SolidColorBrush(dark.PencilColor);
            TextTable.Foreground = new SolidColorBrush(dark.PencilColor);
            TextText.Foreground = new SolidColorBrush(dark.PencilColor);
            TextZoom.Foreground = new SolidColorBrush(dark.PencilColor);
        }

        public void ColorizeInLight()
        {
            // change color of main grids and dockpanels
            LightTheme light = new LightTheme();
            Window.Background = new SolidColorBrush(light.LayoutRTB);
            Tools_Grid.Background = new SolidColorBrush(light.LayoutTopGrid);
            TopGrid.Background = new SolidColorBrush(light.LayoutTopGrid);
            DockPanelRight.Background = new SolidColorBrush(light.LayoutRightColumn);
            GridMenu.Background = new SolidColorBrush(light.LayoutTopGrid);
            btnChooseColor.BorderBrush = new SolidColorBrush(light.LayoutTopGrid);
            btnColourful.BorderBrush = new SolidColorBrush(light.LayoutTopGrid);

            btnStyle_right.BorderBrush = new SolidColorBrush(light.LayoutTopGrid);
            btnStyle_right.Foreground = new SolidColorBrush(light.PencilColor);
            btnLayout_right.BorderBrush = new SolidColorBrush(light.LayoutTopGrid);
            btnLayout_right.Foreground = new SolidColorBrush(light.PencilColor);
            btnMore_right.BorderBrush = new SolidColorBrush(light.LayoutTopGrid);
            btnMore_right.Foreground = new SolidColorBrush(light.PencilColor);

            //change color of pencils
            TextAccount.Foreground = new SolidColorBrush(light.PencilColor);
            TextAddPage.Foreground = new SolidColorBrush(light.PencilColor);
            TextAfterParagraph.Foreground = new SolidColorBrush(light.PencilColor);
            TextAlignment.Foreground = new SolidColorBrush(light.PencilColor);
            TextBeforeParagraph.Foreground = new SolidColorBrush(light.PencilColor);
            TextCharacterStyle.Foreground = new SolidColorBrush(light.PencilColor);
            TextChart.Foreground = new SolidColorBrush(light.PencilColor);
            TextCopy.Foreground = new SolidColorBrush(light.PencilColor);
            TextFind.Foreground = new SolidColorBrush(light.PencilColor);
            TextFont.Foreground = new SolidColorBrush(light.PencilColor);
            TextHome.Foreground = new SolidColorBrush(light.PencilColor);
            TextImage.Foreground = new SolidColorBrush(light.PencilColor);
            TextInsert.Foreground = new SolidColorBrush(light.PencilColor);
            TextNewFile.Foreground = new SolidColorBrush(light.PencilColor);
            TextOpen.Foreground = new SolidColorBrush(light.PencilColor);
            TextPasteAll.Foreground = new SolidColorBrush(light.PencilColor);
            TextPrint.Foreground = new SolidColorBrush(light.PencilColor);
            TextSave.Foreground = new SolidColorBrush(light.PencilColor);
            TextSettings.Foreground = new SolidColorBrush(light.PencilColor);
            TextSpacing.Foreground = new SolidColorBrush(light.PencilColor);
            TextStyle.Foreground = new SolidColorBrush(light.PencilColor);
            TextTable.Foreground = new SolidColorBrush(light.PencilColor);
            TextText.Foreground = new SolidColorBrush(light.PencilColor);
            TextZoom.Foreground = new SolidColorBrush(light.PencilColor);
        }

        public void ReplaceTheme()
        {
            if (IsPink)
            {
                ColorizeInPink();
            }
            if (IsDark)
            {
                ColorizeInDark();
            }
            if (IsLight)
            {
                ColorizeInLight();
            }
        }

        private void btnCenterAlignment_Click(object sender, RoutedEventArgs e)
        {
            if (!IsCenterAlignment)
            {
                btnCenterAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                btnRightAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnLeftAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnJustifyAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsLeffAlignment = false;
                IsJustifyAlignment = false;
                IsRightAlignment = false;
                IsCenterAlignment = true;
            }
            else
            {
                btnCenterAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsCenterAlignment = false;
            }
        }

        private void btnLeftAlignment_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLeffAlignment)
            {
                btnLeftAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                IsLeffAlignment = true;
                IsRightAlignment = false;
                IsCenterAlignment = false;
                IsJustifyAlignment = false;
                btnCenterAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnRightAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnJustifyAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
            }
            else
            {
                btnLeftAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsLeffAlignment = false;
            }
        }

        private void btnJustifyAlignment_Click(object sender, RoutedEventArgs e)
        {
            if (!IsJustifyAlignment)
            {

                btnJustifyAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(DarkPink));
                btnCenterAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnRightAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                btnLeftAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsJustifyAlignment = true;
                IsLeffAlignment = false;
                IsRightAlignment = false;
                IsCenterAlignment = false;
            }
            else
            {
                btnJustifyAlignment.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(LightGrey));
                IsJustifyAlignment = false;
            }
        }

        private void cmbZoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Text_Field != null)
            {
                if (cmbZoom.SelectedIndex == 0)
                {
                    Text_Field.Width = 500;
                    Text_Field.FontSize = 12;
                }
                if (cmbZoom.SelectedIndex == 1)
                {
                    Text_Field.Width = 600;
                    Text_Field.FontSize = 13;
                }
                if (cmbZoom.SelectedIndex == 2)
                {
                    Text_Field.Width = 700;
                    Text_Field.FontSize = 14;
                }
                if (cmbZoom.SelectedIndex == 3)
                {
                    Text_Field.Width = 800;
                    Text_Field.FontSize = 16;
                }
                if (cmbZoom.SelectedIndex == 4)
                {
                    Text_Field.Width = 900;
                    Text_Field.FontSize = 18;
                }
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.ShowDialog();
        }

        public bool IsCheckSpelling = true;
        public bool IsAutoTabMode = true;
        public bool IsAutoCompleteMode = false;
        public bool IsAutoReturnMode = true;

        public void CheckSettings()
        {
            if (IsCheckSpelling)
                Text_Field.SpellCheck.IsEnabled = true;
            else
                Text_Field.SpellCheck.IsEnabled = false;

            if (IsAutoTabMode)
                Text_Field.AcceptsTab = true;
            else
                Text_Field.AcceptsTab = false;

            if (IsAutoReturnMode)
                Text_Field.AcceptsReturn = true;
            else
                Text_Field.AcceptsReturn = false;
        }

        private void SelectAllMatches(string ToSearch)
        {
            
        }

        private void HighlightWordInRichTextBox(String word)
        {
            TextRange text = new TextRange(Text_Field.Document.ContentStart, Text_Field.Document.ContentEnd);
            TextPointer current = text.Start.GetInsertionPosition(LogicalDirection.Forward);
            while (current != null)
            {
                string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                if (!string.IsNullOrWhiteSpace(textInRun))
                {
                    int index = textInRun.IndexOf(word);
                    if (index != -1)
                    {
                        TextPointer selectionStart = current.GetPositionAtOffset(index, LogicalDirection.Forward);
                        TextPointer selectionEnd = selectionStart.GetPositionAtOffset(word.Length, LogicalDirection.Forward);
                        TextRange selection = new TextRange(selectionStart, selectionEnd);
                        selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                        Text_Field.Selection.Select(selection.Start, selection.End);
                        Text_Field.Focus();
                    }
                }
                current = current.GetNextContextPosition(LogicalDirection.Forward);
            }
        }

        public void FindWordSentence(string Word)
        {
            HighlightWordInRichTextBox(Word);
        }

        private void btnFindWord_Click(object sender, RoutedEventArgs e)
        {
            FindWord findwordWindow = new FindWord();
            findwordWindow.Owner = this;
            findwordWindow.ShowDialog();
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|JPG Files (*.jpg)" +
                "|*.jpg|JPEG Files (*.jpeg)|*.jpeg";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a title of the form 
            if (result == true)
            {
                // Open document 
                if (dlg.FileName == "")
                {
                    return;
                }
                try
                { 
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(dlg.FileName);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    Image image = new Image();
                    image.Source = bitmap;
                    Paragraph para = new Paragraph();
                    para.Inlines.Add(image);
                    Text_Field.Document.Blocks.Add(para);
                }
                catch
                {
                    MessageBox.Show("Unable to insert the image format selected.", "RTE - Paste");
                }
            }
        }


        private TableRow CreateNewRow(string items)
        {
            TableRow newRow = new TableRow();
            for (int i = 0; i < items.Length; i++)
            {
                TableCell cell = new TableCell { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1, 1, 1, 1) };
                Paragraph paragraph = new Paragraph();
                Span span = new Span();
                var newString = items[i];
                paragraph.Inlines.Add(span);
                cell.Blocks.Add(paragraph);
                newRow.Cells.Add(cell);
            }

            return newRow;
        }

        private void btnTable_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".xl";
            dlg.Filter = "XL Files (*.xl)|*.xl|XLR Files (*.xlr)|*.xlr";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a title of the form 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                InitialFileName = filename;

                string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(filename);

                var b = new StreamReader(filename, Encoding.Default);
                FlowDocument flow = new FlowDocument(new Paragraph(new Run(b.ReadToEnd())));
                Text_Field.Document = flow;
                DocumentTitle.Text = filenameWithoutExt;

                b.Dispose();
                b.Close();

            }
        }

        private void btnColourful_Click(object sender, RoutedEventArgs e)
        {
            Window1 findwordWindow = new Window1();
            findwordWindow.Owner = this;
            findwordWindow.ShowDialog();
        }
    }
}
