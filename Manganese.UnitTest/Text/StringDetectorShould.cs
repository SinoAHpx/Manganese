﻿using System;
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
}