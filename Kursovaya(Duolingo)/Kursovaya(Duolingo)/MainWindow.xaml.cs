using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.IO;

namespace Kursovaya_Duolingo_
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();
        public ObservableCollection<Word> FilteredWords { get; set; } = new ObservableCollection<Word>();


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;  // Добавляем связь контекста данных
            LoadData();
            CorrectAnswers = 0;
            TotalAnswers = 0;
            SelectedCategory = Categories.FirstOrDefault();  // По умолчанию первая категория
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                LoadWordsForCategory();
            }
        }

        private Word _currentWord;
        public Word CurrentWord
        {
            get => _currentWord;
            set
            {
                _currentWord = value;
                OnPropertyChanged(nameof(CurrentWord));
            }
        }

        private string _userAnswer;
        public string UserAnswer
        {
            get => _userAnswer;
            set
            {
                _userAnswer = value;
                OnPropertyChanged(nameof(UserAnswer));
            }
        }

        private int _correctAnswers;
        public int CorrectAnswers
        {
            get => _correctAnswers;
            set
            {
                _correctAnswers = value;
                OnPropertyChanged(nameof(CorrectAnswers));
            }
        }

        private int _totalAnswers;
        public int TotalAnswers
        {
            get => _totalAnswers;
            set
            {
                _totalAnswers = value;
                OnPropertyChanged(nameof(TotalAnswers));
            }
        }

        public ICommand AddWordCommand { get; }

        public void LoadData()
        {
            Words = new ObservableCollection<Word>
                {
                    new Word("Cat", "Кошка", "Животные"),
                    new Word("Dog", "Собака", "Животные"),
                    new Word("Elephant", "Слон", "Животные"),
                    new Word("Apple", "Яблоко", "Еда"),
                    new Word("Banana", "Банан", "Еда"),
                    new Word("Orange", "Апельсин", "Еда"),
                    new Word("Carrot", "Морковь", "Еда"),
                    new Word("Potato", "Картошка", "Еда"),
                    new Word("Tomato", "Помидор", "Еда"),
                    new Word("Car", "Машина", "Транспорт"),
                    new Word("Bicycle", "Велосипед", "Транспорт"),
                    new Word("Airplane", "Самолет", "Транспорт"),
                    new Word("Bus", "Автобус", "Транспорт"),
                    new Word("Red", "Красный", "Цвета"),
                    new Word("Blue", "Синий", "Цвета"),
                    new Word("Green", "Зеленый", "Цвета")
                };
            Categories = new ObservableCollection<string> { "Животные", "Еда", "Транспорт", "Цвета" };
            FilteredWords = new ObservableCollection<Word>(Words);
            UpdateWordCount();
            UpdateWordsList();
        }



        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(Words);
            File.WriteAllText("words.json", json);
        }

        private void LoadWordsForCategory()
        {
            if (string.IsNullOrEmpty(SelectedCategory)) return;

            FilteredWords.Clear();
            foreach (var word in Words.Where(w => w.Category == SelectedCategory))
            {
                FilteredWords.Add(word);
            }
        }

        private void ShowNextWord()
        {
            if (Words.Count == 0) return;

            Random rand = new Random();
            CurrentWord = Words[rand.Next(Words.Count)];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWord();
        }

        private void AddWord()
        {
            var dialog = new AddWordDialog();
            if (dialog.ShowDialog() == true) // Если пользователь нажал "OK"
            {
                if (!string.IsNullOrWhiteSpace(dialog.ForeignWord) &&
                    !string.IsNullOrWhiteSpace(dialog.Translation) &&
                    !string.IsNullOrWhiteSpace(dialog.Category))
                {
                    var newWord = new Word(dialog.ForeignWord, dialog.Translation, dialog.Category);
                    Words.Add(newWord); // Добавляем слово в коллекцию
                    UpdateWordCount();

                    if (!Categories.Contains(dialog.Category))
                    {
                        Categories.Add(dialog.Category); // Добавляем категорию, если ее нет
                    }
                    LoadWordsForCategory(); // <-- Добавляем вызов, чтобы обновить список
                    SaveData(); // Сохраняем изменения
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем диалог открытия файла
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*", // Фильтр для JSON-файлов
                Title = "Выберите файл со словами"
            };

            // Показываем диалог и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                LoadWordsFromFile(filePath); // Загружаем слова из файла
            }
        }

        private void LoadWordsFromFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var words = JsonConvert.DeserializeObject<List<Word>>(json);

                if (words != null)
                {
                    Words = new ObservableCollection<Word>(words);
                    Categories = new ObservableCollection<string>(words.Select(w => w.Category).Distinct());
                }
                UpdateWordCount();
                MessageBox.Show("Слова успешно загружены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            var trainingWindow = new TrainingWindow(Words.ToList());
            trainingWindow.TrainingCompleted += OnTrainingCompleted;
            trainingWindow.ShowDialog();
        }
        private void OnTrainingCompleted(object sender, TrainingCompletedEventArgs e)
        {
            CorrectAnswers += e.CorrectAnswers;
            OnPropertyChanged(nameof(CorrectAnswers));
            TotalAnswers += e.TotalAnswers;
            OnPropertyChanged(nameof(TotalAnswers));
            CorrectAnswersLabel.Content = $"Правильных ответов: {CorrectAnswers}";
            TotalAnswersLabel.Content = $"Всего ответов: {TotalAnswers}";
        }


        private void ResetWordsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить все пользовательские слова?", "Подтверждение",
            MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                LoadData(); // Перезагружаем список, оставляя только слова по умолчанию
                UpdateWordCount();
                SaveData(); // Сохраняем изменения
                MessageBox.Show("Список слов сброшен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private int _wordCount;
        public int WordCount
        {
            get => _wordCount;
            set
            {
                _wordCount = value;
                OnPropertyChanged(nameof(WordCount));
            }
        }

        private void UpdateWordCount()
        {
            WordCount = Words.Count;
        }

        private void UpdateWordsList()
        {
            if (string.IsNullOrEmpty(SelectedCategory))
            {
                // Если категория не выбрана, показываем все слова
                FilteredWords.Clear();
                foreach (var word in Words)
                {
                    FilteredWords.Add(word);
                }
            }
            else
            {
                FilteredWords.Clear();

                // Фильтруем слова по выбранной категории
                var wordsInCategory = Words.Where(w => w.Category == SelectedCategory).ToList();

                // Обновляем коллекцию FilteredWords
                foreach (var word in wordsInCategory)
                {
                    FilteredWords.Add(word);
                }
            }
        }

        private void CategoryComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                SelectedCategory = selectedItem.Content.ToString();
                LoadWordsForCategory();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Сохранить список слов"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(Words);
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Слова успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
