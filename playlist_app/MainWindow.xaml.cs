using System.Windows;

namespace playlist_app
{
    public partial class MainWindow : Window
    {
        private Playlist playlist = new Playlist();

        public MainWindow()
        {
            InitializeComponent();
            UpdateCurrentTrack();
        }

        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            string trackName = TrackNameTextBox.Text;
            if (!string.IsNullOrEmpty(trackName))
            {
                playlist.AddTrack(trackName);
                TrackListBox.Items.Add(trackName);
                TrackNameTextBox.Clear();
                UpdateCurrentTrack();
            }
        }

        private void PrevTrack_Click(object sender, RoutedEventArgs e)
        {
            playlist.MovePrev();
            UpdateCurrentTrack();
        }

        private void NextTrack_Click(object sender, RoutedEventArgs e)
        {
            playlist.MoveNext();
            UpdateCurrentTrack();
        }

        private void DeleteTrack_Click(object sender, RoutedEventArgs e)
        {
            string currentTrack = playlist.GetCurrentTrack();
            if (currentTrack != null)
            {
                playlist.RemoveCurrentTrack();
                TrackListBox.Items.Remove(currentTrack);

                
                UpdateCurrentTrack();
            }
        }

        private void UpdateCurrentTrack()
        {
            string currentTrack = playlist.GetCurrentTrack();
            CurrentTrackTextBlock.Text = currentTrack ?? "No Track";

            TrackListBox.SelectedItem = currentTrack;
        }
    }
}
