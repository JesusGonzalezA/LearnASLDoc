// AI SERVICE
public async Task<List<Prediction> > SendRequest(...)
{
    // Add headers
    // - Auth header
    _httpClient.DefaultRequestHeaders.Add(_options.AuthHeader, token);

    // (I skipped some initialization code)
    // - Multipart with other information
    //      - Video
    multipartFormContent.Add(
        fileStreamContent,
        name: _options.FormContentVideoKey,
        fileName: filenameWithoutPath
    );
    //      - Difficulty
    multipartFormContent.Add(
        name: _options.FormContentDifficultyKey,
        content: new StringContent(difficulty.ToString())
    );

    // Send the request
    HttpResponseMessage response = await _httpClient.PostAsync(
        _options.Route,
        multipartFormContent
    );

    // Read the reply
    string body = await response.Content.ReadAsStringAsync();

    // Map the reply
    List<Prediction> predictions = JsonConvert.DeserializeObject<List<Prediction> >(body);
    return predictions;
}