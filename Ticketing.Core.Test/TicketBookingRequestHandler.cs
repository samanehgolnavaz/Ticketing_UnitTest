namespace Ticketing.Core
{
    public class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        public ServiceBookingResult BookingService(TicketBookingRequest bookingRequest)
        {
            return new ServiceBookingResult
            {
                Name= bookingRequest.Name,
                Family= bookingRequest.Family,
                Email   = bookingRequest.Email,
            };
        }
    }
}