using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context;
 
        [HttpGet]
         public async Task <ActionResult<List<VideoGame>>> GetVideoGames()
         {
             return Ok(await _context.VideoGames.ToListAsync());
         }
        
         [HttpGet("{id}")]
         public async Task<ActionResult<VideoGame>> GetVideoGameById(int id) //recebe um it e retorna um tipo generico
         {
            var game = await _context.VideoGames.FindAsync(id);
             if (game is null) 
                 return NotFound();
             return Ok(game);
         }
        /* 
         [HttpPost]      //used when u want to creat something
         public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
         {
             if (newGame is null)
             {
                 return BadRequest();
             }
             newGame.Id = videoGames.Max(g => g.Id) + 1;
             videoGames.Add(newGame);
             return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
         }

         [HttpPut("{id}")]           // put troca todos, enquanto que patch troca um
         public IActionResult UpdateVideoGame (int id, VideoGame updatedGame)
         {
             var game = videoGames.FirstOrDefault(g => g.Id == id);
             if (game is null)
                 return NotFound();

             game.Title = updatedGame.Title;
             game.Platform = updatedGame.Platform;
             game.Platform = updatedGame.Developer;
             game.Platform = updatedGame.Publisher;

             return NoContent();
         }

         [HttpDelete("{id}")]        // entanda a rota(route) como "a maneira como vai acessar isso"
         public IActionResult DeleteVideoGame(int id)
         {
             var game = videoGames.FirstOrDefault(g => g.Id == id);
             if (game is null)
                 return NotFound();
             videoGames.Remove(game);
             return NoContent();
         }*/
    }
}
