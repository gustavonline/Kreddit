using Kreddit.api.Data;
using Kreddit.shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kreddit.api.Controllers;

[ApiController]
[Route("api")]
public class PostController : ControllerBase
{
    private readonly DataContext _context;
    
    // Constructor
    public PostController(DataContext context)
    {
        _context = context;
    }
    
    // GET api/allposts
    [HttpGet ("allposts")]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
        return Ok(await _context.Posts.ToListAsync());
    }
    
    // GET api/post/{id}
    [HttpGet ("post/{id}")]
    public async Task<ActionResult<Post>> GetPostById(int id)
    {
        return Ok(await _context.Posts.FindAsync(id));
    }
    
    // POST api/create-post
    [HttpPost ("create-post")]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        if (string.IsNullOrWhiteSpace(post.Title))
        {
            return BadRequest("Post title should not be empty or whitespace.");
        } 

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return Ok(await _context.Posts.ToListAsync());
    }
}