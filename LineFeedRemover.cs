using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum_WPFApp
{
    public static class LineFeedRemover
    {

        static LineFeedRemover()
        {

        }

        public static string CleanClipboardText()
        {
            string cleanString = string.Empty;
            if (ClipboardValidator())
            {
                // cleanString = Clipboard.GetText().Replace("\r\n", "");
                cleanString = ReplaceNonAscii(Clipboard.GetText());
            }
            else
            {
                MessageBox.Show("There is no text on the clipboard!");
            }
            return cleanString;
        }

        private static bool ClipboardValidator()
        {
            bool isText;
            if (Clipboard.ContainsText()) { isText = true; } else { isText = false; }
            return isText;
        }

        private static string ReplaceNonAscii(string stringToClean)
        {
            string pattern = @"(\r\n)";
            Regex regExp = new Regex(pattern);
            return regExp.Replace(stringToClean, " ");
        }

        private static string RemoveCharFromString(string stringCleanable, string charToRemove)
        {
            char[] charArray = stringCleanable.ToCharArray();
            string tempString = string.Empty;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i].ToString() != charToRemove)
                {
                    tempString += charArray[i];
                }
            }
            return tempString;
        }
        
    }
}
