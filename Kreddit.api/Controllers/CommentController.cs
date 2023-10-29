using Microsoft.AspNetCore.Mvc;
using Kreddit.api.Data;
using Kreddit.shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Kreddit.api.Controllers
{
    [Route("api/posts/{postId}")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }
        
        // GET: api/posts/{postId}/comments
        [HttpGet("comments")]
        public async Task<ActionResult<List<Comment>>> GetComments(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return NotFound($"Post with ID {postId} not found.");
            }

            var comments = await _context.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User) // Include the user for each comment
                .ToListAsync();

            return Ok(comments);
        }
        

      
        // POST: api/posts/{postId}/create-comment
        [HttpPost("create-comment")]
        public async Task<ActionResult<Comment>> CreateComment(int postId, Comment comment)
        {
            if (postId <= 0)
            {
                return BadRequest("Invalid PostId.");
            }

            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return NotFound($"Post with ID {postId} not found.");
            }

            if (string.IsNullOrWhiteSpace(comment.Title))
            {
                return BadRequest("Comment title should not be empty or whitespace.");
            }

            // Set the PostId in the Comment object.
            comment.PostId = postId;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateComment), new { postId = postId, id = comment.Id }, comment);
        }
    }
}
