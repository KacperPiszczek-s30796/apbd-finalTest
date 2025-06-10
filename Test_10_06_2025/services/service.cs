using Microsoft.EntityFrameworkCore;
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

    public async Task<bookListResponse> ListBooks(bool filter,CancellationToken cancellationToken)
    {
        bookListResponse response = new bookListResponse();
        List<allInfoBookDTO> allInfoBooks = new List<allInfoBookDTO>();
        List<Book> data;
        if (filter)
        {
            data = _context.Books.OrderBy(book => book.ReleaseDate).ToListAsync(cancellationToken).Result;
        }
        else
        {
            data = _context.Books.ToListAsync(cancellationToken).Result;
        }
        foreach (var book in data)
        {
            allInfoBookDTO alldto = new allInfoBookDTO();
            alldto.IdBook = book.IdBook;
            alldto.NameBook = book.Name;
            alldto.ReleaseDate = book.ReleaseDate;
            var publishingHouseDTO = _context.PublishingHouses.Where(house => house.IdPublishingHouse == book.IdPublishingHouse).FirstOrDefaultAsync(cancellationToken).Result;
            alldto.NamePublishingHouse = publishingHouseDTO.Name;
            alldto.Country = publishingHouseDTO.Country;
            alldto.City = publishingHouseDTO.City;
            List<string> genres = new List<string>();
            List<string> authors = new List<string>();
            var bookgenres = _context.BookGenres.Where(genre => genre.IdBook == book.IdBook).ToListAsync(cancellationToken).Result;
            foreach (var bookgenre in bookgenres)
            {
                var genre = _context.Genres.Where(genre => genre.IdGenre == bookgenre.IdGenre).FirstOrDefaultAsync(cancellationToken).Result;
                genres.Add(genre.Name);
            }
            alldto.Genres = genres;
            var authorBooks = _context.BookAuthors.Where(author => author.IdBook == book.IdBook).ToListAsync(cancellationToken).Result;
            foreach (var authorBook in authorBooks)
            {
                var author = _context.Users.Where(a => a.IdAuthor == authorBook.IdAuthor).FirstOrDefaultAsync(cancellationToken).Result;
                authors.Add(author.FirstName + " " + author.LastName);
            }
            alldto.Authors = authors;
            allInfoBooks.Add(alldto);
        }
        response.allInfoBooks = allInfoBooks;
        return response;
    }

    public async Task<Boolean> AddBook(BookToAdd book, CancellationToken cancellationToken)
    {
        try
        {
            var publishingHouse = _context.PublishingHouses
                .Where(house => house.IdPublishingHouse == book.IdPublishingHouse).FirstOrDefaultAsync(cancellationToken).Result;
            if (publishingHouse == null)
            {
                PublishingHouse p = new PublishingHouse();
                p.IdPublishingHouse = book.IdPublishingHouse;
                p.Name = book.NamePublishingHouse;
                p.Country = book.Country;
                p.City = book.City;
                _context.PublishingHouses.Add(p);
            }
        }
        catch (Exception e)
        {
            try
            {
                PublishingHouse p = new PublishingHouse();
                p.IdPublishingHouse = book.IdPublishingHouse;
                p.Name = book.NamePublishingHouse;
                p.Country = book.Country;
                p.City = book.City;
                _context.PublishingHouses.Add(p);
            }
            catch (Exception exception)
            {
                
            }
        }
        Book newBook = new Book();
        newBook.IdBook = book.IdBook;
        newBook.Name = book.NameBook;
        newBook.ReleaseDate = book.ReleaseDate;
        newBook.IdPublishingHouse = book.IdPublishingHouse;
        _context.Books.Add(newBook);
        foreach (var author in book.IdAuthors)
        {
            _context.BookAuthors.Add(new BookAuthor { IdAuthor = author, IdBook = newBook.IdBook });
        }

        foreach (var genre in book.IdGenres)
        {
            _context.BookGenres.Add(new BookGenre { IdGenre = genre, IdBook = newBook.IdBook });
        }
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
}