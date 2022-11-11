using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CMS02.Models
{
    public class RolesAutorization
    {
        public static async Task<string> CanBeUploaded(MyDBContext Context, User User, Document Document, IFormFile File)
        {
            int CurrentUserId = User.UserId;
            var UserPermisions = await (from permisions in Context.Permisions
                                        join rol in Context.Roles on permisions.RoleId equals rol.RoleId
                                        where rol.UserId == CurrentUserId
                                        select permisions).FirstOrDefaultAsync<Permisions>();
            
            IQueryable<Document> Documents = from doc in Context.Document
                                             join oun in Context.Ouners on doc.DocumentId equals oun.DocumentId
                                             where oun.UserId == CurrentUserId
                                             select doc;
            List<Document> UsersDocuments;

            try
            {
                UsersDocuments = await Documents.ToListAsync();
            }
            catch (Exception)
            {
                UsersDocuments = null;
            }

            int FileType = Document.DocTipe;
            if (FileType == 0) // Picture
            {
                if (File.Length > UserPermisions.MaxPictureSize && UserPermisions.MaxPictureSize != -1)
                {
                    return "You can not upload this size picture, please, uprage to premium.";
                }

                int UsersPictureAmount = 0;
                foreach (Document doc in UsersDocuments)
                {
                    if (doc.DocTipe == 0)
                    {
                        UsersPictureAmount++;
                    }
                }

                if (UsersPictureAmount > UserPermisions.MaxPictureAmount && UserPermisions.MaxPictureAmount != -1)
                {
                    return "You can not upload more pictures, please, uprage to premium.";
                } 
            }
            else if (FileType == 1) // Video
            {
                if (File.Length > UserPermisions.MaxVideoSize && UserPermisions.MaxVideoSize != -1)
                {
                    return "You can not upload this size video, please, uprage to premium.";
                }

                int UsersVideoAmount = 0;
                foreach (Document doc in UsersDocuments)
                {
                    if (doc.DocTipe == 1)
                    {
                        UsersVideoAmount++;
                    }
                }

                if (UsersVideoAmount > UserPermisions.MaxVideoAmount && UserPermisions.MaxVideoAmount != -1)
                {
                    return "You can not upload more videos, please, uprage to premium.";
                }
            }
            else if (FileType == 2) // Pdf
            {
                if (File.Length > UserPermisions.MaxPDFSize && UserPermisions.MaxPDFSize != -1)
                {
                    return "You can not upload this size PDF, please, uprage to premium.";
                }

                int UsersPDFAmount = 0;
                foreach (Document doc in UsersDocuments)
                {
                    if (doc.DocTipe == 2)
                    {
                        UsersPDFAmount++;
                    }
                }

                if (UsersPDFAmount > UserPermisions.MaxPDFAmount && UserPermisions.MaxPDFAmount != -1)
                {
                    return "You can not upload more PDF, please, uprage to premium.";
                }
            }
            else if (FileType == 3) // txt
            {
                ;
            } 
            else if (FileType == -1) // generic file
            {
                if (!UserPermisions.CanUseGenerics)
                {
                    return "You can not upload generic files, please, uprage to premium.";
                }
            }

            return "-1";
        }
    }
}
