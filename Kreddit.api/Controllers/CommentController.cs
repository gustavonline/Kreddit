using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kreddit.api.Data;
using Kreddit.shared.Models;

namespace Kreddit.api.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }



      
        // POST: api/posts/{postId}/comments
        [HttpPost ("posts/{postId}/comments")]
        public async Task<ActionResult<Comment>> CreateComment(int postId, Comment comment)
        {

            // Remove post lookup  

            // Add comment 
            _context.Comments.Add(comment);

            // Save changes
            await _context.SaveChangesAsync();

            return Ok(comment);

        }

    }
}
