using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form2 : Form
    {
        private List<int> playerHand;
        private List<int> enemyHand;

        private int discarded;
        private int playerhangmansteps = 0;
        private int enemyhangmansteps = 0;
        private PictureBox[] enemycardss;
        public Form2()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            enemycardss = new PictureBox[]
            {
                enemycard0, enemycard1, enemycard2, enemycard3, enemycard4, enemycard5, enemycard6, enemycard7, enemycard8, enemycard9, enemycard10
            };
            playerHand = new List<int>();
            enemyHand = new List<int>();
            InitializeHands();
            setdiscbox();
            UpdateUI();

        }
        private void InitializeHands()
        {
            var deck = Enumerable.Range(1, 10).Concat(Enumerable.Range(1, 10)).Append(new Random().Next(1, 6)).OrderBy(x => Guid.NewGuid()).ToList();
            playerHand = deck.Take(10).ToList();
            enemyHand = deck.Skip(10).Take(11).ToList();
            removematch();
        }

        private void removematch()
        {
            var matchingcardss = playerHand.Intersect(enemyHand).ToList();
            foreach (var card in matchingcardss) { playerHand.Remove(card); enemyHand.Remove(card); }
        }
        private void setdiscbox()
        {
            discarded = 0;
        }
        private void UpdateUI()
        {
            for (int i = 0; i < playerHand.Count; i++)
            {
                string cardname = $"card {playerHand[i]}.png";
                ((PictureBox)Controls["playercard" + (i + 1)]).Image = Image.FromFile(cardname);
                ((PictureBox)Controls["playercard" + (i + 1)]).Visible = true;
            }
            for (int i = 0; i < enemyHand.Count; i++)
            {
                ((PictureBox)Controls["enemycard" + (i + 1)]).Image = null;
                ((PictureBox)Controls["enemycard" + (i + 1)]).Visible = true;
            }
            if (discarded != 0)
            {
                string cardname = $"card {discarded}.png";
                discard.Image = Image.FromFile(cardname);
            }//should have named 'discard' and 'discarded' more differently smh

            UpdateHangman();
        }
        private void UpdateHangman()
        {
            if (playerhangmansteps <=10)
            {
                playerhangman1.Image = Image.FromFile($"step{playerhangmansteps}.png");
            }
            if (enemyhangmansteps <=10)
            {
                enemyhangman2.Image = Image.FromFile($"step{enemyhangmansteps}.png");
            }

        }
        private void enemycard_Click(object sender, EventArgs e)
        {
            var clickedcard = (PictureBox)sender;
            int cardind = Array.IndexOf(enemycardss, clickedcard);

            if (cardind >= 0 && cardind < enemyHand.Count)
            {
                int selectedCard = enemyHand[cardind];
                enemyHand.RemoveAt(cardind);
                playerHand.Add(selectedCard);
                discarded = selectedCard;

                checkforroundEnd();
                UpdateUI();
            }
            
        }
        private void checkforroundEnd()
        {
            if (playerHand.Count == 1 && playerHand.Contains(discarded))
            {
                playerhangmansteps += discarded;
                if (playerhangmansteps >= 11)
                {
                    MessageBox.Show("You Win");
                    InitializeGame();
                }

            }
            else if (enemyHand.Count == 1 && enemyHand.Contains(discarded))
            {
                enemyhangmansteps += discarded;
                if (enemyhangmansteps >= 11)
                {
                    MessageBox.Show("You Lose");
                    InitializeGame();
                }
            }
        }
    }
}
