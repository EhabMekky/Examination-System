namespace ExaminationSystem;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion()
    {
        AnswerArray = new Answer[2];
    }

    public override void GetUserAnswer()
    {
        DisplayQuestion();
        Console.Write("Enter your answer (1 or 2): ");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer == 1)
        {
            UserAnswer = AnswerArray[0];
            Console.WriteLine("You selected: True");
        }
        else if (userAnswer == 2)
        {
            UserAnswer = AnswerArray[1];
            Console.WriteLine("You selected: False");
        }
        else
        {
            Console.WriteLine("Invalid answer.");
        }
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"{Header}\n{Body}\n1. True\n2. False\n");
    }
   
}