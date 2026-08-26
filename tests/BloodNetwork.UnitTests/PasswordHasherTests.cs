using BloodNetwork.Infrastructure.Authentication;

namespace BloodNetwork.UnitTests;

public class PasswordHasherTests
{
    private readonly PasswordHasher _hasher = new();

    [Fact]
    public void HashPassword_ReturnsNonEmptyString()
    {
        var hash = _hasher.HashPassword("testpassword");
        Assert.False(string.IsNullOrEmpty(hash));
    }

    [Fact]
    public void HashPassword_ReturnsDifferentHashes()
    {
        var hash1 = _hasher.HashPassword("testpassword");
        var hash2 = _hasher.HashPassword("testpassword");
        Assert.NotEqual(hash1, hash2);
    }

    [Fact]
    public void VerifyPassword_CorrectPassword_ReturnsTrue()
    {
        var hash = _hasher.HashPassword("Password123");
        Assert.True(_hasher.VerifyPassword("Password123", hash));
    }

    [Fact]
    public void VerifyPassword_WrongPassword_ReturnsFalse()
    {
        var hash = _hasher.HashPassword("Password123");
        Assert.False(_hasher.VerifyPassword("WrongPassword", hash));
    }

    [Fact]
    public void VerifyPassword_EmptyPassword_ReturnsFalse()
    {
        var hash = _hasher.HashPassword("Password123");
        Assert.False(_hasher.VerifyPassword("", hash));
    }

    [Fact]
    public void HashPassword_SpecialCharacters_Works()
    {
        var hash = _hasher.HashPassword("P@$$w0rd!#%");
        Assert.True(_hasher.VerifyPassword("P@$$w0rd!#%", hash));
    }

    [Fact]
    public void HashPassword_Unicode_Works()
    {
        var hash = _hasher.HashPassword("আমারপাসword1");
        Assert.True(_hasher.VerifyPassword("আমারপাসword1", hash));
    }

    [Fact]
    public void HashPassword_LongPassword_Works()
    {
        var longPassword = new string('A', 128);
        var hash = _hasher.HashPassword(longPassword);
        Assert.True(_hasher.VerifyPassword(longPassword, hash));
    }
}
