using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaEndpoint.Models;
using DeltaEndpoint.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeltaEndpoint.Controllers
{
    [Route("api/Incident")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        [Route("getall")]
        [HttpGet]
        public ActionResult<IEnumerable<Incident>> Get()
        {
            var incidents = _incidentService.GetAllIncident();
            return Ok(incidents);
        }

        [Route("GetLocation")]
        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocation()
        {
            var locations = _incidentService.GetAllLocation();
            return Ok(locations);
        }

        [Route("GetIncidentType")]
        [HttpGet]
        public ActionResult<IEnumerable<IssueType>> GetIncidentType()
        {
            var issueCategoty = _incidentService.GetAllIssueType();
            return Ok(issueCategoty);
        }

        [Route("GetIncidentById")]
        [HttpGet]
        public ActionResult<IEnumerable<Incident>> GetIncidentById(long mobileNumber)
        {
            // if(!ModelState.IsValid)
            // return NoContent();
            
          
            var incidentResult = _incidentService.GetIncidentById(mobileNumber);
            return Ok(incidentResult);
        }

        // GET api/incident/5
       
        [Route("GetById")]
        [HttpGet("{id}")]
        public ActionResult<Incident> Get([FromQuery] int id)
        {
            var incident = _incidentService.GetIncident(id);
            return Ok(incident);
        }

        // POST api/incident
        [HttpPost]
        public ActionResult Post(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }
            _incidentService.PostIncident(incident);
            return Ok();
        }

    }
}