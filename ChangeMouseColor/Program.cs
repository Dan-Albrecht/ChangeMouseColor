namespace ChangeMouseColor
{
    using Microsoft.MouseKeyboardCenter.Interop;
    using System;
    using System.Threading;

    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            DPGAppType.DPGAppTypeInstance.CurrentDPGAppType = DeviceType.DEVICE_TYPE_MOUSE;
            IntelliProMouseSetting mouseSetting = SingleTouchMouseManager.Instance.GetIntelliProMouseSetting(ModelId.INTELLI_PRO_MOUSE);

            const int numSteps = 100;
            const double max = 2 * Math.PI;
            const double stepSize = max / numSteps;
            const double center = 255f / 2;
            const double rPhase = 0;
            const double gPhase = 2 * Math.PI / 3;
            const double bPhase = 2 * Math.PI / 3 * 2;

            while (true)
            {
                for (double theta = 0; theta <= max; theta += stepSize)
                {
                    byte r = (byte)(Math.Sin(theta + rPhase) * center + center);
                    byte g = (byte)(Math.Sin(theta + gPhase) * center + center);
                    byte b = (byte)(Math.Sin(theta + bPhase) * center + center);

                    mouseSetting.SetTailLightColor(r, g, b);
                    Thread.Sleep(25);
                }
            }
        }
    }
}
