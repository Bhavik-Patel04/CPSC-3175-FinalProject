using System;

public class HealthSystem
{
    private int maxHealth       = 100;
	private int health_ammount  = 100;


	public HealthSystem()
	{
	}

	public void Hit(int decriment_ammount)
	{
		if (health_ammount > decriment_ammount)
		{
            health_ammount -= decriment_ammount;
		}
		else
		{
            health_ammount = 0; 
        }
	}

    public void reginerate(int incriment_ammount)
    {
        if (health_ammount < maxHealth)
        {
            health_ammount += incriment_ammount;
        }
        else
        {
            health_ammount = maxHealth;
        }
    }


}
