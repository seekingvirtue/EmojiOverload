using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Word-emoji dictionary: language -> word -> emoji
        var words = new Dictionary<string, Dictionary<string, string>>
        {
            ["English"] = new Dictionary<string, string>
            {
                ["Dog"] = "🐶",
                ["Cat"] = "🐱",
                ["Sun"] = "☀️",
                ["Apple"] = "🍎",
                ["Car"] = "🚗"
            },
            ["Spanish"] = new Dictionary<string, string>
            {
                ["Perro"] = "🐶",
                ["Gato"] = "🐱",
                ["Sol"] = "☀️",
                ["Manzana"] = "🍎",
                ["Coche"] = "🚗"
            },
            ["French"] = new Dictionary<string, string>
            {
                ["Chien"] = "🐶",
                ["Chat"] = "🐱",
                ["Soleil"] = "☀️",
                ["Pomme"] = "🍎",
                ["Voiture"] = "🚗"
            }
        };

        var rand = new Random();
        var languages = new List<string>(words.Keys);
        int score = 0;

        while (true)
        {
            // Pick a random language
            string language = languages[rand.Next(languages.Count)];
            var wordList = new List<string>(words[language].Keys);
            // Pick a random word
            string word = wordList[rand.Next(wordList.Count)];
            string correctEmoji = words[language][word];

            // Pick a random incorrect emoji
            string wrongEmoji;
            do
            {
                string wrongWord = wordList[rand.Next(wordList.Count)];
                wrongEmoji = words[language][wrongWord];
            } while (wrongEmoji == correctEmoji);

            // Randomize left/right position
            bool correctOnLeft = rand.Next(2) == 0;
            string leftEmoji = correctOnLeft ? correctEmoji : wrongEmoji;
            string rightEmoji = correctOnLeft ? wrongEmoji : correctEmoji;

            Console.Clear();
            Console.WriteLine($"Language: {language}");
            Console.WriteLine($"Select the emoji for: {word}");
            Console.WriteLine();
            Console.WriteLine($"[Left]  {leftEmoji}     {rightEmoji}  [Right]");
            Console.WriteLine();
            Console.WriteLine("Press Left or Right arrow key. Press Esc to quit.");

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
                break;
            bool isCorrect = (key.Key == ConsoleKey.LeftArrow && correctOnLeft) ||
                             (key.Key == ConsoleKey.RightArrow && !correctOnLeft);
            if (isCorrect)
            {
                Console.WriteLine("Correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct emoji was: {correctEmoji}\n");
            }
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("Press any key for next round...");
            Console.ReadKey(true);
        }
        Console.WriteLine($"\nFinal Score: {score}");
        Console.WriteLine("Thanks for playing!");
    }
}
