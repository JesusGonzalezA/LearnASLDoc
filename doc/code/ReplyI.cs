// SERVICE: QuestionService
private async Task<dynamic> GetUpdatedQuestion(...)
{
    dynamic question = await GetQuestionFromRepository(...);

    switch (testType)
    {
        // Other cases

        case TestType.QA:
        case TestType.QA_Error:
        case TestType.Mimic:
        case TestType.Mimic_Error:
            List<Prediction> predictions = await _aiService.SendRequest(difficulty, filename, token);
            // If the word is among the classification, the question is set as correct
            Prediction correctPrediction = predictions.Find(p => p.Label == question.WordToGuess);
            question.VideoUser = parameters.VideoUser;
            question.IsCorrect = correctPrediction != null;
            break;
    }

    return question;
}