using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.GameAssets.Scripts.GamePlay.Cards;

namespace Assets.GameAssets.Scripts.GamePlay
{
    public class OrderedCardContainer : CardContainer
    {
        private object _Owner = null;

        /// <summary>
        /// A List containing all the cards in the deck.
        /// </summary>
        private Queue<Card> _Cards = new Queue<Card>();

        public override int Count
        {
            get { return _Cards.Count; }
        }

        public OrderedCardContainer(object pOwner)
        {
            _Cards = new Queue<Card>();
            _Owner = pOwner;
        }

        public Card Peek()
        {
            return _Cards.Peek();
        }

        public bool AddCard(Card pCard)
        {
            _Cards.Enqueue(pCard);
            return true;
        }

        public Card GetCard(string pCardName)
        {
            if (_Cards.Count > 0)
                return _Cards.Dequeue();
            return null;
        }

        public CardDummy View(string pCardName)
        {
            return null;
        }

        public override void Shuffle()
        {
            if (_Cards.Count < 2) return;

            _Cards.Peek().Visable = false;

            Card[] cardArr = _Cards.ToArray();
            _Cards.Clear();

            Random rand = new Random();
            for (int i = cardArr.Length - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                Card temp = cardArr[i];
                cardArr[i] = cardArr[n];
                cardArr[n] = temp;

            }

            foreach (Card card in cardArr)
            {
                _Cards.Enqueue(card);
            }

            _Cards.Peek().Visable = true;}

        public override CardDummy[] GetDummyCards()
        {
            var dummys = new List<CardDummy>();

            _Cards.ToArray().ToList().ForEach(x => dummys.Add(new CardDummy(x)));

            return dummys.ToArray();
        }
    }
}
