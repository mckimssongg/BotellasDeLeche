using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotellasDeLeche
{
    public partial class Form1 : Form
    {
        // Variables para el modo de hilos (parte a)
        private bool hayLeche = false;
        private SemaphoreSlim semaforoCompra = new SemaphoreSlim(1, 1);
        private readonly object lockRefri = new object();

        // Variables para el modo de procesos (parte b)
        private Process servidorProceso;
        private List<Process> listaCompaneros;

        public Form1()
        {
            InitializeComponent();
            comboBoxModo.SelectedIndex = 0; // Seleccionar "Hilos (Parte a)" por defecto
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar.Enabled = false;
            comboBoxModo.Enabled = false;
            numericUpDownCompaneros.Enabled = false;

            if (comboBoxModo.SelectedIndex == 0)
            {
                // Modo de hilos (Parte a)
                IniciarSimulacionHilos();
            }
            else
            {
                // Modo de procesos (Parte b)
                IniciarSimulacionProcesos();
            }
        }

        private void IniciarSimulacionHilos()
        {
            listBoxLog.Items.Add("Iniciando simulación con hilos...");

            Thread companero1 = new Thread(() => AccionesCompaneroHilos("Compañero 1"));
            Thread companero2 = new Thread(() => AccionesCompaneroHilos("Compañero 2"));

            companero1.Start();
            companero2.Start();
        }

        private void AccionesCompaneroHilos(string nombre)
        {
            AgregarMensaje($"{nombre} mira el refrigerador.");

            bool necesitaLeche = false;

            lock (lockRefri)
            {
                if (!hayLeche)
                {
                    AgregarMensaje($"{nombre} nota que no hay leche.");
                    necesitaLeche = true;
                }
                else
                {
                    AgregarMensaje($"{nombre} ve que hay leche.");
                }
            }

            if (necesitaLeche)
            {
                // Intentar adquirir el semáforo para comprar leche
                if (semaforoCompra.Wait(0))
                {
                    try
                    {
                        AgregarMensaje($"{nombre} va al supermercado.");

                        // Simular el tiempo de ir al supermercado y comprar leche
                        Thread.Sleep(5000);

                        lock (lockRefri)
                        {
                            hayLeche = true;
                            AgregarMensaje($"{nombre} llega a casa y guarda la leche.");
                        }
                    }
                    finally
                    {
                        semaforoCompra.Release();
                    }
                }
                else
                {
                    AgregarMensaje($"{nombre} sabe que alguien más está comprando leche.");
                }
            }
        }

        private void IniciarSimulacionProcesos()
        {
            int numeroCompaneros = (int)numericUpDownCompaneros.Value;
            AgregarMensaje($"Iniciando simulación con procesos y {numeroCompaneros} compañeros...");

            // Iniciar el servidor
            servidorProceso = new Process();
            servidorProceso.StartInfo.FileName = Application.ExecutablePath;
            servidorProceso.StartInfo.Arguments = "servidor";
            servidorProceso.StartInfo.UseShellExecute = false;
            servidorProceso.StartInfo.CreateNoWindow = true;
            servidorProceso.StartInfo.RedirectStandardOutput = true;
            servidorProceso.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    AgregarMensaje($"Servidor: {e.Data}");
                }
            };
            servidorProceso.Start();
            servidorProceso.BeginOutputReadLine();

            listaCompaneros = new List<Process>();

            for (int i = 1; i <= numeroCompaneros; i++)
            {
                Process companeroProceso = new Process();
                companeroProceso.StartInfo.FileName = Application.ExecutablePath;
                companeroProceso.StartInfo.Arguments = $"companero \"Compañero {i}\"";
                companeroProceso.StartInfo.UseShellExecute = false;
                companeroProceso.StartInfo.CreateNoWindow = true;
                companeroProceso.StartInfo.RedirectStandardOutput = true;
                string nombreCompanero = $"Compañero {i}";
                companeroProceso.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        AgregarMensaje($"{nombreCompanero}: {e.Data}");
                    }
                };
                companeroProceso.Start();
                companeroProceso.BeginOutputReadLine();

                listaCompaneros.Add(companeroProceso);
            }

            // Monitorear los procesos
            Task.Run(() => MonitorearProcesos());
        }


        private void MonitorearProcesos()
        {
            foreach (var companero in listaCompaneros)
            {
                companero.WaitForExit();
            }

            if (!servidorProceso.HasExited)
            {
                servidorProceso.Kill();
            }

            AgregarMensaje("Simulación con procesos terminada.");
        }

        private void AgregarMensaje(string mensaje)
        {
            if (listBoxLog.InvokeRequired)
            {
                listBoxLog.Invoke(new Action(() => listBoxLog.Items.Add(mensaje)));
            }
            else
            {
                listBoxLog.Items.Add(mensaje);
            }
        }
    }
}
