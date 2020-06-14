using System;
using System.Threading;
using SharpDX.XInput;

namespace Dominic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var controller = new Controller(UserIndex.Two);

            Console.WriteLine(controller.IsConnected);
            Console.WriteLine(controller.UserIndex);

            //controller.SetVibration(new Vibration()
            //{
            //    LeftMotorSpeed = 35000,
            //    RightMotorSpeed = 35000
            //});

            var batt = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
            Console.WriteLine(batt.BatteryLevel);
            Console.WriteLine(batt.BatteryType);

            while (true)
            {
                var state = controller.GetState();
                Console.WriteLine(state.Gamepad.Buttons);
                Thread.Sleep(100);
            }
        }
    }
}
