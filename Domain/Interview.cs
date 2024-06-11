namespace SurveyService.Domain;

public class Interview
{
    public long Id { get; }
    public string IntervieweeName { get; }
    public DateTime CreatedAt { get; }

    public long SurveyId { get; }
    public Survey Survey { get; }

    public IList<Result> ResultList { get; }

    private Interview() { }

    public Interview(string intervieweeName, DateTime createdAt, long surveyId)
    {
        IntervieweeName = intervieweeName;
        CreatedAt = createdAt;
        SurveyId = surveyId;
    }

    public void AddResult(Result result) => ResultList.Add(result);
}