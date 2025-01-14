using Chip8.Component;

namespace Chip8.Command;

// Clear screen
public class Op_00E0(CPU cpu): ICommand 
{
    public void Execute()
    {
        Array.Clear(cpu.Renderer.PixelScreen, 0, cpu.Renderer.PixelScreen.Length);
    }
}