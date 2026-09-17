using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinordleAPI;
using MinordleAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class LanguageBasesController : ControllerBase
{
    private readonly MinordleDbContext _context;
    public LanguageBasesController(MinordleDbContext context)
    {
        _context = context;
    }

    // GET: api/LanguageBase
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageBase>>> GetLanguageBase()
    {
        return await _context.Languages.ToListAsync();
    }

    // GET: api/LanguageBase/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LanguageBase>> GetLanguageBase(int id)
    {
        var languagebase = await _context.Languages.FindAsync(id);

        if (languagebase == null)
        {
            return NotFound();
        }

        return languagebase;
    }

    // PUT: api/LanguageBase/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLanguageBase(int? id, LanguageBase languagebase)
    {
        if (id != languagebase.Id)
        {
            return BadRequest();
        }

        _context.Entry(languagebase).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LanguageBaseExists(id))
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

    // POST: api/LanguageBase
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<LanguageBase>> PostLanguageBase(string languageName, string languageFamily, string languageDescription, string languageExample, string audioFile = "")
    {
        LanguageBase languagebase = new LanguageBase();
        languagebase.LanguageName = languageName;
        languagebase.LanguageFamily = languageFamily;
        languagebase.LanguageDescription = languageDescription;
        languagebase.LanguageExample = languageExample;
        languagebase.audioFile = audioFile;
        languagebase.GreenImg = $"/LanguageMapPNGs/{languageName}_Green.png";
        languagebase.YellowImg = $"/LanguageMapPNGs/{languageName}_Yellow.png";

        _context.Languages.Add(languagebase);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLanguageBase", new { id = languagebase.Id }, languagebase);
    }

    // DELETE: api/LanguageBase/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLanguageBase(int? id)
    {
        var languagebase = await _context.Languages.FindAsync(id);
        if (languagebase == null)
        {
            return NotFound();
        }

        _context.Languages.Remove(languagebase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LanguageBaseExists(int? id)
    {
        return _context.Languages.Any(e => e.Id == id);
    }
}
