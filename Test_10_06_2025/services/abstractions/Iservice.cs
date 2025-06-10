using Test_10_06_2025.contracts.requests;
using Test_10_06_2025.contracts.responses;

namespace Test_10_06_2025.services.abstractions;

public interface Iservice
{
    public Task<bookListResponse> ListBooks(bool? filter,CancellationToken cancellationToken);
    public Task<Boolean> AddBook(BookToAdd book, CancellationToken cancellationToken);
}