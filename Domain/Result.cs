namespace SurveyService.Domain;

public class Result
{
    public long Id { get; }

    public long InterviewId { get; }
    public Interview Interview { get; }

    public long QuestionId { get; }
    public Question Question { get; }

    public IList<Answer> AnswerList { get; }

    private Result() { }

    public Result(long interviewId, long questionId, IList<Answer> answers)
    {
        InterviewId = interviewId;
        QuestionId = questionId;
        AnswerList = answers;
    }
}