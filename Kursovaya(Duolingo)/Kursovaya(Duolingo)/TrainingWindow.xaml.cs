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
    /// Логика взаимодействия для TrainingWindow.xaml
    /// </summary>
    public partial class TrainingWindow : Window
    {
        private List<Word> trainingWords;
        private int currentWordIndex;
        private int correctAnswersCount;
        private List<string> answerOptions;
        public event EventHandler<TrainingCompletedEventArgs> TrainingCompleted;

        public TrainingWindow(List<Word> words)
        {
            InitializeComponent();

            if (words.Count < 4)
            {
                MessageBox.Show("Недостаточно слов для тренировки! Нужно хотя бы 4.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
                return;
            }

            trainingWords = words.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            currentWordIndex = 0;
            correctAnswersCount = 0;
            ShowNextTrainingWord();
        }

        private void ShowNextTrainingWord()
        {
            if (currentWordIndex >= trainingWords.Count)
            {
                MessageBox.Show($"Тренировка завершена! Правильных ответов: {correctAnswersCount} из {trainingWords.Count}.", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                TrainingCompleted?.Invoke(this, new TrainingCompletedEventArgs
                {
                    CorrectAnswers = correctAnswersCount,
                    TotalAnswers = trainingWords.Count
                });

                Close();
                return;
            }

            var word = trainingWords[currentWordIndex];

            // Генерируем варианты ответов
            answerOptions = trainingWords
                .Where(w => w.Translation != word.Translation)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .Select(w => w.Translation)
                .ToList();

            answerOptions.Add(word.Translation);
            answerOptions = answerOptions.OrderBy(x => Guid.NewGuid()).ToList();

            // Устанавливаем текст в элементы
            TrainingWordLabel.Content = $"Переведите слово: {word.ForeignWord}";
            Answer1Button.Content = answerOptions[0];
            Answer2Button.Content = answerOptions[1];
            Answer3Button.Content = answerOptions[2];
            Answer4Button.Content = answerOptions[3];

            currentWordIndex++;
        }

        private void CheckTrainingAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (currentWordIndex == 0 || currentWordIndex > trainingWords.Count) return;

            Button clickedButton = sender as Button;
            string selectedAnswer = clickedButton.Content.ToString();
            string correctAnswer = trainingWords[currentWordIndex - 1].Translation;

            if (selectedAnswer == correctAnswer)
            {
                correctAnswersCount++;
                MessageBox.Show("Правильно!", "✅", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Неправильно! Правильный ответ: {correctAnswer}", "❌", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            ShowNextTrainingWord();
        }
    }
}
