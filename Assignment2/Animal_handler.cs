using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Park
{
    class Animal_handler
    {
        private List<uint> Animal_Ids = new List<uint>();

        /// <summary>
        /// Creates a Bird animal object
        /// </summary>
        /// <param name="type_of_bird"></param>
        /// <param name="Maxspeed"></param>
        /// <param name="Habitat"></param>
        /// <returns></returns>
        public Bird Create_bird(Bird_list type_of_bird, UInt32 Maxspeed, String Habitat)
        {
            Bird animal = null;

            switch (type_of_bird)
            {
                case Bird_list.Raven:
                    animal = new Raven(Maxspeed, Habitat);
                    break;
                case Bird_list.Owl:
                    animal = new Owl(Maxspeed, Habitat);
                    break;
            }
            return (Bird)animal;
        }
        /// <summary>
        /// Creates general Fish animal object
        /// </summary>
        /// <param name="type_of_fish"></param>
        /// <param name="Maxspeed"></param>
        /// <param name="Maxdepth"></param>
        /// <returns></returns>
        public Fish Create_fish(Fish_list type_of_fish, UInt32 Maxspeed, UInt32 Maxdepth)
        {
            Fish animal = null;

            switch (type_of_fish)
            {
                case Fish_list.Salmon:
                    animal = new Salmon(Maxspeed, Maxdepth);
                    break;
                case Fish_list.Shark:
                    animal = new Shark(Maxspeed, Maxdepth);
                    break;
            }
            return (Fish)animal;
        }
        /// <summary>
        /// Creates insect animal object
        /// </summary>
        /// <param name="type_of_insect"></param>
        /// <param name="Habitat"></param>
        /// <param name="N_legs"></param>
        /// <param name="N_wings"></param>
        /// <returns></returns>
        public Insect Create_insect(Insect_list type_of_insect, String Habitat, UInt32 N_legs, UInt32 N_wings)
        {
            Insect animal = null;

            switch (type_of_insect)
            {
                case Insect_list.Ant:
                    animal = new Ant(Habitat, N_legs, N_wings);
                    break;
                case Insect_list.Butterfly:
                    animal = new Butterfly(Habitat, N_legs, N_wings);
                    break;
            }
            return (Insect)animal;
        }
        /// <summary>
        /// Creates mammal object
        /// </summary>
        /// <param name="type_of_mammal"></param>
        /// <param name="Tail_Length"></param>
        /// <param name="Color"></param>
        /// <returns></returns>
        public Mammal Create_mammal(Mammal_list type_of_mammal, UInt32 Tail_Length, String Color)
        {
            Mammal animal = null;

            switch (type_of_mammal)
            {
                case Mammal_list.Cat:
                    animal = new Cat(Tail_Length, Color);
                    break;
                case Mammal_list.Dog:
                    animal = new Dog(Tail_Length, Color);
                    break;
                case Mammal_list.Horse:
                    animal = new Horse(Tail_Length, Color);
                    break;
            }
            return (Mammal)animal;
        }
        /// <summary>
        /// Creates reptile object
        /// </summary>
        /// <param name="type_of_reptile"></param>
        /// <param name="N_legs"></param>
        /// <param name="Poison_bite"></param>
        /// <returns></returns>
        public Reptile Create_reptile(Reptile_list type_of_reptile, UInt32 N_legs, Boolean Poison_bite)
        {
            Reptile animal = null;

            switch (type_of_reptile)
            {
                case Reptile_list.Crocodile:
                    animal = new Crocodile(N_legs, Poison_bite);
                    break;
                case Reptile_list.Snake:
                    animal = new Snake(N_legs, Poison_bite);
                    break;
                case Reptile_list.Turtle:
                    animal = new Turtle(N_legs, Poison_bite);
                    break;
            }
            return (Reptile)animal;
        }
    }
}
