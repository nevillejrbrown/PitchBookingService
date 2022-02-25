using System;
using FluentValidation;

#nullable disable

namespace CricketDataTypes
{
    public class PitchBookingRequest
    {
        public string ContactEmail { get; set; }

        public DateTime BookingDate { get; set; }

    }

    public class PitchBookingRequestValidator : AbstractValidator<PitchBookingRequest>
    {
        public PitchBookingRequestValidator()
        {
            RuleFor(x => x.ContactEmail).NotEmpty().WithMessage("Please supply a contact email");
            RuleFor(x => x.BookingDate).Must(date => date >= DateTime.Now).WithMessage("Booking date must be in the future");
            RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Please supply a valid contact email");
        }
    }
}
