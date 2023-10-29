using System.Net.Http.Json;
using System.Text.Json;
using Kreddit.shared.Models;

namespace Kreddit.client.Services;

public class CommentService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public CommentService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }
    
    public async Task<Comment[]> GetComments(int postId)
    {
        string url = $"{baseAPI}posts/{postId}/comments/";
        return await http.GetFromJsonAsync<Comment[]>(url);
    }
    
    public async Task<Comment> CreateComment(int postId,Comment comment)
    {
        string url = $"{baseAPI}posts/{postId}/comments";
     
        // Post JSON to API, save the HttpResponseMessage
        HttpResponseMessage msg = await http.PostAsJsonAsync(url, new { comment });

        // Get the JSON string from the response
        string json = msg.Content.ReadAsStringAsync().Result;

        // Deserialize the JSON string to a Comment object
        Comment? newComment = JsonSerializer.Deserialize<Comment>(json, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true // Ignore case when matching JSON properties to C# properties 
        });

        // Return the new comment 
        return newComment;
    }
}