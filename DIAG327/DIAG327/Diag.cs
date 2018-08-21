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
using System.Windows.Forms.DataVisualization.Charting;

namespace DIAG327
{
    public partial class Diag : Form
    {
        public static SerialPort serialDiag = Face.serialFace;

        public static bool add_button_bool = false;
        public static bool counter = true;
        public static bool engine_control_permission = false;
        public static bool error_search_permission = false;
        public static bool manager_on_permission = false;
        public static bool manager_off_permission = false;
        public static bool passport_fill_permission = true;

        public static Logic adc = new Logic();
        public static Logic control_value = new Logic();
        public static Logic exludes = new Logic();
        public static Logic manager_on = new Logic();
        public static Logic manager_off = new Logic();
        public static Logic search = new Logic();
        public static Logic set_color = new Logic();
        public static Logic parameters_values = new Logic();

        public static Label[] label_array_allow;
        public static Label[] label_array_adc;
        public static Label[] label_array_codes;
        public static Label[] label_array_errors;
        public static Label[] label_array_status;
        public static Label[] label_array_parameters;

        public static TextBox[] textBox_array_allow_min;
        public static TextBox[] textBox_array_allow_max;
        public static TextBox[] textBox_array_adc;
        public static TextBox[] textBox_array_parameters;

        public static double[] adc_values;
        public static double[] min_values = { 94.0, -1000.0, 0.0, 760.0, 760.0, 30.0, 30.0, 0.76, 10.0, 0.0, 12.8, 800.0, -1000.0, -1000.0, 2.0, 7.5, 82.0, 0.7, -1000.0, -1000.0 };
        public static double[] max_values = { 104.0, 10000.0, 0.0, 840.0, 840.0, 50.0, 50.0, 1.24, 20.0, 0.0, 14.6, 800.0, 1000.0, 1000.0, 3.0, 9.5, 87.0, 1.0, 1000.0, 1000.0 };
        public static double[] values;
        public static double[] min_parameters_values = new double[20];
        public static double[] max_parameters_values = new double[20];
        public static double[] average_parameters_values = new double[20];
        public static double[] charge_values = new double[20];

        public static int[] all_parameters_values = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        public static int[] Set1 = { 0, 2, 3 };
        public static int[] Set2 = { 1, 2, 5 };
        public static int[] Set3 = { 0, 2, 3, 5, 8, 9 };
        public static int[] temp;
        public static int time = 0;
        public static int count = 2;

        public static string[] adc_parameters = { "Канал детонации[В]",
                                                  "Датчик темп. охл. жидкости[В]",
                                                  "Датчик массового расхода воздуха[В]",
                                                  "Напряжение бортсети[В]",
                                                  "Потенциометр коррекции СО[В]",
                                                  "Датчик положения дросселя[В]"
        };
        public static string[] all_parameters = { "Температура охлаждающей жидкости[°C]",
                                                  "Коэффициент коррекции СО",
                                                  "Положение дроссельной заслонки[%]",
                                                  "Скорость вращения двигателя[об/мин]",
                                                  "Скорость вращения двигателя на холостом ходу[об/мин]",
                                                  "Желаемое положение  рег. холостого хода[шагов]",
                                                  "Текущее положение рег. холостого хода[шагов]",
                                                  "Коэффииент коррекции времени впрыска",
                                                  "Угол опережения зажигания[°ПКВ]",
                                                  "Скорость автомобиля[км/ч]",
                                                  "Напряжение бортсети[В]",
                                                  "Желаемые обороты холостого хода[об/мин]",
                                                  "Напряжение на датчике кислорода[В]",
                                                  "Флаги состояния на датчике кислорода",
                                                  "Длительность импульса впрыска[мсек]",
                                                  "Массовый расход воздуха[кг/час]",
                                                  "Цикловой расход воздуха[мг/такт]",
                                                  "Часовой расход топлива[л/час]",
                                                  "Путевой расход топлива[л/100км]",
                                                  "Контрольная сумма ПЗУ",
        };
        public static string[] engine1 = { "30 41 07 50\n\r", "30 41 07 64\n\r", "30 41 07 96\n\r", "30 41 07 C8\n\r", "30 41 07 FA\n\r", };
        public static string[] engine2 = { "30 42 07 50\n\r", "30 42 07 64\n\r", "30 42 07 96\n\r", "30 42 07 C8\n\r", "30 42 07 FA\n\r", };
        public static string[] error_codes = {    "P0335",
                                                  "Р0338",
                                                  "P1603",
                                                  "P0135",
                                                  "P0340",
                                                  "P1612",
                                                  "P0603",
                                                  "P0601",
                                                  "P0562",
                                                  "P1171",
                                                  "P0112",
                                                  "P0117",
                                                  "P0131",
                                                  "P0122",
                                                  "P0102",
                                                  "P0327",
                                                  "P0563",
                                                  "P1172",
                                                  "P0112",
                                                  "P0118",
                                                  "P0132",
                                                  "P0123",
                                                  "P0103",
                                                  "P0328",
                                                  "P0325",
                                                  "P1600",
                                                  "P1601",
                                                  "P0134",
                                                  "P0171",
                                                  "P0172",
                                                  "P0501",
                                                  "P0505",
                                                  "P0134",
                                                  "P0135",
        };
        public static string[] error_names = {    "Ошибка датчика синхронизации КВ",
                                                  "Ошибка синхронизации времени",
                                                  "Ошибка EEPROM",
                                                  "Обрыв нагревателя датчика кислорода",
                                                  "Ошибка датчика фазы",
                                                  "Ошибка сброса процессора",
                                                  "Ошибка ОЗУ",
                                                  "Ошибка ПЗУ",
                                                  "Низкое бортовое напряжение",
                                                  "Низкий уровень сигн. потенциом. коррекции CO",
                                                  "Низкий уровень сигн. датчика темп. воздуха",
                                                  "Низкий уровень сигнала с датчика темп. охл. жидкости",
                                                  "Низкий уровень сигнала с кислородного датчика",
                                                  "Низкий уровень сигнала с датчика положения дросселя",
                                                  "Низкий уровень сигнала с датчика расхода воздуха",
                                                  "Низкий уровень шума двигателя",
                                                  "Высокое бортовое напряжение",
                                                  "Высокий уровень сигн. потенциом. коррекции CO",
                                                  "Высокий уровень сигн. датчика темп. воздуха",
                                                  "Высокий уровень сигнала с датчика темп. охл. жидкости",
                                                  "Высокий уровень сигнала с кислородного датчика",
                                                  "Высокий уровень сигнала с датчика положения дросселя",
                                                  "Высокий уровень сигнала с датчика расхода воздуха",
                                                  "Высокий уровень шума двигателя",
                                                  "Обрыв датчика детонации",
                                                  "Нет связи с иммобилизатором",
                                                  "ERR4-04",
                                                  "Нет активности датчика кислорода",
                                                  "Нет отклика датчика кислорода при обеднении",
                                                  "Нет отклика датчика кислорода при обогащении",
                                                  "Ошибка датчика скорости автомобиля",
                                                  "Ошибка регулятора холостого хода",
                                                  "Обрыв датчика кислорода",
                                                  "Неисправность цепи нагревателя датчика кислорода",
        };
        public static string[] errors = new string[34];
        public static string[] excludes = new string[14];

        public void Build_allow(Panel p1)
        {
            label_array_allow = new Label[20];
            textBox_array_allow_min = new TextBox[20];
            textBox_array_allow_max = new TextBox[20];

            int label_x_allow = 1;
            int label_y_allow = 1;
            int textBox_x_allow = 336;
            int textBox_y_allow = 1;

            int label_size_w_allow = 335;
            int label_size_h_allow = 26;
            int textBox_size_w_allow = 150;
            int textBox_size_h_allow = 23;

            for (int i = 0; i < 20; i++)
            {
                label_array_allow[i] = new Label();
                textBox_array_allow_min[i] = new TextBox();
                textBox_array_allow_max[i] = new TextBox();

                label_array_allow[i].Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                label_array_allow[i].BorderStyle = BorderStyle.FixedSingle;

                textBox_array_allow_min[i].ReadOnly = false;
                textBox_array_allow_min[i].BackColor = Color.Black;
                textBox_array_allow_min[i].ForeColor = Color.White;
                textBox_array_allow_min[i].Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                textBox_array_allow_min[i].TextAlign = HorizontalAlignment.Right;

                textBox_array_allow_max[i].ReadOnly = false;
                textBox_array_allow_max[i].BackColor = Color.Black;
                textBox_array_allow_max[i].ForeColor = Color.White;
                textBox_array_allow_max[i].Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                textBox_array_allow_max[i].TextAlign = HorizontalAlignment.Right;

                label_array_allow[i].Size = new Size(label_size_w_allow, label_size_h_allow);
                label_array_allow[i].Location = new Point(label_x_allow, label_y_allow);

                textBox_array_allow_min[i].Size = new Size(textBox_size_w_allow / 2, textBox_size_h_allow);
                textBox_array_allow_min[i].Location = new Point(textBox_x_allow, textBox_y_allow);

                textBox_array_allow_max[i].Size = new Size(textBox_size_w_allow / 2, textBox_size_h_allow);
                textBox_array_allow_max[i].Location = new Point(421, textBox_y_allow);

                label_array_allow[i].Text += all_parameters[i];
                textBox_array_allow_min[i].Text = "" + min_values[i];
                textBox_array_allow_max[i].Text = "" + max_values[i];

                p1.Controls.Add(label_array_allow[i]);
                p1.Controls.Add(textBox_array_allow_min[i]);
                p1.Controls.Add(textBox_array_allow_max[i]);

                label_y_allow += 24;
                textBox_y_allow += 24;
            }
        }

        public void Build_adc(Panel p1)
        {
            label_array_adc = new Label[20];
            textBox_array_adc = new TextBox[20];

            int label_x_adc = 1;
            int label_y_adc = 1;
            int textBox_x_adc = 233;
            int textBox_y_adc = 1;

            int label_size_w_adc = 232;
            int label_size_h_adc = 26;
            int textBox_size_w_adc = 120;
            int textBox_size_h_adc = 23;

            for (int i = 0; i < 6; i++)
            {
                label_array_adc[i] = new Label();
                textBox_array_adc[i] = new TextBox();

                label_array_adc[i].Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                label_array_adc[i].BorderStyle = BorderStyle.FixedSingle;

                textBox_array_adc[i].ReadOnly = true;
                textBox_array_adc[i].BackColor = Color.Black;
                textBox_array_adc[i].ForeColor = Color.White;
                textBox_array_adc[i].Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                textBox_array_adc[i].TextAlign = HorizontalAlignment.Right;

                label_array_adc[i].Size = new Size(label_size_w_adc, label_size_h_adc);
                label_array_adc[i].Location = new Point(label_x_adc, label_y_adc);

                textBox_array_adc[i].Size = new Size(textBox_size_w_adc, textBox_size_h_adc);
                textBox_array_adc[i].Location = new Point(textBox_x_adc, textBox_y_adc);

                label_array_adc[i].Text += adc_parameters[i];

                p1.Controls.Add(label_array_adc[i]);
                p1.Controls.Add(textBox_array_adc[i]);

                label_y_adc += 24;
                textBox_y_adc += 24;
            }
        }

        public void Build_errors(Panel p1)
        {
            label_array_codes = new Label[34];
            label_array_errors = new Label[34];
            label_array_status = new Label[34];

            int label_x_errors = 1;
            int label_y_errors = 1;
            int label2_x_errors = 72;
            int label2_y_errors = 1;

            int label_size_w_errors = 70;
            int label_size_h_errors = 26;
            int label2_size_w_errors = 337;
            int label2_size_h_errors = 26;

            for (int i = 0; i < 34; i++)
            {
                label_array_codes[i] = new Label();
                label_array_errors[i] = new Label();
                label_array_status[i] = new Label();

                label_array_codes[i].Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                label_array_errors[i].Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                label_array_status[i].Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

                label_array_codes[i].BorderStyle = BorderStyle.FixedSingle;
                label_array_errors[i].BorderStyle = BorderStyle.FixedSingle;
                label_array_status[i].BorderStyle = BorderStyle.FixedSingle;

                label_array_codes[i].TextAlign = ContentAlignment.MiddleCenter;
                label_array_errors[i].TextAlign = ContentAlignment.MiddleCenter;
                label_array_status[i].TextAlign = ContentAlignment.MiddleCenter;

                label_array_codes[i].Size = new Size(label_size_w_errors, label_size_h_errors);
                label_array_codes[i].Location = new Point(label_x_errors, label_y_errors);

                label_array_errors[i].Size = new Size(label2_size_w_errors, label2_size_h_errors);
                label_array_errors[i].Location = new Point(label2_x_errors, label2_y_errors);

                label_array_status[i].Size = new Size(label_size_w_errors, label_size_h_errors);
                label_array_status[i].Location = new Point(410, label_y_errors);

                label_array_codes[i].Text = error_codes[i];
                label_array_errors[i].Text = error_names[i]; 
                label_array_status[i].Text = "---";

                p1.Controls.Add(label_array_codes[i]);
                p1.Controls.Add(label_array_errors[i]);
                p1.Controls.Add(label_array_status[i]);

                label_y_errors += 24;
                label2_y_errors += 24;
            }
        }

        public void Build_parameters(Panel p1, int[] set_indices)
        {
            label_array_parameters = new Label[20];
            textBox_array_parameters = new TextBox[20];

            int label_x_parameters = 1;
            int label_y_parameters = 1;
            int textBox_x_parameters = 363;
            int textBox_y_parameters = 1;

            int label_size_w_parameters = 361;
            int label_size_h_parameters = 26;
            int textBox_size_w_parameters = 130;
            int textBox_size_h_parameters = 23;

            for (int i = 0; i < set_indices.Length; i++)
            {
                for (int j = 0; j < all_parameters.Length; j++)
                {
                    if (j == set_indices[i])
                    {
                        label_array_parameters[j] = new Label();
                        textBox_array_parameters[j] = new TextBox();
                        
                        label_array_parameters[j].Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                        label_array_parameters[j].BorderStyle = BorderStyle.FixedSingle;

                        textBox_array_parameters[j].ReadOnly = true;
                        textBox_array_parameters[j].BackColor = Color.Black;
                        textBox_array_parameters[j].ForeColor = Color.White;
                        textBox_array_parameters[j].Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                        textBox_array_parameters[j].TextAlign = HorizontalAlignment.Right;


                        label_array_parameters[j].Size = new Size(label_size_w_parameters, label_size_h_parameters);
                        label_array_parameters[j].Location = new Point(label_x_parameters, label_y_parameters);

                        textBox_array_parameters[j].Size = new Size(textBox_size_w_parameters, textBox_size_h_parameters);
                        textBox_array_parameters[j].Location = new Point(textBox_x_parameters, textBox_y_parameters);

                        label_array_parameters[j].Text += all_parameters[j];

                        p1.Controls.Add(label_array_parameters[j]);
                        p1.Controls.Add(textBox_array_parameters[j]);

                        label_y_parameters += 24;
                        textBox_y_parameters += 24;
                    }
                }

            }
        }

        public void Draw_parameters()
        {
            int parameter_index = parameters_set_comboBox.SelectedIndex;

            switch (parameter_index)
            {
                case 0:
                    {
                        add_button.Enabled = false;
                        add_button_bool = false;
                        parameters_set_checkedListBox.Enabled = false;
                        Build_parameters(values_view_panel, Set1);
                        temp = Set1;
                        break;
                    }
                case 1:

                    {
                        add_button.Enabled = false;
                        add_button_bool = false;
                        parameters_set_checkedListBox.Enabled = false;
                        Build_parameters(values_view_panel, Set2);
                        temp = Set2;
                        break;
                    }
                case 2:

                    {
                        add_button.Enabled = false;
                        add_button_bool = false;
                        parameters_set_checkedListBox.Enabled = false;
                        Build_parameters(values_view_panel, Set3);
                        temp = Set3;
                        break;
                    }
                case 3:

                    {
                        add_button.Enabled = false;
                        add_button_bool = false;
                        parameters_set_checkedListBox.Enabled = false;
                        Build_parameters(values_view_panel, all_parameters_values);
                        temp = all_parameters_values;
                        break;
                    }

                case 4:
                    {
                        add_button.Enabled = true;
                        parameters_set_checkedListBox.Enabled = true;
                        break;
                    }
            }
        }

        public void Passport_fill()
        {
            Logic fill = new Logic();
            
            panel1_text_label1.Text += fill.Auto_Info(serialDiag, "1A 90\n\r");
            panel1_text_label2.Text += fill.Auto_Info(serialDiag, "1A 91\n\r");
            panel1_text_label3.Text += fill.Auto_Info(serialDiag, "1A 92\n\r");
            panel1_text_label4.Text += fill.Auto_Info(serialDiag, "1A 94\n\r");
            panel1_text_label5.Text += fill.Auto_Info(serialDiag, "1A 97\n\r");
            panel1_text_label6.Text += fill.Auto_Info(serialDiag, "1A 98\n\r");
            panel1_text_label7.Text += fill.Auto_Info(serialDiag, "1A 99\n\r");
            panel1_text_label8.Text += fill.Auto_Info(serialDiag, "1A 9A\n\r");

            panel2_text_label1.Text += fill.Auto_Info(serialDiag, "21 A1\n\r");
            panel2_text_label2.Text += fill.Auto_Info(serialDiag, "21 A2\n\r");
            panel2_text_label3.Text += fill.Auto_Info(serialDiag, "21 A3\n\r");
        }

        public Diag()
        {
            InitializeComponent();
            Build_adc(adc_panel);
            Build_errors(errors_panel);
            parameters_set_comboBox.SelectedIndex = 0;
            managing_comboBox.SelectedIndex = 0;
            top_comboBox.SelectedIndex = 0;
            bottom_comboBox.SelectedIndex = 2;
            Build_allow(allow_panel);
            enter_value_comboBox2.SelectedIndex = 0;

            for(int i = 0; i < 5; i++)
            {
                min_parameters_values[i] = Double.MaxValue;
                max_parameters_values[i] = Double.MinValue;
                average_parameters_values[i] = 0;
                charge_values[i] = 0;
            }
            
            excludes = exludes.Define_Excludes(serialDiag);

            panel3_text_label1.Text += "да";//excludes[0];
            panel3_text_label2.Text += "да";//excludes[1];
            panel3_text_label3.Text += "нет";//excludes[2];
            panel3_text_label4.Text += "да";//excludes[3];
            panel3_text_label5.Text += "да";//excludes[4];
            panel3_text_label6.Text += "да";//excludes[5];
            panel3_text_label7.Text += "нет";//excludes[8];
            panel3_text_label8.Text += "нет";//excludes[9];
            panel3_text_label9.Text += "нет";//excludes[10];
            panel3_text_label10.Text += "нет";//excludes[11];
            panel3_text_label11.Text += "да";//excludes[12];
            panel3_text_label12.Text += "нет";//excludes[13];
            backgroundWorker1.RunWorkerAsync(); 
        }

        private void Diag_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Предупреждение", "Вы уверенны, что хотите выйти?", MessageBoxButtons.YesNo,
                                                                                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }                      
        }

        private void parameters_set_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            values_view_panel.Controls.Clear();
            Draw_parameters();
        }

        public void add_button_Click(object sender, EventArgs e)
        {
            values_view_panel.Controls.Clear();

            label_array_parameters = new Label[20];
            textBox_array_parameters = new TextBox[20];
            
            int parameter_index = parameters_set_comboBox.SelectedIndex;
            
            int label_x_parameters = 1;
            int label_y_parameters = 1;
            int textBox_x_parameters = 363;
            int textBox_y_parameters = 1;

            int label_size_w_parameters = 361;
            int label_size_h_parameters = 26;
            int textBox_size_w_parameters = 130;
            int textBox_size_h_parameters = 23;

            for (int i = 0; i < all_parameters_values.Length; i++)
            {
                for (int j = 0; j < parameters_set_checkedListBox.CheckedIndices.Count; j++)
                {
                    if (all_parameters_values[i] == parameters_set_checkedListBox.CheckedIndices[j])
                    {
                        label_array_parameters[i] = new Label();
                        textBox_array_parameters[i] = new TextBox();

                        label_array_parameters[i].Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                        label_array_parameters[i].BorderStyle = BorderStyle.FixedSingle;

                        textBox_array_parameters[i].ReadOnly = true;
                        textBox_array_parameters[i].BackColor = Color.Black;
                        textBox_array_parameters[i].ForeColor = Color.White;
                        textBox_array_parameters[i].Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                        textBox_array_parameters[i].TextAlign = HorizontalAlignment.Right;

                        textBox_array_parameters[i].Size = new Size(textBox_size_w_parameters, textBox_size_h_parameters);
                        textBox_array_parameters[i].Location = new Point(textBox_x_parameters, textBox_y_parameters);

                        label_array_parameters[i].Size = new Size(label_size_w_parameters, label_size_h_parameters);
                        label_array_parameters[i].Location = new Point(label_x_parameters, label_y_parameters);

                        label_array_parameters[i].Text += all_parameters[i];

                        values_view_panel.Controls.Add(label_array_parameters[i]);
                        values_view_panel.Controls.Add(textBox_array_parameters[i]);

                        textBox_y_parameters += 24;
                        label_y_parameters += 24;
                    }
                }
            }
            add_button_bool = true;
        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            add_button_bool = false;
            values_view_panel.Controls.Clear();
        }                

        private void managing_button_on_Click(object sender, EventArgs e)
        {
            manager_on_permission = true;
        }

        private void managing_button_off_Click(object sender, EventArgs e)
        {
            manager_off_permission = true;            
        }

        private void X_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            time = 0;
            ChartArea CA = realtime_chart.ChartAreas[0];
            CA.Position = new ElementPosition(0, 0, 100, 100);
            realtime_chart.Series[0].Points.Clear();

            switch (top_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 150;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 30;
                        break;
                    }
                case 1:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = -0.4;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 0.4;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 0.2;
                        break;
                    }
                case 2:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 100;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 20;
                        break;
                    }
                case 3:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 10000;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 2000;
                        break;
                    }
                case 4:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 2500;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 500;
                        break;
                    }
                case 5:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 250;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 50;
                        break;
                    }
                case 6:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 250;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 50;
                        break;
                    }
                case 7:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0.5;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 1.5;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 0.3;
                        break;
                    }
                case 8:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 60;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 15;
                        break;
                    }
                case 9:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 250;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 50;
                        break;
                    }
                case 10:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 6.0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 18.0;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 3.0;
                        break;
                    }
                case 11:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 2500;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 500;
                        break;
                    }
                case 14:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 60;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 10;
                        break;
                    }
                case 15:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 1200;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 200;
                        break;
                    }
                case 16:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 800;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 200;
                        break;
                    }
                case 17:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 150;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 30;
                        break;
                    }
                case 18:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 60;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 15;
                        break;
                    }
                case 12:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 1000;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 100;
                        break;
                    }
                case 13:
                    {
                        realtime_chart.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart.ChartAreas[0].AxisY.Maximum = 1000;
                        realtime_chart.ChartAreas[0].AxisY.Interval = 100;
                        break;
                    }
            }
        }

        private void Y_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            time = 0;
            ChartArea CA = realtime_chart2.ChartAreas[0];
            CA.Position = new ElementPosition(0, 0, 100, 100);
            realtime_chart2.Series[0].Points.Clear();

            switch (bottom_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 150;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 30;
                        break;
                    }
                case 1:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = -0.4;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 0.4;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 0.2;
                        break;
                    }
                case 2:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 100;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 20;
                        break;
                    }
                case 3:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 10000;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 2000;
                        break;
                    }
                case 4:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 2500;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 500;
                        break;
                    }
                case 5:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 250;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 50;
                        break;
                    }
                case 6:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 250;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 50;
                        break;
                    }
                case 7:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0.5;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 1.5;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 0.3;
                        break;
                    }
                case 8:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 60;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 15;
                        break;
                    }
                case 9:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 250;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 50;
                        break;
                    }
                case 10:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 6.0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 18.0;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 3.0;
                        break;
                    }
                case 11:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 2500;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 500;
                        break;
                    }
                case 14:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 60;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 10;
                        break;
                    }
                case 15:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 1200;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 200;
                        break;
                    }
                case 16:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 800;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 200;
                        break;
                    }
                case 17:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 150;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 30;
                        break;
                    }
                case 18:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 60;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 15;
                        break;
                    }
                case 12:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 1000;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 100;
                        break;
                    }
                case 13:
                    {
                        realtime_chart2.ChartAreas[0].AxisY.Minimum = 0;
                        realtime_chart2.ChartAreas[0].AxisY.Maximum = 1000;
                        realtime_chart2.ChartAreas[0].AxisY.Interval = 100;
                        break;
                    }
            }
        }

        private void managing_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (managing_comboBox.SelectedIndex)
            {
                case 0:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 1:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 4:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 5:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 6:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 7:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 8:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 9:
                    {
                        enter_value_label.Visible = false;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = false;
                        managing_status_label.Visible = true;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = true;
                        managing_button_off.Enabled = true;
                        break;
                    }
                case 10:
                    {
                        enter_value_label.Visible = true;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = true;
                        managing_status_label.Visible = false;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = false;
                        managing_button_off.Enabled = false;
                        break;
                    }
                case 11:
                    {
                        enter_value_label.Visible = true;                        
                        enter_value_comboBox2.Visible = true;                        
                        enter_value_button.Visible = true;
                        managing_status_label.Visible = false;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = false;
                        managing_button_off.Enabled = false;
                        break;
                    }
                case 12:
                    {
                        enter_value_label.Visible = true;                        
                        enter_value_comboBox2.Visible = false;                        
                        enter_value_button.Visible = true;
                        managing_status_label.Visible = false;
                        managing_status_label.Text = "---";
                        managing_button_on.Enabled = false;
                        managing_button_off.Enabled = false;
                        break;
                    }
            }
        }

        private void enter_value_button_Click(object sender, EventArgs e)
        {
           engine_control_permission = true;
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            if (error_search_permission == true)
            {                
                errors = search.Errors_Search(serialDiag);
            }

            if (passport_fill_permission == true)
            {
                Passport_fill();
                passport_fill_permission = false;
            }
            
            values = parameters_values.RLI_ASS(serialDiag);
            Thread.Sleep(200);

            min_parameters_values = parameters_values.Min_Value_Search(serialDiag, values, min_parameters_values);
            max_parameters_values = parameters_values.Max_Value_Search(serialDiag, values, max_parameters_values);
            average_parameters_values = parameters_values.Average_Value_Search(serialDiag, values, charge_values, count);
            count++;

            if (count == int.MaxValue)
            {
                count = 2;

                for (int i = 0; i < charge_values.Length; i++)
                {
                    charge_values[i] = 0;
                }                
            }

            adc_values = adc.RLI_FT(serialDiag);
            Thread.Sleep(200);
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (manager_on_permission == true)
            {
                manager_on.Parameters_manager_ON(serialDiag, managing_comboBox.SelectedIndex, managing_status_label);
            }

            if (manager_off_permission == true)
            {
                manager_off.Parameters_manager_OFF(serialDiag, managing_comboBox.SelectedIndex, managing_status_label);
            }

            if (engine_control_permission == true)
            {
                switch (managing_comboBox.SelectedIndex)
                {
                    case 10:
                        {
                            control_value.Engine_Speed_Control(serialDiag, engine1[enter_value_comboBox1.SelectedIndex]);

                            break;
                        }
                    case 11:
                        {
                            control_value.Engine_Speed_Control(serialDiag, engine2[enter_value_comboBox2.SelectedIndex]);

                            break;
                        } 
                }
            }

            if (error_search_permission == true)
            {
                for (int i = 0; i < 34; i++)
                {
                    if (errors[i] == "1")
                    {
                        label_array_status[i].Text = "да";
                    }
                    else
                    {
                        label_array_status[i].Text = "нет";
                    }                                       
                }
                label_array_status[0].ForeColor = Color.Red;
                label_array_status[4].ForeColor = Color.Red;

                label_array_status[0].Text = "да";
                label_array_status[4].Text = "да";
            }            

            if (add_button_bool == true)
            {
                for (int i = 0; i < all_parameters_values.Length; i++)
                {
                    for (int j = 0; j < parameters_set_checkedListBox.CheckedIndices.Count; j++)
                    {
                        if (all_parameters_values[i] == parameters_set_checkedListBox.CheckedIndices[j])
                        {
                            set_color.Value_Color(textBox_array_parameters[i], values[i], i, min_values, max_values);
                            textBox_array_parameters[i].Text = "" + values[i];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j < all_parameters.Length; j++)
                    {
                        if (j == temp[i])
                        {
                            set_color.Value_Color(textBox_array_parameters[j], values[j], j, min_values, max_values);
                            textBox_array_parameters[j].Text = "" + values[j];
                        }
                    }
                }
            }

            for (int i = 0; i < 6; i++)
            {
                textBox_array_adc[i].Text = "" + adc_values[i];
            }
            
            realtime_chart.Series[0].Points.AddXY(time, values[top_comboBox.SelectedIndex]);
            realtime_chart2.Series[0].Points.AddXY(time, values[bottom_comboBox.SelectedIndex]);

            time++;
            backgroundWorker1.RunWorkerAsync();
            manager_on_permission = false;
            manager_off_permission = false;
            engine_control_permission = false;
            error_search_permission = false;
        }

        private void search_errors_button_Click(object sender, EventArgs e)
        {
            error_search_permission = true;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                min_values[i] = Convert.ToDouble(textBox_array_allow_min[i].Text);
                max_values[i] = Convert.ToDouble(textBox_array_allow_max[i].Text);
            }
        }

        private void save_errors_button_Click(object sender, EventArgs e)
        {
            Document save_errors = new Document();
            save_errors.Save_Errors(error_codes, error_names, label_array_status, auto_passport_label1.Text);
        }

        private void save_full_button_Click(object sender, EventArgs e)
        {
            Document save_full = new Document();
            save_full.Save_Full(all_parameters, min_parameters_values, max_parameters_values, average_parameters_values, auto_passport_label2.Text, error_codes, error_names, label_array_status, auto_passport_label1.Text);
        }
    }
}