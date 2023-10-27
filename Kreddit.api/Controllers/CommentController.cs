using Microsoft.AspNetCore.Mvc;
using Kreddit.api.Data;
using Kreddit.shared.Models;

namespace Kreddit.api.Controllers
{
    [Route("api/posts/{postId}/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }
        

      
        // POST: api/posts/{postId}/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(int postId, Comment comment)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return NotFound($"Post with ID {postId} not found.");
            }

            if (string.IsNullOrWhiteSpace(comment.Title)) 
            {
                return BadRequest("Comment title should not be empty or whitespace.");
            }

            comment.PostId = postId;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateComment), new { postId = postId, id = comment.Id }, comment);
        }
    }
}
