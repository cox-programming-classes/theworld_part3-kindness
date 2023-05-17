namespace CS_TheWorld_Part3.GameMath;

public class SocialStats
{
    public uint Addiction { get; private set; }
    public int MentalHealth { get; private set; }
    public int SocialPoints { get; private set; }

    public SocialStats (uint a, int mh, int sp)
    {
        Addiction = a;
        MentalHealth = mh;
        SocialPoints = sp;
    }

    public void changeAddiction(int num) => Addiction = Addiction + num < 0 ? 0 : (uint)(Addiction + num);
    
    public void changeSP(int num) => SocialPoints += num;

    public void changeMH(int num) => MentalHealth += num;

    /// <summary>
    /// Function bring sup mental health temporaryly after after a ceratin amounnt of time mh goes down
    /// </summary>
    /// <param name="firstValue">first increase of mh</param>
    /// <param name="downValue">give in positive - amount mh decreases eventually</param>
    /// <param name="time">amount of time it take for mh to go down</param>
    public void changeMHTemporary(int firstValue, int downValue, int time)
    {
        Console.WriteLine("up " + firstValue + "="+ MentalHealth);
        Thread thread = new(() => MHThread(downValue, time));
        thread.Start();
    }

    public void MHThread(int down, int time)
    {
        Thread.Sleep(time);
        changeMH(-down);
    }
    


}