using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CezarLib
{
    public class CezarEncryptor
    {
        public List<CharMap> charMapList = new List<CharMap>()
        {
            new CharMap(){CharValue = 'A' ,NumberValue = 1},
            new CharMap(){CharValue = 'B' ,NumberValue = 2},
            new CharMap(){CharValue = 'C' ,NumberValue = 3},
            new CharMap(){CharValue = 'Ç' ,NumberValue = 4},
            new CharMap(){CharValue = 'D' ,NumberValue = 5},
            new CharMap(){CharValue = 'E' ,NumberValue = 6},
            new CharMap(){CharValue = 'F' ,NumberValue = 7},
            new CharMap(){CharValue = 'G' ,NumberValue = 8},
            new CharMap(){CharValue = 'Ğ' ,NumberValue = 9},
            new CharMap(){CharValue = 'H' ,NumberValue = 10},
            new CharMap(){CharValue = 'I' ,NumberValue = 11},
            new CharMap(){CharValue = 'İ' ,NumberValue = 12},
            new CharMap(){CharValue = 'J' ,NumberValue = 13},
            new CharMap(){CharValue = 'K' ,NumberValue = 14},
            new CharMap(){CharValue = 'L' ,NumberValue = 15},
            new CharMap(){CharValue = 'M' ,NumberValue = 16},
            new CharMap(){CharValue = 'N' ,NumberValue = 17},
            new CharMap(){CharValue = 'O' ,NumberValue = 18},
            new CharMap(){CharValue = 'Ö' ,NumberValue = 19},
            new CharMap(){CharValue = 'P' ,NumberValue = 20},
            new CharMap(){CharValue = 'R' ,NumberValue = 21},
            new CharMap(){CharValue = 'S' ,NumberValue = 22},
            new CharMap(){CharValue = 'Ş' ,NumberValue = 23},
            new CharMap(){CharValue = 'T' ,NumberValue = 24},
            new CharMap(){CharValue = 'U' ,NumberValue = 25},
            new CharMap(){CharValue = 'Ü' ,NumberValue = 26},
            new CharMap(){CharValue = 'V' ,NumberValue = 27},
            new CharMap(){CharValue = 'Y' ,NumberValue = 28},
            new CharMap(){CharValue = 'Z' ,NumberValue = 29},
        };
        
        private string keyword { get; set; }
        private CultureInfo turkish { get; set; }

        public CezarEncryptor(string key)
        {
            keyword = key;
            turkish = new CultureInfo("tr-TR", false);
        }


        public void SetKeyWord(string key)
        {
            keyword = key;
        }

        public string EncryptLine(string toEncrypt)
        {
            string retVal = string.Empty;

            int keyIndex = 0;
            
            foreach (var letter in toEncrypt.ToUpper(turkish).ToCharArray())
            {
                retVal += EncryptLetter(letter, keyword[keyIndex]);
                keyIndex = (keyIndex + 1) % keyword.Length;
            }

            return retVal;
        }

        private string EncryptLetter(char letter,char keyLetter)
        {
            if (letter == ' ')
            {
                return " ";
            }
            
            var currentVal = charMapList.First(m => m.CharValue == letter);

            var keyVal = 0;
            int.TryParse(keyLetter.ToString(), out keyVal);

            int total = (keyVal + currentVal.NumberValue) % 29;
            if (total == 0)
            {
                total = 29;
            }

            var encryptedVal = charMapList.First(m => m.NumberValue == total);

            return encryptedVal.CharValue.ToString();

        }

        public string EmbedText(string toEmbed, string targetString)
        {
            string searchString = targetString.ToUpper(turkish);


            Dictionary<int,char> indexList = new Dictionary<int, char>();
            var builder = new StringBuilder(targetString);

            int currentIndex = 0;
            
            foreach (char letter in toEmbed.ToCharArray())
            {
                if (letter == ' ')
                {
                    continue;
                }
                int foundIndex = searchString.IndexOf(letter, currentIndex);
                if (foundIndex >= 0)
                {
                    currentIndex = foundIndex + 3;
                    indexList.Add(foundIndex,letter);
                    builder.Remove(foundIndex, 1);
                    builder.Insert(foundIndex, string.Format("|{0}|", letter));

                    searchString = builder.ToString().ToUpper(turkish);
                }
                else
                {
                    Console.WriteLine("Not found " + letter);
                }
            }


            return builder.ToString();
        }
    }
}