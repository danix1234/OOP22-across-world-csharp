using System;
using System.Collections.Generic;

public class RandomizeLine
{
    private readonly Dictionary<int, int> lineRandomValue = new Dictionary<int, int>();

    private void calculateLineRandomValue(int line)
    {
        if (!lineRandomValue.ContainsKey(line))
        {
            lineRandomValue[line] = new Random().Next(0, Int32.MaxValue);
        }
    }

    private double NextDouble(Random RandGenerator, double MinValue, double MaxValue)
    {
        return RandGenerator.NextDouble() * (MaxValue - MinValue) + MinValue;
    }

    public X getLineRandomElement<X>(List<X> elems, int line)
    {
        calculateLineRandomValue(line);
        return elems[lineRandomValue[line] % elems.Count];
    }

    public double getLineRandomNumber(double lowerBound, double upperBound, int line)
    {
        calculateLineRandomValue(line);
        var random = new Random(this.lineRandomValue[line]);
        if (lowerBound > upperBound)
        {
            return NextDouble(random, upperBound, lowerBound);
        }
        if (lowerBound == upperBound)
        {
            return lowerBound;
        }
        return NextDouble(random, lowerBound, upperBound);
    }
}