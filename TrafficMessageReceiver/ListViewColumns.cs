using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrafficMessageReceiver
{
    class ListViewColumns
    {

        public static ColumnHeader HeaderID
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "ID";
                column.Width = 60;
                return column;
            }

            private set
            {

            }
        }

        public static ColumnHeader HeaderDate
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Datum";
                column.Width = 100;
                return column;
            }

            private set
            {

            }
        }

        public static ColumnHeader HeaderTime
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Tijd";
                column.Width = 100;
                return column;
            }

            private set
            {
                
            }
        }

        public static ColumnHeader HeaderCarID
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Kenteken";
                column.Width = 100;
                return column;
            }
        }

        public static ColumnHeader HeaderCarSpeed
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Snelheid";
                column.Width = 60;
                return column;
            }
        }

        public static ColumnHeader HeaderJunctionID
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Kruispunt ID";
                column.Width = 100;
                return column;
            }
        }

        public static ColumnHeader HeaderLightID
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Licht ID";
                column.Width = 100;
                return column;
            }
        }

        public static ColumnHeader[] Overview
        {
            get
            {
                return new[] { HeaderDate, HeaderTime, HeaderJunctionID, HeaderLightID };
            }
        }

        public static ColumnHeader[] Speedings
        {
            get
            {
                return new[] { HeaderDate, HeaderTime, HeaderCarID, HeaderCarSpeed };
            }
        }

        public static ColumnHeader[] RedLight
        {
            get
            {
                return new[] { HeaderDate, HeaderTime, HeaderCarID, HeaderLightID };
            }
        }

        public static ColumnHeader[] Accident
        {
            get
            {
                return new[] { HeaderDate, HeaderTime, HeaderJunctionID };
            }
        }

        public static ListViewGroup SpeedingGroup
        {
            get
            {
                return new ListViewGroup("Snelheidsovertredingen");
            }
        }

        public static ListViewGroup RedLightGroup
        {
            get
            {
                return new ListViewGroup("Rood licht overtredingen");
            }
        }

        public static ListViewGroup AccidentGroup
        {
            get
            {
                return new ListViewGroup("Ongelukken");
            }
        }
    }
}
