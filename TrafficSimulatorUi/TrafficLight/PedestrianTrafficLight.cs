using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficSimulatorUi
{
    /// <summary>
    /// Class representing a traffic light for pedestrians.
    /// 
    /// A pedestrian traffic ligh has 4 signal states: IDLE, CLEAR_CROSSING, STOP and GO.
    /// The states are shown by 2 lights which have the colors red and green.
    /// 
    /// 
    /// The signal states and their corresponding light display:
    /// 
    /// State            Signal            Meaning to traffic
    /// -----            ---------------   ----------------- 
    /// IDLE             red, blinking     The traffic light is disabled. Cross with caution.
    /// CLEAR_CROSSING   green, blinking   The red light is about to appear. Clear the crossing. 
    /// STOP             red               Stop. Do not cross. Wait for the green light to appear.
    /// GO               green             You have right of way.
    /// 
    /// </summary>
    public class PedestrianTrafficLight : TrafficLight
    {
        /// <summary>
        /// Width of traffic light. 
        /// </summary>
        private const int width = 9;

        /// <summary>
        /// height of traffic light.
        /// </summary>
        private const int height = 16;

        /// <summary>
        /// Blink interval when in idle state
        /// </summary>
        private const int blinkIntervalWhenInIdleState = 1000;

        /// <summary>
        /// Blink interval when in stop state.
        /// </summary>
        private const int blinkIntervalWhenInClearCrossingState = 500;

        /// <summary>
        /// The coordinates for drawing the red light 
        /// </summary>
        private Point redLightLocation;

        /// <summary>
        /// The coordinates for drawing the green light 
        /// </summary>
        private Point greenLightLocation;

        /// <summary>
        /// Timer used to blink light on and off for even measures of time
        /// when in SignalState.CLEAR_CROSSING or SignalState.IDLE state.
        /// </summary>
        private Timer blinkTimer;

        /// <summary>
        /// When blinking and true then the light should be on, else off.
        /// </summary>
        private bool blinkLightOn;

        /// The number of times the light blinked when in SignalState.CLEAR_CROSSING state.
        private int blinkCounter;

        /// <summary>
        /// The number of times the light will blink before going to wait state.
        /// </summary>
        private const int timesToBlinkBetweenGoAndStopState = 5;

        /// <summary>
        /// Creates a new pedestrian traffic light.
        /// </summary>
        /// <param name="location">The location for the traffic light (upper left corner)</param>
        /// <param name="orientation">The orientation to use (horizontal or vertical)</param>
        public PedestrianTrafficLight(Point location, Orientation orientation)
            : base(location, width, height, orientation)
        {
            SetLightLocations(orientation);

            blinkTimer = new Timer();
            blinkTimer.Tick += new EventHandler(blinkTimer_Tick);
            blinkTimer.Interval = blinkIntervalWhenInIdleState;
            blinkLightOn = true;
            blinkTimer.Start();
        }

        /// <summary>
        /// Sets the position of the lights.
        /// </summary>
        private void SetLightLocations(Orientation orientation)
        {
            Point topLightLocation = Location + new Size(2, 2);
            Point bottomLightLocation;

            if (orientation == Orientation.HORIZONTAL
                || orientation == Orientation.HORIZONTAL_AND_FLIP)
            {
                bottomLightLocation = Location + new Size(2, 9);
            }
            else
            {
                bottomLightLocation = Location + new Size(9, 2);
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
            greenLightLocation = bottomLightLocation;
        }

        /// <summary>
        /// Handles the timer event to make blinking of the lights possible.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void blinkTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            blinkLightOn = !blinkLightOn;
            if (State == SignalState.CLEAR_CROSSING && !blinkLightOn)
            {
                blinkCounter++;
                if (blinkCounter == timesToBlinkBetweenGoAndStopState)
                {
                    blinkTimer.Stop();
                    State = SignalState.STOP;
                }
            }
        }

        /// <summary>
        /// Switches the traffic light to a new state.
        /// 
        /// When switched from SignalState.GO to SignalState.STOP 
        /// the state goes to SignalState.CLEAR_CROSSING for a few seconds 
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
            blinkTimer.Stop();
            if (newState == SignalState.STOP && State == SignalState.GO)
            {
                State = SignalState.CLEAR_CROSSING;
                blinkTimer.Interval = blinkIntervalWhenInClearCrossingState;
                blinkLightOn = false;
                blinkCounter = 0;
                blinkTimer.Start();
            }
            else
            {
                State = newState;
                if (newState == SignalState.IDLE)
                {
                    blinkTimer.Interval = blinkIntervalWhenInIdleState;
                    blinkLightOn = false;
                    blinkTimer.Start();
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
            if (State == SignalState.STOP
                || (State == SignalState.IDLE && blinkLightOn))
            {
                drawingSurface.DrawImageUnscaled(Properties.Resources.RedLightImage, redLightLocation);
            }
            else if (State == SignalState.GO
                || (State == SignalState.CLEAR_CROSSING && blinkLightOn))
            {
                drawingSurface.DrawImageUnscaled(Properties.Resources.GreenLightImage, greenLightLocation);
            }
        }
    }
}
