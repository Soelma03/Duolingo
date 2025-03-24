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
using System.Windows.Shapes;

namespace Kursovaya_Duolingo_
{
    /// <summary>
    /// Логика взаимодействия для AddWordDialog.xaml
    /// </summary>
    public partial class AddWordDialog : Window
    {
        public string ForeignWord { get; private set; }
        public string Translation { get; private set; }
        public string Category { get; private set; }

        public AddWordDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ForeignWordTextBox.Text) ||
                string.IsNullOrWhiteSpace(TranslationTextBox.Text) ||
                CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ForeignWord = ForeignWordTextBox.Text;
            Translation = TranslationTextBox.Text;
            Category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DialogResult = true;
        }
    }
}
