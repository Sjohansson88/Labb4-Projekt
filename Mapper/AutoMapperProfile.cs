using AutoMapper;
using SUT23_Labb4.DTO;
using SUT23_Labb4Models;

namespace SUT23_Labb4.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();

            
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
        }
    }
}
