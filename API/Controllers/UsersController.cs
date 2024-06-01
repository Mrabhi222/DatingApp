using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext context;
    public UsersController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await  context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await context.Users.FindAsync(id);
    }
}
