using System.Linq;
using Microsoft.Win32;

namespace RemoveForcedChromeExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Google\Chrome\ExtensionInstallForcelist", writable: true);
            if (key != null)
            {
                var value = key.GetValueNames().FirstOrDefault(k => key.GetValue(k)?.ToString()?.StartsWith("ppnbnpeolgkicgegkbkbjmhlideopiji") ?? false);
                if (value != null)
                {
                    System.Console.WriteLine("Deleting " + value);
                    key.DeleteValue(value);
                }
            }
        }
    }
}
