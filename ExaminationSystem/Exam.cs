namespace ExaminationSystem;

public abstract class Exam
{
    public int Duration { get; set; }
    public Question[] Questions { get; set; }

    public abstract void ShowExam();
    public abstract void ShowResults();
    
    public int CalculateTotalMarks()
    {
        int total = 0;
        foreach (var question in Questions)
        {
            total += question.Mark;
        }
        return total;
    }

    public int CalculateUserMarks()
    {
        int userTotal = 0;
        foreach (var question in Questions)
        {
            if (question.IsCorrect())
            {
                userTotal += question.Mark;
            }
        }
        return userTotal;
    }
}
