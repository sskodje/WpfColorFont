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


        public bool PreviewFontInFontList
        {
            get { return (bool)GetValue(PreviewFontInFontListProperty); }
            set { SetValue(PreviewFontInFontListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreviewFontInFontList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviewFontInFontListProperty =
            DependencyProperty.Register("PreviewFontInFontList", typeof(bool), typeof(ColorFontChooser), new PropertyMetadata(true, PreviewFontInFontListPropertyCallback));


        public ColorFontChooser()
        {
            InitializeComponent();
        }
        private static void PreviewFontInFontListPropertyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorFontChooser chooser = d as ColorFontChooser;
            if (e.NewValue == null)
                return;
            if ((bool)e.NewValue == true)
                chooser.lstFamily.ItemTemplate = chooser.Resources["fontFamilyData"] as DataTemplate;
            else
                chooser.lstFamily.ItemTemplate = chooser.Resources["fontFamilyDataWithoutPreview"] as DataTemplate;
        }
        private void colorPicker_ColorChanged(object sender, RoutedEventArgs e)
        {
            this.txtSampleText.Foreground = this.colorPicker.SelectedColor.Brush;
        }
    }
}
