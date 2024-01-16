using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "tiger", "elephant", "zebra", "giraffe", "gorilla", "lion", "deer", "bear" , "rhino" , "crocodile" , "octopus" , 
        "wolf" , "fox"};

        Console.WriteLine("Welcome to the Word Guessing Game! Guess the name of animals");

        while (true)
        {
            // Select a random word from the database
            string selectedWord = words[new Random().Next(words.Length)];
            string displayString = new string('_', selectedWord.Length);

            int maxIncorrectGuesses = 6;
            int incorrectGuesses = 0;

            Console.WriteLine($"Try to guess the name of animal: {displayString}");

            while (incorrectGuesses < maxIncorrectGuesses)
            {
                try
                {
                    // Ask the player to enter a letter for their guess
                    Console.Write("Enter a letter: ");
                    char guessedLetter = GetGuessedLetter();

                    // Check if the guessed letter is in the selected word
                    if (selectedWord.Contains(guessedLetter))
                    {
                        // Update the display string with correctly guessed letters
                        for (int i = 0; i < selectedWord.Length; i++)
                        {
                            if (selectedWord[i] == guessedLetter)
                            {
                                displayString = displayString.Substring(0, i) + guessedLetter + displayString.Substring(i + 1);
                            }
                        }

                        Console.WriteLine($"Correct! The word is: {displayString}");
                    }
                    else
                    {
                        // Track incorrect guesses and update hangman figure
                        incorrectGuesses++;
                        Displayfigure(incorrectGuesses);
                        Console.WriteLine($"Incorrect guesses: {incorrectGuesses}/{maxIncorrectGuesses}");
                    }

                    // Check if the player guessed the entire word
                    if (displayString == selectedWord)
                    {
                        Console.WriteLine("Congratulations! You guessed the word! You Won!");
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Display the correct word if the game is over
            Console.WriteLine($"The correct word was: {selectedWord}");
        }
        Console.WriteLine("Thank you for playing!");
    }

    static char GetGuessedLetter()
    {
        string input = Console.ReadLine().ToLower();

        if (input.Length == 1 && Char.IsLetter(input[0]))
        {
            return input[0];
        }
        else
        {
            throw new ArgumentException("Invalid input. Please enter a single letter.");
        }
    }

    static void Displayfigure(int incorrectGuesses)
    {
        // Display a figure based on incorrect guesses
        switch (incorrectGuesses)
        {
            case 1:
                Console.WriteLine("========");
                break;
            case 2:
                Console.WriteLine("=========");
                break;
            case 3:
                Console.WriteLine("========");
                break;
            case 4:
                Console.WriteLine("=======");
                break;
            case 5:
                Console.WriteLine("=========");
                break;
            case 6:
                Console.WriteLine("=========");
                break;
        }
    }
}
