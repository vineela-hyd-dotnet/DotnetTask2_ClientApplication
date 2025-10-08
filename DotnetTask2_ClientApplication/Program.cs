using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace DotnetTask2_ClientApplication
{
    public class Program
    {
        private static readonly HttpClient _client =new HttpClient();
        private static string baseUrl="http://localhost:5027/api/Employ";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Fetching Employees from API");
            try
            {
                List<Employee> employees = await _client.GetFromJsonAsync<List<Employee>>(baseUrl);
                if (employees != null && employees.Count > 0)
                {
                   
                    foreach (var emp in employees)
                    {
                        Console.WriteLine("Id: " + emp.Id);
                        Console.WriteLine("Name: " + emp.Name);
                        Console.WriteLine("Email: " + emp.Email);
                        Console.WriteLine("Department: " + emp.Department);
                        Console.WriteLine("Mobile: " + emp.Mobile);
                        Console.WriteLine("  ");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

        }
    }
}
