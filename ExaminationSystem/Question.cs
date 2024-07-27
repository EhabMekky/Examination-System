namespace ExaminationSystem;

public class Question
{ 
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    
    public Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
    }
}