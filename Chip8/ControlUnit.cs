using Chip8.Command;

namespace Chip8;

public class ControlUnit
{
    private ICommand _noCommand;
    private List<ICommand> _commands = new();
    
    public ControlUnit()
    {
        
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}