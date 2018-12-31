using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WoW_Toons
{
    public partial class UpdateForm : System.Web.UI.Page
    {
        /* VARIABLES */
        DataTable dataTable;
        SqlDataAdapter dataAdapter;
        SqlConnection connection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        ListItem selectToon = new ListItem("<Select Toon>", "0");
        const string NAME = "DBCS";
        string toonName, server, faction, race, _class, level, iLvl, gender;
        string[] words;
        int rowsUpdated = 0;

        /* QUERIES */
        const string QUERY_SELECTAS = 
            @"SELECT ToonName + \'-\' + ToonServer AS Toon 
              FROM tblToons 
              ORDER BY ToonServer, ToonName";

        const string QUERY_SELECT = 
            @"SELECT Id, ToonName, ToonServer, Faction, ToonRace, ToonClass, ToonLvl, ILvl, Gender 
              FROM tblToons 
              WHERE ToonName=@toonName AND ToonServer=@server";

        const string QUERY_UPDATE = 
            @"UPDATE tblToons 
              SET ToonName=@toonName, ToonServer=@server, Faction=@faction, ToonRace=@race, ToonClass=@_class, ToonLvl=@level, ILvl=@iLvl, Gender=@gender 
              WHERE Id=@id";

        protected void Page_Load(object sender, EventArgs e)
        {
            lnkUpdateToons.ForeColor = System.Drawing.Color.Red;
            dataTable = new DataTable();

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[NAME].ConnectionString))
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(QUERY_SELECTAS, connection);
                    dataAdapter.Fill(dataTable);

                    ddlToons.DataSource = dataTable;
                    ddlToons.DataTextField = "Toon";
                    ddlToons.DataBind();
                }
                catch (Exception ex) { Console.WriteLine("" + ex.StackTrace); }
            }



            if (!ddlToons.Items.Contains(selectToon))
            {
                ddlToons.Items.Insert(0, selectToon);
            }
        }
        protected void ddlToons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lblMessage.Text.Equals("")) lblMessage.Text = "";
            words = ddlToons.SelectedValue.ToString().Split('-');
            toonName = words[0];
            server = words[1];

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[NAME].ConnectionString))
            {
                sqlCommand = new SqlCommand(QUERY_SELECT, connection);
                sqlCommand.Parameters.AddWithValue("@toonName", toonName);
                sqlCommand.Parameters.AddWithValue("@server", server);
                connection.Open();

                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    txtClass.Text      = sqlDataReader["ToonClass"].ToString();
                    txtFaction.Text    = sqlDataReader["Faction"].ToString();
                    txtGender.Text     = sqlDataReader["Gender"].ToString();
                    txtItemLevel.Text  = sqlDataReader["ILvl"].ToString();
                    txtName.Text       = sqlDataReader["ToonName"].ToString();
                    txtRace.Text       = sqlDataReader["ToonRace"].ToString();
                    txtServer.Text     = sqlDataReader["ToonServer"].ToString();
                    txtToonLevel.Text  = sqlDataReader["ToonLvl"].ToString();
                    HiddenField1.Value = sqlDataReader["Id"].ToString();
                }
                else
                {
                    lblMessage.Text = "Character does not currently exist in database";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            toonName = txtName.Text;
            server = txtServer.Text;
            faction = txtFaction.Text;
            race = txtRace.Text;
            _class = txtClass.Text;
            level = txtToonLevel.Text;
            iLvl = txtItemLevel.Text;
            gender = txtGender.Text;

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[NAME].ConnectionString))
            {
                sqlCommand = new SqlCommand(QUERY_UPDATE, connection);
                sqlCommand.Parameters.AddWithValue("@id", HiddenField1.Value);
                sqlCommand.Parameters.AddWithValue("@toonName", toonName);
                sqlCommand.Parameters.AddWithValue("@server", server);
                sqlCommand.Parameters.AddWithValue("@faction", faction);
                sqlCommand.Parameters.AddWithValue("@race", race);
                sqlCommand.Parameters.AddWithValue("@_class", _class);
                sqlCommand.Parameters.AddWithValue("@level", level);
                sqlCommand.Parameters.AddWithValue("@iLvl", iLvl);
                sqlCommand.Parameters.AddWithValue("@gender", gender);
                connection.Open();

                rowsUpdated = sqlCommand.ExecuteNonQuery();

                if (rowsUpdated >= 1)
                {
                    lblMessage.Text = rowsUpdated + " row(s) successfully updated!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Failed to update row";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e) 
        {
            if (!lblMessage.Text.Equals("")) lblMessage.Text = "";
            words = ddlToons.SelectedValue.ToString().Split('-');
            toonName = words[0];
            server = words[1];

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[NAME].ConnectionString))
            {
                sqlCommand = new SqlCommand(QUERY_SELECT, connection);
                sqlCommand.Parameters.AddWithValue("@toonName", toonName);
                sqlCommand.Parameters.AddWithValue("@server", server);
                connection.Open();

                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    txtClass.Text = sqlDataReader["ToonClass"].ToString();
                    txtFaction.Text = sqlDataReader["Faction"].ToString();
                    txtGender.Text = sqlDataReader["Gender"].ToString();
                    txtItemLevel.Text = sqlDataReader["ILvl"].ToString();
                    txtName.Text = sqlDataReader["ToonName"].ToString();
                    txtRace.Text = sqlDataReader["ToonRace"].ToString();
                    txtServer.Text = sqlDataReader["ToonServer"].ToString();
                    txtToonLevel.Text = sqlDataReader["ToonLvl"].ToString();
                    HiddenField1.Value = sqlDataReader["Id"].ToString();
                }
                else
                {
                    lblMessage.Text = "Character does not currently exist in database";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void lnkViewToons_Click(object sender, EventArgs e) { Response.Redirect("WoW.aspx"); }
        protected void lnkAddToon_Click(object sender, EventArgs e) { Response.Redirect("AddForm.aspx"); }
        protected void lnkDeleteToon_Click(object sender, EventArgs e) { Response.Redirect("DeleteForm.aspx"); }
        protected void lnkAdvSearch_Click(object sender, EventArgs e) { Response.Redirect("AdvancedSearch.aspx"); }
    }
}