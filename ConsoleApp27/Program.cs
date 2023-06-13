using System;
using System.Data.SqlClient;

namespace ConsoleApp27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isFlag=true;
            string connection = "Server=MSI\\SQLEXPRESS;Database=Wolt;Trusted_Connection=True";
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            void ShowProducts()
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from Products", sqlConnection);
                var sqlexe = sqlCommand.ExecuteReader();
                while (sqlexe.Read())
                {
                    Console.WriteLine(sqlexe["name"]);
                }
            }
            void ShowCategory()
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from Category", sqlConnection);
                var sqlexe = sqlCommand.ExecuteReader();
                while (sqlexe.Read())
                {
                    Console.WriteLine(sqlexe["name"]);
                }

            }
            void AddProducts()
            {
                Console.WriteLine("Enter Product Name...");
                string productName = Console.ReadLine();
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Products VALUES('{productName}')", sqlConnection);
                sqlCommand.ExecuteNonQuery();

            }
            void AddCategory()
            {
                Console.WriteLine("Enter Category Name...");
                string categoryName = Console.ReadLine();
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Category VALUES('{categoryName}')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            void EditProduct()
            {
                Console.WriteLine("Enter Product id...");
                int productId = int.Parse(Console.ReadLine());
                SqlCommand sqlCommand = new SqlCommand($"Select*from Products where id={productId}", sqlConnection);
                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("enter new name...");
                    string newName = Console.ReadLine();
                    SqlCommand sqlCommand2 = new SqlCommand($"Update Products set name={newName} where id={productId}", sqlConnection);
                    sqlCommand2.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Bu id`li product yoxdur...");
                }

            }
            void EditCategory()
            {
                Console.WriteLine("Enter Category id...");
                int categoryId = int.Parse(Console.ReadLine());
                SqlCommand sqlCommand = new SqlCommand($"Select*from Category where id={categoryId}", sqlConnection);
                var read = sqlCommand.ExecuteReader();
                if (read.Read())
                {
                    Console.WriteLine("enter new name...");
                    string newName = Console.ReadLine();
                    SqlCommand sqlCommand2 = new SqlCommand($"Update Category set name={newName} where id={categoryId}", sqlConnection);
                    sqlCommand2.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Bu id`li category yoxdur...");
                }
            }
            while (isFlag)
            {
            int select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        ShowCategory();
                        break;
                    case 3:
                        AddProducts();
                        break;
                    case 4:
                        AddCategory();
                        break;
                    case 5:
                        EditProduct();
                        break;
                    case 6:
                        EditCategory();
                        break;
                    case 8:
                        isFlag = false;
                        break;

                }
            }




        }
    }
}
