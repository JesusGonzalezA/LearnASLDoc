// Creating the attribute
public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int _maxFileSize;
    public MaxFileSizeAttribute(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        IFormFile file = value as IFormFile;
        if (file != null)
        {
            if (file.Length > _maxFileSize)
            {
                return new ValidationResult($"Maximum allowed file size is { _maxFileSize} bytes.");
            }
        }

        return ValidationResult.Success;
    }
}

// Use of the attribute
public class QuestionReplyDto
{
    [DataType(DataType.Upload)]
    [MaxFileSize(5 * 1024 * 1024)]
    [AllowedExtensions(new string[] { ".mp4" })]
    public IFormFile? VideoUser { get; set; }
}
