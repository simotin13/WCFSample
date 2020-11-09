using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using test.service;

namespace test
{
    public partial class SampleService : ServiceBase
    {
        public SampleService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            startService();
        }

        protected override void OnStop()
        {
        }

        private void startService()
        {
            ServiceHost _svc;
            Console.WriteLine("Start...");
            // サービスエンドポイント生成
            // Bindingの設定はクライアントとあわせる必要がある
            var ntcpBinding = new NetTcpBinding(SecurityMode.None);
            ntcpBinding.OpenTimeout = new TimeSpan(0, 0, 30);
            ntcpBinding.SendTimeout = new TimeSpan(0, 0, 30);
            ntcpBinding.ReceiveTimeout = new TimeSpan(0, 0, 30);
            ntcpBinding.Security.Mode = SecurityMode.None;
            //ntcpBinding.maxConcurrentSessions  = 1;
            //ntcpBinding.ListenBacklog = 1;



            _svc = new ServiceHost(typeof(GetServiceHost));

            var throttleBehavior = new ServiceThrottlingBehavior();
            throttleBehavior.MaxConcurrentSessions = 5;
            throttleBehavior.MaxConcurrentCalls = 5;
            throttleBehavior.MaxConcurrentInstances = 5;
            _svc.Description.Behaviors.Add(throttleBehavior);

            _svc.AddServiceEndpoint(typeof(IGet), ntcpBinding, "net.tcp://localhost/API");

            // サービス開始
            _svc.Open();

        }
    }
}
