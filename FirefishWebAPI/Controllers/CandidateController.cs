using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using FirefishAPIProject.Models;

namespace FirefishWebAPI.Controllers
{
    [RoutePrefix("api/Candidates")]
    public class CandidateController : ApiController
    {
        CandidateDataAccessLayer CDAL = new CandidateDataAccessLayer();

        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            return Json(CDAL.GetCandidates());
        }

        // POST: api/Inventory
        [HttpPost, Route("")]
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult PostCandidate(Candidate candidate)
        {
            
        if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CDAL.AddCandidate(candidate);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            return CreatedAtRoute("DisplayRoute", new { id = candidate.candidateID }, candidate);
        }

        [HttpPut, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCandidate(int id, Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CDAL.UpdateCandidate(id, candidate);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        // GET: api/Candidates/5
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> GetCandidate(int id)
        {
            Candidate candidate = CDAL.GetOne(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok();
        }


    }
}