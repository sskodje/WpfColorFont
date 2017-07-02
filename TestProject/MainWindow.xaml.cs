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
using WpfColorFontDialog;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ColorFontDialog dialog = new ColorFontDialog(true,true);
            dialog.Owner = this;
            dialog.Font = FontInfo.GetControlFont(this.TextBlockSample);
            //dialog.FontSizes = new int[] { 10, 12, 14, 16, 18 };
            if (dialog.ShowDialog() == true)
            {
                FontInfo font = dialog.Font;
                if (font != null)
                {
                    FontInfo.ApplyFont(this.TextBlockSample, font);
                }
            }
        }
    }
}
