internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Programa para ordener fechas capturadas en una matriz");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Cuantas fechas va capturar: ");
        int cantidadCaptura = Convert.ToInt32(Console.ReadLine());

        int[,] fechasCapturadas = new int[cantidadCaptura, 3];

        for (int i = 0; i < fechasCapturadas.GetLength(0); i++)
        {
            Console.WriteLine($"Escribe la fecha número {i + 1} con el formato de DD MM YYYY");
            for (int j = 0; j < fechasCapturadas.GetLength(1); j++)
            {
                if (j == 0)
                {
                    Console.Write("Escribe el día (DD): ");
                }
                else if (j == 1)
                {
                    Console.Write("Escribe el mes (MM): ");
                }
                else if (j == 2)
                {
                    Console.Write("Escribe el año (YYYY): ");
                }
                fechasCapturadas[i, j] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("Fechas capturadas");
        PrintArray(fechasCapturadas);
        Console.ReadKey();

        Console.WriteLine("Fechas ordenadas por fecha");
        PrintArray(OrdenarFechas(fechasCapturadas,true));

        Console.WriteLine("Fechas ordenadas por fecha");
        PrintArray(OrdenarFechas(fechasCapturadas,false));

    }

    static void PrintArray(int[,] inputArray)
    {
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                Console.Write($"{inputArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static int[,] OrdenarFechas(int[,] fechas, bool ascendente) {

        //Calculo de los promedios
        int[] burbuja = new int[3];
        bool ordernar = false;

        for (int fil1 = 0; fil1 < fechas.GetLength(0); fil1++)
        {
            for (int fil2 = 0; fil2 < fechas.GetLength(0); fil2++)
            {
                //ordenar por año
                if (ascendente) 
                {
                    ordernar = fechas[fil1, 2] > fechas[fil2, 2] ? true :
                        fechas[fil1, 2] == fechas[fil2, 2] && fechas[fil1, 1] > fechas[fil2, 1] ? true : 
                        fechas[fil1, 2] == fechas[fil2, 2] && fechas[fil1, 1] == fechas[fil2, 1] && fechas[fil1, 0] > fechas[fil2, 0] ? true : false;
                }
                else {
                    ordernar = fechas[fil1, 2] < fechas[fil2, 2] ? true :
                        fechas[fil1, 2] == fechas[fil2, 2] && fechas[fil1, 1] < fechas[fil2, 1] ? true : 
                        fechas[fil1, 2] == fechas[fil2, 2] && fechas[fil1, 1] == fechas[fil2, 1] && fechas[fil1, 0] < fechas[fil2, 0] ? true : false;
                }

                if (ordernar)
                {
                    burbuja[0] = fechas[fil1, 0];
                    burbuja[1] = fechas[fil1, 1];
                    burbuja[2] = fechas[fil1, 2];

                    fechas[fil1, 0] = fechas[fil2, 0];
                    fechas[fil1, 1] = fechas[fil2, 1];
                    fechas[fil1, 2] = fechas[fil2, 2];

                    fechas[fil2, 0] = burbuja[0];
                    fechas[fil2, 1] = burbuja[1];
                    fechas[fil2, 2] = burbuja[2];

                }
            }
        }

        return fechas;

    }

}