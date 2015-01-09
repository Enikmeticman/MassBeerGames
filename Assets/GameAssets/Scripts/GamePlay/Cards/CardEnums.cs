

/// <summary>
/// The Type of color a card has.
/// </summary>
public enum ColorType 
{
    Black = 0,
    Red = 1
}

/// <summary>
/// The Type of card.
/// </summary>
public enum CardType
{
    Spade = 0,
    Heart = 1,
    Diamond = 2,
    Club = 3,
    WildCard = 4,    
}

/// <summary>
/// The deck types the deck factory can create.
/// </summary>
public enum DeckType
{
    Random = 0,
    Ring = 1
}

/// <summary>
/// The deck types the deck factory can create.
/// </summary>
public enum DeckCardType
{
    Standard = 0,
    Poker = 1,
    JackUp = 2,
    QueenkUp = 3,
    KingUp = 4,
    AceUp = 5
}