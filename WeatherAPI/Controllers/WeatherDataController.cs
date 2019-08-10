using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class WeatherDataController : ApiController
    {

        private WeatherIOTEntities4 db = new WeatherIOTEntities4();
        ///Add new Weather_Data
        [HttpPost, Route("api/AddNewWeatherData")]
        public IHttpActionResult AddNewWeather_Data(Weather_Data Weather_Data)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    db.Weather_Data.Add(Weather_Data);
                    db.SaveChanges();
                    return Ok(Weather_Data);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Get all Weather_Datas
        [HttpGet, Route("api/GetAllWeatherData")]
        public IHttpActionResult GetAllWeather_Data()
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    return Ok(db.Weather_Data);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Get Weather_Data by id
        [HttpGet, Route("api/GetWeatherDataById")]
        public IHttpActionResult GetWeather_DataById(int id)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    return Ok(db.Weather_Data.Find(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Update Weather_Data by id
        [HttpPost, Route("api/UpdateWeatherDataById")]
        public IHttpActionResult UpdateWeather_DataById(int id, Weather_Data Weather_Data)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    db.Entry(Weather_Data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok(Weather_Data);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///Delete Weather_Data by id
        [HttpDelete, Route("api/DeleteWeatherDataById")]
        public IHttpActionResult UpdateWeather_DataById(int id)
        {
            Task<IHttpActionResult> httpActionResult = Task<IHttpActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    Weather_Data Weather_Data = db.Weather_Data.Find(id);
                    if (Weather_Data == null)
                    {
                        return NotFound();
                    }

                    db.Weather_Data.Remove(Weather_Data);
                    db.SaveChanges();
                    return Ok(Weather_Data);
                }
                catch (Exception ex)
                {
                    return BadRequest(string.Format("Error:{0}", ex.Message));
                }

            });
            return httpActionResult.Result;
        }

        ///is it exist
        private bool Weather_DataExists(int id)
        {
            return db.Weather_Data.Count(e => e.Id == id) > 0;

        }
    }
}
