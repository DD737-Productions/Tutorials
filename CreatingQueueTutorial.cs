
/**

    Hello, who ever you are!
    Today we create a class!

    Well not just a class, but a very useful class.

    I'm of course talking about the class System.Collections.Queue or, if you imported System.Collections, just Queue.

    This class stores data like an array, but it doesn't have a maximum size. That means you can just insert more and more data and the program will not throw any exceptions.

    As I said, we try to recreate this class because this can help you thinking of other ways of reaching a goal.
    Maybe I can even blow your mind with this simple but complicated sounding class!

*/

/*

    So at first, we have to think about how we wanna store the data?
    Of course we could just use an actual Queue and use this class just as something like a mask but then it wouldn't be a tutorial anymore, right?

    So how do we store data?

    First, we have to create a sup class. A class which stores one piece of data.
    In this class we will also store a reference to the next and previous element.
    With this method the elements of the Queue will act like a chain, but still we have no access to these elements.

*/

/*

    A very simple solution is storing these elements in an array with the size of the number of elements we have and everytime a new element gets added, we create a new array with an increased size.
    This would work fine. It's even really simple but there is ONE big issue.

    This method is slow. VERY slow.
    If you use this method just casually and you are just adding a little bit of data, this will not impact the program much, but if you store hundreds of pieces of data, your program will get really slow.

    So what do we do?

    Since we create a Queue we just want to manage the very first, and the very last element.

    So in the Queue we could just have a reference to the first and last element.

    'And what is, when we delete an element? How do we get a new reference?' you might ask.

    Well the answer is simple. Remember that we gave EVERY element a reference to next and previous element?
    We could just use these ...

    Here is how the class QueueElem could look like:

    class QueueElem
    {

        public QueueElem Next;
        public QueueElem Prev;

        public object Data;

        public QueueElem (object data, QueuElem prev, QueueElem next)
        {
        
            Data = data;

            Prev = prev;
            Next = next;

        }

    }

*/

/*

    So a Queue should have three main methods:
        - a constructor
        - an Enqueue method
        - a Dequeue method

    So basically we could ignore the constructor since we don't need it but later it will become important so I would suggest to implement it.

    What should Enqueue do?
        Enqueue inserts an element at the very start of our chain.

    What should Dequeue do?
        Dequeue deletes the element at the very end of the chain and returns its data.
    
    So this could be the class Queue:

    public class Queue
    {
    
        class QueueElem
        {
        
            public QueueElem Next;
            public QueueElem Prev;

            public int Length { get; private set; }

            public object Data;

            public QueueElem (object data, QueuElem prev, QueueElem next)
            {
        
                Data = data;

                Prev = prev;
                Next = next;

            }

        }  
        
        QueueElem Start;
        QueueElem End;
        
        public Queue ()
        {
        
            Length = 0;

            Start = null;
            End = null;

        }
        
        public void Enqueue (object data)
        {
        
            QueueElem Data = new QueueElem (data, null, Start);

            Start.Prev = Data;

            Start = Data;

            Length ++;

        }  

        public object Dequeue ()
        {

            If (Length <= 0)
                return null;
            
            if (Length == 1)
            {

                object obj = Start.Data;

                Start = null;
                End = null;

                Length = 0;

                return obj;

            }

            QueueElem Data = End;

            End = Data.Prev;

            End.Next = null;

            Length --;

            if (Length == 1)
            {
            
                Start.Next = End;
                End.Prev = Start;

            }

            return Data.Data;

        }

    }

    This implementation would work just fine but I would recommend some improvements ...

*/

/*

    1. Improvement:
        So currently Start and End have references which are null.
        Better is if those references point on Start and End.
        For example:

        null <- Prev <- Strart -> Next -> ...
        Current

        Start <- Prev <- Start -> Next -> ...
        New

        In this way we will never have a null reference.

    2. Improvement:
        We can use something what is called a Dummy Element
        In this way the Queue is never empty and we can remove some If statements, because we don't need the anymore.
        The dummys of course do not effect the Length of the Queue neither what the user sees.
        The user is not able to know if there are dummys elements.

    So let's take a look at the final product ...

*/

namespace System.Collection.Tutorial // Just a quick namespace for you to use
{

    public class Queue
    {

        class Elem // I renamed the class because in this ways it is simpler to write the code and you know that this class is the QueueElem. It is even Queue.Elem ...
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

        public int Length { get; private set; } // You, as a user can GET the Length but you can't SET it

        Elem Head, Tail; // Head and Tail are common names for Queue starts and ends

        public Queue()
        {

            Length = 0;

            Head = new Elem(null, Head, Tail); // Dummy Element
            Tail = new Elem(null, Head, Tail); // Same

        }

        public void Enqueue(object data) // Adding data to the Queue
        {

            Elem Data = new Elem(data, Head, Head.Next); // Generating the new Elem. It is placed BEHIND the Dummy Element

            Head.Next = Data; // Updating the reference
            Data.Next.Prev = Data; // Same

            Length++; // New Elem => bigger size

        }

        public object Dequeue () // Removing data from the Queue
        {

            if (Length < 1) // If there is no data, we can't remove it ...
                return null;

            Elem Data = Tail.Prev; // Last Elem before Dummy ...

            Data.Prev.Next = Tail; // Updating the reference
            Tail.Prev = Data.Prev; // Same

            Length--; // Decreasing the size ...

            return Data.Data; // Returning the stored data

        }

    }

}

/*

    Check out my next tutorial because I will use this class as an example for creating a generic class.

    See ya!

*/