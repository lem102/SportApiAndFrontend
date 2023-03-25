namespace SportsApi.Models;

public record class Person(
int PersonId,
string FirstName,
string LastName,
bool IsAuthorised,
bool IsValid,
bool IsEnabled,
ICollection<Sport> Sports
);
