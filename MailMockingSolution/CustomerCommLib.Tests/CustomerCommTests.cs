using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSentSuccessfully()
        {
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(ms => ms.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);

            bool result = customerComm.SendMailToCustomer();

            Assert.IsTrue(result);
        }
    }
}
