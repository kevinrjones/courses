using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleDispatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Asteroid theAsteroid = new Asteroid();
            SpaceShip theSpaceShip = new SpaceShip();
            ApolloSpacecraft theApolloSpacecraft = new ApolloSpacecraft();

            theAsteroid.CollideWith(theSpaceShip);
            theAsteroid.CollideWith(theApolloSpacecraft);
            Console.WriteLine();


            ExplodingAsteroid theExplodingAsteroid = new ExplodingAsteroid();
            theExplodingAsteroid.CollideWith(theSpaceShip);
            theExplodingAsteroid.CollideWith(theApolloSpacecraft);
            Console.WriteLine();

            Asteroid theAsteroidReference = theExplodingAsteroid;
            theAsteroidReference.CollideWith(theSpaceShip);
            theAsteroidReference.CollideWith(theApolloSpacecraft);
            Console.WriteLine();

            //note the type of the reference and the type of the object.
            SpaceShip theSpaceShipReference = theApolloSpacecraft;
            theAsteroid.CollideWith(theSpaceShipReference);
            theAsteroidReference.CollideWith(theSpaceShipReference);

            Console.WriteLine();
            theSpaceShipReference.CollideWith(theAsteroid);
            theSpaceShipReference.CollideWith(theAsteroidReference);
        }
    }

    class SpaceShip
    {
        public virtual void CollideWith(Asteroid inAsteroid)
        {
            inAsteroid.CollideWith(this);
        }
    }

    class ApolloSpacecraft : SpaceShip
    {
        public override void CollideWith(Asteroid inAsteroid)
        {
            inAsteroid.CollideWith(this);
        }        
    }

    class Asteroid
    {
        public virtual void CollideWith(SpaceShip ship)
        {
            Console.WriteLine("Asteroid hit a SpaceShip");
        }
        public virtual void CollideWith(ApolloSpacecraft ship)
        {
            Console.WriteLine("Asteroid hit an ApolloSpacecraft");
        }
    }

    class ExplodingAsteroid : Asteroid
    {

        public override void CollideWith(SpaceShip ship)
        {
            Console.WriteLine("ExplodingAsteroid hit a SpaceShip");
        }
        public override void CollideWith(ApolloSpacecraft ship)
        {
            Console.WriteLine("ExplodingAsteroid hit an ApolloSpacecraft");
        }
    }
}
