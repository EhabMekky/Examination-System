namespace ExaminationSystem;

public abstract class Exam
{ 
    public int Duration { get; set; }
    public Question[] Questions { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public abstract void ShowExam();
    public abstract void ShowResults();
    
    public void ShowExam(bool displayQuestions = true)  
    {  
        if (displayQuestions)  
        {  
            foreach (var question in Questions)  
            {  
                question.DisplayQuestion();  
            }  
        }  
    }  
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
    
    public TimeSpan CalculateTimeTaken()
    {
        return EndTime - StartTime;
    }

    public bool IsTimeExceeded()
    {
        return CalculateTimeTaken() > TimeSpan.FromMinutes(Duration);
    }
    
    public void ShowExamDetails()
    {
        TimeSpan actualDuration = EndTime - StartTime;
        Console.WriteLine($"Exam Duration: {Duration} minutes");
        Console.WriteLine($"Actual Time Taken: {actualDuration.TotalMinutes} minutes");
    }
}
