namespace Homework_4
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
            //    Подсказка: если взять первое число в массиве, 
            //    можно ли найти в оставшейся его части два числа равных по сумме первому.
            int[] array = new int[] { 1, 2, -6, 3, 9, 3, -1, 6, 3, -5, 5, 9, 7, 10, 0, 8, 4, 0 };
            int findCount = 6;

            HashSet<int[]> set = new HashSet<int[]>();
            List<int[]> list = new List<int[]>();

            //1-й вариант
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array.Length; k++)
                    {
                        if (array[i] + array[j] + array[k] == findCount)
                        {
                            if (!set.Contains([array[i], array[j], array[k]]))
                            {
                                set.Add([array[i], array[j], array[k]]);
                            }
                        }
                    }
                }
            }
            foreach (int[] item in set)
            {
                Console.WriteLine($"Числа = {item[0]}, {item[1]}, {item[2]} - сумма {findCount}");
            }



            //2-й вариант

            Array.Sort(array);

            for (int i = 0; i < array.Length - 2; i++)
            {
                int minPosition = i + 1;
                int maxPosition = array.Length - 1;
                while (minPosition < maxPosition)
                {
                    if (array[minPosition] + array[i] + array[maxPosition] == findCount)
                    {
                        list.Add([array[minPosition], array[i], array[maxPosition]]);
                        break;
                    }
                    else if (array[minPosition] + array[i] + array[maxPosition] < findCount) { minPosition++; }
                    else if (array[minPosition] + array[i] + array[maxPosition] > findCount) { maxPosition--; }
                }
            }

            foreach (int[] item in list)
            {
                Console.WriteLine($"Числа = {item[0]}, {item[1]}, {item[2]} - сумма {findCount}");
            }
        }
    }
}
