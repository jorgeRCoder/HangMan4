using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan4
{
    class Words
    {
        private string _level;
        private int _wordIndex;
        private string _word;
        private List<string> _lettersGuessed = new List<string>();
        private List<int> _lettersIndexes = new List<int>();
        private List<string> _lettersCorrect = new List<string>();
        private List<string> _lettersIncorrect = new List<string>();
        private int _guesses;
        private int _guessesWrong;
        private int _maxWrong = 10;
        public Words()
        {
        }

        public Words(string level,int wordIndex)
        {
            _level = level;
            _wordIndex = wordIndex;
        }

        public string getLevel()
        {
            return _level;
        }

        public string Level(string level)
        {
            string[] easy ={ "moon","sun", "earth", "ocean" };
            string[] hard = { "complexity", "ralativity", "science" };
            Random rand = new Random();

            _level = level;
            if (_level == "Hard")
            {
                _wordIndex = rand.Next(0, hard.Length);
                return _word = hard[_wordIndex];
            }            
            else
            {
                _wordIndex = rand.Next(0, easy.Length);
                return _word = easy[_wordIndex];
            }
        }

        public bool LetterGuess(string letter)
        {
            for (int i = 0; i < _word.Length; i++)
            {
                if (letter == _word.Substring(i, i + 1))
                {
                    _lettersIndexes.Add(i);
                    _guesses++;
                    for (int j = 0; j < _lettersGuessed.Count; j++)
                    {
                        if (letter != _lettersGuessed[j])
                        {
                            _lettersGuessed.Add(letter);
                            _lettersCorrect.Add(letter);
                        }
                    }
                    return true;
                }
                else
                {
                    _lettersIncorrect.Add(letter);
                    _guessesWrong++;
                    if (_guessesWrong == _maxWrong)
                    {
                        Console.WriteLine($"Game over");
                    }
                    return false;
                }
            }
            return false;
        }

        //public override string ToString()
        //{
        //    StringBuilder lg = new StringBuilder();
        //    for (int i = 0; i < _lettersGuessed.Count; i++)
        //    {
        //        lg.Append(_lettersGuessed[i]);
        //    }
        //    return lg.ToString();

        //    return $"{_word}";

        //    return $"level:{_level}, wordIndex:{_wordIndex}, word:{_word}," +
        //        $"lettersGuessed:{lg.ToString()}, lettersIndexes:{_lettersIndexes}," +
        //        $"lettersCorrect:{ _lettersCorrect.ToString()},lettersIncorrect:{_lettersIncorrect.ToString()}," +
        //        $"guesses:{_guesses},guessesWrong:{_guessesWrong},";
        //}
    }
    }
