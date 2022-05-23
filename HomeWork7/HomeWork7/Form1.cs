using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Кабылбеков Галымжан
namespace HomeWork7
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;
        private int count;
        private Stack<int> stack;
        public Form1()
        {
            computerNumber = random.Next(99);
            StartGame(computerNumber);
            InitializeComponent();
            stack = new Stack<int>();
            UpdateGameState(userNumber, computerNumber);
        }
        private void stackReset()
        {
            for (int i = 0; i < count; i++)
                stack.Pop();
            userNumber = 0;
            count = 0;
        }
        private void UpdateGameState(int userNumber)
        {
            labelUserNumber.Text = $"Текущее число: {userNumber}";
            labelCount.Text = $"Количество шагов: {count}";
        }

        private void UpdateGameState(int userNumber, int computerNumber)
        {
            UpdateGameState(userNumber);
            this.computerNumber = computerNumber;
            labelComputerNumber.Text = $"Получите число: {computerNumber}";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            stackReset();
            
            UpdateGameState(userNumber, random.Next(20));
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            count++;
            stack.Push(2);
            UpdateGameState(userNumber *= 2);
            CheckWin();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            count++;
            stack.Push(1);
            UpdateGameState(++userNumber);
            CheckWin();
        }
        private void StartGame(int computerNumber)
        {
            MessageBox.Show("Играть", "Меню",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show($"Вы должны получить число {computerNumber} за минимальное количество ходов", "Меню",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CheckWin()
        {
            if (userNumber == computerNumber)
            {
                MessageBox.Show("Вы успешно завершили игру!", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    stackReset();
                    UpdateGameState(userNumber, random.Next(99));
                }
                else
                {
                    Close();
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (count != 0)
            {
                count--;
                UpdateGameState(stack.Pop() == 1 ? --userNumber : userNumber /= 2);
            }
        }
    }
}
