using System;
using Manganese.Data;
using Xunit;

namespace Manganese.UnitTest.Data;

public class CommonDataDetectorShould
{
    [Fact]
    public void ThrowIfNul()
    {
        string? a = null;
        Assert.Throws<InvalidOperationException>(() => a.ThrowIfNull(new InvalidOperationException()));

        Assert.Equal("awd", "awd".ThrowIfNull());
        Assert.Equal(114514, 114514.ThrowIfNull());
    }
}