using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShelterDAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebApplication1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AnShelterIdenContext _context;
        private readonly JWTSettings _jwtsettings;

        public UsersController(AnShelterIdenContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }

        // GET: api/Users
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<Volonter>>> GetUsers()
        {
            return await _context.Volonters.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<Volonter>> GetUser(int id)
        {
            var user = await _context.Volonters.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/5
        [HttpGet("GetUserDetails/{id}")]
        public async Task<ActionResult<Volonter>> GetUserDetails(int id)
        {
            var user = await _context.Volonters.Include(u => u.Role)
                                            .Where(u => u.Idvolonters == id)
                                            .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users

        [HttpPost("Login")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody] Volonter user)
        {
            user = await _context.Volonters.Include(u => u.Role)
                                        .Where(u => u.EMail == user.EMail
                                                && u.Password == user.Password).FirstOrDefaultAsync();

            UserWithToken userWithToken = new UserWithToken(user);


            if (userWithToken == null)
            {
                return NotFound();
            }


            //    //sign your token here here..
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.EMail)
                }),
                Expires = DateTime.UtcNow.AddMinutes(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        UserWithToken.Token = tokenHandler.WriteToken(token);

            return userWithToken;
        }
            

            //// PUT: api/Users/5
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
            //// more details see https://aka.ms/RazorPagesCRUD.
            [HttpPut("UpdateUser/{id}")]
            public async Task<IActionResult> PutUser(int id, Volonter user)
            {
                if (id != user.Idvolonters)
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

            // POST: api/Users
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPost("CreateUser")]
            public async Task<ActionResult<Volonter>> PostUser(Volonter user)
            {
                _context.Volonters.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.Idvolonters }, user);
            }

            // DELETE: api/Users/5
            [HttpDelete("DeleteUser/{id}")]
            public async Task<ActionResult<Volonter>> DeleteUser(int id)
            {
                var user = await _context.Volonters.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                _context.Volonters.Remove(user);
                await _context.SaveChangesAsync();

                return user;
            }

            private bool UserExists(int id)
            {
                return _context.Volonters.Any(e => e.Idvolonters == id);
            }
        
      }
}