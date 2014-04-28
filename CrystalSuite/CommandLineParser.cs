using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace CrystalSuite
{
    class CommandLineParser
    {
        StringDictionary _parameters;

        //finds all parameters starting with a -, -- or / and all the values
        //parameters can be seperated by a space, colon, or equals.
        //excludes single and double quote enclosing characters
        public CommandLineParser(string[] args)
        {
            _parameters = new StringDictionary();

            string parameter = null;
            string[] parts;

            Regex spliter = new Regex(@"^-{1,2}|^/|=|:",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            Regex remover = new Regex(@"^['""]?(.*?)['""]?$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            foreach (string arg in args)
            {
                parts = spliter.Split(arg, 3);

                switch (parts.Length)
                {
                    case 1:
                        if (parameter != null)
                        {
                            if (!_parameters.ContainsKey(parameter))
                            {
                                parts[0] = remover.Replace(parts[0], "$1");
                                _parameters.Add(parameter, parts[0]);
                            }
                            parameter = null;
                        }
                        break;
                    case 2:
                        if (parameter != null)
                        {
                            if (!_parameters.ContainsKey(parameter)) _parameters.Add(parameter, "true");
                        }
                        parameter = parts[1];
                        break;
                    case 3:
                        if (parameter != null)
                        {
                            if (!_parameters.ContainsKey(parameter)) _parameters.Add(parameter, "true");
                        }
                        parameter = parts[1];
                        if (!_parameters.ContainsKey(parameter))
                        {
                            parts[2] = remover.Replace(parts[2], "$1");
                            _parameters.Add(parameter, parts[2]);
                        }
                        parameter = null;
                        break;
                }

                if (parameter != null)
                {
                    if (!_parameters.ContainsKey(parameter))
                    {
                        _parameters.Add(parameter, "true");
                    }
                }
            }
        }

        public string this[string param]
        {
            get
            {
                return (_parameters[param]);
            }
        }
    }
}
