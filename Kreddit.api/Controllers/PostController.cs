using Kreddit.api.Data;
using Kreddit.shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kreddit.api.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly DataContext _context;
    
    // Constructor
    public PostController(DataContext context)
    {
        _context = context;
    }
    
    // GET api/posts
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
        // Include the user
        var posts = await _context.Posts.Include(p => p.User).ToListAsync();
        return Ok(posts);
    }
    
    // GET api/posts/{id}
    [HttpGet ("{id}")]
    public async Task<ActionResult<Post>> GetPostById(int id)
    {
        // Include the user while fetching the post by its ID
        var post = await _context.Posts.Include(p => p.User).SingleOrDefaultAsync(p => p.Id == id);
    
        if (post == null)
        {
            return NotFound($"Post with ID {id} not found.");
        }
        return Ok(post);
    }
    
    // POST api/posts/create-post
    [HttpPost ("create-post")]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        if (string.IsNullOrWhiteSpace(post.Title))
        {
            return BadRequest("Post title should not be empty or whitespace.");
        }

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
            
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }
    
    // PUT api/posts/{id}/upvote-post
    [HttpPut ("{id}/upvote")]
    public async Task<ActionResult<Post>> UpvotePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound($"Post with ID {id} not found.");
        }
        post.Upvotes++;
        await _context.SaveChangesAsync();
        return Ok(post);
    }
    
    // PUT api/posts/{id}/downvote-post
    [HttpPut ("{id}/downvote")]
    public async Task<ActionResult<Post>> DownvotePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound($"Post with ID {id} not found.");
        }
        post.Downvotes++;
        await _context.SaveChangesAsync();
        return Ok(post);
    }
}