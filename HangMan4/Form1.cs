using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangMan4
{
    public partial class Form1 : Form
    {
        private Bitmap[] HangManImages =        
            { 
            HangMan4.Properties.Resources.Hangman1,
            HangMan4.Properties.Resources.Hangman2,
            HangMan4.Properties.Resources.Hangman3,
            HangMan4.Properties.Resources.Hangman4,
            HangMan4.Properties.Resources.Hangman5,
            HangMan4.Properties.Resources.Hangman6,
            HangMan4.Properties.Resources.Hangman7,
            };

        private int _wrongGuess = 0;
        private int _length;
        private string _word;
        private string _spaces="";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
             lblWonOrLost.Text = "";
            _wrongGuess = 0;
            pbHangMan.Image = HangManImages[_wrongGuess];
            Words game = new Words();
            _word = game.Level("easy");
            _length = _word.Length;
            for (int i = 0; i < _length; i++)
            {
                _spaces += "_";
            }
            DisplaySpaces();
            btnEasy.Enabled = false;
            btnHard.Enabled = false;
        }

        private void DisplaySpaces()
        {
            for (int i = 0; i < _spaces.Length; i++)
            {
                lblWord.Text += _spaces.Substring(i, 1);
                lblWord.Text += " ";
                lblWordHidden.Text += _word.Substring(i, 1);
                lblWordHidden.Text += " ";
            }
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            Button letterBtn = sender as Button;
            string word = lblWordHidden.Text;
            string wordSpaces = lblWord.Text;
            char letterGuess = letterBtn.Text.ElementAt(0);

            if (lblWordHidden.Text == lblWord.Text)
            {
                lblWonOrLost.Text = "You Won";
            }
            else if (lblWordHidden.Text.Contains(letterBtn.Text))
            {
                char[] lettersWord = word.ToCharArray();
                char[] lettersGuessed = wordSpaces.ToCharArray();

                for (int i = 0; i < lettersWord.Length; i++)
                {
                    if (lettersWord[i] == letterGuess)
                    {
                        lettersGuessed[i] = letterGuess;
                    }
                    lblWord.Text = new string(lettersGuessed);                  
                }
            }
            
            else if (_wrongGuess < HangManImages.Length - 1)
            {
                _wrongGuess++;
                pbHangMan.Image = HangManImages[_wrongGuess];             
            }
            else
            {
                lblWonOrLost.Text = "Sorry you lost!";
            }
        }

        private void pbHangMan_Click(object sender, EventArgs e)
        {

        }

        private void btnHard_Click(object sender, EventArgs e)
        {                      
                lblWonOrLost.Text = "";
                _wrongGuess = 0;
                pbHangMan.Image = HangManImages[_wrongGuess];
                Words game = new Words();
                _word = game.Level("Hard");
                _length = _word.Length;
                for (int i = 0; i < _length; i++)
                {
                    _spaces += "_";
                }
                DisplaySpaces();
                btnHard.Enabled = false;
                btnEasy.Enabled = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }
    }
}
