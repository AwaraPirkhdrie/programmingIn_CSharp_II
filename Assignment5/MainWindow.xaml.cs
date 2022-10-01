using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public delegate void FlightCommandEventHandler<TEventArgs>(object sender, TEventArgs e);    
    public partial class MainWindow : Window
    {
        private AirplanesCounter FPLCounter = new AirplanesCounter();

        /// <summary>
        /// Main Window GUI initialization
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            LblNumberOfFlights.Content = "Number of active flights: " + FPLCounter.ReturnFlightcount().ToString();
        }

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendclick(object sender, RoutedEventArgs e)
        {
            
            string Flight_Code = this.TextBoxFlightNumber.Text.Trim();
            if (Flight_Code.Length == 0)
            {
                MessageBox.Show("Flight Code should be given");
                return;
            }
            FlightLogEntry Log = new FlightLogEntry();
            Log.Flight_Code = Flight_Code;
            Log.Status = "Sent to runway";
            Log.Time = DateTime.Now;
            this.List_View_Flights.Items.Add(Log);
            Flight_window new_flight = new Flight_window(Flight_Code);
            new_flight.SetFlight_Id(Flight_Code);
            new_flight.RaiseTakeoffEvent += FPLCounter.CountTakeoffEvent;
            new_flight.RaiseLandEvent += FPLCounter.CountLandEvent;
            new_flight.RaiseTakeoffEvent += HandleTakeoffEvent;
            new_flight.RaiseHeadingEvent += HandleHeadingEvent;
            new_flight.RaiseLandEvent += HandleLandEvent;   
            new_flight.Show();
            
        }
        /// <summary>
        /// Take off event handler (subscriber)
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleTakeoffEvent(object sender, StartFlightInfo e)
        {
            FlightLogEntry Log = new FlightLogEntry();
            Log.Flight_Code = e.FlightId;
            Log.Status = e.CommandInfo;
            Log.Time = e.TimeOfCommand;
            this.List_View_Flights.Items.Add(Log);
            LblNumberOfFlights.Content = "Number of airborne flights: " + FPLCounter.ReturnFlightcount().ToString();
        }
        /// <summary>
        /// Heading change event handler
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleHeadingEvent(object sender, ChangeRouteEventInfo e)
        {
            FlightLogEntry Log = new FlightLogEntry();
            Log.Flight_Code = e.FlightId;
            Log.Status = e.Command_Info;
            Log.Time = e.TimeOfCommand;
            this.List_View_Flights.Items.Add(Log);
        }
        /// <summary>
        /// Land Event handler
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleLandEvent(object sender, CountryInfo e)
        {
            FlightLogEntry Log = new FlightLogEntry();
            Log.Flight_Code = e.FlightId;
            Log.Status = e.CommandInfo;
            Log.Time = e.TimeOfCommand;
            this.List_View_Flights.Items.Add(Log);
            LblNumberOfFlights.Content = "Number of airborne flights: " + FPLCounter.ReturnFlightcount().ToString();
        }
        /// <summary>
        /// Text input handler from user via GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Str_Len = this.TextBoxFlightNumber.Text.Length;
            if (Str_Len > 15)
            {
                MessageBox.Show("Flight Code should not be longer than 15 symbols");
                this.TextBoxFlightNumber.Text = this.TextBoxFlightNumber.Text.Remove(Str_Len - 1);
            }
        }
        /// <summary>
        /// Mouse down handler
        /// removes the help text from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDownOnFlightCode(object sender, MouseButtonEventArgs e)
        {
            this.TextBoxFlightNumber.Text = "";
        }
        /// <summary>
        /// Textbox focus handler
        /// removes help text from textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFlightCodeFocus(object sender, RoutedEventArgs e)
        {
            this.TextBoxFlightNumber.Text = "";
        }

        /// <summary>
        /// Handles starting flight
        /// adds a log entry
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightStartEventHandler<TEventArgs>(object sender, StartFlightInfo e)
        {
            this.List_View_Flights.Items.Add(e.FlightId);
        }
       
        /// <summary>
        /// On Tower window closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowTowerClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (FPLCounter.ReturnFlightcount() > 0)
            {
                MessageBox.Show("Cannot close the tower until all planes have landed.");
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Handles Tower windiw closing
        /// exits application if no flights up in the air
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowTowerClosed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this system?",
                "Close", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Close the window  
                this.Close();   
            }
            else
            {
                // Do not close the window  
            }
        }

        private void List_View_Flights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    
    }
}
