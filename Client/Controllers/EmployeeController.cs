using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Client.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7152/api");

        private readonly HttpClient _client;

        public EmployeeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployees").Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }


            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Employees/AddEmployee", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Employee added successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                EmployeeViewModel employee = new EmployeeViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployee/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    employee = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }
            

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employee)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Employees/UpdateEmployee/" + employee.Id, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Employee updated successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }

            return View();
        }



     
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Employees/DeleteEmployee/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Employee deleted successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }








    }
}
