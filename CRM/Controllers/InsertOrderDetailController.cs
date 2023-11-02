using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Http;
using CRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private string connectionString = @"Data Source=LamDat;Initial Catalog=crm_system;Integrated Security=True;TrustServerCertificate=True";

        [HttpPost]
        public string InsertOrderDetail([FromBody] OrderItem orderDetail)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check product availability in stock
                    SqlCommand checkStockCommand = new SqlCommand("SELECT unit_in_stock FROM product WHERE id = @product_id", connection);
                    checkStockCommand.Parameters.AddWithValue("@product_id", orderDetail.ProductId);

                    int availableStock = Convert.ToInt32(checkStockCommand.ExecuteScalar());

                    if (availableStock >= orderDetail.Quantity)
                    {
                        // Insert the order detail
                        SqlCommand insertCommand = new SqlCommand("INSERT INTO order_item (id, quantity, discount_percent, order_id, product_id) VALUES (@id, @quantity, @discount_percent, @order_id, @product_id)", connection);
                        insertCommand.Parameters.AddWithValue("@id", orderDetail.Id);
                        insertCommand.Parameters.AddWithValue("@quantity", orderDetail.Quantity);
                        insertCommand.Parameters.AddWithValue("@discount_percent", orderDetail.DiscountPercent);
                        insertCommand.Parameters.AddWithValue("@order_id", orderDetail.OrderId);
                        insertCommand.Parameters.AddWithValue("@product_id", orderDetail.ProductId);

                        insertCommand.ExecuteNonQuery();

                        // Update stock quantity
                        SqlCommand updateStockCommand = new SqlCommand("UPDATE product SET unit_in_stock = unit_in_stock - @quantity WHERE id = @id", connection);
                        updateStockCommand.Parameters.AddWithValue("@id", orderDetail.ProductId);
                        updateStockCommand.Parameters.AddWithValue("@quantity", orderDetail.Quantity);
                        updateStockCommand.ExecuteNonQuery();
                        return "Order detail inserted successfully in CRM.";
                    }
                    else
                    {
                        return "Product not available in sufficient quantity.";
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

