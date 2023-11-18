using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Пытаемся загрузить прогресс из файла
        int currentIndex = LoadProgress("name.txt");

        Question[] questions = new Question[]
        {
            new Question("Когда была основана компания Microsoft?", new[] { "1975", "1985", "1995", "2005" }, 0),
            new Question("Кто является автором произведения 'Война и мир'?", new[] { "Лев Толстой", "Федор Достоевский", "Александр Пушкин", "Иван Тургенев" }, 0),
            new Question("Что означает HTML в веб-разработке?", new[] { "Hyper Text Markup Language", "High Technical Machine Learning", "Home Tool Management Logic", "Hierarchy Text Management Language" }, 0),
            new Question("Какая самая высокая гора в мире?", new[] { "Килиманджаро", "Макинли", "Эверест", "Аконкагуа" }, 2),
            new Question("Что означает аббревиатура CPU в компьютерах?", new[] { "Computer Power Unit", "Central Processing Unit", "Common Programming Utility", "Cybernetic Processing Utility" }, 1),
            new Question("Какой газ является самым распространенным в атмосфере Земли?", new[] { "Азот", "Кислород", "Углекислый газ", "Аргон" }, 1),
            new Question("Какой язык программирования используется для создания динамических веб-страниц?", new[] { "JavaScript", "Python", "C++", "Ruby" }, 0),
            new Question("Какой элемент таблицы Менделеева является самым легким?", new[] { "Водород", "Гелий", "Литий", "Бериллий" }, 0),
            new Question("Кто написал произведение 'Гарри Поттер'?", new[] { "J.R.R. Толкиен", "Стивен Кинг", "Джоан Роулинг", "Дэн Браун" }, 2),
            new Question("Что означает аббревиатура 'FAQ'?", new[] { "Frequently Asked Questions", "Detailed Answers to Queries", "Formal Query Forms", "Regular Use of Queries" }, 0)
        };

        // Начинаем игру с текущего индекса
        for (int i = currentIndex; i < questions.Length; i++)
        {
            ManageQuestion(questions[i]);

            // Спрашиваем, хочет ли игрок сохранить прогресс
            Console.WriteLine("Do you want to save your progress? (y/n)");
            string saveChoice = Console.ReadLine().ToLower();
            if (saveChoice == "y")
            {
                SaveProgress("name.txt", i + 1); // Сохраняем следующий индекс в файле с именем "name"
                Console.WriteLine($"Progress saved. You can continue from question {i + 2} next time.");
            }
        }

        Console.WriteLine("Congratulations! You answered all questions correctly!");
    }

    static void ManageQuestion(Question question)
    {
        Console.WriteLine(question.Text);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
        }
        Console.WriteLine("Please enter your answer (number)");
        int answer = int.Parse(Console.ReadLine());
        if (question.Answers[answer - 1].IsCorrect)
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Incorrect");
            Environment.Exit(0);
        }
    }

    static void SaveProgress(string fileName, int currentIndex)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            // Записываем текущий индекс в файл
            writer.WriteLine(currentIndex);
        }
    }

    static int LoadProgress(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Считываем числовое значение из файла
                string indexString = reader.ReadLine();
                if (int.TryParse(indexString, out int loadedIndex))
                {
                    return loadedIndex;
                }
            }
        }

        // Если файл не существует или произошла ошибка при чтении, возвращаем значение по умолч
        return 0;
    }

class Question
{
    public Question(string text, string[] answers, int correctAnswer)
    {
        Text = text;
        Answers = new Answer[answers.Length];
        for (int i = 0; i < answers.Length; i++)
        {
            Answers[i] = new Answer(answers[i], i == correctAnswer);
        }
    }
    public string Text;
    public Answer[] Answers;
}

class Answer
{
    public Answer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }
    public string Text;
    public bool IsCorrect;
}
}

        

            
    
