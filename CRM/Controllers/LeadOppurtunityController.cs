using CRM.Models;
using CRM.Scripts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LeadOppurtunityController : ControllerBase
    {
        private string connectionString = @"Data Source=LamDat;Initial Catalog=crm_system;Integrated Security=True;TrustServerCertificate=True";

        [HttpPost]
        public string InsertLeadOppurtunity([FromBody] LeadOppurtunity leadOppurtunity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    GenerateKey generateKey = new GenerateKey();

                    //Get number lead oppurtuniy
                    SqlCommand checkNumberOppurtunity = new SqlCommand("SELECT * FROM lead_oppurtunity", connection);

                    SqlDataReader readerCheckNumberOppurtunity = checkNumberOppurtunity.ExecuteReader();
                    int numberOppurtunity = 0;
                    while (readerCheckNumberOppurtunity.Read())
                    {
                        numberOppurtunity++;
                    }
                    readerCheckNumberOppurtunity.Close();

                    //Get number lead stage
                    SqlCommand checkNumberStage = new SqlCommand("SELECT * FROM lead_stage", connection);

                    SqlDataReader readerCheckNumberStage = checkNumberStage.ExecuteReader();
                    int numberStage = 0;
                    while (readerCheckNumberStage.Read())
                    {
                        numberStage++;
                    }
                    readerCheckNumberStage.Close();


                    //Get sale_team of employee
                    SqlCommand getSaleTeamEmloyee = new SqlCommand("SELECT sales_team_id FROM employee where id = @id", connection);
                    getSaleTeamEmloyee.Parameters.AddWithValue("@id", leadOppurtunity.CreateEmployeeId);
                    string saleteamid = Convert.ToString(getSaleTeamEmloyee.ExecuteScalar());

                    //Check condition
                    if (saleteamid != "")
                    {
                        string keyIdLeadOppurtunity = generateKey.GenerateString("LOP", numberOppurtunity+1);

                        // Insert Oppurtunity
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO lead_oppurtunity (id, name, urgency, expected_revenue, expected_closing_date, create_date, source_id, create_employee_id, marketing_campaign_id) VALUES (@id, @name, @urgency, @expected_revenue, @expected_closing_date, @create_date, @source_id, @create_employee_id, @marketing_campaign_id)", connection);
                        insertCommand.Parameters.AddWithValue("@id", keyIdLeadOppurtunity);
                        insertCommand.Parameters.AddWithValue("@name", leadOppurtunity.Name);
                        insertCommand.Parameters.AddWithValue("@urgency", leadOppurtunity.Urgency);
                        insertCommand.Parameters.AddWithValue("@expected_revenue", leadOppurtunity.ExpectedRevenue);
                        insertCommand.Parameters.AddWithValue("@expected_closing_date", leadOppurtunity.ExpectedClosingDate);
                        insertCommand.Parameters.AddWithValue("@create_date", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@source_id", leadOppurtunity.SourceId);
                        insertCommand.Parameters.AddWithValue("@create_employee_id", leadOppurtunity.CreateEmployeeId);
                        insertCommand.Parameters.AddWithValue("@marketing_campaign_id", leadOppurtunity.MarketingCampaignId);
                        insertCommand.ExecuteNonQuery();

                        //Auto insert lead stage
                        SqlCommand insertCommand1 = new SqlCommand("INSERT INTO lead_stage (id, start_date, stage_id, create_employee_id, lead_oppurtunity_id) VALUES (@id, @start_date, @stage_id, @create_employee_id, @lead_oppurtunity_id)", connection);
                        insertCommand1.Parameters.AddWithValue("@id", generateKey.GenerateString("LST", numberStage + 1));
                        insertCommand1.Parameters.AddWithValue("@start_date", DateTime.Now);
                        insertCommand1.Parameters.AddWithValue("@stage_id", "STA001");
                        insertCommand1.Parameters.AddWithValue("@create_employee_id", leadOppurtunity.CreateEmployeeId);
                        insertCommand1.Parameters.AddWithValue("@lead_oppurtunity_id", keyIdLeadOppurtunity);
                        insertCommand1.ExecuteNonQuery();

                        return "Sucess to insert lead oppurtunity";
                    }
                    return "Employee not have sale team";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
