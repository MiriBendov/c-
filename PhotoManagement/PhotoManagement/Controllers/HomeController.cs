using Microsoft.AspNetCore.Mvc;
using PhotoManagement.Models;
using System.Diagnostics;
using BLL;


namespace PhotoManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string uniqueCode = BLL.Class1.GenerateShortUniqueCodeFromGuid();
            ViewBag.UniqueCode = uniqueCode; // מעביר לקוד הייחודי ל-View
            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult size()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
        [HttpPost] // מציין שהפעולה מקבלת POST requests
        public IActionResult SaveSelection(string[] sizes)
        {
            // sizes מכיל את הערכים של checkboxes שנבחרו
            // כאן תוכל לעבד את הבחירות, למשל לשמור במסד נתונים או לבצע פעולות אחרות

            // ניתן להעביר מסר לאחזור בקובץ ה-View
            ViewBag.SelectedSizes = sizes;

            return View("Result"); // מחזיר לדף תוצאה (החלף עם שמו של ה-View המתאים)
        }

        public IActionResult CreateOrder()
        {
            return View(); // ודא שה-View קיים
        }


        [HttpPost]
        public IActionResult SubmitOrder(string name, string phone)
        {
            // שמירה של הערכים שהתקבלו במתודעה
            string userName = name; // תוכן השם מה-input
            string userPhone = phone; // תוכן הטלפון מה-input



            //_logger.LogInformation("Received Name: {Name}, Phone: {Phone}", userName, userPhone);
            ViewData["Name"] = userName; // החלף עם השם האמיתי
            ViewData["Phone"] = userPhone; // החלף עם הטלפון האמיתי


            //return View("size", new { Name = userName, Phone = userPhone });
            return View("size");




            // כעת תוכל להשתמש במשתנים userName ו-userPhone
            // לדוגמה, תוכל להעביר אותם למסד נתונים בהמשך
            // ... (קוד להעברת הנתונים למסד נתונים)

            // דוגמה להחזרת דף אישור (אופציונלי)
            //return RedirectToAction("size"); // אם יש דף אישור
        }

    }
}