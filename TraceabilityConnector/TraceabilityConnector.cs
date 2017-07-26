using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using LAD08PackagingV1;
using Traceability.Hook;
using Traceability.Hook.Models;
using Traceability.Hook.Setting;
using TraceabilityConnector.Helper;


namespace TraceabilityConnector
{
    public partial class TraceabilityConnector : Form
    {
        public  bool EmbeddedMode { get; protected set; }

        public bool EnableVirtualIndexer
        {
            get
            {
                return _enableVirtualIndexer;
            }

            set
            {
                _enableVirtualIndexer = value;
            }
        }

        public delegate void DelegateShowInformation(string info);
        public delegate void DelegateSetLabelText(Label label, string info);

        private IDataAcquisition _dataAcquisition;
        private MachineData _machineData;
        private IMachineHook _thisMachine;
        private ISettingHook _setting;

        private string _plcIpAddress;
        private int _plcScanRate;
        private bool _enableVirtualIndexer;
        private bool _traceabilityEnabled;
        private int _uniqueIdentityLength;
        private string _databaseConnection;
        private string _serverIp;

        public TraceabilityConnector(bool embeddedMode)
        {
            EmbeddedMode = embeddedMode;
            InitializeComponent();
            InitAll();   
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            lblBuild.Text = @"Build : "+ Assembly.GetExecutingAssembly().GetLinkerTime().ToString("yyMMddhhmmss");
            tmr_CLock.Start();
        }
#region Non Form Events

        private void InitAll()
        {
             gb_Embedded.Visible = EmbeddedMode;
             lbl_OrderNumber.Text = "";

             tb_ShowInformation.Clear();
            _setting = new SettingHook();
            _plcIpAddress = _setting.GetPlcIpAdress();
            _traceabilityEnabled = _setting.GetEnableTraceability();
            _plcScanRate = _setting.GetPlcScanRate();         
            EnableVirtualIndexer = _setting.GetVirtualIndexer();
            _uniqueIdentityLength = _setting.GetUniqueIdLength();
            _databaseConnection = _setting.GetDatabaseConnectionString();

            _serverIp = TestConnection.ParseIpAddress(_databaseConnection);
            if (_serverIp != "")
            {
                tmrPingServer_Tick(tmrPingServer, null);
                tmrPingServer.Start();
            }
            SetLabelText(lblServerIp,_serverIp);

            ScanTimerInitialize();
            DaqReInitialize();
            MachineHookInitialize();

            SetMachineInformation();
            SetProductInformation();
            MachineDataReInitialize();
            VirtualIndexerToListBox(lb_Indexer);
           
                try
                {                   
                    lbl_PlcConnection.Text = @"Connected";
                     if(!EnableVirtualIndexer) lbl_VirtualIndexer.Text = @"Not Used";
                    _dataAcquisition.SetUniqueIdentityLength(_uniqueIdentityLength);
                    _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.TraceabilityStatusNotUpdated);
                    _dataAcquisition.SetVirtualIndexer(
                        EnableVirtualIndexer ? VirtualIndexerStates.WaitingTraceabilityStatusCheck : VirtualIndexerStates.NotIndexed);
                    
                   SetTraceabilityStates(_traceabilityEnabled? TraceabilityStates.WaitingForReference: TraceabilityStates.ByPassed);
                    btn_ByPass2.Text = _traceabilityEnabled ? "&By Pass" : "&Activate";
                   if (!EnableVirtualIndexer) _machineData.ActiveReference = ReadActiveReference();

                    tmr_Scanner.Start();
                   
                }
               catch (Exception exception)
                {
                   ShowInformation("Initialize : "+exception.Message);
                }
            
        }
        private void MachineHookInitialize()
        {
            if (_thisMachine != null)
            {
                _thisMachine.MachineHookErrorOccured -= MachineHookErrorOccured;
                _thisMachine.MachineHookException -= MachineHookException;
            }
            _thisMachine = new MachineHook();
            _thisMachine.MachineHookErrorOccured += MachineHookErrorOccured;
            _thisMachine.MachineHookException += MachineHookException;
            _thisMachine.Initialize();   
        }

        private void ScanTimerInitialize()
        {
            tmr_Scanner.Stop();
            tmr_Scanner.Interval = _plcScanRate;
        }

        private void DaqInitialize()
        {
            if (_plcIpAddress.Contains("0.0.0.0"))
            {
                _dataAcquisition = new VirtualDataAcquisition();
            }
            else
            {
                try
                {
                    _dataAcquisition = new PlcDataAcquisition();
                }
                catch (Exception exception)
                {
                    ShowInformation("Init PLC : "+exception.Message);
                    tmr_PlcRetry.Start();
                    return;
                }
            }
           
            _dataAcquisition.DataAcquisitionOnException += DataAcquisitionOnException;
        }

        private void DataAcquisitionOnException(string exception)
        {
            ShowInformation(exception);
        }

        private void DaqReInitialize()
        {
            if (_dataAcquisition != null)
            {               
                _dataAcquisition.DataAcquisitionOnException -= DataAcquisitionOnException;
            }
            DaqInitialize();
        }

        private void MachineDataInitialize()
        {           
            _machineData = new MachineData(EnableVirtualIndexer);
            _machineData.ProductInLoadingStatusChanged += ProductInLoadingStatusChanged;
            _machineData.ProductInUnloadingStatusChanged += ProductInUnloadingStatusChanged;
            _machineData.ReferenceChanged += ReferenceChanged;
            _machineData.TraceabilityStateChanged += TraceabilityStateChanged;
            if (EnableVirtualIndexer) _machineData.VirtualIndexerStateChanged += VirtualIndexerStateChanged;
        }

        private void VirtualIndexerStateChanged(VirtualIndexerStates state)
        {
            switch (state)
            {
                case VirtualIndexerStates.NotIndexed:
                    SetLabelText(lbl_VirtualIndexer,"Not Used");
                    break;
                case VirtualIndexerStates.NewlyIndexed:
                    SetLabelText(lbl_VirtualIndexer, "Newly Indexed");
                    _machineData.VirtualIndexer.ShiftProductStationRight("", 1, 1, 1);
                    _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.UpdateTraceabilityStatus);
                    break;
                case VirtualIndexerStates.IndexConfirmed:
                    SetLabelText(lbl_VirtualIndexer, "Index Confirmed");
                    break;
                case VirtualIndexerStates.Reset:
                    SetLabelText(lbl_VirtualIndexer, "Reset");
                    _machineData.VirtualIndexer.Clear();
                    _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.IndexConfirmed);
                    break;
                case VirtualIndexerStates.WaitingTraceabilityStatusCheck:
                    SetLabelText(lbl_VirtualIndexer, "Waiting Traceability Status Check");
                    if (EnableVirtualIndexer && _machineData.ProductInLoadingStatus== ProductStatus.LoadedNeedTraceabilityCheck)
                    {
                        var product = ReadLoading();
                        if (product == string.Empty)
                        {
                            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.TraceabilityCheckedNok);
                            break;
                        }
                        int status;
                        CheckReferenceLoadIfUnMatch(product);
                        var result = _thisMachine.LoadProduct(product, "", out status);

                        _dataAcquisition.UpdateProductInLoadingStatus(result
                            ? ProductStatus.TraceabilityCheckedOk
                            : ProductStatus.TraceabilityCheckedNok);

                        if (result && EnableVirtualIndexer)
                        {
                            _machineData.VirtualIndexer.SetProductToStation(0, product, 1, 1);
                            VirtualIndexerToListBox(lb_Indexer);
                            _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.IndexConfirmed);
                        }
                    }
                    break;
                case VirtualIndexerStates.UpdateTraceabilityStatus:
                    SetLabelText(lbl_VirtualIndexer, "Waiting Unloading Traceability Status Update");
                    if (EnableVirtualIndexer &&
                        _machineData.ProductInUnloadingStatus == ProductStatus.LoadedNeedTraceabilityStatusUpdateNOk)
                    {
                        var product = ReadUnloading();
                        var result = false;
                        if (product != string.Empty)
                        {
                            int status;
                            result = _thisMachine.UpdateProductStatusNOk(product, "Auto", out status);
                        }
                        _dataAcquisition.UpdateProductInUnloadingStatus(
                           result ? ProductStatus.TraceabilityStatusUpdated : ProductStatus.TraceabilityStatusNotUpdated);
                        _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.WaitingTraceabilityStatusCheck);
                    }
                    if (EnableVirtualIndexer &&
                       _machineData.ProductInUnloadingStatus == ProductStatus.LoadedNeedTraceabilityStatusUpdateOk)
                    {
                        var product = ReadUnloading();

                        var result = false;
                        if (product != string.Empty)
                        {
                            int status;
                            result = _thisMachine.UpdateProductStatusOk(product, "Auto", out status);
                        }
                        _dataAcquisition.UpdateProductInUnloadingStatus(
                           result ? ProductStatus.TraceabilityStatusUpdated : ProductStatus.TraceabilityStatusNotUpdated);
                        _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.WaitingTraceabilityStatusCheck);
                    }
                    break;
            }
            VirtualIndexerToListBox(lb_Indexer);
        }

        private void MachineDataReInitialize()
        {
            if (_machineData != null)
            {
                _machineData.ProductInLoadingStatusChanged -= ProductInLoadingStatusChanged;
                _machineData.ProductInUnloadingStatusChanged -= ProductInUnloadingStatusChanged;
                _machineData.ReferenceChanged -= ReferenceChanged;
                _machineData.TraceabilityStateChanged -= TraceabilityStateChanged;
                if (EnableVirtualIndexer) _machineData.VirtualIndexerStateChanged -= VirtualIndexerStateChanged;
                _machineData = null;
            }
            MachineDataInitialize();
        }

        private void SetProductInformation()
        {
            SetLabelText(lbl_Article, _thisMachine?.ShowArticle());
            SetLabelText(lbl_Reference, _thisMachine?.ShowReference());
            SetLabelText(lbl_Sequence, _thisMachine?.ShowSequence());
            SetLabelText(lbl_PreviousMachine, _thisMachine?.ShowPrevMachineFamily());
        }

        private void SetMachineInformation()
        {
            lbl_MachineCode.Text = _thisMachine?.ShowMachineSerialNumber();
            lbl_MachineName.Text = _thisMachine?.ShowMachineName();
            lbl_MachineFamily.Text = _thisMachine?.ShowMachineFamily();
            lbl_PreviousMachine.Text = string.Empty;
            lbl_plcIpAddress.Text = _plcIpAddress;
            lbl_PlcConnection.Text = @"Not Connected";

            myNotifyIcon.Text = @"Traceability " + lbl_MachineName.Text;
        }

        private void SetTraceabilityStates(TraceabilityStates states)
        {
            states = _traceabilityEnabled ? states : TraceabilityStates.ByPassed;
            _machineData.TraceabilityStates = states;
            _dataAcquisition.SetTraceabilityStates(states);
        }

        private void LampBlink(CheckBox chb)
        {
            chb.BackColor = chb.Checked ? Color.Green : Color.GreenYellow;
            chb.Checked = !chb.Checked;
        }
        private void TraceabilityStateChanged(TraceabilityStates data)
        {
            switch (data)
            {
                case TraceabilityStates.NotReady:
                    SetLabelText(lbl_TraceabilityStates,"Not Ready");
                    SetTraceabilityStates(_traceabilityEnabled ? TraceabilityStates.WaitingForReference : TraceabilityStates.ByPassed);
                    break;
                case TraceabilityStates.WaitingForReference:
                    if (!_traceabilityEnabled)
                    {
                        SetTraceabilityStates(TraceabilityStates.ByPassed);
                        break;
                    }
                    if (!EnableVirtualIndexer) _machineData.ActiveReference = ReadActiveReference();
                    SetLabelText(lbl_TraceabilityStates, "Waiting For Reference");
                    SetTraceabilityStates(TraceabilityStates.Ready);
                    break;
                case TraceabilityStates.Ready:
                    if (!_traceabilityEnabled)
                    {
                        SetTraceabilityStates(TraceabilityStates.ByPassed);
                        break;
                    }
                    SetLabelText(lbl_TraceabilityStates, "Ready");
                    break;
                case TraceabilityStates.ByPassed:
                    SetLabelText(lbl_TraceabilityStates, "By Passed");
                    break;
               
            }
        }
        private void ReferenceChanged(string data)
        {
            if (data != string.Empty)
            {
                int error;
                if (!_thisMachine.LoadReference(_machineData.ActiveReference, out error))
                {
                    _thisMachine.UnloadReference();
                    ShowInformation(@"Failed to Load Reference " + data + ". Error Code : " + error);
                    SetTraceabilityStates(TraceabilityStates.WaitingForReference);
                }
                else
                {
                    SetTraceabilityStates(TraceabilityStates.Ready);
                }
            }
            else
            {
                _thisMachine.UnloadReference();
            }
            SetProductInformation();
        }
        private void ProductInUnloadingStatusChanged(ProductStatus eproductstatus)
        {
            if (!_traceabilityEnabled) return;

            string product;
            int status;
            bool result;
            switch (eproductstatus)
            {
                case ProductStatus.LoadedNeedTraceabilityStatusUpdateNOk:
                   
                    SetLabelText(lbl_UnloadingState, "Unloaded Need Traceability Update Status Nok");
                    if (EnableVirtualIndexer &&
                     _machineData.VirtualIndexerStates != VirtualIndexerStates.UpdateTraceabilityStatus)
                    {
                        return;
                    }
                    product = ReadUnloading();
                    
                    result = false;
                    if (product != string.Empty)
                    {
                        result = _thisMachine.UpdateProductStatusNOk(product, "Auto", out status);
                    }
                    _dataAcquisition.UpdateProductInUnloadingStatus(
                       result ? ProductStatus.TraceabilityStatusUpdated : ProductStatus.TraceabilityStatusNotUpdated);
                    _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.WaitingTraceabilityStatusCheck);
                    break;
                case ProductStatus.LoadedNeedTraceabilityStatusUpdateOk:
                    SetLabelText(lbl_UnloadingState, "Unloaded Need Traceability Status Ok");
                    if (EnableVirtualIndexer &&
                      _machineData.VirtualIndexerStates != VirtualIndexerStates.UpdateTraceabilityStatus)
                    {
                        return;
                    }
                    product = ReadUnloading();
                    result = false;
                    if (product != string.Empty)
                    {
                        result = _thisMachine.UpdateProductStatusOk(product, "Auto", out status);
                    }
                    _dataAcquisition.UpdateProductInUnloadingStatus(
                        result ? ProductStatus.TraceabilityStatusUpdated : ProductStatus.TraceabilityStatusNotUpdated);
                    _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.WaitingTraceabilityStatusCheck);
                    break;
                case ProductStatus.Unknown:
                    SetLabelText(lbl_UnloadingState, "Unknown");
                    break;
                case ProductStatus.TraceabilityStatusUpdated:
                    SetLabelText(lbl_UnloadingState, "Status Updated");
                    break;
                case ProductStatus.TraceabilityStatusNotUpdated:
                    SetLabelText(lbl_UnloadingState, "Status Not Updated");
                    break;
            }
        }

        private void ProductInLoadingStatusChanged(ProductStatus eproductstatus)
        {
            if (!_traceabilityEnabled) return;
            switch (eproductstatus)
            {
                case ProductStatus.Unknown:
                    SetLabelText(lbl_LoadingStatus, "Unknown");
                 
                    break;
                case ProductStatus.LoadedNeedTraceabilityCheck:
                    SetLabelText(lbl_LoadingStatus, "Loaded Need Traceability Check");                   
                  
                    if (EnableVirtualIndexer &&
                        _machineData.VirtualIndexerStates != VirtualIndexerStates.WaitingTraceabilityStatusCheck)
                    {
                        return;
                    }
                    var product = ReadLoading();
                    if (product == string.Empty)
                    {
                        _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.TraceabilityCheckedNok);
                        break;
                    }
                        int status;
                        CheckReferenceLoadIfUnMatch(product); // will change automatically if unmatch
                        var result = _thisMachine.LoadProduct(product, "", out status);

                        _dataAcquisition.UpdateProductInLoadingStatus(result
                            ? ProductStatus.TraceabilityCheckedOk
                            : ProductStatus.TraceabilityCheckedNok);

                    if (result && EnableVirtualIndexer)
                    {
                        _machineData.VirtualIndexer.SetProductToStation(0, product, 1, 1);
                        VirtualIndexerToListBox(lb_Indexer);
                        _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.IndexConfirmed);
                    }
                    break;
                case ProductStatus.TraceabilityCheckedOk:
                    SetLabelText(lbl_LoadingStatus, "Traceability Check Ok");
                    break;
                case ProductStatus.TraceabilityCheckedNok:
                    SetLabelText(lbl_LoadingStatus, "Traceability Check Nok");
                    break;
            }
        }
    
        private void MachineHookException(string info)
        {
            ShowInformation(info);
        }

        private void MachineHookErrorOccured(string info)
        {
            ShowInformation(info);
        }
        public void ShowInformation(string text)
        {
            if (tb_ShowInformation.InvokeRequired)
            {
                DelegateShowInformation d = ShowInformation;
                Invoke(d, text);
            }
            else
            {
                tb_ShowInformation.AppendText(DateTime.Now.ToString("f")+" : "+ text + "\r\n");
            }
        }
        private void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                DelegateSetLabelText d = SetLabelText;
                Invoke(d, label, text);
            }
            else
            {
                label.Text = text;
            }
        }

        private void VirtualIndexerToListBox(ListBox lb)
        {
            if (!EnableVirtualIndexer) return;
            if (!(_machineData?.VirtualIndexer?.NumberOfStation() > 0)) return;

            lb.Items.Clear();
            var number = _machineData?.VirtualIndexer?.NumberOfStation();
            for (var i = 0; i < number; i++)
            {
                string product;
                _machineData.VirtualIndexer.GetStationProduct(i, out product);
                lb.Items.Add("Station [" + (i + 1) + "]=" + product);
            }
        }
        #endregion

        #region functions

        private void CheckReferenceLoadIfUnMatch(string datamatrix)
        {
            ReferenceParsed parsed;
            _thisMachine.ParseProductFullName(datamatrix, out parsed);
            if (parsed.ReferencePart != _thisMachine.ShowReference())
            {
                _machineData.ActiveReference = parsed.ReferencePart;
            }

        }
        private string ReadUnloading()
        {
            string result;
            if (EnableVirtualIndexer)
            {
                _machineData.VirtualIndexer.GetStationProduct(
                _machineData.VirtualIndexer.NumberOfStation() - 1, out result);
            }
            else
            {
                result = _dataAcquisition.ReadProductInUnloading();
            }
            lbl_UnloadingDataMatrix.Text = result;
            _machineData.ProductInUnloadingStation = result;
            return result;
        }
        private string ReadLoading()
        {
            var result = _dataAcquisition.ReadProductInLoading();
            lbl_LoadingDataMatrix.Text = result;
            _machineData.ProductInLoadingStation = result;
            return result;
        }
        private string ReadActiveReference()
        {
            var result = _dataAcquisition.ReadActiveReference();
            return result;
        }
        private void PlcScanMapping(int[] data)
        {
            _machineData.TraceabilityStates = (TraceabilityStates)data[3];
            if (!_traceabilityEnabled) return;
            _machineData.ProductInLoadingStatus= (ProductStatus)data[1];
            _machineData.ProductInUnloadingStatus = (ProductStatus)data[2];
            _machineData.VirtualIndexerStates=(VirtualIndexerStates)data[4];
        }
        #endregion

        private void btn_Initialize_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show(@"Lakukan Initialisasi?", @"Initialization", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dialog == DialogResult.Cancel) return;
            InitAll();
        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            using (var form = new HookSetting())
            {
                form.ShowDialog();
            }
        }

        private void tmr_Scanner_Tick(object sender, EventArgs e)
        {
            tmr_Scanner.Stop();
            if (_dataAcquisition != null)
            {
                try
                {
                    var dummy = _dataAcquisition.ReadScanData();
                    if (dummy.Length >= 5)
                    {
                        PlcScanMapping(dummy);
                    }

                    if (!lbl_PlcConnection.Text.Equals(@"Connected"))
                    {
                        lbl_PlcConnection.Text = @"Connected";
                    }
                    LampBlink(chb_ScanLamp);
                    tmr_Scanner.Start();
                    return;
                }
                catch (Exception ex)
                {
                    ShowInformation(@"PLC:" + ex.Message);
                    DaqReInitialize();               
                }

                if (!lbl_PlcConnection.Text.Equals(@"Not Connected"))
                {
                    lbl_PlcConnection.Text = @"Not Connected";
                }
               
            }
            else
            {
                DaqReInitialize();               
            }
        }

       
     

      
       

        #region Public Functions For Embedding to existing program

        public bool GenerateProductTraceability(string dataMatrix)
        {
            int status;
            if (!_traceabilityEnabled) return false;
            var result =  _thisMachine.StartProductTraceability(dataMatrix, "Auto", out status);
            lbl_GeneratedDataMatrix.Text = dataMatrix;
            lbl_GenerateResult.Text = result ? "Successful" : "Failed";
            return result;
        }

        public void SetProductTraceabilityOk(string dataMatrix)
        {
            if (!_traceabilityEnabled) return;
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.Unknown);
            _dataAcquisition.WriteProductInUnloading(dataMatrix);
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.LoadedNeedTraceabilityStatusUpdateOk);
        }
        public void SetProductTraceabilityNok(string dataMatrix)
        {
            if (!_traceabilityEnabled) return;
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.Unknown);
            _dataAcquisition.WriteProductInUnloading(dataMatrix);
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.LoadedNeedTraceabilityStatusUpdateNOk);
        }
        public void LoadProductTraceability(string dataMatrix)
        {
            if (!_traceabilityEnabled) return;
            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.Unknown);
            _dataAcquisition.WriteProductInLoading(dataMatrix);
            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.LoadedNeedTraceabilityCheck);
        }

        public void LoadReference(string reference)
        {
            _dataAcquisition.WriteActiveReference(reference);
        }
        public bool ProductDismantle(string dataMatrix)
        {
            int status;
            if (!_traceabilityEnabled) return false;
            return _thisMachine.ProductDismantle(dataMatrix, "Auto", out status);
        }
        public bool ForceUpdateProductOk(string dataMatrix)
        {
            int status;
            if (!_traceabilityEnabled) return false;
            return _thisMachine.ForceUpdateProductStatusOk(dataMatrix, out status);
        }
        public bool GetProductByDataMatrix(string dataMatrix, out ProductProcessWithDetails productProcess)
        {
            productProcess = new ProductProcessWithDetails();
            if (!_traceabilityEnabled) return false;
            return _thisMachine.GetProductLastProcessWithDetails(dataMatrix, out productProcess);
        }
        public bool CreateWorkOrderIfNotExistedReloadIfExisted(string workOrderNumber, string reference,int target)
        {
            int productId;
            if (!_traceabilityEnabled) return false;
            var result = _thisMachine.LoadReferenceCheck(reference, out productId );
            if (!result)
            {
                ShowInformation("Failed Reference check : "+reference+".");
                return false;
            }

            _machineData.ActiveReference = reference;
            int status;
            var result2 = _thisMachine.CreateWorkOrderIfNotExisted(workOrderNumber, productId, target, out status);
            lbl_OrderNumber.Text = result2 ? workOrderNumber : "";
            return result2;
        }

        public bool TraceabilityEnabled()
        {
            return _traceabilityEnabled;
        }

        public bool GetPreviousSequenceMachinesByProcessId(int processId, out List<ProductSequenceItem> machines)
        {
            return _thisMachine.GetPreviousSequenceMachinesByProcessId(processId, out machines);
        }

        public bool ProductProcessJumpBack(int processId, int jumpBackToMachineFamily)
        {
            return _thisMachine.ProductProcessJumpBack(processId, jumpBackToMachineFamily);
        }

        public bool ProductRename(string currentDataMatrix, string newDataMatrix)
        {
            return _thisMachine.ProductRename(currentDataMatrix, newDataMatrix);
        }
        #endregion

        private void btn_LoadReference_Click(object sender, EventArgs e)
        {
            if (_machineData != null) _machineData.ActiveReference = ReadActiveReference();
        }

      

        private void TraceabilityConnector_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !EmbeddedMode)
            {
                e.Cancel = true;
                var r = MessageBox.Show(@"Are you sure want to exit?",@"Close Application",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    e.Cancel = false;
                    myNotifyIcon.Visible = false;
                }
                return;
            }
            if ((e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.None) && EmbeddedMode)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void TraceabilityConnector_Resize(object sender, EventArgs e)
        {
            if (!EmbeddedMode)
            {
                if (FormWindowState.Minimized == this.WindowState)
                {
                    myNotifyIcon.Visible = true;
                    myNotifyIcon.ShowBalloonTip(500);
                    this.Hide();
                }

                else if (FormWindowState.Normal == this.WindowState)
                {
                    myNotifyIcon.Visible = false;
                    Show();
                }
            }
            else
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Hide();
                }
            }
        }


        private void TraceabilityConnector_VisibleChanged(object sender, EventArgs e)
        {         
            if (!Visible) return;
            WindowState = FormWindowState.Normal;
            Show();
            BringToFront();
        }

        private int _secretPasswordReset;
        private int _secretPasswordResetTimer;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _secretPasswordReset += 1;
            if (_secretPasswordReset == 1)
            {
                _secretPasswordResetTimer = 10;
            }
        }

       

        private void btn_ByPass_Click(object sender, EventArgs e)
        {

            using (var form = new LoginDialog())
            {
                form.ShowDialog();
                if (form.LoginSuccessfull)
                {
                    if (btn_ByPass2.Text.Equals("&By Pass"))
                    {
                        var dialog = MessageBox.Show(@"By Pass Traceability Mesin Ini?", @"By Pass", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);
                        if (dialog == DialogResult.Cancel) return;
                        ChangeTraceabilityState(true);
                        btn_ByPass2.Text = @"&Activate";
                    }
                    else
                    {
                        var dialog = MessageBox.Show(@"Activekan Traceability Mesin Ini?", @"Activekan", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question);
                        if (dialog == DialogResult.Cancel) return;
                        ChangeTraceabilityState(false);
                        btn_ByPass2.Text = @"&By Pass";
                    }
                }
            }

        }

        private void ChangeTraceabilityState(bool traceability)
        {
            _dataAcquisition.SetTraceabilityStates(traceability? TraceabilityStates.ByPassed : TraceabilityStates.WaitingForReference);
            _setting.SetEnableTraceability(!traceability);
          
            _traceabilityEnabled = !traceability;
        }

        

        private void tmr_PlcRetry_Tick(object sender, EventArgs e)
        {
            tmr_PlcRetry.Stop();
            InitAll();
        }

        private void btnAlarmClear_Click(object sender, EventArgs e)
        {
            tb_ShowInformation.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void gb_Embedded_Enter(object sender, EventArgs e)
        {

        }

        private void tmr_CLock_Tick(object sender, EventArgs e)
        {
            tmr_CLock.Stop();
            lbl_Clock.Text = DateTime.Now.ToString("F");
            if (_secretPasswordResetTimer > 0)
            {
                _secretPasswordResetTimer -= 1;
            }
            else
            {
                if (_secretPasswordReset == 5)
                {
                    _setting.SetAdminPassword("Pass1234");
                }
                if (_secretPasswordReset>0) _secretPasswordReset = 0;
            }
            tmr_CLock.Start();
        }

        private void myNotifyIcon_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tmrPingServer_Tick(object sender, EventArgs e)
        {
            tmrPingServer.Stop();
            var j = TestConnection.PingNow(_serverIp);
            if (j)
            {
                LampBlink(chb_PingServerLamp);
                SetLabelText(lblPingStatus, "OK");
                if (sender.GetType() == typeof(Button))
                {
                    MessageBox.Show(@"Ping Successfull!",@"Ping Server",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                _blinkCounter = 0;
                tmr_Blink.Start();
            }
            else
            {
                if (sender.GetType() == typeof(Button))
                {
                    MessageBox.Show(@"Ping Failed! Check Database Connection String Setting, Network Connection, and  PC Server is running.", @"Ping Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SetLabelText(lblPingStatus, "FAIL");
            }
            tmrPingServer.Start();
        }

        private int _blinkCounter;
        private void tmr_Blink_Tick(object sender, EventArgs e)
        {
            tmr_Blink.Stop();
            LampBlink(chb_PingServerLamp);
            _blinkCounter++;
            if (_blinkCounter<1) tmr_Blink.Start();
        }

        private void btnPingServer_Click(object sender, EventArgs e)
        {
            tmrPingServer_Tick(btnPingServer, null);
        }
    }
}
