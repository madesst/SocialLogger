using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace SocialLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SocialLoggerDataContext _context = new SocialLoggerDataContext();
        public ObservableCollection<LogEntryDTO> LogEntriesDTOs { set; get; }

        public MainWindow()
        {
            LogEntriesDTOs = new ObservableCollection<LogEntryDTO>();
            LogEntriesDTOs.InsertRange(_context.LogEntries.Select(q => new LogEntryDTO(q)));

            InitializeComponent();

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var random = new Random();

            LogEntriesDTOs.Add(new LogEntryDTO(new LogEntry()
            {
                StartAt = DateTime.Now.AddDays(random.Next(-6, -5)),
                EndAt = DateTime.Now.AddDays(random.Next(-4, -1)).AddMinutes(random.Next(-59, - 1)).AddSeconds(random.Next(-59, -1))
            }));
        }
    }
    public class LogEntryDTO : LogEntry
    {
        public TimeSpan Duration { set; get; }

        public LogEntryDTO(LogEntry logEntry)
        {
            Id = logEntry.Id;
            StartAt = logEntry.StartAt;
            EndAt = logEntry.EndAt;

            var diff = logEntry.EndAt - logEntry.StartAt;
            if (logEntry.EndAt != null && diff != null)
            {
                Duration = diff.GetValueOrDefault(new TimeSpan(0, 0, 0, 0));
            }
        }
    }

    public class ObservableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>
    {
        public void InsertRange(IEnumerable<T> items)
        {
            CheckReentrancy();
            foreach (var item in items)
                Items.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }


}
