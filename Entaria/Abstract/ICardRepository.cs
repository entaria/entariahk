using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entaria.Models;

namespace Entaria.Abstract
{
    public interface ICardRepository
    {
        IQueryable<Card> Cards { get; }

        void SaveCard(Card card);
        Card DeleteCard(int cardId);
    }
}
