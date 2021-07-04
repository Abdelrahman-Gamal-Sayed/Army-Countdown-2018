using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CircularProgressBarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon m_notifyIcon;


        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            // initialise code here
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipText = "The app has been minimised. Click the tray icon to show.";
            m_notifyIcon.BalloonTipTitle = "Abdo Army Countdown";
            m_notifyIcon.Text = "Abdo Army Countdown";
            m_notifyIcon.Icon = new System.Drawing.Icon("TheAppIcon.ico");
            m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
            this.DataContext = new MainViewModel();

        //    WindowState= WindowState.Minimized;

        }
        void OnClose(object sender, CancelEventArgs args)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }

        private WindowState m_storedWindowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            }
            else
                m_storedWindowState = WindowState;
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }

        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }

        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }


        public MainWindow(int x)
        {
      
            
        }
        DateTime StartDate, EndDate;
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            //Double years, months, weeks, days, hours, miin, sec, temp;
            //EndDate= Convert.ToDateTime (cbxday_Copy.Text + "-" + cbxmonth_Copy.Text + "-" + cbxyears_Copy.Text) ;
            //years = Convert.ToDouble(cbxyears.Text);
            //if (years > DateTime.Now.Year)
            //    months = ((12 - DateTime.Now.Month) + Convert.ToDouble(cbxmonth.Text)) - (Convert.ToDouble(DateTime.Now.Day) / 30);
            //else
            //    months = (Convert.ToDouble(cbxmonth.Text) - DateTime.Now.Month) - (Convert.ToDouble(DateTime.Now.Day) / 30);

            //while (years - 1 > DateTime.Now.Year)
            //{
            //    months += 12;
            //    years--;
            //}
            
            //temp = DateTime.Now.Hour;
            //days = months * 30 - (temp / 24);
            //weeks = days / 7;
            //temp = DateTime.Now.Minute;
            //hours = days * 24 - (temp / 60);
            //temp = DateTime.Now.Second;
            //miin = hours * 60 - (temp / 60);
            //temp = DateTime.Now.Millisecond;
            //sec = miin * 60 - (temp / 60);
            //lblhours.Content = hours.ToString();
            //lbldays.Content = days.ToString();
            //lblmin.Content = miin.ToString();
            //lblmonth.Content = months.ToString();
            //lblsec.Content = sec.ToString();
            //lblweek.Content = weeks.ToString();

            //   StartDate=Convert.ToDateTime(cbxyears_Copy.Text+"/")

            EndDate = Convert.ToDateTime(cbxmonth_Copy.Text + "-" +  cbxday_Copy.Text + "-" + cbxyears_Copy.Text);
            var s = (    EndDate - DateTime.Now);
            lblhours.Content = s.TotalHours.ToString();
            lbldays.Content = s.TotalDays.ToString();
            lblmin.Content = s.TotalMinutes.ToString();
            lblmonth.Content = (s.TotalDays/30.5).ToString();
            lblsec.Content = s.TotalSeconds.ToString();
            lblweek.Content = (s.TotalDays / 7).ToString();
            StartDate = Convert.ToDateTime(cbxmonth.Text + "-" + cbxday.Text + "-" + cbxyears.Text);
            var d   = EndDate - StartDate;
            stvar.nesbaa = (100 * (d.TotalDays - s.TotalDays) / d.TotalDays);
          
            
            //   MessageBox.Show((100 * (360 - days) / 360).ToString());

            this.DataContext = new MainViewModel();
        }


        public void work ()
        {
           
            EndDate = Convert.ToDateTime(cbxmonth_Copy.Text + "-" + cbxday_Copy.Text + "-" + cbxyears_Copy.Text);
            var s = (EndDate - DateTime.Now);
            lblhours.Content = s.TotalHours.ToString();
            lbldays.Content = s.TotalDays.ToString();
            lblmin.Content = s.TotalMinutes.ToString();
            lblmonth.Content = (s.TotalDays / 30.5).ToString();
            lblsec.Content = s.TotalSeconds.ToString();
            lblweek.Content = (s.TotalDays / 7).ToString();
            StartDate = Convert.ToDateTime(cbxmonth.Text + "-" + cbxday.Text + "-" + cbxyears.Text);
            var d = EndDate - StartDate;
            stvar.nesbaa = (100 * (d.TotalDays - s.TotalDays) / d.TotalDays);


        }



    



        void oldfun()
        {
            Double years, months, weeks, days, hours, miin, sec, temp;
            years = Convert.ToDouble(cbxyears.Text);
            if (years > DateTime.Now.Year)
                months = ((12 - DateTime.Now.Month) + Convert.ToDouble(cbxmonth.Text)) - (Convert.ToDouble(DateTime.Now.Day) / 30);
            else
                months = (Convert.ToDouble(cbxmonth.Text) - DateTime.Now.Month) - (Convert.ToDouble(DateTime.Now.Day) / 30);

            while (years - 1 > DateTime.Now.Year)
            {
                months += 12;
                years--;
            }
            temp = DateTime.Now.Hour;
            days = months * 30 - (temp / 24);
            weeks = days / 7;
            temp = DateTime.Now.Minute;
            hours = days * 24 - (temp / 60);
            temp = DateTime.Now.Second;
            miin = hours * 60 - (temp / 60);
            temp = DateTime.Now.Millisecond;
            sec = miin * 60 - (temp / 60);
            lblhours.Content = hours.ToString();
            lbldays.Content = days.ToString();
            lblmin.Content = miin.ToString();
            lblmonth.Content = months.ToString();
            lblsec.Content = sec.ToString();
            lblweek.Content = weeks.ToString();
            stvar.nesbaa = (100 * (360 - days) / 360);
            //   MessageBox.Show((100 * (360 - days) / 360).ToString());

        }
    }
}
