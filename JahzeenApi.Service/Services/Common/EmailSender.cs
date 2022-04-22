using JahzeenApi.Domain.Models;
using JahzeenApi.Domain.Models.Common;
using JahzeenApi.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Common
{
    public class EmailSender
    {
        AppConfiguration appConfiguration = new AppConfiguration(); 
        public EmailSender()
        {

        }

        public void sendEmailConfirmationEmail(ApplicationUser user , string token)
        {
            /*if (string.IsNullOrEmpty(lang))
            {
                lang = "EN";
            }*/
            string confirmationLink = appConfiguration.EmailConfirmation;
            //string systemLink = appConfiguration.SystemLink;
            string subject = "Jahzeen Verfiy Email";
            string body = "Your Jahzeen OTP Code To Complete Sign up " + token;
            SendEmail.SendEmails(user.Email, subject, body);
        } 
        public void SendReminderEmail()
        {
            
            string subject = "New Contact Us Message";
            string body = string.Format("You have a new contact message check on link", appConfiguration.AdminUrl);
            SendEmail.SendEmails(appConfiguration.Email, subject, body);
        }
        public void sendResetPasswordEmail(ApplicationUser user , string token,string lang)
        {

            try
            {
                string ResetLink = appConfiguration.ResetPassword;
                string systemLink = appConfiguration.SystemLink;
                string subject =lang=="EN"? "Reset Password Link" : "إعادة تعيين كلمة المرور";
                string body = string.Format(ResetLink, user.Email, token);
                SendEmail.SendEmails(user.Email, subject, body);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        


    }
}
