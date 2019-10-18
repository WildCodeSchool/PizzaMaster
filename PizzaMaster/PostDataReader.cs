using System;
using System.IO;
using System.Collections.Specialized;

namespace PizzaMaster
{
    public class PostDataReader
    {
        private StreamReader stream;
        private NameValueCollection _parameters;

        public PostDataReader(Stream stream)
        {
            this.stream = new StreamReader(stream);
            _parameters = new NameValueCollection();
        }

        public string this[string key]
        {
            get {
                string postParameterValue = Parameters[key];
                if (postParameterValue == null)
                {
                    throw new ArgumentException("Set nbPizzas to a value");
                }
                return postParameterValue;
            }
        }

        private NameValueCollection Parameters
        {
            get
            {
                if (_parameters.HasKeys())
                {
                    return _parameters;
                }
                String data = stream.ReadToEnd();
                string[] nameValueAssociations = data.Split('&');
                foreach (string association in nameValueAssociations)
                {   
                    string[] variableInstanciation = association.Split('=');
                    if (variableInstanciation.Length == 2)
                    {
                        _parameters[variableInstanciation[0]] = variableInstanciation[1];
                    }
                }
                return _parameters;
            }
        }
    }
}
