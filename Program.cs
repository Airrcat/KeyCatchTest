using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System.Text;

namespace KeyCatchTest
{

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            KeyPress keyPress = new KeyPress();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            
        }

    }
    class KeyPress
    {
        private static  GlobalHooker hooker = new GlobalHooker();//全局钩子，可以定义app内的hook
        private KeyboardHookListener hookListener = new KeyboardHookListener(hooker);
        public KeyPress()
        {
            hookListener.KeyPress += HookListener_KeyPress;
            hookListener.Start();
        }
         

            
        private void HookListener_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            Console.WriteLine(e.KeyChar);
            MessageBox.Show(e.KeyChar.ToString());
        }

    }


}