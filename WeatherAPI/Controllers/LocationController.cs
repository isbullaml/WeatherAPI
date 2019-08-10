using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class LocationController : ApiController
    {
        private WeatherIOTEntities4 db =new WeatherIOTEntities4();

        ///Add new location
        [HttpPost, Route("api/AddNewLocation")]
        public IHttpActionResult AddNewLocation(Location location)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    db.Locations.Add(location);
                    db.SaveChanges();
                    return Ok(location);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}",ex.Message));
                }
             
            });
            return httpActionResult.Result;
        }

        ///Get all locations
        [HttpGet, Route("api/GetAllLocation")]
        public IHttpActionResult GetAllLocation()
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    return Ok(db.Locations);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Get location by id
        [HttpGet, Route("api/GetLocationById")]
        public IHttpActionResult GetLocationById(int id)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    return  Ok(db.Locations.Find(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Update location by id
        [HttpPost, Route("api/UpdateLocationById")]
        public IHttpActionResult UpdateLocationById(int id, Location location)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    db.Entry(location).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok(location);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Delete location by id
        [HttpDelete, Route("api/DeleteLocationById")]
        public IHttpActionResult UpdateLocationById(int id)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    Location location = db.Locations.Find(id);
                    if (location == null)
                    {
                        return NotFound();
                    }

                    db.Locations.Remove(location);
                    db.SaveChanges();
                    return Ok(location);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///is it exist
        private bool LocationExists(int id)
        {
            return db.Locations.Count(e => e.Id == id) > 0;
           
        }
    }
}