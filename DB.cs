using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager;

internal class DB
{
    public static bool InCategories(string connectionString, string categoryID)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader[0].ToString() == categoryID)
                        return true;

                }
            }
            else
            {
                Console.WriteLine("no rows found");
            }
            reader.Close();
        }
        return false;
    }
    public static int InsertProducts(string connectionString)
    {
        string categoryID = "", productName, description, img;
        float price;
        string ans = "y";
        int sumRow = 0;
        while (ans == "y")
        {
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("Enter category ID");
                categoryID = Console.ReadLine();
                flag = InCategories(connectionString, categoryID);
                if (!flag)
                    Console.WriteLine("Category does not exist");
            }
            Console.WriteLine("Enter product Name");
            productName = Console.ReadLine();
            Console.WriteLine("Enter description");
            description = Console.ReadLine();
            Console.WriteLine("Enter price");
            price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter image url");
            img = Console.ReadLine();

            string query = "INSERT INTO Products([Category_ID], [Name], [Description], [Price], [ImageURL])" +
                "VALUES(@Category_ID,@Name,@Description,@Price,@ImageURL)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Category_ID", SqlDbType.Int).Value = categoryID;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = productName;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@ImageURL", SqlDbType.VarChar).Value = img;
                con.Open();
                sumRow += cmd.ExecuteNonQuery();
                con.Close();

            }
            Console.WriteLine("Are you want to continue y/n");
            ans = Console.ReadLine();
        }

        return sumRow;
    }
    public static int InsertCategories(string connectionString)
    {
        string categoryName;
        string ans = "y";
        int sumRow = 0;
        while (ans == "y")
        {
            Console.WriteLine("Enter category Name");
            categoryName = Console.ReadLine();
            string query = "INSERT INTO Categories([Name])" +
                "VALUES(@Name)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = categoryName;

                con.Open();
                sumRow += cmd.ExecuteNonQuery();
                con.Close();

            }
            Console.WriteLine("Are you want to continue y/n");
            ans = Console.ReadLine();
        }

        return sumRow;

    }



    public static void printProducts(string connectionString)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Products", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t",
                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
            }
            else
            {
                Console.WriteLine("no rows found");
            }
            reader.Close();
        }
    }
    public static void printCategories(string connectionString)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("select * from Categories", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}",
                        reader[0], reader[1]);
                }
            }
            else
            {
                Console.WriteLine("no rows found");
            }
            reader.Close();
        }
    }

}