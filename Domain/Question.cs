namespace SurveyService.Domain;

public class Question
{
    public long Id { get; }
    public string Text { get; set; }
    public IList<Answer> AnswerList { get; }

    public long SurveyId { get; }
    public Survey Survey { get; }

    public IList<Result> ResultList { get; }

    private Question() { }

    public Question(string text) => Text = text;

    public Question(string text, IList<Answer> answers) : this(text) => AnswerList = answers;
}