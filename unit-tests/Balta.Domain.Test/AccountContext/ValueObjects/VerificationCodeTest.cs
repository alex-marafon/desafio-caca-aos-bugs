using Balta.Domain.AccountContext.ValueObjects;
using Balta.Domain.SharedContext.Abstractions;
using Moq;

namespace Balta.Domain.Test.AccountContext.ValueObjects;

public class VerificationCodeTest
{
    private Mock<IDateTimeProvider> _mockDateTimeProvider;
    public VerificationCodeTest()
    {
        _mockDateTimeProvider = new Mock<IDateTimeProvider>();
        _mockDateTimeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2024, 11, 30));
    }
    
    [Fact]
    public void ShouldGenerateVerificationCode()
    {
        var verificationCode = VerificationCode.ShouldCreate(_mockDateTimeProvider.Object);

        // Act
        var code = verificationCode.Code;

        // Assert
        Assert.NotNull(verificationCode);
        Assert.NotNull(code);
        Assert.Equal(6, code.Length);
        Assert.True(verificationCode.ExpiresAtUtc.HasValue);
    }

    [Fact]
    public void ShouldGenerateExpiresAtInFuture()
    {
        var verificationCode = VerificationCode.ShouldCreate(_mockDateTimeProvider.Object);

        // Act
        var code = verificationCode.Code;

        // Assert
        Assert.NotNull(verificationCode);
        Assert.NotNull(code);
        Assert.Equal(6, code.Length);
        Assert.True(verificationCode.ExpiresAtUtc > DateTime.Now);
    }

    [Fact]
    public void ShouldGenerateVerifiedAtAsNull() => Assert.Fail();

    [Fact]
    public void ShouldBeInactiveWhenCreated() => Assert.Fail();

    [Fact]
    public void ShouldFailIfExpired() => Assert.Fail();

    [Fact]
    public void ShouldFailIfCodeIsInvalid() => Assert.Fail();

    [Fact]
    public void ShouldFailIfCodeIsLessThanSixChars() => Assert.Fail();

    [Fact]
    public void ShouldFailIfCodeIsGreaterThanSixChars() => Assert.Fail();

    [Fact]
    public void ShouldFailIfIsNotActive() => Assert.Fail();

    [Fact]
    public void ShouldFailIfIsAlreadyVerified() => Assert.Fail();

    [Fact]
    public void ShouldFailIfIsVerificationCodeDoesNotMatch() => Assert.Fail();

    [Fact]
    public void ShouldVerify() => Assert.Fail();
}