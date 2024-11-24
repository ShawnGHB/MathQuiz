using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create a Random object called rand
        //to generate random numbers
        Random rand = new Random();

        //values store numbers for the adding problems
        int addend1;
        int addend2;

        //values store numbers for the subbing problems
        int minusend1;
        int minusend2;

        //values store numbers for the times problems
        int mult1;
        int mult2;

        //values store numbers for the diving probelms
        int divi1;
        int divi2;

        //This integer variable keeps track of time left
        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problem
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1'
            addend1 = rand.Next(51);
            addend2 = rand.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //sum is the NumericUpDown control
            //makes sure it start with a value of zero first
            sum.Value = 0;

            //subtraction problem
            minusend1 = rand.Next(1, 101);
            minusend2 = rand.Next(0, minusend1);
            minusLeftLabel.Text = minusend1.ToString();
            minusRightLabel.Text = minusend2.ToString();
            difference.Value = 0;

            //multiplication problem
            mult1 = rand.Next(0, 11);
            mult2 = rand.Next(2, 11);
            timesLeftLabel.Text = mult1.ToString();
            timesRightLabel.Text = mult2.ToString();
            product.Value = 0;

            //division problem
            divi1 = rand.Next(2, 11);
            int tempQuotient = rand.Next(1, 11);
            divi2 = divi1 * tempQuotient;
            dividedLeftLabel.Text = divi2.ToString();
            dividedRightLabel.Text = divi1.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        /// <summary>
        /// Check the answers to see if the user is correct
        /// </summary>
        /// <returns>True if the answers are right, false otherwise</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minusend1 - minusend2 == difference.Value)
                && (mult1 * mult2 == product.Value)
                && (divi2 / divi1 == quotient.Value))
                return true;
            else
                return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() returns false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minusend1 - minusend2;
                product.Value = mult1 * mult2;
                quotient.Value = divi2 / divi1;
                startButton.Enabled = true;
            }

            if (timeLeft <= 5 && timeLeft != 0) timeLabel.BackColor = Color.Red;
            else timeLabel.BackColor = Color.White;
        }

        private void answer_Enter(object sender, EventArgs e)
        {

            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }

        }

        private void sumcorrect_Answer(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (addend1 + addend2 == sum.Value)
            {
                //sound here
            }
        }

        private void diff_CorrectAnswer(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (minusend1 - minusend2 == difference.Value)
            {
                //sound here
            }
        }

        private void product_CorrectAnswer(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (mult1 * mult2 == product.Value)
            {
                //sound here
            }
        }

        private void quotient_CorrectAnswer(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;
            if (divi2 / divi1 == quotient.Value)
            {
                //sound here
            }
        }
    }
}
