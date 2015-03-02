using System;
using System.Runtime.Serialization;
using System.Text;

namespace Zen
{
    public class BusinessException : ApplicationException
    {
        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    public class ConfigException : ApplicationException
    {
        public ConfigException()
        {
        }

        public ConfigException(string message)
            : base(message)
        {
        }

        public ConfigException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ConfigException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    public class DataAccessException : ApplicationException
    {
        public DataAccessException()
        {
        }

        public DataAccessException(string message)
            : base(message)
        {
        }

        public DataAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    public class DependencyException : ApplicationException
    {
        public DependencyException()
        {
        }

        public DependencyException(string message)
            : base(message)
        {
        }

        public DependencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DependencyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    /// <summary>
    /// This exception is intended as a wrapper of any logging related exceptions
    /// Note: it is used by the Log4netErrorHandler
    /// </summary>
    /// <remarks>
    /// When this type of error occurs it is most likely due to an configuration
    /// problem or unavailable resource(such as the database or email server)
    /// </remarks>
    public class LoggingException : ApplicationException
    {
        public LoggingException()
        {
        }

        public LoggingException(string message)
            : base(message)
        {
        }

        public LoggingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected LoggingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }


    [Serializable]
    public class CompositeIdNotFoundException : ApplicationException//, ISerializable
    {
        // Operators/Indexer
        public static implicit operator string(CompositeIdNotFoundException ex)
        {
            return ex.ToString();
        }
        
        private const string ClassName = "CompositeIdNotFoundException";
        private const int Hresult = -2146232832;

        
        public CompositeIdNotFoundException()
        {
            HResult = Hresult;
        }

        public CompositeIdNotFoundException(string message)
            : base(message)
        {
            HResult = Hresult;
        }

        public CompositeIdNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            HResult = Hresult;
        }

        protected CompositeIdNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            HResult = Hresult;
        }

        
        //not needed redundant
        //public override void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    base.GetObjectData(info, context);
        //}

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}: {1}", ClassName, Message);

            if (InnerException != null)
                sb.AppendFormat(" ---> {0} <---", base.InnerException);

            if (StackTrace != null)
                sb.Append(Environment.NewLine + base.StackTrace);

            return sb.ToString();
        }

        
    }
}