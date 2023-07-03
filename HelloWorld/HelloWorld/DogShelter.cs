using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class DogShelter : IEnumerable<DogForEnumerating>
    {
        public List<DogForEnumerating> dogs;

        public DogShelter()
        {
            dogs = new List<DogForEnumerating>
            {
                new DogForEnumerating("Casper", false),
                new DogForEnumerating("Sif",    true),
                new DogForEnumerating("Oreo",   false),
                new DogForEnumerating("Pixel",  false)
            };
        }

        IEnumerator<DogForEnumerating> IEnumerable<DogForEnumerating>.GetEnumerator()
        {
            return dogs.GetEnumerator(); // Get the Enumerator from the "dogs" list
        }

        IEnumerator IEnumerable.GetEnumerator() // Ignoring the non-generic version
        {
            throw new NotImplementedException();
        }
    }
}
