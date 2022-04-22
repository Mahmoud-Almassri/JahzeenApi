using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.DTO.AddDTO;
using JahzeenApi.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Service.UnitOfWork;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace JahzeenApi.Services.Helpers
{
    public class FileUploader
    {
        private string[] permittedExtensions = { ".jpg", ".jpeg", ".tiff", ".png", ".svg" };
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public FileUploader(IWebHostEnvironment webHostEnvironmen/*, IServiceUnitOfWork serviceUnitOfWork*/)
        {
            _webHostEnvironment = webHostEnvironmen;
           // _serviceUnitOfWork = serviceUnitOfWork;
        }

        public string PostFile(IFormFile File)
        {
            try
            {
                string randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                //string directory = @"/home/appimages";
                string directory = _webHostEnvironment.WebRootPath + "\\home\\appimages";
                string filePath = Path.Combine(directory, randomFileName);
                if (File.Length > 0)
                {
                    if (File.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(filePath);
                    File.CopyTo(stream);
                    stream.Close();
                    //using var ms = new MemoryStream(filePath);
                    //File.CopyTo(ms);
                    //var fileBytes = ms.ToArray();

                }

                return randomFileName;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public CompanyAttachmentDTO UploadCompanyAttachment(CompanyAttachmentDTO companyAttachmentDTO)
        {
            try
            {
                string randomCompanyLogo = companyAttachmentDTO.CompnayLogo != null ? Guid.NewGuid().ToString() + Path.GetExtension(companyAttachmentDTO.CompnayLogo.FileName) : null;
                string randomCommercialRegister = companyAttachmentDTO.CommercialRegister != null ? Guid.NewGuid().ToString() + Path.GetExtension(companyAttachmentDTO.CommercialRegister.FileName) : null;
                string randomOtherAttachment = companyAttachmentDTO.OtherAttachment != null ? Guid.NewGuid().ToString() + Path.GetExtension(companyAttachmentDTO.OtherAttachment.FileName) : null;
                string directory = @"/home/company-attachments/";

                string companyLogoFilePath = !string.IsNullOrEmpty(randomCompanyLogo) ? Path.Combine(directory, randomCompanyLogo) : null;
                string commercialRegisterFilePath = !string.IsNullOrEmpty(randomCommercialRegister) ? Path.Combine(directory, randomCommercialRegister) : null;
                string otherAttachmentFilePath = !string.IsNullOrEmpty(randomOtherAttachment) ? Path.Combine(directory, randomOtherAttachment) : null;

                if (companyAttachmentDTO.CompnayLogo != null)
                {
                    if (companyAttachmentDTO.CompnayLogo.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(companyLogoFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(companyLogoFilePath);
                    companyAttachmentDTO.CompnayLogo.CopyTo(stream);
                    stream.Close();
                }
                if (companyAttachmentDTO.CommercialRegister != null)
                {
                    if (companyAttachmentDTO.CommercialRegister.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(commercialRegisterFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(commercialRegisterFilePath);
                    companyAttachmentDTO.CommercialRegister.CopyTo(stream);
                    stream.Close();
                }
                if (companyAttachmentDTO.OtherAttachment != null)
                {
                    if (companyAttachmentDTO.OtherAttachment.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(otherAttachmentFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(otherAttachmentFilePath);
                    companyAttachmentDTO.OtherAttachment.CopyTo(stream);
                    stream.Close();
                }

                return new CompanyAttachmentDTO
                {
                    CompanyLogoPath = randomCompanyLogo,
                    CommercialRegisterPath = randomCommercialRegister,
                    OtherAttachmentPath = randomOtherAttachment
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmployeeAttachments UploadEmployeeAttachments(EmployeeAttachmentsAddUpdateDTO attachments)
        {
            try
            {
                string randomProfilePicName = null;
                string randomCriminalName = null;
                string randomPersonalIdName = null;
                string randomLastEducationName = null;
                string directory = _webHostEnvironment.WebRootPath + "/home/employee-attachments/";
                //string directory = _webHostEnvironment.WebRootPath + "\\home\\employee-attachments\\";
                if (attachments.PersonalPicture != null)
                {
                     randomProfilePicName =  Guid.NewGuid().ToString() + Path.GetExtension(attachments.PersonalPicture.FileName) ;
                    string profilePicFilePath = Path.Combine(directory, randomProfilePicName) ;

                    if (attachments.PersonalPicture.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(profilePicFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(profilePicFilePath);
                    attachments.PersonalPicture.CopyTo(stream);
                    stream.Close();
                }
                if (attachments.NoCriminalRecord != null)
                {
                    randomCriminalName =  Guid.NewGuid().ToString() + Path.GetExtension(attachments.NoCriminalRecord.FileName) ;
                    string criminalFilePath =  Path.Combine(directory, randomCriminalName);

                    if (attachments.NoCriminalRecord.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(criminalFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(criminalFilePath);
                    attachments.NoCriminalRecord.CopyTo(stream);
                    stream.Close();
                }
                if (attachments.PersonalId != null)
                {
                    randomPersonalIdName = Guid.NewGuid().ToString() + Path.GetExtension(attachments.PersonalId.FileName);
                    string personalIdFilePath = Path.Combine(directory, randomPersonalIdName);

                    if (attachments.PersonalId.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(personalIdFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(personalIdFilePath);
                    attachments.PersonalId.CopyTo(stream);
                    stream.Close();
                }
                if (attachments.LastEducationCertificate != null)
                {
                    randomLastEducationName = Guid.NewGuid().ToString() + Path.GetExtension(attachments.LastEducationCertificate.FileName);
                    string latEducationFilePath = Path.Combine(directory, randomLastEducationName);

                    if (attachments.LastEducationCertificate.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(latEducationFilePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(latEducationFilePath);
                    attachments.LastEducationCertificate.CopyTo(stream);
                    stream.Close();
                }

                return new EmployeeAttachments
                {
                    PersonalId = randomPersonalIdName,
                    LastEducationCertificatePath = randomLastEducationName,
                    NoCriminalRecordPath = randomCriminalName,
                    PersonalPicturePath = randomProfilePicName
                };
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public Company UploadCompanyAttachments(EmployerAttachmentsAddUpdateDTO attachments)
        {
            try
            {
                string randomCompanyLogoPicName = null;
                string randomCommercialRegisterName = null;
                string randomOtherAttachmentName = null;
                //string directory = @"/home/company-attachments/";
                string directory = _webHostEnvironment.WebRootPath + "/home/employer-attachments/";
                if (attachments.CompanyLogoPath != null)
                {
                    randomCompanyLogoPicName = Guid.NewGuid().ToString() + Path.GetExtension(attachments.CompanyLogoPath.FileName);
                    string CompanyLogoPath =  Path.Combine(directory, randomCompanyLogoPicName);

                    if (attachments.CompanyLogoPath.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(CompanyLogoPath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(CompanyLogoPath);
                    attachments.CompanyLogoPath.CopyTo(stream);
                    stream.Close();
                }
                if (attachments.CommercialRegisterPath != null)
                {
                     randomCommercialRegisterName = attachments.CommercialRegisterPath != null ? Guid.NewGuid().ToString() + Path.GetExtension(attachments.CommercialRegisterPath.FileName) : null;
                     string CommercialRegisterPath = !string.IsNullOrEmpty(randomCommercialRegisterName) ? Path.Combine(directory, randomCommercialRegisterName) : null;

                    if (attachments.CommercialRegisterPath.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(CommercialRegisterPath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(CommercialRegisterPath);
                    attachments.CommercialRegisterPath.CopyTo(stream);
                    stream.Close();
                }
                if (attachments.OtherAttachmentPath != null)
                {
                    randomOtherAttachmentName = attachments.OtherAttachmentPath != null ? Guid.NewGuid().ToString() + Path.GetExtension(attachments.OtherAttachmentPath.FileName) : null;
                    string OtherAttachmentPath = !string.IsNullOrEmpty(randomOtherAttachmentName) ? Path.Combine(directory, randomOtherAttachmentName) : null;

                    if (attachments.OtherAttachmentPath.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(OtherAttachmentPath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(OtherAttachmentPath);
                    attachments.OtherAttachmentPath.CopyTo(stream);
                    stream.Close();
                }

                return new Company
                {
                    CompanyLogoPath = randomCompanyLogoPicName,
                    CommercialRegisterPath = randomCommercialRegisterName,
                    OtherAttachmentPath = randomOtherAttachmentName,
                };
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public string UpdateFile(IFormFile File, string oldFileName , string fileLocation)
        {
            try
            {
                string directory = _webHostEnvironment.WebRootPath + fileLocation;
                if (!string.IsNullOrEmpty(oldFileName))
                {
                    string oldFilePath = Path.Combine(directory, oldFileName);
                    System.IO.File.Delete(oldFilePath);
                }
                string randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
                //string directory = @"/home/appimages";
                string filePath = Path.Combine(directory, randomFileName);
                if (File.Length > 0)
                {
                    if (File.Length >= 5242880)
                    {
                        throw new ValidationException("File size is invalid, max file size is 5 MB");
                    }


                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                    {
                        throw new ValidationException("File extention is not valid");
                    }
                    var stream = System.IO.File.Create(filePath);
                    File.CopyTo(stream);
                    stream.Close();
                    //using var ms = new MemoryStream(filePath);
                    //File.CopyTo(ms);
                    //var fileBytes = ms.ToArray();

                }

                return randomFileName;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public IFormFile ReturnFormFile(FileStream result, string fileName)
        {
            var ms = new MemoryStream();
            try
            {
                result.CopyTo(ms);
                return new FormFile(ms, 0, ms.Length, fileName, fileName);
            }
            catch (Exception e)
            {
                ms.Dispose();
                throw;
            }
            finally
            {
                ms.Dispose();
            }
        }
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        public bool DeleteCompanyFile(string fileName ,string fileLocation)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath + fileLocation, fileName);
            if (File.Exists(path))
            {
                // If file found, delete it    
                File.Delete(Path.Combine(path));
            }

            return true;
        }

        public bool DeleteFile(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath + "\\AppImages\\", fileName);
            if (File.Exists(path))
            {
                // If file found, delete it    
                File.Delete(Path.Combine(path));
            }
            return true;
        }
    }
}
