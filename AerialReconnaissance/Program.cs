namespace AerialReconnaissance
{
    internal static class Program
    {
        /// <summary>
        ///  ������� ����� ����� � ����������.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ����� ��������� ������������ ����������, ��������, ���������� ������� ��������� DPI ��� ����� �� ���������,
            // ��. https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}