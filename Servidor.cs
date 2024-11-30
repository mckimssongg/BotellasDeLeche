using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotellasDeLeche
{
    public static class Servidor
    {
        private static bool hayLeche = false;
        private static readonly object lockRefri = new object();

        public static void IniciarConsola()
        {
            Console.WriteLine("Servidor iniciado. Esperando solicitudes de compañeros...");
            Console.Out.Flush();

            while (true)
            {
                var server = new NamedPipeServerStream("CanalLeche", PipeDirection.InOut, 10, PipeTransmissionMode.Message);
                server.WaitForConnection();

                Task.Run(() =>
                {
                    using (server)
                    {
                        var reader = new StreamReader(server);
                        var writer = new StreamWriter(server) { AutoFlush = true };

                        string solicitud = reader.ReadLine();

                        if (solicitud == "VerificarLeche")
                        {
                            bool necesitaComprar = false;

                            lock (lockRefri)
                            {
                                if (!hayLeche)
                                {
                                    necesitaComprar = true;
                                    hayLeche = true; // Reservar la compra
                                }
                            }

                            if (necesitaComprar)
                            {
                                writer.WriteLine("ComprarLeche");
                                Console.WriteLine("Servidor: Solicitando a un compañero que compre leche.");
                                Console.Out.Flush();
                            }
                            else
                            {
                                writer.WriteLine("LecheDisponible");
                                Console.WriteLine("Servidor: La leche ya está disponible.");
                                Console.Out.Flush();
                            }
                        }
                        else if (solicitud == "LecheComprada")
                        {
                            Console.WriteLine("Servidor: Un compañero ha comprado y guardado la leche.");
                            Console.Out.Flush();
                        }
                    }
                });
            }
        }
    }

}
