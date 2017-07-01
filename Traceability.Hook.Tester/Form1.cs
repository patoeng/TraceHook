using System;
using System.Windows.Forms;
using Traceability.Hook.Models;
using Traceability.Hook.Setting;

namespace Traceability.Hook.Tester
{
    public partial class Form1 : Form
    {
        private IMachineHook _machineHook;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _machineHook = new MachineHook();
            _machineHook.MachineHookException += OnMachineHookException;
            _machineHook.MachineHookErrorOccured += OnMachineHookErrorOccured;
        }

        private void OnMachineHookException(string info)
        {
            MessageBox.Show(info);
        }
        private void OnMachineHookErrorOccured(string info)
        {
            MessageBox.Show(info);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _machineHook.Initialize();
            label1.Text = _machineHook.ShowMachineSerialNumber();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int productId;
            int workorderId;
            int error;
            _machineHook.GetProductByReference(textBox4.Text, out productId);
            _machineHook.CreateWorkOrderIfNotExisted(textBox1.Text, productId, Convert.ToInt32(textBox3.Text), out workorderId);
            _machineHook.LoadReference(textBox4.Text,out error);
            label5.Text = workorderId.ToString();
            textBox2.Text = productId.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int error;
            _machineHook.LoadReferenceCheck(textBox4.Text+"\r\n",out error);
            textBox2.Text = error.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int status;
            _machineHook.StartProductTraceability(textBox5.Text,textBox6.Text,out status);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int status;
            _machineHook.LoadProduct(textBox5.Text,"Test" ,out status);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int status;
            _machineHook.UpdateProductStatusOk(textBox5.Text,"Test", out status);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int status;
            _machineHook.UpdateProductStatusNOk(textBox5.Text, "Test", out status);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int status;
            _machineHook.ProductDismantle(textBox5.Text, "Dismantled", out status);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var j = new HookSetting())
            {
                j.ShowDialog();
            }
        }
        private readonly IStationIndexer _station = new StationIndexer();

        private void StationToListBox()
        {
            listBox1.Items.Clear();
            var j = _station.NumberOfStation();
            for (int i = 0; i < j; i++)
            {
                string fn;
                if (_station.GetStationProduct(i, out fn))
                {
                    listBox1.Items.Add(@"Station: "+(i+1)+" : "+ fn);
                }
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            _station.Initialize();
            StationToListBox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _station.ShiftProducttStationLeft(textBox7.Text, 1, (int) ProcessResult.InProcess, 1);
            StationToListBox();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _station.ShiftProductStationRight(textBox7.Text, 1, (int)ProcessResult.InProcess, 1);
            StationToListBox();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _station.Clear();
            StationToListBox();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            _station.SetProductToStation(1,textBox7.Text, 1, (int)ProcessResult.InProcess);
            StationToListBox();
        }
    }
}
