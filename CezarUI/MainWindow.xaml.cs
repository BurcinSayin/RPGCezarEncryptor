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

namespace CezarUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CezarLib.CezarEncryptor encryptor;
        public MainWindow()
        {
            InitializeComponent();
            encryptor = new CezarLib.CezarEncryptor("0");

            InitCharMapTab();
        }

        private void InitCharMapTab()
        {
            //encryptor.charMapList;

            CharMapGrid.DataContext = encryptor.charMapList;
        }

        private void BtnSaveCharMap_Click(object sender, RoutedEventArgs e)
        {
            string trimmedVal = TxtMappedChar.Text.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedVal) && trimmedVal.Length == 1)
            {
                char charVal = trimmedVal.ToCharArray()[0];
                int numVal;
                if (int.TryParse(TxtMappedVal.Text, out numVal))
                {
                    bool charPresent = encryptor.charMapList.Any(m => m.CharValue == charVal);
                    bool numPresent = encryptor.charMapList.Any(m => m.NumberValue == numVal);

                    if(!charPresent && !numPresent)
                    {
                        encryptor.charMapList.Add(new CezarLib.CharMap
                        {
                            CharValue=charVal,
                            NumberValue=numVal
                        });

                        encryptor.charMapList = encryptor.charMapList.OrderBy(m=>m.CharValue).ToList();

                        TxtMappedChar.Text = string.Empty;
                        TxtMappedVal.Text = string.Empty;
                    }

                    CollectionViewSource.GetDefaultView(CharMapGrid.ItemsSource).Refresh();

                }
            }
        }

        private void CharMapGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharMapGrid.SelectedItem != null)
            {
                var targetMap = (CezarLib.CharMap)CharMapGrid.SelectedItem;

                TxtMappedChar.Text = targetMap.CharValue.ToString();
                TxtMappedVal.Text = targetMap.NumberValue.ToString();
            }
        }

        private void CharMapGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
            //CollectionViewSource.GetDefaultView(CharMapGrid.ItemsSource).Refresh();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string sourceText = txtInput.Text.Trim();
            if (!string.IsNullOrWhiteSpace(sourceText))
            {
                string key = txtKeyword.Text.Trim();
                if (!string.IsNullOrWhiteSpace(key))
                {
                    encryptor.SetKeyWord(key);
                }
                
                string encoded = encryptor.EncryptLine(sourceText);
                txtOutput.Text = encoded;
            }


        }
    }
}
