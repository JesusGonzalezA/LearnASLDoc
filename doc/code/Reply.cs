// CONTROLLER
[HttpPut("{guid}")]
public async Task<IActionResult> Reply(Guid guid, [FromForm] QuestionReplyDto questionReplyDto)
{   
    // Other functionality

    await _questionService.UpdateQuestion(...);

    return Ok();
}

// SERVICE: QuestionService
public async Task UpdateQuestion(...)
{
    dynamic updatedQuestion = await GetUpdatedQuestion(...);
    dynamic repository = GetRepository(testType);

    // Other functionality

    await repository.Update(updatedQuestion);
}
