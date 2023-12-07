using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog : Animal.Animal
    {
        public string Bark()
        {
            return "This animal barks";
        }
    }
}
