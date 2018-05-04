using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frecuencia
{
    class Program
    {
        static int diff;
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            var array1 = arr.GroupBy(c => c)
                         .Select(group => new
                         {
                             Value = group.Key,
                             Count = group.Count()
                         }).ToList();

            var array2 = brr.GroupBy(c => c)
                         .Select(group => new
                         {
                             Value = group.Key,
                             Count = group.Count()
                         }).ToList();

            var result = array1.Except(array2).ToList();

            result = result.Where(k => k.Count > 1).ToList();
            diff = array2.Max(k => k.Value) - array2.Min(k => k.Value);

            return result.Select(k => k.Value).OrderBy(k => k).ToArray();
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            int m = Convert.ToInt32(Console.ReadLine());
            string[] brr_temp = Console.ReadLine().Split(' ');
            int[] brr = Array.ConvertAll(brr_temp, Int32.Parse);

            if ((arr.Where(k=> k <= 1 || k >= 10000).Count() > 0) || (brr.Where(k => k <= 1 || k >= 10000).Count() > 0))
                Console.WriteLine("Los valores de los arreglos deben estar entre 1 y 10000");

            else if (brr.Length <= arr.Length)
                Console.WriteLine("El segundo arreglo debe ser mayor al primer arreglo");

            else if (arr.Length < 1 && brr.Length < 1 && arr.Length >= 200000 && brr.Length >= 200000)
                Console.WriteLine("El tamaño de los arreglos deben estar entre 1 y 200000");

            else
            {
                int[] result = missingNumbers(arr, brr);

                if (diff > 100)
                    Console.WriteLine("La diferencia entre el valor máximo y minimo del segundo arreglo no debe ser menor o igual a 100");
                else
                    Console.WriteLine(String.Join(" ", result));
            }
            Console.ReadLine();
        }
    }
}
