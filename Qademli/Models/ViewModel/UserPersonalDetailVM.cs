using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Qademli.Models.DatabaseModel;
using Qademli.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.ViewModel
{
    public class UserPersonalDetailVM
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserPersonalDetailVM(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public UserPersonalDetail Add(UserPersonalDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            UserPersonalDetail userPersonalDetail = new UserPersonalDetail();
            var ext1 = Path.GetExtension(obj.IdentificationDoc.FileName);
            var ext2 = Path.GetExtension(obj.CivilIDFront.FileName);
            var ext3 = Path.GetExtension(obj.CivilIDBack.FileName);
            if ((obj.IdentificationDoc != null && permittedExtensions.Contains(ext1)))
            {
                userPersonalDetail.IdentificationDoc = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserPersonalDetail/IdentificationDoc", obj.IdentificationDoc);
            }
            if ((obj.CivilIDFront != null && permittedExtensions.Contains(ext2)))
            {
                userPersonalDetail.CivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserPersonalDetail/CivilIDFront", obj.CivilIDFront);
            }
            if ((obj.CivilIDBack != null && permittedExtensions.Contains(ext3)))
            {
                userPersonalDetail.CivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserPersonalDetail/CivilIDBack", obj.CivilIDBack);
            }

            userPersonalDetail.UserID = obj.UserID;
            userPersonalDetail.MaritalStatus = obj.MaritalStatus;
            userPersonalDetail.Address = obj.Address;
            userPersonalDetail.MobileNumber = obj.MobileNumber;
            userPersonalDetail.Instagram = obj.Instagram;
            userPersonalDetail.Twitter = obj.Twitter;
            userPersonalDetail.Facebook = obj.Facebook;
            userPersonalDetail.USAddress = obj.USAddress;
            userPersonalDetail.Title = obj.Title;
            userPersonalDetail.Gender = obj.Gender;
            userPersonalDetail.FirstLanguage = obj.FirstLanguage;
            userPersonalDetail.Nationality = obj.Nationality;
            userPersonalDetail.DOB = obj.DOB;
            userPersonalDetail.IdentificationDocNo = obj.IdentificationDocNo;
            userPersonalDetail.TownCity = obj.TownCity;
            userPersonalDetail.StateCountry = obj.StateCountry;
            userPersonalDetail.ZipPostalCode = obj.ZipPostalCode;
            userPersonalDetail.TelephoneNumber = obj.TelephoneNumber;
            userPersonalDetail.OccupationSector = obj.OccupationSector;
            userPersonalDetail.OccupationLevel = obj.OccupationLevel;
            return userPersonalDetail;
        }

        public UserPersonalDetail Update(UserPersonalDetail userPersonalDetail, UserPersonalDetailUpsert obj)
        {
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
            userPersonalDetail.MaritalStatus = obj.MaritalStatus;
            userPersonalDetail.Address = obj.Address;
            userPersonalDetail.MobileNumber = obj.MobileNumber;
            userPersonalDetail.Instagram = obj.Instagram;
            userPersonalDetail.Twitter = obj.Twitter;
            userPersonalDetail.Facebook = obj.Facebook;
            userPersonalDetail.USAddress = obj.USAddress;
            userPersonalDetail.Title = obj.Title;
            userPersonalDetail.Gender = obj.Gender;
            userPersonalDetail.FirstLanguage = obj.FirstLanguage;
            userPersonalDetail.Nationality = obj.Nationality;
            userPersonalDetail.DOB = obj.DOB;
            userPersonalDetail.IdentificationDocNo = obj.IdentificationDocNo;
            userPersonalDetail.TownCity = obj.TownCity;
            userPersonalDetail.StateCountry = obj.StateCountry;
            userPersonalDetail.ZipPostalCode = obj.ZipPostalCode;
            userPersonalDetail.TelephoneNumber = obj.TelephoneNumber;
            userPersonalDetail.OccupationSector = obj.OccupationSector;
            userPersonalDetail.OccupationLevel = obj.OccupationLevel;
            if (obj.IdentificationDoc != null)
            {
                var ext = Path.GetExtension(obj.IdentificationDoc.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserPersonalDetail\IdentificationDoc", userPersonalDetail.IdentificationDoc.Replace("/Uploads/UserPersonalDetail/IdentificationDoc/", ""));
                    userPersonalDetail.IdentificationDoc = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserPersonalDetail/IdentificationDoc", obj.IdentificationDoc);
                }
            }
            if (obj.CivilIDFront != null)
            {
                var ext = Path.GetExtension(obj.CivilIDFront.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserPersonalDetail\CivilIDFront", userPersonalDetail.CivilIDFront.Replace("/Uploads/UserPersonalDetail/CivilIDFront/", ""));
                    userPersonalDetail.CivilIDFront = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserPersonalDetail/CivilIDFront", obj.CivilIDFront);
                }
            }
            if (obj.CivilIDBack != null)
            {
                var ext = Path.GetExtension(obj.CivilIDBack.FileName);
                if (permittedExtensions.Contains(ext))
                {
                    ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserPersonalDetail\CivilIDBack", userPersonalDetail.CivilIDBack.Replace("/Uploads/UserPersonalDetail/CivilIDBack/", ""));
                    userPersonalDetail.CivilIDBack = ImageHelper.UploadImageFile(_hostEnvironment, "wwwroot/Uploads/UserPersonalDetail/CivilIDBack", obj.CivilIDBack);
                }
            }

            return userPersonalDetail;
        }

        public void Delete(UserPersonalDetail userPersonalDetail)
        {
            if (!string.IsNullOrEmpty(userPersonalDetail.IdentificationDoc))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserPersonalDetail\IdentificationDoc", userPersonalDetail.IdentificationDoc.Replace("/Uploads/UserPersonalDetail/IdentificationDoc/", ""));
            }
            if (!string.IsNullOrEmpty(userPersonalDetail.CivilIDFront))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserPersonalDetail\CivilIDFront", userPersonalDetail.CivilIDFront.Replace("/Uploads/UserPersonalDetail/CivilIDFront/", ""));
            }
            if (!string.IsNullOrEmpty(userPersonalDetail.CivilIDBack))
            {
                ImageHelper.DeleteImage(_hostEnvironment, @"Uploads\UserPersonalDetail\CivilIDBack", userPersonalDetail.CivilIDBack.Replace("/Uploads/UserPersonalDetail/CivilIDBack/", ""));
            }
        }

    }
    public class UserPersonalDetailUpsert
    {
        [Required]
        public int UserID { get; set; }
        [Required]

        public string MaritalStatus { get; set; }

        public IFormFile CivilIDFront { get; set; }

        public IFormFile CivilIDBack { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string MobileNumber { get; set; }
        [Required]

        public string Instagram { get; set; }
        [Required]

        public string Twitter { get; set; }
        [Required]

        public string Facebook { get; set; }
        [Required]

        public string USAddress { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string Gender { get; set; }
        [Required]

        public string FirstLanguage { get; set; }
        [Required]

        public string Nationality { get; set; }
        [Required]

        public DateTime DOB { get; set; }

        public IFormFile IdentificationDoc { get; set; }
        [Required]

        public string IdentificationDocNo { get; set; }
        [Required]

        public string TownCity { get; set; }
        [Required]

        public string StateCountry { get; set; }
        [Required]

        public int ZipPostalCode { get; set; }
        public string TelephoneNumber { get; set; }
        [Required]

        public string OccupationSector { get; set; }
        [Required]

        public string OccupationLevel { get; set; }
    }
}
