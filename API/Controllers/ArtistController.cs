using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using DataAccess;

namespace API.Controllers
{
    public class ArtistController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Search(string name)
        {
            var sql = new SQL();
            try
            {
                var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");
                var row = data.Select($"title = '{name}'").FirstOrDefault();

                return Ok(MapToArtist(row));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            return Created("", "");
        }

        private Artist MapToArtist(DataRow row)
        {
            var rowArray = row.ItemArray;
            int Id;
            int.TryParse(rowArray[0] as string, out Id);
            var artist = new Artist();
            artist.Id = Id;
            artist.ImageUrl = rowArray[4] as string;
            artist.HeroUrl = rowArray[5] as string;
            artist.Biography = rowArray[3] as string;
            return artist;
        }
    }
}
