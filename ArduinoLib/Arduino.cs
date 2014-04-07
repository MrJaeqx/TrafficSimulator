using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoLib
{
    public class Arduino
    {
        /// <summary>
        /// Serial poort voor communicatie met de Arduino.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Event voor als er een trein aan komt.
        /// </summary>
        public event EventHandler trainIncomingEvent;

        /// <summary>
        /// Event voor als er een trein is gepasseerd.
        /// </summary>
        public event EventHandler trainPassedEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comport">COM poort van de Arduino</param>
        /// <param name="baudrate">Baudrate voor de communticatie</param>
        public Arduino(string comport, int baudrate)
        {
            serialPort = new SerialPort(comport, baudrate);

            // Eventhandler aankoppelen voor ontvangen data.
            serialPort.DataReceived += serialPort_DataReceived;
        }

        /// <summary>
        /// Communicatie met de Arduino openen.
        /// </summary>
        public void Open()
        {
            serialPort.Open();
        }

        /// <summary>
        /// Communicatie met de Arduino sluiten.
        /// </summary>
        public void Close()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Event voor ontvangen data van de Arduino
        /// </summary>
        /// <param name="sender">Serial poort waarvan de data afkomstig is.</param>
        /// <param name="e">Niet gebruikt.</param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            int received = sp.ReadByte();
            Debug.WriteLine(received.ToString());

            // TODO Check de berichten
            // Aankomende trein
            if (received == 49)
            {
                trainIncomingEvent.Invoke(null, null);
            }
            // Passerende trein
            else if (received == 50)
            {
                trainPassedEvent.Invoke(null, null);
            }
        }
    }
}
