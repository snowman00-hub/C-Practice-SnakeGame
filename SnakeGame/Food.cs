using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Food
{
    private (int, int) pos;

    public Food()
    {
        pos = (13, 12);
    }

    public void ResetPos(List<(int, int)> snakePos)
    {
        Random random = new Random();
        do
        {
            pos.Item1 = random.Next(1, 21);
            pos.Item2 = random.Next(1, 21);
        } while (snakePos.Contains(pos));
    }

    public (int,int) GetPos()
    {
        return pos;
    }
}
