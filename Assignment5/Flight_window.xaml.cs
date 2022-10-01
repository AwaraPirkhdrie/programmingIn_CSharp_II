using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for Flight_window.xaml
    /// </summary>
    public partial class Flight_window : Window
    {
        private string FlightId = "";
        private DateTime Flight_Start = DateTime.Now;
        private DateTime FlightLand = DateTime.Now;
        private DateTime Heading_Change = DateTime.Now;
        private int Heading = 0;
        private bool Landed = false;
        public event EventHandler<StartFlightInfo> RaiseTakeoffEvent;
        public event EventHandler<ChangeRouteEventInfo> RaiseHeadingEvent;
        public event EventHandler<CountryInfo> RaiseLandEvent;
        

        /// <summary>
        /// Contructor of the flight window class
        /// </summary>
        /// <param name="flight_code"></param>
        public Flight_window(string flight_code)
        {
            InitializeComponent();
            this.Title = "Flight " + flight_code;
            Btn_Land.IsEnabled = false;
            Combo_Headings.IsEnabled = false;
            Combo_Headings.Items.Insert(0, "0 deg");
            Combo_Headings.Items.Insert(1, "30 deg");
            Combo_Headings.Items.Insert(2, "60 deg");
            Combo_Headings.Items.Insert(3, "90 deg");
            Combo_Headings.Items.Insert(4, "120 deg");
            Combo_Headings.Items.Insert(5, "150 deg");
            Combo_Headings.Items.Insert(6, "180 deg");
            Combo_Headings.Items.Insert(7, "210 deg");
            Combo_Headings.Items.Insert(8, "240 deg");
            Combo_Headings.Items.Insert(9, "270 deg");
            Combo_Headings.Items.Insert(10, "300 deg");
            Combo_Headings.Items.Insert(11, "330 deg");
            string image = System.IO.Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "img";
            Random random = new Random();
            string[] imagePaths = System.IO.Directory.GetFiles(image, "*.jpg");
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[random.Next(imagePaths.Length)]));
            Image_fpl.Source = bitmapImage;
        }
        /// <summary>
        /// Set Id
        /// </summary>
        /// <param name="flightId"></param>
        public void SetFlight_Id(string flightId)
        {
            FlightId = flightId;
        }
        /// <summary>
        /// Set heading change time
        /// </summary>
        /// <param name="heading_time"></param>
        public void SetHeadingTime(DateTime heading_time)
        {
            Heading_Change = heading_time;
        }
        /// <summary>
        /// Set Takeoff time
        /// </summary>
        /// <param name="takeoff_time"></param>
        public void SetFlightTakeOff(DateTime takeoff_time)
        {
            Flight_Start = takeoff_time;
        }
        /// <summary>
        /// Set Landing time
        /// </summary>
        /// <param name="land_time"></param>
        public void SetFlightLand(DateTime land_time)
        {
            FlightLand = land_time;
        }
        /// <summary>
        /// Set heading direction
        /// </summary>
        /// <param name="direction"></param>
        public void Set_Heading(int direction)
        {
            Heading = direction;
        }
      
        /// <summary>
        /// Flight take off button logic
        /// Updates EventArg for Takeoff Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            SetFlightTakeOff(DateTime.Now);                      
            StartFlightInfo TakeOffInfo = new StartFlightInfo();
            //lbStart.Visible = false;
            TakeOffInfo.FlightId = this.FlightId;
            TakeOffInfo.TimeOfCommand = this.Flight_Start;
            TakeOffInfo.CommandInfo = "Started";
            if (MessageBox.Show("Fligt code: [ " + FlightId + " ] started?",
                "Started", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OnStartEvent(TakeOffInfo);
                this.BtnStart.IsEnabled = false;
                Btn_Land.IsEnabled = true;
                Combo_Headings.IsEnabled = true;
               
            }
            else
            {
                // Do not close the window  

            }
            
        }


        protected virtual void OnStartEvent(StartFlightInfo e)
        {            
            EventHandler<StartFlightInfo> handler = RaiseTakeoffEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Flight Land logic
        /// Updates EventArg for Land Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLandClick(object sender, RoutedEventArgs e)
        {
            SetFlightLand(DateTime.Now);
            CountryInfo LandInfo = new CountryInfo();
            LandInfo.FlightId = this.FlightId;
            LandInfo.TimeOfCommand = this.Flight_Start;
            LandInfo.CommandInfo = "Landed";
            if (MessageBox.Show("Fligt code: [ " + FlightId + " ] Landed?",
               "Landed", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OnLandEvent(LandInfo);
                Landed = true;
                this.Close();
            }
            else
            {
                // Do not close the window  
            }           
        }
        protected virtual void OnLandEvent(CountryInfo e)
        {
            EventHandler<CountryInfo> handler = RaiseLandEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Flight Heading change logic
        /// Updates EventArg for Heading change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboHeadingChanged(object sender, SelectionChangedEventArgs e)
        {
            int i_heading = Combo_Headings.SelectedIndex;
            if (i_heading < 0)
            {
                return;
            }
            int heading_deg = i_heading * 30;
            SetHeadingTime(DateTime.Now);
            ChangeRouteEventInfo HeadingInfo = new ChangeRouteEventInfo();
            HeadingInfo.FlightId = this.FlightId;
            HeadingInfo.TimeOfCommand = this.Heading_Change;
            HeadingInfo.heading = heading_deg;
            HeadingInfo.Command_Info = "Now heading " + heading_deg.ToString() + " deg";      
            OnHeadingEvent(HeadingInfo);
        }
        protected virtual void OnHeadingEvent(ChangeRouteEventInfo e)
        {
            EventHandler<ChangeRouteEventInfo> handler = RaiseHeadingEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Handles logic for window closing
        /// prevents closing if not landed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((!Landed)&(this.BtnStart.IsEnabled == false))
            {
                MessageBox.Show("Cannot close flight which has not landed."); 
                e.Cancel = true;
            }
        }

 
    }
}
