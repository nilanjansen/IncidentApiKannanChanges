using DeltaEndpoint.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaEndpoint.Service
{
    public interface IIncidentService
    {
        Incident GetIncident(int IncidentId);

        IEnumerable<Incident> GetIncidentById(long mobileNumber);
        IEnumerable<Incident> GetAllIncident();

        IEnumerable<Location> GetAllLocation();

        IEnumerable<IssueType> GetAllIssueType();
        void PostIncident(Incident incident);

    }
    public class IncidentService : IIncidentService
    {
        private readonly deltastoreContext _dbContext;
        public IncidentService(deltastoreContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Incident> GetAllIncident()
        {
            var incidents = _dbContext.Incident.ToList();
           // return incidents;
          return IncidentStatus(incidents);
        }

        public IEnumerable<Location> GetAllLocation()
        {
            var locations = _dbContext.Locations.ToList();
            return locations;
        }

         public IEnumerable<IssueType> GetAllIssueType()
        {
            var issueTypeDetails = _dbContext.IssueType.ToList();
            return issueTypeDetails;
        }

        private IList<Incident> IncidentStatus(IList<Incident> incidentStatus)
        {
            Incident incidentObj=null;
            IList<Incident> incidentList = new List<Incident>();
            foreach (var item in incidentStatus)
            {
                incidentObj =new Incident();

                if (item.Status  == "C")
                    item.Status = "Completed";
                else if (item.Status == "N")
                    item.Status = "New";
                else
                    item.Status = "In Progress";

                    incidentObj = item;
                   incidentList.Add(incidentObj);
            }
           return incidentList;
        }

        public Incident GetIncident(int Id)
        {
            var Incident = _dbContext.Incident.ToList().FirstOrDefault(x => x.IncidentId == Id);
            return Incident;
        }

       public IEnumerable<Incident> GetIncidentById(long mobileNumber)
        {
                                   
           var incidentDetails =  _dbContext.Incident.Where(m => m.CreatorContact == mobileNumber).ToList();

            return incidentDetails;
        }

        public void PostIncident(Incident incident)
        {
            try
            {
                
                if (incident != null)
                {
                    incident.Status = "N";
                    _dbContext.Incident.Add(incident);
                    _dbContext.SaveChanges();
                }
                
            }
            catch (DbUpdateException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
