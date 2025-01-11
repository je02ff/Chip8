namespace Chip8.Component.Memory;

/// <summary>
/// The CHIP-8 has sixteen 8-bit registers, labeled V0 to VF. Each register can hold any value from 0x00 to 0xFF.
/// Register VF is used as a flag to hold information about the result of operations.
/// </summary>

public enum RegisterName
{
    V0,
    V1,
    V2,
    V3,
    V4,
    V5,
    V6,
    V7,
    V8,
    V9,
    VA,
    VB,
    VC,
    VD,
    VE,
    VF
}