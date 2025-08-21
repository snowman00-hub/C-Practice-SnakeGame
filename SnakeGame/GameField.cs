using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameField
{
    private char[,] space;

    private Snake snake;
    private Food food;

    public void Init()
    {
        space = new char[22, 22];
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

        snake = new Snake();
        food = new Food();
    }

    public void Update()
    {
        snake.Update();

        if (SnakeGame.isGameOver)
            return;

        List<(int, int)> snakePos = snake.GetPos();
        foreach (var pos in snakePos)
        {
            if (space[pos.Item1, pos.Item2] == ' ')
            {
                space[pos.Item1, pos.Item2] = '0';
            }
            else if(space[pos.Item1, pos.Item2] == ' ')
        }
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
}
