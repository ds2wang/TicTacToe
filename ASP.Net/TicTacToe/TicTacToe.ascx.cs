using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class TicTacToe : System.Web.UI.UserControl
    {
        public char COMPUTER = 'O';
        /** Character constant for player symbol */
        public char PLAYER = 'X';

        public int turn = 0;
        // 2-D Array to represent Tic-Tac-Toe Board
        private char[,] ttt = new char[3, 3];
        Boolean inProgress = false;
        public Boolean compTurn = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            getInfo();
            if (isWinner(PLAYER) || isWinner(COMPUTER) || isStalemate())
            {
                if (isWinner(COMPUTER))
                {
                    lblStatus.Text = "Status: Computer Wins";
                }
                else if (isWinner(PLAYER))
                {
                    lblStatus.Text = "Status: Computer Wins";
                }
                else
                {
                    lblStatus.Text = "Status: Draw";
                }
                disable();
                return;
            }

        }
        public void disable()
        {
            r1c1.Enabled = false;
            r1c2.Enabled = false;
            r1c3.Enabled = false;
            r2c1.Enabled = false;
            r2c2.Enabled = false;
            r2c3.Enabled = false;
            r3c1.Enabled = false;
            r3c2.Enabled = false;
            r3c3.Enabled = false;
        }
        public void enable()
        {
            r1c1.Enabled = true;
            r1c2.Enabled = true;
            r1c3.Enabled = true;
            r2c1.Enabled = true;
            r2c2.Enabled = true;
            r2c3.Enabled = true;
            r3c1.Enabled = true;
            r3c2.Enabled = true;
            r3c3.Enabled = true;
        }
        public void clear()
        {
            r1c1.Text = " ";
            r1c2.Text = " ";
            r1c3.Text = " ";
            r2c1.Text = " ";
            r2c2.Text = " ";
            r2c3.Text = " ";
            r3c1.Text = " ";
            r3c2.Text = " ";
            r3c3.Text = " ";

        }
        public void getInfo()
        {
            if (lblSymbol.Text == "X")
            {
                COMPUTER = 'O';
                PLAYER = 'X';
            }
            else if (lblSymbol.Text == "O")
            {
                COMPUTER = 'X';
                PLAYER = 'O';
            }
            if (lblStatus.Text == "Status:")
            {
                inProgress = false;
            }
            else
            {
                inProgress = true;
            }
            if (lblTurn.Text == "Turn: Player")
            {
                compTurn = false;
            }
            else if (lblTurn.Text == "Turn: Computer")
            {
                compTurn = true;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    ttt[i, ii] = ' ';
                }
            }
            int t = 0;
            if (r1c1.Text.Trim() != "")
            {
                ttt[0, 0] = r1c1.Text.ElementAt(0);
                t++;
            }
            if (r1c2.Text.Trim() != "")
            {
                ttt[0, 1] = r1c2.Text.ElementAt(0);
                t++;
            }
            if (r1c3.Text.Trim() != "")
            {
                ttt[0, 2] = r1c3.Text.ElementAt(0);
                t++;
            }
            if (r2c1.Text.Trim() != "")
            {
                ttt[1, 0] = r2c1.Text.ElementAt(0);
                t++;
            }
            if (r2c2.Text.Trim() != "")
            {
                ttt[1, 1] = r2c2.Text.ElementAt(0);
                t++;
            }
            if (r2c3.Text.Trim() != "")
            {
                ttt[1, 2] = r2c3.Text.ElementAt(0);
                t++;
            }
            if (r3c1.Text.Trim() != "")
            {
                ttt[2, 0] = r3c1.Text.ElementAt(0);
                t++;
            }
            if (r3c2.Text.Trim() != "")
            {
                ttt[2, 1] = r3c2.Text.ElementAt(0);
                t++;
            }
            if (r3c3.Text.Trim() != "")
            {
                ttt[2, 2] = r3c3.Text.ElementAt(0);
                t++;
            }
            turn = t;

        }
        public void Main()
        {

            Random random = new Random();
            char nextMove;
            Boolean gameOver = false;
            random.NextDouble();
            Console.Out.WriteLine("\nWelcome to Tic Tac Toe, Doctor Falken!");
            Console.Out.WriteLine("You are '" + PLAYER + "' and I am '" + COMPUTER + "'!");
            Console.Out.WriteLine("On your mark.. get set.. and go!");

            // Randomly choose who will go first
            if (random.NextDouble() < 1)
            {
                nextMove = PLAYER;
                Console.Out.WriteLine("\nI'll let you go first.\n");
                displayBoard();
            }
            else
            {
                nextMove = COMPUTER;
                Console.Out.WriteLine("\nI want to go first.\n");
            }

            // Play the game!
            do
            {
                if (nextMove == PLAYER)
                {
                    playerMove();
                    gameOver = isWinner(PLAYER);
                    nextMove = COMPUTER;
                }
                else
                {
                    computerMove();
                    gameOver = isWinner(COMPUTER);
                    nextMove = PLAYER;
                }
                displayBoard();
            } while (!gameOver && !isStalemate());

            // Say who won!
            Console.Out.WriteLine("\n*** G A M E  O V E R! ***\n");
            if (isWinner(COMPUTER))
            {
                Console.Out.WriteLine("I win! Well, no surprises there.");
            }
            else if (isWinner(PLAYER))
            {
                Console.Out.WriteLine("I lost? Impossibru!");
            }
            else
            {
                Console.Out.WriteLine("Good game, looks like we tied but you got lucky");
            }
            Console.Out.WriteLine();
        }

        protected void r1c1_Click(object sender, EventArgs e)
        {
            if (r1c1.Text.Trim() == "")
            {
                r1c1.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }
        public void displayBoard()
        {
            r1c1.Text = ttt[0, 0].ToString();
            r1c2.Text = ttt[0, 1].ToString();
            r1c3.Text = ttt[0, 2].ToString();
            r2c1.Text = ttt[1, 0].ToString();
            r2c2.Text = ttt[1, 1].ToString();
            r2c3.Text = ttt[1, 2].ToString();
            r3c1.Text = ttt[2, 0].ToString();
            r3c2.Text = ttt[2, 1].ToString();
            r3c3.Text = ttt[2, 2].ToString();
            /*
           Console.Out.WriteLine("      Col 1 Col 2 Col 3");
           Console.Out.WriteLine("Row 1:  " + ttt[0,0] + "  |  " + ttt[0,1] + "  |  " + ttt[0,2]);
           Console.Out.WriteLine("      -----+-----+-----");
           Console.Out.WriteLine("Row 2:  " + ttt[1,0] + "  |  " + ttt[1,1] + "  |  " + ttt[1,2]);
           Console.Out.WriteLine("      -----+-----+-----");
           Console.Out.WriteLine("Row 3:  " + ttt[2,0] + "  |  " + ttt[2,1] + "  |  " + ttt[2,2]);
           Console.Out.WriteLine();*/
        }


        public void playerMove()
        {
            int row, col;


            turn++;
        }


        public Boolean checkhH1()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[0, i] == ' ')
                {
                    b++;
                }
                else if (ttt[0, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkhH2()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[2, i] == ' ')
                {
                    b++;
                }
                else if (ttt[2, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkhH3()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[1, i] == ' ')
                {
                    b++;
                }
                else if (ttt[1, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkhV1()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 0] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 0] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkhV2()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 2] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 2] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkhV3()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 1] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 1] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }

        public Boolean checkhD1()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, i] == ' ')
                {
                    b++;
                }
                else if (ttt[i, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkhD2()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[2 - i, i] == ' ')
                {
                    b++;
                }
                else if (ttt[2 - i, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (hm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        ///
        public Boolean checkcH1w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[0, i] == ' ')
                {
                    b++;
                }
                else if (ttt[0, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcH2w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[2, i] == ' ')
                {
                    b++;
                }
                else if (ttt[2, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcH3w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[1, i] == ' ')
                {
                    b++;
                }
                else if (ttt[1, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcV1w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 0] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 0] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcV2w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 2] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 2] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcV3w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 1] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 1] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcD1w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, i] == ' ')
                {
                    b++;
                }
                else if (ttt[i, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcD2w()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[2 - i, i] == ' ')
                {
                    b++;
                }
                else if (ttt[2 - i, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 2 && b == 1)
            {
                return true;
            }
            return false;
        }
        ////
        public Boolean checkcH1()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[0, i] == ' ')
                {
                    b++;
                }
                else if (ttt[0, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcH2()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[2, i] == ' ')
                {
                    b++;
                }
                else if (ttt[2, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcH3()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[1, i] == ' ')
                {
                    b++;
                }
                else if (ttt[1, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcV1()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 0] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 0] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcV2()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 2] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 2] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcV3()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, 1] == ' ')
                {
                    b++;
                }
                else if (ttt[i, 1] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcD1()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[i, i] == ' ')
                {
                    b++;
                }
                else if (ttt[i, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean checkcD2()
        {
            int cm = 0;
            int hm = 0;
            int b = 0;
            for (int i = 0; i < 3; i++)
            {
                if (ttt[2 - i, i] == ' ')
                {
                    b++;
                }
                else if (ttt[2 - i, i] == COMPUTER)
                {
                    cm++;
                }
                else
                {
                    hm++;
                }
            }
            if (cm == 1 && b == 2)
            {
                return true;
            }
            return false;
        }
        public Boolean isGoodMove(int cr, int cc, int hr, int hc)
        {
            ttt[cr, cc] = COMPUTER;
            ttt[hr, hc] = PLAYER;
            Boolean igm = !(checkhH1() || checkhH2() || checkhH3() | checkhV1() || checkhV2() || checkhV3() || checkhD1() || checkhD2());
            ttt[hr, hc] = ' ';
            ttt[cr, cc] = ' ';
            return igm;
        }
        public Boolean isGoodMove2(int cr, int cc, int hr, int hc)
        {
            ttt[cr, cc] = COMPUTER;
            ttt[hr, hc] = PLAYER;
            int bm = 0;
            if (checkhH1())
                bm++;
            if (checkhH2())
                bm++;
            if (checkhH3())
                bm++;
            if (checkhV1())
                bm++;
            if (checkhV2())
                bm++;
            if (checkhV3())
                bm++;
            if (checkhD1())
                bm++;
            if (checkhD2())
                bm++;
            Boolean igm = false;
            ttt[hr, hc] = ' ';
            ttt[cr, cc] = ' ';
            if (bm < 2)
            {
                igm = true;
            }
            return igm;
        }
        public Boolean forceBlockBack(int cr, int cc, int hr, int hc)
        {
            ttt[cr, cc] = COMPUTER;
            ttt[hr, hc] = PLAYER;
            Boolean good = false;
            String bblock = checkBlock();
            if (bblock != ("33"))
            {
                int nr = int.Parse(bblock.Substring(0, 1));
                int nc = int.Parse(bblock.Substring(1, 1));
                if (forceBlock(nr, nc))
                {
                    good = true;
                }
            }
            ttt[hr, hc] = ' ';
            ttt[cr, cc] = ' ';
            return good;
        }
        public Boolean forceBlock(int cr, int cc)
        {
            ttt[cr, cc] = COMPUTER;
            Boolean igm = (checkcH1w() || checkcH2w() || checkcH3w() | checkcV1w() || checkcV2w() || checkcV3w() || checkcD1w() || checkcD2w());
            ttt[cr, cc] = ' ';
            return igm;
        }
        public Boolean force2Blocks(int cr, int cc)
        {
            ttt[cr, cc] = COMPUTER;
            int bc = 0;
            if (checkcH1w())
                bc++;
            if (checkcH2w())
                bc++;
            if (checkcH3w())
                bc++;
            if (checkcV1w())
                bc++;
            if (checkcV2w())
                bc++;
            if (checkcV3w())
                bc++;
            if (checkcD1w())
                bc++;
            if (checkcD2w())
                bc++;
            ttt[cr, cc] = ' ';
            return (bc > 1);
        }
        public String forceWhichBlock(int cr, int cc)
        {
            ttt[cr, cc] = COMPUTER;
            String wb = "33";
            if (checkcH1w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[0, i] == ' ')
                    {
                        wb = "0" + i.ToString();
                    }
                }
            }
            else if (checkcH2w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[2, i] == ' ')
                    {
                        wb = "2" + i.ToString();
                    }
                }
            }
            else if (checkcH3w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[1, i] == ' ')
                    {
                        wb = "1" + i.ToString();
                    }
                }
            }
            else if (checkcV1w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[i, 0] == ' ')
                    {
                        wb = i.ToString() + "0";
                    }
                }
            }
            else if (checkcV2w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[i, 2] == ' ')
                    {
                        wb = i.ToString() + "2";
                    }
                }
            }
            else if (checkcV3w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[i, 1] == ' ')
                    {
                        wb = i.ToString() + "1";
                    }
                }
            }
            else if (checkcD1w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[i, i] == ' ')
                    {
                        wb = i.ToString() + i.ToString();
                    }
                }
            }
            else if (checkcD2w())
            {
                for (int i = 0; i < 3; i++)
                {
                    if (ttt[i, 2 - i] == ' ')
                    {
                        int s = 2 - i;
                        wb = i.ToString() + s.ToString();
                    }
                }
            }
            ttt[cr, cc] = ' ';
            return wb;
        }
        public void computerMove()
        {
            if (isWinner(PLAYER) || isWinner(COMPUTER) || isStalemate())
            {
                if (isWinner(COMPUTER))
                {
                    lblStatus.Text = "Status: Computer Wins";
                }
                else if (isWinner(PLAYER))
                {
                    lblStatus.Text = "Status: Computer Wins";
                }
                else
                {
                    lblStatus.Text = "Status: Draw";
                }
                disable();
                return;
            }
            Random random = new Random();
            int row, col;
            if (turn == 0)
            {
                int vv = (int)(random.NextDouble() * 4);
                if (vv == 0)
                {
                    row = 0;
                    col = 0;
                }
                else if (vv == 1)
                {
                    row = 0;
                    col = 2;
                }
                else if (vv == 2)
                {
                    row = 2;
                    col = 0;
                }
                else
                {
                    row = 2;
                    col = 2;
                }
                if (random.NextDouble() > 0.7)
                {
                    row = 1;
                    col = 1;
                }
                Console.Out.WriteLine("I have chosen Row " + (row + 1) + " and Column " + (col + 1) + " to put my O.\n");
                ttt[row, col] = COMPUTER;
                turn++;
                return;
            }
            if (turn == 1)
            {
                if (ttt[1, 1] == ' ')
                {
                    row = 1;
                    col = 1;
                    Console.Out.WriteLine("I have chosen Row " + (row + 1) + " and Column " + (col + 1) + " to put my O.\n");
                    ttt[row, col] = COMPUTER;
                    turn++;
                    return;
                }
                else
                {
                    int vv = (int)(random.NextDouble() * 4);
                    if (vv == 0)
                    {
                        row = 0;
                        col = 0;
                    }
                    else if (vv == 1)
                    {
                        row = 0;
                        col = 2;
                    }
                    else if (vv == 2)
                    {
                        row = 2;
                        col = 0;
                    }
                    else
                    {
                        row = 2;
                        col = 2;
                    }
                    Console.Out.WriteLine("I have chosen Row " + (row + 1) + " and Column " + (col + 1) + " to put my O.\n");
                    ttt[row, col] = COMPUTER;
                    turn++;
                    return;
                }

            }
            String block = checkBlock();
            String ween = checkWeen();
            if (ween != ("33"))
            {
                row = int.Parse(ween.Substring(0, 1));
                col = int.Parse(ween.Substring(1, 1));
                //ttt[row][col]=COMPUTER;

            }
            else if (block != (("33")))
            {
                row = int.Parse(block.Substring(0, 1));
                col = int.Parse(block.Substring(1, 1));
                // ttt[row][col]=COMPUTER;

            }
            else
            {
                row = 3;
                col = 3;
                int[,] ccount = new int[3, 3];
                for (int ii = 0; ii < 3; ii++)
                {
                    for (int iii = 0; iii < 3; iii++)
                    {
                        ccount[ii, iii] = 0;
                    }
                }
                for (; ; )
                {
                    int trow = (int)(random.NextDouble() * 3);
                    int tcol = (int)(random.NextDouble() * 3);
                    ccount[trow, tcol]++;
                    if (ttt[trow, tcol] == ' ')
                    {
                        if (force2Blocks(trow, tcol))
                        {
                            col = tcol;
                            row = trow;
                            break;
                        }
                    }
                    Boolean b = true;
                    for (int ii = 0; ii < 3; ii++)
                    {
                        for (int iii = 0; iii < 3; iii++)
                        {
                            if (ccount[ii, iii] == 0)
                            {
                                b = false;
                            }
                        }
                    }
                    if (b)
                    {
                        break;
                    }
                }
                for (int ii = 0; ii < 3; ii++)
                {
                    for (int iii = 0; iii < 3; iii++)
                    {
                        ccount[ii, iii] = 0;
                    }
                }
                if (row == 3)
                {
                    for (; ; )
                    {
                        int trow = (int)(random.NextDouble() * 3);
                        int tcol = (int)(random.NextDouble() * 3);
                        ccount[trow, tcol]++;
                        if (ttt[trow, tcol] == ' ')
                        {
                            if (forceBlock(trow, tcol))
                            {
                                String ss = forceWhichBlock(trow, tcol);
                                int hr = int.Parse(ss.Substring(0, 1));
                                int hc = int.Parse(ss.Substring(1, 1));
                                if (isGoodMove(trow, tcol, hr, hc))
                                {
                                    col = tcol;
                                    row = trow;
                                    if (turn == 2)
                                    {
                                        if (ttt[0, 0] == COMPUTER || ttt[2, 2] == COMPUTER || ttt[0, 2] == COMPUTER || ttt[2, 0] == COMPUTER)
                                        {
                                            if ((trow == 1 && tcol == 0) || (trow == 1 && tcol == 2) || (trow == 0 && tcol == 1) || (trow == 2 && tcol == 1))
                                            {
                                                col = 3;
                                                row = 3;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                   
                                }
                            }
                        }
                        Boolean b = true;
                        for (int ii = 0; ii < 3; ii++)
                        {
                            for (int iii = 0; iii < 3; iii++)
                            {
                                if (ccount[ii, iii] == 0)
                                {
                                    b = false;
                                }
                            }
                        }
                        if (b)
                        {
                            break;
                        }
                    }
                    for (int ii = 0; ii < 3; ii++)
                    {
                        for (int iii = 0; iii < 3; iii++)
                        {
                            ccount[ii, iii] = 0;
                        }
                    }
                }
                if (row == 3)
                {
                    for (; ; )
                    {
                        int trow = (int)(random.NextDouble() * 3);
                        int tcol = (int)(random.NextDouble() * 3);
                        ccount[trow, tcol]++;
                        if (ttt[trow, tcol] == ' ')
                        {
                            if (forceBlock(trow, tcol))
                            {
                                String ss = forceWhichBlock(trow, tcol);
                                int hr = int.Parse(ss.Substring(0, 1));
                                int hc = int.Parse(ss.Substring(1, 1));
                                if (isGoodMove2(trow, tcol, hr, hc))
                                {
                                    if (forceBlockBack(trow, tcol, hr, hc))
                                    {
                                        row = trow;
                                        col = tcol;
                                        break;
                                    }
                                }

                            }
                        }
                        Boolean b = true;
                        for (int ii = 0; ii < 3; ii++)
                        {
                            for (int iii = 0; iii < 3; iii++)
                            {
                                if (ccount[ii, iii] == 0)
                                {
                                    b = false;
                                }
                            }
                        }
                        if (b)
                        {
                            break;
                        }
                    }
                    for (int ii = 0; ii < 3; ii++)
                    {
                        for (int iii = 0; iii < 3; iii++)
                        {
                            ccount[ii, iii] = 0;
                        }
                    }
                }
                if (row == 3)
                {
                    for (; ; )
                    {
                        int trow = (int)(random.NextDouble() * 3);
                        int tcol = (int)(random.NextDouble() * 3);
                        ccount[trow, tcol]++;
                        if (ttt[trow, tcol] == ' ')
                        {
                            if (forceBlock(trow, tcol))
                            {
                                String ss = forceWhichBlock(trow, tcol);
                                int hr = int.Parse(ss.Substring(0, 1));
                                int hc = int.Parse(ss.Substring(1, 1));
                                if (isGoodMove2(trow, tcol, hr, hc))
                                {
                                    col = tcol;
                                    row = trow;
                                    break;
                                }
                            }
                        }
                        Boolean b = true;
                        for (int ii = 0; ii < 3; ii++)
                        {
                            for (int iii = 0; iii < 3; iii++)
                            {
                                if (ccount[ii, iii] == 0)
                                {
                                    b = false;
                                }
                            }
                        }
                        if (b)
                        {
                            break;
                        }
                    }
                }
                if (row == 3)
                {
                    do
                    {
                        row = (int)(random.NextDouble() * 3);
                        col = (int)(random.NextDouble() * 3);
                    } while (ttt[row, col] != ' ');
                }
                if (turn == 2)
                {
                    if (ttt[1, 1] == COMPUTER)
                    {
                        if (ttt[0, 0] == PLAYER)
                        {
                            row = 2;
                            col = 2;
                        }
                        if (ttt[2, 0] == PLAYER)
                        {
                            row = 0;
                            col = 2;
                        }
                        if (ttt[2, 2] == PLAYER)
                        {
                            row = 0;
                            col = 0;
                        }
                        if (ttt[0, 2] == PLAYER)
                        {
                            row = 2;
                            col = 0;
                        }
                    }
                    else if (ttt[1, 1] == PLAYER)
                    {
                        if (ttt[0, 0] == COMPUTER)
                        {
                            row = 2;
                            col = 2;
                        }
                        if (ttt[2, 0] == COMPUTER)
                        {
                            row = 0;
                            col = 2;
                        }
                        if (ttt[2, 2] == COMPUTER)
                        {
                            row = 0;
                            col = 0;
                        }
                        if (ttt[0, 2] == COMPUTER)
                        {
                            row = 2;
                            col = 0;
                        }
                    }

                }
            }
            Console.Out.WriteLine("I have chosen Row " + (row + 1) + " and Column " + (col + 1) + " to put my O.\n");

            ttt[row, col] = COMPUTER;
            if (isWinner(PLAYER) || isWinner(COMPUTER) || isStalemate())
            {
                if (isWinner(COMPUTER))
                {
                    lblStatus.Text = "Status: Computer Wins";
                }
                else if (isWinner(PLAYER))
                {
                    lblStatus.Text = "Status: Computer Wins";
                }
                else
                {
                    lblStatus.Text = "Status: Draw";
                }
                disable();
                return;
            }
            turn++;
        }
        public String checkBlock()
        {
            if (checkhH1())
            {
                if (ttt[0, 0] == ' ')
                {
                    return "00";
                }
                else if (ttt[0, 1] == ' ')
                {
                    return "01";
                }
                else
                {
                    return "02";
                }
            }
            else if (checkhH2())
            {
                if (ttt[2, 0] == ' ')
                {
                    return "20";
                }
                else if (ttt[2, 1] == ' ')
                {
                    return "21";
                }
                else
                {
                    return "22";
                }
            }
            else if (checkhH3())
            {
                if (ttt[1, 0] == ' ')
                {
                    return "10";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "12";
                }
            }
            else if (checkhV1())
            {
                if (ttt[0, 0] == ' ')
                {
                    return "00";
                }
                else if (ttt[1, 0] == ' ')
                {
                    return "10";
                }
                else
                {
                    return "20";
                }
            }
            else if (checkhV2())
            {
                if (ttt[0, 2] == ' ')
                {
                    return "02";
                }
                else if (ttt[1, 2] == ' ')
                {
                    return "12";
                }
                else
                {
                    return "22";
                }
            }
            else if (checkhV3())
            {
                if (ttt[0, 1] == ' ')
                {
                    return "01";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "21";
                }
            }
            else if (checkhD1())
            {
                if (ttt[0, 0] == ' ')
                {
                    return "00";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "22";
                }
            }
            else if (checkhD2())
            {
                if (ttt[2, 0] == ' ')
                {
                    return "20";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "02";
                }
            }

            return "33";
        }
        public String checkWeen()
        {
            if (checkcH1w())
            {
                if (ttt[0, 0] == ' ')
                {
                    return "00";
                }
                else if (ttt[0, 1] == ' ')
                {
                    return "01";
                }
                else
                {
                    return "02";
                }
            }
            else if (checkcH2w())
            {
                if (ttt[2, 0] == ' ')
                {
                    return "20";
                }
                else if (ttt[2, 1] == ' ')
                {
                    return "21";
                }
                else
                {
                    return "22";
                }
            }
            else if (checkcH3w())
            {
                if (ttt[1, 0] == ' ')
                {
                    return "10";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "12";
                }
            }
            else if (checkcV1w())
            {
                if (ttt[0, 0] == ' ')
                {
                    return "00";
                }
                else if (ttt[1, 0] == ' ')
                {
                    return "10";
                }
                else
                {
                    return "20";
                }
            }
            else if (checkcV2w())
            {
                if (ttt[0, 2] == ' ')
                {
                    return "02";
                }
                else if (ttt[1, 2] == ' ')
                {
                    return "12";
                }
                else
                {
                    return "22";
                }
            }
            else if (checkcV3w())
            {
                if (ttt[0, 1] == ' ')
                {
                    return "01";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "21";
                }
            }
            else if (checkcD1w())
            {
                if (ttt[0, 0] == ' ')
                {
                    return "00";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "22";
                }
            }
            else if (checkcD2w())
            {
                if (ttt[2, 0] == ' ')
                {
                    return "20";
                }
                else if (ttt[1, 1] == ' ')
                {
                    return "11";
                }
                else
                {
                    return "02";
                }
            }

            return "33";
        }


        public Boolean isWinner(char symbol)
        {
            // Check both diagonals
            if (((ttt[0, 0] == symbol) && (ttt[1, 1] == symbol) && (ttt[2, 2] == symbol)) ||
                ((ttt[0, 2] == symbol) && (ttt[1, 1] == symbol) && (ttt[2, 0] == symbol)))
            {
                return true;
            }
            // check horizontals
            for (int row = 0; row < 3; row++)
            {
                if ((ttt[row, 0] == symbol) && (ttt[row, 1] == symbol) && (ttt[row, 2] == symbol))
                {
                    return true;
                }
            }
            // check verticals
            for (int col = 0; col < 3; col++)
            {
                if ((ttt[0, col] == symbol) && (ttt[1, col] == symbol) && (ttt[2, col] == symbol))
                {
                    return true;
                }
            }
            return false;
        }


        public Boolean isStalemate()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (ttt[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            enable();
            if (ChkFirst.Checked)
            {
                COMPUTER = 'O';
                PLAYER = 'X';
                lblSymbol.Text = "X";
                clear();
                lblTurn.Text = "Turn: Player";
            }
            else
            {
                clear();
                lblSymbol.Text = "O";
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                displayBoard();
                lblTurn.Text = "Turn: Player";

            }
            lblStatus.Text = "Status: in progress";

        }

        protected void r1c2_Click(object sender, EventArgs e)
        {
            if (r1c2.Text.Trim() == "")
            {
                r1c2.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r1c3_Click(object sender, EventArgs e)
        {
            if (r1c3.Text.Trim() == "")
            {
                r1c3.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r2c1_Click(object sender, EventArgs e)
        {
            if (r2c1.Text.Trim() == "")
            {
                r2c1.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r2c2_Click(object sender, EventArgs e)
        {
            if (r2c2.Text.Trim() == "")
            {
                r2c2.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r2c3_Click(object sender, EventArgs e)
        {
            if (r2c3.Text.Trim() == "")
            {
                r2c3.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r3c1_Click(object sender, EventArgs e)
        {
            if (r3c1.Text.Trim() == "")
            {
                r3c1.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r3c2_Click(object sender, EventArgs e)
        {
            if (r3c2.Text.Trim() == "")
            {
                r3c2.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }

        protected void r3c3_Click(object sender, EventArgs e)
        {
            if (r3c3.Text.Trim() == "")
            {
                r3c3.Text = PLAYER.ToString();
                lblTurn.Text = "Turn: Computer";
                getInfo();
                computerMove();
                lblTurn.Text = "Turn: Player";
                displayBoard();
            }
        }
    }







}







