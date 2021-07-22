namespace EventBus.Messages.Events
{
    public class BasketCheckoutEvent : IntegrationBaseEvent
    {
        public string ItemName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}