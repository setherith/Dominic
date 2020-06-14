using System;
using System.Runtime.CompilerServices;
using System.Threading;
using SharpDX.XInput;

namespace Dominic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking controllers...");

            var controller = new Controller(UserIndex.One);

            if (controller.IsConnected)
            {
                var batt = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                Console.WriteLine(batt.BatteryLevel);
                Console.WriteLine(batt.BatteryType);

                int packet = 0;

                while (true)
                {
                    var state = controller.GetState();

                    if (state.PacketNumber != packet)
                    {
                        Console.Clear();
                        Console.WriteLine("Buttons: " + state.Gamepad.Buttons);
                        Console.WriteLine("Left X, Y: " + state.Gamepad.LeftThumbX + "," + state.Gamepad.LeftThumbY);
                        Console.WriteLine("Right X, Y: " + state.Gamepad.RightThumbX + "," + state.Gamepad.RightThumbY);
                        Console.WriteLine("Triggers R, L: " + state.Gamepad.RightTrigger + "," + state.Gamepad.LeftTrigger);
                    }

                    packet = state.PacketNumber;
                    Thread.Sleep(50);
                }
            }
        }
    }
}