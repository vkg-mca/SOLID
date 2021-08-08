using System.Data.SqlClient;
using System.Net.Mail;

namespace VKG.CodeFactory.DesignPrinciples.DIP
{

    #region Violation
    public class OrderProcessor_Violation
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
            using (SqlConnection conn = new SqlConnection("ConnectionString"))
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
            using (SmtpClient mailer = new SmtpClient("host"))
            {
                //Send email
            }
        }
    }
    #endregion  Violation

    #region Adherance
    public class OrderProcessor_Adherance
    {
        private readonly IRepository _repository;
        private readonly IMailSender _mailer;
        public OrderProcessor_Adherance(IRepository repository, IMailSender mailer)
        {
            _repository = repository;
            _mailer = mailer;
        }
        public void Process(Order order)
        {
            if (order.IsValid && _repository.Save(order))
                _mailer.SendConfirmationMessage(order);
        }
    }
    public interface IRepository
    {
        bool Save(Order order);
    }

    public interface IMailSender
    {
        void SendConfirmationMessage(Order order);
    }
    #endregion  Adherance

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
    #endregion  Common
}
