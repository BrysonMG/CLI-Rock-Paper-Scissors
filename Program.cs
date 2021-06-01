using System;
using System.Threading;

int PlayerPoints = 0;
int CompPoints = 0;
int PlayTo = 0;

void GetScore()
{
    string TopScore = string.Empty;
    TopScore = string.Empty;
    while (TopScore == string.Empty)
    {
        Console.WriteLine("What score do you want to play to?");
        TopScore = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(TopScore))
        {
            Console.WriteLine("Fine, I didn't want to play anyway...");
            Environment.Exit(0);
        }

        foreach (char x in TopScore)
        {
            if (!char.IsDigit(x))
            {
                Console.Clear();
                Console.WriteLine("Please type a number...");
                TopScore = string.Empty;
                break;
            };
        };

        if (TopScore == string.Empty)
        {
            continue;
        }

        if (int.Parse(TopScore) == 0)
        {
            Console.Clear();
            Console.WriteLine("Nice Try... Pick a number ABOVE 0...");
            TopScore = string.Empty;
            continue;
        }


        if (int.Parse(TopScore) >= 100)
        {
            Console.Clear();
            Console.WriteLine("Wait, you want to play HOW MANY rounds?");
            Thread.Sleep(1500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine("..");
            Thread.Sleep(500);
            Console.WriteLine("...");
            Thread.Sleep(500);
            Console.WriteLine("Nope. I don't think so... Pick a lower number.");
            Thread.Sleep(2000);
            Console.Clear();
            TopScore = string.Empty;
        }
    }

    PlayTo = int.Parse(TopScore);
};

void main()
{
    ScoreCard(PlayerPoints, CompPoints, PlayTo);
    Play();
};

void runGame()
{
    PlayerPoints = 0;
    CompPoints = 0;
    Console.Clear();
    GetScore();
    main();
}
runGame();

void ScoreCard(int PlayerScore, int CompScore, int EndScore)
{
    if (PlayerScore == EndScore)
    {
        Console.WriteLine($@"
        ------------------------------
        |  Player: {PlayerScore}  |  Computer: {CompScore} |
        ------------------------------
        You Won The Game!
        ");
        Thread.Sleep(1500);
        Console.Write("Would you like to play again? (Y/N): ");
        string Resp = Console.ReadLine().ToLower();
        if (Resp == "y")
        {
            PlayerPoints = 0;
            CompPoints = 0;
            runGame();
        }
        else
        {
            Environment.Exit(0);
        }
    }
    else if (CompScore == EndScore)
    {
        Console.WriteLine($@"
        ------------------------------
        |  Player: {PlayerScore}  |  Computer: {CompScore} |
        ------------------------------
        You Lost The Game!
        ");
        Thread.Sleep(1500);
        Console.Write("Would you like to play again? (Y/N): ");
        string Resp = Console.ReadLine().ToLower();
        if (Resp == "y")
        {
            runGame();
        }
        else
        {
            Environment.Exit(0);
        }
    };

    Console.WriteLine($@"
    First to {EndScore} wins.
    ------------------------------
    |  Player: {PlayerScore}  |  Computer: {CompScore} |
    ------------------------------
    Press Enter to quit.
    ");
};

void Play()
{
    Console.WriteLine(@"
    1) Rock
    2) Paper
    3) Scissors
    ");

    string Input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(Input))
    {
        Console.WriteLine("Thanks for playing!");
        Environment.Exit(0);
    };

    if (Input != "1" && Input != "2" && Input != "3")
    {
        Console.Clear();
        Console.WriteLine("Please make a valid selection...");
        main();
    };

    int Choice = int.Parse(Input);
    Console.Clear();
    if (Choice == 1)
    {
        UseRock();
    }
    else if (Choice == 2)
    {
        UsePaper();
    }
    else if (Choice == 3)
    {
        UseScissors();
    }
    else
    {
        Console.WriteLine("Please make a valid selection...");

    };

    Console.WriteLine();
    Console.WriteLine("----------VS----------");
    Console.WriteLine();

    Random Num = new Random();
    int CompChoice = Num.Next(1, 4);

    if (CompChoice == 1)
    {
        UseRock();
    }
    else if (CompChoice == 2)
    {
        UsePaper();
    }
    else
    {
        UseScissors();
    };

    Thread.Sleep(2500);

    if (Choice == CompChoice)
    {//Result: Draw
        Console.Clear();
        Console.WriteLine("You Drew That Round");
        main();
    }
    else if (Choice == 1 && CompChoice == 2)
    {//Result: Computer Wins
        Console.Clear();
        Console.WriteLine("You Lost That Round");
        CompPoints++;
        main();
    }
    else if (Choice == 1 && CompChoice == 3)
    {//Result: Player Wins
        Console.Clear();
        Console.WriteLine("You Won That Round");
        PlayerPoints++;
        main();
    }
    else if (Choice == 2 && CompChoice == 1)
    {//Result: Player Wins
        Console.Clear();
        Console.WriteLine("You Won That Round");
        PlayerPoints++;
        main();
    }
    else if (Choice == 2 && CompChoice == 3)
    {//Result: Computer Wins
        Console.Clear();
        Console.WriteLine("You Lost That Round");
        CompPoints++;
        main();
    }
    else if (Choice == 3 && CompChoice == 1)
    {//Result: Computer Wins
        Console.Clear();
        Console.WriteLine("You Lost That Round");
        CompPoints++;
        main();
    }
    else if (Choice == 3 && CompChoice == 2)
    {//Result: Player Wins
        Console.Clear();
        Console.WriteLine("You Won That Round");
        PlayerPoints++;
        main();
    };


};

void UseRock()
{
    Console.WriteLine(@"
        _______
    ---'   ____)
          (_____)
          (_____)
          (____)
    ---.__(___)
    ");
};

void UsePaper()
{
    Console.WriteLine(@"
         _______
    ---'    ____)____
               ______)
              _______)
             _______)
    ---.__________)
    ");
};

void UseScissors()
{
    Console.WriteLine(@"
        _______
    ---'   ____)____
              ______)
           __________)
          (____)
    ---.__(___)
    ");
};