using Microsoft.AspNetCore.Mvc;
using SurveyService.Controllers.Bodies;

namespace SurveyService.Controllers;

[ApiController]
[Route("Survey")]
public class SurveyController(SurveyDbContextFactory factory) : ControllerBase
{
    [HttpGet("/{questionId:long}")]
    public async Task<IActionResult> GetQuestionAsync(long questionId)
    {
        using var context = factory.Create();

        var queryable = context.Set<Question>().AsQueryable();
        queryable = queryable.Include(nameof(Question.AnswerList));

        var result = await queryable.FirstOrDefaultAsync(x => x.Id == questionId);
        if (result is null)
            return NotFound();

        return Ok(new
        {
            result.Text,
            Answers = result.AnswerList.Select(x => x.Text).ToList()
        });
    }

    [HttpPost("/next")]
    public async Task<IActionResult> SaveAnswer([FromBody] SaveAnswersRequestBody requestBody)
    {
        using var context = factory.Create();

        var queryable = context.Set<Interview>().AsQueryable();
        queryable = queryable
            .Include(nameof(Interview.Survey))
            .Include($"{nameof(Interview.SurveyId)}.{nameof(Survey.QuestionList)}");

        var targetInterview = await queryable.FirstOrDefaultAsync(x => x.Id == requestBody.InterviewId);
        if (targetInterview is null)
            return BadRequest();

        var selectedAnswerList = context
            .Set<Answer>()
            .Where(x => requestBody.AnswerIdList.Contains(x.Id))
            .ToList();

        targetInterview.AddResult(new Result(requestBody.InterviewId, requestBody.QuestionId, selectedAnswerList));

        await context.SaveChangesAsync();

        var nextQuestionId = targetInterview.Survey.GetNextQuestionId(requestBody.QuestionId);

        return Ok(new { NextQuestionId = nextQuestionId });
    }
}