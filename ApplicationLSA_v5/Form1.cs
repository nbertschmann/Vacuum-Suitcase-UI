using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace ApplicationLSA_v5
{
    public partial class Form1 : Form
    {
        private int collectHoursInt;
        private int collectMinutesInt;
        private int intervalMinutesInt;
        private int IntervalSecondsInt;

        private TimeSpan _maxTime;
        private TimeSpan _intervalTime;
        private TimeSpan _lastReadTime;
        private TimeSpan _timeSinceStartTime;
        private DateTime _startTime = DateTime.MinValue;
        private System.Windows.Forms.Timer _timer;

        private Color activateButtonColor = Color.FromArgb(102, 200, 255);
        private Color deactivateButtonColor = Color.FromArgb(175, 175, 175);

        /// <summary>
        /// Shows if program is in the middle of a read.
        /// </summary>
        private bool readInProgress = false;

        /// <summary>
        /// If for any reason the LSA read needs to stop, set to true.
        /// </summary>
        private bool stopReading = false;

        /// <summary>
        /// Stores <see cref="DataPoint"/> objects of each read.
        /// </summary>
        private static List<DataPoint> saveDataList = new List<DataPoint>();

        public static List<DataPoint> SaveDataList
        {
            get { return saveDataList; }
        }

        /// <summary>
        /// Stores selected COM Port.
        /// </summary>
        public string ComPort
        {
            get { return comboBoxComPort.SelectedItem.ToString(); }
        }


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up the form in its intial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1405, 575);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            TextBox.CheckForIllegalCrossThreadCalls = false;
            GetComPorts();
            SetColours();

            labelCheckmarkTimer.Hide();
            comboBoxComPort.Select();
            StartButtonState(false);
            AbortButtonState(false);
            SetUpButtonState(false);
            SaveButtonState(false);
            OnButtonState(false);
            OffButtonState(false);
            RefreshButtonState(true);

            TimerEventStart();

            foreach (TabPage tp in tabControl1.TabPages)
            {
                tp.Show();
            }
        }

        /// <summary>
        /// Sets up timer and timing event handler.
        /// </summary>
        ///<remarks>
        ///_timer.Interval specifies how often the time is read.
        /// </remarks>
        private void TimerEventStart()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 300;
            _timer.Tick += new EventHandler(TimerTick);
        }

        /// <summary>
        /// Resets form and reloads available COM Ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshComPort_Click(object sender, EventArgs e)
        {
            GetComPorts();
            OnButtonState(false);
            OffButtonState(false);
            StartButtonState(false);
            AbortButtonState(false);
            SetUpButtonState(false);

            textBoxCollectHours.Clear();
            textBoxCollectMinutes.Clear();
            textBoxIntervalMinutes.Clear();
            textBoxIntervalSeconds.Clear();
            textBoxTimer.Clear();
        }

        /// <summary>
        /// Opens new FormTimeInput form.
        /// </summary>
        /// <remarks>
        /// Time input strings are converted to int. This is because these int variables are used in <see cref="SetUpTiming"/>
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetUpTiming_Click(object sender, EventArgs e)
        {
            FormTimeInput f = new FormTimeInput();

            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(this.Left, this.Top + 30);
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {

                if (!Int32.TryParse(f.CollectInputHours, out collectHoursInt))
                {
                    collectHoursInt = 0;
                }

                if (!Int32.TryParse(f.CollectInputMinutes, out collectMinutesInt))
                {
                    collectMinutesInt = 0;
                }

                if (!Int32.TryParse(f.IntervalInputMinutes, out intervalMinutesInt))
                {
                    intervalMinutesInt = 0;
                }

                if (!Int32.TryParse(f.IntervalInputSeconds, out IntervalSecondsInt))
                {
                    IntervalSecondsInt = 0;
                }

                textBoxCollectHours.Text = collectHoursInt.ToString();
                textBoxCollectMinutes.Text = collectMinutesInt.ToString();
                textBoxIntervalMinutes.Text = intervalMinutesInt.ToString();
                textBoxIntervalSeconds.Text = IntervalSecondsInt.ToString();

                StartButtonState(true);
            }


        }

        /// <summary>
        /// Sets up for a new set of data reads.
        /// </summary>
        /// <remarks>
        /// Timing begins, and a new thread is started to read data.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            RefreshButtonState(false);
            SetUpButtonState(false);
            StartButtonState(false);
            AbortButtonState(true);
            ComboBoxState(false);
            SaveButtonState(false);
            OnButtonState(false);
            OffButtonState(false);

            readInProgress = true;
            stopReading = false;
            saveDataList.Clear();
            ChartTemperatureClear();
            ChartPressureClear();
            DataPoint.DataPtCount = 0;

            SetUpTiming();

            Thread startCollectData = new Thread(ReadAndDisplayData);
            startCollectData.Start();
        }


        /// <summary>
        /// Opens new FormAbort form.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAbort_Click(object sender, EventArgs e)
        {
            FormAbort a = new FormAbort();
            a.StartPosition = FormStartPosition.Manual;
            a.Location = new Point(this.Left, this.Top + 30);

            a.ShowDialog();

            //if we go through with abort, stop reading data          
            if (a.DialogResult == DialogResult.OK)
            {
                StopReading();

                if (a.AbortAndSave)
                {
                    SaveData();
                }

                if (a.AbortWithoutSaving)
                {
                    SaveButtonState(false);
                }
            }

            if (a.DialogResult == DialogResult.Cancel)
            {

            }
        }


        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// Writes a character to the LSA - corresponds to the 'on' command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLsaOn_Click(object sender, EventArgs e)
        {
            OffButtonState(true);

            SerialPort _serialPort = SerialPortBegin();

            if (_serialPort.IsOpen)
            {
                _serialPort.Write("B");
                _serialPort.Close();
            }
        }

        /// <summary>
        /// Writes a character to LSA - corresponds to the 'off' command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLsaOff_Click(object sender, EventArgs e)
        {
            OffButtonState(false);

            SerialPort _serialPort = SerialPortBegin();

            if (_serialPort.IsOpen)
            {
                _serialPort.Write("C");
                _serialPort.Close();
            }
        }

        /// <summary>
        /// Activates specific buttons which allow the user to go to the next step of the program
        /// </summary>
        /// <remarks>
        /// Called when a COM Port is selected from the combo box
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetUpButtonState(true);
            OnButtonState(true);
            OffButtonState(true);

        }

        /// <summary>
        /// Gets names of ports that an external USB device is connected to.
        /// Adds port names to combobox.
        /// </summary>
        private void GetComPorts()
        {
            string[] comPortArray = SerialPort.GetPortNames();
            comboBoxComPort.DropDownStyle = ComboBoxStyle.DropDownList;


            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(comPortArray);
        }

        /// <summary>
        /// Calculates total amount of seconds for read duration and read interval.
        /// Sets timing variables to begin timing.
        /// </summary>
        private void SetUpTiming()
        {
            int collectTotalSeconds = (collectHoursInt * 3600) + (collectMinutesInt * 60);
            int intervalTotalSeconds = (intervalMinutesInt * 60) + (IntervalSecondsInt);

            _maxTime = TimeSpan.FromSeconds(collectTotalSeconds);
            _intervalTime = TimeSpan.FromSeconds(intervalTotalSeconds);
            _lastReadTime = TimeSpan.FromSeconds(0);
            _timeSinceStartTime = TimeSpan.FromSeconds(0);
            _startTime = DateTime.Now;

            _timer.Start();
        }

        /// <summary>
        /// Sets desired colours for form backround, buttons, and text.
        /// </summary>
        private void SetColours()
        {
            Color labelBackColor = Color.FromArgb(0, 51, 142);
            Color groupBoxColor = Color.FromArgb(0, 51, 142);
            Color minorlabelColor = Color.FromArgb(225, 225, 225);
            Color majorLabelColor = Color.FromArgb(255, 255, 255);
            Color txtBoxColor = Color.FromArgb(210, 210, 210);
            this.labelCheckmarkTimer.ForeColor = Color.FromArgb(124, 252, 0);

            this.BackColor = labelBackColor;
            label1.BackColor = labelBackColor;
            label3.BackColor = labelBackColor;
            label4.BackColor = labelBackColor;
            label5.BackColor = labelBackColor;
            label6.BackColor = labelBackColor;
            label7.BackColor = labelBackColor;
            label8.BackColor = labelBackColor;
            label9.BackColor = labelBackColor;
            label10.BackColor = labelBackColor;
            label11.BackColor = labelBackColor;
            label12.BackColor = labelBackColor;
            label13.BackColor = labelBackColor;
            label14.BackColor = labelBackColor;
            label15.BackColor = labelBackColor;
            label16.BackColor = labelBackColor;
            label17.BackColor = labelBackColor;
            label18.BackColor = labelBackColor;
            label19.BackColor = labelBackColor;
            label20.BackColor = labelBackColor;
            label21.BackColor = labelBackColor;
            label22.BackColor = labelBackColor;
            label23.BackColor = labelBackColor;
            label24.BackColor = labelBackColor;
            label25.BackColor = labelBackColor;

            groupBox1.BackColor = groupBoxColor;
            groupBox2.BackColor = groupBoxColor;
            groupBox3.BackColor = groupBoxColor;
            groupBox4.BackColor = groupBoxColor;

            label1.ForeColor = minorlabelColor;
            label3.ForeColor = minorlabelColor;
            label4.ForeColor = minorlabelColor;
            label5.ForeColor = minorlabelColor;
            label6.ForeColor = minorlabelColor;
            label7.ForeColor = minorlabelColor;
            label8.ForeColor = minorlabelColor;
            label9.ForeColor = minorlabelColor;
            label10.ForeColor = minorlabelColor;
            label11.ForeColor = minorlabelColor;
            label12.ForeColor = minorlabelColor;
            label17.ForeColor = minorlabelColor;
            label18.ForeColor = minorlabelColor;
            label19.ForeColor = minorlabelColor;
            label20.ForeColor = minorlabelColor;
            label21.ForeColor = minorlabelColor;
            label22.ForeColor = minorlabelColor;
            label23.ForeColor = minorlabelColor;

            label16.ForeColor = majorLabelColor;
            label13.ForeColor = majorLabelColor;
            label14.ForeColor = majorLabelColor;
            label15.ForeColor = majorLabelColor;
            label24.ForeColor = majorLabelColor;
            label25.ForeColor = majorLabelColor;

            textBoxBatteryPower.BackColor = txtBoxColor;
            textBoxDeviceName.BackColor = txtBoxColor;
            textBoxPressure.BackColor = txtBoxColor;
            textBoxBatteryPower.BackColor = txtBoxColor;
            textBoxPumpCurrent.BackColor = txtBoxColor;
            textBoxCollectHours.BackColor = txtBoxColor;
            textBoxCollectMinutes.BackColor = txtBoxColor;
            textBoxIntervalMinutes.BackColor = txtBoxColor;
            textBoxIntervalSeconds.BackColor = txtBoxColor;
            textBoxTemperature.BackColor = txtBoxColor;
            textBoxTimer.BackColor = txtBoxColor;
        }

        /// <summary>
        /// Creates a new <see cref="SerialPort"/> object and sets its properties.
        /// </summary>
        /// <remarks>
        /// Required for serial communication between CPU and LSA.
        /// </remarks>
        /// <returns><see cref="SerialPort"/> object </returns>
        private SerialPort SerialPortBegin()
        {
            SerialPort _serialPort = new SerialPort();
            _serialPort.PortName = comboBoxComPort.SelectedItem.ToString();
            _serialPort.BaudRate = 19200;

            //Enables serial communication between program and Arduino.
            _serialPort.DtrEnable = true;

            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }

            try
            {
                _serialPort.Open();
            }

            catch (Exception)
            {
                UsbRemoved();
            }

            return _serialPort;
        }

        /// <summary>
        /// Creates a new <see cref="DataPoint"/> object and checks if it meets the criteria to read LSA data.
        /// </summary>
        private void ReadAndDisplayData()
        {
            while (stopReading == false)
            {
                DataPoint newData = new DataPoint();

                //immediately reads data from LSA (00:00:00s)
                if (DataPoint.DataPtCount == 0)
                {
                    DisplayData(newData);
                }

                //reads data from LSA at end of max time
                if (_timeSinceStartTime >= _maxTime)
                {
                    _timer.Stop();
                    labelCheckmarkTimer.Show();
                    StopReading();
                    DisplayData(newData);
                }

                //reads data from LSA at user-specified interval
                if (_timeSinceStartTime - _lastReadTime >= _intervalTime)
                {
                    DisplayData(newData);
                }
            }
        }


        /// <summary>
        /// Displays all of the data retrieved from DataPoint class 
        /// </summary>
        /// 
        ///<param name="newDataPoint"> Contains all of the data from the most recent read of the LSA </param>
        private void DisplayData(DataPoint newDataPoint)
        {
            newDataPoint.TimeOfRead = _timeSinceStartTime.ToString(@"hh\:mm\:ss");
            newDataPoint.TimeOfRead = _timeSinceStartTime.ToString();
            newDataPoint.ReadIncomingData();

            if (DataPoint.UsbRemoved)
            {
                UsbRemoved();
            }

            if (DataPoint.NullData == false && DataPoint.UsbRemoved == false)
            {
                saveDataList.Add(newDataPoint);

                _lastReadTime = _timeSinceStartTime;

                if (chartPressure.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { ChartPressureUpdate(); });
                }

                if (chartTemperature.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { ChartTemperatureUpdate(); });
                }

                //When temperature reads -242, the temperature sensor is not connected
                if (newDataPoint.Temperature == "-242")
                {
                    textBoxTemperature.Text = "N/A";
                }

                else
                {
                    textBoxTemperature.Text = newDataPoint.Temperature;
                }

                textBoxPressure.Text = newDataPoint.Pressure;
                textBoxPumpCurrent.Text = newDataPoint.PumpCurrent;
                textBoxDeviceName.Text = newDataPoint.DeviceName;
                textBoxBatteryPower.Text = newDataPoint.BatteryLevel;
            }
        }

        /// <summary>
        /// Stops the data reading process.
        /// Resets the form to 'not reading' state
        /// </summary>
        private void StopReading()
        {
            AbortButtonState(false);
            RefreshButtonState(true);
            ComboBoxState(true);
            SetUpButtonState(true);
            SaveButtonState(true);
            OnButtonState(true);
            OffButtonState(true);

            readInProgress = false;
            stopReading = true;
            _timer.Stop();
        }

        /// <summary>
        /// Opens a new SaveData Form.
        /// </summary>
        private void SaveData()
        {
            FormSaveData a = new FormSaveData();

            a.StartPosition = FormStartPosition.Manual;
            a.Location = new Point(this.Left, this.Top + 30);
            a.ShowDialog();
        }

        /// <summary>
        /// Called when serial communication is attempted but fails - due to USB connection issues or removal.
        /// Stops reading data and sets form back to original state.
        /// </summary>
        private void UsbRemoved()
        {
            MessageBox.Show(ComPort + " Does Not Exist. Check USB Connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            StopReading();
            GetComPorts();
            ChartPressureClear();
            ChartTemperatureClear();
            StartButtonState(false);
            SetUpButtonState(false);
            OnButtonState(false);
            OffButtonState(false);
        }

        /// <summary>
        /// Goes through list of DataPoint objects and adds the pressure values to the chart.
        /// </summary>
        private void ChartPressureUpdate()
        {
            ChartPressureSetUp();

            this.chartPressure.ChartAreas[0].AxisY.IsLogarithmic = true;

            //entire chart is redrawn every time a new piece of data is added
            foreach (DataPoint value in saveDataList)
            {
                chartPressure.Series["Series1"].Points.AddXY(value.TimeOfRead.ToString(), value.Pressure);
            }

        }


        /// <summary>
        /// Specifies behavior and appearance of pressure chart.
        /// </summary>
        private void ChartPressureSetUp()
        {
            chartPressure.Series["Series1"].Points.Clear();
            chartPressure.ChartAreas[0].RecalculateAxesScale();
            chartPressure.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chartPressure.Series[0].IsValueShownAsLabel = false;

            chartPressure.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chartPressure.ChartAreas[0].AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartPressure.ChartAreas[0].AxisY.MinorGrid.Interval = chartPressure.ChartAreas[0].AxisY.MajorGrid.Interval;

            chartPressure.ChartAreas[0].AxisY.Title = "Pressure [mbar]";
            chartPressure.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10f);
        }

        /// <summary>
        /// Resets chart to blank window.
        /// </summary>
        private void ChartPressureClear()
        {
            chartPressure.Series["Series1"].Points.Clear();
        }

        /// <summary>
        /// Goes through list of DataPoint objects and adds the temperature values to the chart.
        /// </summary>
        public void ChartTemperatureUpdate()
        {
            ChartTemperatureSetUp();

            foreach (DataPoint value in saveDataList)
            {
                chartTemperature.Series["Series1"].Points.AddXY(value.TimeOfRead.ToString(), value.Temperature);
            }

        }

        /// <summary>
        /// Specifies behavior and appearance of temperature chart.
        /// </summary>
        public void ChartTemperatureSetUp()
        {
            chartTemperature.Series["Series1"].Points.Clear();
            chartTemperature.ChartAreas[0].RecalculateAxesScale();
            chartTemperature.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chartTemperature.Series[0].IsValueShownAsLabel = false;

            chartTemperature.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chartTemperature.ChartAreas[0].AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartTemperature.ChartAreas[0].AxisY.MinorGrid.Interval = chartTemperature.ChartAreas[0].AxisY.MajorGrid.Interval;

            chartTemperature.ChartAreas[0].AxisY.Title = "Temperature [°C]";
            chartTemperature.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10f);
        }

        /// <summary>
        /// Resets temperature chart to blank window.
        /// </summary>
        public void ChartTemperatureClear()
        {
            chartTemperature.Series["Series1"].Points.Clear();
        }

        /// <summary>
        /// Timer event  
        /// </summary>
        /// <remarks> 
        /// Called at specified inteval <see cref="TimerEventStart"/> 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            _timeSinceStartTime = DateTime.Now - _startTime;
            _timeSinceStartTime = new TimeSpan(_timeSinceStartTime.Hours,
                                               _timeSinceStartTime.Minutes,
                                               _timeSinceStartTime.Seconds);

            textBoxTimer.Text = _timeSinceStartTime.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Form closing argument</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (readInProgress)
            {
                FormAbort a = new FormAbort();
                a.StartPosition = FormStartPosition.Manual;
                a.Location = new Point(this.Left, this.Top + 30);

                a.ShowDialog();

                if (a.DialogResult == DialogResult.OK)
                {
                    StopReading();

                    if (a.AbortAndSave)
                    {
                        SaveData();
                    }

                    if (a.AbortWithoutSaving)
                    {
                        SaveButtonState(false);
                        Application.Exit();
                    }
                }

                if (a.DialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void StartButtonState(bool state)
        {
            if (state == true)
            {
                buttonStart.Enabled = true;
                buttonStart.BackColor = activateButtonColor;
            }

            if (state == false)
            {
                buttonStart.Enabled = false;
                buttonStart.BackColor = deactivateButtonColor;
            }
        }

        private void RefreshButtonState(bool state)
        {
            if (state == true)
            {
                buttonRefreshComPort.Enabled = true;
                buttonRefreshComPort.BackColor = activateButtonColor;
            }

            if (state == false)
            {
                buttonRefreshComPort.Enabled = false;
                buttonRefreshComPort.BackColor = deactivateButtonColor;
            }
        }

        private void SetUpButtonState(bool state)
        {
            if (state == true)
            {
                buttonSetUpTiming.Enabled = true;
                buttonSetUpTiming.BackColor = activateButtonColor;
            }

            if (state == false)
            {
                buttonSetUpTiming.Enabled = false;
                buttonSetUpTiming.BackColor = deactivateButtonColor;
            }
        }

        private void AbortButtonState(bool state)
        {
            if (state == true)
            {
                buttonAbort.Enabled = true;
                buttonAbort.BackColor = Color.Red;
            }

            if (state == false)
            {
                buttonAbort.Enabled = false;
                buttonAbort.BackColor = deactivateButtonColor;
            }
        }

        private void ComboBoxState(bool state)
        {
            if (state == true)
            {
                comboBoxComPort.Enabled = true;
            }

            if (state == false)
            {
                comboBoxComPort.Enabled = false;
            }
        }

        private void SaveButtonState(bool state)
        {
            if (state == true)
            {
                buttonSaveData.Enabled = true;
                buttonSaveData.BackColor = activateButtonColor;
            }

            if (state == false)
            {
                buttonSaveData.Enabled = false;
                buttonSaveData.BackColor = deactivateButtonColor;
            }
        }

        private void OnButtonState(bool state)
        {
            if (state == true)
            {
                buttonLsaOn.Enabled = true;
                buttonLsaOn.BackColor = Color.Red;
            }

            if (state == false)
            {
                buttonLsaOn.Enabled = false;
                buttonLsaOn.BackColor = deactivateButtonColor;
            }
        }

        private void OffButtonState(bool state)
        {
            if (state == true)
            {
                buttonLsaOff.Enabled = true;
                buttonLsaOff.BackColor = Color.Gray;
            }

            if (state == false)
            {
                buttonLsaOff.Enabled = false;
                buttonLsaOff.BackColor = deactivateButtonColor;
            }
        }

    }
}
