using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.GameAssets.Scripts.GamePlay.Cards;

namespace Assets.GameAssets.Scripts.GamePlay
{

    public  abstract class CardContainer
    {
        public static CardContainer CreateContainer(object pOwner, OrderType pOrderTyp)
        {
            switch (pOrderTyp)
            {
                    case OrderType.Orderd:
                    return new OrderedCardContainer(pOwner);
                    case OrderType.Random:
                    return new RandomCardContainer(pOwner);
            }
            
            Debug.Assert(false);
            return null;
        }

        public abstract int Count { get;}

        public abstract void Shuffle();

        public abstract CardDummy[] GetDummyCards();


    }
}
