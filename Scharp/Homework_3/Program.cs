namespace Homework_3

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] labirynth = new int[,,]
            {
                {
                    {1, 1, 1, 1, 1},
                    {1, 0, 0, 1, 1},
                    {1, 0, 0, 1, 1},
                    {1, 0, 0, 0, 1},
                    {1, 1, 1, 1, 1}
                },
                {
                    {1, 1, 1, 1, 1},
                    {1, 1, 0, 0, 1},
                    {1, 0, 0, 1, 1},
                    {1, 0, 1, 1, 1},
                    {1, 1, 1, 1, 1}
                },
                {
                    {1, 1, 1, 1, 1},
                    {1, 0, 0, 0, 1},
                    {1, 0, 1, 1, 1},
                    {1, 0, 0, 0, 1},
                    {1, 1, 1, 1, 1}
                },
                {
                    {1, 1, 1, 1, 1},
                    {1, 0, 0, 0, 1},
                    {1, 0, 1, 0, 1},
                    {1, 0, 1, 0, 1},
                    {1, 1, 1, 1, 1}
                },
                {
                    {1, 1, 1, 1, 1},
                    {1, 1, 0, 0, 1},
                    {1, 0, 0, 0, 1},
                    {1, 1, 1, 0, 1},
                    {1, 1, 1, 1, 1}
                },
            };

            Console.Write(HasExit(3, 3, 3, labirynth));
        }


        //Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить
        //сколько всего выходов имеется в трёхмерном лабиринте:

        //int[,,] labirynth = new int[5, 5, 5];

        static int HasExit(int startI, int startJ, int startK, int[,,] l)
        {
            int count = 0;
            if (!IsOurBorder(startI, startJ, startK, l)) { return 0; }

            if (!IsZero(startI, startJ, startK, l)) { return 0; }
            else
            {
                l[startI, startJ, startK] = 2;

                if (startI == 0 && startJ == 0 && startK == 0
                    || startI == l.GetLength(0) - 1 && startJ == 0 && startK == 0
                    || startI == 0 && startJ == l.GetLength(1) - 1 && startK == 0
                    || startI == 0 && startJ == 0 && startK == l.GetLength(2) - 1
                    || startI == l.GetLength(0) - 1 && startJ == l.GetLength(1) - 1 && startK == l.GetLength(2))
                    count += 2;

                else if (startI == 0 || startJ == 0 || startK == 0
                    || startI == l.GetLength(0) - 1 || startJ == l.GetLength(1) - 1 || startK == l.GetLength(2) - 1)
                    count++;
            }
            count += HasExit(startI + 1, startJ, startK, l);
            count += HasExit(startI - 1, startJ, startK, l);
            count += HasExit(startI, startJ + 1, startK, l);
            count += HasExit(startI, startJ - 1, startK, l);
            count += HasExit(startI, startJ, startK + 1, l);
            count += HasExit(startI, startJ, startK - 1, l);
            return count;
        }


        static bool IsOurBorder(int x, int y, int z, int[,,] array)
        {
            if (x < 0 || x >= array.GetLength(0))
                return false;
            if (y < 0 || y >= array.GetLength(1))
                return false;
            if (z < 0 || z >= array.GetLength(2))
                return false;
            return true;
            //return array[x, y, z] == 0;
        }

        static bool IsZero(int x, int y, int z, int[,,] array)
        {
            if (array[x, y, z] == 0) return true;
            else return false;
        }
    }
}


//int[,] labirynth1 = new int[,]
//     {
//     {1, 1, 1, 0, 1, 0, 0 },
//     {1, 0, 0, 0, 0, 0, 1 },
//     {1, 0, 1, 1, 1, 0, 1 },
//     {0, 0, 0, 0, 1, 0, 0 },
//     {1, 1, 0, 0, 1, 1, 1 },
//     {1, 1, 1, 0, 1, 1, 1 },
//     {1, 1, 1, 0, 1, 1, 1 }
//     };

//static int Find(int x, int y, int[,] array)
//{
//    if (!IsEmpty(x, y, array))
//        return 0;

//    int count = 0;
//    array[x, y] = 2;

//    if (x == 0 && y == 0
//        || x == 0 && y == array.GetLength(1) - 1
//        || x == array.GetLength(0) - 1 && y == 0
//        || x == array.GetLength(0) - 1 && y == array.GetLength(1) - 1)
//        count += 2;
//    else if (x == 0 || y == 0 || y == array.GetLength(1) - 1 || x == array.GetLength(0) - 1)
//        count++;

//    count += Find(x, y + 1, array);
//    count += Find(x + 1, y, array);
//    count += Find(x - 1, y, array);
//    count += Find(x, y - 1, array);

//    return count;
//}

//static bool IsEmpty(int x, int y, int[,] array)
//{
//    if (x < 0 || x >= array.GetLength(0))
//        return false;
//    if (y < 0 || y >= array.GetLength(1))
//        return false;
//    return array[x, y] == 0;
//}