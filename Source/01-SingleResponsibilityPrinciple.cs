using System.Data.SqlClient;
using System.Net.Mail;

namespace VKG.CodeFactory.DesignPrinciples.SRP
{
    #region Violation
    public class OrderProcessor_Violation
    {
        public void Process(Order order)
        {
            if (order.IsValid && Save(order))
            {
                SendCOnfirmationMessage(order);
            }
        }

        private bool Save(Order order)
        {
            using (var conn = new SqlConnection("ConnectionString"))
            {
                //Save the order to database
            }
            return true;
        }

        private void SendCOnfirmationMessage(Order order)
        {
            //Send email to the client
            var name = order.Customer.Name;
            var email = order.Customer.Email;

            using (var mailer = new SmtpClient("host"))
            {
                //Send email
            }
        }
    }

    #endregion Violation

    #region Adherance
    public class OrderProcessor_Adherance
    {
        public void Process(Order order)
        {
            var repository = new Repository();
            var mailer = new MailSender();
            if (order.IsValid && repository.Save(order))
            {
                mailer.SendCOnfirmationMessage(order);
            }
        }
    }

    public class Repository
    {
        public bool Save(Order order)
        {
            using (var conn = new SqlConnection("ConnectionString"))
            {
                //Save the order to database
            }
            return true;
        }
    }

    public class MailSender
    {
        public void SendCOnfirmationMessage(Order order)
        {
            //Send email to the client
            var name = order.Customer.Name;
            var email = order.Customer.Email;
            using (var mailer = new SmtpClient("host"))
            {
                //Send email
            }
        }
    }
    #endregion Adherance

    #region Common
    public class Order
    {
        public Customer Customer { get; internal set; }
        public bool IsValid { get; internal set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    #endregion Common

}
