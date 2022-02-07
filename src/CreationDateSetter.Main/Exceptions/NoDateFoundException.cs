namespace CreationDateSetter.Main.Exceptions
{
    [System.Serializable]
    public class NoDateFoundException : Exception
    {
        public NoDateFoundException() { }
        public NoDateFoundException(string message) : base(message) { }
        public NoDateFoundException(string message, Exception inner) : base(message, inner) { }
        protected NoDateFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
