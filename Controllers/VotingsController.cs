using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_Test.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace Demo_Test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VotingsController : ControllerBase
    {
        private readonly xtremax_demoContext _context;

        public VotingsController(xtremax_demoContext context)
        {
            _context = context;
        }

        // GET: api/Votings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voting>>> GetVotings()
        {
            //Eager loading
            var includedVoting = _context.Votings
                                    .Include(vot => vot.Category)
                                    .Include(vot => vot.Votes)
                                        .ThenInclude(votes => votes.Client);
            //return await _context.Votings.ToListAsync();
            return await includedVoting.ToListAsync();

            ////Explicit loading
            //var votings = await _context.Votings.ToListAsync();

            //_context.Entry(votings)
            //    .Reference(vot => vot.Category)
            //    .Load();

            //return votings;
        }

        // GET: api/Votings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voting>> GetVoting(int id)
        {
            var voting = _context.Votings
                                    .Include(vot => vot.Category)
                                    .Include(vot => vot.Votes)
                                        .ThenInclude(votes => votes.Client)
                                    .Where(vot => vot.Id == id)
                                    .FirstOrDefault();

            if (voting == null)
            {
                return NotFound();
            }

            return voting;
        }

        [Authorize]
        // PUT: api/Votings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoting(int id, Voting voting)
        {
            if (id != voting.Id)
            {
                return BadRequest();
            }

            _context.Entry(voting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotingExists(id))
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

        // POST: api/Votings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voting>> PostVoting(Voting voting)
        {
            _context.Votings.Add(voting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoting", new { id = voting.Id }, voting);
        }

        // DELETE: api/Votings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voting>> DeleteVoting(int id)
        {
            var voting = await _context.Votings.FindAsync(id);
            if (voting == null)
            {
                return NotFound();
            }

            _context.Votings.Remove(voting);
            await _context.SaveChangesAsync();

            return voting;
        }

        private bool VotingExists(int id)
        {
            return _context.Votings.Any(e => e.Id == id);
        }
    }
}
