[Theory]
[InlineData("test@mail.com")]
public async Task UserService_ChangeEmail_ThrowsBEUserAlreadyInUse(string email)
{
    // Arrange
    UserService userService = new UserService(_unitOfWork);
    UserEntity userEntity = new UserEntity(email, "test");
    await userService.AddUser(userEntity);

    // Assert
    await Assert.ThrowsAsync<BusinessException>(async () =>
    {
        // Act
        await userService.ChangeEmail(email, email);
    });
}