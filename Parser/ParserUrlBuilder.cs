namespace Parser
{
    public class ParserUrlBuilder
    {
        private string _city = string.Empty;
        private string _okved = string.Empty;
        private bool _hasPhone;
        private bool _hasWebsite;
        private bool _hasEmail;
        private bool _work = true;

        public ParserUrlBuilder SetCity(string city)
        {
            _city = city;
            return this;
        }

        public ParserUrlBuilder SetOkved(string okved)
        {
            _okved = okved;
            return this;
        }

        public ParserUrlBuilder SetPhone(bool hasPhone)
        {
            _hasPhone = hasPhone;
            return this;
        }

        public ParserUrlBuilder SetWebsite(bool hasWebsite)
        {
            _hasWebsite = hasWebsite;
            return this;
        }

        public ParserUrlBuilder SetEmail(bool hasEmail)
        {
            _hasEmail = hasEmail;
            return this;
        }

        public ParserUrlBuilder SetWork(bool work)
        {
            _work = work;
            return this;
        }

        public string Build(string baseUrl)
        {
            var parameters = new List<string>
            {
                $"val={_city}",
                "type=address"
            };

            if (_work)
                parameters.Add("work=on");

            if (_hasPhone)
                parameters.Add("is_phone=on");

            if (_hasWebsite)
                parameters.Add("is_www=on");

            if (_hasEmail)
                parameters.Add("is_email=on");

            parameters.Add($"okved={_okved}");

            return $"{baseUrl}/search?{string.Join("&", parameters)}";
        }
    }
}
