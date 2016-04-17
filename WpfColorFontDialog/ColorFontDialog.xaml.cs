using System;
using System.Collections;
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

namespace WpfColorFontDialog
{
    /// <summary>
    /// Interaction logic for ColorFontDialog.xaml
    /// </summary>
    public partial class ColorFontDialog : Window
    {
        private FontInfo selectedFont;

        public FontInfo Font
        {
            get
            {
                return this.selectedFont;
            }
            set
            {
                this.selectedFont = value;
            }
        }
        public ColorFontDialog(bool previewFontInFontList=true)
        {
            InitializeComponent();
            this.colorFontChooser.PreviewFontInFontList = previewFontInFontList;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Font = this.colorFontChooser.SelectedFont;
            base.DialogResult = new bool?(true);
        }

        private void SyncFontColor()
        {
            int colorIdx = AvailableColors.GetFontColorIndex(this.Font.Color);
            this.colorFontChooser.colorPicker.superCombo.SelectedIndex = colorIdx;
            this.colorFontChooser.txtSampleText.Foreground = this.Font.Color.Brush;
            this.colorFontChooser.colorPicker.superCombo.BringIntoView();
        }

        private void SyncFontName()
        {
            string fontFamilyName = this.selectedFont.Family.Source;
            bool foundMatch=false;
            int idx = 0;
            foreach (object item in (IEnumerable)this.colorFontChooser.lstFamily.Items)
            {
                if (fontFamilyName == item.ToString())
                {
                    foundMatch = true;
                    break;
                }
                idx++;
            }
            if(!foundMatch)
            {
                idx = 0;
            }
            this.colorFontChooser.lstFamily.SelectedIndex = idx;
            this.colorFontChooser.lstFamily.ScrollIntoView(this.colorFontChooser.lstFamily.Items[idx]);
        }

        private void SyncFontSize()
        {
            double fontSize = this.selectedFont.Size;
            foreach (ListBoxItem item in (IEnumerable)this.colorFontChooser.lstFontSizes.Items)
            {
                if (double.Parse(item.Content.ToString()) != fontSize)
                {
                    continue;
                }
                item.IsSelected = true;
                break;
            }
        }

        private void SyncFontTypeface()
        {
            string fontTypeFaceSb = FontInfo.TypefaceToString(this.selectedFont.Typeface);
            int idx = 0;
            foreach (object item in (IEnumerable)this.colorFontChooser.lstTypefaces.Items)
            {
                if (fontTypeFaceSb == FontInfo.TypefaceToString(item as FamilyTypeface))
                {
                    break;
                }
                idx++;
            }
            this.colorFontChooser.lstTypefaces.SelectedIndex = idx;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.SyncFontColor();
            this.SyncFontName();
            this.SyncFontSize();
            this.SyncFontTypeface();
        }
    }
}
