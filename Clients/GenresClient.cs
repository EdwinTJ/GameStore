using GameStore.Models;

namespace GameStore.Clients;
public class GenresClient
{
    private readonly Genre[] genres =
        [
            new(){
                Id = 1,
                Name = "Fighting"
            },

             new(){
                Id = 2,
                Name = "RolePlaying"
            },

         new(){
                Id = 3,
                Name = "Sport"
            },

         new(){
                Id = 4,
                Name = "Racing"
            },

            new(){
                Id = 5,
                Name = "Other"
            }
        ];

    public Genre[] GetGenres () { return genres; }
}
