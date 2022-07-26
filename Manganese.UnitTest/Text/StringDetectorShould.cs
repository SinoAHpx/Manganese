using System;
using System.Collections.Generic;
using Manganese.Text;
using Xunit;

namespace Manganese.UnitTest.Text;

//Test all methods in the StringDetector class 
public class StringDetectorShould
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    [InlineData("   ")]
    public void IsNullOrEmpty(string input)
    {
        Assert.False("a".IsNullOrEmpty());
        Assert.True(input.IsNullOrEmpty());
    }

    [Fact]
    public void ThrowExceptionWhenNullOrEmpty()
    {
        Assert.Throws<ArgumentNullException>(() => "".ThrowIfNullOrEmpty<ArgumentNullException>());
        Assert.Throws<ArgumentNullException>(() => " ".ThrowIfNullOrEmpty<ArgumentNullException>());
        Assert.Throws<ArgumentNullException>(() => "  ".ThrowIfNullOrEmpty<ArgumentNullException>());
        Assert.Throws<ArgumentNullException>(() => "   ".ThrowIfNullOrEmpty<ArgumentNullException>());
    }


    [Fact]
    public void IsInt32()
    {
        Assert.True("1".IsInt32());
        Assert.True("-1".IsInt32());
        Assert.True("0".IsInt32());
        Assert.False("1.0".IsInt32());
        Assert.False("-1.0".IsInt32());
        Assert.False("0.0".IsInt32());
        Assert.False("1.1".IsInt32());
        Assert.False("-1.1".IsInt32());
        Assert.False("0.1".IsInt32());
    }

    [Fact]
    public void IsInt64()
    {
        Assert.True("1".IsInt64());
        Assert.True("-1".IsInt64());
        Assert.True("0".IsInt64());
        Assert.True("9223372036854775807".IsInt64());
        Assert.True("92233720368547757".IsInt64());
        Assert.False("1.0".IsInt64());
        Assert.False("-1.0".IsInt64());
        Assert.False("9223372036854775808".IsInt64());
    }

    [Fact]
    public void IsValidEmail()
    {
        Assert.True("ahpx@yandex.com".IsValidEmail());
        Assert.True("114514@gmail.com".IsValidEmail());
        Assert.False("114514@gmail".IsValidEmail());
        Assert.False("114514@com.gmail".IsValidEmail());
    }

    [Fact]
    public void ContainsAnyOf()
    {
        var t = new List<string>()
        {
            "a1", "a2", "a3"
        };
        
        Assert.True("a1".ContainsAnyOf(t));
        Assert.True("a2".ContainsAnyOf(t));
        Assert.True("a3".ContainsAnyOf(t));
        Assert.False("a4".ContainsAnyOf(t));
    }

    [Fact]
    public void SubstringBetween()
    {
        Assert.True("Key: test - 123".SubstringBetween(": ", " -") == "test");
    }

    [Fact]
    public void SubstringAfter()
    {
        Assert.True("This: 123 - 123".SubstringAfter(": ") == "123 - 123");
        Assert.True("This.Is.A.Test".SubstringAfter(".", true) == "Test");
    }
}