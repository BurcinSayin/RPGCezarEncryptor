using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CezarLib;

namespace CezarUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CezarLib.CezarEncryptor encryptor;

        private List<KeywordType> keywordTypes = new List<KeywordType>() { KeywordType.Number, KeywordType.Word };

        public MainWindow()
        {
            InitializeComponent();
            encryptor = new CezarLib.CezarEncryptor();

            InitCharMapTab();
        }

        private void InitCharMapTab()
        {
            //encryptor.charMapList;


            //cmbKeywordType.DataContext = keywordTypes;
            txtAlphabet.Text = encryptor.GetAlphabet();

            CharMapGrid.DataContext = encryptor.charMapList;
        }

        private void BtnSaveCharMap_Click(object sender, RoutedEventArgs e)
        {
            string alphabetString = txtAlphabet.Text.Trim();
            if (!string.IsNullOrWhiteSpace(alphabetString))
            {
                encryptor.SetAlphabet(alphabetString, new System.Globalization.CultureInfo("tr-tr", false));
                //CollectionViewSource.GetDefaultView(CharMapGrid.ItemsSource).Refresh();
                CharMapGrid.DataContext = encryptor.charMapList;
                CollectionViewSource.GetDefaultView(CharMapGrid.ItemsSource).Refresh();
            }

        }

        private void CharMapGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*private void CharMapGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                string newVal = ((TextBox)e.EditingElement).Text.Trim();

                if (!string.IsNullOrWhiteSpace(newVal))
                {
                    CezarLib.CharMap original = (CezarLib.CharMap)e.Row.DataContext;

                    if ((string)e.Column.Header == "Original Char")
                    {
                        char charVal = newVal.ToCharArray()[0];
                        if (encryptor.charMapList.Any(m => m.CharValue == charVal) && charVal != original.CharValue)
                        {
                            MessageBox.Show("Value already Mapped");

                            e.Cancel = true;
                            ((TextBox)e.EditingElement).Text = original.CharValue.ToString();
                        }
                    }
                    else
                    {
                        int numVal;
                        if (int.TryParse(newVal, out numVal))
                        {
                            if (encryptor.charMapList.Any(m => m.NumberValue == numVal) && numVal != original.NumberValue)
                            {
                                MessageBox.Show("Value already Mapped");
                                e.Cancel = true;
                                ((TextBox)e.EditingElement).Text = original.NumberValue.ToString();
                            }
                        }

                    }

                }
            }
        }*/

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string sourceText = txtInput.Text.Trim();
            if (!string.IsNullOrWhiteSpace(sourceText))
            {
                string key = txtKeyword.Text.Trim();
                if (!string.IsNullOrWhiteSpace(key))
                {
                    encryptor.SetKeyWord(key, (KeywordType)cmbKeywordType.SelectedItem);
                }

                string encoded = encryptor.EncryptLine(sourceText);
                txtOutput.Text = encoded;
            }


        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string sourceText = txtDecryptInput.Text.Trim();
            if (!string.IsNullOrWhiteSpace(sourceText))
            {
                string key = txtDecryptKeyword.Text.Trim();
                if (!string.IsNullOrWhiteSpace(key))
                {
                    encryptor.SetKeyWord(key, (KeywordType)cmbDecryptKeywordType.SelectedItem);
                }

                string decrypted = encryptor.DecryptLine(sourceText);
                txtDecryptOutput.Text = decrypted;
            }


        }
    }
}
