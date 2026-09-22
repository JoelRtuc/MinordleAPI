using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinordleAPI;
using MinordleAPI.Data;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly MinordleDbContext _context;
    public UsersController(MinordleDbContext context)
    {
        _context = context;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
        return await _context.Users.ToListAsync();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int? id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(string username, string password)
    {
        User newUser = new User();
        newUser.Username = username;
        newUser.Password = password;

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int? id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("{id:int}/profile-picture")]
    public async Task<ActionResult> UploadProfilePicture(int id, IFormFile file)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null) return NotFound();

        var allowed = new[] { "image/png", "image/jpeg", "image/webp" };
        if (!allowed.Contains(file.ContentType))
            return BadRequest("Unsupported image format.");

        var folder = Path.Combine("wwwroot", "ProfilePictures");
        Directory.CreateDirectory(folder); // ensure it exists

        var ext = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid()}{ext}";
        var fullPath = Path.Combine(folder, fileName);

        using (var stream = System.IO.File.Create(fullPath))
            await file.CopyToAsync(stream);

        user.ProfilePicturePath = $"/ProfilePictures/{fileName}";
        await _context.SaveChangesAsync();

        return Ok(new { user.ProfilePicturePath });
    }

    private bool UserExists(int? id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}
