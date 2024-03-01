internal class Program
{
    static void Main(string[] args)
    {
        int[,] labirynth = new int[,]
        {
        {1, 1, 1, 1, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 1 },
        {0, 0, 0, 0, 1, 0, 2 },
        {1, 1, 2, 0, 1, 1, 0 },
        {1, 1, 1, 0, 1, 1, 1 },
        {2, 1, 1, 2, 1, 1, 1 }
        };
        int quantityExit = HasExit(1, 1, labirynth);
        if (quantityExit != 0)
        {
            if (quantityExit == 1)
            {
                    Console.WriteLine("Найден 1 выход");
            }
            else
            {
                Console.WriteLine("Найдено несколько выходов в количестве: " + quantityExit + " шт.");
            }
        }  
        else
        {
            Console.WriteLine("Выхода нет");
        }
    }

    static int HasExit(int startI, int startJ, int[,] labirynth)
    {
        Queue<(int, int)> coordinates = new ();
        int quantity = 0;
        if (labirynth[startI, startJ] != 1)
        {
            coordinates.Enqueue((startI, startJ));
        }

        while (coordinates.Count > 0)
        {
            (int i, int j) = coordinates.Dequeue();
            if (labirynth[i, j] == 2)
            {
                quantity += 1;
            }
            labirynth[i, j] = 1;
            if (((i-1) >= 0) && (labirynth[i-1, j] != 1))
            {
                coordinates.Enqueue((i-1, j));
            }
            if (((i+1) < labirynth.GetLength(0)) && (labirynth[i+1, j] != 1))
            {
                coordinates.Enqueue((i+1, j));
            }
            if (((j-1) >= 0) && (labirynth[i, j-1] != 1))
            {
                coordinates.Enqueue((i, j-1));
            }
            if (((j+1) < labirynth.GetLength(1)) && (labirynth[i, j+1] != 1))
            {
                coordinates.Enqueue((i, j+1));
            }
        }
        return quantity;
    }
}
