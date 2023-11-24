using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticketing.Core.DataServices;
using Ticketing.Core.Domain;

namespace Ticketing.Core
{
    public class Ticket_Booking_Request_Handler_Test
    {
        private readonly TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;

        public Ticket_Booking_Request_Handler_Test()
        {
            //Arrange
            
            _request = new TicketBookingRequest
            {
                Name = "Test Name",
                Family = "Test Family",
                Email = "TestEmail"
            };
            _ticketBookingServiceMock = new Mock<ITicketBookingService>();
            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);
        }
        [Fact]
        public void  Should_Return_Ticket_Booking_Response_With_Request_Values()
        {

            
            //Act
            ServiceBookingResult Result = _handler.BookService(_request);

            //Assert
            //Assert.NotNull(Result);
            //Assert.Equal(Result.Name, BookingRequest.Name); 
            //Assert.Equal(Result.Family,BookingRequest.Family);
            //Assert.Equal(Result.Email,BookingRequest.Email);
            Result.ShouldNotBeNull();
            //Assert By Shouldly
            Result.Name.ShouldBe(_request.Name);
            Result.Family.ShouldBe(_request.Family);
            Result.Email.ShouldBe(_request.Email);
        }
        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception=Should.Throw<ArgumentNullException>(() =>  _handler.BookService(null));
            exception.ParamName.ShouldBe("bookingRequest");
           // Assert.Throws<ArgumentNullException>(() => Handler.BookService(null));

        }
        [Fact]
        public void Should_Save_Ticket_Booking_Request()
        {
            TicketBooking SavedBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                .Callback<TicketBooking>(booking =>
                {
                    SavedBooking = booking;
                });
            _handler.BookService(_request);
            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()),Times.Once);
            SavedBooking.ShouldNotBeNull();
            //Assert By Shouldly
            SavedBooking.Name.ShouldBe(_request.Name);
            SavedBooking.Family.ShouldBe(_request.Family);
            SavedBooking.Email.ShouldBe(_request.Email);
        }
    }
}
