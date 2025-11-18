
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
            List<List<double>> semana = new List<List<double>>();

            for (int i = 0; i < dias.Length; i++)
            {
                Console.WriteLine($"\n Día {i + 1}: {dias[i]}");
                List<double> temperaturasDelDia = new List<double>();
                int medicion = 1;

                while (true)
                {
                    Console.Write($"🌡️ Medición {medicion} - Ingrese temperatura en °C: ");
                    if (double.TryParse(Console.ReadLine(), out double temp))
                    {
                        if (temp < -30 || temp > 50)
                        {
                            Console.WriteLine(" Temperatura fuera de rango (-30°C a 50°C). No se registra.");
                            continue;
                        }
                        temperaturasDelDia.Add(temp);
                        MostrarConversiones(temp, medicion);
                        medicion++;
                    }
                    else
                    {
                        Console.WriteLine("❌ Entrada inválida.");
                    }

                    Console.Write("¿Desea ingresar otra temperatura? (S/N): ");
                    string respuesta = Console.ReadLine().ToUpper();
                    if (respuesta != "S") break;
                }

                MostrarResumenDiario(temperaturasDelDia, dias[i]);
                semana.Add(temperaturasDelDia);
            }

              MostrarResumenSemanal(semana, dias);
            static void MostrarConversiones(double celsius, int medicion)
            {
                double fahrenheit = celsius * 1.8 + 32;
                double kelvin = celsius + 273.15;
                Console.WriteLine($"Medición {medicion}: {celsius:F2}°C | {fahrenheit:F2}°F | {kelvin:F2}K");
            }

            static void MostrarResumenDiario(List<double> temps, string dia)
            {
                double max = temps.Max();
                double min = temps.Min();
                double promedio = temps.Average();
                Console.WriteLine($"\n Resumen de {dia}:");
                Console.WriteLine($"Cantidad de mediciones: {temps.Count}");
                Console.WriteLine($"Temperatura máxima: {max:F2}°C");
                Console.WriteLine($"Temperatura mínima: {min:F2}°C");
                Console.WriteLine($"Promedio del día: {promedio:F2}°C");
            }
            static void MostrarResumenSemanal(List<List<double>> semana, string[] dias)
            {
                int totalMediciones = semana.Sum(dia => dia.Count);
                double promedioSemanal = semana.SelectMany(dia => dia).Average();

                int diaMayor = semana.Select((temps, i) => new { Index = i, Prom = temps.Average() })
                                     .OrderByDescending(x => x.Prom).First().Index;

                int diaMenor = semana.Select((temps, i) => new { Index = i, Prom = temps.Average() })
                                     .OrderBy(x => x.Prom).First().Index;

                Console.WriteLine("\n📅 Resumen semanal:");
                Console.WriteLine($"Total de mediciones: {totalMediciones}");
                Console.WriteLine($"Promedio semanal: {promedioSemanal:F2}°C");
                Console.WriteLine($"Día con mayor promedio: {dias[diaMayor]}");
                Console.WriteLine($"Día con menor promedio: {dias[diaMenor]}");
            }
        }
    }
}



