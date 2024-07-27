namespace ExaminationSystem;

public class Subject
{
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string name)
        {
            SubjectId = subjectId;
            Name = name;
        }

        public void CreateExam(Exam.ExamType examType, int numberOfQuestions)
        {
            switch (examType)
            {
                case Exam.ExamType.Final:
                    Exam = new FinalExam(numberOfQuestions)
                    {
                        Type = examType,
                    };
                    break;

                case Exam.ExamType.Practical:
                    Exam = new PracticalExam(numberOfQuestions)
                    {
                        Type = examType
                    };
                    break;

                default:
                    throw new ArgumentException("Invalid exam type");
            }
        }

        public object Clone()
        {
            var clonedSubject = new Subject(this.SubjectId, this.Name)
            {
                Exam = (Exam)this.Exam.Clone()
            };
            return clonedSubject;
        }

        public override string ToString()
        {
            return $"Subject Id: {SubjectId}, Name: {Name}";
        }
}