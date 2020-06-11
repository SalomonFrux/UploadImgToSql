


using ImageToSql.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace UploadToSql.Controllers
{
    public class HomeController : Controller
    {
        [BindProperty]
        public UserForm UserForm { get; set; }



        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.UserForms.ToList());
        }

        public IActionResult Create()
        {
            return View(UserForm);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost()
        {
            //Saving the Image to the Sql database

            if (!ModelState.IsValid)
                return View(UserForm);
            //Getting the data from the web page



            //Request for the uploaded file if any
            var files = HttpContext.Request.Form.Files;

            //Check if any file is uploaded
            if (files.Any())
            {
                //Then the a file has been uploaded so initialise a stream of byte
                byte[] streamOfBytes;

                //Start Reading the files
                var readStreamFile = files[0].OpenReadStream();

                //Initialise a memory Stream 

                var memoryStream = new MemoryStream();

                //Copy the file to read into the Memory Stream

                readStreamFile.CopyTo(memoryStream);

                //Then  save the memory in the bytes array 

                streamOfBytes = memoryStream.ToArray();

                //Add the user object in the database and save
                UserForm.Image = streamOfBytes;
                _context.UserForms.Add(UserForm);
                _context.SaveChanges();
            }



            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      //  public IActionResult Error()
        //{
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}





