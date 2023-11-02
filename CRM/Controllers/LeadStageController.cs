using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CRM.Scripts;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadStageController : ControllerBase
    {
        private string connectionString = @"Add datasource here";

        [HttpPost]
        public string InsertLeadStage([FromBody] LeadOppurtunity leadOppurtunity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    GenerateKey generateKey = new GenerateKey();

                    // Get total stage
                    SqlCommand checkTotalStage = new SqlCommand("SELECT * FROM stage", connection);
                    SqlDataReader readerGetTotalStage = checkTotalStage.ExecuteReader();
                    int totalStage = 0;
                    while (readerGetTotalStage.Read())
                    {
                        totalStage++;
                    }
                    readerGetTotalStage.Close();

                    //Get number lead stage
                    SqlCommand checkNumberStage = new SqlCommand("SELECT * FROM lead_stage where lead_oppurtunity_id = @LeadOppurnityId", connection);
                    checkNumberStage.Parameters.AddWithValue("@LeadOppurnityId", leadOppurtunity.Id);
                    
                    SqlDataReader readerCheckNumberStage = checkNumberStage.ExecuteReader();
                    int numberStage = 0;
                    while (readerCheckNumberStage.Read())
                    {
                        numberStage++;
                    }
                    readerCheckNumberStage.Close();

                    // Condition insert lead stage
                    if(numberStage >= totalStage)
                    {
                        return "Lead stage in final stage";
                    }
                    else
                    {
                        //Get latest lead stage
                        SqlCommand leadStageLatest = new SqlCommand("SELECT TOP 1 * FROM lead_stage where lead_oppurtunity_id = @LeadOppurnityId ORDER BY stage_id DESC", connection);
                        leadStageLatest.Parameters.AddWithValue("@LeadOppurnityId", leadOppurtunity.Id);

                        SqlDataReader reader = leadStageLatest.ExecuteReader();
                        LeadStage newLeadStage = null;
                        while (reader.Read())
                        {
                            newLeadStage = new LeadStage
                            {
                                Id = reader.GetString(0),
                                StartDate = null,
                                EndDate = null,
                                StageId = generateKey.GenerateString("STA", numberStage + 1),
                                CreateEmployeeId = reader.GetString(4),
                                LeadOppurtunityId = reader.GetString(5)
                            };
                        }
                        reader.Close();

                        //Get sale team
                        SqlCommand getSaleTeam1 = new SqlCommand("SELECT sales_team_id FROM employee where id = @EmployeeId", connection);
                        SqlCommand getSaleTeam2 = new SqlCommand("SELECT sales_team_id FROM employee where id = @EmployeeId", connection);

                        getSaleTeam1.Parameters.AddWithValue("@EmployeeId", leadOppurtunity.CreateEmployeeId);
                        getSaleTeam2.Parameters.AddWithValue("@EmployeeId", newLeadStage.CreateEmployeeId);

                        string idSaleTeam1 = Convert.ToString(getSaleTeam1.ExecuteScalar());
                        string idSaleTeam2 = Convert.ToString(getSaleTeam2.ExecuteScalar());

                        if (idSaleTeam1 == idSaleTeam2)
                        {
                            // Update end date
                            SqlCommand updateStockCommand = new SqlCommand("UPDATE lead_stage SET end_date = @end_date WHERE id = @id", connection);
                            updateStockCommand.Parameters.AddWithValue("@id", newLeadStage.Id);
                            updateStockCommand.Parameters.AddWithValue("@end_date", DateTime.Now);
                            updateStockCommand.ExecuteNonQuery();


                            // Insert new lead stage
                            SqlCommand checkNumberLeadStage = new SqlCommand("SELECT * FROM lead_stage", connection);
                            checkNumberLeadStage.Parameters.AddWithValue("@LeadOppurnityId", leadOppurtunity.Id);

                            SqlDataReader readerCheckNumberLeadStage = checkNumberLeadStage.ExecuteReader();
                            int numberLeadStage = 0;
                            while (readerCheckNumberLeadStage.Read())
                            {
                                numberLeadStage++;
                            }
                            readerCheckNumberLeadStage.Close();

                            SqlCommand insertCommand = new SqlCommand("INSERT INTO lead_stage (id, start_date, stage_id, create_employee_id, lead_oppurtunity_id) VALUES (@id, @start_date, @stage_id, @create_employee_id, @lead_oppurtunity_id)", connection);
                            insertCommand.Parameters.AddWithValue("@id", generateKey.GenerateString("LST", numberLeadStage + 1));
                            insertCommand.Parameters.AddWithValue("@start_date", DateTime.Now);
                            insertCommand.Parameters.AddWithValue("@stage_id", newLeadStage.StageId);
                            insertCommand.Parameters.AddWithValue("@create_employee_id", leadOppurtunity.CreateEmployeeId);
                            insertCommand.Parameters.AddWithValue("@lead_oppurtunity_id", newLeadStage.LeadOppurtunityId);
                            insertCommand.ExecuteNonQuery();

                            return "Lead stage inserted successfully in CRM.";
                        }
                        else
                        {
                            return "You not have permission to insert and update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
