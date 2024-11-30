namespace BotellasDeLeche
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "servidor")
            {
                // Iniciar el servidor en modo consola
                Servidor.IniciarConsola();
            }
            else if (args.Length > 0 && args[0] == "companero")
            {
                // Iniciar un compa�ero en modo consola
                string nombreCompanero = args.Length > 1 ? args[1] : "Compa�ero";
                Companero.IniciarConsola(nombreCompanero);
            }
            else
            {
                // Iniciar la aplicaci�n Windows Forms
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }

        }
    }
}