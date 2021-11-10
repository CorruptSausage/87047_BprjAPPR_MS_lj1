using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _87047_BprjAPPR_MS_lj1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region startupItemsJsla
            //Startup window size
            this.Height = 326;
            this.Width = 646;
            //This makes the basic value of the prg 26
            prgTurnsLeftJsla.Maximum = 26;
            #endregion
        }





        #region randomGeneratorJsla
        //Make random generator
        Random randomGeneratorJsla = new Random();
        #endregion

        #region resetGameMethodJsla
        public void resetGameJsla()
        {
            //Reset method, this bassicaly reset everything to the startup.
            lblLastGuesNumberJsla.ForeColor = Color.Black;
            lblGuesStatusJsla.ForeColor = Color.Black;
            lblGuesStatusJsla.Text = "No guesses made";
            lblCheatRandomNumberJsla.Text = "None";
            lblCheatMenuDifferenceJsla.Text = "0";
            prgTurnsLeftJsla.Maximum = 10;
            lblLastGuesNumberJsla.Text = "None";
        }
        #endregion

        #region GuessButtonJsla
        private void btnGuessJsla_Click(object sender, EventArgs e)
        {
            int parsedValueJsla;
            //First check if MaxNumber MinNumber and GuessNumber are not empty.
            if (string.IsNullOrEmpty(txbMaxNumberJsla.Text) || string.IsNullOrEmpty(txbMinNumberJsla.Text) || string.IsNullOrEmpty(txbGuessNumberJsla.Text))
            {
                MessageBox.Show("Min number, max number and guess number can't be empty", "Error");
            }
            else if (!int.TryParse(txbMinNumberJsla.Text, out parsedValueJsla))
            {
                MessageBox.Show("Min number and Max number can only contain integers", "Error.");
                return;
            }
            else if (!int.TryParse(txbMaxNumberJsla.Text, out parsedValueJsla))
            {
                MessageBox.Show("Min number and Max number can only contain integers", "Error.");
                return;
            }
            else if (!int.TryParse(txbGuessNumberJsla.Text, out parsedValueJsla))
            {
                MessageBox.Show("Min number and Max number can only contain integers", "Error.");
                return;
            }
            else if (Convert.ToInt32(txbMaxNumberJsla.Text) > 500)
            {
                MessageBox.Show("Number can't be higher than 500.");
            }
            else if (Convert.ToInt32(txbMinNumberJsla.Text) < 0 || Convert.ToInt32(txbMaxNumberJsla.Text) < 0 || Convert.ToInt32(txbGuessNumberJsla.Text) < 0)
            {
                MessageBox.Show("Numbers can't be lower than 0", "Error");
            }
            else if (lblCheatRandomNumberJsla.Text == "None")
            {
                if(cbxAmountTurnsJsla.SelectedItem == null)
                {
                    MessageBox.Show("Please select turn limit", "Error");
                }
                else
                {
                    prgTurnsLeftJsla.Maximum = Convert.ToInt32(cbxAmountTurnsJsla.Text);
                    prgTurnsLeftJsla.Value = Convert.ToInt32(cbxAmountTurnsJsla.Text);
                }
                
            }





            #region ErrorChecksJsla
            //Check if min and max are empty again
            if (string.IsNullOrEmpty(txbMinNumberJsla.Text) || string.IsNullOrEmpty(txbMaxNumberJsla.Text))
            {
                return;
            }
            //Check if Min number doesn't has only integers in them.
            
            else if (!int.TryParse(txbMinNumberJsla.Text, out parsedValueJsla))
            {
                MessageBox.Show("Min number and Max number can only contain integers", "Error.");
                return;
            }
            //Check if Max number doesn't has only integers in them.
            else if (!int.TryParse(txbMaxNumberJsla.Text, out parsedValueJsla))
            {
                MessageBox.Show("Min number and Max number can only contain integers", "Error.");
                return;
            }
            #endregion
            else
            {
                
                //Now generate random number

                //If the random number still is the startup "none" then it generator a number.
                if (lblCheatRandomNumberJsla.Text == "None")
                    {
                    int minNumberJsla = Convert.ToInt32(txbMinNumberJsla.Text);
                    int maxNumberJsla = Convert.ToInt32(txbMaxNumberJsla.Text);
                    if(minNumberJsla > maxNumberJsla)
                    {
                        MessageBox.Show("Minimum number can't be higher than max number", "Error.");
                    }
                    else
                    {
                        int randomNumber = randomGeneratorJsla.Next(minNumberJsla, maxNumberJsla);
                        lblCheatRandomNumberJsla.Text = Convert.ToString(randomNumber);
                    }
                    }
                    else
                    {
                        
                        
                    }

                //Guess
                
                //simple check if Guess textbox is not empty
                if (string.IsNullOrEmpty(txbGuessNumberJsla.Text))
                {
                        
                }
                    //Simple check if guess textbox only contain a integer.
                    else if (!int.TryParse(txbGuessNumberJsla.Text, out parsedValueJsla))
                    {
                        MessageBox.Show("Guess number can only contain numbers", "Error");
                    }



                #region gameCode
                //here the game code


                else
                {
                    if(string.IsNullOrEmpty(txbGuessNumberJsla.Text) || string.IsNullOrEmpty(lblGuessNumberTextJsla.Text))
                    {
                        return;
                    }
                    else
                    {
                        if(!int.TryParse(txbGuessNumberJsla.Text, out parsedValueJsla))
                        {
                            return;
                        }
                        else if (!int.TryParse(lblCheatRandomNumberJsla.Text, out parsedValueJsla))
                        {
                            return;
                        }
                        else
                        {
                            int guessNumberJsla = Convert.ToInt32(txbGuessNumberJsla.Text);
                            int randomNumberJsla = Convert.ToInt32(lblCheatRandomNumberJsla.Text);

                            if (guessNumberJsla > randomNumberJsla)
                            {
                                int differenceJsla = Convert.ToInt32(txbGuessNumberJsla.Text) - Convert.ToInt32(lblCheatRandomNumberJsla.Text);
                                lblCheatMenuDifferenceJsla.Text = Convert.ToString(differenceJsla);
                            }
                            //If guess number is smaller than random number difference is: random number - guessNumber
                            else
                            {
                                int differenceJsla = Convert.ToInt32(lblCheatRandomNumberJsla.Text) - Convert.ToInt32(txbGuessNumberJsla.Text);
                                lblCheatMenuDifferenceJsla.Text = Convert.ToString(differenceJsla);
                            }
                        }
                       
                    }
                }
                    
                    //If guess number is bigger than random number difference is: Guessnumber - random number.
                    

                //This check again if textbox and label string is empty.
                if(string.IsNullOrEmpty(txbGuessNumberJsla.Text) || string.IsNullOrEmpty(lblCheatRandomNumberJsla.Text.ToString()))
                {
                    

                }
                else
                {
                    //If player does not select amount of turns.
                    if(cbxAmountTurnsJsla.SelectedItem == null)
                    {
                        return;
                    }
                    //If turns left == 0 than the player lost the game.
                    else if (prgTurnsLeftJsla.Value == 0)
                    {
                        MessageBox.Show("You are out of turns and lost.", "Game lost");
                        resetGameJsla();
                    }
                    //this sets value and maximum to max amount of turns and turns left.
                    else if(prgTurnsLeftJsla.Maximum == 26)
                    {
                            prgTurnsLeftJsla.Maximum = Convert.ToInt32(cbxAmountTurnsJsla.Text);
                            prgTurnsLeftJsla.Value = Convert.ToInt32(cbxAmountTurnsJsla.Text);
                    }
                    //crash fix
                    if(lblCheatRandomNumberJsla.Text == "None")
                    {
                        return;
                    }
                    //If your number is equal to the mystery number.
                    int guessNumberJsla = Convert.ToInt32(txbGuessNumberJsla.Text);
                    int cheatRandomNumerJsla = Convert.ToInt32(lblCheatRandomNumberJsla.Text);

                    if (guessNumberJsla == cheatRandomNumerJsla)
                    {
                        //check if selecteditem is not nothing to prevent crashes.
                        if(cbxAmountTurnsJsla.SelectedItem == null)
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Guessed number is now equal to the mystery number, well done!", "Success");
                            prgTurnsLeftJsla.Maximum = Convert.ToInt32(cbxAmountTurnsJsla.Text);
                            prgTurnsLeftJsla.Value = Convert.ToInt32(cbxAmountTurnsJsla.Text);
                            resetGameJsla();
                        }
                        
                    }
                    //If not turns - 1 and change last number
                    else
                    {
                        if (string.IsNullOrEmpty(cbxAmountTurnsJsla.Text))
                        {
                            return;
                        }
                        else
                        {
                            prgTurnsLeftJsla.Value = prgTurnsLeftJsla.Value - 1;
                        }
                        
                        //Under comes hot and colder code

                        //First check if its the first guess
                        
                        if (lblLastGuesNumberJsla.Text == "None")
                        {
                            lblGuesStatusJsla.Text = "First guess.";
                            lblGuesStatusJsla.ForeColor = Color.Black;
                        }
                        else
                        //This part of the code handles the colors. and hotter, colder texts.
                        {
                                int differenceJsla = Convert.ToInt32(lblCheatMenuDifferenceJsla.Text);
                                if(differenceJsla <= 1)
                                {
                                lblGuesStatusJsla.Text = "Cannot be hotter!!!!";
                                lblGuesStatusJsla.ForeColor = Color.Red;
                                }
                                else if(differenceJsla <= 5)
                                {
                                    lblGuesStatusJsla.Text = "Super Hot";
                                    lblGuesStatusJsla.ForeColor = Color.Red;
                                }
                                else if(differenceJsla <= 10)
                                {
                                    lblGuesStatusJsla.Text = "Hotter";
                                    lblGuesStatusJsla.ForeColor = Color.Red;
                                }else if(differenceJsla <= 15)
                                {
                                    lblGuesStatusJsla.Text = "Hot";
                                    lblGuesStatusJsla.ForeColor = Color.OrangeRed;
                                }
                                else if (differenceJsla >= 25)
                                {
                                lblGuesStatusJsla.Text = "Coldest";
                                lblGuesStatusJsla.ForeColor = Color.DarkBlue;
                                }
                                else if (differenceJsla >= 20)
                                {
                                lblGuesStatusJsla.Text = "Colder";
                                lblGuesStatusJsla.ForeColor = Color.Blue;
                                }
                                else if(differenceJsla >= 15)
                                {
                                    lblGuesStatusJsla.Text = "Cold";
                                    lblGuesStatusJsla.ForeColor = Color.LightBlue;
                                }
                                
                        }
                        lblLastGuesNumberJsla.Text = txbGuessNumberJsla.Text;

                    }
                }
                #endregion
            }
        }
        #endregion

        #region aboutMeButtonJsla

        //Simple button, that pops up a messagebox
        private void btnAboutMeJsla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jordy Slaats, IC.21.SD.E", "About me");
        }
        #endregion

        #region LocationPathJsla
        //Simple button that opens locationPath
        private void btnLocatePathJsla_Click(object sender, EventArgs e)
        {
            MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().Location, "App location");
        }
        #endregion

        #region ExitButtonJsla

        //Simple exit button with yes or no dialog.
        private void btnExitJsla_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }else if(dialog == DialogResult.No)
            {
                return;
            }
        }
        #endregion

        #region openCheatsJsla
        private void btnMenuOpenCheatJsla_Click(object sender, EventArgs e)
        {
            //first check if size is normal
            if(this.Height == 326 || this.Height < 326)
            {
                //if size is normal change to new size.
                int newHeightJsla = 326 + 68;

                this.Height = newHeightJsla;

            }
            //if cheat menu is already open or the menu is even bigger than 394 than close and make it normal again.
            else if(this.Height == 394 || this.Height > 394)
            {
                int newHeightJsla = 326;

                this.Height = newHeightJsla;
            }
            //If something went wrong this messagebox will pop up.
            else
            {
                MessageBox.Show("Something went wrong with changing the height of the program.", "Error");
            }
        }
        #endregion

        #region openExtraMenuJsla
        private void btnMenuOpenExtraJsla_Click(object sender, EventArgs e)
        {
            //First check if windows size is normal
            if(this.Width == 646 || this.Width < 646)
            {
                //than change to new size
                int newWidthJsla = 646 + 224;

                this.Width = newWidthJsla;
                //check if window size is not normal.
            }else if(this.Width == 870 || this.Width > 646)
            {
                //than change to normal again
                int newWidthJsla = 646;

                this.Width = newWidthJsla;
            }
            else
            {
                //if something went wrong did error message will pop up.
                MessageBox.Show("Something went wrong with changing the width on the program.", "Error");
            }
        }

        #endregion

        #region ChangeColorJsla
        private void btnExtraMenuChangeColorJsla_Click(object sender, EventArgs e)
        {
            int value1 = randomGeneratorJsla.Next(1, 255);
            int value2 = randomGeneratorJsla.Next(1, 255);
            int value3 = randomGeneratorJsla.Next(1, 255);
            DialogResult dialog = MessageBox.Show("Do you want to change background of all buttons, or just the color button?", "Confirmation", MessageBoxButtons.YesNo);

            if(dialog == DialogResult.Yes)
            {
                btnMenuOpenCheatJsla.BackColor = Color.FromArgb(value1, value2, value3);
                btnMenuOpenExtraJsla.BackColor = Color.FromArgb(value1, value2, value3);
                btnGuessJsla.BackColor = Color.FromArgb(value1, value2, value3);
                btnExitJsla.BackColor = Color.FromArgb(value1, value2, value3);
                btnAboutMeJsla.BackColor = Color.FromArgb(value1, value2, value3);
                btnLocatePathJsla.BackColor = Color.FromArgb(value1, value2, value3);
                btnExtraMenuChangeColorJsla.BackColor = Color.FromArgb(value1, value2, value3);
            }
            else
            {
                btnExtraMenuChangeColorJsla.BackColor = Color.FromArgb(value1, value2, value3);
            }
            

            btnExtraMenuChangeColorJsla.BackColor = Color.FromArgb(value1, value2, value3);
        }
        #endregion
    }
}
