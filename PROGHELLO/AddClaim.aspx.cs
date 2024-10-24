using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PROGHELLO.Pages
{
    public class AddClaimModel : PageModel
    {
        [BindProperty]
        public int LecturerID { get; set; }
        [BindProperty]
        public decimal TotalAmount { get; set; }
        public string Message { get; set; }

        public void OnPost()
        {
            string connectionString = "Server=labG9AEB3\\SQLEXPRESS;Database=LecturerClaimsDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Claim (LecturerID, TotalAmount, Status) VALUES (@LecturerID, @TotalAmount, 'Pending')";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LecturerID", LecturerID);
                    command.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Message = "Claim added successfully.";
                    }
                    else
                    {
                        Message = "Error adding claim.";
                    }
                }
            }
        }
    }
}
