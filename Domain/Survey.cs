namespace SurveyService.Domain;

public class Survey
{
    public long Id { get; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public IList<Question> QuestionList { get; }

    public IList<Interview> InterviewList { get; }

    private Survey() { }

    public Survey(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }

    public Survey(string name, string? description, IList<Question> questions) : this(name, description) => QuestionList = questions;

    public long? GetNextQuestionId(long currentQuestionId)
    {
        if (QuestionList is null || QuestionList.Any() is false)
            return null;

        if (QuestionList.Last().Id == currentQuestionId)
            return null;

        var target = QuestionList.First(x => x.Id == currentQuestionId);
        var currentIndex = QuestionList.IndexOf(target);

        return QuestionList[currentIndex + 1].Id;
    }
}