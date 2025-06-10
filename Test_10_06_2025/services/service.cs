using Test_10_06_2025.contracts;
using Test_10_06_2025.contracts.requests;
using Test_10_06_2025.contracts.responses;
using Test_10_06_2025.DAL;
using Test_10_06_2025.models;
using Test_10_06_2025.services.abstractions;

namespace Test_10_06_2025.services;

public class service: Iservice
{
    private readonly DbContext1 _context;

    public service(DbContext1 context)
    {
        _context = context;
    }

    public async Task<bookListResponse> ListBooks(CancellationToken cancellationToken)
    {
        bookListResponse response = new bookListResponse();
        var data = _context.Books.ToList();
        foreach (var book in data)
        {
            allInfoBookDTO alldto = new allInfoBookDTO();
            alldto.IdBook = book.IdBook;
            alldto.NameBook = book.Name;
            alldto.ReleaseDate = book.ReleaseDate;
            var publishingHouseDTO = _context.PublishingHouses.Where(house => house.IdPublishingHouse == book.IdPublishingHouse).FirstOrDefault();
            alldto.NamePublishingHouse = publishingHouseDTO.Name;
            
        }
        return response;
    }

    public async Task<Boolean> AddBook(BookToAdd book, CancellationToken cancellationToken)
    {
        return true;
    }
    
}