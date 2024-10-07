using System;
public abstract class ResetStrategyHelper
{
	public static ResetStrategy GetStrategy(ResetStrategy.NAME strategy)
	{
		switch(strategy)
		{
			case ResetStrategy.NAME.Spiral: return new SpiralResetStrategy();
			case ResetStrategy.NAME.Wave: return new WaveResetStrategy();
			default:
				throw new ArgumentException();
		}
	}

	public static ResetStrategy GetRandomStrategy()
	{
        Array values = Enum.GetValues(typeof(ResetStrategy.NAME));
        Random random = new Random();
        ResetStrategy.NAME randomName =
			(ResetStrategy.NAME) values.GetValue(random.Next(values.Length));

		return GetStrategy(randomName);
	}
}

