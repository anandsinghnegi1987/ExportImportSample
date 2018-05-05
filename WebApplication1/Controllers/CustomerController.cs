using System.Collections;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Dashboard()
        {
            if (Session["Customer"] == null)
            {
                return RedirectToAction("Account", "Home");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Flot()
        {
            return View();
        }

        public ActionResult ChartData()
        {
            ChartDisplayDBContext context = new ChartDisplayDBContext();

            var _context = context.TestEntities;

            ArrayList xValue = new ArrayList();

            ArrayList yValue = new ArrayList();

           // var results = (from c in _context. .tblMVCCharts select c);

           // results.ToList().ForEach(rs => xValue.Add(rs.Growth_Year));

           // results.ToList().ForEach(rs => yValue.Add(rs.Growth_Value));

           // new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla3D)

           // .AddTitle("Chart for Growth [Column Chart]")

           //.AddSeries("Default", chartType: "column", xValue: xValue, yValues: yValue)

           //       .Write("bmp");

            return null;
        }

        public ActionResult CharterColumn()
        {

            Repository EmpRepo = new Repository();

            ModelState.Clear();

            ArrayList xValue = new ArrayList();

            ArrayList yValue = new ArrayList();

            List<ChartDisplay> list = EmpRepo.GetAllEmployees();


            foreach (var item in list)
            {
                xValue.Add(item.Growth_Year);
                yValue.Add(item.Growth_Value);
            }

            new Chart(width: 300, height: 200, theme: ChartTheme.Vanilla3D)
                    .AddTitle("Chart for Growth [Pie Chart]")
                    .AddLegend("Summary")
                    .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
                    .Write("bmp");

            return null;
        }
    }
}