using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Snake
{
    private Food food;

    private List<(int, int)> pos;
    private (int, int) tail;

    private (int, int) moveDir = (1, 0);

    public Snake()
    {
        pos = new List<(int, int)>();
        food = new Food();
        tail = food.GetPos();
    }

    public List<(int, int)> GetPos()
    {
        return pos;
    }

    public (int, int) GetFoodPos()
    {
        return food.GetPos();
    }

    public void Update()
    {
        if(pos.Count == 0)
        {
            GetFood();
        }

        KeyInput();
        Move();
    }

    public void GetFood()
    {
        pos.Add(tail);
        food.ResetPos(pos);
        SnakeGame.score++;
    }

    public void Move()
    {
        var head = pos[0];
        tail = pos[pos.Count - 1];
        for (int i = pos.Count - 1; i > 0; i--)
        {
            pos[i] = pos[i - 1];
        }
        head = (head.Item1 + moveDir.Item1, head.Item2 + moveDir.Item2);
        pos[0] = head;

        if (head == food.GetPos())
        {
            GetFood();
        }

        if((head.Item1 is <= 0 or >= 21) ||
            (head.Item2 is <= 0 or >= 21))
        {
            SnakeGame.isGameOver = true;
            System.Threading.Thread.Sleep(300);
        }

        for(int i= 1;i< pos.Count;i++)
        {
            if(head == pos[i])
            {
                SnakeGame.isGameOver = true;
                System.Threading.Thread.Sleep(300);
                break;
            }
        }
    }

    public void KeyInput()
    {
        float waitingTime = 175f;
        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalMilliseconds < waitingTime)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (moveDir != (0, 1))
                            moveDir = (0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (moveDir != (-1, 0))
                            moveDir = (1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (moveDir != (1, 0))
                            moveDir = (-1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        if (moveDir != (0, -1))
                            moveDir = (0, 1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
