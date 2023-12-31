﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  public DataContext Context { get; }

  public UsersController(DataContext context)
  {
        Context = context;
  }
    
  [HttpGet]
  public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
  {
    var users = await Context.Users.ToListAsync();
    
    return users;

  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AppUser>> GetUser(int id)
  {
   return await Context.Users.FindAsync(id);
  }
}
