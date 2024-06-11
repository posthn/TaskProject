namespace SurveyService.Controllers.Bodies;

public class SaveAnswersRequestBody
{
    public long InterviewId { get; set; }

    public long QuestionId { get; set; }

    public List<long> AnswerIdList { get; set; }
}