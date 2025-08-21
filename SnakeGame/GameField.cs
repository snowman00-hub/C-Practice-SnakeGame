using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameField
{
    private char[,] space;

    private Snake snake;

    public void Init()
    {
        space = new char[22, 22];
        SpaceReset();

        snake = new Snake();
        var foodPos = snake.GetFoodPos();
        space[foodPos.Item2, foodPos.Item1] = '*';
    }

    public void Update()
    {
        snake.Update();

        if (SnakeGame.isGameOver)
            return;

        SpaceReset();
        List<(int, int)> snakePos = snake.GetPos();
        foreach (var pos in snakePos)
        {
            space[pos.Item2, pos.Item1] = '0';
        }

        var foodPos = snake.GetFoodPos();
        space[foodPos.Item2, foodPos.Item1] = '*';
    }

    public void Draw()
    {
        for (int i = 0; i < 22; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                Console.Write(space[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"점수: {SnakeGame.score}");
    }

    public void SpaceReset()
    {
        for (int i = 0; i < 22; i++)
        {
            if (i == 0 || i == 21)
            {
                space[i, 0] = '+';
                for (int j = 1; j < 21; j++)
                    space[i, j] = '-';
                space[i, 21] = '+';
            }
            else
            {
                space[i, 0] = '|';
                for (int j = 1; j < 21; j++)
                    space[i, j] = ' ';
                space[i, 21] = '|';
            }
        }
    }
}
