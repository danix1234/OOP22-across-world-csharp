using NUnit.Framework;

[TestFixture]
public class RandomizeLineTest
{
    RandomizeLine _randomizeLine = new RandomizeLine();

    [Test]
    public void testRandomLine()
    {
        var randomDouble = _randomizeLine.getLineRandomNumber(5, 10, 10);
        Assert.GreaterOrEqual(randomDouble, 5, "result is too little");
        Assert.LessOrEqual(randomDouble, 10, "result is too big");
        Assert.AreEqual(randomDouble, _randomizeLine.getLineRandomNumber(5, 10, 10));
        Assert.AreNotEqual(randomDouble, _randomizeLine.getLineRandomNumber(5, 10.1, 10));
    }

    [Test]
    public void testRandomElem()
    {
        List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
        var randomElem = _randomizeLine.getLineRandomElement<int>(list, 11);
        Assert.GreaterOrEqual(randomElem, 0, "result is too little");
        Assert.LessOrEqual(randomElem, 6, "result is too big");
        Assert.AreEqual(randomElem, _randomizeLine.getLineRandomElement<int>(list, 11));
    }

}
