using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ancient.runtime;
using static System.Console;


[Guid("2F380069-1951-41DF-9500-3FE4610FA924")]
public class TerminalDevice : Device
{
    public override void write(long address, long data)
    {
        switch (address)
        {
            case 0xA:
                if (data > kitties.Count)
                    this.ThrowMemoryRead((ulong) address, 0x15);
                print(kitties[(int)data]);
                break;
            case 0xB:
                print(kitties[new Random().Next(0, kitties.Count)]);
                break;
        }
    }

    private void print(string base64) 
        => WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(base64)));

    public TerminalDevice() : base(0x9, "kitty") { }




    private static List<string> kitties = new List<string>
    {
        "fFwtLS0vfA0KfCBvX28gfA0KIFxfXl8v",
        "IC9cXy9cDQooIG8ubyApDQogPiBeIDw=",
        "IC9cXy9cDQooIG8gbyApDQo9PV9ZXz09DQogIGAtJw==",
        "ICAgIC9cX19fX18vXA0KICAgLyAgbyAgIG8gIFwNCiAgKCA9PSAgXiAgPT0gKQ0KICAgKSAgICAgICAgICgNCiAgKCAgICAgICAgICAgKQ0KICggKCAgKSAgICggICkgKQ0KKF9fKF9fKV9fXyhfXylfXyk=",
        "ICAgICAgXCAgICAvXA0KICAgICAgICkgICggJykNCiAgICAgICggIC8gICkNCiAgICAgICBcKF9fKXw=",
        "ICAgKVwuXy4sLS0uLi4uLCdgYC4NCiAgLywgICBfLi4gXCAgIF9cICAoYC5fICwuDQogYC5fLi0oLF8uLictLSgsXy4uJ2AtLjsuJw=="
    };
}