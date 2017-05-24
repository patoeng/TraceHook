using System;
using System.Drawing;
using System.Windows.Forms;
using Traceability.Hook;
using Traceability.Hook.Models;
using Traceability.Hook.Setting;


namespace TraceabilityConnector
{
    public partial class TraceabilityConnector : Form
    {
        public  bool EmbeddedMode { get; protected set; }

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

        public TraceabilityConnector(bool embeddedMode)
        {
            EmbeddedMode = embeddedMode;
            InitializeComponent();
            InitAll();   
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            
        }
#region Non Form Events

        private void InitAll()
        {
            tb_ShowInformation.Clear();
            _setting = new SettingHook();
            _plcIpAddress = _setting.GetPlcIpAdress();
            _traceabilityEnabled = _setting.GetEnableTraceability();
            _plcScanRate = _setting.GetPlcScanRate();         
            _enableVirtualIndexer = _setting.GetVirtualIndexer();
          

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
                     if(!_enableVirtualIndexer) lbl_VirtualIndexer.Text = @"Not Used";
                    _dataAcquisition.SetVirtualIndexer(
                    _enableVirtualIndexer ? VirtualIndexerStates.IndexConfirmed : VirtualIndexerStates.NotIndexed);

                   SetTraceabilityStates(_traceabilityEnabled? TraceabilityStates.WaitingForReference: TraceabilityStates.ByPassed);
                    btn_ByPass.Text = _traceabilityEnabled ? "By Pass" : "Activate";
                   if (!_enableVirtualIndexer) _machineData.ActiveReference = ReadActiveReference();

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
            _machineData = new MachineData(_enableVirtualIndexer);
            _machineData.ProductInLoadingStatusChanged += ProductInLoadingStatusChanged;
            _machineData.ProductInUnloadingStatusChanged += ProductInUnloadingStatusChanged;
            _machineData.ReferenceChanged += ReferenceChanged;
            _machineData.TraceabilityStateChanged += TraceabilityStateChanged;
            if (_enableVirtualIndexer) _machineData.VirtualIndexerStateChanged += VirtualIndexerStateChanged;
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
                    _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.WaitingTraceabilityStatusCheck);
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
                    break;
                case VirtualIndexerStates.UpdateTraceabilityStatus:
                    SetLabelText(lbl_VirtualIndexer, "Waiting Unloading Traceability Status Update");
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
                if (_enableVirtualIndexer) _machineData.VirtualIndexerStateChanged -= VirtualIndexerStateChanged;
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
                    if (!_enableVirtualIndexer) _machineData.ActiveReference = ReadActiveReference();
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

                    if (result && _enableVirtualIndexer)
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
        private void ShowInformation(string text)
        {
            if (tb_ShowInformation.InvokeRequired)
            {
                DelegateShowInformation d = ShowInformation;
                Invoke(d, text);
            }
            else
            {
                tb_ShowInformation.AppendText(text + "\r\n");
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
            if (!_enableVirtualIndexer) return;
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
            if (_enableVirtualIndexer)
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
            _machineData.ProductInLoadingStatus= (ProductStatus)data[1];
            _machineData.ProductInUnloadingStatus = (ProductStatus)data[2];
            _machineData.TraceabilityStates = (TraceabilityStates) data[3];
            _machineData.VirtualIndexerStates=(VirtualIndexerStates)data[4];
        }
        #endregion

        private void btn_Initialize_Click(object sender, EventArgs e)
        {
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
                    DaqReInitialize();
                    ShowInformation(@"PLC:" + ex.Message);                 
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

       
     

        private void btn_WriteToLoading_Click(object sender, EventArgs e)
        {
            _dataAcquisition.WriteProductInLoading(textBox5.Text);
        }

        private void btn_WriteToUnloading_Click(object sender, EventArgs e)
        {
            _dataAcquisition.WriteProductInUnloading(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _dataAcquisition.WriteActiveReference(textBox4.Text);            
        }

       

        #region Public Functions For Embedding to existing program

        public bool GenerateProductTraceability(string dataMatrix)
        {
            int status;
            if (!_traceabilityEnabled) return false;
            return _thisMachine.StartProductTraceability(dataMatrix, "Auto", out status);          
        }

        public void SetProductTraceabilityOk(string dataMatrix)
        {
            if (!_traceabilityEnabled) return;
            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.Unknown);
            _dataAcquisition.WriteProductInUnloading(dataMatrix);
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.LoadedNeedTraceabilityStatusUpdateOk);
        }
        public void SetProductTraceabilityNok(string dataMatrix)
        {
            if (!_traceabilityEnabled) return;
            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.Unknown);
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
            if (!result) return false;
            _machineData.ActiveReference = reference;
            int status;
            return _thisMachine.CreateWorkOrderIfNotExisted(workOrderNumber, productId, target, out status);
        }

        public bool TraceabilityEnabled()
        {
            return _traceabilityEnabled;
        }

        #endregion

        private void btn_LoadReference_Click(object sender, EventArgs e)
        {
            if (_machineData != null) _machineData.ActiveReference = ReadActiveReference();
        }

        private void btn_SetRequestCheck_Click(object sender, EventArgs e)
        {
            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.LoadedNeedTraceabilityCheck);
        }

        private void btn_SetProcessOk_Click(object sender, EventArgs e)
        {
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.LoadedNeedTraceabilityStatusUpdateOk);
        }

        private void btn_SetProcessNok_Click(object sender, EventArgs e)
        {
            _dataAcquisition.UpdateProductInUnloadingStatus(ProductStatus.LoadedNeedTraceabilityStatusUpdateNOk);
        }

        private void btn_IndexTable_Click(object sender, EventArgs e)
        {
            _dataAcquisition.SetVirtualIndexer(VirtualIndexerStates.NewlyIndexed);
        }

        private void TraceabilityConnector_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.None || !EmbeddedMode)
                return;
            e.Cancel = true;
            Hide();
        }

        private void TraceabilityConnector_Resize(object sender, EventArgs e)
        {
            if (!EmbeddedMode) return;
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }


        private void TraceabilityConnector_VisibleChanged(object sender, EventArgs e)
        {
            if (!EmbeddedMode) return;
            if (!Visible) return;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private int _count;     
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _count++;
            if (_count > 3)
            {
                _count = 0;
                gb_MachineSimulation.Visible = true;
                pictureBox1.Hide();
            }
            else
            {
                gb_MachineSimulation.Visible = false;
                pictureBox1.Show();
            }
        }

        private void btn_Hide_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            gb_MachineSimulation.Hide();
        }

        private void btn_ByPass_Click(object sender, EventArgs e)
        {

            using (var form = new LoginDialog())
            {
                form.ShowDialog();
                if (form.LoginSuccessfull)
                {
                    if (btn_ByPass.Text.Equals("By Pass"))
                    {
                        ChangeTraceabilityState(true);
                        btn_ByPass.Text = @"Activate";
                    }
                    else
                    {
                        ChangeTraceabilityState(false);
                        btn_ByPass.Text = @"By Pass";
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

        private void button2_Click(object sender, EventArgs e)
        {
            _dataAcquisition.UpdateProductInLoadingStatus(ProductStatus.Unknown);
        }

        private void tmr_PlcRetry_Tick(object sender, EventArgs e)
        {
            tmr_PlcRetry.Stop();
            InitAll();
        }
    }
}
