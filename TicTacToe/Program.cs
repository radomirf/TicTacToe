class Program
{
    static void Main()
    {
        int player1wins = 0;
        int player2wins = 0;
        string again = "y";
        while (again.Equals("y"))
        {
            Console.Clear();
            bool endgame;
            int player = 1;
            int valid;
            int[] stored = new int[9];
            string[,] matrix = {
            {"1","2","3" },
            {"4","5","6"},
            {"7","8","9"},
        };
            int count = 0;
            do
            {
                Console.WriteLine("Choose field player " + player);
                Console.WriteLine();
                PrintField(matrix);
                string choice = Console.ReadLine();
                choice = choice.Trim();
                if (int.TryParse(choice, out valid))
                {
                    if (valid > 0 && valid < 10)
                    {
                        if (stored.Contains(valid))
                        {
                            Console.Clear();
                            Console.WriteLine("Field Taken");
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (matrix[i, j].Equals(choice))
                                    {
                                        if (count % 2 == 0)
                                        {
                                            stored[count] = valid;
                                            matrix[i, j] = "X";
                                            player = 2;
                                            count++;
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            stored[count] = valid;
                                            matrix[i, j] = "O";
                                            player = 1;
                                            count++;
                                            Console.Clear();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Field");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You didn't enter a number");
                }
                endgame = CheckWinner(matrix);

                endgame = CheckWinner(matrix);
            } while (!endgame && !(count == 9));
            Console.WriteLine("Final Field\n");
            PrintField(matrix);
            if (endgame)
            {
                if (player == 1)
                {
                    Console.WriteLine("Winner is player 2");
                    player2wins++;
                }
                else
                {
                    Console.WriteLine("winner is player 1");
                    player1wins++;
                }
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.WriteLine($"Player 1: {player1wins} vs Player 2: {player2wins}\n");
            Console.WriteLine("Wanna play again?  Enter 'y' for yes press any key to exit");
            again = Console.ReadLine();
        }
    }

    static bool CheckWinner(string[,] matrix)
    {
        //horizontal check
        for (int i = 0, j = 0; i < 3; i++)
        {
            if (matrix[i, j].Equals(matrix[i, j + 1]) && matrix[i, j].Equals(matrix[i, j + 2]))
                return true;
        }
        //vertical check
        for (int j = 0, i = 0; j < 3; j++)
        {
            if (matrix[i, j].Equals(matrix[i + 1, j]) && matrix[i, j].Equals(matrix[i + 2, j]))
                return true;
        }
        //diagonal check
        if (matrix[0, 0].Equals(matrix[1, 1]) && matrix[0, 0].Equals(matrix[2, 2]))
            return true;
        //diagonal check
        if (matrix[0, 2].Equals(matrix[1, 1]) && matrix[0, 2].Equals(matrix[2, 0]))
            return true;

        return false;
    }
    static void PrintField(string[,] matrix)
    {
        Console.WriteLine($" {matrix[0, 0]} | {matrix[0, 1]} | {matrix[0, 2]}");
        Console.WriteLine("------------");
        Console.WriteLine($" {matrix[1, 0]} | {matrix[1, 1]} | {matrix[1, 2]}");
        Console.WriteLine("------------");
        Console.WriteLine($" {matrix[2, 0]} | {matrix[2, 1]} | {matrix[2, 2]}");
        Console.WriteLine();
    }
}