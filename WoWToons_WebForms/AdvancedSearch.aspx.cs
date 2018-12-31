using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoW_Toons
{
    public partial class AdvancedSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkAdvSearch.ForeColor = System.Drawing.Color.Red;
        }

        protected void lnkViewToons_Click(object sender, EventArgs e) { Response.Redirect("WoW.aspx"); }
        protected void lnkUpdateToons_Click(object sender, EventArgs e) { Response.Redirect("UpdateForm.aspx"); }
        protected void lnkAddToon_Click(object sender, EventArgs e) { Response.Redirect("AddForm.aspx"); }
        protected void lnkDeleteToon_Click(object sender, EventArgs e) { Response.Redirect("DeleteForm.aspx"); }
    }
}