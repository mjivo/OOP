namespace AuthorProblem
{
    using System;
    [Author("Victor")]
    class StartUp
    {
        [Author("George")]
        static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

}
