using System;
using System.Linq;

namespace ProjectCSharp
{
    class Program
    {
        public static string Reverse(string text)
        {
            if (text == null) return text;

            char[] array = text.ToCharArray(); //we transform the string into an array of chars
            int length = array.Length;
            string reversedString = string.Empty;
            for (int i = length - 1; i >= 0; i--) //we go through the array from the end to the beginning and we add the characters to the reversedString
                reversedString += array[i];
            return reversedString; //we return the reversed string
        }

        public static int CountVowels(string text)
        {
            int nbOfVowels = 0;
            int len = text.Length;
            for (int i = 0; i < len; i++) //we go through the string and check each character if it is a vowel
            {
                if (text[i] == 'a' || text[i] == 'A' || text[i] == 'e' || text[i] == 'E' || text[i] == 'i' || text[i] == 'I' || text[i] == 'o' || text[i] == 'O' || text[i] == 'u' || text[i] == 'U')
                    nbOfVowels++; //if the character on the current position is a vowel, we count it
            }
            return nbOfVowels; //we return the number of vowels
        }

            public static int CountWords(string text)
             {
                int count = 0;
                for (int i = 1; i < text.Length; i++) //we go through the string
                {
                    if (char.IsWhiteSpace(text[i - 1]) == true) //We check if character on the previous position is a white space
                {
                        if (char.IsLetterOrDigit(text[i]) == true || char.IsPunctuation(text[i])) //we check if the character on the current position is a letter, a digit or punctuation
                    {
                            count++;
                        }
                    }
                }
                if (text.Length > 2) //if the string is greater than 2, it means that we have at least one word that we are counting
            {
                    count++;
                }
                return count; //we return the number of words
        }

        public static string TitleCaseString(string text)
        {
            if (text == null) return text;

            string[] words = text.Split(' '); //we divide the string into words
            for (int i = 0; i < words.Length; i++)//we go through the string of words
            {
                if (words[i].Length == 0) continue;

                Char firstChar = Char.ToUpper(words[i][0]); //we turn the first letter of the current word into a capital letter
                string rest = "";
                if (words[i].Length > 1) //if the word has more than one character, we convert all characters except the first into lowercase letters
                {
                    rest = words[i].Substring(1).ToLower();
                }
                words[i] = firstChar + rest;
            }
            return string.Join(" ", words); //we return the transformed strin
        }

        public static string LongestWord(string text )
        {
            if (text == null) return text;

            string currentWord = " ", maxWord = " ";
            char ch;
            int len = text.Length;
            int currentLength, maxLength = 0;
            for (int i = 0; i < len; i++)
            {
                ch = text[i];
                if (ch != ' ') //if the current character is not a space, we add the character to the current word
                {
                    currentWord += ch;
                }
                else
                {
                    currentLength = currentWord.Length - 1; //if the current character is a space, the length of the current word decreases by 1
                    if (currentLength > maxLength) //if the length of the current word is greater than the maximum length, the current word becomes the maximum word and its length is the maximum length
                    {
                        maxLength = currentLength;
                        maxWord = currentWord;
                    }
                    currentWord = " ";
                }
            }
            return maxWord;//we return the word with the longest length
        }
        public static string ShortestWord(string text)
        {
            if (text == null) return text;

            string currentWord = " ", minWord = " ";
            char ch;
            int len = text.Length;
            int currentLength, minLength = len;
           
            for (int i = 0; i < len; i++)
            {
                ch = text[i];
                if (ch != ' ') //if the current character is not a space, we add the character to the current word
                {
                    currentWord += ch;
                }
                else
                {
                    currentLength = currentWord.Length - 1;//if the current character is a space, the length of the current word decreases by 1
                    if (currentLength < minLength) //if the length of the current word is smaller than the minimum length, the current word becomes the minimum word and its length is the minimum length
                    {
                        minLength= currentLength;
                        minWord = currentWord;
                    }
                    currentWord = " ";
                }
            }
            return minWord; //we return the word with the shortest length
        }
        public static string MostFrequentWord(string text)
        {
            if (text == null) return text;

            int max = 0; //the maximum number of occurrences of the word in the string
            string word = " "; //the word that appears most times in the string
            string[] splitString = text.Split(' '); //we divide the string into words
            var arrayCount = splitString.GroupBy(a => a);
            foreach (var r in arrayCount)
            {
                if (r.Count() > max) //if the number of occurrences of r in the array is greater than the maximum number of occurrences, r.Key  becomes the word that appears most times and its number of occurrences becomes the maximum number of occurrences
                {
                    max = r.Count();
                    word = r.Key;
                }
                
            }
            return word; //we return the word that appears most times in the string
        }
         static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Enter a string you want to change then select an operation.");
            Console.WriteLine("1:Convert a string to uppercase");
            Console.WriteLine("2:Reverse a string");
            Console.WriteLine("3:Count the number of vowels in a string");
            Console.WriteLine("4:Count the number of words in a string");
            Console.WriteLine("5:Convert a string to title case");
            Console.WriteLine("6: Find the longest and shortest words in a string");
            Console.WriteLine("7:Find the most frequent word in a string");
            Console.WriteLine("8:Check if a string is a palindrome");

            Console.WriteLine("Enter your string here: ");
            string text = Console.ReadLine();   // Read the Input string from User 
            bool cont= true; //the variable that tells us when to stop
            while (cont)
            {
                Console.WriteLine("Enter the number of the operation you want to do");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: //Convert a string to uppercase

                        Console.WriteLine("String converted to uppercase: " + text.ToUpper());
                        break;
                    case 2: // Reverse a string
                        {
                            Console.WriteLine("Reversed string: " + Reverse(text));
                        }
                        break;
                    case 3: // Count the number of vowels in a string
                        {
                            Console.WriteLine("Number of vowels in the string: " + CountVowels(text));
                        }
                        break;
                    case 4: // Count the number of words in a string 
                        {
                            Console.WriteLine("Number of words in the string: " + CountWords(text));
                        }
                        break;
                    case 5: // Convert a string to title case
                        {
                            Console.WriteLine("String converted to title case: " + TitleCaseString(text));
                        }
                        break;
                    case 6: // Find the longest and shortest words in a string
                        {
                            Console.WriteLine("Shortest Word: " + ShortestWord(text));
                            Console.WriteLine("Longest Word : " + LongestWord(text));
                        }
                        break;
                    case 7: //Find the most frequent word in a string
                        {
                            Console.WriteLine("The most frequent word: " + MostFrequentWord(text));
                        }
                        break;
                    case 8://Check if a string is a palindrome
                        {
                            if (text == Reverse(text))
                                Console.WriteLine("Your string is a palindrome");
                            else
                                Console.WriteLine("Your string is not a palindrome");
                        }
                        break;
                    default:
                        Console.WriteLine("Your choice is not valid");
                        break;
                }
                Console.WriteLine("----------------------");
                Console.WriteLine("Do you want to quit? ");
                Console.WriteLine("yes/no: ");
                string quit = Console.ReadLine();
                if (quit == "yes")
                    cont = false;
            }
        }
    }
}
