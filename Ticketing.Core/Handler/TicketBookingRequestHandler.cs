using System.Runtime.CompilerServices;
using Ticketing.Core.DataServices;
using Ticketing.Core.Domain;
using Ticketing.Core.Model;

namespace Ticketing.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingServic;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingServic)
        {
            this._ticketBookingServic = ticketBookingServic;
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }
            _ticketBookingServic.Save(CreateTicketBookingObject<TicketBooking>(bookingRequest));
            return CreateTicketBookingObject<ServiceBookingResult>(bookingRequest);



        }

        private static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest bookingRequest) where TTicketBooking : ServiceBookingBase, new()
        {
            return new TTicketBooking
            {
                Name = bookingRequest.Name,
                Family = bookingRequest.Family,
                Email = bookingRequest.Email,
            };
        }
    }
}