using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WoW_Toons
{
    public partial class AddForm : System.Web.UI.Page
    {
        /* VARIABLES */
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        SqlCommand sqlCommand;
        int rowsInserted = 0;
        string toonName, server, faction, race, _class, level, iLvl, gender, canTank, canHeal;

        /* QUERY(IES) */
        const string QUERY_INSERT = 
            @"INSERT INTO tblToons (ToonName, ToonServer, Faction, ToonRace, ToonClass, ToonLvl, ILvl, Gender, CanTank, CanHeal) 
              VALUES(@toonName, @server, @faction, @race, @_class, @level, @iLvl, @gender, @canTank, @canHeal)";
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            toonName = txtName.Text;
            server = txtServer.Text;
            faction = txtFaction.Text;
            race = txtRace.Text;
            _class = txtClass.Text;
            level = txtToonLevel.Text;
            iLvl = txtItemLevel.Text;
            gender = txtGender.Text;
            canTank = txtCanTank.Text;
            canHeal = txtCanHeal.Text;

            using (sqlConnection)
            {
                sqlCommand = new SqlCommand(QUERY_INSERT, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@toonName", toonName);
                sqlCommand.Parameters.AddWithValue("@server", server);
                sqlCommand.Parameters.AddWithValue("@faction", faction);
                sqlCommand.Parameters.AddWithValue("@race", race);
                sqlCommand.Parameters.AddWithValue("@_class", _class);
                sqlCommand.Parameters.AddWithValue("@level", level);
                sqlCommand.Parameters.AddWithValue("@iLvl", iLvl);
                sqlCommand.Parameters.AddWithValue("@gender", gender);
                sqlCommand.Parameters.AddWithValue("@canTank", canTank);
                sqlCommand.Parameters.AddWithValue("@canHeal", canHeal);
                sqlConnection.Open();

                rowsInserted = sqlCommand.ExecuteNonQuery();

                if (rowsInserted == 1)
                {
                    lblMessage.Text = "Toon has been successfully added!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("WoW.aspx");
                }
                else
                {
                    lblMessage.Text = "Error encountered while trying to add toon";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            
        }
        protected void lnkAdvSearch_Click(object sender, EventArgs e) { Response.Redirect("AdvancedSearch.aspx"); }
        protected void lnkViewToons_Click(object sender, EventArgs e) { Response.Redirect("WoW.aspx"); }
        protected void lnkUpdateToons_Click(object sender, EventArgs e) { Response.Redirect("UpdateForm.aspx"); }
        protected void lnkDeleteToon_Click(object sender, EventArgs e) { Response.Redirect("DeleteForm.aspx"); }
        protected void Page_Load(object sender, EventArgs e) { lnkAddToon.ForeColor = System.Drawing.Color.Red; }
    }
}