using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            //            SimpleIterator();

            //            Composite();

            Person kevin = new Person();

            kevin.Add(new Book { Title = "Catch-22", Author = "Heller", Price = 9.99m });
            kevin.Add(new Book { Title = "A Brief History Of Time", Author = "Hawking", Price = 10.99m });
            kevin.Add(new Book { Title = "GOF", Author = "GOF", Price = 22.99m });

            kevin.Add(new CompactDisk { Title = "UB40's Greatest Hits", Price = 10m});
            kevin.Add(new DigitalVersatileDisk { Title = "Ex Machina", Price = 20m });

            PriceVisitor visitor = new PriceVisitor();

            foreach (var possesion in kevin.Find(null))
            {
                possesion.Accept(visitor);
            }

            Console.WriteLine(visitor.Price);
        }

        private static void Composite()
        {
            TodoItemContainer container = new TodoItemContainer { Title = "Container" };
            container.Add(new TodoItem { Title = "todo 1" });
            container.Add(new TodoItem { Title = "todo 2" });
            container.Add(new TodoItem { Title = "todo 3" });

            TodoItemContainer nestedContainer = new TodoItemContainer { Title = "Nested Container" };
            nestedContainer.Add(new TodoItem { Title = "Nested 1" });
            nestedContainer.Add(new TodoItem { Title = "Nested 2" });

            container.Add(nestedContainer);

            foreach (var child in container.FindAll())
            {
                Console.WriteLine(child.Title);
            }
        }

        private static void SimpleIterator()
        {
            Person kevin = new Person();
            kevin.Add(new Book { Title = "Catch-22", Author = "Heller", Price = 9.99m });
            kevin.Add(new Book { Title = "A Brief History Of Time", Author = "Hawking", Price = 10.99m });
            kevin.Add(new Book { Title = "GOF", Author = "GOF", Price = 22.99m });
            foreach (var book in kevin.Find(b => b.Title == "Catch-22"))
            {
                Console.WriteLine(book.Title);
            }
        }
    }

    public abstract class Todo
    {
        // container
        public virtual void Add(Todo item)
        {
            throw new NotImplementedException();
        }

        // item
        public virtual void Delete()
        {

        }

        public string Title { get; set; }
        public abstract bool IsDone { get; set; }

        public abstract IEnumerable<Todo> Children { get; }


        public virtual IEnumerable<Todo> FindAll()
        {
            yield return this;

            foreach (Todo cpt in this.Children)
            {
                foreach (Todo child in cpt.FindAll())
                {
                    yield return child;
                }
            }
        }

    }

    public class TodoItemContainer : Todo
    {
        private List<Todo> _children = new List<Todo>();
        public override bool IsDone
        {
            get { return false; }
            set { }
        }

        public override IEnumerable<Todo> Children
        {
            get { return _children; }
        }

        public override void Add(Todo item)
        {
            _children.Add(item);
        }
    }

    public class TodoItem : Todo
    {
        public override bool IsDone { get; set; }

        public override IEnumerable<Todo> Children
        {
            get { yield break; }
        }

        public override void Delete()
        {
            // mark self as deleted
        }
    }
}
