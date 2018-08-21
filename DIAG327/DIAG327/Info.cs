﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace DIAG327
{
    public partial class Info : Form
    {       
        public Info()
        {
            InitializeComponent();
            info_comboBox.SelectedIndex = 0;
        }

        private void info_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (info_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 1:
                    {
                        info_richTextBox.Text = "ff";
                        break;
                    }
                case 2:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 3:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 4:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 5:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 6:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 7:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 8:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 9:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 10:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 11:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 12:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 13:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 14:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 15:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 16:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 17:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 18:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
                case 19:
                    {
                        info_richTextBox.Text = "При достижении температуры отметки в 104 градуса по Цельсию может произойти заклинивание двигателя. Предельно допустимые температуры ограничиваются свойствами охлаждающей жидкости. Если температура кипения воды составляет 100 градусов, то температура кипения тосола может варьироваться от 108 до 138 градусов Цельсия.";
                        break;
                    }
            }

        }
    }
}
