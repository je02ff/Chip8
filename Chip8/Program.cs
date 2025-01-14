using Chip8;
using Chip8.Component;
using Raylib_cs;

const string ROM_FILE_PATH = "../../../assets/rom/ibm.ch8";

Display display = new Display();
CPU cpu = new CPU(ROM_FILE_PATH, display);

while (!Raylib.WindowShouldClose())
{
    cpu.Cycle();
}