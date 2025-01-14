using Chip8.Command;

namespace Chip8;

public class ControlUnit
{
    public void Invoke(ICommand command)
    {
        command.Execute();
    }
}