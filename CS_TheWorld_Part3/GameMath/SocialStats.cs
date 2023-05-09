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

    public void changeMH(int num) => MentalHealth += num;
    
    public void changeSP(int num) => SocialPoints += num;


}