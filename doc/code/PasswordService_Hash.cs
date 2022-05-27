public string Hash(string password)
{
    //PBKDF2 implementation
    using (var algorithm = new Rfc2898DeriveBytes(
        password,
        _options.SaltSize,
        _options.Iterations
        ))
    {
        string key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
        string salt = Convert.ToBase64String(algorithm.Salt);

        return $"{_options.Iterations}.{salt}.{key}";
    }
}