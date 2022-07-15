using System;
using FluentValidation;

#nullable disable

namespace CricketDataTypes
{
    public class PitchBooking
    {
        private DateTime _trimmedDate;

        public string ContactEmail { get; set; }

        public DateTime BookingDate { 
            get {
                return _trimmedDate;
            }
            set
            {
                this._trimmedDate = value.Date;
            }
}



        public override bool Equals(object obj)
        {
            if (obj is PitchBooking)
            {
                return ((PitchBooking)obj).ContactEmail.Equals(this.ContactEmail)
                    && ((PitchBooking)obj).BookingDate.Equals(this.BookingDate);
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class PitchBookingRequestValidator : AbstractValidator<PitchBooking>
    {
        public PitchBookingRequestValidator()
        {
            RuleFor(x => x.ContactEmail).NotEmpty().WithMessage("Please supply a contact email");
            RuleFor(x => x.BookingDate).Must(date => date >= DateTime.Now).WithMessage("Booking date must be in the future");
            RuleFor(x => x.ContactEmail).EmailAddress().WithMessage("Please supply a valid contact email");
        }
    }
}
