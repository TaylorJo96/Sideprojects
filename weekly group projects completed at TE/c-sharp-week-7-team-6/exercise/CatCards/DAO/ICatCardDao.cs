using CatCards.Models;
using System.Collections.Generic;

namespace CatCards.DAO
{
    public interface ICatCardDao
    {
        List<CatCard> GetAllCards();

        CatCard GetCard(int id);

        CatCard SaveCard(CatCard cardToSave);

        bool UpdateCard(CatCard updatedCard);

        bool RemoveCard(int id);
    }
}