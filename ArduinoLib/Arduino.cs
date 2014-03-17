using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ArduinoLib
{
    public class ArduinoLib
    {
        private SerialPort serialPort;

        /// <summary>
        /// Arduino serial port voorbereiden.
        /// </summary>
        /// <param name="comport">COM poort van de Arduino.</param>
        /// <param name="baudrate">Baudrate van de verbinding met de Arduino.</param>
        public ArduinoLib(String comport, int baudrate)
        {
            serialPort = new SerialPort(comport);
            serialPort.BaudRate = baudrate;
            serialPort.DataReceived += this.DataReceivedHandler;
        }

        /// <summary>
        /// Serial port openen.
        /// </summary>
        public void Open()
        {
            try
            {
                serialPort.Open();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Data naar de Arduino verzenden. Opent de Serial port indien dit nog niet is gebeurt.
        /// </summary>
        /// <param name="data">Byte om te verzenden.</param>
        public void Send(byte data)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    Open();
                }
                catch (Exception exc)
                {
                    throw exc;
                }

            }
        }

        /// <summary>
        /// Event voor de ontvangen data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort) sender;
            int received = sp.ReadByte();
        }

        /// <summary>
        /// Serial port sluiten.
        /// </summary>
        public void Close()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception exc) { }
        }

        
    }
}
