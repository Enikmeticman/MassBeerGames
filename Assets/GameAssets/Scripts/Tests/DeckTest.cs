using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class DeckTest : MonoBehaviour 
{
    void Start()
    {
        DeckFactory.GreateDeck(DeckCardType.Poker, DeckType.Ring, new Vector3(-10,0,0));
        DeckFactory.GreateDeck(DeckCardType.Poker, DeckType.Ring, new Vector3(+10, 0, 0));
        DeckFactory.GreateDeck(DeckCardType.Poker, DeckType.Ring, new Vector3(0, 20, 0));
        DeckFactory.GreateDeck(DeckCardType.Poker, DeckType.Ring, new Vector3(0, -20, 0));

        PileFactory.GreatePile(PileType.Stack, VisableCardStyle.Top, PickStyle.Line, new Vector3(-30, -30, 0));
        PileFactory.GreatePile(PileType.Stack, VisableCardStyle.Top, PickStyle.Line, new Vector3(-30, 0, 0));
        PileFactory.GreatePile(PileType.Stack, VisableCardStyle.Top, PickStyle.Line, new Vector3(-30, +30, 0));
    }
}
