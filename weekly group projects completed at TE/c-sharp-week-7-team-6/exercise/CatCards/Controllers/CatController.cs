using System.Collections.Generic;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("/api/cards")]
    [ApiController]

    public class CatController : ControllerBase
    {
        private readonly ICatCardDao cardDao;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CatController(ICatCardDao _cardDao, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDao = _cardDao;
        }

        //// GET /api/cards: Provides a list of all Cat Cards in the user's collection.

        [HttpGet]

        public List<CatCard> ListAllCards()
        {
            List<CatCard> catCards = cardDao.GetAllCards();
            return catCards;
        }


        //GET /api/cards/{id
        //    }: Provides a Cat Card with the given ID.

        [HttpGet("{id}")]
        public ActionResult<CatCard> Get(int id)
        {
            CatCard catCard = cardDao.GetCard(id);
            if (catCard != null)
            {
                return Ok(catCard);
            }
            else
            {
                return NotFound();
            }
        }



        //GET /api/cards/random: Provides a new, randomly created Cat Card containing information from the cat fact and picture services.
        [HttpGet("random")]
        public ActionResult<CatCard> Get()
        {
            CatFact catFact = catFactService.GetFact();
            string fact= catFact.Text;

            CatPic catPic = catPicService.GetPic();
            string picUrl = catPic.File;

            if (fact != null && picUrl !=null)
            {
                CatCard cat = new CatCard();
                cat.CatFact = fact;
                cat.ImgUrl = picUrl;
                return Ok(cat);
            }
            else
            {
                return NotFound();
            }
        }




        //POST /api/cards: Saves a card to the user's collection.

        [HttpPost]
        public ActionResult<CatCard> Create(CatCard catCard)
        {
            CatCard added = cardDao.SaveCard(catCard);

            return Created($"/{added.CatCardId}", added);

        }



        //PUT /api/cards/{id
        //}: Updates a card in the user's collection.

        [HttpPut("{id}")]
        public ActionResult<CatCard> UpdateCard(CatCard catCard)
        {
            //This is good practice. making sure the model and the url id match. 
         
            if (catCard != null)
            {
                cardDao.UpdateCard(catCard);
                
                //200 with data more verborse (using more words to do the same thing)
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //DELETE /api/cards/{id}: Removes a card from the user's collection.

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CatCard existingCard = cardDao.GetCard(id);
            if (existingCard == null)
            {
                return NotFound();
            }


            bool success = cardDao.RemoveCard(id);
            if (success)
            {
                return NoContent(); //204 - success with no data. 
            }

            return StatusCode(500); //respond with error while trying to delete. 
        }

    }
}
