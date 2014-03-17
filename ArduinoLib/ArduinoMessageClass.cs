using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    class ArduinoMessager
    {
        private bool trainComming;
        private bool lights;
        private bool barrier;

        public bool TrainComming(string arduinoMessage)
        {
            if (arduinoMessage == "TRAINPRESENT")
            {
                return true;
            }
            else if(arduinoMessage == "TRAINABSENT")
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool Lights(string arduinoMessage)
        {
            if (arduinoMessage == "LIGHTON")
            {
                return true;
            }

            else if (arduinoMessage == "LIGHTOFF")
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool Barrier(string arduinoMessage)
        {
            if (arduinoMessage == "BARRIERDOWN")
            {
                return true;
            }

            else if (arduinoMessage == "BARRIERUP")
            {
                return false;
            }

            else
            {
                return false;
            }
        }
    }
}

