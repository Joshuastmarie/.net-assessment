using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;

public partial class artistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            var artistId = Request.QueryString["artistId"];
            var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");
            var row = data.Select($"artistID = {artistId}").FirstOrDefault();
            var artistArray = row.ItemArray;

            ArtistBio.Text = artistArray[3] as string;
            Hero.ImageUrl = artistArray[5] as string;
            BannerImage.ImageUrl = artistArray[4] as string;

            //Gets the top three song rows.
            var songData = sql.ExecuteStoredProcedureDT("ArtistSongs")
                .AsEnumerable()
                .Take(3)
                .CopyToDataTable();

            songList.DataSource = songData;
            songList.DataBind();
        }
        catch (Exception ex)
        {
            return;
        }
    }
}