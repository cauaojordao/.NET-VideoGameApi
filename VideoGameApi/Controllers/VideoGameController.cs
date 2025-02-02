using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "Ps5",
                Developer = "Insomniac Games",
                Publisher = "Sony Interactive Entertainment"
                },
            new VideoGame {
                Id = 2,
                Title = "The Legend of Zelda Breath of the Wild",
                Platform = " Nintendo Switch",
                Developer = "Nintendo EPD",
                Publisher = "Nintendo"
            }
        };
        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(x => x.Id == id);

            if (game is null)
                return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();

            newGame.Id = videoGames.Max(x => x.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id });
        }

    }
}
