using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entaria.Abstract;
using Entaria.Models;

namespace Entaria.Concrete
{
    public class EFCardRepository : ICardRepository
    {
        private EntariaEFContext context = new EntariaEFContext();
        public IQueryable<Card> Cards
        {
            get { return context.Cards; }
        }

        public void SaveCard(Card card)
        {
            if (card.CardId == 0)
            {
                context.Cards.Add(card);
            }
            else
            {
                Card c = context.Cards.Find(card.CardId);
                if (c != null)
                {
                    c.LoyaltyCardHolderId = card.LoyaltyCardHolderId;
                    c.Number = card.Number;
                }
            }
            context.SaveChanges();
        } // end save method

        public Card DeleteCard(int cardId)
        {
            Card c = context.Cards.Find(cardId);
            if (c != null)
            {
                context.Cards.Remove(c);
                context.SaveChanges();
            }
            return c;
        } // end delete method

    }
}