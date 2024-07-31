namespace ExaminationSystem;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam Exam { get; set; }

    public Subject(int subjectId, string subjectName )
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void CreateExam(Program.ExamType examType, int numberOfQuestions)
    {
        switch (examType)
        {
            case Program.ExamType.Final:
                Exam = new FinalExam
                {
                    Questions = new Question[numberOfQuestions]
                };
                break;
            case Program.ExamType.Practical:
                Exam = new PracticalExam
                {
                    Questions = new Question[numberOfQuestions]
                };
                break;
        }
    }

    public override string ToString()
    {
        return $"Subject {SubjectId}: {SubjectName}";
    }
}
