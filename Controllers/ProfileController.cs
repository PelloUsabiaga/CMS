using CMS02.Extensions;
using CMS02.Models;
using CMS02.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS02.Controllers
{
    public class ProfileController : Controller
    {
        private readonly MyDBContext __context;
        private readonly IHostEnvironment __hostEnviroment;
        public ProfileController(MyDBContext context, IHostEnvironment environment)
        {
            __context = context;
            __hostEnviroment = environment;
        }
        public async Task<IActionResult> Index()
        {
            DocumentViewList DocumentsView = new DocumentViewList();
            int CurrentUserId = -1;
            try { 
                CurrentUserId = HttpContext.Session.Get<User>("User").UserId;
            }
            catch (Exception)
            {
                return View(DocumentsView);
            }
            IQueryable<Document> Documents = from doc in __context.Document
                                             join oun in __context.Ouners on doc.DocumentId equals oun.DocumentId
                                             where oun.UserId == CurrentUserId
                                             select doc;

            try
            {
                DocumentsView.Documents = await Documents.ToListAsync();
            }
            catch (Exception)
            {
                DocumentsView.Documents = null;
            }

            return View(DocumentsView);
        }

        public IActionResult Download(string DocumentPath)
        {
            DocumentPath = Path.Combine(__hostEnviroment.ContentRootPath, "wwwroot/" + DocumentPath);
            return PhysicalFile(DocumentPath, MimeTypes.GetMimeType(DocumentPath), Path.GetFileName(DocumentPath));
        }

        public IActionResult Upload(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }
        
        public IActionResult UploadText(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadSend(DocumentUploadViewModel model)
        {
            Document Document = model.Document;
            if (model.FileToUpload == null)
            {
                return RedirectToAction("Upload", new{ mensaje = "Select a file to upload."});
            }
            if (model.Document.Name == null)
            {
                return RedirectToAction("Upload", new { mensaje = "Select a name for the file." });
            }
            if (model.Document.Description == null)
            {
                model.Document.Description = "";
            }

            User CurrentUser = HttpContext.Session.Get<User>("User");
            Document.Date = DateTime.Today;

            string FileType = model.FileToUpload.ContentType;
            if (FileType.Substring(0,5) == "image")
            {
                Document.DocTipe = 0; // Picture
            } else if (FileType.Substring(0,5) == "video")
            {
                Document.DocTipe = 1; // Video
            } else if (FileType == "application/pdf")
            {
                Document.DocTipe = 2; // Pdf
            } else if (FileType == "text/plain")
            {
                Document.DocTipe = 3; // txt
            }
            else
            {
                Document.DocTipe = -1; // Generic File
            }

            
            int max = 0;
            try
            {
                max = __context.Document.OrderByDescending(p => p.DocumentId).FirstOrDefault().DocumentId;
            } catch(Exception)
            {
                max = 0;
            }

            Task<string> Autorization = RolesAutorization.CanBeUploaded(__context, CurrentUser, Document, model.FileToUpload);

            max++;
            Document.Source = "Files/" + max.ToString() + "/" + model.FileToUpload.FileName;
            Document.DocumentId = max;

            Ouners Ouner = new Ouners();
            Ouner.DocumentId = max;
            Ouner.UserId = CurrentUser.UserId;

            string FilePath = Path.Combine(__hostEnviroment.ContentRootPath, "wwwroot/" + Document.Source);

            string CanBeUploaded = await Autorization;

            if (CanBeUploaded == "-1") 
            { 
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                using (Stream fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await model.FileToUpload.CopyToAsync(fileStream);
                }

                __context.Ouners.Add(Ouner);
                __context.Document.Add(Document);
                __context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Upload", new { mensaje = CanBeUploaded });
            }

        }
        
        [HttpPost]
        public async Task<IActionResult> TextUploadSend(DocumentUploadViewModel model)
        {
            Document Document = model.Document;
            if (model.Document.Description == null)
            {
                return RedirectToAction("TextUpload", new { mensaje = "Your text can not be empty." });
            }

            User CurrentUser = HttpContext.Session.Get<User>("User");
            Document.Date = DateTime.Today;
            Document.DocTipe = 3; // txt

            int max = 0;
            try
            {
                max = __context.Document.OrderByDescending(p => p.DocumentId).FirstOrDefault().DocumentId;
            } catch(Exception)
            {
                max = 0;
            }

            Task<string> Autorization = RolesAutorization.CanBeUploaded(__context, CurrentUser, Document, model.FileToUpload);

            max++;
            Document.Source = "Files/" + max.ToString() + "/textfile.txt";
            Document.DocumentId = max;
            Document.Name = "__restringedNameText";
            Document.ShowDescription = false;

            Ouners Ouner = new Ouners();
            Ouner.DocumentId = max;
            Ouner.UserId = CurrentUser.UserId;

            string FilePath = Path.Combine(__hostEnviroment.ContentRootPath, "wwwroot/" + Document.Source);

            string CanBeUploaded = await Autorization;

            if (CanBeUploaded == "-1") 
            { 
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));

                using (StreamWriter sw = System.IO.File.CreateText(FilePath))
                {
                    sw.WriteLine(Document.Description);
                }

                __context.Ouners.Add(Ouner);
                __context.Document.Add(Document);
                __context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Upload", new { mensaje = CanBeUploaded });
            }

        }

        public async Task<IActionResult> DetailsAsync(string Document)
        {
            int id = Int32.Parse(Document);
            DocumentOptionViewModel Model = new DocumentOptionViewModel();
            IQueryable<Document> Documents = from doc in __context.Document
                                             where doc.DocumentId == id
                                             select doc;
            Model.Document = await Documents.FirstOrDefaultAsync();
            return (View(Model));
        }
        
        public async Task<IActionResult> EditAsync(string Document)
        {
            int id = Int32.Parse(Document);
            DocumentOptionViewModel Model = new DocumentOptionViewModel();
            IQueryable<Document> Documents = from doc in __context.Document
                                             where doc.DocumentId == id
                                             select doc;
            Model.Document = await Documents.FirstOrDefaultAsync();
            return (View(Model));
        }
        
        public async Task<IActionResult> DeleteAsync(string Document)
        {
            int id = Int32.Parse(Document);
            DocumentOptionViewModel Model = new DocumentOptionViewModel();
            IQueryable<Document> Documents = from doc in __context.Document
                                             where doc.DocumentId == id
                                             select doc;
            Model.Document = await Documents.FirstOrDefaultAsync();
            return (View(Model));
        }

        public async Task<IActionResult> Share(string Document, string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            int id = Int32.Parse(Document);
            DocumentOptionViewModel Model = new DocumentOptionViewModel();
            IQueryable<Document> Documents = from doc in __context.Document
                                             where doc.DocumentId == id
                                             select doc;
            Model.Document = await Documents.FirstOrDefaultAsync();
            return (View(Model));
        }

        [HttpPost]
        public async Task<IActionResult> ShareSend(string SearchString, string DocumentId)
        {
            IQueryable<User> Users = from user in __context.User
                                     where user.Email == SearchString
                                     select user;
            List<User> UserList= await Users.ToListAsync();
            User SelectedUser;
            try
            {
                SelectedUser = UserList[0];
            }
            catch (Exception)
            {
                return RedirectToAction("Share", new { mensaje = "This user does not exist.", Document = DocumentId });
            }

            Ouners Ouner = new Ouners();
            Ouner.DocumentId = Int32.Parse(DocumentId);
            Ouner.UserId = SelectedUser.UserId;

            __context.Ouners.Add(Ouner);
            __context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditSend([Bind("Name,Description,Public,ShowDescription")] Document Document, string DocumentId)
        {
            int id = Int32.Parse(DocumentId);
            IQueryable<Document> Documents = from doc in __context.Document
                                             where doc.DocumentId == id
                                             select doc;
            Document DocumentToEdit = await Documents.FirstOrDefaultAsync<Document>();
            DocumentToEdit.Name = Document.Name;
            DocumentToEdit.Description = Document.Description;
            DocumentToEdit.Public = Document.Public;
            DocumentToEdit.ShowDescription = Document.ShowDescription;
            __context.Update(DocumentToEdit);
            await __context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteSend(string DocumentId)
        {
            int id = Int32.Parse(DocumentId);
            IQueryable<Document> Documents = from doc in __context.Document
                                             where doc.DocumentId == id
                                             select doc;
            Document DocumentToDelete = await __context.Document.FindAsync(id);

            string FilePath = Path.Combine(__hostEnviroment.ContentRootPath, "wwwroot/" + DocumentToDelete.Source);
            FileInfo File = new FileInfo(FilePath);
            File.Delete();
            Directory.Delete(Path.GetDirectoryName(FilePath));

            __context.Document.Remove(DocumentToDelete);
            await __context.SaveChangesAsync();


            return RedirectToAction("Index");
        }
    }
}
