using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form2 : Form
    {
        List<Card> deck = new List<Card>();

        List<Card> player1Hand = new List<Card>();
        List<Card> player2Hand = new List<Card>();

        
            
        public Form2()
        {
            InitializeComponent();
            CreateDeck();
            DealCards();
        }

        void CreateDeck()
        {
            for (int i = 0; i < 10; i++)
            {
                deck.Add(new Card(i + 1));
                deck.Add(new Card(i + 1));
            }
            deck.Add(new Card(11));
        }

        void DealCards()
        {
            Random r  = new Random();
            for(int i=0;i< 10; i++)
            {
                int cardPos = r.Next(deck.Count);
                player1Hand.Add(deck[cardPos]);
                deck.RemoveAt(cardPos);

                cardPos = r.Next(deck.Count);
                player2Hand.Add(deck[cardPos]);
                deck.RemoveAt(cardPos);
            }
            player2Hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
        //assign the card values (randomized) to the picture boxes (playercard)

        public void picturesOnCard(a)
        {
            switch()
            {
                case 0:
                    {
                        playercard1.Visible = true;
                        break;
                    }

                case 1:
                    {
                        playercard2.Visible = true;
                        break;
                    }

                case 2:
                    {
                        playercard3.Visible = true;
                        break;
                    }

                case 3:
                    {
                        playercard4.Visible = true;
                        break;
                    }
            }

        }

        private void playercard1_Click(object sender, EventArgs e)
        {
            Image card1 = Image.FromFile("card A.png");
            playercard1.Image = card1;
        }
    }
   
}


    //assign all 20 normal number cards with a value
    public class Card
    {
        public int numbers;

        public Card(int a)
        {

            numbers = a;

        }

        public int value()
        {
            return numbers;
        }

    }


