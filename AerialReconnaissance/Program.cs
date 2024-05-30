namespace AerialReconnaissance
{
    internal static class Program
    {
        /// <summary>
        ///  Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Чтобы настроить конфигурацию приложения, например, установить высокие параметры DPI или шрифт по умолчанию,
            // см. https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}