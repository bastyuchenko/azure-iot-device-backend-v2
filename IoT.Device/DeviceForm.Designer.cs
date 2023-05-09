namespace IoT.Device
{
    partial class Device
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Device));
            btnRegister = new System.Windows.Forms.Button();
            lbStatus = new System.Windows.Forms.TextBox();
            tabControl = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            btnSendMsg = new System.Windows.Forms.Button();
            tbReceivedMsg = new System.Windows.Forms.TextBox();
            tbMsg = new System.Windows.Forms.TextBox();
            tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            btnStopTelemetryMessageReceiving = new System.Windows.Forms.Button();
            btnStartTelemetryMessageReceiving = new System.Windows.Forms.Button();
            tabPage3 = new System.Windows.Forms.TabPage();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tbDTReport = new System.Windows.Forms.TextBox();
            tbDTRead = new System.Windows.Forms.TextBox();
            btnWReported = new System.Windows.Forms.Button();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            btnReadDT = new System.Windows.Forms.Button();
            btnDTReadDesired = new System.Windows.Forms.Button();
            tabPage4 = new System.Windows.Forms.TabPage();
            tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            btnGenStream = new System.Windows.Forms.Button();
            btnGenerateStreamStop = new System.Windows.Forms.Button();
            tbMsgsExample = new System.Windows.Forms.TextBox();
            tabModuleTwin = new System.Windows.Forms.TabPage();
            tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            tbModuleTwinRepProps = new System.Windows.Forms.TextBox();
            btnModuleTwinDesiredPropsSubsr = new System.Windows.Forms.Button();
            btnModuleTwinRepProps = new System.Windows.Forms.Button();
            tbModuletwinDesProps = new System.Windows.Forms.TextBox();
            tabDirectMethods = new System.Windows.Forms.TabPage();
            label4 = new System.Windows.Forms.Label();
            tbDirectMethodName = new System.Windows.Forms.TextBox();
            btnSubscribeDirectMethod = new System.Windows.Forms.Button();
            tbAssignedHub = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            lbDeviceId = new System.Windows.Forms.Label();
            tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            btnCreateClient = new System.Windows.Forms.Button();
            btnModuleClient = new System.Windows.Forms.Button();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            tabPage3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPage4.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            tabModuleTwin.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            tabDirectMethods.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            btnRegister.Location = new System.Drawing.Point(3, 2);
            btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(150, 27);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lbStatus
            // 
            lbStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbStatus.BackColor = System.Drawing.SystemColors.ScrollBar;
            lbStatus.Location = new System.Drawing.Point(3, 2);
            lbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lbStatus.Multiline = true;
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new System.Drawing.Size(667, 752);
            lbStatus.TabIndex = 3;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage3);
            tabControl.Controls.Add(tabPage4);
            tabControl.Controls.Add(tabModuleTwin);
            tabControl.Controls.Add(tabDirectMethods);
            tabControl.Location = new System.Drawing.Point(676, 2);
            tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(668, 752);
            tabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.Gray;
            tabPage1.Controls.Add(tableLayoutPanel9);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage1.Size = new System.Drawing.Size(660, 724);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Send to/Receive from IoT Hub";
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.57407F));
            tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.42593F));
            tableLayoutPanel9.Controls.Add(btnSendMsg, 1, 0);
            tableLayoutPanel9.Controls.Add(tbReceivedMsg, 0, 1);
            tableLayoutPanel9.Controls.Add(tbMsg, 0, 0);
            tableLayoutPanel9.Controls.Add(tableLayoutPanel13, 1, 1);
            tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel9.Location = new System.Drawing.Point(3, 2);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new System.Drawing.Size(654, 720);
            tableLayoutPanel9.TabIndex = 7;
            // 
            // btnSendMsg
            // 
            btnSendMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            btnSendMsg.Location = new System.Drawing.Point(569, 2);
            btnSendMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new System.Drawing.Size(82, 356);
            btnSendMsg.TabIndex = 1;
            btnSendMsg.Text = "Send msg to IoT";
            btnSendMsg.UseVisualStyleBackColor = true;
            btnSendMsg.Click += btnSendMsg_Click;
            // 
            // tbReceivedMsg
            // 
            tbReceivedMsg.BackColor = System.Drawing.SystemColors.ScrollBar;
            tbReceivedMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            tbReceivedMsg.Location = new System.Drawing.Point(3, 362);
            tbReceivedMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbReceivedMsg.Multiline = true;
            tbReceivedMsg.Name = "tbReceivedMsg";
            tbReceivedMsg.ReadOnly = true;
            tbReceivedMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbReceivedMsg.Size = new System.Drawing.Size(560, 356);
            tbReceivedMsg.TabIndex = 6;
            // 
            // tbMsg
            // 
            tbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            tbMsg.Location = new System.Drawing.Point(3, 2);
            tbMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbMsg.Multiline = true;
            tbMsg.Name = "tbMsg";
            tbMsg.Size = new System.Drawing.Size(560, 356);
            tbMsg.TabIndex = 0;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 1;
            tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel13.Controls.Add(btnStopTelemetryMessageReceiving, 0, 1);
            tableLayoutPanel13.Controls.Add(btnStartTelemetryMessageReceiving, 0, 0);
            tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel13.Location = new System.Drawing.Point(569, 363);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 2;
            tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel13.Size = new System.Drawing.Size(82, 354);
            tableLayoutPanel13.TabIndex = 8;
            // 
            // btnStopTelemetryMessageReceiving
            // 
            btnStopTelemetryMessageReceiving.Dock = System.Windows.Forms.DockStyle.Fill;
            btnStopTelemetryMessageReceiving.Location = new System.Drawing.Point(3, 179);
            btnStopTelemetryMessageReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnStopTelemetryMessageReceiving.Name = "btnStopTelemetryMessageReceiving";
            btnStopTelemetryMessageReceiving.Size = new System.Drawing.Size(76, 173);
            btnStopTelemetryMessageReceiving.TabIndex = 7;
            btnStopTelemetryMessageReceiving.Text = "Stop telemetry message listening";
            btnStopTelemetryMessageReceiving.UseVisualStyleBackColor = true;
            btnStopTelemetryMessageReceiving.Click += btnStopTelemetryMessageReceiving_Click;
            // 
            // btnStartTelemetryMessageReceiving
            // 
            btnStartTelemetryMessageReceiving.Dock = System.Windows.Forms.DockStyle.Fill;
            btnStartTelemetryMessageReceiving.Location = new System.Drawing.Point(3, 2);
            btnStartTelemetryMessageReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnStartTelemetryMessageReceiving.Name = "btnStartTelemetryMessageReceiving";
            btnStartTelemetryMessageReceiving.Size = new System.Drawing.Size(76, 173);
            btnStartTelemetryMessageReceiving.TabIndex = 0;
            btnStartTelemetryMessageReceiving.Text = "Start telemetry message listening";
            btnStartTelemetryMessageReceiving.UseVisualStyleBackColor = true;
            btnStartTelemetryMessageReceiving.Click += btnStartTelemetryMessageReceiving_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = System.Drawing.SystemColors.ControlDark;
            tabPage3.Controls.Add(tableLayoutPanel1);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new System.Drawing.Size(660, 724);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "DeviceTwin";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            tableLayoutPanel1.Controls.Add(tbDTReport, 0, 0);
            tableLayoutPanel1.Controls.Add(tbDTRead, 0, 1);
            tableLayoutPanel1.Controls.Add(btnWReported, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(660, 724);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // tbDTReport
            // 
            tbDTReport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDTReport.Location = new System.Drawing.Point(3, 2);
            tbDTReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbDTReport.Multiline = true;
            tbDTReport.Name = "tbDTReport";
            tbDTReport.Size = new System.Drawing.Size(561, 358);
            tbDTReport.TabIndex = 7;
            // 
            // tbDTRead
            // 
            tbDTRead.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDTRead.BackColor = System.Drawing.SystemColors.ScrollBar;
            tbDTRead.Location = new System.Drawing.Point(3, 364);
            tbDTRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbDTRead.Multiline = true;
            tbDTRead.Name = "tbDTRead";
            tbDTRead.ReadOnly = true;
            tbDTRead.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbDTRead.Size = new System.Drawing.Size(561, 358);
            tbDTRead.TabIndex = 8;
            tbDTRead.WordWrap = false;
            // 
            // btnWReported
            // 
            btnWReported.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnWReported.Location = new System.Drawing.Point(584, 2);
            btnWReported.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnWReported.Name = "btnWReported";
            btnWReported.Size = new System.Drawing.Size(73, 44);
            btnWReported.TabIndex = 0;
            btnWReported.Text = "write Reported";
            btnWReported.UseVisualStyleBackColor = true;
            btnWReported.Click += btnWReported_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnReadDT, 0, 0);
            tableLayoutPanel2.Controls.Add(btnDTReadDesired, 0, 1);
            tableLayoutPanel2.Location = new System.Drawing.Point(570, 365);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.27737F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.72263F));
            tableLayoutPanel2.Size = new System.Drawing.Size(86, 238);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // btnReadDT
            // 
            btnReadDT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnReadDT.Location = new System.Drawing.Point(3, 2);
            btnReadDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnReadDT.Name = "btnReadDT";
            btnReadDT.Size = new System.Drawing.Size(80, 58);
            btnReadDT.TabIndex = 9;
            btnReadDT.Text = "read Device Twin";
            btnReadDT.UseVisualStyleBackColor = true;
            btnReadDT.Click += btnReadDT_Click;
            // 
            // btnDTReadDesired
            // 
            btnDTReadDesired.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDTReadDesired.Location = new System.Drawing.Point(3, 64);
            btnDTReadDesired.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnDTReadDesired.Name = "btnDTReadDesired";
            btnDTReadDesired.Size = new System.Drawing.Size(80, 104);
            btnDTReadDesired.TabIndex = 1;
            btnDTReadDesired.Text = "subscribe on Device Twin Desired Properties";
            btnDTReadDesired.UseVisualStyleBackColor = true;
            btnDTReadDesired.Click += btnRDesired_Click;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = System.Drawing.Color.Gray;
            tabPage4.Controls.Add(tableLayoutPanel10);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(660, 724);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Generate stream";
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 1;
            tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel10.Controls.Add(tableLayoutPanel11, 0, 0);
            tableLayoutPanel10.Controls.Add(tbMsgsExample, 0, 1);
            tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.604017F));
            tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.39598F));
            tableLayoutPanel10.Size = new System.Drawing.Size(660, 724);
            tableLayoutPanel10.TabIndex = 3;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 2;
            tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel11.Controls.Add(btnGenStream, 0, 0);
            tableLayoutPanel11.Controls.Add(btnGenerateStreamStop, 1, 0);
            tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel11.Size = new System.Drawing.Size(200, 46);
            tableLayoutPanel11.TabIndex = 0;
            // 
            // btnGenStream
            // 
            btnGenStream.Location = new System.Drawing.Point(3, 2);
            btnGenStream.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnGenStream.Name = "btnGenStream";
            btnGenStream.Size = new System.Drawing.Size(94, 41);
            btnGenStream.TabIndex = 0;
            btnGenStream.Text = "Generate stream - Start";
            btnGenStream.UseVisualStyleBackColor = true;
            btnGenStream.Click += btnGenStream_Click;
            // 
            // btnGenerateStreamStop
            // 
            btnGenerateStreamStop.Location = new System.Drawing.Point(103, 2);
            btnGenerateStreamStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnGenerateStreamStop.Name = "btnGenerateStreamStop";
            btnGenerateStreamStop.Size = new System.Drawing.Size(94, 41);
            btnGenerateStreamStop.TabIndex = 2;
            btnGenerateStreamStop.Text = "Generate stream - Stop";
            btnGenerateStreamStop.UseVisualStyleBackColor = true;
            btnGenerateStreamStop.Click += btnGenerateStreamStop_Click;
            // 
            // tbMsgsExample
            // 
            tbMsgsExample.Dock = System.Windows.Forms.DockStyle.Fill;
            tbMsgsExample.Location = new System.Drawing.Point(3, 57);
            tbMsgsExample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbMsgsExample.Multiline = true;
            tbMsgsExample.Name = "tbMsgsExample";
            tbMsgsExample.ReadOnly = true;
            tbMsgsExample.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbMsgsExample.Size = new System.Drawing.Size(654, 665);
            tbMsgsExample.TabIndex = 1;
            // 
            // tabModuleTwin
            // 
            tabModuleTwin.BackColor = System.Drawing.Color.Gray;
            tabModuleTwin.Controls.Add(tableLayoutPanel12);
            tabModuleTwin.Location = new System.Drawing.Point(4, 24);
            tabModuleTwin.Name = "tabModuleTwin";
            tabModuleTwin.Padding = new System.Windows.Forms.Padding(3);
            tabModuleTwin.Size = new System.Drawing.Size(660, 724);
            tabModuleTwin.TabIndex = 4;
            tabModuleTwin.Text = "ModuleTwin";
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.ColumnCount = 2;
            tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel12.Controls.Add(tbModuleTwinRepProps, 0, 0);
            tableLayoutPanel12.Controls.Add(btnModuleTwinDesiredPropsSubsr, 1, 1);
            tableLayoutPanel12.Controls.Add(btnModuleTwinRepProps, 1, 0);
            tableLayoutPanel12.Controls.Add(tbModuletwinDesProps, 0, 1);
            tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 2;
            tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel12.Size = new System.Drawing.Size(654, 718);
            tableLayoutPanel12.TabIndex = 0;
            // 
            // tbModuleTwinRepProps
            // 
            tbModuleTwinRepProps.Dock = System.Windows.Forms.DockStyle.Fill;
            tbModuleTwinRepProps.Location = new System.Drawing.Point(3, 3);
            tbModuleTwinRepProps.Multiline = true;
            tbModuleTwinRepProps.Name = "tbModuleTwinRepProps";
            tbModuleTwinRepProps.Size = new System.Drawing.Size(321, 353);
            tbModuleTwinRepProps.TabIndex = 0;
            // 
            // btnModuleTwinDesiredPropsSubsr
            // 
            btnModuleTwinDesiredPropsSubsr.Location = new System.Drawing.Point(330, 362);
            btnModuleTwinDesiredPropsSubsr.Name = "btnModuleTwinDesiredPropsSubsr";
            btnModuleTwinDesiredPropsSubsr.Size = new System.Drawing.Size(113, 64);
            btnModuleTwinDesiredPropsSubsr.TabIndex = 1;
            btnModuleTwinDesiredPropsSubsr.Text = "Subscribe module twin desired props";
            btnModuleTwinDesiredPropsSubsr.UseVisualStyleBackColor = true;
            btnModuleTwinDesiredPropsSubsr.Click += btnModuleTwinDesiredPropsSubsr_Click;
            // 
            // btnModuleTwinRepProps
            // 
            btnModuleTwinRepProps.Location = new System.Drawing.Point(330, 3);
            btnModuleTwinRepProps.Name = "btnModuleTwinRepProps";
            btnModuleTwinRepProps.Size = new System.Drawing.Size(102, 51);
            btnModuleTwinRepProps.TabIndex = 2;
            btnModuleTwinRepProps.Text = "Set reported props";
            btnModuleTwinRepProps.UseVisualStyleBackColor = true;
            btnModuleTwinRepProps.Click += btnModuleTwinRepProps_Click;
            // 
            // tbModuletwinDesProps
            // 
            tbModuletwinDesProps.Dock = System.Windows.Forms.DockStyle.Fill;
            tbModuletwinDesProps.Location = new System.Drawing.Point(3, 362);
            tbModuletwinDesProps.Multiline = true;
            tbModuletwinDesProps.Name = "tbModuletwinDesProps";
            tbModuletwinDesProps.Size = new System.Drawing.Size(321, 353);
            tbModuletwinDesProps.TabIndex = 3;
            // 
            // tabDirectMethods
            // 
            tabDirectMethods.Controls.Add(label4);
            tabDirectMethods.Controls.Add(tbDirectMethodName);
            tabDirectMethods.Controls.Add(btnSubscribeDirectMethod);
            tabDirectMethods.Location = new System.Drawing.Point(4, 24);
            tabDirectMethods.Name = "tabDirectMethods";
            tabDirectMethods.Size = new System.Drawing.Size(660, 724);
            tabDirectMethods.TabIndex = 5;
            tabDirectMethods.Text = "Direct Methods";
            tabDirectMethods.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(18, 33);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(116, 15);
            label4.TabIndex = 4;
            label4.Text = "Direct method name";
            // 
            // tbDirectMethodName
            // 
            tbDirectMethodName.Location = new System.Drawing.Point(140, 30);
            tbDirectMethodName.Name = "tbDirectMethodName";
            tbDirectMethodName.Size = new System.Drawing.Size(370, 23);
            tbDirectMethodName.TabIndex = 3;
            tbDirectMethodName.Text = "SetTelemetryInterval";
            // 
            // btnSubscribeDirectMethod
            // 
            btnSubscribeDirectMethod.Location = new System.Drawing.Point(540, 20);
            btnSubscribeDirectMethod.Name = "btnSubscribeDirectMethod";
            btnSubscribeDirectMethod.Size = new System.Drawing.Size(75, 60);
            btnSubscribeDirectMethod.TabIndex = 0;
            btnSubscribeDirectMethod.Text = "Subscribe direct method";
            btnSubscribeDirectMethod.UseVisualStyleBackColor = true;
            btnSubscribeDirectMethod.Click += btnSubscribeDirectMethod_Click;
            // 
            // tbAssignedHub
            // 
            tbAssignedHub.Dock = System.Windows.Forms.DockStyle.Fill;
            tbAssignedHub.Location = new System.Drawing.Point(439, 2);
            tbAssignedHub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tbAssignedHub.Name = "tbAssignedHub";
            tbAssignedHub.ReadOnly = true;
            tbAssignedHub.Size = new System.Drawing.Size(927, 23);
            tbAssignedHub.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(165, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "Device Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(352, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(81, 15);
            label3.TabIndex = 4;
            label3.Text = "Assigned Hub";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(lbStatus, 0, 0);
            tableLayoutPanel3.Controls.Add(tabControl, 1, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 109);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(1347, 756);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 5;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.Controls.Add(label2, 1, 0);
            tableLayoutPanel4.Controls.Add(tbAssignedHub, 4, 0);
            tableLayoutPanel4.Controls.Add(label3, 3, 0);
            tableLayoutPanel4.Controls.Add(lbDeviceId, 2, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new System.Drawing.Size(1347, 100);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // lbDeviceId
            // 
            lbDeviceId.Dock = System.Windows.Forms.DockStyle.Fill;
            lbDeviceId.Location = new System.Drawing.Point(226, 2);
            lbDeviceId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lbDeviceId.Name = "lbDeviceId";
            lbDeviceId.Size = new System.Drawing.Size(120, 96);
            lbDeviceId.TabIndex = 0;
            lbDeviceId.Text = "There is no reason to know SerialNumber, the SerialNumber is stored in certificate.";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(btnRegister, 0, 0);
            tableLayoutPanel6.Controls.Add(btnCreateClient, 0, 1);
            tableLayoutPanel6.Controls.Add(btnModuleClient, 0, 2);
            tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.Size = new System.Drawing.Size(156, 94);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // btnCreateClient
            // 
            btnCreateClient.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCreateClient.Location = new System.Drawing.Point(3, 34);
            btnCreateClient.Name = "btnCreateClient";
            btnCreateClient.Size = new System.Drawing.Size(150, 25);
            btnCreateClient.TabIndex = 3;
            btnCreateClient.Text = "Create Device Client";
            btnCreateClient.UseVisualStyleBackColor = true;
            btnCreateClient.Click += btnCreateClient_Click;
            // 
            // btnModuleClient
            // 
            btnModuleClient.Dock = System.Windows.Forms.DockStyle.Fill;
            btnModuleClient.Location = new System.Drawing.Point(3, 65);
            btnModuleClient.Name = "btnModuleClient";
            btnModuleClient.Size = new System.Drawing.Size(150, 26);
            btnModuleClient.TabIndex = 4;
            btnModuleClient.Text = "Create Module Client";
            btnModuleClient.UseVisualStyleBackColor = true;
            btnModuleClient.Click += btnModuleClient_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.Size = new System.Drawing.Size(1353, 843);
            tableLayoutPanel5.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.Location = new System.Drawing.Point(3, 2);
            textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(166, 344);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            textBox2.Location = new System.Drawing.Point(3, 350);
            textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textBox2.Size = new System.Drawing.Size(166, 345);
            textBox2.TabIndex = 8;
            textBox2.WordWrap = false;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(175, 2);
            button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(22, 44);
            button1.TabIndex = 0;
            button1.Text = "write Reported";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnWReported_Click;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(button2, 0, 0);
            tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.Size = new System.Drawing.Size(200, 100);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(117, 2);
            button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(80, 58);
            button2.TabIndex = 9;
            button2.Text = "read Device Twin";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnReadDT_Click;
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button3.Location = new System.Drawing.Point(117, 64);
            button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(80, 104);
            button3.TabIndex = 1;
            button3.Text = "subscribe on Device Twin Desired Properties";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnRDesired_Click;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86F));
            tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            tableLayoutPanel7.Controls.Add(textBox1, 0, 0);
            tableLayoutPanel7.Controls.Add(textBox2, 0, 1);
            tableLayoutPanel7.Controls.Add(button1, 1, 0);
            tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.Size = new System.Drawing.Size(200, 100);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // Device
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(1353, 843);
            Controls.Add(tableLayoutPanel5);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Device";
            Text = "Device";
            Load += Device_Load;
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel13.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            tabModuleTwin.ResumeLayout(false);
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel12.PerformLayout();
            tabDirectMethods.ResumeLayout(false);
            tabDirectMethods.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox lbStatus;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbAssignedHub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDTReadDesired;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbMsgsExample;
        private System.Windows.Forms.Button btnGenStream;
        private System.Windows.Forms.Button btnStartTelemetryMessageReceiving;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox tbReceivedMsg;
        private System.Windows.Forms.Button btnReadDT;
        private System.Windows.Forms.Button btnGenerateStreamStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbDTReport;
        private System.Windows.Forms.TextBox tbDTRead;
        private System.Windows.Forms.Button btnWReported;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnCreateClient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TabPage tabModuleTwin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TextBox tbModuleTwinRepProps;
        private System.Windows.Forms.Button btnModuleTwinDesiredPropsSubsr;
        private System.Windows.Forms.Button btnModuleTwinRepProps;
        private System.Windows.Forms.TextBox tbModuletwinDesProps;
        private System.Windows.Forms.Label lbDeviceId;
        private System.Windows.Forms.TabPage tabDirectMethods;
        private System.Windows.Forms.Button btnSubscribeDirectMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDirectMethodName;
        private System.Windows.Forms.Button btnStopTelemetryMessageReceiving;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Button btnModuleClient;
    }
}
