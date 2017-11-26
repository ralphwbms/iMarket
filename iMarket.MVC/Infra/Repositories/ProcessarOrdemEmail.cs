using System.Net;
using System.Net.Mail;
using System.Text;
using iMarket.Models;

namespace iMarket.Infra.Repositories
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "notificacoes@imarket.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\imarketLogs\";
    }

    public class ProcessarOrdemEmail
    {
        private EmailSettings emailSettings;

        public ProcessarOrdemEmail(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Carrinho cart, DetalhesEntrega shippingInfo)
        {

            using (var smtpClient = new SmtpClient())
            {

                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                          emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Seu pedido está confirmardo!")
                    .AppendLine("---")
                    .AppendLine("Itens:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Produto.Preco * line.Quantidade;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantidade,
                                      line.Produto.Nome,
                                      subtotal);
                }

                body.AppendFormat("Valor total da compra: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Enviar para:")
                    .AppendLine(shippingInfo.Nome)
                    .AppendLine(shippingInfo.Endereco)
                    .AppendLine(shippingInfo.Cidade)
                    .AppendLine(shippingInfo.Estado ?? "")
                    .AppendLine(shippingInfo.CEP)
                    .AppendLine("---")
                    .AppendFormat("Agendamento de Entrega: {0}",
                        shippingInfo.AgendarEntrega ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,   // From
                                       emailSettings.MailToAddress,     // To
                                       "Dados de sua compra no iMarket!", // Subject
                                       body.ToString());                // Body

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }

        }
    }
}