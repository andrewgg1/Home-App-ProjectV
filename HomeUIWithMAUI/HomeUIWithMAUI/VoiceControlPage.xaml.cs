namespace HomeUIWithMAUI
{
    public partial class VoiceControlPage : ContentPage
    {
        private VoiceCommand _currentEditingCommand;

        public VoiceControlPage()
        {
            InitializeComponent(); // Ensure this method exists
            CommandsListView.ItemsSource = CommandStore.Instance.Commands;
        }

        private void OnAddOrUpdateCommandClicked(object sender, EventArgs e)
        {
            string commandText = VoiceCommandEntry.Text;
            string responseText = VoiceResponseEntry.Text;

            if (string.IsNullOrWhiteSpace(commandText) || string.IsNullOrWhiteSpace(responseText))
            {
                DisplayAlert("Error", "Both command and response are required.", "OK");
                return;
            }

            if (_currentEditingCommand != null)
            {
                _currentEditingCommand.Command = commandText;
                _currentEditingCommand.Response = responseText;
                _currentEditingCommand = null;
            }
            else
            {
                CommandStore.Instance.Commands.Add(new VoiceCommand
                {
                    Command = commandText,
                    Response = responseText
                });
            }

            VoiceCommandEntry.Text = string.Empty;
            VoiceResponseEntry.Text = string.Empty;
        }

        private void OnEditCommandClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var command = (VoiceCommand)button.BindingContext;

            VoiceCommandEntry.Text = command.Command;
            VoiceResponseEntry.Text = command.Response;
            _currentEditingCommand = command;
        }

        private void OnDeleteCommandClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var command = (VoiceCommand)button.BindingContext;
            CommandStore.Instance.Commands.Remove(command);
        }
    }
}
