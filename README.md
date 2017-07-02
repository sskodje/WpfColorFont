# Wpf Color/Font Dialog

A wpf color and font picker based on [a project by Alessio Saltarin](http://www.codeproject.com/Articles/368070/A-WPF-Font-Picker-with-Color).

Available on [NuGet](http://www.nuget.org/packages/WpfColorFontDialog/)

usage:
          
            //We can pass a bool to choose if we preview the font directly in the list of fonts.
            Bool previewFontInFontList = true;
            //True to allow user to input arbitrary font sizes. False to only allow predtermined sizes
            Bool allowArbitraryFontSizes = true; 
            ColorFontDialog dialog = new ColorFontDialog(previewFontInFontList,allowArbitraryFontSizes);
            dialog.Font = FontInfo.GetControlFont(MyTextBox);
            //Optional custom allowed size range
            dialog.FontSizes = new int[] { 10, 12, 14, 16, 18, 20, 22 };
            
            if (dialog.ShowDialog() == true)
            {
                FontInfo font = dialog.Font;
                if (font != null)
                {
                    FontInfo.ApplyFont(MyTextBox, font);
                }
            }
 
![Example](http://i.imgur.com/9RtLqsN.png)

