using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;


namespace DIAG327
{
    public class Logic
    {
        public Logic()
        {

        }

        public void Init_Config(SerialPort s1, ProgressBar bar)
        {
            bar.PerformStep();
            s1.Write("ATZ\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATE0\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATH0\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATAL\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATS1\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATST80\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATSH8110F1\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATIIA10\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATSP5\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATSW00\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("ATFI\n\r");
            Thread.Sleep(1000);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("10 81 0A\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.PerformStep();
            s1.Write("3E 01\n\r");
            Thread.Sleep(500);
            s1.ReadTo(">");
            bar.Step = 4;
            bar.PerformStep();
        }

        public string Auto_Info(SerialPort s1, string command)
        {
            s1.Write(command);

            string stringData = s1.ReadTo(">");
            string[] stringDataSplit = stringData.Split(' ');
            char[] charData = new char[stringDataSplit.Length];
            string result = "";

            for (int i = 0; i < stringDataSplit.Length - 1; i++)
            {
                if (stringDataSplit[i] != "FF")
                {
                    charData[i] = (char)Convert.ToInt32(stringDataSplit[i], 16);
                    result += charData[i].ToString();
                }
            }

            return result;
        }

        public double[] RLI_ASS(SerialPort s1)
        {
            s1.Write("21 01\n\r");

            string stringData = s1.ReadTo(">");
            string[] stringDataSplit = stringData.Split(' ');
            double[] doubleData = new double[20];

            doubleData[0] = Convert.ToInt32(stringDataSplit[10], 16) - 40.0;
            doubleData[1] = (Convert.ToInt32(stringDataSplit[11], 16) + 128.0) * 14.7 / 256.0;
            doubleData[2] = Convert.ToInt32(stringDataSplit[12], 16);
            doubleData[3] = Convert.ToInt32(stringDataSplit[13], 16) * 40.0;
            doubleData[4] = Convert.ToInt32(stringDataSplit[14], 16) * 10.0;
            doubleData[5] = Convert.ToInt32(stringDataSplit[15], 16);
            doubleData[6] = Convert.ToInt32(stringDataSplit[16], 16);
            doubleData[7] = (Convert.ToInt32(stringDataSplit[17], 16) + 128.0) / 256.0;
            doubleData[8] = Convert.ToInt32(stringDataSplit[18], 16) / 2.0;
            doubleData[9] = Convert.ToInt32(stringDataSplit[19], 16);
            doubleData[10] = Convert.ToInt32(stringDataSplit[20], 16) * 0.05 + 5.2;
            doubleData[11] = Convert.ToInt32(stringDataSplit[21], 16) * 10.0;
            doubleData[12] = Convert.ToInt32(stringDataSplit[22], 16) / 256.0 * 1.25;
            doubleData[13] = Convert.ToInt32(stringDataSplit[23], 16);
            doubleData[14] = Convert.ToInt32(stringDataSplit[24] + stringDataSplit[25], 16) / 125.0;
            doubleData[15] = Convert.ToInt32(stringDataSplit[26] + stringDataSplit[27], 16) / 10.0;
            doubleData[16] = Convert.ToInt32(stringDataSplit[28] + stringDataSplit[29], 16) / 6.0;
            doubleData[17] = Convert.ToInt32(stringDataSplit[30] + stringDataSplit[31], 16);
            doubleData[18] = Convert.ToInt32(stringDataSplit[32] + stringDataSplit[33], 16) / 128.0;
            doubleData[19] = Convert.ToInt32(stringDataSplit[34] + stringDataSplit[35], 16);

            return doubleData;
        }

        public double[] RLI_FT(SerialPort s1)
        {
            s1.Write("21 03\n\r");

            string stringData = s1.ReadTo(">");
            string[] stringDataSplit = stringData.Split(' ');
            double[] doubleData = new double[20];

            doubleData[0] = Convert.ToInt32(stringDataSplit[2], 16) * 5.0 / 256.0;
            doubleData[1] = Convert.ToInt32(stringDataSplit[3], 16) * 5.0 / 256.0;
            doubleData[2] = Convert.ToInt32(stringDataSplit[4], 16) * 5.0 / 256.0;
            doubleData[3] = Convert.ToInt32(stringDataSplit[5], 16) * 0.287 * 5.0 / 256.0;
            doubleData[4] = Convert.ToInt32(stringDataSplit[6], 16) * 5.0 / 256.0;
            doubleData[5] = Convert.ToInt32(stringDataSplit[7], 16) * 5.0 / 256.0;

            return doubleData;
        }

        public void Parameters_manager_ON(SerialPort s1, int selected_index, Label l1)
        {
            switch (selected_index)
            {
                case 0:
                    {
                        s1.Write("30 01 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 1:
                    {
                        s1.Write("30 02 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 2:
                    {
                        s1.Write("30 03 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 3:
                    {
                        s1.Write("30 04 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 4:
                    {
                        s1.Write("30 05 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 5:
                    {
                        s1.Write("30 06 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 6:
                    {
                        s1.Write("30 09 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 7:
                    {
                        s1.Write("30 0A 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 8:
                    {
                        s1.Write("30 0B 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
                case 9:
                    {
                        s1.Write("30 0C 06 01\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Включено";
                        break;
                    }
            }
        }

        public void Parameters_manager_OFF(SerialPort s1, int selected_index, Label l1)
        {
            switch (selected_index)
            {
                case 0:
                    {
                        s1.Write("30 01 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 1:
                    {
                        s1.Write("30 02 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 2:
                    {
                        s1.Write("30 03 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 3:
                    {
                        s1.Write("30 04 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 4:
                    {
                        s1.Write("30 05 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 5:
                    {
                        s1.Write("30 06 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 6:
                    {
                        s1.Write("30 09 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 7:
                    {
                        s1.Write("30 0A 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 8:
                    {
                        s1.Write("30 0B 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
                case 9:
                    {
                        s1.Write("30 0C 06 00\n\r");
                        s1.ReadTo(">");
                        l1.Text = "Выключено";
                        break;
                    }
            }
        }

        public void Value_Color(TextBox textBox, double value, int selected_index, double[] min, double[] max)
        {
            if (value >= min[selected_index] && value <= max[selected_index])
            {
                textBox.ForeColor = Color.Green;
            }
            else { textBox.ForeColor = Color.Red; }
        }

        public void Engine_Speed_Control(SerialPort s1, string command)
        {
            s1.Write(command);
            s1.ReadTo(">");
        }

        public string[] Errors_Search(SerialPort s1)
        {
            s1.Write("21 01\n\r");
            string stringData = s1.ReadTo(">");           
            string[] stringDataSplit = stringData.Split(' ');

            int[] error_int = new int[5];
            string[] error_string_binary = new string[5];
            string error_string_return = "";

            for (int i = 0; i < 5; i++)
            {
                error_int[i] = Convert.ToInt32(stringDataSplit[i + 6], 16);
                error_string_binary[i] = Convert.ToString(error_int[i], 2);
                char[] error_char_array = new char[error_string_binary[i].Length];

                if (error_string_binary[i].Length < 8)
                {
                    int sub = 8 - error_string_binary[i].Length;

                    for (int j = 0; j < sub; j++)
                    {
                        error_string_binary[i] = error_string_binary[i].Insert(0, "0");
                    }
                }

                error_char_array = error_string_binary[i].ToCharArray();
                char[] error_char_array_reverse = new char[error_char_array.Length];

                for (int k = 0; k < error_char_array.Length; k++)
                {
                    error_char_array_reverse[error_char_array_reverse.Length - k - 1] = error_char_array[k];
                }

                for (int l = 0; l < error_char_array_reverse.Length; l++)
                {
                    error_string_return += error_char_array_reverse[l] + " ";
                }
                
                if (i == 3)
                {
                    error_int[i + 1] = Convert.ToInt32(stringDataSplit[23], 16);
                    error_string_binary[i + 1] = Convert.ToString(error_int[4], 2);

                    if (error_string_binary[i + 1].Length < 8)
                    {
                        int sub = 8 - error_string_binary[i + 1].Length;

                        for (int j = 0; j < sub; j++)
                        {
                            error_string_binary[i + 1] = error_string_binary[i + 1].Insert(0, "0");
                        }
                    }

                    error_char_array = error_string_binary[i + 1].ToCharArray();
                    error_char_array_reverse = new char[error_char_array.Length];

                    for (int k = 0; k < error_char_array.Length; k++)
                    {
                        error_char_array_reverse[error_char_array_reverse.Length - k - 1] = error_char_array[k];
                    }

                    for (int l = 0; l < error_char_array_reverse.Length; l++)
                    {
                        error_string_return += error_char_array_reverse[l] + " ";
                    }

                    break;
                }
            }

            string[] error_string_return_split = error_string_return.Split(' ');
                        
            return error_string_return_split;
        }

        public string[] Define_Excludes(SerialPort s1)
        {            
            s1.Write("21 01\n\r");

            string stringData = s1.ReadTo(">");
            string[] stringDataSplit = stringData.Split(' ');

            int[] excludes_int = new int[2];
            string[] excludes_string_binary = new string[2];
            string excludes_string_return = "";

            for (int i = 0; i < 2; i++)
            {
                excludes_int[i] = Convert.ToInt32(stringDataSplit[i + 2], 16);
                excludes_string_binary[i] = Convert.ToString(excludes_int[i], 2);
                char[] excludes_char_array = new char[excludes_string_binary[i].Length];

                if (excludes_string_binary[i].Length < 8)
                {
                    int sub = 8 - excludes_string_binary[i].Length;

                    for (int j = 0; j < sub; j++)
                    {
                        excludes_string_binary[i] = excludes_string_binary[i].Insert(0, "0");
                    }
                }

                excludes_char_array = excludes_string_binary[i].ToCharArray();
                char[] error_char_array_reverse = new char[excludes_char_array.Length];

                for (int k = 0; k < excludes_char_array.Length; k++)
                {
                    error_char_array_reverse[error_char_array_reverse.Length - k - 1] = excludes_char_array[k];
                }

                for (int l = 0; l < error_char_array_reverse.Length; l++)
                {
                    excludes_string_return += error_char_array_reverse[l] + " ";
                }
            }        

            string[] excludes_string_return_split = excludes_string_return.Split(' ');

            return excludes_string_return_split;
        }

        public double[] Min_Value_Search(SerialPort s1, double[] min_new, double[] min_old)
        {
            for (int i = 0; i < min_new.Length; i++)
            { 
                if (min_old[i] > min_new[i])
                {
                    min_old[i] = min_new[i];
                }
            }         
            return min_old;
        }

        public double[] Max_Value_Search(SerialPort s1, double[] max_new, double[] max_old)
        {
            for (int i = 0; i < max_new.Length; i++)
            {
                if (max_old[i] < max_new[i])
                {
                    max_old[i] = max_new[i];
                }
            }
            return max_old;
        }

        public double[] Average_Value_Search(SerialPort s1, double[] values, double[] charge_values, int count)
        {
            double[] av_values = new double[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                charge_values[i] += values[i];
                av_values[i] = charge_values[i] / count;
            }
            return av_values;
        }
    }
}