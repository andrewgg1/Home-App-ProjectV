using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeUIWithMAUI
{
    public class CommandStore
    {
        private static CommandStore _instance;
        public static CommandStore Instance => _instance ??= new CommandStore();

        public ObservableCollection<VoiceCommand> Commands { get; }

        private CommandStore()
        {
            // Initialize with some default commands
            Commands = new ObservableCollection<VoiceCommand>
            {
                new VoiceCommand { Command = "Turn on light", Response = "Turning on the lights..." },
                new VoiceCommand { Command = "Set temperature to 22°C", Response = "Setting temperature to 22°C." }
            };
        }
    }

    public class VoiceCommand
    {
        public string Command { get; set; }
        public string Response { get; set; }
    }
}
