using System;

int PlayerPoints = 0;
int CompPoints = 0;

// void main()
// {

// };

void ScoreCard(int PlayerScore, int CompScore)
{
    Console.WriteLine($@"
    ------------------------------
    | Player: {PlayerScore}   |  Computer: {CompScore} |
    ------------------------------
    ");
};

void Play()
{
    Console.WriteLine(@"
    1) Rock
    2) Paper
    3) Scissors
    ");

    int Choice = int.Parse(Console.ReadLine());

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

    if (Choice == CompChoice)
    {
        Console.WriteLine("----------DRAW----------");

    }


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