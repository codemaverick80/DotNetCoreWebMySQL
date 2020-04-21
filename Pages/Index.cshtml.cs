using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebMySQL.DataEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotNetCoreWebMySQL.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public MusicDbContext _context;

    public IndexModel(ILogger<IndexModel> logger, MusicDbContext context)
    {

      _context = context ?? throw new ArgumentNullException(nameof(context));
      _logger = logger;
    }


    public List<Genre> Genres { get; set; }


    public async Task OnGetAsync()
    {
      Genres = await _context.Genre.ToListAsync();

    }

  }
}
