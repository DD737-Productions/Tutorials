
/**

    Hello, who ever you are!
    Today we are talking about Generics!

    We'll create a class!

    I'm of course talking about the class System.Collections.Generic.Queue<T> or, if you imported System.Collections.Generic, just Queue<T>.

    This class stores data like an array, but it doesn't have a maximum size. That means you can just insert more and more data and the program will not throw any exceptions.

    We recreated the class System.Collections.Queue in the last tutorial so if you wanna know how we wrote the template we are using, check it out!

    As I said, we are using the Queue class from the last tutorial as a template. Here it is:

*/


namespace System.Collection.Tutorial
{

    public class Queue
    {

        class Elem
        {

            public Elem Prev;
            public Elem Next;

            public object Data;

            public Elem(object data, Elem prev, Elem next)
            {

                Data = data;

                Prev = prev;
                Next = next;

            }

        }

        public int Length { get; private set; }

        Elem Head, Tail; 

        public Queue()
        {

            Length = 0;

            Head = new Elem(null, Head, Tail); 
            Tail = new Elem(null, Head, Tail);

        }

        public void Enqueue(object data)
        {

            Elem Data = new Elem(data, Head, Head.Next);

            Head.Next = Data;
            Data.Next.Prev = Data;

            Length++;

        }

        public object Dequeue () 
        {

            if (Length < 1)
                return null;

            Elem Data = Tail.Prev;

            Data.Prev.Next = Tail;
            Tail.Prev = Data.Prev;

            Length--;

            return Data.Data;

        }

    }

}

/*

    We use this class and just modify it a little because we want it to be a generic class!

    But how do generics work and what are they?

*/

/*

    Generics are a special type of classes, structs and methods.

    Generics have the abbility to handle multible TYPE of variables.

    For example:
        You have a class which stores int variables.
        But you want to store float variables.
        What do you do?

        Rewrite the class but instead of ints you use floats?
        In very big classes this is NOT an option.

        Replace int with object?
        This would take some time but it would work but there is still a huge problem:
        If you want to GET data from this saver, it would return an object and how do you know in which type you have to convert?
        Let's say you strored ints, floats and strings if the given object was a string but convert it to an int you would get an exception.

        So what to do?
        You turn the class generic!
        If the class is generic it could even handle bools and strings and OTHER CLASSES!

    So with this in mind, what do we do to turn a class generic?

*/

/*

    Here comes my example:
    Our class was designed to be easily turned into a generic class.

    So first we have to say the compiler that this class is generic.
    We can tell this by deklaring a specific type of sysntax right after the class name.

    public class Queue "<TYPE>" ...

    We can replace TYPE with whatever we want but a 'T' is common used.

    After that we replace EVERY object with T and you will get errors!

    The problem are the nulls.

    There are indeed System.Type s which can't be null.

    Does that mean we can't give a variable a DEFAULT VALUE?

    Well of course we can!

    Replace every null with defaul(T) and you'll notice that you do NOT have ANY ERRORS anymore!

    And that's it!

    Here comes the generic class but thats all!

*/

namespace System.Collection.Generic.Tutorial // Different namespace because its a different tutorial :)
{

    public class Queue <T> // Here is the syntax!
    {

        class Elem // Elem is pretty much the same except ...
        {

            public Elem Prev;
            public Elem Next;

            public T Data; // ... this little guy. It was once an object!

            public Elem(T/* We need to update the Type here ... */ data, Elem prev, Elem next)
            {

                Data = data;

                Prev = prev;
                Next = next;

            }

        }

        public int Length { get; private set; }

        Elem Head, Tail;

        public Queue()
        {

            Length = 0;

            Head = new Elem(default(T) /* Updating null ... */, Head, Tail);
            Tail = new Elem(default(T) /* Same */, Head, Tail);

        }

        public void Enqueue(T data) // Replacing object ...
        {

            Elem Data = new Elem(data, Head, Head.Next);

            Head.Next = Data;
            Data.Next.Prev = Data;

            Length++;

        }

        public object Dequeue()
        {

            if (Length < 1)
                return null;

            Elem Data = Tail.Prev;

            Data.Prev.Next = Tail;
            Tail.Prev = Data.Prev;

            Length--;

            return Data.Data;

        }

    }

}

/*

    That was it!

    Thanks for reading, I hope you enjoyed it and learned something!

    Check out my next tutorial because ... well just do it!

    See ya!

*/
