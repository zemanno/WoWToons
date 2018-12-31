using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WoW_Toons
{
    public partial class DeleteForm : System.Web.UI.Page
    {
        /* VARIABLES */
        DataTable dataTable;
        SqlDataAdapter dataAdapter;
        SqlConnection connection;
        SqlCommand sqlCommand;
        string _name, _server;
        string[] words;
        int rowsDeleted;

        /* QUERY(IES) */
        const string QUERY_SELECT = 
            @"SELECT ToonName + \'-\' + ToonServer AS Toon 
              FROM tblToons 
              ORDER BY ToonServer, ToonName";

        const string QUERY_DELETE = 
            @"DELETE FROM tblToons 
              WHERE ToonName=@_name AND ToonServer=@_server";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDeleteToon.ForeColor = System.Drawing.Color.Red;
            dataTable = new DataTable();

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(QUERY_SELECT, connection);
                    dataAdapter.Fill(dataTable);

                    ddlToons.DataSource = dataTable;
                    ddlToons.DataTextField = "Toon";
                    ddlToons.DataBind();
                }
                catch(Exception ex) { }
            }
            ddlToons.Items.Insert(0, new ListItem("<Select Toon>", "0"));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            words = ddlToons.SelectedValue.ToString().Split('-');
            _name = words[0];
            _server = words[1];

            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                sqlCommand = new SqlCommand(QUERY_DELETE, connection);
                sqlCommand.Parameters.AddWithValue("@_name", _name);
                sqlCommand.Parameters.AddWithValue("@_server", _server);
                connection.Open();

                rowsDeleted = sqlCommand.ExecuteNonQuery();

                if (rowsDeleted == 1)
                {
                    lblLabel.Text = rowsDeleted + " row(s) deleted!";
                    lblLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblLabel.Text = "Failed to delete row";
                    lblLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void lnkViewToons_Click(object sender, EventArgs e) { Response.Redirect("WoW.aspx"); }
        protected void lnkUpdateToons_Click(object sender, EventArgs e) { Response.Redirect("UpdateForm.aspx"); }
        protected void lnkAdvSearch_Click(object sender, EventArgs e) { Response.Redirect("AdvancedSearch.aspx"); }
        protected void lnkAddToon_Click(object sender, EventArgs e) { Response.Redirect("AddForm.aspx"); }
    }
}