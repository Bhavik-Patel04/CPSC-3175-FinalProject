using System;

public interface IActivity
{
	string Name { get; }
	string Description { get; }

	// add action

	public IActivity()
	{
	}

	public void Execute()
	{

	}
}
