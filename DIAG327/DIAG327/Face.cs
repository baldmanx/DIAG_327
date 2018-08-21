using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace DIAG327
{
    public partial class Face : Form
    {
        public static SerialPort serialFace = new SerialPort();

        public static bool counter = true;
        public static bool permission = false;

        public static string com = "";

        Logic ELM327 = new Logic();

        public Face()
        {
            InitializeComponent();
            
            serialFace.BaudRate = 38400;
            serialFace.DataBits = 8;
            serialFace.Parity = Parity.None;
            serialFace.StopBits = StopBits.One;
            serialFace.Handshake = Handshake.None;

            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < ports.Length; i++)
            {
                serialFace.PortName = ports[i];

                serialFace.Open();
                serialFace.Write("ate0\n\r");
                serialFace.ReadTo(">");
                serialFace.Write("ati\n\r");
                string result = serialFace.ReadTo(">");

                if (result.Trim() == "ELM327 v1.5")
                {
                    device_status_label.Text = "Идёт настройка устройства...(" + ports[i] + ")";
                    port_status_label.Text = "Порт открыт";
                    serialFace.Close();
                    com = ports[i];
                    break;
                }
                else
                    device_status_label.Text = "Устройсто не найдено";
            }
            serialFace.Close();
            timer1.Start();
        }

        public void about_button_Click(object sender, EventArgs e)
        {
            About about_form = new About();
            about_form.ShowDialog();
        }

        private void settings_button_Click(object sender, EventArgs e)
        {
            Info info_form = new Info();
            info_form.ShowDialog();
        }

        private void go_to_diag_button_Click(object sender, EventArgs e)
        {
            counter = false;

             if (permission == true)
             {
            Diag diag_form = new Diag();
                diag_form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Устройство не найдено.", "Ошибка", MessageBoxButtons.OK,
                                                                                MessageBoxIcon.Error);
            }

            serialFace.Close();
        }

        private void Face_FormClosing(object sender, FormClosingEventArgs e)
        {
            counter = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (counter == true)
            {
                serialFace.Write("21 01\n\r");
                serialFace.ReadTo(">");
                Thread.Sleep(1000);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialFace.Open();
            ELM327.Init_Config(serialFace, progressBar);
            auto_info_label.Text = ELM327.Auto_Info(serialFace, "1A 90\n\r");
            ecu_label.Text = ELM327.Auto_Info(serialFace, "1A 91\n\r");
            additional_equipment_label.Text = ELM327.Auto_Info(serialFace, "1A 97\n\r");            
            timer1.Stop();
            timer1.Enabled = false;
            progressBar.Enabled = false;            
            backgroundWorker1.RunWorkerAsync();
        }

        private void progressBar_EnabledChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Устройство ELM327 найдено и успешно настроено.", "Уведомление", MessageBoxButtons.OK,
                                                                MessageBoxIcon.Information);
            device_status_label.Text = "ELM327(" + com + ")";
            permission = true;            
            info_button.Enabled = true;
            about_button.Enabled = true;
            go_to_diag_button.Enabled = true;
        }
    }
}
