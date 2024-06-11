namespace SurveyService.Domain;

public class Answer
{
    public long Id { get; }
    public string Text { get; set; }

    public long QuestionId { get; }
    public Question Question { get; }

    public IList<Result> ResultList { get; }

    private Answer() { }

    public Answer(string text, long questionId)
    {
        Text = text;
        QuestionId = questionId;
    }
}