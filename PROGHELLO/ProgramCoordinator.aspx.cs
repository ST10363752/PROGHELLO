﻿using System;
using System.Data;
using System.Web.UI.WebControls;

namespace PROGHELLO
{
    public partial class ProgrammeCoordinator : System.Web.UI.Page
    {
        private DataTable claimsTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize the DataTable for storing claims
                claimsTable = new DataTable();
                claimsTable.Columns.Add("ClaimNo");
                claimsTable.Columns.Add("LecturerName");
                claimsTable.Columns.Add("ProgramCode");
                claimsTable.Columns.Add("ModuleCode");
                claimsTable.Columns.Add("Rate");
                claimsTable.Columns.Add("Hours");
                claimsTable.Columns.Add("ClaimAmount");
                claimsTable.Columns.Add("AttachedDocuments");
                claimsTable.Columns.Add("Status");

                // Add some sample claims
                AddSampleClaims();

                // Store the DataTable in ViewState to persist data across postbacks
                ViewState["Claims"] = claimsTable;

                // Bind data to the GridView
                BindClaimsGrid();
            }
            else
            {
                // Retrieve the DataTable from ViewState on postback
                claimsTable = ViewState["Claims"] as DataTable;
            }
        }

        private void AddSampleClaims()
        {
            claimsTable.Rows.Add("C001", "Amile", "PROG6212", "Database(Intermediate)", 100, 10, 1000, "doc1.pdf", "Pending");
            claimsTable.Rows.Add("C002", "Landile", "HCIN6212", "Human Computer Interaction", 150, 8, 1200, "doc2.pdf", "Pending");
            claimsTable.Rows.Add("C003", "Rachel", "DATA622", "IT Project Management", 90, 10, 900, "doc3.pdf", "Pending");
            claimsTable.Rows.Add("C004", "Sanele", "IPMA6212", "Programming 2B", 110, 11, 1320, "doc4.pdf", "Pending");
        }

        private void BindClaimsGrid()
        {
            gvClaims.DataSource = claimsTable;
            gvClaims.DataBind();
        }

        protected void gvClaims_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve" || e.CommandName == "Reject")
            {
                // Retrieve the claim number from CommandArgument
                string claimNo = e.CommandArgument.ToString();

                // Find the row in the DataTable by claim number
                DataRow[] rows = claimsTable.Select($"ClaimNo = '{claimNo}'");

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    // Update the status based on the command
                    row["Status"] = e.CommandName == "Approve" ? "Approved" : "Rejected";

                    // Update the DataTable in ViewState to preserve changes
                    ViewState["Claims"] = claimsTable;

                    // Rebind the GridView to reflect changes
                    BindClaimsGrid();
                }
            }
        }
    }
}