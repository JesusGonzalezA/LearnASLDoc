
public bool Check(string hash, string password)
{
    string[] parts = hash.Split('.');
    if (parts.Length != 3)
    {
        throw new FormatException("Unexpected hash format");
    }

    int iterations = Convert.ToInt32(parts[0]);
    byte[] salt = Convert.FromBase64String(parts[1]);
    byte[] key = Convert.FromBase64String(parts[2]);

    using (var algorithm = new Rfc2898DeriveBytes(
        password,
        salt,
        iterations
        ))
    {
        byte[] keyToCheck = algorithm.GetBytes(_options.KeySize);
        return keyToCheck.SequenceEqual(key);
    }
}