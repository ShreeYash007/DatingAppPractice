using System.Collections;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  public DataContext Context { get; }

  public UserController(DataContext context)
  {
        Context = context;
  }
    
  [HttpGet]
  public ActionResult<IEnumerable<AppUser>> GetUser()
  {
    var users = Context.Users.ToList();
    
    return users;

  }

  [HttpGet("{id}")]
  public ActionResult<AppUser> GetUser(int id)
  {
   return Context.Users.Find(id);
  }
}
