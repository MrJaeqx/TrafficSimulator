using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Class representing a traffic light for drivers on the road.
    /// 
    /// A driver traffic ligh has 4 signal states: IDLE, CLEAR_CROSSING, STOP and GO.
    /// The states are shown by 3 lights which have the colors red, yellow and green.
    /// 
    /// 
    /// The signal states and their corresponding light display:
    /// 
    /// State            Signal             Meaning to traffic
    /// -----            ---------------    ----------------- 
    /// IDLE             yellow, blinking   The traffic light is disabled. Cross with caution.
    /// CLEAR_CROSSING   yellow             The red light is about to appear. Clear the crossing. 
    /// STOP             red                Stop. Do not cross. Wait for the green light to appear.
    /// GO               green              You have right of way.
    /// 
    /// </summary>
    public class DriverTrafficLight : TrafficLight
    {
        /// <summary>
        /// Width of traffic light. 
        /// </summary>
        private const int width = 9;

        /// <summary>
        /// height of traffic light.
        /// </summary>
        private const int height = 23;

        /// <summary>
        /// Blink interval when in idle state
        /// </summary>
        private const int blinkIntervalWhenInIdleState = 1000;

        /// <summary>
        /// Duration of the SignalState.CLEAR_CROSSING state (msec).
        /// </summary>
        private const int clearCrossingStateDuration = 2000;

        /// <summary>
        /// The coordinates for drawing the red light 
        /// </summary>
        private Point redLightLocation;

        /// <summary>
        /// The coordinates for drawing the yellow light 
        /// </summary>
        private Point yellowLightLocation;

        /// <summary>
        /// The coordinates for drawing the green light 
        /// </summary>
        private Point greenLightLocation;

        /// <summary>
        /// Timer used to blink light on and off when in SignalState.IDLE state
        /// and to light the yellow light for the duration of the SignalState.CLEAR_CROSSING
        /// state.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// When in SignalState.IDLE state used to blinking the yellow light.
        /// </summary>
        private bool blinkIdleLightOn;

        /// <summary>
        /// Creates a new driver traffic light.
        /// </summary>
        /// <param name="location">The location for the traffic light (upper left corner)</param>
        /// <param name="orientation">The orientation to use (horizontal or vertical)</param>
        public DriverTrafficLight(Point location, Orientation orientation)
            : base(location, width, height, orientation)
        {
            SetLightLocations(orientation);

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = blinkIntervalWhenInIdleState;
            blinkIdleLightOn = true;
            timer.Start();
        }

        /// <summary>
        /// Sets the position of the lights.
        /// </summary>
        private void SetLightLocations(Orientation orientation)
        {
            Point topLightLocation = Location + new Size(2, 2);
            Point centerLightLocation;
            Point bottomLightLocation;

            if (orientation == Orientation.HORIZONTAL
                || orientation == Orientation.HORIZONTAL_AND_FLIP)
            {
                centerLightLocation = Location + new Size(2, 9);
                bottomLightLocation = Location + new Size(2, 16);
            }
            else
            {
                centerLightLocation = Location + new Size(9, 2);
                bottomLightLocation = Location + new Size(16, 2);
            }

            if (orientation == Orientation.HORIZONTAL_AND_FLIP
                || orientation == Orientation.VERTICAL_AND_FLIP)
            {
                Point temp;
                temp = topLightLocation;
                topLightLocation = bottomLightLocation;
                bottomLightLocation = temp;
            }

            redLightLocation = topLightLocation;
            yellowLightLocation = centerLightLocation;
            greenLightLocation = bottomLightLocation;
        }

        /// <summary>
        /// Handles the timer event.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void timer_Tick(Object myObject, EventArgs myEventArgs)
        {
            if (State == SignalState.CLEAR_CROSSING)
            {
                timer.Stop();
                State = SignalState.STOP;
            }
            else if (State == SignalState.IDLE)
            {
                blinkIdleLightOn = !blinkIdleLightOn;
            }
        }

        /// <summary>
        /// Switches the traffic light to a new state.
        /// 
        /// When switched from SignalState.GO to SignalState.STOP 
        /// the state goes to SignalState.CLEAR_CROSSING for some time 
        /// before entering the SignalState.STOP state.
        /// </summary>
        /// <param name="color">The state to switch to. 
        /// Valid states are SignalState.IDLE, SignalState.STOP, SignalState.GO. </param>
        public override void SwitchTo(SignalState newState)
        {
            // Exception situation 1: The parameter is not valid
            if (newState != SignalState.IDLE
                && newState != SignalState.STOP
                && newState != SignalState.GO)
            {
                throw new ArgumentException("New state must be SignalState.IDLE, SignalState.WAIT or SignalState.GO.", "newState");
            }

            // Exception situation 1: The new state is not valid -> skip
            if (newState == State
                || (newState == SignalState.STOP && State == SignalState.CLEAR_CROSSING))
            {
                return;
            }

            // Handle the state transition
            timer.Stop();
            if (newState == SignalState.STOP && State == SignalState.GO)
            {
                State = SignalState.CLEAR_CROSSING;
                timer.Interval = clearCrossingStateDuration;
                timer.Start();
            }
            else
            {
                State = newState;
                if (newState == SignalState.IDLE)
                {
                    timer.Interval = blinkIntervalWhenInIdleState;
                    blinkIdleLightOn = false;
                    timer.Start();
                }
            }
        }

        /// <summary>
        /// Draws the traffic light to the drawing surface.
        /// </summary>
        /// <param name="drawingSurface">The drawing surface to draw onto.</param>
        public override void DrawTo(Graphics drawingSurface)
        {
            drawingSurface.FillRectangle(Brushes.Black, BoundingBox);
            if (State == SignalState.STOP)
            {
                drawingSurface.DrawImageUnscaled(Properties.Resources.RedLightImage, redLightLocation);
            }
            else if (State == SignalState.CLEAR_CROSSING
               || (State == SignalState.IDLE && blinkIdleLightOn))
            {
                drawingSurface.DrawImageUnscaled(Properties.Resources.YellowLightImage, yellowLightLocation);
            }
            else if (State == SignalState.GO)
            {
                drawingSurface.DrawImageUnscaled(Properties.Resources.GreenLightImage, greenLightLocation);
            }
        }
    }
}
