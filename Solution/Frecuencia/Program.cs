using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frecuencia
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            int diff = 0;
            int[] arr;
            int[] brr;
            int resultValue = 0;
            int n = 0;
            int m = 0;

            Console.WriteLine("Escribe el tamaño del primer arreglo");
            int.TryParse(Console.ReadLine(), out resultValue);

            if (resultValue != 0)
            {
                n = resultValue;
                resultValue = 0;
            }
            else
                Close("El valor debe ser númerico, presione ENTER para salir");



            Console.WriteLine("Escribe el tamaño del segundo arreglo");
            int.TryParse(Console.ReadLine(), out resultValue);

            if (resultValue != 0)
            {
                m = resultValue;
                resultValue = 0;
            }
            else
                Close("El valor debe ser númerico, presione ENTER para salir");

            // Constraint: n<=m
            if (m <= n)
                Close("El tamaño del segundo arreglo debe ser mayor al del primer arreglo, presione ENTER para salir");


            // Constraint: 1<=n,m<=2*100000
            if ((n < 1 || n >= 200000) || (m < 1 || m >= 200000))
                Close("El tamaño de los arreglos deben estar entre 1 y 200000, presione ENTER para salir");


            Console.WriteLine("Escribe los valores del primer arreglo, línea por línea");
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                // Constraint: x intercession B
                int.TryParse(Console.ReadLine(), out resultValue);

                if (resultValue != 0)
                    arr[i] = resultValue;
                else
                    Close("Los valores deben ser numéricos, presione ENTER para salir");

                resultValue = 0;
            }

            Console.WriteLine("Escribe los valores del segundo arreglo, línea por línea");
            brr = new int[m];
            for (int i = 0; i < m; i++)
            {
                // Constraint: x intercession B
                int.TryParse(Console.ReadLine(), out resultValue);

                if (resultValue != 0)
                    brr[i] = resultValue;
                else
                    Close("Los valores deben ser numéricos, presione ENTER para salir");

                resultValue = 0;
            }

            // Constraint: 1<=x <=10000
            if ((arr.Where(k => k <= 1 || k >= 10000).Count() > 0) || (brr.Where(k => k <= 1 || k >= 10000).Count() > 0))
                Close("Los valores de los arreglos deben estar entre 1 y 10000, presione ENTER para salir");


            int[] result = NumericalOrdering.missingNumbers(arr, brr, out diff);

            // Constraint: Xmax - Xmin < 101
            if (diff > 100)
                Close("La diferencia entre el valor máximo y minimo del segundo arreglo no debe ser menor o igual a 100, presione ENTER para salir");


            Close(string.Concat("Los números faltantes son: ", String.Join(" ", result)));
        }

        public static void Close(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}