using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wcfClient
{
    public partial class Form1 : Form
    {
        ChannelFactory<IGet> _channelFactory;
        IGet _service;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ntcpBinding = new NetTcpBinding(SecurityMode.None);
            ntcpBinding.OpenTimeout = new TimeSpan(0, 0, 30);
            ntcpBinding.SendTimeout = new TimeSpan(0, 0, 30);
            ntcpBinding.ReceiveTimeout = new TimeSpan(0, 0, 30);

            _channelFactory = new ChannelFactory<IGet>(ntcpBinding, new EndpointAddress("net.tcp://localhost/API"));
            _service = _channelFactory.CreateChannel();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var num = _service.GetNumber();
            MessageBox.Show(num.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var str = _service.GetString();
            MessageBox.Show(str);
        }
    }
}
