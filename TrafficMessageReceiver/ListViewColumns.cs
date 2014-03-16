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
                column.Text = "Time";
                column.Width = 100;
                return column;
            }

            private set
            {
                
            }
        }

        public static ColumnHeader HeaderType
        {
            get
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = "Type";
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
                return new[] { HeaderID, HeaderType, HeaderDate, HeaderTime, HeaderJunctionID, HeaderLightID };
            }
        }

        public static ColumnHeader[] Speedings
        {
            get
            {
                return new[] { HeaderID, HeaderDate, HeaderTime, HeaderCarID, HeaderCarSpeed };
            }
        }

        public static ColumnHeader[] RedLight
        {
            get
            {
                return new[] { HeaderID, HeaderDate, HeaderTime, HeaderCarID, HeaderLightID };
            }
        }

        public static ColumnHeader[] Accident
        {
            get
            {
                return new[] { HeaderID, HeaderDate, HeaderTime, HeaderJunctionID };
            }
        }
    }
}
