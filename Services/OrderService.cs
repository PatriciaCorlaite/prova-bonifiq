using ProvaPub.Models;
using ProvaPub.Services.Pagamentos;
using Stripe;

namespace ProvaPub.Services
{
    public class OrderService
    {

        private readonly Dictionary<string, IPaymentMethod> paymentMethods;

        public OrderService()
        {
            paymentMethods = new Dictionary<string, IPaymentMethod>
            {
                { "pix", new PixPayment() },
                { "creditcard", new CreditCardPayment() },
                { "paypal", new PaypalPayment() }
            };
        }


        public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (paymentMethods.TryGetValue(paymentMethod, out var paymentProcessor))
            {
                var paymentResult = await paymentProcessor.ProcessPayment(paymentValue);

                if (paymentResult)
                {
                    return new Order
                    {
                        Value = paymentValue

                    };
                }
                else
                {     
                    Console.WriteLine("O pagamento falhou.");
                }
            }
            else
            {
            
                Console.WriteLine("Método de pagamento não suportado.");
            }

        }
    }
}
