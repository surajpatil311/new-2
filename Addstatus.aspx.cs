using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using synbuf.component.bl;
using System.Configuration;
using System.Data;

namespace ThreeWebApplication2
{
    public partial class Addstatus : System.Web.UI.Page
    {
        AssignSubTaskDetails cdl = new AssignSubTaskDetails();
        AssignSubTaskBL cbl = new AssignSubTaskBL();
       
        public Addstatus()
        {
            connectionDB();
        }
        public bool connectionDB()
        {
            return cbl.connection(ConfigurationManager.AppSettings["connectionstring"]);
        }
        protected void Page_Load(object sender, EventArgs e)
       {
           if (!IsPostBack)
           {
               from1.Visible = false;
               DataTable dt = new DataTable();
               dt = cbl.selecttable();
               GridView1.DataSource = dt;
               GridView1.DataBind();
               SetInitialRow();
           }
        }
        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Srno", typeof(string)));
            dt.Columns.Add(new DataColumn("clientname", typeof(string)));
            dt.Columns.Add(new DataColumn("taskname", typeof(string)));
            dt.Columns.Add(new DataColumn("subtaskname", typeof(string)));
            dt.Columns.Add(new DataColumn("empname", typeof(string)));
            dt.Columns.Add(new DataColumn("assigndate", typeof(string)));
            dt.Columns.Add(new DataColumn("DeadlineDate", typeof(string)));
            dt.Columns.Add(new DataColumn("Remark", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            DataTable data1 = new DataTable();
            data1=cbl.getdataingridview();
            for(int i=0;i<data1.Rows.Count;i++)
            {
                if (data1.Rows[i].ItemArray[5].ToString() == "")
                {
                    dr = dt.NewRow();
                    dr["Srno"] = data1.Rows[i].ItemArray[0].ToString();
                    dr["clientname"] = data1.Rows[i].ItemArray[1].ToString();
                    dr["taskname"] = data1.Rows[i].ItemArray[2].ToString();
                    dr["subtaskname"] = data1.Rows[i].ItemArray[3].ToString();
                    dr["empname"] = data1.Rows[i].ItemArray[4].ToString();
                    dr["assigndate"] = data1.Rows[i].ItemArray[6].ToString();
                    dr["DeadlineDate"] = data1.Rows[i].ItemArray[7].ToString();
                    dr["Remark"] = data1.Rows[i].ItemArray[9].ToString();
                    dr["Status"] = string.Empty;
                }
                else
                {
                    dr = dt.NewRow();
                    dr["Srno"] = data1.Rows[i].ItemArray[0].ToString();
                    dr["clientname"] = data1.Rows[i].ItemArray[1].ToString();
                    dr["taskname"] = data1.Rows[i].ItemArray[2].ToString();
                    dr["subtaskname"] = data1.Rows[i].ItemArray[3].ToString();
                    dr["empname"] = data1.Rows[i].ItemArray[5].ToString();
                    dr["assigndate"] = data1.Rows[i].ItemArray[6].ToString();
                    dr["DeadlineDate"] = data1.Rows[i].ItemArray[7].ToString();
                    dr["Remark"] = data1.Rows[i].ItemArray[9].ToString();
                    dr["Status"] = string.Empty;
                }
                dt.Rows.Add(dr);

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

       
        }
        

        protected void save_Click(object sender, EventArgs e)
        {
            
        }

        protected void save_Click1(object sender, EventArgs e)
        {
            int rowIndex = 0;
            for (int i = 1; i <= GridView1.Rows.Count; i++)
            {
                Label lblsrno = (Label)GridView1.Rows[rowIndex].Cells[0].FindControl("lablesrno");
                cdl.srno = Convert.ToInt32(lblsrno.Text);
                Label lblclientname = (Label)GridView1.Rows[rowIndex].Cells[1].FindControl("lableclientname");
               cdl.clientname = lblclientname.Text;
               Label lbltaskname = (Label)GridView1.Rows[rowIndex].Cells[2].FindControl("labletaskname");
               cdl.taskname = lbltaskname.Text;
               Label lblsubtaskname = (Label)GridView1.Rows[rowIndex].Cells[3].FindControl("lablesubtaskname");
               cdl.subtaskname = lblsubtaskname.Text;
               Label lblempname = (Label)GridView1.Rows[rowIndex].Cells[4].FindControl("lableempname");
               cdl.empname = lblempname.Text;
               Label lblassigndate = (Label)GridView1.Rows[rowIndex].Cells[5].FindControl("lableassigndate");
               cdl.assigndate = lblassigndate.Text;
               TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("labletxtdeadlinedate");
               
                TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("Remark");

                DropDownList dp1 = (DropDownList)GridView1.Rows[rowIndex].Cells[8].FindControl("DropDownList1");
                cdl.status = dp1.SelectedItem.Text;
                cdl.remark = box1.Text;

                //cdl.deadlinesdate = box2.Text;
                cdl.approvetask = "false";
                cbl.updateaddstatus(cdl);

                rowIndex++;

            }
            string message = "Add Status Succesfully";
            string url = "Home1.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }

        protected void search_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
           
            if (DropDownList1.SelectedItem.Text == "Client Name")
            {
                cdl.search = txtsearch.Text;
                dt = cbl.searchrecord(cdl);
            }
            else if (DropDownList1.SelectedItem.Text == "Task Name")
            {
                cdl.search = txtsearch.Text;
                dt = cbl.searchbytaskname(cdl);
            }
            else if (DropDownList1.SelectedItem.Text == "Sub Task Name")
            {
                cdl.search = txtsearch.Text;
                dt = cbl.searchbysubtaskname(cdl);
            }
            else if (DropDownList1.SelectedItem.Text == "Employee Name")
            {
                cdl.search = txtsearch.Text;
                dt = cbl.searchbyempname(cdl);
            }
            else if (DropDownList1.SelectedItem.Text == "Date")
            {
                cdl.search = txtsearch.Text;
                dt = cbl.searchbyassigndate(cdl);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (DropDownList1.SelectedItem.Text == "Date")
            {
                from1.Visible = true;
                
            }        
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = cbl.selecttable();
            GridView1.DataSource = dt;
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Date")
            {
                from1.Visible = true;

            }    
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = cbl.selectstatus();
            int rowindex = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)GridView1.Rows[rowindex].Cells[8].FindControl("DropDownList1");
                    box1.SelectedItem.Text = dt.Rows[i].ItemArray[10].ToString();
                 
                    rowindex++;
                }
            }
        
        }

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
}
}
        


