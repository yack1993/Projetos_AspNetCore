using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Schedule.Application.Dto;
using Schedule.Application.Repositories;

namespace Schedule.Application.UseCases.Books.UpdateBook
{
    public sealed class UpdateBookUseCase : IUpdateBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookUseCase(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Result> Execute(string id, Book bookIn)
        {
            try
            {
                var obj = _mapper.Map<Book>(bookIn);

                 _bookRepository.UpdateBook(id, obj);

                var result = new Result
                {
                    Message = "Sucesso",
                    Sucess = false
                };

                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
