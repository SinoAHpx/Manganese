using System;
using Manganese.Text;
using Xunit;

namespace Manganese.UnitTest.Text;

public class StringDetectorShould
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    [InlineData("   ")]
    public void IsNullOrEmpty(string input)
    {
        Assert.True(input.IsNullOrEmpty(true));
        Assert.False("a".IsNullOrEmpty());
    }
    
    [Fact]
    public void ThrowExceptionWhenNullOrEmpty()
    {
        Assert.Throws<ArgumentNullException>(() => "".ThrowIfNullOrEmpty());
        Assert.Throws<ArgumentNullException>(() => " ".ThrowIfNullOrEmpty(considerWhitespace: true));
        Assert.Throws<ArgumentNullException>(() => "  ".ThrowIfNullOrEmpty(considerWhitespace: true));
        Assert.Throws<ArgumentNullException>(() => "   ".ThrowIfNullOrEmpty(considerWhitespace: true));
    }
    
    

}