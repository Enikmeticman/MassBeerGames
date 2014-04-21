

/// <summary>
/// The Type of color a card has.
/// </summary>
public enum ColorType 
{
    Red,
    Black
}

/// <summary>
/// The Type of card.
/// </summary>
public enum CardType
{
    Spades,
    Hearts,
    Diamonts,
    Clubs,
    WildCard,    
}

/// <summary>
/// The deck types the deck factory can create.
/// </summary>
public enum DeckType
{
    Standard = 0,
    Poker = 1,
    JackUp = 2,
    QueenkUp = 3,
    KingUp = 4,
    AceUo = 5
}