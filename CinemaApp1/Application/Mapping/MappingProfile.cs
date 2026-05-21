using AutoMapper;
namespace CinemaApp1.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponseDto>();
        CreateMap<RegisterDTO, User>()
        .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
        .ForMember(dest => dest.Role, opt => opt.Ignore())
        .ForMember(dest => dest.IsVerified, opt => opt.Ignore())
        .ForMember(dest => dest.IsBlocked, opt => opt.Ignore())
        .ForMember(dest => dest.VerificationToken, opt => opt.Ignore())
        .ForMember(dest => dest.ResetPasswordToken, opt => opt.Ignore())
        .ForMember(dest => dest.ResetPasswordTokenExpiry, opt => opt.Ignore());

        CreateMap<Genre, GenreResponseDTO>();
        CreateMap<GenreCreateDTO, Genre>();
        CreateMap<GenreUpdateDTO, Genre>()
            .ForAllMembers(opt => opt.Condition(
                (src, dest, srcMember) => srcMember != null));

        CreateMap<Movie, MovieResponseDTO>()
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Stars) : (double?)null))
            .ForMember(dest => dest.PosterImageUrl,
             opt => opt.MapFrom(src => src.PosterImage));

        CreateMap<MovieCreateDTO, Movie>()
            .ForMember(dest => dest.PosterImage, opt => opt.Ignore());

        CreateMap<MovieUpdateDTO, Movie>()
            .ForMember(dest => dest.PosterImage, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<MovieScreening, ScreeningResponseDTO>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
            .ForMember(dest => dest.PosterImageUrl, opt => opt.MapFrom(src => src.Movie.PosterImage))
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Movie.Genre.Name))
            .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.Seats.Count(s => !s.IsOccupied)))
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Movie.Ratings.Any() ? src.Movie.Ratings.Average(r => r.Stars) : (double?)null));

        CreateMap<MovieScreening, ScreeningListDTO>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
            .ForMember(dest => dest.PosterImageUrl, opt => opt.MapFrom(src => src.Movie.PosterImage))
            .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.Seats.Count(s => !s.IsOccupied)))
            .ForMember(dest => dest.IsPast, opt => opt.MapFrom(src => src.DateTime < DateTime.UtcNow));

        CreateMap<ScreeningCreateDTO, MovieScreening>();
        CreateMap<ScreeningUpdateDTO, MovieScreening>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        /*
         * CreateMap<SeatCreateDTO, Seat>();
            CreateMap<Seat, SeatResponseDTO>();
        */

        CreateMap<SeatCreateDTO, Seat>();
        CreateMap<Seat, SeatResponseDTO>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsOccupied ? "Occupied" : "Available"));

        CreateMap<Reservation, ReservationResponseDTO>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Screening.Movie.Name))
            .ForMember(dest => dest.ScreeningDateTime, opt => opt.MapFrom(src => src.Screening.DateTime));
            //.ForMember(dest => dest.SeatNumbers, opt => opt.MapFrom(src => src.ReservationSeats.Select(rs => rs.Seat.SeatNumber).ToList()));

        CreateMap<Reservation, ReservationListDTO>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Screening.Movie.Name))
            .ForMember(dest => dest.ScreeningDateTime, opt => opt.MapFrom(src => src.Screening.DateTime))
            .ForMember(dest => dest.IsPast, opt => opt.MapFrom(src => src.Screening.DateTime < DateTime.UtcNow));


        CreateMap<CreateReservationDTO, Reservation>()
            .ForMember(dest => dest.UniqueCode, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsCanceled, opt => opt.Ignore())
            .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
            .ForMember(dest => dest.DiscountApplied, opt => opt.Ignore());

        CreateMap<Reservation, ReservationDetailDTO>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Screening.Movie.Name))
            .ForMember(dest => dest.PosterImageUrl, opt => opt.MapFrom(src => src.Screening.Movie.PosterImage))
            .ForMember(dest => dest.ScreeningDateTime, opt => opt.MapFrom(src => src.Screening.DateTime))
            .ForMember(dest => dest.TicketPrice, opt => opt.MapFrom(src => src.Screening.TicketPrice))
            //.ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.ReservationSeats.Select(rs => rs.Seat).ToList()))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating != null ? src.Rating.Stars : (int?)null));



        CreateMap<User, UserResponseDTO>();
        CreateMap<User, UserListDTO>();
        CreateMap<User, AuthResponseDto>();

        CreateMap<Rating, RatingResponseDTO>()
            .ForMember(dest => dest.MovieName,
                opt => opt.MapFrom(src => src.Reservation.Screening.Movie.Name));
        CreateMap<RatingCreateDTO, Rating>();
    }
}