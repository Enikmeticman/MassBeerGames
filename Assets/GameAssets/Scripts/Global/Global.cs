
public static class Global
{
    public static readonly int MIN_CARD_VALUE = 2;
    public static readonly int MAX_CARD_VALUE = 14;
    public static readonly int WILD_CARD_VALUE = 15;


   /* #region Singleton
    static private readonly object _Rooth = new object();
    static private Global _Instance = null;

    static Global Instance
    {
        get
        {
            if (_Instance == null)
            {
                lock (_Rooth)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Global();
                    }
                }
            }

            return _Instance;
        }
    }

    private Global(){}

    #endregion*/
}
