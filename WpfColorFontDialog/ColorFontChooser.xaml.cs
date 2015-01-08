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

namespace WpfColorFontDialog
{
    /// <summary>
    /// Interaction logic for ColorFontChooser.xaml
    /// </summary>
    public partial class ColorFontChooser : UserControl
    {
        public FontInfo SelectedFont
        {
            get
            {
                return new FontInfo(this.txtSampleText.FontFamily, this.txtSampleText.FontSize, this.txtSampleText.FontStyle, this.txtSampleText.FontStretch, this.txtSampleText.FontWeight, this.colorPicker.SelectedColor.Brush);
            }
        }
        public ColorFontChooser()
        {
            InitializeComponent();
        }
        private void colorPicker_ColorChanged(object sender, RoutedEventArgs e)
        {
            this.txtSampleText.Foreground = this.colorPicker.SelectedColor.Brush;
        }
    }
}
