using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7_2
{
    public partial class Form1 : Form
    {
        private int userNum;
        private int ComputerNum;
        private int count;
        private Random random = new Random();
        public Form1()
        {
            Start();
            InitializeComponent();
        }
        private void Start()
        {
            MessageBox.Show($"Вы должны отгадать число от 1 до 100 за наименьшее число попыток", "Угадай число",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            ComputerNum = random.Next(1,100);
        }
        private void buttonNewForm_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Owner = this;
            newForm.Show();
        }

        internal void NewUserNum(string s)
        {
            userNum = int.Parse(s);
            labelUserNum.Text = $"Ваше число: {userNum}";
            labelCount.Text = $"Количество попыток: {++count}";
            chekUserNum();
        }
        private void chekUserNum()
        {
            if (userNum == ComputerNum)
            {
                MessageBox.Show($"Поздравляю! Вы отгадали число {userNum} за {count} попыток.", "Угадай число",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Угадай число", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    reset();
                }
                else
                {
                    Close();
                }
            } else if (userNum < ComputerNum)
            {
                MessageBox.Show($"Число {userNum} меньше загаданного", "Угадай число",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show($"Число {userNum} больше загаданного", "Угадай число",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            ComputerNum = random.Next(1, 100);
            count = 0;
            labelUserNum.Text = $"Ваше число: ";
            labelCount.Text = $"Количество попыток: {count}";
        }
    }
}
