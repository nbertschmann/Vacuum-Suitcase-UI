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
    public class DataPoint
    {
        private string pressure = "";
        private string temperature = "";
        private string batteryLevel = "";
        private string pumpCurrent = "";
        private string deviceName = "";

        /// <summary>
        /// Returns the time that a given data point is read in relation to the first read.
        /// </summary>
        private string timeOfRead = "";

        /// <summary>
        /// Set to true when the data read by <see cref="ReadIncomingData"/> is null or not in the correct format.
        /// </summary>
        private static bool nullData = false;

        /// <summary>
        /// Set to true when <see cref="SerialPort"/> cannot be opened.
        /// </summary>
        private static bool usbRemoved = false;

        /// <summary>
        /// Returns number of data points created up to date.
        /// </summary>
        private static int dataPtCount = 0;

        Form1 frm = (Form1)Application.OpenForms["Form1"];

        public static bool UsbRemoved
        {
            get { return usbRemoved; }
        }

      
        public static bool NullData
        {
            get { return nullData; }
        }

        public string Pressure
        {
            get { return pressure; }
        }

        public string Temperature
        {
            get { return temperature; }
        }

        public string BatteryLevel
        {
            get { return batteryLevel; }
        }

        public string PumpCurrent
        {
            get { return pumpCurrent; }
        }

        public string DeviceName
        {
            get { return deviceName; }
        }

        public string TimeOfRead
        {
            get { return timeOfRead; }
            set { timeOfRead = value; }
        }

        
        public static int DataPtCount
        {
            get { return dataPtCount; }
            set { dataPtCount = value; }
        }

        public DataPoint()
        {
            nullData = false;
            usbRemoved = false;

        }

        /// <summary>
        /// Initializes <see cref="SerialPort"/> object for data reading.
        /// </summary>
        /// <returns>
        ///  <see cref="SerialPort"/> object.
        /// </returns>
        private SerialPort SerialPortBegin()
        {
            SerialPort _serialPort = new SerialPort();
            _serialPort.PortName = frm.ComPort;
            _serialPort.BaudRate = 19200;
            _serialPort.DtrEnable = true;

            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }

            //if the serial port doesn't open, there is a connection issue with the USB
            try
            {
                _serialPort.Open();
            }

            catch (Exception)
            {
                usbRemoved = true;
            }

            return _serialPort;
        }

        /// <summary>
        /// Initializes communication with Arduino on the LSA and receives a string of data. 
        /// </summary>
        public void ReadIncomingData()
        {

            SerialPort _serialPort = SerialPortBegin();

            if (_serialPort.IsOpen)
            {

                //write a char to Arduino which tells it to transmit data
                _serialPort.Write("A");
                Thread.Sleep(500);

                try
                {
                    string dataReadString = _serialPort.ReadExisting();
                    string[] currentDataArray = dataReadString.Split(',');

                    //check if the correct string is received
                    if (currentDataArray.Length == 6)
                    {
                        dataPtCount++;

                        deviceName = currentDataArray[0];
                        pumpCurrent = currentDataArray[1];
                        pressure = currentDataArray[2];
                        temperature = currentDataArray[3];
                        batteryLevel = currentDataArray[4];
                    }

                    else
                    {
                        nullData = true;
                    }
                }

                //if USB is removed during read, flag is set
                catch (Exception)
                {
                    usbRemoved = true;
                }

                _serialPort.Close();
            }
        }
    }
}

