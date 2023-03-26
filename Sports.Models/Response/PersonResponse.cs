namespace Sports.Response.Models;

public record class PersonResponse(
int PersonId,
string FirstName,
string LastName,
bool IsAuthorised,
bool IsValid,
bool IsEnabled,
ICollection<SportResponse> Sports
);
