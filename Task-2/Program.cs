using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Task_2
{


    /*English-French Vocabulary*/
    internal class Program
    {
        class EngFrench
        {
            public string OriginWorg { get; set; }
            public List<string> Translate;

            public EngFrench()
            {
                Translate = new List<string>();
            }
            public EngFrench(string originWorg, List<string> Translate)
            {
                OriginWorg = originWorg;

            }
        }
        class EngFrDictionary
        {
            EngFrench engFrench;
            Dictionary<string, List<string>> dictionary;
            public EngFrDictionary()
            {
                dictionary = new Dictionary<string, List<string>>();
                engFrench = new EngFrench();

            }

            public void AddWord()
            {
                engFrench = new EngFrench();
                Console.WriteLine("Enter a word : ");
                engFrench.OriginWorg = Console.ReadLine();


                int temp = 1;
                do
                {
                    Console.WriteLine("Enter a translate word :");
                    string translate = Console.ReadLine();
                    engFrench.Translate.Add(translate);
                    Console.WriteLine("do you want to add other variation of word ?");
                    Console.WriteLine("1-yes, 2-No");
                    temp = int.Parse(Console.ReadLine());

                } while (temp == 1);
                dictionary.Add(engFrench.OriginWorg, engFrench.Translate);
            }
            public void OutputVocabulary()
            {
                foreach (var word in dictionary)
                {
                    Console.Write(word.Key + ":" );
                    foreach (var words in word.Value)
                    {
                        Console.WriteLine("\t\t\t"+words);
                    }
                }

            }
            public void DeleteWord()
            {
                Console.WriteLine("Which word do u like to dlt?");
                string DelWord = Console.ReadLine();
                if (dictionary.Keys.Contains(DelWord))
                    dictionary.Remove(DelWord);
                else Console.WriteLine("Word wasn/t find");
            }
            public void DeleteVariantOfTranslate()
            {
                Console.WriteLine("Enter a word : ");
                string KeyWord = Console.ReadLine();
                int count = 0;

                foreach (var word in dictionary[KeyWord])
                {
                    Console.WriteLine(++count + ". " + word);
                }
                Console.WriteLine("Choose a variant of translate - 1 , 2 , 3 ...");
                int choice = int.Parse(Console.ReadLine());
                dictionary[KeyWord].Remove(dictionary[KeyWord][choice - 1]);

            }
            public void ChangeWord()
            {
                Console.WriteLine("Enter a word");
                string KeyWord = Console.ReadLine();
                if (dictionary.Keys.Contains(KeyWord))
                {
                    Console.WriteLine("Enter a New word");
                    string NewWord = Console.ReadLine();
                    dictionary.Add(NewWord, dictionary[KeyWord]);
                    dictionary.Remove(KeyWord);
                }


            }
            public void ChangeVariantOfTranslate()
            {
                Console.WriteLine("Enter a word : ");
                string KeyWord = Console.ReadLine();
                int count = 0;

                foreach (var word in dictionary[KeyWord])
                {
                    Console.WriteLine(++count + ". " + word);
                }
                Console.WriteLine("Choose a variant of translate for changing  :  1 , 2 , 3 ...");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new variant");
                string NewWord = Console.ReadLine();
                dictionary[KeyWord][choice - 1] = NewWord;

            }
            public void Search()
            {
                Console.WriteLine("Enter Word - translation");
                string KeyWord = Console.ReadLine();
                if (dictionary.ContainsKey(KeyWord))
                {
                    foreach (var word in dictionary[KeyWord])
                    {
                        Console.WriteLine(word);
                    }
                }
                else Console.WriteLine("Word wasn't find");
            }
      



        }
        class IDictionaryMenu
        {
            EngFrDictionary engFrDictionary;
            IDictionaryMenu(EngFrDictionary engFrDictionary)
            {
                this.engFrDictionary = engFrDictionary;
            }
            void Menu_Main()
            {
                int choice;
                do
                {
                    Console.WriteLine("Choose an action : ");
                    Console.WriteLine("1: Add word and variant of translate : "
                        + "\n2:Delete word"
                        + "\n3:Delete variant of translate"
                        + "\n4:Change word"
                        + "\n5:Change variant of translate"
                        + "\n6:Search the word"
                        + "\n7: Output Vocabulary"
                        + "\n0 Exit:");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: { Console.Clear(); engFrDictionary.AddWord(); } break;
                        case 2: { Console.Clear(); engFrDictionary.DeleteWord(); } break;
                        case 3: { Console.Clear(); engFrDictionary.DeleteVariantOfTranslate(); } break;
                        case 4: { Console.Clear(); engFrDictionary.ChangeWord(); } break;
                        case 5: { Console.Clear(); engFrDictionary.ChangeVariantOfTranslate(); } break;
                        case 6: { Console.Clear(); engFrDictionary.Search(); } break;
                        case 7: { Console.Clear(); engFrDictionary.OutputVocabulary();  } break;
                        case 0: { return; }
                        default: { Console.WriteLine("Incorrect choice!"); choice = 1; break; }
                    }
                } while (choice != 0);


            }
            static void Main(string[] args)
            {

                EngFrDictionary engFrDictionary = new EngFrDictionary();
                IDictionaryMenu dictionaryMenu = new IDictionaryMenu(engFrDictionary);
                dictionaryMenu.Menu_Main();




            }
        }
    }
}