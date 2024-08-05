
internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {

            Console.WriteLine("КРЕСТИКИ НОЛИКИ\nВидите 1 чтобы начать игру.\nВидите 0 чтобы выйти");
            Console.Write("Вод: ");
            if (int.TryParse(Console.ReadLine(), out var choice_game))
            {
                switch (choice_game)
                {
                    case 1:
                        Initialization();
                        Gameplay_player_1();
                        return;
                    case 0:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("ОШИБКА\nВы ввели неправильное число\n");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("ОШИБКА\nВы ввели не число\n");

            }

        }

    }

    static int Width_X = 3;
    static int Width_Y = 3;
    static string[,] map = new string[Width_Y, Width_X];

    static void Initialization()
    {
        var card_appearance = " ■";
        for (int i = 0; i < Width_Y; i++)
        {
            for (int j = 0; j < Width_X; j++)
            {
                map[i, j] = card_appearance;
            }
        }
        Game_map();
    }

    static void Game_map()
    {
        Console.WriteLine();
        for (int i = 0; i < Width_Y; i++)
        {
            for (int j = 0; j < Width_X; j++)
            {
                Console.Write($"{map[i, j],2}");

            }
            Console.WriteLine();
        }
    }
    static bool win = true;
    static string player_X_O;
    static void Gameplay_player_1()
    {


        while (true)
        {
            Console.WriteLine("\nИгрок X выберите поле");
            Console.Write("Сорочка X: ");
            if (int.TryParse(Console.ReadLine(), out var x_X))
            {
                Console.Write("Сорочка Y: ");
                if (int.TryParse(Console.ReadLine(), out var y_X))
                {
                    if (y_X > 0 && y_X < 4 && x_X > 0 && x_X < 4 && map[y_X - 1, x_X - 1] != "x" && map[y_X - 1, x_X - 1] != "o")
                    {
                        Console.Clear();
                        player_X_O = "x";
                        map[y_X - 1, x_X - 1] = player_X_O;
                        Game_map();
                        Win();
                        if (win == false)
                        {
                            Console.WriteLine("Игрок X выиграл");
                            return;
                        }

                        while (true)
                        {
                            Console.WriteLine("\nИгрок O выберите поле");
                            Console.Write("Сорочка X: ");
                            if (int.TryParse(Console.ReadLine(), out var x_O))
                            {
                                Console.Write("Сорочка Y: ");
                                if (int.TryParse(Console.ReadLine(), out var y_O))
                                {
                                    if (y_O > 0 && y_O < 4 && x_O > 0 && x_O < 4 && map[y_O - 1, x_O - 1] != "o" && map[y_O - 1, x_O - 1] != "x")
                                    {
                                        Console.Clear();
                                        player_X_O = "o";
                                        map[y_O - 1, x_O - 1] = player_X_O;
                                        Game_map();
                                        Win();
                                        if (win == false)
                                        {
                                            Console.WriteLine("Игрок O выиграл");
                                            return;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Вы выбрали неправильную строку");
                                        Game_map();
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Вы выбрали не Y");
                                    Game_map();

                                }


                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Вы выбрали не X");
                                Game_map();

                            }
                        }
                    

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Вы выбрали неправильную строку");
                        Game_map();
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы выбрали не Y");
                    Game_map();

                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали не X");
                Game_map();

            }

        }





    }
   


   static void Win()
    {
        int n = map.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            if (Enumerable.Range(0, n).All(j => map[i, j] == player_X_O))
            {
                win = false;
            }
        }
        for (int j = 0; j < n; j++)
        {
            if (Enumerable.Range(0, n).All(i => map[i, j] == player_X_O))
            {
                win = false;
            }
        }
        if (Enumerable.Range(0, n).All(i => map[i, i] == player_X_O))
        {
            win = false;
        }
        if (Enumerable.Range(0, n).All(i => map[i, n - i - 1] == player_X_O))
        {
            win = false;
        }
    }
}


