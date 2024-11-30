using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotellasDeLeche
{
    public static class Companero
    {
        public static void IniciarConsola(string nombre)
        {
            Console.WriteLine($"{nombre} está iniciando.");
            Console.Out.Flush();

            using (var client = new NamedPipeClientStream(".", "CanalLeche", PipeDirection.InOut))
            {
                client.Connect();

                var reader = new StreamReader(client);
                var writer = new StreamWriter(client) { AutoFlush = true };

                writer.WriteLine("VerificarLeche");

                string respuesta = reader.ReadLine();

                if (respuesta == "ComprarLeche")
                {
                    Console.WriteLine($"{nombre} va al supermercado.");
                    Console.Out.Flush();
                    // Simular tiempo para comprar leche
                    Task.Delay(5000).Wait();
                    Console.WriteLine($"{nombre} compra y guarda la leche.");
                    Console.Out.Flush();

                    // Notificar al servidor que la leche ha sido comprada
                    writer.WriteLine("LecheComprada");
                }
                else if (respuesta == "LecheDisponible")
                {
                    Console.WriteLine($"{nombre} ve que la leche ya está disponible.");
                    Console.Out.Flush();
                }
            }

            Console.WriteLine($"{nombre} ha terminado.");
            Console.Out.Flush();
        }
    }

}
