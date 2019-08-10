using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class DeviceController : ApiController
    {
        private WeatherIOTEntities4 db = new WeatherIOTEntities4();

        ///Add new device
        [HttpPost, Route("api/AddNewDevice")]
        public IHttpActionResult AddNewDevice(Device device)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    db.Devices.Add(device);
                    db.SaveChanges();
                    return Ok(device);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Get all devices
        [HttpGet, Route("api/GetAllDevice")]
        public IHttpActionResult GetAllDevice()
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    return Ok(db.Devices);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Get device by id
        [HttpGet, Route("api/GetDeviceById")]
        public IHttpActionResult GetDeviceById(int id)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    return Ok(db.Devices.Find(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Update device by id
        [HttpPost, Route("api/UpdateDeviceById")]
        public IHttpActionResult UpdateDeviceById(int id, Device device)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    db.Entry(device).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok(device);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Delete device by id
        [HttpDelete, Route("api/DeleteDeviceById")]
        public IHttpActionResult UpdateDeviceById(int id)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    Device device = db.Devices.Find(id);
                    if (device == null)
                    {
                        return NotFound();
                    }

                    db.Devices.Remove(device);
                    db.SaveChanges();
                    return Ok(device);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///is it exist
        private bool DeviceExists(int id)
        {
            return db.Devices.Count(e => e.Id == id) > 0;

        }
    }
}
