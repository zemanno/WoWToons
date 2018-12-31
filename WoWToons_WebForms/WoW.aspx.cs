using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WoW_Toons
{
    public partial class WoW : System.Web.UI.Page
    {
        /* VARIABLES */
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        /* QUERY(IES) */
        const string QUERY_SELECT = 
            @"SELECT ToonName, ToonServer, Faction, ToonRace, ToonClass, ToonLvl, ILvl, Gender, CanTank, CanHeal 
              FROM tblToons 
              ORDER BY ToonLvl DESC, ToonServer";

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkViewToons.ForeColor = System.Drawing.Color.Red;


            using (sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                sqlDataAdapter = new SqlDataAdapter(QUERY_SELECT, sqlConnection);

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "tblToons");

                Cache["DataSet"] = dataSet;
                gridToons.DataSource = dataSet;
                gridToons.DataBind();
            }
        }
        protected void lnkUpdateToons_Click(object sender, EventArgs e) { Response.Redirect("UpdateForm.aspx"); }
        protected void lnkAddToon_Click(object sender, EventArgs e) { Response.Redirect("AddForm.aspx"); }
        protected void lnkDeleteToon_Click(object sender, EventArgs e) { Response.Redirect("DeleteForm.aspx"); }
        protected void lnkAdvSearch_Click(object sender, EventArgs e) { Response.Redirect("AdvancedSearch.aspx"); }
    }
}