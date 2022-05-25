public class QuestionController : BaseController
{
    // ... 
    private readonly IUriService _uriService;

    public QuestionController
    (
        // ...
        IUriService uriService
    )
    {
        // ...
        _uriService = uriService;
    }

    // ...
}