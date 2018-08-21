using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace simpleform
{
    public partial class simplewebform : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString);
            
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Display(); 
        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("show", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (save.Text == "save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insrt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@age", age.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if (save.Text == "update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",ViewState["upt"]);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@age", age.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();

            }
        }
        public void Clear()
        {
            name.Text = "";
            address.Text = "";
            age.Text = "";
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DLT") {
                con.Open();
                SqlCommand cmd = new SqlCommand("DLT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if (e.CommandName=="EDT")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EDT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                cmd.ExecuteNonQuery();
                con.Close();
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    name.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    age.Text = ds.Tables[0].Rows[0]["age"].ToString();
                    address.Text = ds.Tables[0].Rows[0]["address"].ToString();
                    save.Text = "update";
                    ViewState["upt"] = e.CommandArgument;
                }
            }
        }
    }
}