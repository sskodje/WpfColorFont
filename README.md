# Wpf Color/Font Dialog

A wpf color and font picker based on [a project by Alessio Saltarin](http://www.codeproject.com/Articles/368070/A-WPF-Font-Picker-with-Color).

Available on [NuGet](http://www.nuget.org/packages/WpfColorFontDialog/)

usage:
          
          //We can pass a bool to choose if we preview the font directly in the list of fonts.
            Bool previewFontInFontList = true;
            ColorFontDialog dialog = new ColorFontDialog(previewFontInFontList);
            dialog.Font = FontInfo.GetControlFont(MyTextBox);
            
            if (dialog.ShowDialog() == true)
            {
                FontInfo font = dialog.Font;
                if (font != null)
                {
                    FontInfo.ApplyFont(MyTextBox, font);
                }
            }
 
![Example](http://i.imgur.com/9RtLqsN.png)

