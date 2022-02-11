using Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var ef = new AnalyzeEfQuery();
            var listEfMethods = new List<MakeDbDelegate>
            {
                ef.CreateDepartment,
                ef.UpdateDepartment,
                ef.GetAllDepartment,
                ef.RemoveDepartment,
                ef.ChangeName,
                ef.AddCustomer,
                ef.RemoveCustomer,
                ef.HireEmployee,
                ef.CountEmployees,
                ef.FindEmployee,
                ef.FindCurrentProject,
                ef.DismissEmployee,
            };

            foreach (var method in listEfMethods)
            {
                await using (var db = new DataBaseContext())
                {
                    PrintResult(method.GetMethodInfo().Name, MeasureTime(method, db));
                    await Task.Delay(1000);
                }
            }

            Console.WriteLine("___________________________________");

            var sp = new AnalyzeStoredProcedure();
            var listSpMethods = new List<MakeDbDelegate>
            {
                sp.CreateDepartment,
                sp.UpdateDepartment,
                sp.GetAllDepartment,
                sp.RemoveDepartment,
                sp.ChangeName,
                sp.AddCustomer,
                sp.RemoveCustomer,
                sp.HireEmployee,
                sp.CountEmployees,
                sp.FindEmployee,
                sp.FindCurrentProject,
                sp.DismissEmployee,
            };

            foreach (var method in listSpMethods)
            {
                await using (var db = new DataBaseContext())
                {
                    PrintResult(method.GetMethodInfo().Name, MeasureTime(method, db));
                    await Task.Delay(1000);
                }
            }
        }

        private static void PrintResult(string methodName, long time)
        {
            Console.WriteLine($"{methodName}--{time}");
        }
        private static long MeasureTime(MakeDbDelegate makeDb, DataBaseContext db)
        {
            var watch = new Stopwatch();

            watch.Start();
            makeDb.Invoke(db);
            watch.Stop();

            //db.Dispose();
            return watch.ElapsedMilliseconds;
        }
    }
}
