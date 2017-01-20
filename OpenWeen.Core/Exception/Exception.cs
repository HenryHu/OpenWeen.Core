namespace OpenWeen.Core.Exception
{
    public class WeiboException : System.Exception
    {
        public WeiboException() { }
        public WeiboException(string message) : base(message) { }
        public WeiboException(string message, System.Exception inner) : base(message, inner) { }
    }
    public class InvalidLoginDataException : System.Exception
    {
        public InvalidLoginDataException()
        {
        }

        public InvalidLoginDataException(string message) : base(message)
        {
        }

        public InvalidLoginDataException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class InvalidAccessTokenException : System.Exception
    {
        public InvalidAccessTokenException()
        {
        }

        public InvalidAccessTokenException(string message) : base(message)
        {
        }

        public InvalidAccessTokenException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class InvalidResponseException : System.Exception
    {
        public InvalidResponseException()
        {
        }

        public InvalidResponseException(string message) : base(message)
        {
        }

        public InvalidResponseException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class InvalidIDException : System.Exception
    {
        public InvalidIDException()
        {
        }

        public InvalidIDException(string message) : base(message)
        {
        }

        public InvalidIDException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class ShortUrlException : System.Exception
    {
        public ShortUrlException()
        {
        }

        public ShortUrlException(string message) : base(message)
        {
        }

        public ShortUrlException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}