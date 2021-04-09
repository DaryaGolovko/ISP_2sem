using System;
using System.Runtime.InteropServices;
using System.Text;

namespace lab4
{
    class Info
    {
        [DllImport("kernel32.dll")]
        public static extern int GetSystemDirectory(StringBuilder buffer, ref int sizeBuffer);

        [DllImport("kernel32.dll")]
        public static extern int GetWindowsDirectory(StringBuilder buffer, ref int sizeBuffer);

        [DllImport("advapi32.dll")]
        public static extern int GetUserName(StringBuilder buffer, ref int sizeBuffer);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort processorKind;
        }

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SYSTEM_INFO info);
    }
    class Program
    {
        static void Main()
        {
            StringBuilder name = new StringBuilder();
            StringBuilder directory = new StringBuilder();
            StringBuilder windowsDirectory = new StringBuilder();
            int temp;

            temp = name.Capacity;
            Info.GetUserName(name, ref temp);
            Console.WriteLine($"Имя пользователя: {name}");

            temp = directory.Capacity;
            Info.GetSystemDirectory(directory, ref temp);
            Console.WriteLine($"Система: {directory}");

            temp = windowsDirectory.Capacity;
            Info.GetWindowsDirectory(windowsDirectory, ref temp);
            Console.WriteLine($"Windows: {windowsDirectory}");

            Info.SYSTEM_INFO info;
            Info.GetSystemInfo(out info);

            switch (info.processorKind)
            {
                case 0:
                    Console.WriteLine("Процессор: Intel x86");
                    break;
                case 5:
                    Console.WriteLine("Процессор: ARM");
                    break;
                case 6:
                    Console.WriteLine("Процессор: IA64 Intel Itanium-based");
                    break;
                case 9:
                    Console.WriteLine("Процессор: AMD64 or Intel x64");
                    break;
                case 12:
                    Console.WriteLine("Процессор: ARM64");
                    break;
                default:
                    Console.WriteLine("Процессор неизвестен");
                    break;
            }
        }
    }
}
