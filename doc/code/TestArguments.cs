public static IEnumerable<object[]> AllTestTypes()
{
    foreach (var number in Enum.GetValues(typeof(TestType)))
    {
        yield return new object[] { number };
    }
}

[Theory]
[MemberData(nameof(AllTestTypes))]
public async Task QuestionService_UpdateQuestion_DoesNotThrowException(TestType testType)
{
    // Test
}

[Theory]
[InlineData("test@mail.com")]
public async Task UserService_GetUserByEmail(string email)
{
    // Test
}

[Fact]
public async Task TestService_AddTest_ReturnsGuid()
{
    // Test
}