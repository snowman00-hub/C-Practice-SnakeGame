using System;

class SnakeGame
{
    private static int sceneNumber = 0;
    public static bool isGameOver = false;
    public static int score = 0;

    public static void Main()
    {
        SnakeGame game = new SnakeGame();
        Console.CursorVisible = false;

        while (true)
        {
            switch (sceneNumber)
            {
                case 0:
                    game.EnterStartScene();
                    break;
                case 1:
                    game.EnterGameScene();
                    break;
                case 2:
                    game.EnterGameOverScene();
                    break;
            }
        }
    }

    public void EnterGameOverScene()
    {
        Console.WriteLine($"게임 오버! 점수: {score}");
        Console.WriteLine("\nSPACE 키를 눌러서 다시 시작하세요!");

        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
        } while (key != ConsoleKey.Spacebar);

        score = 0;
        sceneNumber = 0;
        Console.Clear();
    }

    public void EnterGameScene()
    {
        GameField gameField = new GameField();

        gameField.Init();
        gameField.Draw();
        System.Threading.Thread.Sleep(200);
        while (!isGameOver)
        {
            gameField.Update();

            Console.SetCursorPosition(0, 0);
            gameField.Draw();
        }

        sceneNumber = 2;
        Console.Clear();
    }

    public void EnterStartScene()
    {
        Console.WriteLine("스네이크 게임");
        Console.WriteLine("SPACE 키를 눌러서 시작하세요!");

        ConsoleKey key;
        do
        {
            key = Console.ReadKey().Key;
        } while (key != ConsoleKey.Spacebar);

        sceneNumber = 1;
        Console.Clear();
    }
}