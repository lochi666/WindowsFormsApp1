using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{


    public partial class formGuesstheword : Form
    {
        List<string> words = new List<string>();
        string newText;
        int i = 0;
        int guessed = 0;
        
        
        public formGuesstheword()
        {
            InitializeComponent();
            Setup();
            
        }

        private void Setup()
        {
            throw new NotImplementedException();
        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (words[i].ToLower() == textBox1.Text.ToLower())
                {
                    if (i < words.Count - 1)
                    {
                        MessageBox.Show("GREAT JOB!");
                        textBox1.Text = "";
                        i += 1;
                        newText = Scramble(words[i]);
                        lblWord.Text = newText;
                        lblInfo.Text = "Words:" + (i + 1) + "of" + words.Count;
                        guessed = 0;
                        lblGuessed.Text = "Guessd:" + guessed + "times.";
                    }
                    else
                    {
                        lblWord.Text = "YOU WON, CONGRATULATIONS!";
                        return;
                    }
                }
                else
                {
                    guessed += 1;
                    lblGuessed.Text = "Guessed:" + guessed + "times.";
                }
                e.Handled = true;
            }

        }
        private void Setup(object FileReadlines)
        {
            string filePath = "words.text";
            words = File.Readlines(filePath).ToList();
            newText = Scramble(words[i]);
            lblWord.Text = newText;
            lblInfo.Text = "Words:" + (i + 1) + "of" + words.Count;
        }
        private string Scramble(string text)
        {
            return new string (text.ToCharArray().OrderBy(x =>Guid.NewGuid()).ToArray());
        }
    }
}
