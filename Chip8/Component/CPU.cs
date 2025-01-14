using Chip8.Command;
using Chip8.Component.Memory;

namespace Chip8.Component;

public class CPU
{
    const string FONT_FILE_PATH = "../../../Component/Memory/cosmacvipfont.txt";
    public Display Renderer { get; }
    public MainMemory MainMemory;
    public RAM Ram { get; }
    internal short _PC = 0x200;
    internal short _index = 0x00;
    private Register _SP = MemoryFactory.CreateRegister();
    private byte _delayTimer;
    private byte _soundTimer;
    private ControlUnit _controlUnit;
    public CPU(string romPath, Display display)
    {
        Ram = new RAM();
        _controlUnit = new ControlUnit();
        MainMemory = MemoryFactory.CreateMainMemory(4096);
        MemoryLoader.LoadFontToMainMemory(FONT_FILE_PATH, MainMemory);
        MemoryLoader.LoadRomToMainMemory(romPath, MainMemory);
        Renderer = display;
    }

    public void Cycle()
    {
        // Fetch
        Instruction inst = new Instruction(
            (byte)(MainMemory.Data[_PC] >> 4 & 0x0F),
            (byte)(MainMemory.Data[_PC] & 0x0F),
            (byte)(MainMemory.Data[_PC + 1] >> 4 & 0x0F),
            (byte)(MainMemory.Data[_PC + 1] & 0x0F));

        _PC += 2;

        ICommand command = new Op_NoCommand();
        // Decode
        switch ((inst.FirstNibble, inst.SecondNibble, inst.ThirdNibble, inst.FourthNibble))
        {
            case (0x0, 0x0 , 0xE, 0x0):
                command = new Op_00E0(this);
                break;
            case (0x0, 0x0, 0xE, 0xE):
                break;
            case (0x1, _, _, _ ):
                command = new Op_1NNN(this, inst);
                break;
            case (0x2, _, _, _ ):
                break;
            case (0x3, _, _, _ ):
                break;
            case (0x4, _, _, _ ):
                break;
            case (0x5, _, _, 0x0 ):
                break;
            case (0x6, _, _, _ ):
                command = new Op_6XNN(this, inst);
                break;
            case (0x7, _, _, _ ):
                command = new Op_7XNN(this, inst);
                break;
            case (0x8, _, _, 0x0 ):
                break;
            case (0x8, _, _, 0x1 ):
                break;
            case (0x8, _, _, 0x2 ):
                break;
            case (0x8, _, _, 0x3 ):
                break;
            case (0x8, _, _, 0x4 ):
                break;
            case (0x8, _, _, 0x5 ):
                break;
            case (0x8, _, _, 0x6 ):
                break;
            case (0x8, _, _, 0x7 ):
                break;
            case (0x8, _, _, 0xE ):
                break;
            case (0x9, _, _, 0x0 ):
                break;
            case (0xA, _, _, _ ):
                command = new Op_ANNN(this, inst);
                break;
            case (0xB, _, _, _ ):
                break;
            case (0xC, _, _, _ ):
                break;
            case (0xD, _, _, _ ):
                command = new Op_DXYN(this, inst);
                break;
            case (0xE, _, 0x9, 0xE ):
                break;
            case (0xE, _, 0xA, 0x1 ):
                break;
            case (0xF, _, 0x0, 0x7 ):
                break;
            case (0xF, _, 0x0, 0xA ):
                break;
            case (0xF, _, 0x1, 0x5 ):
                break;
            case (0xF, _, 0x1, 0x8 ):
                break;
            case (0xF, _, 0x1, 0xE ):
                break;
            case (0xF, _, 0x2, 0x9 ):
                break;
            case (0xF, _, 0x3, 0x3 ):
                break;
            case (0xF, _, 0x5, 0x5 ):
                break;
            case (0xF, _, 0x6, 0x5 ):
                break;
        }

        // Execute
        _controlUnit.Invoke(command);
        
        // Renderer.Render();
    }
}

public record Instruction
{
    public byte FirstNibble { get; }
    public byte SecondNibble { get; }
    public byte ThirdNibble { get; }
    public byte FourthNibble { get; }

    public Instruction(byte firstNibble, byte secondNibble, byte thirdNibble, byte fourthNibble)
    {
        FirstNibble = firstNibble;
        SecondNibble = secondNibble;
        ThirdNibble = thirdNibble;
        FourthNibble = fourthNibble;
    }
}