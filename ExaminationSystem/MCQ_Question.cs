namespace ExaminationSystem;

public class MCQ_Question : Question
{
    public MCQ_Question(int answerArraySize)
    {
        AnswerArray = new Answer[answerArraySize];
    }

    public override void GetUserAnswer()
    {
        DisplayQuestion();
        Console.Write($"Enter your answer (1 to {AnswerArray.Length}): ");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer >= 1 && userAnswer <= AnswerArray.Length)
        {
            UserAnswer = AnswerArray[userAnswer - 1];
            Console.WriteLine($"You selected: {UserAnswer.AnswerText}");
        }
        else
        {
            Console.WriteLine("Invalid answer.");
        }
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine($"{Header}\n{Body}");
        for (int i = 0; i < AnswerArray.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {AnswerArray[i].AnswerText}");
        }
        Console.WriteLine();
    }
}