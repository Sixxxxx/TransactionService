using AutoMapper;
using TransactionsService.Dtos;
using TransactionsService.Models;

namespace TransactionsService.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDtoForCreate>().ReverseMap();
        }
    }
}
